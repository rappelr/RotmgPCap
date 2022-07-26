using RotmgPCap.Packets.DataTypes.Primitive;

namespace RotmgPCap.Packets.DataTypes
{
    internal class PacketHeader : GroupType
    {
        internal PacketHeader() : base("PacketHeader", new TypeInstance[]
        {
            new AInt32().Instance("Length"),
            new AByte().Instance("Id")
        }, 5, true)
        { }

        internal TypeInstance Instance() => Instance(Name);
    }
}
