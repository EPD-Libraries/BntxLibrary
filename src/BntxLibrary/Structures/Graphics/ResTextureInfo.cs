using BntxLibrary.Common;
using BntxLibrary.Structures.Common;
using Revrs;
using System.Runtime.InteropServices;

namespace BntxLibrary.Structures.Graphics;

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x100)]
public struct ResTextureInfo
{
    public const uint MAGIC = 0x42525449;

    [FieldOffset(0)]
    public BinaryBlockHeader BlockHeader;

    [FieldOffset(0x10)]
    public TextureInfo TextureInfo;

    [FieldOffset(0x38)]
    public uint PackedTextureLayout;

    [FieldOffset(0x50)]
    public int Size;

    [FieldOffset(0x54)]
    public uint Alignment;

    [FieldOffset(0x58)]
    public ChannelSourceInfo ChannelSourceInfo;

    [FieldOffset(0x5C)]
    public ImageDimension TextureDimension;

    [FieldOffset(0x60)]
    public ulong TextureNamePointer;

    [FieldOffset(0x68)]
    public ulong ParentContainerPointer;

    [FieldOffset(0x70)]
    public ulong MipPointerArrayPointer;

    [FieldOffset(0x78)]
    public ulong UserDataPointer;

    [FieldOffset(0x80)]
    public ulong TexturePointer;

    [FieldOffset(0x88)]
    public ulong TextureViewPointer;

    [FieldOffset(0x90)]
    public ulong RuntimeDescriptorSlot;

    [FieldOffset(0x98)]
    public ulong UserDataDictionaryPointer;

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            BinaryBlockHeader.Reverser.Reverse(slice[0x00..0x10]);
            TextureInfo.Reverser.Reverse(slice[0x10..0x38]);
            slice[0x38..0x3C].Reverse();
            slice[0x50..0x54].Reverse();
            slice[0x54..0x58].Reverse();
            slice[0x58..0x5C].Reverse();
            slice[0x5C..0x60].Reverse();
            slice[0x60..0x68].Reverse();
            slice[0x68..0x70].Reverse();
            slice[0x70..0x78].Reverse();
            slice[0x78..0x80].Reverse();
            slice[0x80..0x88].Reverse();
            slice[0x88..0x90].Reverse();
            slice[0x90..0x98].Reverse();
            slice[0x98..0xA0].Reverse();
        }
    }
}
