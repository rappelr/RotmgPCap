using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Packets.DataTypes.Primitive;
using System.Collections.Generic;

namespace RotmgPCap.Packets
{
    internal class PacketManager
    {
        internal Dictionary<byte, PacketProto> PacketProtoDict;

        internal PacketReaderProfile Profile;

        internal PacketManager()
        {
            PacketProtoDict = new Dictionary<byte, PacketProto>();
        }

        internal PacketProto GetOrCreate(byte id)
        {
            if (!PacketProtoDict.TryGetValue(id, out PacketProto proto))
            {
                proto = new PacketProto("Unknown_" + id, id, new TypeInstance[] {
                        new PacketHeader().Instance(),
                        new TypeInstance(new AVoid(), "Auto generated")
                    });

                PacketProtoDict.Add(id, proto);
            }

            return proto;
        }

        internal TypeInstance[] Read(Packet packet)
        {
            PacketReader reader = PacketReader.Create(Profile, packet);

            foreach (TypeInstance type in packet.Proto.Types)
                if (!reader.Read(type))
                    break;

            return packet.Proto.Types;
        }

        internal PacketProto ByName(string name)
        {
            foreach (PacketProto proto in PacketProtoDict.Values)
                if (proto.Name == name)
                    return proto;
            return null;
        }

        internal string LoadProto()
        {
            PacketProtoDict = new Dictionary<byte, PacketProto>();

            return new ProtoFileParser(this).Parse();
        }
    }
}
