namespace RotmgPCap.Packets.DataTypes
{
    internal class Reference
    {
        internal readonly bool Constant;
        internal readonly string ReferenceTarget;

        internal string Value;

        internal Reference(string value, bool constant = false)
        {
            Constant = constant;

            if(constant)
                Value = value;
            else
                ReferenceTarget = value;
        }

        internal bool AsInteger(out int value) => int.TryParse(Value, out value);

        internal bool AsInteger(out int value, int min) => int.TryParse(Value, out value) && value >= min;
    }
}
