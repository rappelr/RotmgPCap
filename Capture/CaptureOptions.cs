using SharpPcap;

namespace RotmgPCap.Capture
{
    internal class CaptureOptions
    {
        internal ICaptureDevice CaptureDevice;

        internal ushort Port;

        internal byte? PacketId;

        internal int? SocketTimeout;

        internal bool FilterUntilSync, FilterACK, FilterPacket;

        internal bool? Direction;
    }
}
