using BntxLibrary.Structures;
using Revrs;

namespace BntxLibrary.Writers.WriterContextModels;

public class BntxWriterContext(RevrsWriter writer, Bntx bntx) : IWriterContext
{
    public Dictionary<string, long> StringPointers { get; } = [];
    public RevrsWriter Writer { get; } = writer;
    public Bntx Bntx { get; } = bntx;

    public BntxHeader Header = new() {
        BinaryFileHeader = {
            Magic = BntxHeader.MAGIC,
            Version = bntx.Version,
            BoM = writer.Endianness,
            PackedAlignment = bntx.PackedAlignment,
            TargetAddressSize = bntx.TargetAddressSize
        },
        TextureContainer = {
            TargetPlatform = bntx.TargetPlatform,
            TextureCount = bntx.Count
        }
    };
}
