namespace BntxLibrary.Structures.Graphics;

[Flags]
public enum ChannelSource : byte
{
    Zero = 1,
    One = 2,
    Red = 4,
    Green = 8,
    Blue = 16,
    Alpha = 32
}

public struct ChannelSourceInfo
{
    public ChannelSource R;
    public ChannelSource G;
    public ChannelSource B;
    public ChannelSource A;
}
