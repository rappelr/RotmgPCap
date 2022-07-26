using System;
using System.Text;

namespace RotmgPCap.Capture
{
    internal class Crypto
    {
        private const string INCOMING_KEY = "c91d9eec420160730d825604e0";
        private const string OUTGOUNG_KEY = "5a4d2016bc16dc64883194ffd9";
        private const int STATE_LENGTH = 256;

        internal static Crypto Incoming, Outgoing;

        static Crypto() => Reset();

        internal static void Reset(bool? incoming = null)
        {
            if (incoming.HasValue)
            {
                if (incoming.Value)
                    Incoming = new Crypto(INCOMING_KEY);
                else
                    Outgoing = new Crypto(OUTGOUNG_KEY);
            }
            else
            {
                Incoming = new Crypto(INCOMING_KEY);
                Outgoing = new Crypto(OUTGOUNG_KEY);
            }
        }

        private byte[] engineState;
        private byte[] workingKey;

        private int x;
        private int y;

        internal static byte[] HexStringToBytes(string key)
        {
            byte[] numArray = (uint)(key.Length % 2) <= 0U ? new byte[key.Length / 2] : throw new ArgumentException("Invalid hex string");
            char[] charArray = key.ToCharArray();

            for (int index = 0; index < charArray.Length; index += 2)
            {
                int int32 = Convert.ToInt32(new StringBuilder(2).Append(charArray[index]).Append(charArray[index + 1]).ToString(), 16);
                numArray[index / 2] = (byte)int32;
            }

            return numArray;
        }

        private Crypto(string key)
        {
            workingKey = HexStringToBytes(key);
            SetKey(workingKey);
        }

        internal void Cipher(byte[] packet, int slice) => ProcessBytes(packet, slice, packet.Length - slice, packet, slice);

        private void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
        {
            for (int index = 0; index < length; ++index)
            {
                x = x + 1 & (int)byte.MaxValue;
                y = (int)engineState[x] + y & (int)byte.MaxValue;
                byte num = engineState[x];
                engineState[x] = engineState[y];
                engineState[y] = num;
                output[index + outOff] = (byte)(input[index + inOff] ^ (uint)engineState[engineState[x] + engineState[y] & byte.MaxValue]);
            }
        }

        private void SetKey(byte[] keyBytes)
        {
            workingKey = keyBytes;
            x = y = 0;
            if (engineState == null)
                engineState = new byte[STATE_LENGTH];
            for (int index = 0; index < STATE_LENGTH; ++index)
                engineState[index] = (byte)index;
            int index1 = 0;
            int index2 = 0;
            for (int index3 = 0; index3 < STATE_LENGTH; ++index3)
            {
                index2 = (keyBytes[index1] & byte.MaxValue) + engineState[index3] + index2 & byte.MaxValue;
                byte num = engineState[index3];
                engineState[index3] = engineState[index2];
                engineState[index2] = num;
                index1 = (index1 + 1) % keyBytes.Length;
            }
        }
    }
}
