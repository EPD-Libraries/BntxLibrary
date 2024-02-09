using Revrs;

namespace BntxLibrary.Structures.Common;

public struct ResDicHeader
{
    public const uint MAGIC = 0x4349445F;

    public uint Magic;
    public int Count;

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x4..0x8].Reverse();
        }
    }
}
