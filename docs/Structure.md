# BNTX

Binary NX Texture Archive

- [BNTX](#bntx)
  - [Header](#header)
  - [Texture Container](#texture-container)
  - [Memory Pool](#memory-pool)
  - [Texture Pointer Array](#texture-pointer-array)
  - [String Table](#string-table)
  - [Texture Dictionary](#texture-dictionary)
    - [Texture Dictionary Entry](#texture-dictionary-entry)
  - [Texture Info Array](#texture-info-array)
    - [Texture Info](#texture-info)
  - [Texture Data](#texture-data)
  - [Relocation Table](#relocation-table)
    - [Relocation Table Section](#relocation-table-section)
    - [Relocation Table Entry](#relocation-table-entry)

## Header

BNTX files start with a `32`-byte header.

| Offset | Type    | Description                      |
| :----- | :------ | :------------------------------- |
| `0x00` | `u64`   | Magic (always BNTX `0x58544E42`) |
| `0x08` | `u8[4]` | Version                          |
| `0x0C` | `u16`   | Byte Order Mark (BoM)            |
| `0x0E` | `u8`    | Packed Alignment                 |
| `0x0F` | `u8`    | Target Address Size              |
| `0x10` | `u32`   | Name Offset                      |
| `0x14` | `u16`   | Relocation Flags                 |
| `0x16` | `u16`   | String Table Offset              |
| `0x18` | `u32`   | Relocation Table Offset          |
| `0x1C` | `u32`   | File Size                        |

## Texture Container

The texture container follows immediately after the BNTX header.

| Offset | Type    | Description                     |
| :----- | :------ | :------------------------------ |
| `0x00` | `u8[4]` | Target Platform                 |
| `0x04` | `u32`   | Texture Count                   |
| `0x08` | `void*` | Texture Info Array Pointer      |
| `0x10` | `void*` | Texture Data Pointer            |
| `0x18` | `void*` | Texture Info Dictionary Pointer |
| `0x20` | `void*` | Memory Pool Pointer             |
| `0x28` | `void*` | User Memory Pool Pointer        |
| `0x30` | `u32`   | Memory Pool Base Offset         |
| `0x34` | `u32`   | Reserved                        |

## Memory Pool

The memory pool is a constant `320`-byte buffer following immediately after the texture container.

| Offset | Type        | Description |
| :----- | :---------- | :---------- |
| `0x00` | `u8[0x140]` | Buffer      |

## Texture Pointer Array

The texture pointer array is an array of `64`-bit pointers into the [texture info array](#texture-info-array) following immediately after the memory pool.

The length of the array is defined in the [texture container](#texture-container)

| Offset | Type     | Description           |
| :----- | :------- | :-------------------- |
| `0x00` | `u64[n]` | Texture Pointer Array |

## String Table

The string table follows immediately after the memory pool.

| Offset | Type  | Description                      |
| :----- | :---- | :------------------------------- |
| `0x00` | `u32` | Magic (always _STR `0x5254535F`) |
| `0x04` | `u32` | Next Block Offset                |
| `0x08` | `u32` | Table Size                       |
| `0x0C` | `u32` | Reserved                         |
| `0x10` | `u32` | Count (n)                        |

This header is immediately followed by `n` pascal strings aligned to `2` bytes.

The first entry is an empty string (Size = `0x0000`, `u8[1] = [0]`).

| Offset     | Type    | Description                          |
| :--------- | :------ | :----------------------------------- |
| `0x00`     | `u16`   | Size (n)                             |
| `n` \` `2` | `u8[n]` | `n` long string aligned to `2` bytes |

The string table is aligned to `0x8` bytes.

## Texture Dictionary

The texture dictionary is an array of entries following immidiately after the string table.

| Offset | Type       | Description                        |
| :----- | :--------- | :--------------------------------- |
| `0x00` | `u32`      | Magic (always \_DIC `0x4349445F`)  |
| `0x04` | `u32`      | Count (n)                          |
| `0x08` | `Entry`    | Root (the BitIndex is always `-1`) |
| `0x08` | `Entry[n]` | Entries                            |

### Texture Dictionary Entry

| Offset | Type     | Description    |
| :----- | :------- | :------------- |
| `0x00` | `s32`    | BitIndex       |
| `0x04` | `u16[2]` | Indices        |
| `0x08` | `void*`  | String Pointer |

## Texture Info Array

The texture dictionary is followed by an array of texture info blocks.

The length of this array is defined in the header.

| Offset | Type         | Description |
| :----- | :----------- | :---------- |
| `0x00` | `Texture[n]` | Entries     |

### Texture Info

| Offset | Type     | Description                          |
| :----- | :------- | :----------------------------------- |
| `0x00` | `u32`    | Magic (always BRTI `0x42525449`)     |
| `0x04` | `u32`    | Next Block Offset                    |
| `0x08` | `u32`    | Size                                 |
| `0x0C` | `u32`    | Reserved                             |
| `0x10` | `u8`     | Flags                                |
| `0x11` | `u8`     | Texture Storage Dimension            |
| `0x12` | `u16`    | Tile Mode                            |
| `0x14` | `u16`    | Swizzle                              |
| `0x16` | `u16`    | Mip Count                            |
| `0x18` | `u16`    | Sample Count                         |
| `0x1A` | `u16`    | Reserved                             |
| `0x1C` | `u32`    | Texture Format                       |
| `0x20` | `u32`    | GPU Access Flags                     |
| `0x24` | `s32`    | Width                                |
| `0x28` | `s32`    | Height                               |
| `0x2C` | `s32`    | Depth                                |
| `0x30` | `u32`    | Array Layers                         |
| `0x34` | `u32`    | Texture Layout (1)                   |
| `0x38` | `u32`    | Texture Layout (2)                   |
| `0x3C` | `u8[20]` | Reserved                             |
| `0x50` | `u32`    | Texture Size                         |
| `0x54` | `u32`    | Texture Data Alignment               |
| `0x58` | `u32`    | Channel Type                         |
| `0x5C` | `u8`     | Texture Dimension                    |
| `0x5D` | `u8[3]`  | Padding                              |
| `0x60` | `void*`  | Texture Name Pointer                 |
| `0x68` | `void*`  | Parent Container Pointer             |
| `0x70` | `void**` | Mip Map Pointer Array Pointer        |
| `0x78` | `void*`  | User Data Pointer                    |
| `0x80` | `void*`  | In-Place Texture Region Pointer      |
| `0x88` | `void*`  | In-Place Texture View Region Pointer |
| `0x90` | `u64`    | Runtime Descriptor Slot              |
| `0x98` | `void*`  | User Data Dictionary Pointer         |

The header is immediately followed by the `0x100`-byte in-place texture region and the `0x100`-byte in-place texture view region.

| Offset  | Type        | Description         |
| :------ | :---------- | :------------------ |
| `0x0A0` | `u8[0x100]` | Texture Buffer      |
| `0x1A0` | `u8[0x100]` | Texture View Buffer |

These two regions are followed by an array of pointers to the mip map data in the data block.

The length of this array is defined by the `Mip Count` in the header.

| Offset  | Type       | Description           |
| :------ | :--------- | :-------------------- |
| `0x2A0` | `void*[n]` | Mip Map Data Pointers |

## Texture Data

The texture data header follows immediately after the [texture info array](#texture-info-array).

| Offset | Type  | Description                      |
| :----- | :---- | :------------------------------- |
| `0x00` | `u32` | Magic (always BRTD `0x44545242`) |
| `0x04` | `u32` | Next Block Offset                |
| `0x08` | `u32` | Size                             |
| `0x0C` | `u32` | Reserved                         |

The header is immediately followed by the texture data header. 

## Relocation Table

*Documentation provided by Watertoon. [Source](https://epd.zeldamods.org/wiki/Common_nn::util#Relocation_Tables).*

| Offset | Type  | Description                      |
| :----- | :---- | :------------------------------- |
| `0x0`  | `u32` | Magic (always _RLT `0x544C525F`) |
| `0x4`  | `u32` | Offset to this table             |
| `0x8`  | `u32` | Section count                    |
| `0xC`  | `u32` | Reserved                         |

### Relocation Table Section

| Offset | Type    | Description                                                         |
| :----- | :------ | :------------------------------------------------------------------ |
| `0x00` | `void*` | Base Pointer (when null, the region is relative to the BNTX header) |
| `0x08` | `u32`   | Region Offset (relative to BinaryFileHeader or Base Pointer)        |
| `0x0C` | `u32`   | Region Size                                                         |
| `0x10` | `u32`   | Base Entry Index                                                    |
| `0x14` | `u32`   | Entry Count                                                         |

### Relocation Table Entry

| Offset | Type | Description                                                  |
| :----- | :--- | :----------------------------------------------------------- |
| 0x0    | u32  | Region Offset (relative to section region offset)            |
| 0x4    | u16  | Array Count                                                  |
| 0x6    | u8   | Per-array Pointer Count                                      |
| 0x7    | u8   | Array Stride (in pointer count, so `stride * sizeof(void*)`) |