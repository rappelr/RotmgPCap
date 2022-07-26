using RotmgPCap.Packets.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RotmgPCap.Packets
{
    internal class PacketReader : BinaryReader
    {
        internal readonly PacketReaderProfile Profile;

        internal readonly Dictionary<string, TypeInstance> RuntimeReference;

        internal PacketReader(PacketReaderProfile profile, Stream s) : base(s)
        {
            Profile = profile;
            RuntimeReference = new Dictionary<string, TypeInstance>();
        }

        internal static PacketReader Create(PacketReaderProfile profile, Packet packet) => new PacketReader(profile, new MemoryStream(packet.Data));

        internal bool Read(TypeInstance instance)
        {
            long index = BaseStream.Position;

            string error = instance.Type.Read(this, out object result);

            instance.Result = new ReadResult((int)(BaseStream.Position - index), (int)index, result, error);

            if (instance.Referencable)
            {
                if (RuntimeReference.ContainsKey(instance.Name))
                    RuntimeReference.Remove(instance.Name);
                RuntimeReference.Add(instance.Name, instance);
            }

            return !instance.Result.Error;
        }

        internal bool Read(Reference reference)
        {
            if (reference.Constant)
                return true;

            if(!RuntimeReference.TryGetValue(reference.ReferenceTarget, out TypeInstance instance))
            {
                reference.Value = "Missing reference \"" + reference.ReferenceTarget + "\"";
                return false;
            }

            if(instance.Result.Error)
            {
                reference.Value = "Reference error \"" + reference.ReferenceTarget + "\"";
                return false;
            }

            reference.Value = instance.Result.StringValue;
            return true;
        }

        public override short ReadInt16() => IPAddress.NetworkToHostOrder(base.ReadInt16());
        public override ushort ReadUInt16() => (ushort)IPAddress.NetworkToHostOrder((short)base.ReadUInt16());
        public override int ReadInt32() => IPAddress.NetworkToHostOrder(base.ReadInt32());
        public override uint ReadUInt32() => (uint)IPAddress.NetworkToHostOrder(base.ReadUInt32());

        public override float ReadSingle()
        {
            byte[] array = ReadBytes(4);
            Array.Reverse(array);
            return BitConverter.ToSingle(array, 0);
        }
    }
}
