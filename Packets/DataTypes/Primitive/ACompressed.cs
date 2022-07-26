using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class ACompressed : DataType
    {
        internal ACompressed() : base("Compressed", 1, false) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                byte num1 = reader.ReadByte();
                bool flag = (num1 & 64U) > 0U;
                int num2 = 6;
                int num3 = num1 & 63;

                while ((num1 & 128) > 0)
                {
                    try
                    {
                        num1 = reader.ReadByte();
                    }
                    catch (EndOfStreamException)
                    {
                        result = null;
                        return "End of stream reached";
                    }

                    num3 |= (num1 & sbyte.MaxValue) << num2;
                    num2 += 7;
                }

                result = flag ? -num3 : num3;
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
