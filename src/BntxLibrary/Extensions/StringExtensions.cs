using Revrs.Extensions;
using System.Runtime.CompilerServices;
using System.Text;

namespace BntxLibrary.Extensions;

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<byte> ReadPascalSting(this Span<byte> data)
    {
        ref ushort length = ref data.Read<ushort>();
        return data[sizeof(ushort)..(sizeof(ushort) + length)];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToManaged(this Span<byte> data)
    {
        return Encoding.UTF8.GetString(data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToManaged(this ReadOnlySpan<byte> data)
    {
        return Encoding.UTF8.GetString(data);
    }
}
