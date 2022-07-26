using RotmgPCap.Packets.DataTypes;

namespace RotmgPCap.Packets
{
    internal class PacketStructure
    {
        internal readonly string Name;
        internal readonly byte Id;
        internal readonly TypeInstance[] Types;

        internal PacketStructure(string name, byte id, TypeInstance[] types)
        {
            Name = name;
            Id = id;
            Types = types;
        }

        internal void Clear()
        {
            foreach (TypeInstance type in Types)
                type.Clear();
        }
    }
}
