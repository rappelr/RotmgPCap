using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    internal class AByte : DataType
    {
        internal AByte() : base("Byte", 1, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadByte();
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
