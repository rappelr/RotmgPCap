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
            result = null;

            try
            {
                short byteCount = reader.ReadInt16();

                if (byteCount < 0)
                    return "Proto invalid";

                result = Encoding.UTF8.GetString(reader.ReadBytes(byteCount));
                return null;
            }
            catch(Exception e)
            {
                if (e is EndOfStreamException || e is ArgumentOutOfRangeException)
                    return "End of stream reached";

                if(e is ArgumentException || e is ArgumentOutOfRangeException)
                    return "Encoding error";

                return "Unknown error";
            }
        }
    }
}
