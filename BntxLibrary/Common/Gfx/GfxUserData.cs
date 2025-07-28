using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

[StructLayout(LayoutKind.Sequential, Size = 0x40)]
[Swappable]
public partial struct GfxUserData
{
    public BinaryPointer<BinaryString<byte>> Name;
    public BinaryPointer<byte> Value;
    public int Count;
    public GfxUserDataType Type;
    private unsafe fixed byte _reserved[0x2B];

    public unsafe bool IsEmpty {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Value.GetPtr() == null;
    }

    public unsafe Span<byte> ByteArray {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Value.GetPtr(), Count);
    }

    public unsafe Span<int> IntArray {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Value.GetPtr(), Count);
    }

    public unsafe Span<float> FloatArray {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Value.GetPtr(), Count);
    }

    public unsafe Span<BinaryPointer<BinaryString<byte>>> StringArray {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Value.GetPtr(), Count);
    }

    public unsafe Span<BinaryPointer<BinaryString<char>>> WideStringArray {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Value.GetPtr(), Count);
    }

    public static unsafe void SwapData(GfxUserData* value, ResEndian* endian)
    {
        if (value->Type is GfxUserDataType.Int or GfxUserDataType.Float) {
            uint* ptr = (uint*)value->Value.ToPtr(endian->Base);
            for (int i = 0; i < value->Count; i++, ptr++) {
                EndianUtils.Swap(ptr);
            }
        }
    }
}