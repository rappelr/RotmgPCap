using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    internal class ASByte : DataType
    {
        internal ASByte() : base("SByte", 1, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadSByte();
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
