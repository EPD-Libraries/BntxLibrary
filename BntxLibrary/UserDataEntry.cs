using System.Collections;
using BntxLibrary.Common.Gfx;

namespace BntxLibrary;

public class UserDataEntry(string name, GfxUserDataType type)
{
    private IEnumerable? _values;
    
    public string Name { get; set; } = name;

    public GfxUserDataType Type { get; private set; } = type;

    public UserDataEntry(string name, params IList<int> values) : this(name, GfxUserDataType.Int)
    {
        _values = values;
    }
    
    public UserDataEntry(string name, params IList<float> values) : this(name, GfxUserDataType.Float)
    {
        _values = values;
    }
    
    public UserDataEntry(string name, params IList<string> values) : this(name, GfxUserDataType.String)
    {
        _values = values;
    }
    
    public UserDataEntry(string name, params IList<byte> values) : this(name, GfxUserDataType.Byte)
    {
        _values = values;
    }
    
    public UserDataEntry(string name, bool isUnicode, params IList<string> values)
        : this(name, isUnicode ? GfxUserDataType.WString : GfxUserDataType.String)
    {
        _values = values;
    }
    
    internal UserDataEntry(string name, GfxUserDataType type, IEnumerable values) : this(name, type)
    {
        _values = values;
    }

    public IList<T>? GetValues<T>() => _values as IList<T>;

    public void SetValues(params IList<int> values)
    {
        Type = GfxUserDataType.Int;
        _values = values;
    }

    public void SetValues(params IList<float> values)
    {
        Type = GfxUserDataType.Float;
        _values = values;
    }

    public void SetValues(params IList<string> values)
    {
        Type = GfxUserDataType.String;
        _values = values;
    }

    public void SetValues(params IList<byte> values)
    {
        Type = GfxUserDataType.Byte;
        _values = values;
    }
    
    public void SetValues(bool isUnicode, params IList<string> values)
    {
        Type = isUnicode ? GfxUserDataType.WString : GfxUserDataType.String;
        _values = values;
    }
}