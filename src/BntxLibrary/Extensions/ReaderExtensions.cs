using Revrs;

namespace BntxLibrary.Extensions;

public static class ReaderExtensions
{
    public static void Seek<T>(this ref RevrsReader reader, T offset) where T : unmanaged, IConvertible
    {
        reader.Seek(offset.ToInt32(null));
    }
}
