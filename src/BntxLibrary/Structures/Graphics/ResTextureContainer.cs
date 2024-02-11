using Revrs;
using System.Runtime.CompilerServices;

namespace BntxLibrary.Structures.Graphics;

public enum TargetPlatform : uint
{
    NX = 0x2020584E,
    PC = 0x206E6547,
}

public struct ResTextureContainer
{
    public TargetPlatform TargetPlatform;
    public int TextureCount;
    public long TextureInfoPointerArrayPointer;
    public long TextureDataPointer;
    public long DictionaryPointer;
    public long MemoryPoolPointer;
    public long UserMemoryPoolPointer;
    public int BaseMemoryPoolOffset;
    public uint Reserved;

    public class Reverser : IStructReverser
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x00..0x04].Reverse();
            slice[0x04..0x08].Reverse();
            slice[0x08..0x10].Reverse();
            slice[0x10..0x18].Reverse();
            slice[0x18..0x20].Reverse();
            slice[0x20..0x28].Reverse();
            slice[0x28..0x30].Reverse();
            slice[0x30..0x34].Reverse();
            slice[0x34..0x38].Reverse();
        }
    }
}
