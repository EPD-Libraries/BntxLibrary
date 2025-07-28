namespace BntxLibrary.Common.Gfx;

[Flags]
public enum TextureInfoFlags : byte
{
    None = 0,
    IsPackedTexture = 1,
    IsSparseBinding = 2,
    IsSparse = 4,
    IsResTexture = 8,
}

/// <summary>
/// nn::gfx::TextureInfo
/// </summary>
[Swappable]
public partial struct TextureInfo
{
    public TextureInfoFlags Flags;
    public ImageStorageDimension StorageDimension;
    public TileMode TileMode;
    public ushort Swizzle;
    public ushort MipLevels;
    public ushort SampleCount;
    private ushort _reserved;
    public ImageFormat ImageFormat;
    public GpuAccessFlags GpuAccessFlags;
    public int Width;
    public int Height;
    public int Depth;
    public int ArrayLayers;
    public uint PackagedTextureLayout;
}