namespace RotmgPCap.Packets.DataTypes
{
    internal class EnumValue : DataType
    {
        internal readonly string TargetEnum;
        internal readonly DataType NumberType;

        internal EnumValue(string targetEnum, DataType numberType)
            : base(targetEnum, numberType.MinLength, numberType.FixedLength)
        {
            TargetEnum = targetEnum;
            NumberType = numberType;
        }

        internal override string Read(PacketReader reader, out object result)
        {
            result = null;

            if (!reader.Profile.Enums.TryGetValue(TargetEnum, out NamedEnum @enum))
                return "Missing enum \"" + TargetEnum + "\"";

            if (NumberType.Read(reader, out object res) is string str)
                return str;

            if (@enum.Values.TryGetValue((int)res, out string name)) {
                result = name;
                return null;
            }

            return $"Enum {res} unknown for enum {TargetEnum}";
        }
    }
}
