using RotmgPCap.Util;
using System;
using System.Collections.Generic;

namespace RotmgPCap.Packets
{
    internal class Packet
    {
        internal readonly bool? Incoming;
        internal readonly long Time;
        internal readonly byte[] Data;
        internal readonly bool Captured;

        internal PacketProto Proto { get; private set; }

        internal int Length => Data.Length - 5;

        internal Packet(PacketProto proto, bool? incoming, long time, byte[] data, bool captured)
        {
            Proto = proto;
            Incoming = incoming;
            Time = time;
            Data = data;
            Captured = captured;
        }

        internal string FormatName() => Proto.Name;
        internal string FormatNameId() => $"{Proto.Name} ({Proto.Id})";
        internal string FormatData() => Length + " bytes";
        internal string FormatTime(bool full = false) => Time == -1 ? "Unknown" : full ? TimeUtil.FormatFullUnix(Time) : TimeUtil.FormatShortUnix(Time);
        internal string FormatDirection(bool full = true) => full ? (Incoming.HasValue ? (Incoming.Value ? "Incoming" : "Outgoing") : "Unknown") :
            Incoming.HasValue ? (Incoming.Value ? "Inc" : "Out") : "Unk";

        internal void ApplyProto(PacketManager manager) => Proto = manager.GetOrCreate(Proto.Id);

        internal static Packet[] Parse(PacketManager manager, byte[] data)
        {
            if (data == null || data.Length < 5)
                throw new Exception("Invalid packet data");

            var result = new List<Packet>();
            int offset = 0;

            while(offset < data.Length - 1)
            {
                int length = 0;
                length |= data[offset + 0] << 24;
                length |= data[offset + 1] << 16;
                length |= data[offset + 2] << 8;
                length |= data[offset + 3];

                if(data.Length < (offset + length))
                    throw new Exception("Invalid packet data");

                byte[] packetData = new byte[length];
                Array.Copy(data, offset, packetData, 0, length);
                PacketProto proto = manager.GetOrCreate(data[offset + 4]);

                result.Add(new Packet(proto, null, -1, packetData, false));

                offset += length;
            }

            return result.ToArray();
        }
    }
}
