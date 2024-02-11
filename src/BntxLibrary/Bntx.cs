using BntxLibrary.Extensions;
using BntxLibrary.Structures.Common;
using BntxLibrary.Structures.Graphics;
using BntxLibrary.Writers;
using Revrs;

namespace BntxLibrary;

public class Bntx : Dictionary<string, BntxTexture>
{
    public string Name { get; set; } = string.Empty;
    public BinaryFileVersion Version { get; set; } = new() {
        Major = 4,
        Minor = 1,
        Micro = 0,
    };

    public Endianness Endianness { get; set; }
    public byte PackedAlignment { get; set; } = 12;
    public byte TargetAddressSize { get; set; } = 64;
    public TargetPlatform TargetPlatform { get; set; } = TargetPlatform.NX;
    public int Alignment => 1 << PackedAlignment;

    // TODO: UserData?

    public static Bntx FromBinary(Span<byte> data)
    {
        RevrsReader reader = new(data);
        BntxView view = new(ref reader);
        return FromBntxView(view);
    }

    public static Bntx FromBntxView(in BntxView bntxView)
    {
        Bntx result = new() {
            Name = bntxView.Name.ToManaged(),
            Version = bntxView.Header.BinaryFileHeader.Version,
            Endianness = bntxView.Header.BinaryFileHeader.BoM,
            PackedAlignment = bntxView.Header.BinaryFileHeader.PackedAlignment,
            TargetAddressSize = bntxView.Header.BinaryFileHeader.TargetAddressSize,
            TargetPlatform = bntxView.Header.TextureContainer.TargetPlatform
        };

        foreach ((var name, var tex) in bntxView) {
            result.Add(name.ToManaged(), BntxTexture.FromTextureView(tex));
        }

        return result;
    }

    public byte[] ToBinary(Endianness? endianness = null)
    {
        endianness ??= Endianness;

        using MemoryStream ms = new();
        WriteBinary(ms, endianness.Value);
        return ms.ToArray();
    }

    public void WriteBinary(byte[] buffer, Endianness? endianness = null)
    {
        endianness ??= Endianness;

        using MemoryStream ms = new(buffer);
        WriteBinary(ms, endianness.Value);
    }

    public void WriteBinary(in Stream stream, Endianness? endianness = null)
    {
        endianness ??= Endianness;
        using BntxWriter writer = new(this, stream, endianness.Value);
        writer.ReserveMemoryPool(/* Use the default memory pool size of 0x140 */);
        writer.WriteTextureDictionary();
        writer.SkipTextureInfoArray();
        writer.WriteTextureData();
    }
}
