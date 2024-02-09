using Revrs;

namespace BntxLibrary.Structures.Common;

public struct BinaryBlockHeader
{
    public uint Magic;
    public uint NextBlockOffset;
    public uint BlockSize;
    public uint Reserved;

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x04..0x08].Reverse();
            slice[0x08..0x0C].Reverse();
            slice[0x0C..0x10].Reverse();
        }
    }
}
