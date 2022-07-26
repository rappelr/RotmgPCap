using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes
{
    internal class GroupType : DataType
    {
        internal readonly TypeInstance[] Types;

        internal GroupType(string name, TypeInstance[] types, int minLength, bool fixedLength) : base(name, minLength, fixedLength)
        {
            Types = types;
        }

        internal override string Read(PacketReader reader, out object result)
        {
            result = new TypeInstance[Types.Length];

            try
            {
                TypeInstance[] cResult = (TypeInstance[])result;

                for (int i = 0; i < Types.Length; i++)
                {
                    bool success = reader.Read(Types[i]);
                    cResult[i] = Types[i];

                    if (!success)
                        return Types[i].Result.ErrorMessage;
                }

                return null;
            }
            catch (EndOfStreamException)
            {
                return "End of stream reached";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Unknown issue";
            }
        }

        internal override TypeInstance Instance(string name, bool referencable = false)
        {
            TypeInstance[] instanced = new TypeInstance[Types.Length];

            for (int i = 0; i < Types.Length; i++)
                instanced[i] = Types[i].Type.Instance(Types[i].Name, Types[i].Referencable);

            return new TypeInstance(new GroupType(Name, instanced, MinLength, FixedLength), name, referencable);
        }
    }
}
