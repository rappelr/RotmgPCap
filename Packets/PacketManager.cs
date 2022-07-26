using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Packets.DataTypes.Primitive;
using System.Collections.Generic;

namespace RotmgPCap.Packets
{
    internal class PacketManager
    {
        internal Dictionary<byte, PacketStructure> Structures;

        internal PacketReaderProfile Profile;

        internal PacketManager()
        {
            Structures = new Dictionary<byte, PacketStructure>();
        }

        internal PacketStructure GetOrCreate(byte id)
        {
            if (!Structures.TryGetValue(id, out PacketStructure structure))
            {
                structure = new PacketStructure("Unknown_" + id, id, new TypeInstance[] {
                        new PacketHeader().Instance(),
                        new TypeInstance(new AVoid(), "Auto generated")
                    });

                Structures.Add(id, structure);
            }

            return structure;
        }

        internal TypeInstance[] Read(Packet packet)
        {
            PacketReader reader = PacketReader.Create(Profile, packet);

            foreach (TypeInstance type in packet.Structure.Types)
                if (!reader.Read(type))
                    break;

            return packet.Structure.Types;
        }

        internal PacketStructure ByName(string name)
        {
            foreach (PacketStructure structure in Structures.Values)
                if (structure.Name == name)
                    return structure;
            return null;
        }

        internal string LoadStructures()
        {
            Structures = new Dictionary<byte, PacketStructure>();

            return new PacketStructureFileParser(this).ParsePacketStructureFile();
        }
    }
}
