namespace BntxLibrary.Common.Gfx;

/// <summary>
/// nn::gfx::GpuAccessFlags
/// </summary>
[Flags]
public enum GpuAccessFlags : ushort
{
    VertexBuffer = 0x4,
    IndexBuffer = 0x8,
    UniformBuffer = 0x10,
    Texture = 0x20,
    TransferDestination = 0x40,
    RenderTargetColor = 0x80,
    RenderTargetDepth = 0x100,
    IndirectDraw = 0x200,
    DisplayTexture = 0x400,
    Count = 0x800
}