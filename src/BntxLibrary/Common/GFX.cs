﻿namespace BntxLibrary.Common;

public enum ChannelFormat : int
{
    None = 0x1,
    R8 = 0x2,
    R4G4B4A4 = 0x3,
    R5G5B5A1 = 0x5,
    A1B5G5R5 = 0x6,
    R5G6B5 = 0x7,
    B5G6R5 = 0x8,
    R8G8 = 0x9,
    R16 = 0xA,
    R8G8B8A8 = 0xB,
    B8G8R8A8 = 0xC,
    R9G9B9E5F = 0xD,
    R10G10B10A2 = 0xE,
    R11G11B10F = 0xF,
    R16G16 = 0x12,
    D24S8 = 0x13,
    R32 = 0x14,
    R16G16B16A16 = 0x15,
    D32FS8 = 0x16,
    R32G32 = 0x17,
    R32G32B32 = 0x18,
    R32G32B32A32 = 0x19,
    BC1 = 0x1A,
    BC2 = 0x1B,
    BC3 = 0x1C,
    BC4 = 0x1D,
    BC5 = 0x1E,
    BC6H = 0x1F,
    BC7U = 0x20,
    ASTC_4X4 = 0x2D,
    ASTC_5X4 = 0x2E,
    ASTC_5X5 = 0x2F,
    ASTC_6X5 = 0x30,
    ASTC_6X6 = 0x31,
    ASTC_8X5 = 0x32,
    ASTC_8X6 = 0x33,
    ASTC_8X8 = 0x34,
    ASTC_10x5 = 0x35,
    ASTC_10x6 = 0x26,
    ASTC_10x8 = 0x37,
    ASTC_10x10 = 0x38,
    ASTC_12X10 = 0x39,
    ASTC_12X12 = 0x3A,
    B5G5R5A1 = 0x3B,
}

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

