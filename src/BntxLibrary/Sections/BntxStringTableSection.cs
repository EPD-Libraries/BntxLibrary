using BntxLibrary.Writers.WriterContextModels;
using Revrs;

namespace BntxLibrary.Sections;

public struct BntxStringTableSection
{
    public const uint MAGIC = 0x5254535F;

    public static void Reverse(ref RevrsReader reader)
    {
        reader.Move(0x10);
        int count = reader.Read<int>();
        reader.Move(0x4);

        for (int i = 0; i < count; i++)
        {
            short size = reader.Read<short>();
            reader.Move(size);
            reader.Align(0x2);
        }
    }

    public static void Write(BntxWriterContext context)
    {
        // TODO: Check if the order matters
        context.Writer.Write(context.Bntx.Count + 1);
        context.StringPointers[""] = context.Writer.Position;
        context.Writer.Write(0u); // Empty string

        foreach (var key in context.Bntx.Keys) {
            context.StringPointers[key] = context.Writer.Position;
            context.Writer.Write((ushort)key.Length);
            context.Writer.WriteStringUtf8(key);
            context.Writer.Write<byte>(0x0);
            context.Writer.Align(2);
        }

        // TODO: UserData Strings
    }
}
