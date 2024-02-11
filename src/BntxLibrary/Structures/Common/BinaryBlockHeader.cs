using BntxLibrary.Writers.WriterContextModels;
using Revrs;

namespace BntxLibrary.Structures.Common;

public struct BinaryBlockHeader
{
    public uint Magic;
    public uint NextBlockOffset;
    public uint BlockSize;
    public uint Reserved;

    public static long Write<T>(in T context, uint magic, Action<T> write) where T : IWriterContext
    {
        long headerOffset = context.Writer.Position;
        write(context);
        context.Writer.Align(0x8);
        uint blockSize = Convert.ToUInt32(context.Writer.Position - headerOffset);

        context.Writer.Seek(headerOffset);
        context.Writer.Write(new BinaryBlockHeader {
            Magic = magic,
            NextBlockOffset = blockSize,
            BlockSize = blockSize
        });

        return headerOffset;
    }

    public class Reverser : IStructReverser
    {
        public static void Reverse(in Span<byte> slice)
        {
            slice[0x04..0x08].Reverse();
            slice[0x08..0x0C].Reverse();
            slice[0x0C..0x10].Reverse();
        }
    }
}
