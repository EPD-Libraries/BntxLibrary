using System.Runtime.CompilerServices;

namespace BntxLibrary.Common.Util;

public readonly unsafe ref struct ResEndian(byte* @base, bool isSerializing)
{
    public readonly byte* Base = @base;
    
    public readonly bool IsSerializing = isSerializing;

    public ResEndian(void* @base, bool isSerializing = false) : this((byte*)@base, isSerializing)
    {
    }

    public static ResEndian FromRef<T>(ref T @base, bool isSerializing = false)
    {
        return new ResEndian(Unsafe.AsPointer(ref @base), isSerializing);
    }
}