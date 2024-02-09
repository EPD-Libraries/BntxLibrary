using BntxLibrary.Common;
using BntxLibrary.Structures.Graphics;

namespace BntxLibrary;

public class BntxTexture
{
    public TextureInfoFlags Flags { get; set; }
    public ImageStorageDimension StorageDimension { get; set; } = ImageStorageDimension.Type2D;
    public TileMode TileMode { get; set; }
    public int Swizzle { get; set; }
    public int MipMapCount { get; set; }
    public int SampleCount { get; set; }
    public ImageFormat Format { get; set; }
    public GpuAccessFlags AccessFlags { get; set; } = GpuAccessFlags.Texture;
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; } = 1;
    public int ArrayCount { get; set; }
    public uint PackedTextureLayoutCommon { get; set; }
    public uint PackedTextureLayout { get; set; }
    public uint Alignment { get; set; }
    public ChannelSourceInfo ChannelInfo { get; set; }
    public ImageDimension Dimension { get; set; }
    public byte[] Data { get; set; } = [];

    // TODO: User Data?

    public static BntxTexture FromTextureView(in BntxTextureView tex)
    {
        return new() {
            Flags = tex.Info.TextureInfo.Flags,
            StorageDimension = tex.Info.TextureInfo.StorageDimension,
            TileMode = tex.Info.TextureInfo.TileMode,
            Swizzle = tex.Info.TextureInfo.Swizzle,
            MipMapCount = tex.Info.TextureInfo.MipCount,
            SampleCount = tex.Info.TextureInfo.SampleCount,
            Format = tex.Info.TextureInfo.TextureFormat,
            AccessFlags = tex.Info.TextureInfo.GpuAccessFlags,
            Width = tex.Info.TextureInfo.Width,
            Height = tex.Info.TextureInfo.Height,
            Depth = tex.Info.TextureInfo.Depth,
            ArrayCount = tex.Info.TextureInfo.ArrayLength,
            PackedTextureLayoutCommon = tex.Info.TextureInfo.PackedTextureLayout,
            PackedTextureLayout = tex.Info.PackedTextureLayout,
            Alignment = tex.Info.Alignment,
            ChannelInfo = tex.Info.ChannelSourceInfo,
            Dimension = tex.Info.TextureDimension,
            Data = tex.TextureData.ToArray()
        };
    }
}
