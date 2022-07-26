using System;

namespace RotmgPCap.Capture
{
    internal class CapturePacket
    {
        internal readonly string SourceAddress, DestinationAddress;
        internal readonly int Length;
        internal readonly byte Id;
        internal readonly bool Incoming;

        internal byte[] Data;

        internal int Remaining => Length - Data.Length;

        internal CapturePacket(string sourceAddress, string destinationAddress, byte id, int length, bool incoming)
        {
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Id = id;
            Length = length;
            Incoming = incoming;
            Data = new byte[0];
        }

        internal void AddData(byte[] data, int offset, int length)
        {
            if (Data == null)
                Data = data;
            else
            {
                byte[] result = new byte[Data.Length + length];
                Array.Copy(Data, result, Data.Length);
                Array.Copy(data, offset, result, Data.Length, length);
                Data = result;
            }
        }
    }
}
