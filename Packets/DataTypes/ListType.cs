using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes
{
    internal class ListType : DataType
    {
        internal readonly Reference LengthReference;
        internal readonly DataType Type;

        internal ListType(string name, Reference lengthReference, DataType type) : base(name, 0, false)
        {
            LengthReference = lengthReference;
            Type = type;
        }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                if (!reader.Read(LengthReference))
                {
                    result = null;
                    return LengthReference.Value;
                }

                if (!LengthReference.AsInteger(out int length, 0))
                {
                    result = null;
                    return "Invalid reference value, list length cannot be lower than 0";
                }

                result = new TypeInstance[length];
                TypeInstance[] cResult = (TypeInstance[])result;

                for (int i = 0; i < length; i++)
                {
                    TypeInstance current = Type.Instance($"{Name} [{i}]");

                    bool success = reader.Read(current);
                    cResult[i] = current;

                    if (!success)
                        return current.Result.ErrorMessage;
                }

                return null;
            }
            catch (EndOfStreamException)
            {
                result = 0;
                return "End of stream reached";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = null;
                return "Unknown issue";
            }
        }
    }
}
