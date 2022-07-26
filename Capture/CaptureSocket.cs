using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RotmgPCap.Capture
{
    internal class CaptureSocket
    {
        private static readonly object queueLock = new object();
        private static readonly PacketArrivalEventHandler arrivalEventHandler;
        private static readonly CaptureStoppedEventHandler stoppedEventHandler;

        private static CaptureManager manager;
        private static ICaptureDevice device;
        private static ushort port;

        private static List<RawCapture> packetQueue = new List<RawCapture>();
        private static Thread thread;

        private static CapturePacket incomingPacket, outgoingPacket;
        private static bool active, closing;

        static CaptureSocket()
        {
            arrivalEventHandler = new PacketArrivalEventHandler(OnPacketArrival);
            stoppedEventHandler = new CaptureStoppedEventHandler(OnCaptureStopped);
        }

        internal static bool Start(CaptureManager manager, ICaptureDevice device, ushort port, int? timeout)
        {
            if (active)
                return false;

            if (closing)
                thread.Join();

            CaptureSocket.manager = manager;
            CaptureSocket.device = device;
            CaptureSocket.port = port;

            closing = false;

            thread = new Thread(() => Run());
            thread.Start();
            
            try
            {
                device.OnPacketArrival += arrivalEventHandler;

                if(timeout.HasValue)
                    device.Open(DeviceMode.Promiscuous, timeout.Value);
                else
                    device.Open(DeviceMode.Promiscuous);

                device.Filter = "ip and tcp";
                device.StartCapture();

                active = true;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Close(true);
                return false;
            }
        }

        internal static void Close(bool join = false)
        {
            if (!active)
                return;

            if(closing)
            {
                thread.Join();
                return;
            }

            device.StopCapture();
            closing = true;

            if(join)
                thread.Join();

            active = false;
        }

        private static void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (queueLock)
            {
                packetQueue.Add(e.Packet);
            }
        }

        private static void OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            Close(true);
            manager.CaptureError(status == CaptureStoppedEventStatus.ErrorWhileCapturing);
        }

        private static void Run()
        {
            while (!closing)
            {
                bool sleep = true;

                lock (queueLock)
                {
                    if (packetQueue.Count != 0)
                        sleep = false;
                }

                if (sleep)
                    Thread.Sleep(250);
                else
                {
                    List<RawCapture> queue;
                    lock (queueLock)
                    {
                        queue = packetQueue;
                        packetQueue = new List<RawCapture>();
                    }

                    foreach (RawCapture capture in queue)
                        ParseRawPacket(Packet.ParsePacket(capture.LinkLayerType, capture.Data));
                }
            }

            device.OnPacketArrival -= arrivalEventHandler;
        }

        private static void ParseRawPacket(Packet rawPacket)
        {
            try
            {
                var ip = (IpPacket)rawPacket.Extract(typeof(IpPacket));
                var tcp = (TcpPacket)rawPacket.Extract(typeof(TcpPacket));

                if (ip != null && tcp != null && (tcp.SourcePort == port || tcp.DestinationPort == port) && tcp.PayloadData != null)
                    ParsePacketData(ip, tcp, tcp.SourcePort == port);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred while parsing packet:");
                Console.WriteLine(e);
            }
        }

        private static void ParsePacketData(IpPacket ip, TcpPacket tcp, bool incoming)
        {
            CapturePacket targetPacket = incoming ? incomingPacket : outgoingPacket;

            int offset = 0;
            int count = 0;

            while(true)
            {
                count++;

                int tcpRemaining = tcp.PayloadData.Length - offset;

                if (targetPacket == null)
                {
                    if (tcpRemaining == 0)
                        break;

                    if (tcpRemaining < 5)
                    {
                        Console.WriteLine("No target packet, too small tcp data " + tcpRemaining);
                        break;
                    }

                    int length = 0;
                    length |= tcp.PayloadData[offset + 0] << 24;
                    length |= tcp.PayloadData[offset + 1] << 16;
                    length |= tcp.PayloadData[offset + 2] << 8;
                    length |= tcp.PayloadData[offset + 3];

                    targetPacket = new CapturePacket(ip.SourceAddress.ToString(), ip.DestinationAddress.ToString(),
                        tcp.PayloadData[offset + 4], length, incoming);
                }

                int packetRemaining = targetPacket.Remaining;

                //data left for next packet
                if (tcpRemaining < packetRemaining)
                {
                    targetPacket.AddData(tcp.PayloadData, offset, tcpRemaining);
                    if (targetPacket.Incoming)
                        incomingPacket = targetPacket;
                    else
                        outgoingPacket = targetPacket;
                    break;
                }
                
                //data fills last packet
                if(tcpRemaining == packetRemaining)
                {
                    targetPacket.AddData(tcp.PayloadData, offset, tcpRemaining);

                    if (targetPacket.Incoming)
                        incomingPacket = null;
                    else
                        outgoingPacket = null;

                    manager.CaptureSocketCatch(targetPacket);
                    break;
                }

                //data leaves room for another packet
                targetPacket.AddData(tcp.PayloadData, offset, packetRemaining);
                offset += packetRemaining;

                if (targetPacket.Incoming)
                    incomingPacket = null;
                else
                    outgoingPacket = null;

                manager.CaptureSocketCatch(targetPacket);
                targetPacket = null;
            }

            manager.AddPacketsCaught(count);
        }
    }
}
