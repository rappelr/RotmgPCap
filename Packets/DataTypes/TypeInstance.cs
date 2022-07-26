namespace RotmgPCap.Packets.DataTypes
{
    class TypeInstance
    {
        internal readonly DataType Type;
        internal readonly string Name;
        internal readonly bool Referencable;

        internal ReadResult Result { get; set; }

        internal TypeInstance(DataType type, string name, bool referencable = false)
        {
            Type = type;
            Name = name;
            Referencable = referencable;
        }

        internal void Clear()
        {
            Type.Clear();
            Result = null;
        }
    }
}
