using BntxLibrary.Common;
using BntxLibrary.Extensions;
using BntxLibrary.Sections;
using BntxLibrary.Structures;
using Revrs;
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

    public readonly int Count {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => TexturePointers.Length;
    }

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

        reader.Seek(header.TextureContainer.TextureInfoPointerArrayPointer);
        TexturePointers = reader.ReadSpan<ulong>(header.TextureContainer.TextureCount);

        if (reader.Endianness.IsNotSystemEndianness()) {
            BntxStringTableSection.Reverse(ref reader);

            // This block is after the dictionary, but
            // to avoid a second condition I do it now
            for (int i = 0; i < header.TextureContainer.TextureCount; i++) {
                reader.Seek(TexturePointers[i]);
                BntxTextureView.Reverse(ref reader);
            }
        }

        reader.Seek(header.TextureContainer.DictionaryPointer);
        TexturesDictionary = new(ref reader);

        Name = reader.Data[
            (header.BinaryFileHeader.NameOffset - sizeof(short))..
        ].ReadPascalSting();

        Header = header;
        Header.BinaryFileHeader.BoM = reader.Endianness;
    }

    public readonly BntxTextureView this[ReadOnlySpan<byte> key] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            int offset = Convert.ToInt32(TexturePointers[TexturesDictionary[key]]);
            return new(Data, offset);
        }
    }

    public readonly BntxTextureView this[int index] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            int offset = Convert.ToInt32(TexturePointers[index]);
            return new(Data, offset);
        }
    }

    public readonly Span<byte> GetUtf8FromPtr<T>(T ptr) where T : unmanaged, IConvertible
    {
        int offset = ptr.ToInt32(null);
        return Data[offset..].ReadPascalSting();
    }

    public readonly string GetStringFromPtr<T>(T ptr) where T : unmanaged, IConvertible
    {
        return GetUtf8FromPtr(ptr).ToManaged();
    }

    public readonly Enumerator GetEnumerator() => new(this);

    public ref struct Enumerator(BntxView bntx)
    {
        private readonly BntxView _bntx = bntx;
        private int _index = -1;

        public readonly BntxTextureView Current {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _bntx[_index];
        }

        public bool MoveNext()
        {
            return ++_index < _bntx.Count;
        }
    }
}
