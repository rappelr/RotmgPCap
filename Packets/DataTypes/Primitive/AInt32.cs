using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AInt32 : DataType
    {
        internal AInt32() : base("Int32", 4, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadInt32();
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
