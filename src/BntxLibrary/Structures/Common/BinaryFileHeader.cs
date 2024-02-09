using Revrs;
using System.Runtime.CompilerServices;

namespace BntxLibrary.Structures.Common;

public struct BinaryFileHeader
{
    public ulong Magic;
    public BinaryFileVersion Version;
    public Endianness BoM;
    public byte PackedAlignment;
    public byte TargetAddressSize;
    public int NameOffset;
    public ushort RelocationFlag;
    public ushort FirstBlockOffset;
    public uint RelocationTableOffset;
    public uint FileSize;

    public class Reverser : IStructReverser
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x0C..0x0E].Reverse();
            slice[0x10..0x14].Reverse();
            slice[0x14..0x16].Reverse();
            slice[0x16..0x18].Reverse();
            slice[0x18..0x1C].Reverse();
            slice[0x1C..0x20].Reverse();
        }
    }
}
