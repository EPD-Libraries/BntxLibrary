using BntxLibrary;
using BntxLibrary.Extensions;
using Revrs;

byte[] data = File.ReadAllBytes(".\\Assets\\Common.bntx");
RevrsReader reader = new(data);
BntxView bntx = new(ref reader);

using StreamWriter writer = new("D:\\bin\\Bntx\\Debug.yml");

writer.WriteLine($"Name: {bntx.Name.ToManaged()}");
writer.WriteLine($"Magic: {bntx.Header.BinaryFileHeader.Magic}");
writer.WriteLine($"Version: {bntx.Header.BinaryFileHeader.Version}");
writer.WriteLine($"BoM: {bntx.Header.BinaryFileHeader.BoM}");
writer.WriteLine($"PackedAlignment: {bntx.Header.BinaryFileHeader.PackedAlignment}");
writer.WriteLine($"TargetAddressSize: {bntx.Header.BinaryFileHeader.TargetAddressSize}");
writer.WriteLine($"NameOffset: {bntx.Header.BinaryFileHeader.NameOffset}");
writer.WriteLine($"RelocationFlag: {bntx.Header.BinaryFileHeader.RelocationFlag}");
writer.WriteLine($"FirstBlockOffset: {bntx.Header.BinaryFileHeader.FirstBlockOffset}");
writer.WriteLine($"RelocationTableOffset: {bntx.Header.BinaryFileHeader.RelocationTableOffset}");
writer.WriteLine($"FileSize: {bntx.Header.BinaryFileHeader.FileSize}");
writer.WriteLine($"TargetPlatform: {bntx.Header.TextureContainer.TargetPlatform}");
writer.WriteLine($"TextureCount: {bntx.Header.TextureContainer.TextureCount}");
writer.WriteLine($"TextureInfoPointerArrayPointer: {bntx.Header.TextureContainer.TextureInfoPointerArrayPointer}");
writer.WriteLine($"TextureDataPointer: {bntx.Header.TextureContainer.TextureDataPointer}");
writer.WriteLine($"DictionaryPointer: {bntx.Header.TextureContainer.DictionaryPointer}");
writer.WriteLine($"MemoryPoolPointer: {bntx.Header.TextureContainer.MemoryPoolPointer}");
writer.WriteLine($"UserMemoryPoolPointer: {bntx.Header.TextureContainer.UserMemoryPoolPointer}");
writer.WriteLine($"BaseMemoryPoolOffset: {bntx.Header.TextureContainer.BaseMemoryPoolOffset}");
writer.WriteLine($"Textures:");

foreach ((var name, var tex) in bntx) {
    writer.WriteLine($"  {name.ToManaged()}:");
    writer.WriteLine($"    BlockHeader:");
    writer.WriteLine($"      Magic: {tex.Info.BlockHeader.Magic}");
    writer.WriteLine($"      NextBlockOffset: {tex.Info.BlockHeader.NextBlockOffset}");
    writer.WriteLine($"      BlockSize: {tex.Info.BlockHeader.BlockSize}");
    writer.WriteLine($"    TextureInfo:");
    writer.WriteLine($"      Flags: {tex.Info.TextureInfo.Flags}");
    writer.WriteLine($"      StorageDimension: {tex.Info.TextureInfo.StorageDimension}");
    writer.WriteLine($"      TileMode: {tex.Info.TextureInfo.TileMode}");
    writer.WriteLine($"      Swizzle: {tex.Info.TextureInfo.Swizzle}");
    writer.WriteLine($"      MipCount: {tex.Info.TextureInfo.MipCount}");
    writer.WriteLine($"      SampleCount: {tex.Info.TextureInfo.SampleCount}");
    writer.WriteLine($"      Reserved: {tex.Info.TextureInfo.Reserved}");
    writer.WriteLine($"      TextureFormat: {tex.Info.TextureInfo.TextureFormat}");
    writer.WriteLine($"      GpuAccessFlags: {tex.Info.TextureInfo.GpuAccessFlags}");
    writer.WriteLine($"      Width: {tex.Info.TextureInfo.Width}");
    writer.WriteLine($"      Height: {tex.Info.TextureInfo.Height}");
    writer.WriteLine($"      Depth: {tex.Info.TextureInfo.Depth}");
    writer.WriteLine($"      ArrayLength: {tex.Info.TextureInfo.ArrayLength}");
    writer.WriteLine($"      PackedTextureLayout: {tex.Info.TextureInfo.PackedTextureLayout}");
    writer.WriteLine($"    PackedTextureLayout: {tex.Info.PackedTextureLayout}");
    writer.WriteLine($"    Size: {tex.Info.Size}");
    writer.WriteLine($"    Alignment: {tex.Info.Alignment}");
    writer.WriteLine($"    ChannelSourceInfo:");
    writer.WriteLine($"      R: {tex.Info.ChannelSourceInfo.R}");
    writer.WriteLine($"      G: {tex.Info.ChannelSourceInfo.G}");
    writer.WriteLine($"      B: {tex.Info.ChannelSourceInfo.B}");
    writer.WriteLine($"      A: {tex.Info.ChannelSourceInfo.A}");
    writer.WriteLine($"    TextureDimension: {tex.Info.TextureDimension}");
    writer.WriteLine($"    ParentContainerPointer: {tex.Info.ParentContainerPointer}");
    writer.WriteLine($"    MipPointerArrayPointer: {tex.Info.MipPointerArrayPointer}");
    writer.WriteLine($"    UserDataPointer: {tex.Info.UserDataPointer}");
    writer.WriteLine($"    TexturePointer: {tex.Info.TexturePointer}");
    writer.WriteLine($"    TextureViewPointer: {tex.Info.TextureViewPointer}");
    writer.WriteLine($"    RuntimeDescriptorSlot: {tex.Info.RuntimeDescriptorSlot}");
    writer.WriteLine($"    UserDataDictionaryPointer: {tex.Info.UserDataDictionaryPointer}");
}