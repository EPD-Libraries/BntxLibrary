using System.Runtime.CompilerServices;

namespace BntxLibrary.Common.Util;

[Flags]
public enum RelocationFlags : ushort
{
    IsRelocated = 1 << 0
}

[Swappable]
public partial struct BinaryFileHeader
{
    [NeverSwap]
    public ulong Magic;

    [NeverSwap]
    public BinaryFileVersion Version;

    public Endianness ByteOrder;
    public byte Alignment;
    public byte AddressSize;
    public int FileNameOffset;
    public RelocationFlags RelocationFlags;
    public ushort FirstBlockOffset;
    public int RelocationTableOffset;
    public int FileSize;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsEndianReverse() => ByteOrder == Endianness.Little;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsRelocated() => RelocationFlags.HasFlag(RelocationFlags.IsRelocated);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetRelocated() => RelocationFlags |= RelocationFlags.IsRelocated;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetUnRelocated() => RelocationFlags &= ~RelocationFlags.IsRelocated;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe StringView GetFileName()
    {
        fixed (void* ptr = &this) {
            return new StringView(in MemUtils.GetRelativeTo<byte>(ptr, FileNameOffset));
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe ref RelocationTable GetRelocationTable()
    {
        if (RelocationTableOffset == 0) {
            return ref Unsafe.NullRef<RelocationTable>();
        }

        fixed (BinaryFileHeader* ptr = &this) {
            return ref MemUtils.GetRelativeTo<RelocationTable>(ptr, RelocationTableOffset);
        }
    }

    public unsafe BinaryBlockHeader* GetFirstBlock()
    {
        if (FirstBlockOffset == 0) {
            return null;
        }
        
        fixed (BinaryFileHeader* ptr = &this) {
            return (BinaryBlockHeader*)((byte*)ptr + FirstBlockOffset);
        }
    }

    public unsafe T* FindFirstBlock<T>(uint magic) where T : unmanaged
    {
        if (FirstBlockOffset == 0) {
            return null;
        }

        BinaryBlockHeader* block = GetFirstBlock();
        if (block is not null && block->Magic == magic) {
            return (T*)block;
        }

        return (T*)block->FindNextBlock(magic);
    }
}