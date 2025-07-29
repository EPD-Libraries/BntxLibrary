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
public unsafe partial struct TextureInfo
{
    public TextureInfoFlags Flags;
    public ImageStorageDimension ImageStorageDimension;
    public TileMode TileMode;
    public ushort Swizzle;
    public ushort MipLevels;
    public ushort SampleCount;
    private fixed byte _reserved2[2];
    public ImageFormat ImageFormat;
    public GpuAccessFlags GpuAccessFlags;
    public int Width;
    public int Height;
    public int Depth;
    public int ArrayLength;
    public fixed byte TextureLayout[8];
    private fixed byte _reserved[20];
}