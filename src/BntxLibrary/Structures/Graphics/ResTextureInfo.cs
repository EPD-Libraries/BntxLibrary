using BntxLibrary.Common;
using BntxLibrary.Structures.Common;
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
    public uint Size;

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
    public ulong MipArrayPointer;

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
}
