using RotmgPCap.Packets.DataTypes;
using System;
using System.IO;

namespace RotmgPCap.Packets
{
    internal class PacketStructureFileParser
    {

        private readonly PacketManager manager;

        private int genericNameCounter;

        internal PacketStructureFileParser(PacketManager manager) => this.manager = manager;

        internal string ParsePacketStructureFile()
        {

            manager.Profile = new PacketReaderProfile();

            genericNameCounter = 0;
            int counter = 0;
            string line = "";

            try
            {
                StreamReader file;

                try
                {
                    file = new StreamReader("PacketStructures.txt");
                }
                catch
                {
                    return "Failed to load PacketStructures.txt";
                }

                while (true)
                {
                    string readResult = file.ReadLine();

                    if (readResult == null)
                        break;

                    counter++;

                    line += readResult;

                    bool? result = ParseLine(line);

                    if (result == null)
                    {
                        line = line.Replace("+", "");
                        continue;
                    }

                    if (!result.Value)
                    {
                        Console.WriteLine(counter + " Invalid line:\n" + line);
                    }

                    line = "";
                }

                file.Close();
                return null;
            }
            catch
            {
                return "Exception occurred while parsing packet structures:\n" + line;
            }
        }

        private bool? ParseLine(string line)
        {
            line = line.Replace(" ", "");

            int commentIndex = line.LastIndexOf('#');

            if (commentIndex == 0 || line.IndexOf('#') == 0)
                return true;

            if (commentIndex != -1)
                line = line.Substring(0, commentIndex);

            if (string.IsNullOrWhiteSpace(line))
                return true;

            if (line.EndsWith("+"))
                return null;

            int tagIndex = line.IndexOf(';');

            if (tagIndex <= 0)
                return false;

            string tag = line.Substring(0, tagIndex);
            string data = line.Substring(tagIndex + 1);

            if (tag.StartsWith("$"))
                return ParseOption(tag.Substring(1), data);

            if (tag.StartsWith(":"))
                return ParseGroup(tag.Substring(1), data);

            return ParsePacket(tag, data);
        }

        private bool ParsePacket(string tag, string data)
        {
            string[] raw = tag.Split(',');

            if (raw.Length != 2 || !VerifyName(raw[0]) || !byte.TryParse(raw[1], out byte id))
                return false;

            string name = raw[0];

            TypeInstance[] parsedTypes = ParseTypeInstanceList(data, true);

            if (parsedTypes == null)
                return false;

            TypeInstance[] finalTypes = new TypeInstance[parsedTypes.Length + 1];
            Array.Copy(parsedTypes, 0, finalTypes, 1, parsedTypes.Length);
            finalTypes[0] = new PacketHeader().Instance();

            manager.Structures.Add(id, new PacketStructure(name, id, finalTypes));
            return true;
        }

        private bool ParseGroup(string tag, string data)
        {
            if (!VerifyName(tag))
                return false;

            TypeInstance[] types = ParseTypeInstanceList(data);

            if (types == null)
                return false;

            int minLength = 0;
            bool fixedLength = true;

            foreach (TypeInstance type in types)
            {
                minLength += type.Type.MinLength;
                if (fixedLength && !type.Type.FixedLength)
                    fixedLength = false;
            }

            manager.Profile.Add(new GroupType(tag, types, minLength, fixedLength));
            return true;
        }

        private bool ParseOption(string tag, string data)
        {
            if (!VerifyName(tag))
                return false;

            string[] values = data.Split(',');

            if (values.Length == 0)
                return false;

            manager.Profile.Add(new Option(tag, values));
            return true;
        }

        private TypeInstance[] ParseTypeInstanceList(string data, bool allowEmpty = false)
        {
            if (data.Length == 0)
                return allowEmpty ? new TypeInstance[0] : null;

            string[] raw = data.IndexOf(',') == -1 ? new string[] { data } : data.Split(',');

            TypeInstance[] types = new TypeInstance[raw.Length];

            for (int i = 0; i < types.Length; i++)
            {
                TypeInstance type = ParseTypeInstance(raw[i]);

                if (type == null)
                    return null;

                types[i] = type;
            }

            return types;
        }

        private TypeInstance ParseTypeInstance(string data)
        {
            if (data.Length == 0)
                return null;

            int nameIndex = data.LastIndexOf(':');

            if (nameIndex == 0)
                return null;

            string type, name = GenerateGenericName();

            if (nameIndex == -1)
            {
                type = data;
            }
            else if (nameIndex == data.Length - 1)
            {
                type = data.Substring(0, data.Length - 1);
            }
            else
            {
                type = data.Substring(0, nameIndex);
                name = data.Substring(nameIndex + 1);
                genericNameCounter--;
            }

            if (type.StartsWith("("))
            {
                int optionIndex = type.IndexOf('$');
                int repeatIndex = type.IndexOf('*');

                if (type.Length <= 2)
                    return null;
                else
                    type = type.Substring(1, type.Length - 2);

                if (optionIndex != -1)
                {
                    string valueNameName = type.Substring(0, optionIndex - 1);

                    if (!ParseReference(valueNameName, out Reference reference))
                        return null;

                    string[] spl1 = type.Substring(optionIndex).Split('?');

                    if (spl1.Length != 2)
                        return null;

                    string optionalName = spl1[0];

                    if (optionalName.Length == 0)
                        return null;
                    
                    if(optionalName.Length > 1 && optionalName.StartsWith("!"))
                    {
                        string optionValue = optionalName;
                        optionalName = GenerateGenericName();
                        manager.Profile.Add(new Option(optionalName, new string[] { optionValue }));
                    }

                    string[] spl2 = spl1[1].Split(':');

                    if (spl2.Length != 2 ||
                        !manager.Profile.Types.TryGetValue(spl2[0], out DataType foundA) ||
                        !manager.Profile.Types.TryGetValue(spl2[1], out DataType foundB))
                        return null;

                    if (VerifyName(name))
                        return new TypeInstance(new Optional(reference, optionalName, foundA, foundB), name);
                    return null;
                }
                else if (repeatIndex != -1)
                {
                    string repeatName = type.Substring(0, repeatIndex - 1);

                    if (!ParseReference(repeatName, out Reference reference))
                        return null;

                    string repeatType = type.Substring(repeatIndex);

                    if (!manager.Profile.Types.TryGetValue(repeatType, out DataType foundRepeatType))
                        return null;

                    if (VerifyName(name))
                        return new TypeInstance(new ListType(name, reference, foundRepeatType), name + "_List");

                    return null;
                }
            }

            if (!manager.Profile.Types.TryGetValue(type, out DataType found))
                return null;

            bool referencable = false;

            if (name.StartsWith("@"))
            {
                name = name.Substring(1);
                referencable = true;
            }

            if (VerifyName(name))
                return found.Instance(name, referencable);

            return null;
        }

        internal string GenerateGenericName()
        {
            return "I" + ("" + ++genericNameCounter).PadLeft(8);
        }

        private bool ParseReference(string str, out Reference reference)
        {
            reference = null;

            if (str == null || str.Length == 0)
                return false;

            if(str.StartsWith("!"))
            {
                if (str.Length == 1)
                    return false;

                reference = new Reference(str.Substring(1), true);
            }
            else
            {
                if (!VerifyName(str))
                    return false;

                reference = new Reference(str);
            }

            return true;
        }

        private bool VerifyName(string name)
        {
            return name.Length > 0 && !char.IsDigit(name[0]) && System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$");
        }
    }
}
