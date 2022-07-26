using System;
using System.IO;
using System.Text;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AUtf : DataType
    {
        internal AUtf() : base("Utf", 1, false) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt16()));
                return null;
            }
            catch(Exception e)
            {
                result = null;

                if (e is EndOfStreamException || e is ArgumentOutOfRangeException)
                    return "End of stream reached";

                if(e is ArgumentException)
                    return "Encoding error";

                return "Unknown error";
            }
        }
    }
}
