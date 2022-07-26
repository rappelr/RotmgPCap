using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AFloat : DataType
    {
        internal AFloat() : base("Float", 4, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadSingle();
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
