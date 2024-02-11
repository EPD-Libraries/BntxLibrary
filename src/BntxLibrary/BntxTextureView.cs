using BntxLibrary.Extensions;
using BntxLibrary.Structures.Graphics;
using Revrs;
using Revrs.Extensions;

namespace BntxLibrary;

public ref struct BntxTextureView
{
    public readonly Span<byte> Data;
    public ResTextureInfo Info;
    public Span<long> MipMapPointers;

    public BntxTextureView(Span<byte> data, int offset)
    {
        Data = data;
        Info = Data[offset..].Read<ResTextureInfo>();
        MipMapPointers = Data[Convert.ToInt32(Info.MipPointerArrayPointer)..].ReadSpan<long>(Info.TextureInfo.MipCount);
    }

    public static void Reverse(ref RevrsReader reader)
    {
        ref ResTextureInfo info = ref reader.Read<ResTextureInfo>();
        reader.Seek(info.MipPointerArrayPointer);
        reader.ReverseSpan<ulong>(info.TextureInfo.MipCount);
    }

    public readonly Span<byte> this[int index] {
        get {
            int dataStartOffset = Convert.ToInt32(MipMapPointers[index]);
            int dataEndOffset = ++index >= MipMapPointers.Length
                ? Convert.ToInt32(MipMapPointers[0]) + Info.Size : Convert.ToInt32(MipMapPointers[index]);
            return Data[dataStartOffset..dataEndOffset];
        }
    }

    public readonly void Deconstruct(out Span<byte> name, out BntxTextureView bntxTexture)
    {
        name = Data[Convert.ToInt32(Info.TextureNamePointer)..].ReadPascalSting();
        bntxTexture = this;
    }
}
