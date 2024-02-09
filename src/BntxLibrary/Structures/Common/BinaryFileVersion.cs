using Revrs;
using System.Xml;

namespace BntxLibrary.Structures.Common;

public struct BinaryFileVersion
{
    public byte Micro;
    public byte Minor;
    public ushort Major;

    public readonly override string ToString()
    {
        return $"{Major}.{Minor}.{Micro}";
    }

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x2..0x4].Reverse();
        }
    }
}
