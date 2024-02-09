using BntxLibrary.Common;
using Revrs;

namespace BntxLibrary.Structures.Graphics;

[Flags]
public enum TextureInfoFlags : byte
{
    None = 0,
    IsPackedTexture = 1,
    IsSparseBinding = 2,
    IsSparse = 4,
    IsResTexture = 8,
}

public struct TextureInfo
{
    public TextureInfoFlags Flags;
    public ImageStorageDimension StorageDimension;
    public TileMode TileMode;
    public ushort Swizzle;
    public ushort MipCount;
    public ushort SampleCount;
    public ushort Reserved;
    public ImageFormat TextureFormat;
    public GpuAccessFlags GpuAccessFlags;
    public int Width;
    public int Height;
    public int Depth;
    public int ArrayLength;
    public uint PackedTextureLayout;

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x02..0x04].Reverse();
            slice[0x04..0x06].Reverse();
            slice[0x06..0x08].Reverse();
            slice[0x08..0x0A].Reverse();
            // 0x0A..0x0C Reserved
            slice[0x0C..0x10].Reverse();
            slice[0x10..0x14].Reverse();
            slice[0x14..0x18].Reverse();
            slice[0x18..0x1C].Reverse();
            slice[0x1C..0x20].Reverse();
            slice[0x20..0x24].Reverse();
            slice[0x24..0x28].Reverse();
        }
    }
}
