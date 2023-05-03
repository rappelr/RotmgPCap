using System.Collections.Generic;

namespace RotmgPCap.Packets.DataTypes
{
    internal class NamedEnum
    {
        internal readonly string Name;
        internal readonly Dictionary<int, string> Values;

        internal NamedEnum(string name, Dictionary<int, string> values)
        {
            Name = name;
            Values = values;
        }
    }
}
