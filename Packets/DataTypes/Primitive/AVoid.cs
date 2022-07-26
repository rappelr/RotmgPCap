namespace RotmgPCap.Packets.DataTypes.Primitive
{
    internal class AVoid : DataType
    {
        internal AVoid() : base("Void",  0, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            result = "Void (no value required)";
            return null;
        }
    }
}
