﻿using BntxLibrary.Extensions;
using BntxLibrary.Structures.Common;
using BntxLibrary.Structures.Graphics;
using Revrs;

namespace BntxLibrary;

public class Bntx : Dictionary<string, BntxTexture>
{
    public string Name { get; set; } = string.Empty;
    public BinaryFileVersion Version { get; set; } = new() {
        Major = 4,
        Minor = 1,
        Micro = 0,
    };

    public Endianness Endianness { get; set; }
    public int Alignment { get; set; } = 0x1000;
    public int TargetAddressSize { get; set; } = 64;
    public TargetPlatform TargetPlatform { get; set; } = TargetPlatform.NX;

    // TODO: UserData?

    public static Bntx FromBinary(Span<byte> data)
    {
        RevrsReader reader = new(data);
        BntxView view = new(ref reader);
        return FromBntxView(view);
    }

    public static Bntx FromBntxView(in BntxView bntxView)
    {
        Bntx result = new() {
            Name = bntxView.Name.ToManaged(),
            Version = bntxView.Header.BinaryFileHeader.Version,
            Endianness = bntxView.Header.BinaryFileHeader.BoM,
            Alignment = 1 << bntxView.Header.BinaryFileHeader.PackedAlignment,
            TargetAddressSize = bntxView.Header.BinaryFileHeader.TargetAddressSize,
            TargetPlatform = bntxView.Header.TextureContainer.TargetPlatform
        };

        foreach ((var name, var tex) in bntxView) {
            result.Add(name.ToManaged(), BntxTexture.FromTextureView(tex));
        }

        return result;
    }
}