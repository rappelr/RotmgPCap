﻿using RotmgPCap.Packets;
using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Util;
using SharpPcap;
using System;
using System.Collections.Generic;

namespace RotmgPCap.Capture
{
    internal class CaptureManager
    {
        internal Dictionary<string, ICaptureDevice> NetworkDevices { get; private set; }

        private readonly RotmgPCapCore rotmgPCap;

        private byte? packetId;
        private bool? direction;
        private bool initial, inSync, outSync, FilterUntilSync, filterAck, filterPacket;

        internal CaptureManager(RotmgPCapCore rotmgPCap)
        {
            this.rotmgPCap = rotmgPCap;

            NetworkDevices = new Dictionary<string, ICaptureDevice>();
        }

        internal bool Start(CaptureOptions options)
        {
            Stop();
            Crypto.Reset();

            initial = true;
            inSync = outSync = false;

            packetId = options.PacketId;
            direction = options.Direction;
            FilterUntilSync = options.FilterUntilSync;
            filterAck = options.FilterACK;
            filterPacket = options.FilterPacket;

            return CaptureSocket.Start(this, options.CaptureDevice, options.Port, options.SocketTimeout);
        }

        internal void Stop()
        {
            CaptureSocket.Close(true);
            rotmgPCap.FinishCapturing(false);
        }

        internal bool LoadCaptureDevices()
        {
            try
            {
                CaptureDeviceList devices = CaptureDeviceList.Instance;

                foreach (ICaptureDevice dev in devices)
                    if(dev.FriendlyName != null)
                        NetworkDevices.Add(dev.FriendlyName, dev);

                return NetworkDevices.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        internal void AddPacketsCaught(int count) => rotmgPCap.AddPacketsCaught(count);

        internal void CaptureSocketCatch(CapturePacket capturePacket)
        {
            PacketStructure structure = rotmgPCap.PacketManager.GetOrCreate(capturePacket.Id);
            
            if (structure.Id == 1)
            {
                Crypto.Reset(false);
                outSync = true;
                rotmgPCap.SetSync(false);
            }
            else if (structure.Id == 92)
            {
                Crypto.Reset(true);
                inSync = true;
                rotmgPCap.SetSync(true);
            }

            bool desync = !(capturePacket.Incoming ? inSync : outSync);

            // filter crypto unsafe
            if (desync && FilterUntilSync)
                return;

            if (initial)
            {
                rotmgPCap.AddressDetected((capturePacket.Incoming ? capturePacket.SourceAddress : capturePacket.DestinationAddress).ToString());
                initial = false;
            }

            (capturePacket.Incoming ? Crypto.Incoming : Crypto.Outgoing).Cipher(capturePacket.Data, 5);

            // filter crypto safe
            if (direction.HasValue && capturePacket.Incoming != direction.Value)
                return;

            if (filterPacket && (packetId.HasValue ? structure.Id != packetId.Value : !structure.Name.StartsWith("Unknown_")))
                return;

            if (filterAck && structure.Name.EndsWith("Ack"))
                return;

            rotmgPCap.AddPacket(new Packet(structure, capturePacket.Incoming, TimeUtil.CurrentUnix(), capturePacket.Data, true));
        }

        internal void CaptureError(bool error)
        {
            rotmgPCap.FinishCapturing(error);
        }
    }
}
