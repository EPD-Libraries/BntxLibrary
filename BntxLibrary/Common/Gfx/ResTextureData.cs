using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

[Swappable]
public partial struct ResTextureData
{
    public BinaryBlockHeader Header;
    public unsafe fixed byte Data[1];
}