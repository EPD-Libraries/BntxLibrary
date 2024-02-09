using BntxLibrary.Structures.Common;
using BntxLibrary.Structures.Graphics;
using Revrs;
using System.Runtime.CompilerServices;

namespace BntxLibrary.Structures;

public struct BntxHeader
{
    public const ulong MAGIC = 0x58544E42;

    public BinaryFileHeader BinaryFileHeader;
    public ResTextureContainer TextureContainer;

    public class Reverser : IStructReverser
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reverse(in Span<byte> slice)
        {
            BinaryFileHeader.Reverser.Reverse(slice[0x00..0x20]);
            ResTextureContainer.Reverser.Reverse(slice[0x20..0x58]);
        }
    }
}
