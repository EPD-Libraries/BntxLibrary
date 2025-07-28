using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using BntxLibrary.Common.Util;

namespace BntxLibrary;

public sealed unsafe class TextureFile
{
    public static readonly BinaryFileVersion V040 = new(0, 0, 4, 0);
    public static readonly BinaryFileVersion V140 = new(0, 1, 4, 0);
    
    public string? Name { get; set; }

    public BinaryFileVersion Version { get; set; } = V140;
    
    public int Alignment { get; set; } = 8;

    [StringLength(4)]
    public string TargetPlatform { get; set; } = "NX  ";

    public OrderedDictionary<string, Texture> Textures { get; set; }

    public TextureFile()
    {
        Textures = [];
    }
    
    public TextureFile(Span<byte> buffer)
    {
        ResTextureFile* bntx = GetResPtr(buffer);
        
        if (bntx->Header.Magic != ResTextureFile.Magic) {
            throw new InvalidDataException(
                $"Invalid TextureFile magic. Expected 'BNTX....' but found '0x{bntx->Header.Magic:x}'");
        }

        if (bntx->Header.IsEndianReverse()) {
            ResEndian endian = ResEndian.FromRef(ref buffer[0]);
            ResTextureFile.Swap(bntx, &endian);
        }
        
        Name = bntx->Header.GetFileName().ToString();
        Alignment = 1 << bntx->Header.Alignment;
        TargetPlatform = Encoding.UTF8.GetString(bntx->Container.TargetPlatform, 4);
        
        // Rewrite offsets as pointers
        // relative to the input buffer
        bntx->Relocate();

        int textureCount = (int)bntx->Container.TextureCount;
        Textures = new OrderedDictionary<string, Texture>(textureCount);
        
        ResDicEntry* textureNames = bntx->Container.TextureNames.GetPtr()->GetEntries();
        ++textureNames;
        
        for (int i = 0; i < textureCount; i++) {
            if (textureNames[i].GetKey().ToString() is not string key) {
                throw new InvalidDataException($"Texture name at {i} was unexpectedly null.");
            }
            
            Textures.Add(key, Texture.FromRes((ulong)bntx, &bntx->Container.Textures.GetPtr()[i]));
        }
    }
    
    public static ref ResTextureFile GetRes(Span<byte> buffer)
        => ref Unsafe.As<byte, ResTextureFile>(ref buffer[0]);

    public static unsafe ResTextureFile* GetResPtr(Span<byte> buffer)
        => (ResTextureFile*)Unsafe.AsPointer(ref GetRes(buffer));
}