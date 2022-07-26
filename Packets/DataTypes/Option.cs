namespace RotmgPCap.Packets.DataTypes
{
    internal class Option
    {
        internal readonly string Name;
        internal readonly string[] Options;

        internal Option(string name, string[] options)
        {
            Name = name;
            Options = options;
        }

        internal bool Match(int value)
        {
            foreach (string option in Options)
                if (int.TryParse(option, out int asInt) && asInt == value)
                        return true;
            return false;
        }

        internal bool Match(string value)
        {
            foreach (string option in Options)
                if (option == value)
                    return true;
            return false;
        }
    }
}
