using BntxLibrary.Extensions;
using BntxLibrary.Structures.Graphics;
using Revrs;
using Revrs.Extensions;

namespace BntxLibrary;

public ref struct BntxTextureView
{
    public readonly Span<byte> Data;
    public ResTextureInfo Info;
    public Span<ulong> MipMapPointers;
    public Span<byte> TextureData;

    public BntxTextureView(Span<byte> data, int offset)
    {
        Data = data;
        Info = Data[offset..].Read<ResTextureInfo>();
        MipMapPointers = Data[Convert.ToInt32(Info.MipPointerArrayPointer)..].ReadSpan<ulong>(Info.TextureInfo.MipCount);

        int firstMipMapOffset = Convert.ToInt32(MipMapPointers[0]);
        TextureData = Data[firstMipMapOffset..(firstMipMapOffset + Info.Size)];
    }

    public static void Reverse(ref RevrsReader reader)
    {
        ref ResTextureInfo info = ref reader.Read<ResTextureInfo>();
        reader.Seek(info.MipPointerArrayPointer);
        reader.ReverseSpan<ulong>(info.TextureInfo.MipCount);
    }

    public readonly void Deconstruct(out Span<byte> name, out BntxTextureView bntxTexture)
    {
        name = Data[Convert.ToInt32(Info.TextureNamePointer)..].ReadPascalSting();
        bntxTexture = this;
    }
}
