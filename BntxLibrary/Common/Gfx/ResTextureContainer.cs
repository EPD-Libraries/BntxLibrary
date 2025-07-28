using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::ResTextureContainer
/// </summary>
[Swappable]
public partial struct ResTextureContainer
{
    public unsafe fixed byte TargetPlatform[4];
    public uint TextureCount;
    public BinaryPointer<BinaryPointer<ResTextureInfo>> Textures;
    public BinaryPointer<byte> TextureData;
    public BinaryPointer<ResDic> TextureNames;
    public BinaryPointer<byte> MemoryPool;
    public BinaryPointer<byte> UserMemoryPool;
    public uint MemoryPoolBaseOffset;
    private uint _reservedA;
    
    public static unsafe void SwapData(ResTextureContainer* value, ResEndian* endian)
    {
        BinaryPointer<ResTextureInfo>* texturePointers = value->Textures.ToPtr(endian->Base);
        if (endian->IsSerializing) {
            for (uint i = 0; i < value->TextureCount; i++) {
                ResTextureInfo* textureInfo = texturePointers[i].ToPtr(endian->Base);
                ResTextureInfo.SwapData(textureInfo, endian);
                ResTextureInfo.Swap(textureInfo);
                BinaryPointer<ResTextureInfo>.Swap(&texturePointers[i]);
            }
        }
        else {
            for (uint i = 0; i < value->TextureCount; i++) {
                BinaryPointer<ResTextureInfo>.Swap(&texturePointers[i]);
                ResTextureInfo* textureInfo = texturePointers[i].ToPtr(endian->Base);
                ResTextureInfo.Swap(textureInfo);
                ResTextureInfo.SwapData(textureInfo, endian);
            }
        }
    }
}