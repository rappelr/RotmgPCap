﻿using System;
using System.IO;

namespace RotmgPCap.Packets.DataTypes.Primitive
{
    class AUInt32 : DataType
    {
        internal AUInt32() : base("UInt32", 4, true) { }

        internal override string Read(PacketReader reader, out object result)
        {
            try
            {
                result = reader.ReadUInt32();
                return null;
            }
            catch (EndOfStreamException)
            {
                result = null;
                return "End of stream reached";
            }
            catch (Exception e)
            {
                result = null;
                Console.WriteLine(e);
                return "Unknown issue";
            }
        }
    }
}
