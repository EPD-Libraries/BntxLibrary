using BntxLibrary.Sections;
using BntxLibrary.Structures;
using BntxLibrary.Structures.Common;
using BntxLibrary.Structures.Graphics;
using BntxLibrary.Writers.WriterContextModels;
using Revrs;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace BntxLibrary.Writers;

public sealed class BntxWriter : RevrsWriter, IDisposable
{
    private enum PointerHint
    {
        TextureContainer_TextureInfoPointerArrayPointer,
        TextureContainer_TextureDataPointer,
        TextureContainer_DictionaryPointer,
        TextureContainer_MemoryPoolPointer,
        TextureContainer_UserMemoryPoolPointer,

        ResTextureInfo_TextureNamePointer,
        ResTextureInfo_ParentContainerPointer,
        ResTextureInfo_MipPointerArrayPointer,
        ResTextureInfo_UserDataPointer,
        ResTextureInfo_TexturePointer,
        ResTextureInfo_TextureViewPointer,
        ResTextureInfo_UserDataDictionaryPointer,
    }

    private const int MEMORY_POOL_SIZE = 0x140;

    private readonly Bntx _bntx;
    private readonly BntxWriterContext _context;

    public BntxWriter(in Bntx bntx, in Stream stream, Endianness endianness) : base(stream, endianness)
    {
        _bntx = bntx;
        _context = new(this, bntx);

        Seek(Unsafe.SizeOf<BntxHeader>());
    }

    public void ReserveMemoryPool(int size = MEMORY_POOL_SIZE)
    {
        Seek(size);
    }

    public void ReserveTextureInfoPointerArray()
    {
        // TODO: INJECT PTR -> Header.TextureContainer.TextureInfoPointerArrayPointer
        _context.Header.TextureContainer.TextureInfoPointerArrayPointer
            = RegisterPointer(PointerHint.TextureContainer_TextureInfoPointerArrayPointer);

        Seek(_bntx.Count * sizeof(long));
    }

    public void WriteStringTable()
    {
        long ptr = BinaryBlockHeader.Write(_context,
            BntxStringTableSection.MAGIC,
            BntxStringTableSection.Write
        );
    }

    public void WriteTextureDictionary()
    {

    }

    public void SkipTextureInfoArray()
    {
        foreach (var texture in _context.Bntx.Values) {
            Seek(Unsafe.SizeOf<ResTextureInfo>());
            Seek(0x200); // In-Place Texture and TextureView region
            Seek(texture.MipMapCount * sizeof(long));
        }
    }

    public void WriteTextureData()
    {

    }

    public void Dispose()
    {
        _context.Header.BinaryFileHeader.FileSize = Convert.ToInt32(Position);

        Seek(0);
        Write(_context.Header);
    }

    private long RegisterPointer(PointerHint hint)
    {
        return Position;
    }
}
