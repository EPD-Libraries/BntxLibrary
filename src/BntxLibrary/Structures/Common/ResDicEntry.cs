using Revrs;

namespace BntxLibrary.Structures.Common;

public struct ResDicEntry
{
    public int BitIndex;
    public ushort LeftIndex;
    public ushort RightIndex;
    public ulong StringPointer;

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x00..0x04].Reverse();
            slice[0x04..0x06].Reverse();
            slice[0x06..0x08].Reverse();
            slice[0x08..0x10].Reverse();
        }
    }
}
