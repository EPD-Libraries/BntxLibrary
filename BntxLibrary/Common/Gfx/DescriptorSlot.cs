using System.Runtime.InteropServices;

namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::DescriptorSlot<br/>
/// Runtime descriptor slot for the registered Texture + TextureView
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct DescriptorSlot;