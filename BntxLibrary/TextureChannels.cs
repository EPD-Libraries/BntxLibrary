using BntxLibrary.Common.Gfx;

namespace BntxLibrary;

public struct TextureChannels
{
    public ChannelSource R;
    public ChannelSource G;
    public ChannelSource B;
    public ChannelSource A;

    public static unsafe TextureChannels FromFixed(ChannelSource* ptr)
    {
        return new TextureChannels {
            R = ptr[0],
            G = ptr[1],
            B = ptr[2],
            A = ptr[3],
        };
    }
}