using System.Runtime.InteropServices;
using BntxLibrary.Common.Gfx;
using BntxLibrary.Common.Util;

namespace BntxLibrary;

public sealed class Texture
{
    public TextureInfo Info { get; set; }
    
    public int Alignment { get; set; }
    
    public TextureChannels Channels { get; set; }

    public UserData? UserData { get; set; }

    public required List<TextureData> ArrayLayers { get; set; }
    
    internal static unsafe Texture FromRes(ulong basePtr, BinaryPointer<ResTextureInfo>* binaryPointer)
    {
        ResTextureInfo* resTextureInfo = binaryPointer->GetPtr();
        
        if (resTextureInfo->Header.Magic != ResTextureInfo.Magic) {
            throw new InvalidDataException(
                $"Invalid TextureInfo magic. Expected 'BRTI' but found '0x{resTextureInfo->Header.Magic:x}'");
        }
        
        int arrayLayerCount = resTextureInfo->Info.ArrayLayers;
        List<TextureData> layers = arrayLayerCount == 0 ? [] : new List<TextureData>(resTextureInfo->Info.ArrayLayers);
        
        if (arrayLayerCount == 0) {
            goto ReturnEmptyTexture;
        }
        
        BinaryPointer<byte>* mipMapLevels = resTextureInfo->MipMaps.GetPtr();
        int mipMapLayerCount = resTextureInfo->Info.MipLevels;
        
        uint textureSize = resTextureInfo->TextureSize;
        ulong mipMapDataStart = (ulong)mipMapLevels->GetPtr();
        
        for (int arrayLayerIndex = 0; arrayLayerIndex < arrayLayerCount; arrayLayerIndex++) {
            TextureData textureData = new(mipMapLayerCount);
            
            for (int mipMapLayerIndex = 0; mipMapLayerIndex < mipMapLayerCount; mipMapLayerIndex++) {
                int index = (arrayLayerIndex + 1) * mipMapLayerIndex;
                byte* ptr = mipMapLevels[index].GetPtr();
                int size = (int)(mipMapDataStart + textureSize - (ulong)ptr);
                byte[] data = new byte[size];
                
                fixed (byte* dst = data) {
                    Buffer.MemoryCopy(ptr, dst, size, size);
                }
                
                textureData.MipMapLevels.Add(data);
            }
            
            layers.Add(textureData);
        }

    ReturnEmptyTexture:
        return new Texture {
            Info = resTextureInfo->Info,
            Alignment = resTextureInfo->TextureDataAlignment,
            Channels = TextureChannels.FromFixed(resTextureInfo->ChannelSources),
            UserData = UserData.FromRes(resTextureInfo),
            ArrayLayers = layers
        };
    }
}