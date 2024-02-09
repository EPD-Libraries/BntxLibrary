using Revrs;

namespace BntxLibrary.Sections;

public struct BntxStringTableSection
{
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
}
