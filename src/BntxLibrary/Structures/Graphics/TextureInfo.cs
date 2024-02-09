using BntxLibrary.Common;

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

    // TODO: impl reverser
}
