using System.Runtime.CompilerServices;
using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::ResTextureInfo
/// </summary>
[Swappable]
public partial struct ResTextureInfo
{
    public const uint Magic = 0x49545242;

    public BinaryBlockHeader Header;
    public TextureInfo Info;
    public uint TextureDataSize;
    public int Alignment;
    private unsafe fixed byte _channelMapping[4];
    public ImageDimension ImageDimension;
    private unsafe fixed byte _reserved[3];
    public BinaryPointer<BinaryString<byte>> TextureName;
    private BinaryPointer<byte> _parent;
    public BinaryPointer<BinaryPointer<byte>> MipMaps;
    public BinaryPointer<GfxUserData> UserData;
    public BinaryPointer<byte> TextureRegion;
    public BinaryPointer<byte> TextureViewRegion;
    public DescriptorSlot UserDescriptorSlot;
    public BinaryPointer<ResDic> UserDataNames;

    public unsafe ChannelSource* ChannelMapping {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            fixed (byte* ptr = _channelMapping) {
                return (ChannelSource*)ptr;
            }
        }
    }

    public unsafe BinaryPointer<ResTextureContainer>* Parent {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            fixed (BinaryPointer<byte>* ptr = &_parent) {
                return (BinaryPointer<ResTextureContainer>*)ptr;
            }
        }
    }

    public static unsafe void SwapData(ResTextureInfo* value, ResEndian* endian)
    {
        GfxUserData* userData = value->UserData.ToPtr(endian->Base);
        
        if (endian->IsSerializing) {
            GfxUserData.SwapData(userData, endian);
            GfxUserData.Swap(userData);
        }
        else {
            GfxUserData.Swap(userData);
            GfxUserData.SwapData(userData, endian);
        }
        
        ResDic.Swap(value->UserDataNames.ToPtr(endian->Base));
    }
}