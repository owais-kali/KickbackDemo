// Decompiled with JetBrains decompiler
// Type: UnityEngine.TextureFormat
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 11684410-BBEA-4C4E-8246-6F84FB700CB4
// Assembly location: /home/owais/Unity/Hub/Editor/2020.3.18f1/Editor/Data/Managed/UnityEngine/UnityEngine.CoreModule.dll

using System;
using System.ComponentModel;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Format used when creating textures from scripts.</para>
  /// </summary>
  /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat">`TextureFormat` on docs.unity3d.com</a></footer>
  public enum TextureFormat
  {
    [Obsolete("Enum member TextureFormat.ATC_RGB4 has been deprecated. Use ETC_RGB4 instead (UnityUpgradable) -> ETC_RGB4", true), EditorBrowsable(EditorBrowsableState.Never)] ATC_RGB4 = -127, // 0xFFFFFF81
    [Obsolete("Enum member TextureFormat.ATC_RGBA8 has been deprecated. Use ETC2_RGBA8 instead (UnityUpgradable) -> ETC2_RGBA8", true), EditorBrowsable(EditorBrowsableState.Never)] ATC_RGBA8 = -127, // 0xFFFFFF81
    [Obsolete("Enum member TextureFormat.PVRTC_2BPP_RGB has been deprecated. Use PVRTC_RGB2 instead (UnityUpgradable) -> PVRTC_RGB2", true), EditorBrowsable(EditorBrowsableState.Never)] PVRTC_2BPP_RGB = -127, // 0xFFFFFF81
    [Obsolete("Enum member TextureFormat.PVRTC_2BPP_RGBA has been deprecated. Use PVRTC_RGBA2 instead (UnityUpgradable) -> PVRTC_RGBA2", true), EditorBrowsable(EditorBrowsableState.Never)] PVRTC_2BPP_RGBA = -127, // 0xFFFFFF81
    [Obsolete("Enum member TextureFormat.PVRTC_4BPP_RGB has been deprecated. Use PVRTC_RGB4 instead (UnityUpgradable) -> PVRTC_RGB4", true), EditorBrowsable(EditorBrowsableState.Never)] PVRTC_4BPP_RGB = -127, // 0xFFFFFF81
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.PVRTC_4BPP_RGBA has been deprecated. Use PVRTC_RGBA4 instead (UnityUpgradable) -> PVRTC_RGBA4", true)] PVRTC_4BPP_RGBA = -127, // 0xFFFFFF81
    /// <summary>
    ///   <para>Alpha-only texture format, 8 bit integer.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.Alpha8">`TextureFormat.Alpha8` on docs.unity3d.com</a></footer>
    Alpha8 = 1,
    /// <summary>
    ///   <para>A 16 bits/pixel texture format. Texture stores color with an alpha channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ARGB4444">`TextureFormat.ARGB4444` on docs.unity3d.com</a></footer>
    ARGB4444 = 2,
    /// <summary>
    ///   <para>Color texture format, 8-bits per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGB24">`TextureFormat.RGB24` on docs.unity3d.com</a></footer>
    RGB24 = 3,
    /// <summary>
    ///   <para>Color with alpha texture format, 8-bits per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGBA32">`TextureFormat.RGBA32` on docs.unity3d.com</a></footer>
    RGBA32 = 4,
    /// <summary>
    ///   <para>Color with alpha texture format, 8-bits per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ARGB32">`TextureFormat.ARGB32` on docs.unity3d.com</a></footer>
    ARGB32 = 5,
    /// <summary>
    ///   <para>A 16 bit color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGB565">`TextureFormat.RGB565` on docs.unity3d.com</a></footer>
    RGB565 = 7,
    /// <summary>
    ///   <para>Single channel (R) texture format, 16 bit integer.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.R16">`TextureFormat.R16` on docs.unity3d.com</a></footer>
    R16 = 9,
    /// <summary>
    ///   <para>Compressed color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.DXT1">`TextureFormat.DXT1` on docs.unity3d.com</a></footer>
    DXT1 = 10, // 0x0000000A
    /// <summary>
    ///   <para>Compressed color with alpha channel texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.DXT5">`TextureFormat.DXT5` on docs.unity3d.com</a></footer>
    DXT5 = 12, // 0x0000000C
    /// <summary>
    ///   <para>Color and alpha  texture format, 4 bit per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGBA4444">`TextureFormat.RGBA4444` on docs.unity3d.com</a></footer>
    RGBA4444 = 13, // 0x0000000D
    /// <summary>
    ///   <para>Color with alpha texture format, 8-bits per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.BGRA32">`TextureFormat.BGRA32` on docs.unity3d.com</a></footer>
    BGRA32 = 14, // 0x0000000E
    /// <summary>
    ///   <para>Scalar (R)  texture format, 16 bit floating point.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RHalf">`TextureFormat.RHalf` on docs.unity3d.com</a></footer>
    RHalf = 15, // 0x0000000F
    /// <summary>
    ///   <para>Two color (RG)  texture format, 16 bit floating point per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGHalf">`TextureFormat.RGHalf` on docs.unity3d.com</a></footer>
    RGHalf = 16, // 0x00000010
    /// <summary>
    ///   <para>RGB color and alpha texture format, 16 bit floating point per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGBAHalf">`TextureFormat.RGBAHalf` on docs.unity3d.com</a></footer>
    RGBAHalf = 17, // 0x00000011
    /// <summary>
    ///   <para>Scalar (R) texture format, 32 bit floating point.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RFloat">`TextureFormat.RFloat` on docs.unity3d.com</a></footer>
    RFloat = 18, // 0x00000012
    /// <summary>
    ///   <para>Two color (RG)  texture format, 32 bit floating point per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGFloat">`TextureFormat.RGFloat` on docs.unity3d.com</a></footer>
    RGFloat = 19, // 0x00000013
    /// <summary>
    ///   <para>RGB color and alpha texture format,  32-bit floats per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGBAFloat">`TextureFormat.RGBAFloat` on docs.unity3d.com</a></footer>
    RGBAFloat = 20, // 0x00000014
    /// <summary>
    ///   <para>A format that uses the YUV color space and is often used for video encoding or playback.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.YUY2">`TextureFormat.YUY2` on docs.unity3d.com</a></footer>
    YUY2 = 21, // 0x00000015
    /// <summary>
    ///   <para>RGB HDR format, with 9 bit mantissa per channel and a 5 bit shared exponent.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGB9e5Float">`TextureFormat.RGB9e5Float` on docs.unity3d.com</a></footer>
    RGB9e5Float = 22, // 0x00000016
    /// <summary>
    ///   <para>HDR compressed color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.BC6H">`TextureFormat.BC6H` on docs.unity3d.com</a></footer>
    BC6H = 24, // 0x00000018
    /// <summary>
    ///   <para>High quality compressed color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.BC7">`TextureFormat.BC7` on docs.unity3d.com</a></footer>
    BC7 = 25, // 0x00000019
    /// <summary>
    ///   <para>Compressed one channel (R) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.BC4">`TextureFormat.BC4` on docs.unity3d.com</a></footer>
    BC4 = 26, // 0x0000001A
    /// <summary>
    ///   <para>Compressed two-channel (RG) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.BC5">`TextureFormat.BC5` on docs.unity3d.com</a></footer>
    BC5 = 27, // 0x0000001B
    /// <summary>
    ///   <para>Compressed color texture format with Crunch compression for smaller storage sizes.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.DXT1Crunched">`TextureFormat.DXT1Crunched` on docs.unity3d.com</a></footer>
    DXT1Crunched = 28, // 0x0000001C
    /// <summary>
    ///   <para>Compressed color with alpha channel texture format with Crunch compression for smaller storage sizes.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.DXT5Crunched">`TextureFormat.DXT5Crunched` on docs.unity3d.com</a></footer>
    DXT5Crunched = 29, // 0x0000001D
    /// <summary>
    ///   <para>PowerVR (iOS) 2 bits/pixel compressed color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.PVRTC_RGB2">`TextureFormat.PVRTC_RGB2` on docs.unity3d.com</a></footer>
    PVRTC_RGB2 = 30, // 0x0000001E
    /// <summary>
    ///   <para>PowerVR (iOS) 2 bits/pixel compressed with alpha channel texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.PVRTC_RGBA2">`TextureFormat.PVRTC_RGBA2` on docs.unity3d.com</a></footer>
    PVRTC_RGBA2 = 31, // 0x0000001F
    /// <summary>
    ///   <para>PowerVR (iOS) 4 bits/pixel compressed color texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.PVRTC_RGB4">`TextureFormat.PVRTC_RGB4` on docs.unity3d.com</a></footer>
    PVRTC_RGB4 = 32, // 0x00000020
    /// <summary>
    ///   <para>PowerVR (iOS) 4 bits/pixel compressed with alpha channel texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.PVRTC_RGBA4">`TextureFormat.PVRTC_RGBA4` on docs.unity3d.com</a></footer>
    PVRTC_RGBA4 = 33, // 0x00000021
    /// <summary>
    ///   <para>ETC (GLES2.0) 4 bits/pixel compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC_RGB4">`TextureFormat.ETC_RGB4` on docs.unity3d.com</a></footer>
    ETC_RGB4 = 34, // 0x00000022
    /// <summary>
    ///   <para>ETC2  EAC (GL ES 3.0) 4 bitspixel compressed unsigned single-channel texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.EAC_R">`TextureFormat.EAC_R` on docs.unity3d.com</a></footer>
    EAC_R = 41, // 0x00000029
    /// <summary>
    ///   <para>ETC2  EAC (GL ES 3.0) 4 bitspixel compressed signed single-channel texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.EAC_R_SIGNED">`TextureFormat.EAC_R_SIGNED` on docs.unity3d.com</a></footer>
    EAC_R_SIGNED = 42, // 0x0000002A
    /// <summary>
    ///   <para>ETC2  EAC (GL ES 3.0) 8 bitspixel compressed unsigned dual-channel (RG) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.EAC_RG">`TextureFormat.EAC_RG` on docs.unity3d.com</a></footer>
    EAC_RG = 43, // 0x0000002B
    /// <summary>
    ///   <para>ETC2  EAC (GL ES 3.0) 8 bitspixel compressed signed dual-channel (RG) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.EAC_RG_SIGNED">`TextureFormat.EAC_RG_SIGNED` on docs.unity3d.com</a></footer>
    EAC_RG_SIGNED = 44, // 0x0000002C
    /// <summary>
    ///   <para>ETC2 (GL ES 3.0) 4 bits/pixel compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC2_RGB">`TextureFormat.ETC2_RGB` on docs.unity3d.com</a></footer>
    ETC2_RGB = 45, // 0x0000002D
    /// <summary>
    ///   <para>ETC2 (GL ES 3.0) 4 bits/pixel RGB+1-bit alpha texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC2_RGBA1">`TextureFormat.ETC2_RGBA1` on docs.unity3d.com</a></footer>
    ETC2_RGBA1 = 46, // 0x0000002E
    /// <summary>
    ///   <para>ETC2 (GL ES 3.0) 8 bits/pixel compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC2_RGBA8">`TextureFormat.ETC2_RGBA8` on docs.unity3d.com</a></footer>
    ETC2_RGBA8 = 47, // 0x0000002F
    /// <summary>
    ///   <para>ASTC (4x4 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_4x4">`TextureFormat.ASTC_4x4` on docs.unity3d.com</a></footer>
    ASTC_4x4 = 48, // 0x00000030
    /// <summary>
    ///   <para>ASTC (4x4 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_4x4">`TextureFormat.ASTC_RGB_4x4` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGB_4x4 has been deprecated. Use ASTC_4x4 instead (UnityUpgradable) -> ASTC_4x4"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGB_4x4 = 48, // 0x00000030
    /// <summary>
    ///   <para>ASTC (5x5 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_5x5">`TextureFormat.ASTC_5x5` on docs.unity3d.com</a></footer>
    ASTC_5x5 = 49, // 0x00000031
    /// <summary>
    ///   <para>ASTC (5x5 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_5x5">`TextureFormat.ASTC_RGB_5x5` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGB_5x5 has been deprecated. Use ASTC_5x5 instead (UnityUpgradable) -> ASTC_5x5"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGB_5x5 = 49, // 0x00000031
    /// <summary>
    ///   <para>ASTC (6x6 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_6x6">`TextureFormat.ASTC_6x6` on docs.unity3d.com</a></footer>
    ASTC_6x6 = 50, // 0x00000032
    /// <summary>
    ///   <para>ASTC (6x6 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_6x6">`TextureFormat.ASTC_RGB_6x6` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGB_6x6 has been deprecated. Use ASTC_6x6 instead (UnityUpgradable) -> ASTC_6x6"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGB_6x6 = 50, // 0x00000032
    /// <summary>
    ///   <para>ASTC (8x8 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_8x8">`TextureFormat.ASTC_8x8` on docs.unity3d.com</a></footer>
    ASTC_8x8 = 51, // 0x00000033
    /// <summary>
    ///   <para>ASTC (8x8 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_8x8">`TextureFormat.ASTC_RGB_8x8` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGB_8x8 has been deprecated. Use ASTC_8x8 instead (UnityUpgradable) -> ASTC_8x8"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGB_8x8 = 51, // 0x00000033
    /// <summary>
    ///   <para>ASTC (10x10 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_10x10">`TextureFormat.ASTC_10x10` on docs.unity3d.com</a></footer>
    ASTC_10x10 = 52, // 0x00000034
    /// <summary>
    ///   <para>ASTC (10x10 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_10x10">`TextureFormat.ASTC_RGB_10x10` on docs.unity3d.com</a></footer>
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.ASTC_RGB_10x10 has been deprecated. Use ASTC_10x10 instead (UnityUpgradable) -> ASTC_10x10")] ASTC_RGB_10x10 = 52, // 0x00000034
    /// <summary>
    ///   <para>ASTC (12x12 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_12x12">`TextureFormat.ASTC_12x12` on docs.unity3d.com</a></footer>
    ASTC_12x12 = 53, // 0x00000035
    /// <summary>
    ///   <para>ASTC (12x12 pixel block in 128 bits) compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGB_12x12">`TextureFormat.ASTC_RGB_12x12` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGB_12x12 has been deprecated. Use ASTC_12x12 instead (UnityUpgradable) -> ASTC_12x12"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGB_12x12 = 53, // 0x00000035
    /// <summary>
    ///   <para>ASTC (4x4 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_4x4">`TextureFormat.ASTC_RGBA_4x4` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGBA_4x4 has been deprecated. Use ASTC_4x4 instead (UnityUpgradable) -> ASTC_4x4"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGBA_4x4 = 54, // 0x00000036
    /// <summary>
    ///   <para>ASTC (5x5 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_5x5">`TextureFormat.ASTC_RGBA_5x5` on docs.unity3d.com</a></footer>
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.ASTC_RGBA_5x5 has been deprecated. Use ASTC_5x5 instead (UnityUpgradable) -> ASTC_5x5")] ASTC_RGBA_5x5 = 55, // 0x00000037
    /// <summary>
    ///   <para>ASTC (6x6 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_6x6">`TextureFormat.ASTC_RGBA_6x6` on docs.unity3d.com</a></footer>
    [Obsolete("Enum member TextureFormat.ASTC_RGBA_6x6 has been deprecated. Use ASTC_6x6 instead (UnityUpgradable) -> ASTC_6x6"), EditorBrowsable(EditorBrowsableState.Never)] ASTC_RGBA_6x6 = 56, // 0x00000038
    /// <summary>
    ///   <para>ASTC (8x8 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_8x8">`TextureFormat.ASTC_RGBA_8x8` on docs.unity3d.com</a></footer>
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.ASTC_RGBA_8x8 has been deprecated. Use ASTC_8x8 instead (UnityUpgradable) -> ASTC_8x8")] ASTC_RGBA_8x8 = 57, // 0x00000039
    /// <summary>
    ///   <para>ASTC (10x10 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_10x10">`TextureFormat.ASTC_RGBA_10x10` on docs.unity3d.com</a></footer>
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.ASTC_RGBA_10x10 has been deprecated. Use ASTC_10x10 instead (UnityUpgradable) -> ASTC_10x10")] ASTC_RGBA_10x10 = 58, // 0x0000003A
    /// <summary>
    ///   <para>ASTC (12x12 pixel block in 128 bits) compressed RGBA texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_RGBA_12x12">`TextureFormat.ASTC_RGBA_12x12` on docs.unity3d.com</a></footer>
    [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Enum member TextureFormat.ASTC_RGBA_12x12 has been deprecated. Use ASTC_12x12 instead (UnityUpgradable) -> ASTC_12x12")] ASTC_RGBA_12x12 = 59, // 0x0000003B
    /// <summary>
    ///   <para>ETC 4 bits/pixel compressed RGB texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC_RGB4_3DS">`TextureFormat.ETC_RGB4_3DS` on docs.unity3d.com</a></footer>
    [Obsolete("Nintendo 3DS is no longer supported.")] ETC_RGB4_3DS = 60, // 0x0000003C
    /// <summary>
    ///   <para>ETC 4 bitspixel RGB + 4 bitspixel Alpha compressed texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC_RGBA8_3DS">`TextureFormat.ETC_RGBA8_3DS` on docs.unity3d.com</a></footer>
    [Obsolete("Nintendo 3DS is no longer supported.")] ETC_RGBA8_3DS = 61, // 0x0000003D
    /// <summary>
    ///   <para>Two color (RG) texture format, 8-bits per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RG16">`TextureFormat.RG16` on docs.unity3d.com</a></footer>
    RG16 = 62, // 0x0000003E
    /// <summary>
    ///   <para>Single channel (R) texture format, 8 bit integer.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.R8">`TextureFormat.R8` on docs.unity3d.com</a></footer>
    R8 = 63, // 0x0000003F
    /// <summary>
    ///   <para>Compressed color texture format with Crunch compression for smaller storage sizes.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC_RGB4Crunched">`TextureFormat.ETC_RGB4Crunched` on docs.unity3d.com</a></footer>
    ETC_RGB4Crunched = 64, // 0x00000040
    /// <summary>
    ///   <para>Compressed color with alpha channel texture format using Crunch compression for smaller storage sizes.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ETC2_RGBA8Crunched">`TextureFormat.ETC2_RGBA8Crunched` on docs.unity3d.com</a></footer>
    ETC2_RGBA8Crunched = 65, // 0x00000041
    /// <summary>
    ///   <para>ASTC (4x4 pixel block in 128 bits) compressed RGB(A) HDR texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_4x4">`TextureFormat.ASTC_HDR_4x4` on docs.unity3d.com</a></footer>
    ASTC_HDR_4x4 = 66, // 0x00000042
    /// <summary>
    ///   <para>ASTC (5x5 pixel block in 128 bits) compressed RGB(A) HDR texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_5x5">`TextureFormat.ASTC_HDR_5x5` on docs.unity3d.com</a></footer>
    ASTC_HDR_5x5 = 67, // 0x00000043
    /// <summary>
    ///   <para>ASTC (6x6 pixel block in 128 bits) compressed RGB(A) HDR texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_6x6">`TextureFormat.ASTC_HDR_6x6` on docs.unity3d.com</a></footer>
    ASTC_HDR_6x6 = 68, // 0x00000044
    /// <summary>
    ///   <para>ASTC (8x8 pixel block in 128 bits) compressed RGB(A) texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_8x8">`TextureFormat.ASTC_HDR_8x8` on docs.unity3d.com</a></footer>
    ASTC_HDR_8x8 = 69, // 0x00000045
    /// <summary>
    ///   <para>ASTC (10x10 pixel block in 128 bits) compressed RGB(A) HDR texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_10x10">`TextureFormat.ASTC_HDR_10x10` on docs.unity3d.com</a></footer>
    ASTC_HDR_10x10 = 70, // 0x00000046
    /// <summary>
    ///   <para>ASTC (12x12 pixel block in 128 bits) compressed RGB(A) HDR texture format.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.ASTC_HDR_12x12">`TextureFormat.ASTC_HDR_12x12` on docs.unity3d.com</a></footer>
    ASTC_HDR_12x12 = 71, // 0x00000047
    /// <summary>
    ///   <para>Two channel (RG) texture format, 16 bit integer per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RG32">`TextureFormat.RG32` on docs.unity3d.com</a></footer>
    RG32 = 72, // 0x00000048
    /// <summary>
    ///   <para>Three channel (RGB) texture format, 16 bit integer per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGB48">`TextureFormat.RGB48` on docs.unity3d.com</a></footer>
    RGB48 = 73, // 0x00000049
    /// <summary>
    ///   <para>Four channel (RGBA) texture format, 16 bit integer per channel.</para>
    /// </summary>
    /// <footer><a href="https://docs.unity3d.com/2020.3/Documentation/ScriptReference/30_search.html?q=TextureFormat.RGBA64">`TextureFormat.RGBA64` on docs.unity3d.com</a></footer>
    RGBA64 = 74, // 0x0000004A
  }
}
