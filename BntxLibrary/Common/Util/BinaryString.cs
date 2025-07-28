using System.Runtime.CompilerServices;

namespace BntxLibrary.Common.Util;

public struct BinaryString<T> : ISwappable<BinaryString<T>> where T : unmanaged
{
    public ushort Length;
    public T Chars;
    
    public unsafe Span<T> Data {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            fixed (T* ptr = &Chars) {
                return new Span<T>(ptr, Length);
            }
        }
    }

    public bool IsEmpty {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Length == 0;
    }

    public ref T this[int index] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Data[index];
    }

    public unsafe BinaryString<T>* NextString()
    {
        fixed (BinaryString<T>* ptr = &this) {
            byte* offset = (byte*)ptr + (sizeof(T) * (Length + 1)).AlignUp(2);
            return (BinaryString<T>*)offset;
        }
    }

    public static unsafe void Swap(BinaryString<T>* value)
    {
        EndianUtils.Swap(&value->Length);
    }
}