public enum ImageFormat : uint
{
    R8_Unorm = (ChannelFormat.R8 << 8) | TypeFormat.Unorm,
    R8_Snorm = (ChannelFormat.R8 << 8) | TypeFormat.Snorm,
    R8_UInt = (ChannelFormat.R8 << 8) | TypeFormat.UInt,
    R8_SInt = (ChannelFormat.R8 << 8) | TypeFormat.SInt,
    R8_Float = (ChannelFormat.R8 << 8) | TypeFormat.Float,
    R8_SRGB = (ChannelFormat.R8 << 8) | TypeFormat.SRGB,
    R8_Depth = (ChannelFormat.R8 << 8) | TypeFormat.Depth,
    R8_UScaled = (ChannelFormat.R8 << 8) | TypeFormat.UScaled,
    R8_SScaled = (ChannelFormat.R8 << 8) | TypeFormat.SScaled,
    R8_UFloat = (ChannelFormat.R8 << 8) | TypeFormat.UFloat,
    R4G4B4A4_Unorm = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.Unorm,
    R4G4B4A4_Snorm = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.Snorm,
    R4G4B4A4_UInt = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.UInt,
    R4G4B4A4_SInt = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.SInt,
    R4G4B4A4_Float = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.Float,
    R4G4B4A4_SRGB = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.SRGB,
    R4G4B4A4_Depth = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.Depth,
    R4G4B4A4_UScaled = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.UScaled,
    R4G4B4A4_SScaled = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.SScaled,
    R4G4B4A4_UFloat = (ChannelFormat.R4G4B4A4 << 8) | TypeFormat.UFloat,
    R5G5B5A1_Unorm = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.Unorm,
    R5G5B5A1_Snorm = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.Snorm,
    R5G5B5A1_UInt = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.UInt,
    R5G5B5A1_SInt = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.SInt,
    R5G5B5A1_Float = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.Float,
    R5G5B5A1_SRGB = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.SRGB,
    R5G5B5A1_Depth = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.Depth,
    R5G5B5A1_UScaled = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.UScaled,
    R5G5B5A1_SScaled = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.SScaled,
    R5G5B5A1_UFloat = (ChannelFormat.R5G5B5A1 << 8) | TypeFormat.UFloat,
    A1B5G5R5_Unorm = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.Unorm,
    A1B5G5R5_Snorm = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.Snorm,
    A1B5G5R5_UInt = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.UInt,
    A1B5G5R5_SInt = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.SInt,
    A1B5G5R5_Float = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.Float,
    A1B5G5R5_SRGB = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.SRGB,
    A1B5G5R5_Depth = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.Depth,
    A1B5G5R5_UScaled = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.UScaled,
    A1B5G5R5_SScaled = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.SScaled,
    A1B5G5R5_UFloat = (ChannelFormat.A1B5G5R5 << 8) | TypeFormat.UFloat,
    R5G6B5_Unorm = (ChannelFormat.R5G6B5 << 8) | TypeFormat.Unorm,
    R5G6B5_Snorm = (ChannelFormat.R5G6B5 << 8) | TypeFormat.Snorm,
    R5G6B5_UInt = (ChannelFormat.R5G6B5 << 8) | TypeFormat.UInt,
    R5G6B5_SInt = (ChannelFormat.R5G6B5 << 8) | TypeFormat.SInt,
    R5G6B5_Float = (ChannelFormat.R5G6B5 << 8) | TypeFormat.Float,
    R5G6B5_SRGB = (ChannelFormat.R5G6B5 << 8) | TypeFormat.SRGB,
    R5G6B5_Depth = (ChannelFormat.R5G6B5 << 8) | TypeFormat.Depth,
    R5G6B5_UScaled = (ChannelFormat.R5G6B5 << 8) | TypeFormat.UScaled,
    R5G6B5_SScaled = (ChannelFormat.R5G6B5 << 8) | TypeFormat.SScaled,
    R5G6B5_UFloat = (ChannelFormat.R5G6B5 << 8) | TypeFormat.UFloat,
    B5G6R5_Unorm = (ChannelFormat.B5G6R5 << 8) | TypeFormat.Unorm,
    B5G6R5_Snorm = (ChannelFormat.B5G6R5 << 8) | TypeFormat.Snorm,
    B5G6R5_UInt = (ChannelFormat.B5G6R5 << 8) | TypeFormat.UInt,
    B5G6R5_SInt = (ChannelFormat.B5G6R5 << 8) | TypeFormat.SInt,
    B5G6R5_Float = (ChannelFormat.B5G6R5 << 8) | TypeFormat.Float,
    B5G6R5_SRGB = (ChannelFormat.B5G6R5 << 8) | TypeFormat.SRGB,
    B5G6R5_Depth = (ChannelFormat.B5G6R5 << 8) | TypeFormat.Depth,
    B5G6R5_UScaled = (ChannelFormat.B5G6R5 << 8) | TypeFormat.UScaled,
    B5G6R5_SScaled = (ChannelFormat.B5G6R5 << 8) | TypeFormat.SScaled,
    B5G6R5_UFloat = (ChannelFormat.B5G6R5 << 8) | TypeFormat.UFloat,
    R8G8_Unorm = (ChannelFormat.R8G8 << 8) | TypeFormat.Unorm,
    R8G8_Snorm = (ChannelFormat.R8G8 << 8) | TypeFormat.Snorm,
    R8G8_UInt = (ChannelFormat.R8G8 << 8) | TypeFormat.UInt,
    R8G8_SInt = (ChannelFormat.R8G8 << 8) | TypeFormat.SInt,
    R8G8_Float = (ChannelFormat.R8G8 << 8) | TypeFormat.Float,
    R8G8_SRGB = (ChannelFormat.R8G8 << 8) | TypeFormat.SRGB,
    R8G8_Depth = (ChannelFormat.R8G8 << 8) | TypeFormat.Depth,
    R8G8_UScaled = (ChannelFormat.R8G8 << 8) | TypeFormat.UScaled,
    R8G8_SScaled = (ChannelFormat.R8G8 << 8) | TypeFormat.SScaled,
    R8G8_UFloat = (ChannelFormat.R8G8 << 8) | TypeFormat.UFloat,
    R16_Unorm = (ChannelFormat.R16 << 8) | TypeFormat.Unorm,
    R16_Snorm = (ChannelFormat.R16 << 8) | TypeFormat.Snorm,
    R16_UInt = (ChannelFormat.R16 << 8) | TypeFormat.UInt,
    R16_SInt = (ChannelFormat.R16 << 8) | TypeFormat.SInt,
    R16_Float = (ChannelFormat.R16 << 8) | TypeFormat.Float,
    R16_SRGB = (ChannelFormat.R16 << 8) | TypeFormat.SRGB,
    R16_Depth = (ChannelFormat.R16 << 8) | TypeFormat.Depth,
    R16_UScaled = (ChannelFormat.R16 << 8) | TypeFormat.UScaled,
    R16_SScaled = (ChannelFormat.R16 << 8) | TypeFormat.SScaled,
    R16_UFloat = (ChannelFormat.R16 << 8) | TypeFormat.UFloat,
    R8G8B8A8_Unorm = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.Unorm,
    R8G8B8A8_Snorm = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.Snorm,
    R8G8B8A8_UInt = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.UInt,
    R8G8B8A8_SInt = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.SInt,
    R8G8B8A8_Float = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.Float,
    R8G8B8A8_SRGB = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.SRGB,
    R8G8B8A8_Depth = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.Depth,
    R8G8B8A8_UScaled = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.UScaled,
    R8G8B8A8_SScaled = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.SScaled,
    R8G8B8A8_UFloat = (ChannelFormat.R8G8B8A8 << 8) | TypeFormat.UFloat,
    B8G8R8A8_Unorm = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.Unorm,
    B8G8R8A8_Snorm = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.Snorm,
    B8G8R8A8_UInt = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.UInt,
    B8G8R8A8_SInt = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.SInt,
    B8G8R8A8_Float = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.Float,
    B8G8R8A8_SRGB = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.SRGB,
    B8G8R8A8_Depth = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.Depth,
    B8G8R8A8_UScaled = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.UScaled,
    B8G8R8A8_SScaled = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.SScaled,
    B8G8R8A8_UFloat = (ChannelFormat.B8G8R8A8 << 8) | TypeFormat.UFloat,
    R9G9B9E5F_Unorm = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.Unorm,
    R9G9B9E5F_Snorm = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.Snorm,
    R9G9B9E5F_UInt = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.UInt,
    R9G9B9E5F_SInt = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.SInt,
    R9G9B9E5F_Float = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.Float,
    R9G9B9E5F_SRGB = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.SRGB,
    R9G9B9E5F_Depth = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.Depth,
    R9G9B9E5F_UScaled = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.UScaled,
    R9G9B9E5F_SScaled = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.SScaled,
    R9G9B9E5F_UFloat = (ChannelFormat.R9G9B9E5F << 8) | TypeFormat.UFloat,
    R10G10B10A2_Unorm = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.Unorm,
    R10G10B10A2_Snorm = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.Snorm,
    R10G10B10A2_UInt = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.UInt,
    R10G10B10A2_SInt = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.SInt,
    R10G10B10A2_Float = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.Float,
    R10G10B10A2_SRGB = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.SRGB,
    R10G10B10A2_Depth = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.Depth,
    R10G10B10A2_UScaled = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.UScaled,
    R10G10B10A2_SScaled = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.SScaled,
    R10G10B10A2_UFloat = (ChannelFormat.R10G10B10A2 << 8) | TypeFormat.UFloat,
    R11G11B10F_Unorm = (ChannelFormat.R11G11B10F << 8) | TypeFormat.Unorm,
    R11G11B10F_Snorm = (ChannelFormat.R11G11B10F << 8) | TypeFormat.Snorm,
    R11G11B10F_UInt = (ChannelFormat.R11G11B10F << 8) | TypeFormat.UInt,
    R11G11B10F_SInt = (ChannelFormat.R11G11B10F << 8) | TypeFormat.SInt,
    R11G11B10F_Float = (ChannelFormat.R11G11B10F << 8) | TypeFormat.Float,
    R11G11B10F_SRGB = (ChannelFormat.R11G11B10F << 8) | TypeFormat.SRGB,
    R11G11B10F_Depth = (ChannelFormat.R11G11B10F << 8) | TypeFormat.Depth,
    R11G11B10F_UScaled = (ChannelFormat.R11G11B10F << 8) | TypeFormat.UScaled,
    R11G11B10F_SScaled = (ChannelFormat.R11G11B10F << 8) | TypeFormat.SScaled,
    R11G11B10F_UFloat = (ChannelFormat.R11G11B10F << 8) | TypeFormat.UFloat,
    R16G16_Unorm = (ChannelFormat.R16G16 << 8) | TypeFormat.Unorm,
    R16G16_Snorm = (ChannelFormat.R16G16 << 8) | TypeFormat.Snorm,
    R16G16_UInt = (ChannelFormat.R16G16 << 8) | TypeFormat.UInt,
    R16G16_SInt = (ChannelFormat.R16G16 << 8) | TypeFormat.SInt,
    R16G16_Float = (ChannelFormat.R16G16 << 8) | TypeFormat.Float,
    R16G16_SRGB = (ChannelFormat.R16G16 << 8) | TypeFormat.SRGB,
    R16G16_Depth = (ChannelFormat.R16G16 << 8) | TypeFormat.Depth,
    R16G16_UScaled = (ChannelFormat.R16G16 << 8) | TypeFormat.UScaled,
    R16G16_SScaled = (ChannelFormat.R16G16 << 8) | TypeFormat.SScaled,
    R16G16_UFloat = (ChannelFormat.R16G16 << 8) | TypeFormat.UFloat,
    D24S8_Unorm = (ChannelFormat.D24S8 << 8) | TypeFormat.Unorm,
    D24S8_Snorm = (ChannelFormat.D24S8 << 8) | TypeFormat.Snorm,
    D24S8_UInt = (ChannelFormat.D24S8 << 8) | TypeFormat.UInt,
    D24S8_SInt = (ChannelFormat.D24S8 << 8) | TypeFormat.SInt,
    D24S8_Float = (ChannelFormat.D24S8 << 8) | TypeFormat.Float,
    D24S8_SRGB = (ChannelFormat.D24S8 << 8) | TypeFormat.SRGB,
    D24S8_Depth = (ChannelFormat.D24S8 << 8) | TypeFormat.Depth,
    D24S8_UScaled = (ChannelFormat.D24S8 << 8) | TypeFormat.UScaled,
    D24S8_SScaled = (ChannelFormat.D24S8 << 8) | TypeFormat.SScaled,
    D24S8_UFloat = (ChannelFormat.D24S8 << 8) | TypeFormat.UFloat,
    R32_Unorm = (ChannelFormat.R32 << 8) | TypeFormat.Unorm,
    R32_Snorm = (ChannelFormat.R32 << 8) | TypeFormat.Snorm,
    R32_UInt = (ChannelFormat.R32 << 8) | TypeFormat.UInt,
    R32_SInt = (ChannelFormat.R32 << 8) | TypeFormat.SInt,
    R32_Float = (ChannelFormat.R32 << 8) | TypeFormat.Float,
    R32_SRGB = (ChannelFormat.R32 << 8) | TypeFormat.SRGB,
    R32_Depth = (ChannelFormat.R32 << 8) | TypeFormat.Depth,
    R32_UScaled = (ChannelFormat.R32 << 8) | TypeFormat.UScaled,
    R32_SScaled = (ChannelFormat.R32 << 8) | TypeFormat.SScaled,
    R32_UFloat = (ChannelFormat.R32 << 8) | TypeFormat.UFloat,
    R16G16B16A16_Unorm = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.Unorm,
    R16G16B16A16_Snorm = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.Snorm,
    R16G16B16A16_UInt = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.UInt,
    R16G16B16A16_SInt = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.SInt,
    R16G16B16A16_Float = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.Float,
    R16G16B16A16_SRGB = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.SRGB,
    R16G16B16A16_Depth = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.Depth,
    R16G16B16A16_UScaled = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.UScaled,
    R16G16B16A16_SScaled = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.SScaled,
    R16G16B16A16_UFloat = (ChannelFormat.R16G16B16A16 << 8) | TypeFormat.UFloat,
    D32FS8_Unorm = (ChannelFormat.D32FS8 << 8) | TypeFormat.Unorm,
    D32FS8_Snorm = (ChannelFormat.D32FS8 << 8) | TypeFormat.Snorm,
    D32FS8_UInt = (ChannelFormat.D32FS8 << 8) | TypeFormat.UInt,
    D32FS8_SInt = (ChannelFormat.D32FS8 << 8) | TypeFormat.SInt,
    D32FS8_Float = (ChannelFormat.D32FS8 << 8) | TypeFormat.Float,
    D32FS8_SRGB = (ChannelFormat.D32FS8 << 8) | TypeFormat.SRGB,
    D32FS8_Depth = (ChannelFormat.D32FS8 << 8) | TypeFormat.Depth,
    D32FS8_UScaled = (ChannelFormat.D32FS8 << 8) | TypeFormat.UScaled,
    D32FS8_SScaled = (ChannelFormat.D32FS8 << 8) | TypeFormat.SScaled,
    D32FS8_UFloat = (ChannelFormat.D32FS8 << 8) | TypeFormat.UFloat,
    R32G32_Unorm = (ChannelFormat.R32G32 << 8) | TypeFormat.Unorm,
    R32G32_Snorm = (ChannelFormat.R32G32 << 8) | TypeFormat.Snorm,
    R32G32_UInt = (ChannelFormat.R32G32 << 8) | TypeFormat.UInt,
    R32G32_SInt = (ChannelFormat.R32G32 << 8) | TypeFormat.SInt,
    R32G32_Float = (ChannelFormat.R32G32 << 8) | TypeFormat.Float,
    R32G32_SRGB = (ChannelFormat.R32G32 << 8) | TypeFormat.SRGB,
    R32G32_Depth = (ChannelFormat.R32G32 << 8) | TypeFormat.Depth,
    R32G32_UScaled = (ChannelFormat.R32G32 << 8) | TypeFormat.UScaled,
    R32G32_SScaled = (ChannelFormat.R32G32 << 8) | TypeFormat.SScaled,
    R32G32_UFloat = (ChannelFormat.R32G32 << 8) | TypeFormat.UFloat,
    R32G32B32_Unorm = (ChannelFormat.R32G32B32 << 8) | TypeFormat.Unorm,
    R32G32B32_Snorm = (ChannelFormat.R32G32B32 << 8) | TypeFormat.Snorm,
    R32G32B32_UInt = (ChannelFormat.R32G32B32 << 8) | TypeFormat.UInt,
    R32G32B32_SInt = (ChannelFormat.R32G32B32 << 8) | TypeFormat.SInt,
    R32G32B32_Float = (ChannelFormat.R32G32B32 << 8) | TypeFormat.Float,
    R32G32B32_SRGB = (ChannelFormat.R32G32B32 << 8) | TypeFormat.SRGB,
    R32G32B32_Depth = (ChannelFormat.R32G32B32 << 8) | TypeFormat.Depth,
    R32G32B32_UScaled = (ChannelFormat.R32G32B32 << 8) | TypeFormat.UScaled,
    R32G32B32_SScaled = (ChannelFormat.R32G32B32 << 8) | TypeFormat.SScaled,
    R32G32B32_UFloat = (ChannelFormat.R32G32B32 << 8) | TypeFormat.UFloat,
    R32G32B32A32_Unorm = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.Unorm,
    R32G32B32A32_Snorm = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.Snorm,
    R32G32B32A32_UInt = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.UInt,
    R32G32B32A32_SInt = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.SInt,
    R32G32B32A32_Float = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.Float,
    R32G32B32A32_SRGB = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.SRGB,
    R32G32B32A32_Depth = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.Depth,
    R32G32B32A32_UScaled = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.UScaled,
    R32G32B32A32_SScaled = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.SScaled,
    R32G32B32A32_UFloat = (ChannelFormat.R32G32B32A32 << 8) | TypeFormat.UFloat,
    BC1_Unorm = (ChannelFormat.BC1 << 8) | TypeFormat.Unorm,
    BC1_Snorm = (ChannelFormat.BC1 << 8) | TypeFormat.Snorm,
    BC1_UInt = (ChannelFormat.BC1 << 8) | TypeFormat.UInt,
    BC1_SInt = (ChannelFormat.BC1 << 8) | TypeFormat.SInt,
    BC1_Float = (ChannelFormat.BC1 << 8) | TypeFormat.Float,
    BC1_SRGB = (ChannelFormat.BC1 << 8) | TypeFormat.SRGB,
    BC1_Depth = (ChannelFormat.BC1 << 8) | TypeFormat.Depth,
    BC1_UScaled = (ChannelFormat.BC1 << 8) | TypeFormat.UScaled,
    BC1_SScaled = (ChannelFormat.BC1 << 8) | TypeFormat.SScaled,
    BC1_UFloat = (ChannelFormat.BC1 << 8) | TypeFormat.UFloat,
    BC2_Unorm = (ChannelFormat.BC2 << 8) | TypeFormat.Unorm,
    BC2_Snorm = (ChannelFormat.BC2 << 8) | TypeFormat.Snorm,
    BC2_UInt = (ChannelFormat.BC2 << 8) | TypeFormat.UInt,
    BC2_SInt = (ChannelFormat.BC2 << 8) | TypeFormat.SInt,
    BC2_Float = (ChannelFormat.BC2 << 8) | TypeFormat.Float,
    BC2_SRGB = (ChannelFormat.BC2 << 8) | TypeFormat.SRGB,
    BC2_Depth = (ChannelFormat.BC2 << 8) | TypeFormat.Depth,
    BC2_UScaled = (ChannelFormat.BC2 << 8) | TypeFormat.UScaled,
    BC2_SScaled = (ChannelFormat.BC2 << 8) | TypeFormat.SScaled,
    BC2_UFloat = (ChannelFormat.BC2 << 8) | TypeFormat.UFloat,
    BC3_Unorm = (ChannelFormat.BC3 << 8) | TypeFormat.Unorm,
    BC3_Snorm = (ChannelFormat.BC3 << 8) | TypeFormat.Snorm,
    BC3_UInt = (ChannelFormat.BC3 << 8) | TypeFormat.UInt,
    BC3_SInt = (ChannelFormat.BC3 << 8) | TypeFormat.SInt,
    BC3_Float = (ChannelFormat.BC3 << 8) | TypeFormat.Float,
    BC3_SRGB = (ChannelFormat.BC3 << 8) | TypeFormat.SRGB,
    BC3_Depth = (ChannelFormat.BC3 << 8) | TypeFormat.Depth,
    BC3_UScaled = (ChannelFormat.BC3 << 8) | TypeFormat.UScaled,
    BC3_SScaled = (ChannelFormat.BC3 << 8) | TypeFormat.SScaled,
    BC3_UFloat = (ChannelFormat.BC3 << 8) | TypeFormat.UFloat,
    BC4_Unorm = (ChannelFormat.BC4 << 8) | TypeFormat.Unorm,
    BC4_Snorm = (ChannelFormat.BC4 << 8) | TypeFormat.Snorm,
    BC4_UInt = (ChannelFormat.BC4 << 8) | TypeFormat.UInt,
    BC4_SInt = (ChannelFormat.BC4 << 8) | TypeFormat.SInt,
    BC4_Float = (ChannelFormat.BC4 << 8) | TypeFormat.Float,
    BC4_SRGB = (ChannelFormat.BC4 << 8) | TypeFormat.SRGB,
    BC4_Depth = (ChannelFormat.BC4 << 8) | TypeFormat.Depth,
    BC4_UScaled = (ChannelFormat.BC4 << 8) | TypeFormat.UScaled,
    BC4_SScaled = (ChannelFormat.BC4 << 8) | TypeFormat.SScaled,
    BC4_UFloat = (ChannelFormat.BC4 << 8) | TypeFormat.UFloat,
    BC5_Unorm = (ChannelFormat.BC5 << 8) | TypeFormat.Unorm,
    BC5_Snorm = (ChannelFormat.BC5 << 8) | TypeFormat.Snorm,
    BC5_UInt = (ChannelFormat.BC5 << 8) | TypeFormat.UInt,
    BC5_SInt = (ChannelFormat.BC5 << 8) | TypeFormat.SInt,
    BC5_Float = (ChannelFormat.BC5 << 8) | TypeFormat.Float,
    BC5_SRGB = (ChannelFormat.BC5 << 8) | TypeFormat.SRGB,
    BC5_Depth = (ChannelFormat.BC5 << 8) | TypeFormat.Depth,
    BC5_UScaled = (ChannelFormat.BC5 << 8) | TypeFormat.UScaled,
    BC5_SScaled = (ChannelFormat.BC5 << 8) | TypeFormat.SScaled,
    BC5_UFloat = (ChannelFormat.BC5 << 8) | TypeFormat.UFloat,
    BC6H_Unorm = (ChannelFormat.BC6H << 8) | TypeFormat.Unorm,
    BC6H_Snorm = (ChannelFormat.BC6H << 8) | TypeFormat.Snorm,
    BC6H_UInt = (ChannelFormat.BC6H << 8) | TypeFormat.UInt,
    BC6H_SInt = (ChannelFormat.BC6H << 8) | TypeFormat.SInt,
    BC6H_Float = (ChannelFormat.BC6H << 8) | TypeFormat.Float,
    BC6H_SRGB = (ChannelFormat.BC6H << 8) | TypeFormat.SRGB,
    BC6H_Depth = (ChannelFormat.BC6H << 8) | TypeFormat.Depth,
    BC6H_UScaled = (ChannelFormat.BC6H << 8) | TypeFormat.UScaled,
    BC6H_SScaled = (ChannelFormat.BC6H << 8) | TypeFormat.SScaled,
    BC6H_UFloat = (ChannelFormat.BC6H << 8) | TypeFormat.UFloat,
    BC7U_Unorm = (ChannelFormat.BC7U << 8) | TypeFormat.Unorm,
    BC7U_Snorm = (ChannelFormat.BC7U << 8) | TypeFormat.Snorm,
    BC7U_UInt = (ChannelFormat.BC7U << 8) | TypeFormat.UInt,
    BC7U_SInt = (ChannelFormat.BC7U << 8) | TypeFormat.SInt,
    BC7U_Float = (ChannelFormat.BC7U << 8) | TypeFormat.Float,
    BC7U_SRGB = (ChannelFormat.BC7U << 8) | TypeFormat.SRGB,
    BC7U_Depth = (ChannelFormat.BC7U << 8) | TypeFormat.Depth,
    BC7U_UScaled = (ChannelFormat.BC7U << 8) | TypeFormat.UScaled,
    BC7U_SScaled = (ChannelFormat.BC7U << 8) | TypeFormat.SScaled,
    BC7U_UFloat = (ChannelFormat.BC7U << 8) | TypeFormat.UFloat,
    ASTC_10x6_Unorm = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.Unorm,
    ASTC_10x6_Snorm = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.Snorm,
    ASTC_10x6_UInt = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.UInt,
    ASTC_10x6_SInt = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.SInt,
    ASTC_10x6_Float = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.Float,
    ASTC_10x6_SRGB = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.SRGB,
    ASTC_10x6_Depth = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.Depth,
    ASTC_10x6_UScaled = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.UScaled,
    ASTC_10x6_SScaled = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.SScaled,
    ASTC_10x6_UFloat = (ChannelFormat.ASTC_10x6 << 8) | TypeFormat.UFloat,
    ASTC_4X4_Unorm = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.Unorm,
    ASTC_4X4_Snorm = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.Snorm,
    ASTC_4X4_UInt = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.UInt,
    ASTC_4X4_SInt = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.SInt,
    ASTC_4X4_Float = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.Float,
    ASTC_4X4_SRGB = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.SRGB,
    ASTC_4X4_Depth = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.Depth,
    ASTC_4X4_UScaled = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.UScaled,
    ASTC_4X4_SScaled = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.SScaled,
    ASTC_4X4_UFloat = (ChannelFormat.ASTC_4X4 << 8) | TypeFormat.UFloat,
    ASTC_5X4_Unorm = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.Unorm,
    ASTC_5X4_Snorm = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.Snorm,
    ASTC_5X4_UInt = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.UInt,
    ASTC_5X4_SInt = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.SInt,
    ASTC_5X4_Float = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.Float,
    ASTC_5X4_SRGB = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.SRGB,
    ASTC_5X4_Depth = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.Depth,
    ASTC_5X4_UScaled = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.UScaled,
    ASTC_5X4_SScaled = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.SScaled,
    ASTC_5X4_UFloat = (ChannelFormat.ASTC_5X4 << 8) | TypeFormat.UFloat,
    ASTC_5X5_Unorm = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.Unorm,
    ASTC_5X5_Snorm = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.Snorm,
    ASTC_5X5_UInt = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.UInt,
    ASTC_5X5_SInt = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.SInt,
    ASTC_5X5_Float = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.Float,
    ASTC_5X5_SRGB = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.SRGB,
    ASTC_5X5_Depth = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.Depth,
    ASTC_5X5_UScaled = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.UScaled,
    ASTC_5X5_SScaled = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.SScaled,
    ASTC_5X5_UFloat = (ChannelFormat.ASTC_5X5 << 8) | TypeFormat.UFloat,
    ASTC_6X5_Unorm = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.Unorm,
    ASTC_6X5_Snorm = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.Snorm,
    ASTC_6X5_UInt = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.UInt,
    ASTC_6X5_SInt = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.SInt,
    ASTC_6X5_Float = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.Float,
    ASTC_6X5_SRGB = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.SRGB,
    ASTC_6X5_Depth = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.Depth,
    ASTC_6X5_UScaled = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.UScaled,
    ASTC_6X5_SScaled = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.SScaled,
    ASTC_6X5_UFloat = (ChannelFormat.ASTC_6X5 << 8) | TypeFormat.UFloat,
    ASTC_6X6_Unorm = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.Unorm,
    ASTC_6X6_Snorm = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.Snorm,
    ASTC_6X6_UInt = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.UInt,
    ASTC_6X6_SInt = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.SInt,
    ASTC_6X6_Float = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.Float,
    ASTC_6X6_SRGB = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.SRGB,
    ASTC_6X6_Depth = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.Depth,
    ASTC_6X6_UScaled = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.UScaled,
    ASTC_6X6_SScaled = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.SScaled,
    ASTC_6X6_UFloat = (ChannelFormat.ASTC_6X6 << 8) | TypeFormat.UFloat,
    ASTC_8X5_Unorm = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.Unorm,
    ASTC_8X5_Snorm = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.Snorm,
    ASTC_8X5_UInt = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.UInt,
    ASTC_8X5_SInt = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.SInt,
    ASTC_8X5_Float = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.Float,
    ASTC_8X5_SRGB = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.SRGB,
    ASTC_8X5_Depth = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.Depth,
    ASTC_8X5_UScaled = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.UScaled,
    ASTC_8X5_SScaled = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.SScaled,
    ASTC_8X5_UFloat = (ChannelFormat.ASTC_8X5 << 8) | TypeFormat.UFloat,
    ASTC_8X6_Unorm = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.Unorm,
    ASTC_8X6_Snorm = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.Snorm,
    ASTC_8X6_UInt = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.UInt,
    ASTC_8X6_SInt = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.SInt,
    ASTC_8X6_Float = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.Float,
    ASTC_8X6_SRGB = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.SRGB,
    ASTC_8X6_Depth = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.Depth,
    ASTC_8X6_UScaled = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.UScaled,
    ASTC_8X6_SScaled = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.SScaled,
    ASTC_8X6_UFloat = (ChannelFormat.ASTC_8X6 << 8) | TypeFormat.UFloat,
    ASTC_8X8_Unorm = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.Unorm,
    ASTC_8X8_Snorm = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.Snorm,
    ASTC_8X8_UInt = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.UInt,
    ASTC_8X8_SInt = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.SInt,
    ASTC_8X8_Float = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.Float,
    ASTC_8X8_SRGB = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.SRGB,
    ASTC_8X8_Depth = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.Depth,
    ASTC_8X8_UScaled = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.UScaled,
    ASTC_8X8_SScaled = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.SScaled,
    ASTC_8X8_UFloat = (ChannelFormat.ASTC_8X8 << 8) | TypeFormat.UFloat,
    ASTC_10x5_Unorm = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.Unorm,
    ASTC_10x5_Snorm = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.Snorm,
    ASTC_10x5_UInt = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.UInt,
    ASTC_10x5_SInt = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.SInt,
    ASTC_10x5_Float = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.Float,
    ASTC_10x5_SRGB = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.SRGB,
    ASTC_10x5_Depth = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.Depth,
    ASTC_10x5_UScaled = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.UScaled,
    ASTC_10x5_SScaled = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.SScaled,
    ASTC_10x5_UFloat = (ChannelFormat.ASTC_10x5 << 8) | TypeFormat.UFloat,
    ASTC_10x8_Unorm = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.Unorm,
    ASTC_10x8_Snorm = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.Snorm,
    ASTC_10x8_UInt = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.UInt,
    ASTC_10x8_SInt = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.SInt,
    ASTC_10x8_Float = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.Float,
    ASTC_10x8_SRGB = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.SRGB,
    ASTC_10x8_Depth = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.Depth,
    ASTC_10x8_UScaled = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.UScaled,
    ASTC_10x8_SScaled = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.SScaled,
    ASTC_10x8_UFloat = (ChannelFormat.ASTC_10x8 << 8) | TypeFormat.UFloat,
    ASTC_10x10_Unorm = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.Unorm,
    ASTC_10x10_Snorm = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.Snorm,
    ASTC_10x10_UInt = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.UInt,
    ASTC_10x10_SInt = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.SInt,
    ASTC_10x10_Float = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.Float,
    ASTC_10x10_SRGB = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.SRGB,
    ASTC_10x10_Depth = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.Depth,
    ASTC_10x10_UScaled = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.UScaled,
    ASTC_10x10_SScaled = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.SScaled,
    ASTC_10x10_UFloat = (ChannelFormat.ASTC_10x10 << 8) | TypeFormat.UFloat,
    ASTC_12X10_Unorm = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.Unorm,
    ASTC_12X10_Snorm = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.Snorm,
    ASTC_12X10_UInt = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.UInt,
    ASTC_12X10_SInt = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.SInt,
    ASTC_12X10_Float = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.Float,
    ASTC_12X10_SRGB = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.SRGB,
    ASTC_12X10_Depth = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.Depth,
    ASTC_12X10_UScaled = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.UScaled,
    ASTC_12X10_SScaled = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.SScaled,
    ASTC_12X10_UFloat = (ChannelFormat.ASTC_12X10 << 8) | TypeFormat.UFloat,
    ASTC_12X12_Unorm = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.Unorm,
    ASTC_12X12_Snorm = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.Snorm,
    ASTC_12X12_UInt = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.UInt,
    ASTC_12X12_SInt = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.SInt,
    ASTC_12X12_Float = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.Float,
    ASTC_12X12_SRGB = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.SRGB,
    ASTC_12X12_Depth = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.Depth,
    ASTC_12X12_UScaled = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.UScaled,
    ASTC_12X12_SScaled = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.SScaled,
    ASTC_12X12_UFloat = (ChannelFormat.ASTC_12X12 << 8) | TypeFormat.UFloat,
    B5G5R5A1_Unorm = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.Unorm,
    B5G5R5A1_Snorm = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.Snorm,
    B5G5R5A1_UInt = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.UInt,
    B5G5R5A1_SInt = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.SInt,
    B5G5R5A1_Float = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.Float,
    B5G5R5A1_SRGB = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.SRGB,
    B5G5R5A1_Depth = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.Depth,
    B5G5R5A1_UScaled = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.UScaled,
    B5G5R5A1_SScaled = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.SScaled,
    B5G5R5A1_UFloat = (ChannelFormat.B5G5R5A1 << 8) | TypeFormat.UFloat,
}

public enum ImageDimension : byte
{
    Dim1D,
    Dim2D,
    Dim3D,
    DimCube,
    Dim1DArray,
    Dim2DArray,
    Dim2DMsaa,
    Dim2DMsaaArray,
    DimCubeArray,
}

public enum ImageStorageDimension : byte
{
    Type1D = 1,
    Type2D = 2,
    Type3D = 3
}

public enum TileMode : ushort
{
    Optimal = 0,
    Linear = 1
}

public enum TypeFormat : int
{
    Unorm = 0x1,
    Snorm = 0x2,
    UInt = 0x3,
    SInt = 0x4,
    Float = 0x5,
    SRGB = 0x6,
    Depth = 0x7,
    UScaled = 0x8,
    SScaled = 0x9,
    UFloat = 0xa,
}