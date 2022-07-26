using System;
using System.IO;
using System.Net;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AInt16 : DataType
    {
        internal AInt16() : base("Int16", 2, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadInt16();
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
