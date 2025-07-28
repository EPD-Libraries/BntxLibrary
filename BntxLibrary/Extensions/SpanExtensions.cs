using System.Runtime.InteropServices;
using System.Text;
using BntxLibrary.Common.Util;

namespace BntxLibrary.Extensions;

public static class SpanExtensions
{
    public static List<T> ToList<T>(this Span<T> span)
    {
        List<T> result = new(span.Length);
        Span<T> listSpan = CollectionsMarshal.AsSpan(result);
        span.CopyTo(listSpan);
        return result;
    }
    
    public static unsafe List<string> ToStringList<T>(this Span<BinaryPointer<BinaryString<T>>> span) where T : unmanaged
    {
        List<string> result = new(span.Length);
        Span<string> listSpan = CollectionsMarshal.AsSpan(result);

        foreach (BinaryPointer<BinaryString<T>> item in span) {
            BinaryString<T>* bin = item.GetPtr();
            listSpan[0] = sizeof(T) switch {
                1 => Encoding.UTF8.GetString((byte*)&bin->Chars, bin->Length),
                2 => Encoding.Unicode.GetString((byte*)&bin->Chars, bin->Length * 2),
                _ => throw new InvalidOperationException(
                    $"Invalid BinaryString type: {typeof(T)}. Expected {typeof(byte)} (UTF8) or {typeof(char)} (Unicode).")
            };
        }

        return result;
    }
}