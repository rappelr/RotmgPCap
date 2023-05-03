using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Packets.DataTypes.Primitive;
using System.Collections.Generic;

namespace RotmgPCap.Packets
{
    internal class PacketReaderProfile
    {
        internal Dictionary<string, DataType> Types;
        internal Dictionary<string, Option> Options;
        internal Dictionary<string, NamedEnum> Enums;

        internal PacketReaderProfile()
        {
            Types = new Dictionary<string, DataType>();
            Options = new Dictionary<string, Option>();
            Enums = new Dictionary<string, NamedEnum>();

            Add(new AByte());
            Add(new ASByte());
            Add(new AInt16());
            Add(new AUInt16());
            Add(new AInt32());
            Add(new AUInt32());
            Add(new AFloat());
            Add(new ACompressed());
            Add(new AUtf());
            Add(new ABoolean());
            Add(new AVoid());
        }

        internal bool Add(DataType type)
        {
            if (Types.ContainsKey(type.Name))
                return false;

            Types.Add(type.Name, type);
            return true;
        }

        internal bool Add(Option option)
        {
            if (Options.ContainsKey(option.Name))
                return false;

            Options.Add(option.Name, option);
            return true;
        }

        internal bool Add(NamedEnum @enum)
        {
            if (Enums.ContainsKey(@enum.Name))
                return false;

            Enums.Add(@enum.Name, @enum);
            return true;
        }
    }
}
