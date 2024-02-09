using BntxLibrary.Structures.Common;
using Revrs;
using System.Runtime.CompilerServices;

namespace BntxLibrary.Sections.Common;

public ref struct ImmutableResDic
{
    public ResDicHeader Header;
    public Span<ResDicEntry> Entries;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableResDic(ref RevrsReader reader)
    {
        Header = reader.Read<ResDicHeader, ResDicHeader.Reverser>();
        Entries = reader.ReadSpan<ResDicEntry, ResDicEntry.Reverser>(Header.Count + 1);
    }

    public readonly int this[ReadOnlySpan<byte> key]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => LookupIndex(key);
    }

    public readonly int LookupIndex(ReadOnlySpan<byte> key)
    {
        int index = 0;
        ResDicEntry prev = Entries[0];
        ResDicEntry entry = Entries[prev.LeftIndex];

        while (prev.BitIndex < entry.BitIndex)
        {
            int bitIndex = entry.BitIndex;
            int bit = 0;
            if (key.Length > bitIndex >> 3)
            {
                bit = key[key.Length + -((bitIndex >> 3) + 1)] >> (bitIndex & 7) & 1;
            }

            prev = entry;
            entry = Entries[index = bit == 0 ? prev.LeftIndex : prev.RightIndex];
        }

        return index - 1;
    }
}
