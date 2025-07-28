using BntxLibrary.Common.Util;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::ResTextureContainer
/// </summary>
public struct ResTextureContainer
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
    
    public static unsafe void Swap(ResTextureContainer* value, ResEndian* endian)
    {
    }
}