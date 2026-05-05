using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004DF RID: 1247
	[NativeHeader("Runtime/Graphics/GraphicsFormatUtility.bindings.h")]
	[NativeHeader("Runtime/Graphics/TextureFormat.h")]
	[NativeHeader("Runtime/Graphics/Format.h")]
	public class GraphicsFormatUtility
	{
		// Token: 0x06002B38 RID: 11064
		[FreeFunction("GetGraphicsFormat_Native_Texture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern GraphicsFormat GetFormat([NotNull("NullExceptionObject")] Texture texture);

		// Token: 0x06002B39 RID: 11065 RVA: 0x00049258 File Offset: 0x00047458
		public static GraphicsFormat GetGraphicsFormat(TextureFormat format, bool isSRGB)
		{
			return GraphicsFormatUtility.GetGraphicsFormat_Native_TextureFormat(format, isSRGB);
		}

		// Token: 0x06002B3A RID: 11066
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern GraphicsFormat GetGraphicsFormat_Native_TextureFormat(TextureFormat format, bool isSRGB);

		// Token: 0x06002B3B RID: 11067 RVA: 0x00049274 File Offset: 0x00047474
		public static TextureFormat GetTextureFormat(GraphicsFormat format)
		{
			return GraphicsFormatUtility.GetTextureFormat_Native_GraphicsFormat(format);
		}

		// Token: 0x06002B3C RID: 11068
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureFormat GetTextureFormat_Native_GraphicsFormat(GraphicsFormat format);

		// Token: 0x06002B3D RID: 11069 RVA: 0x0004928C File Offset: 0x0004748C
		public static GraphicsFormat GetGraphicsFormat(RenderTextureFormat format, bool isSRGB)
		{
			return GraphicsFormatUtility.GetGraphicsFormat_Native_RenderTextureFormat(format, isSRGB);
		}

		// Token: 0x06002B3E RID: 11070
		[FreeFunction(IsThreadSafe = false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern GraphicsFormat GetGraphicsFormat_Native_RenderTextureFormat(RenderTextureFormat format, bool isSRGB);

		// Token: 0x06002B3F RID: 11071 RVA: 0x000492A8 File Offset: 0x000474A8
		public static GraphicsFormat GetGraphicsFormat(RenderTextureFormat format, RenderTextureReadWrite readWrite)
		{
			bool flag = QualitySettings.activeColorSpace == ColorSpace.Linear;
			bool isSRGB = (readWrite == RenderTextureReadWrite.Default) ? flag : (readWrite == RenderTextureReadWrite.sRGB);
			return GraphicsFormatUtility.GetGraphicsFormat(format, isSRGB);
		}

		// Token: 0x06002B40 RID: 11072
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern GraphicsFormat GetDepthStencilFormatFromBitsLegacy_Native(int minimumDepthBits);

		// Token: 0x06002B41 RID: 11073 RVA: 0x000492D8 File Offset: 0x000474D8
		internal static GraphicsFormat GetDepthStencilFormat(int minimumDepthBits)
		{
			return GraphicsFormatUtility.GetDepthStencilFormatFromBitsLegacy_Native(minimumDepthBits);
		}

		// Token: 0x06002B42 RID: 11074
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetDepthBits(GraphicsFormat format);

		// Token: 0x06002B43 RID: 11075 RVA: 0x000492F0 File Offset: 0x000474F0
		public static GraphicsFormat GetDepthStencilFormat(int minimumDepthBits, int minimumStencilBits)
		{
			bool flag = minimumDepthBits == 0 && minimumStencilBits == 0;
			GraphicsFormat result;
			if (flag)
			{
				result = GraphicsFormat.None;
			}
			else
			{
				bool flag2 = minimumDepthBits < 0 || minimumStencilBits < 0;
				if (flag2)
				{
					throw new ArgumentException("Number of bits in DepthStencil format can't be negative.");
				}
				bool flag3 = minimumDepthBits > 32;
				if (flag3)
				{
					throw new ArgumentException("Number of depth buffer bits cannot exceed 32.");
				}
				bool flag4 = minimumStencilBits > 8;
				if (flag4)
				{
					throw new ArgumentException("Number of stencil buffer bits cannot exceed 8.");
				}
				bool flag5 = minimumDepthBits == 0;
				if (flag5)
				{
					minimumDepthBits = 0;
				}
				else
				{
					bool flag6 = minimumDepthBits <= 16;
					if (flag6)
					{
						minimumDepthBits = 16;
					}
					else
					{
						bool flag7 = minimumDepthBits <= 24;
						if (flag7)
						{
							minimumDepthBits = 24;
						}
						else
						{
							minimumDepthBits = 32;
						}
					}
				}
				bool flag8 = minimumStencilBits != 0;
				if (flag8)
				{
					minimumStencilBits = 8;
				}
				Debug.Assert(GraphicsFormatUtility.tableNoStencil.Length == GraphicsFormatUtility.tableStencil.Length);
				GraphicsFormat[] array = (minimumStencilBits > 0) ? GraphicsFormatUtility.tableStencil : GraphicsFormatUtility.tableNoStencil;
				int num = minimumDepthBits / 8;
				for (int i = num; i < array.Length; i++)
				{
					GraphicsFormat graphicsFormat = array[i];
					bool flag9 = SystemInfo.IsFormatSupported(graphicsFormat, FormatUsage.Render);
					if (flag9)
					{
						return graphicsFormat;
					}
				}
				result = GraphicsFormat.None;
			}
			return result;
		}

		// Token: 0x06002B44 RID: 11076
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSRGBFormat(GraphicsFormat format);

		// Token: 0x06002B45 RID: 11077
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSwizzleFormat(GraphicsFormat format);

		// Token: 0x06002B46 RID: 11078 RVA: 0x00049410 File Offset: 0x00047610
		public static bool IsSwizzleFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsSwizzleFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B47 RID: 11079
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GraphicsFormat GetSRGBFormat(GraphicsFormat format);

		// Token: 0x06002B48 RID: 11080
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GraphicsFormat GetLinearFormat(GraphicsFormat format);

		// Token: 0x06002B49 RID: 11081
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern RenderTextureFormat GetRenderTextureFormat(GraphicsFormat format);

		// Token: 0x06002B4A RID: 11082
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetColorComponentCount(GraphicsFormat format);

		// Token: 0x06002B4B RID: 11083 RVA: 0x00049430 File Offset: 0x00047630
		public static uint GetColorComponentCount(TextureFormat format)
		{
			return GraphicsFormatUtility.GetColorComponentCount(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B4C RID: 11084
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetAlphaComponentCount(GraphicsFormat format);

		// Token: 0x06002B4D RID: 11085 RVA: 0x00049450 File Offset: 0x00047650
		public static uint GetAlphaComponentCount(TextureFormat format)
		{
			return GraphicsFormatUtility.GetAlphaComponentCount(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B4E RID: 11086
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetComponentCount(GraphicsFormat format);

		// Token: 0x06002B4F RID: 11087 RVA: 0x00049470 File Offset: 0x00047670
		public static uint GetComponentCount(TextureFormat format)
		{
			return GraphicsFormatUtility.GetComponentCount(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B50 RID: 11088
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetFormatString(GraphicsFormat format);

		// Token: 0x06002B51 RID: 11089
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetFormatString_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B52 RID: 11090 RVA: 0x00049490 File Offset: 0x00047690
		public static string GetFormatString(TextureFormat format)
		{
			return GraphicsFormatUtility.GetFormatString_Native_TextureFormat(format);
		}

		// Token: 0x06002B53 RID: 11091
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsCompressedFormat(GraphicsFormat format);

		// Token: 0x06002B54 RID: 11092
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsCompressedFormat_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B55 RID: 11093 RVA: 0x000494A8 File Offset: 0x000476A8
		[Obsolete("IsCompressedTextureFormat is obsolete, please use IsCompressedFormat instead.")]
		internal static bool IsCompressedTextureFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsCompressedFormat(format);
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x000494C0 File Offset: 0x000476C0
		public static bool IsCompressedFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsCompressedFormat_Native_TextureFormat(format);
		}

		// Token: 0x06002B57 RID: 11095
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanDecompressFormat(GraphicsFormat format, bool wholeImage);

		// Token: 0x06002B58 RID: 11096 RVA: 0x000494D8 File Offset: 0x000476D8
		internal static bool CanDecompressFormat(GraphicsFormat format)
		{
			return GraphicsFormatUtility.CanDecompressFormat(format, true);
		}

		// Token: 0x06002B59 RID: 11097
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsPackedFormat(GraphicsFormat format);

		// Token: 0x06002B5A RID: 11098 RVA: 0x000494F4 File Offset: 0x000476F4
		public static bool IsPackedFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsPackedFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B5B RID: 11099
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool Is16BitPackedFormat(GraphicsFormat format);

		// Token: 0x06002B5C RID: 11100 RVA: 0x00049514 File Offset: 0x00047714
		public static bool Is16BitPackedFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.Is16BitPackedFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B5D RID: 11101
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GraphicsFormat ConvertToAlphaFormat(GraphicsFormat format);

		// Token: 0x06002B5E RID: 11102
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureFormat ConvertToAlphaFormat_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B5F RID: 11103 RVA: 0x00049534 File Offset: 0x00047734
		public static TextureFormat ConvertToAlphaFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.ConvertToAlphaFormat_Native_TextureFormat(format);
		}

		// Token: 0x06002B60 RID: 11104
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsAlphaOnlyFormat(GraphicsFormat format);

		// Token: 0x06002B61 RID: 11105
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsAlphaOnlyFormat_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B62 RID: 11106 RVA: 0x0004954C File Offset: 0x0004774C
		public static bool IsAlphaOnlyFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsAlphaOnlyFormat_Native_TextureFormat(format);
		}

		// Token: 0x06002B63 RID: 11107
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsAlphaTestFormat(GraphicsFormat format);

		// Token: 0x06002B64 RID: 11108 RVA: 0x00049564 File Offset: 0x00047764
		public static bool IsAlphaTestFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsAlphaTestFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B65 RID: 11109
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool HasAlphaChannel(GraphicsFormat format);

		// Token: 0x06002B66 RID: 11110
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAlphaChannel_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B67 RID: 11111 RVA: 0x00049584 File Offset: 0x00047784
		public static bool HasAlphaChannel(TextureFormat format)
		{
			return GraphicsFormatUtility.HasAlphaChannel_Native_TextureFormat(format);
		}

		// Token: 0x06002B68 RID: 11112
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsDepthFormat(GraphicsFormat format);

		// Token: 0x06002B69 RID: 11113
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsStencilFormat(GraphicsFormat format);

		// Token: 0x06002B6A RID: 11114
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsDepthStencilFormat(GraphicsFormat format);

		// Token: 0x06002B6B RID: 11115
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsIEEE754Format(GraphicsFormat format);

		// Token: 0x06002B6C RID: 11116
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsFloatFormat(GraphicsFormat format);

		// Token: 0x06002B6D RID: 11117
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsHalfFormat(GraphicsFormat format);

		// Token: 0x06002B6E RID: 11118
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsUnsignedFormat(GraphicsFormat format);

		// Token: 0x06002B6F RID: 11119 RVA: 0x0004959C File Offset: 0x0004779C
		public static bool IsUnsignedFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsUnsignedFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B70 RID: 11120
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSignedFormat(GraphicsFormat format);

		// Token: 0x06002B71 RID: 11121 RVA: 0x000495BC File Offset: 0x000477BC
		public static bool IsSignedFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsSignedFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B72 RID: 11122
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsNormFormat(GraphicsFormat format);

		// Token: 0x06002B73 RID: 11123
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsUNormFormat(GraphicsFormat format);

		// Token: 0x06002B74 RID: 11124
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSNormFormat(GraphicsFormat format);

		// Token: 0x06002B75 RID: 11125
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsIntegerFormat(GraphicsFormat format);

		// Token: 0x06002B76 RID: 11126
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsUIntFormat(GraphicsFormat format);

		// Token: 0x06002B77 RID: 11127
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSIntFormat(GraphicsFormat format);

		// Token: 0x06002B78 RID: 11128
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsXRFormat(GraphicsFormat format);

		// Token: 0x06002B79 RID: 11129
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsDXTCFormat(GraphicsFormat format);

		// Token: 0x06002B7A RID: 11130 RVA: 0x000495DC File Offset: 0x000477DC
		public static bool IsDXTCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsDXTCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B7B RID: 11131
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsRGTCFormat(GraphicsFormat format);

		// Token: 0x06002B7C RID: 11132 RVA: 0x000495FC File Offset: 0x000477FC
		public static bool IsRGTCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsRGTCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B7D RID: 11133
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsBPTCFormat(GraphicsFormat format);

		// Token: 0x06002B7E RID: 11134 RVA: 0x0004961C File Offset: 0x0004781C
		public static bool IsBPTCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsBPTCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B7F RID: 11135
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsBCFormat(GraphicsFormat format);

		// Token: 0x06002B80 RID: 11136 RVA: 0x0004963C File Offset: 0x0004783C
		public static bool IsBCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsBCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B81 RID: 11137
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsPVRTCFormat(GraphicsFormat format);

		// Token: 0x06002B82 RID: 11138 RVA: 0x0004965C File Offset: 0x0004785C
		public static bool IsPVRTCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsPVRTCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B83 RID: 11139
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsETCFormat(GraphicsFormat format);

		// Token: 0x06002B84 RID: 11140 RVA: 0x0004967C File Offset: 0x0004787C
		public static bool IsETCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsETCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B85 RID: 11141
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsEACFormat(GraphicsFormat format);

		// Token: 0x06002B86 RID: 11142 RVA: 0x0004969C File Offset: 0x0004789C
		public static bool IsEACFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsEACFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B87 RID: 11143
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsASTCFormat(GraphicsFormat format);

		// Token: 0x06002B88 RID: 11144 RVA: 0x000496BC File Offset: 0x000478BC
		public static bool IsASTCFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsASTCFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B89 RID: 11145
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsHDRFormat(GraphicsFormat format);

		// Token: 0x06002B8A RID: 11146
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsHDRFormat_Native_TextureFormat(TextureFormat format);

		// Token: 0x06002B8B RID: 11147 RVA: 0x000496DC File Offset: 0x000478DC
		public static bool IsHDRFormat(TextureFormat format)
		{
			return GraphicsFormatUtility.IsHDRFormat_Native_TextureFormat(format);
		}

		// Token: 0x06002B8C RID: 11148
		[FreeFunction("IsCompressedCrunchTextureFormat", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsCrunchFormat(TextureFormat format);

		// Token: 0x06002B8D RID: 11149
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern FormatSwizzle GetSwizzleR(GraphicsFormat format);

		// Token: 0x06002B8E RID: 11150 RVA: 0x000496F4 File Offset: 0x000478F4
		public static FormatSwizzle GetSwizzleR(TextureFormat format)
		{
			return GraphicsFormatUtility.GetSwizzleR(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B8F RID: 11151
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern FormatSwizzle GetSwizzleG(GraphicsFormat format);

		// Token: 0x06002B90 RID: 11152 RVA: 0x00049714 File Offset: 0x00047914
		public static FormatSwizzle GetSwizzleG(TextureFormat format)
		{
			return GraphicsFormatUtility.GetSwizzleG(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B91 RID: 11153
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern FormatSwizzle GetSwizzleB(GraphicsFormat format);

		// Token: 0x06002B92 RID: 11154 RVA: 0x00049734 File Offset: 0x00047934
		public static FormatSwizzle GetSwizzleB(TextureFormat format)
		{
			return GraphicsFormatUtility.GetSwizzleB(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B93 RID: 11155
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern FormatSwizzle GetSwizzleA(GraphicsFormat format);

		// Token: 0x06002B94 RID: 11156 RVA: 0x00049754 File Offset: 0x00047954
		public static FormatSwizzle GetSwizzleA(TextureFormat format)
		{
			return GraphicsFormatUtility.GetSwizzleA(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B95 RID: 11157
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetBlockSize(GraphicsFormat format);

		// Token: 0x06002B96 RID: 11158 RVA: 0x00049774 File Offset: 0x00047974
		public static uint GetBlockSize(TextureFormat format)
		{
			return GraphicsFormatUtility.GetBlockSize(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B97 RID: 11159
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetBlockWidth(GraphicsFormat format);

		// Token: 0x06002B98 RID: 11160 RVA: 0x00049794 File Offset: 0x00047994
		public static uint GetBlockWidth(TextureFormat format)
		{
			return GraphicsFormatUtility.GetBlockWidth(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B99 RID: 11161
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetBlockHeight(GraphicsFormat format);

		// Token: 0x06002B9A RID: 11162 RVA: 0x000497B4 File Offset: 0x000479B4
		public static uint GetBlockHeight(TextureFormat format)
		{
			return GraphicsFormatUtility.GetBlockHeight(GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x000497D4 File Offset: 0x000479D4
		public static uint ComputeMipmapSize(int width, int height, GraphicsFormat format)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_2D(width, height, format, 1);
		}

		// Token: 0x06002B9C RID: 11164 RVA: 0x000497F0 File Offset: 0x000479F0
		public static uint ComputeMipmapSize(int width, int height, TextureFormat format)
		{
			return GraphicsFormatUtility.ComputeMipmapSize(width, height, GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002B9D RID: 11165
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint ComputeMipChainSize_Native_2D(int width, int height, GraphicsFormat format, int mipCount);

		// Token: 0x06002B9E RID: 11166 RVA: 0x00049810 File Offset: 0x00047A10
		public static uint ComputeMipChainSize(int width, int height, GraphicsFormat format, [DefaultValue("-1")] int mipCount = -1)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_2D(width, height, format, mipCount);
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x0004982C File Offset: 0x00047A2C
		public static uint ComputeMipChainSize(int width, int height, TextureFormat format, [DefaultValue("-1")] int mipCount = -1)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_2D(width, height, GraphicsFormatUtility.GetGraphicsFormat(format, false), mipCount);
		}

		// Token: 0x06002BA0 RID: 11168 RVA: 0x00049850 File Offset: 0x00047A50
		public static uint ComputeMipmapSize(int width, int height, int depth, GraphicsFormat format)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_3D(width, height, depth, format, 1);
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x0004986C File Offset: 0x00047A6C
		public static uint ComputeMipmapSize(int width, int height, int depth, TextureFormat format)
		{
			return GraphicsFormatUtility.ComputeMipmapSize(width, height, depth, GraphicsFormatUtility.GetGraphicsFormat(format, false));
		}

		// Token: 0x06002BA2 RID: 11170
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint ComputeMipChainSize_Native_3D(int width, int height, int depth, GraphicsFormat format, int mipCount);

		// Token: 0x06002BA3 RID: 11171 RVA: 0x00049890 File Offset: 0x00047A90
		public static uint ComputeMipChainSize(int width, int height, int depth, GraphicsFormat format, [DefaultValue("-1")] int mipCount = -1)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_3D(width, height, depth, format, mipCount);
		}

		// Token: 0x06002BA4 RID: 11172 RVA: 0x000498B0 File Offset: 0x00047AB0
		public static uint ComputeMipChainSize(int width, int height, int depth, TextureFormat format, [DefaultValue("-1")] int mipCount = -1)
		{
			return GraphicsFormatUtility.ComputeMipChainSize_Native_3D(width, height, depth, GraphicsFormatUtility.GetGraphicsFormat(format, false), mipCount);
		}

		// Token: 0x040010E2 RID: 4322
		private static readonly GraphicsFormat[] tableNoStencil = new GraphicsFormat[]
		{
			GraphicsFormat.None,
			GraphicsFormat.D16_UNorm,
			GraphicsFormat.D16_UNorm,
			GraphicsFormat.D24_UNorm,
			GraphicsFormat.D32_SFloat
		};

		// Token: 0x040010E3 RID: 4323
		private static readonly GraphicsFormat[] tableStencil = new GraphicsFormat[]
		{
			GraphicsFormat.S8_UInt,
			GraphicsFormat.D16_UNorm_S8_UInt,
			GraphicsFormat.D16_UNorm_S8_UInt,
			GraphicsFormat.D24_UNorm_S8_UInt,
			GraphicsFormat.D32_SFloat_S8_UInt
		};
	}
}
