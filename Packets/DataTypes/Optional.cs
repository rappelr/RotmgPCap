using System;

namespace RotmgPCap.Packets.DataTypes
{
    internal class Optional : DataType
    {
        internal readonly Reference ValueReference;
        internal readonly string TargetOption;
        internal readonly DataType A, B;

        internal Optional(Reference valueReference, string targetOption, DataType a, DataType b)
            : base("Optional", Math.Min(a.MinLength, b.MinLength), a.FixedLength && b.FixedLength && a.MinLength == b.MinLength)
        {
            ValueReference = valueReference;
            TargetOption = targetOption;
            A = a;
            B = b;
        }

        internal override string Read(PacketReader reader, out object result)
        {
            if (!reader.Read(ValueReference))
            {
                result = null;
                return ValueReference.Value;
            }

            if (!reader.Profile.Options.TryGetValue(TargetOption, out Option option))
            {
                result = null;
                return "Missing option \"" + TargetOption + "\"";
            }

            if (!reader.Read(ValueReference))
            {
                result = null;
                return ValueReference.Value;
            }

            return option.Match(ValueReference.Value) ? A.Read(reader, out result) : B.Read(reader, out result);
        }
    }
}
