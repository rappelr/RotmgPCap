namespace RotmgPCap.Packets.DataTypes
{
    internal abstract class DataType
    {
        internal readonly string Name;
        internal readonly int MinLength;
        internal readonly bool FixedLength;

        internal DataType(string name, int minLength, bool fixedLength)
        {
            Name = name;
            MinLength = minLength;
            FixedLength = fixedLength;
        }

        internal virtual TypeInstance Instance(string name, bool referencable = false) => new TypeInstance(this, name, referencable);
        
        internal abstract string Read(PacketReader reader, out object result);

        internal virtual void Clear() { }
    }
}
