using System.Runtime.CompilerServices;
using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::ResTextureInfo
/// </summary>
public struct ResTextureInfo
{
    public const uint Magic = 0x49545242;
    
    public BinaryBlockHeader Header;
    public TextureInfo Info;
    public unsafe fixed byte PackagedTextureLayout[4];
    private unsafe fixed byte _reserved1[0x14];
    public uint TextureSize;
    public int TextureDataAlignment;
    private unsafe fixed byte _channelSources[4];
    public ImageDimension ImageDimension;
    public unsafe fixed byte _reserved2[3];
    public BinaryPointer<BinaryString<byte>> TextureName;
    private BinaryPointer<byte> _parent;
    public BinaryPointer<BinaryPointer<byte>> MipMaps;
    public BinaryPointer<GfxUserData> UserData;
    public BinaryPointer<byte> TextureRegion;
    public BinaryPointer<byte> TextureViewRegion;
    public DescriptorSlot RuntimeDescriptorSlot;
    public BinaryPointer<ResDic> UserDataNames;

    public unsafe ChannelSource* ChannelSources {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            fixed (byte* ptr = _channelSources) {
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
}