using System.Runtime.InteropServices;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::DescriptorSlot<br/>
/// Runtime descriptor slot for the registered Texture + TextureView
/// </summary>
[Swappable]
public partial struct DescriptorSlot
{
    public ulong Value;
}