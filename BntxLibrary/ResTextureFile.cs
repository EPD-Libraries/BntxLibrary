using BntxLibrary.Common.Gfx;
using BntxLibrary.Common.Util;

namespace BntxLibrary;

public struct ResTextureFile
{
    public const ulong Magic = 0x58544E42;

    public BinaryFileHeader Header;
    public ResTextureContainer Container;

    public void Relocate()
    {
        if (Header.IsRelocated()) {
            return;
        }
        
        ref RelocationTable table = ref Header.GetRelocationTable();
        table.Relocate();
        Header.SetRelocated();
    }

    public void UnRelocate()
    {
        if (!Header.IsRelocated()) {
            return;
        }

        ref RelocationTable table = ref Header.GetRelocationTable();
        table.UnRelocate();
        Header.SetUnRelocated();
    }

    public static unsafe void Swap(ResTextureFile* value, ResEndian* endian)
    {
        BinaryFileHeader.Swap(&value->Header);

        if (endian->IsSerializing) {
            ResTextureContainer.SwapData(&value->Container, endian);
            ResTextureContainer.Swap(&value->Container);
        }
        else {
            ResTextureContainer.Swap(&value->Container);
            ResTextureContainer.SwapData(&value->Container, endian);
        }
    }
}