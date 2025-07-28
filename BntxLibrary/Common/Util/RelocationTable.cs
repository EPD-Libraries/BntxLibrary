using System.Runtime.CompilerServices;

namespace BntxLibrary.Common.Util;

[Swappable]
public unsafe partial struct RelocationTable
{
    public uint Magic;
    public int TableStartOffset;
    public int SectionCount;
    private uint _padding;
    public RelocationTableSection FirstSection;

    public void Relocate()
    {
        byte* tableBase = GetTableBase();
        RelocationTableSection* sections = GetSections();
        RelocationTableSectionEntry* entries = GetEntries();

        for (int sectionIndex = 0; sectionIndex < SectionCount; sectionIndex++) {
            ref RelocationTableSection section = ref sections[sectionIndex];
            
            byte* @base = (byte*)section.GetBasePtr(tableBase);
            int globalEntryIndex = section.FirstEntryIndex;
            int end = globalEntryIndex + section.EntryCount;

            for (int entryIndex = globalEntryIndex; entryIndex < end; entryIndex++) {
                RelocationTableSectionEntry entry = entries[entryIndex];
                byte stride = entry.Stride;
                int pointersOffset = entry.PointersOffset;

                ulong* pointerPtr = (ulong*)(tableBase + pointersOffset);
                for (int i1 = 0; i1 < entry.ArrayCount; i1++) {
                    for (int i2 = 0; i2 < entry.ArrayPointerCount; i2++, ++pointerPtr) {
                        int offset = (int)*pointerPtr;
                        void* ptr = offset == 0 ? (void*)0 : @base + offset;
                        Buffer.MemoryCopy(&ptr, pointerPtr, sizeof(ulong), sizeof(ulong));
                    }
                    
                    pointerPtr += stride;
                }
            }
        }
    }

    public void UnRelocate()
    {
        byte* tableBase = GetTableBase();
        RelocationTableSection* sections = GetSections();
        RelocationTableSectionEntry* entries = GetEntries();
        
        for (int sectionIndex = 0; sectionIndex < SectionCount; sectionIndex++) {
            ref RelocationTableSection section = ref sections[sectionIndex];
            
            byte* @base = (byte*)section.GetBasePtr(tableBase);
            section.ResetPointer();
            int globalEntryIndex = section.FirstEntryIndex;
            int end = globalEntryIndex + section.FirstEntryIndex;

            for (int entryIndex = globalEntryIndex; entryIndex < end; entryIndex++) {
                RelocationTableSectionEntry entry = entries[entryIndex];
                byte stride = entry.Stride;
                int pointersOffset = entry.PointersOffset;
                var pointerPtr = (void**)(tableBase + pointersOffset);

                for (int i1 = 0; i1 < entry.ArrayCount; i1++) {
                    for (int i2 = 0; i2 < entry.ArrayPointerCount; i2++, ++pointerPtr) {
                        void* ptr = *pointerPtr;
                        long offset = ptr == null ? 0 : (int)((byte*)ptr - @base);
                        Buffer.MemoryCopy(&offset, pointerPtr, sizeof(ulong), sizeof(ulong));
                    }
                    
                    pointerPtr += stride;
                }
            }
        }
    }
    
    public static int CalcSize(int sectionCount, int entryCount)
    {
        int size = 0x4 * 0x4; // RelocationTable header fields
        size += sizeof(RelocationTableSection) * sectionCount;
        size += sizeof(RelocationTableSectionEntry) * entryCount;
        return size;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private RelocationTableSection* GetSections()
    {
        fixed (RelocationTableSection* ptr = &FirstSection) {
            return ptr;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private RelocationTableSectionEntry* GetEntries()
    {
        return (RelocationTableSectionEntry*)(
            GetSections() + SectionCount
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private byte* GetTableBase()
    {
        fixed (RelocationTable* ptr = &this) {
            return (byte*)ptr - TableStartOffset;
        }
    }
    
}

[Swappable]
public unsafe partial struct RelocationTableSection
{
    public ulong Pointer;
    public uint Offset;
    public int Size;
    public int FirstEntryIndex;
    public int EntryCount;

    public void ResetPointer() => Pointer = 0;

    public void* GetPtr()
    {
        return (void*)Pointer;
    }

    public void* GetPtrInFile(void* @base)
    {
        return (void*)((ulong)@base + Offset);
    }

    public void* GetBasePtr(void* @base)
    {
        if (Pointer > 0) {
            return (void*)(Pointer - (ulong)@base);
        }

        return @base;
    }

}

[Swappable]
public partial struct RelocationTableSectionEntry
{
    /// <summary>
    /// Offset to pointers to relocate
    /// </summary>
    public int PointersOffset;

    /// <summary>
    /// The number of arrays
    /// </summary>
    public ushort ArrayCount;

    /// <summary>
    /// The number of pointers in each array
    /// </summary>
    public byte ArrayPointerCount;

    /// <summary>
    /// The stride between each array of pointers (in number of pointers, so (stride * sizeof(void*))
    /// </summary>
    public byte Stride;
}