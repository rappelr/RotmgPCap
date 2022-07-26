using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AUInt16 : DataType
    {
        internal AUInt16() : base("UInt16", 2, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadUInt16();
                return null;
            }
            catch (EndOfStreamException)
            {
                result = null;
                return "End of stream reached";
            }
            catch (Exception e)
            {
                result = null;
                Console.WriteLine(e);
                return "Unknown issue";
            }
        }
    }
}
