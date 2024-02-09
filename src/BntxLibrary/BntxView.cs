using BntxLibrary.Common;
using BntxLibrary.Extensions;
using BntxLibrary.Sections;
using BntxLibrary.Sections.Common;
using BntxLibrary.Structures;
using BntxLibrary.Structures.Graphics;
using Revrs;
using Revrs.Extensions;
using System.Runtime.CompilerServices;

namespace BntxLibrary;

public ref struct BntxView
{
    public const int MEMORY_POOL_SIZE = 0x140;

    public readonly Span<byte> Data;
    public BntxHeader Header;
    public ResDicView TexturesDictionary;
    public Span<ulong> TexturePointers;
    public Span<byte> Name;

    public BntxView(ref RevrsReader reader)
    {
        Data = reader.Data;

        ref BntxHeader header = ref reader.Read<BntxHeader, BntxHeader.Reverser>();
        if (header.BinaryFileHeader.BoM != reader.Endianness) {
            reader.Endianness = header.BinaryFileHeader.BoM;
            reader.Reverse<BntxHeader, BntxHeader.Reverser>(0);
        }

        if (header.BinaryFileHeader.Magic != BntxHeader.MAGIC) {
            throw new InvalidDataException("Invalid magic!");
        }

        reader.Move(MEMORY_POOL_SIZE);
        TexturePointers = reader.ReadSpan<ulong>(header.TextureContainer.TextureCount);

        if (reader.Endianness.IsNotSystemEndianness()) {
            StringTableSection.Reverse(ref reader);

            // This block is after the dictionary, but
            // to avoid a second condition I do it now
            reader.Seek((int)header.TextureContainer.TextureInfoArrayPointer);
            for (int i = 0; i < header.TextureContainer.TextureCount; i++) {
                BntxTextureSection.Reverse(ref reader);
            }
        }

        reader.Seek((int)header.TextureContainer.DictionaryPointer);
        TexturesDictionary = new(ref reader);

        Name = reader.Data[
            (header.BinaryFileHeader.NameOffset - sizeof(short))..
        ].ReadPascalSting();

        Header = header;
        Header.BinaryFileHeader.BoM = reader.Endianness;
    }

    public readonly ResTextureInfo this[ReadOnlySpan<byte> key] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            int offset = (int)TexturePointers[TexturesDictionary[key]];
            return Data[offset..].Read<ResTextureInfo>();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Span<byte> GetUtf8FromPtr<T>(T ptr) where T : unmanaged, IConvertible
    {
        int offset = ptr.ToInt32(null);
        return Data[offset..].ReadPascalSting();
    }

    public readonly string GetStringFromPtr<T>(T ptr) where T : unmanaged, IConvertible
    {
        return GetUtf8FromPtr(ptr).ToManaged();
    }
}
