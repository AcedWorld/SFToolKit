using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001D1 RID: 465
	[NativeHeader("Runtime/Graphics/CubemapTexture.h")]
	[ExcludeFromPreset]
	public sealed class Cubemap : Texture
	{
		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060012D5 RID: 4821
		public extern TextureFormat format { [NativeName("GetTextureFormat")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060012D6 RID: 4822
		[FreeFunction("CubemapScripting::Create")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_CreateImpl([Writable] Cubemap mono, int ext, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex);

		// Token: 0x060012D7 RID: 4823 RVA: 0x0001A350 File Offset: 0x00018550
		private static void Internal_Create([Writable] Cubemap mono, int ext, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex)
		{
			bool flag = !Cubemap.Internal_CreateImpl(mono, ext, mipCount, format, colorSpace, flags, nativeTex);
			if (flag)
			{
				throw new UnityException("Failed to create texture because of invalid parameters.");
			}
		}

		// Token: 0x060012D8 RID: 4824
		[FreeFunction(Name = "CubemapScripting::Apply", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable);

		// Token: 0x060012D9 RID: 4825
		[FreeFunction("CubemapScripting::UpdateExternalTexture", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void UpdateExternalTexture(IntPtr nativeTexture);

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060012DA RID: 4826
		public override extern bool isReadable { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060012DB RID: 4827 RVA: 0x0001A37F File Offset: 0x0001857F
		[NativeName("SetPixel")]
		private void SetPixelImpl(int image, int mip, int x, int y, Color color)
		{
			this.SetPixelImpl_Injected(image, mip, x, y, ref color);
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x0001A390 File Offset: 0x00018590
		[NativeName("GetPixel")]
		private Color GetPixelImpl(int image, int mip, int x, int y)
		{
			Color result;
			this.GetPixelImpl_Injected(image, mip, x, y, out result);
			return result;
		}

		// Token: 0x060012DD RID: 4829
		[NativeName("FixupEdges")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SmoothEdges([DefaultValue("1")] int smoothRegionWidthInPixels);

		// Token: 0x060012DE RID: 4830 RVA: 0x0001A3AB File Offset: 0x000185AB
		public void SmoothEdges()
		{
			this.SmoothEdges(1);
		}

		// Token: 0x060012DF RID: 4831
		[FreeFunction(Name = "CubemapScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Color[] GetPixels(CubemapFace face, int miplevel);

		// Token: 0x060012E0 RID: 4832 RVA: 0x0001A3B8 File Offset: 0x000185B8
		public Color[] GetPixels(CubemapFace face)
		{
			return this.GetPixels(face, 0);
		}

		// Token: 0x060012E1 RID: 4833
		[FreeFunction(Name = "CubemapScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPixels([Unmarshalled] Color[] colors, CubemapFace face, int miplevel);

		// Token: 0x060012E2 RID: 4834
		[FreeFunction(Name = "CubemapScripting::SetPixelDataArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImplArray(Array data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x060012E3 RID: 4835
		[FreeFunction(Name = "CubemapScripting::SetPixelData", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImpl(IntPtr data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x060012E4 RID: 4836 RVA: 0x0001A3D2 File Offset: 0x000185D2
		public void SetPixels(Color[] colors, CubemapFace face)
		{
			this.SetPixels(colors, face, 0);
		}

		// Token: 0x060012E5 RID: 4837
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetWritableImageData(int frame);

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060012E6 RID: 4838
		internal extern bool isPreProcessed { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060012E7 RID: 4839
		public extern bool streamingMipmaps { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060012E8 RID: 4840
		public extern int streamingMipmapsPriority { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060012E9 RID: 4841
		// (set) Token: 0x060012EA RID: 4842
		public extern int requestedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetRequestedMipmapLevel", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetRequestedMipmapLevel", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060012EB RID: 4843
		// (set) Token: 0x060012EC RID: 4844
		internal extern bool loadAllMips { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadAllMips", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetLoadAllMips", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060012ED RID: 4845
		public extern int desiredMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetDesiredMipmapLevel", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060012EE RID: 4846
		public extern int loadingMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadingMipmapLevel", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060012EF RID: 4847
		public extern int loadedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadedMipmapLevel", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060012F0 RID: 4848
		[FreeFunction(Name = "GetTextureStreamingManager().ClearRequestedMipmapLevel", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void ClearRequestedMipmapLevel();

		// Token: 0x060012F1 RID: 4849
		[FreeFunction(Name = "GetTextureStreamingManager().IsRequestedMipmapLevelLoaded", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool IsRequestedMipmapLevelLoaded();

		// Token: 0x060012F2 RID: 4850 RVA: 0x0001A3E0 File Offset: 0x000185E0
		internal bool ValidateFormat(TextureFormat format, int width)
		{
			bool flag = base.ValidateFormat(format);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = TextureFormat.PVRTC_RGB2 <= format && format <= TextureFormat.PVRTC_RGBA4;
				bool flag4 = flag3 && !Mathf.IsPowerOfTwo(width);
				if (flag4)
				{
					throw new UnityException(string.Format("'{0}' demands texture to have power-of-two dimensions", format.ToString()));
				}
			}
			return flag;
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0001A448 File Offset: 0x00018648
		internal bool ValidateFormat(GraphicsFormat format, int width)
		{
			bool flag = base.ValidateFormat(format, FormatUsage.Sample);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = GraphicsFormatUtility.IsPVRTCFormat(format);
				bool flag4 = flag3 && !Mathf.IsPowerOfTwo(width);
				if (flag4)
				{
					throw new UnityException(string.Format("'{0}' demands texture to have power-of-two dimensions", format.ToString()));
				}
			}
			return flag;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x0001A4A4 File Offset: 0x000186A4
		[ExcludeFromDocs]
		public Cubemap(int width, DefaultFormat format, TextureCreationFlags flags) : this(width, SystemInfo.GetGraphicsFormat(format), flags)
		{
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x0001A4B6 File Offset: 0x000186B6
		[ExcludeFromDocs]
		public Cubemap(int width, DefaultFormat format, TextureCreationFlags flags, int mipCount) : this(width, SystemInfo.GetGraphicsFormat(format), flags, mipCount)
		{
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x0001A4CA File Offset: 0x000186CA
		[RequiredByNativeCode]
		[ExcludeFromDocs]
		public Cubemap(int width, GraphicsFormat format, TextureCreationFlags flags) : this(width, format, flags, Texture.GenerateAllMips)
		{
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x0001A4DC File Offset: 0x000186DC
		[ExcludeFromDocs]
		public Cubemap(int width, GraphicsFormat format, TextureCreationFlags flags, int mipCount)
		{
			bool flag = !this.ValidateFormat(format, width);
			if (!flag)
			{
				Cubemap.ValidateIsNotCrunched(flags);
				Cubemap.Internal_Create(this, width, mipCount, format, base.GetTextureColorSpace(format), flags, IntPtr.Zero);
			}
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x0001A524 File Offset: 0x00018724
		internal Cubemap(int width, TextureFormat textureFormat, int mipCount, IntPtr nativeTex, bool createUninitialized)
		{
			bool flag = !this.ValidateFormat(textureFormat, width);
			if (!flag)
			{
				GraphicsFormat graphicsFormat = GraphicsFormatUtility.GetGraphicsFormat(textureFormat, false);
				TextureCreationFlags textureCreationFlags = (mipCount != 1) ? TextureCreationFlags.MipChain : TextureCreationFlags.None;
				bool flag2 = GraphicsFormatUtility.IsCrunchFormat(textureFormat);
				if (flag2)
				{
					textureCreationFlags |= TextureCreationFlags.Crunch;
				}
				if (createUninitialized)
				{
					textureCreationFlags |= (TextureCreationFlags.DontInitializePixels | TextureCreationFlags.DontUploadUponCreate);
				}
				Cubemap.ValidateIsNotCrunched(textureCreationFlags);
				Cubemap.Internal_Create(this, width, mipCount, graphicsFormat, base.GetTextureColorSpace(true), textureCreationFlags, nativeTex);
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x0001A595 File Offset: 0x00018795
		public Cubemap(int width, TextureFormat textureFormat, bool mipChain) : this(width, textureFormat, mipChain ? Texture.GenerateAllMips : 1, IntPtr.Zero, false)
		{
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x0001A5B2 File Offset: 0x000187B2
		public Cubemap(int width, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool createUninitialized) : this(width, textureFormat, mipChain ? Texture.GenerateAllMips : 1, IntPtr.Zero, createUninitialized)
		{
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x0001A5D0 File Offset: 0x000187D0
		public Cubemap(int width, TextureFormat format, int mipCount) : this(width, format, mipCount, IntPtr.Zero, false)
		{
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x0001A5E3 File Offset: 0x000187E3
		public Cubemap(int width, TextureFormat format, int mipCount, [DefaultValue("false")] bool createUninitialized) : this(width, format, mipCount, IntPtr.Zero, createUninitialized)
		{
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x0001A5F8 File Offset: 0x000187F8
		public static Cubemap CreateExternalTexture(int width, TextureFormat format, bool mipmap, IntPtr nativeTex)
		{
			bool flag = nativeTex == IntPtr.Zero;
			if (flag)
			{
				throw new ArgumentException("nativeTex can not be null");
			}
			return new Cubemap(width, format, mipmap ? Texture.GenerateAllMips : 1, nativeTex, false);
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x0001A638 File Offset: 0x00018838
		public void SetPixelData<T>(T[] data, int mipLevel, CubemapFace face, [DefaultValue("0")] int sourceDataStartIndex = 0)
		{
			bool flag = sourceDataStartIndex < 0;
			if (flag)
			{
				throw new UnityException("SetPixelData: sourceDataStartIndex cannot be less than 0.");
			}
			bool flag2 = !this.isReadable;
			if (flag2)
			{
				throw base.CreateNonReadableException(this);
			}
			bool flag3 = data == null || data.Length == 0;
			if (flag3)
			{
				throw new UnityException("No texture data provided to SetPixelData.");
			}
			this.SetPixelDataImplArray(data, mipLevel, (int)face, Marshal.SizeOf<T>(data[0]), data.Length, sourceDataStartIndex);
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x0001A6A4 File Offset: 0x000188A4
		public void SetPixelData<T>(NativeArray<T> data, int mipLevel, CubemapFace face, [DefaultValue("0")] int sourceDataStartIndex = 0) where T : struct
		{
			bool flag = sourceDataStartIndex < 0;
			if (flag)
			{
				throw new UnityException("SetPixelData: sourceDataStartIndex cannot be less than 0.");
			}
			bool flag2 = !this.isReadable;
			if (flag2)
			{
				throw base.CreateNonReadableException(this);
			}
			bool flag3 = !data.IsCreated || data.Length == 0;
			if (flag3)
			{
				throw new UnityException("No texture data provided to SetPixelData.");
			}
			this.SetPixelDataImpl((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), mipLevel, (int)face, UnsafeUtility.SizeOf<T>(), data.Length, sourceDataStartIndex);
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x0001A724 File Offset: 0x00018924
		public unsafe NativeArray<T> GetPixelData<T>(int mipLevel, CubemapFace face) where T : struct
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			bool flag2 = mipLevel < 0 || mipLevel >= base.mipmapCount;
			if (flag2)
			{
				throw new ArgumentException("The passed in miplevel " + mipLevel.ToString() + " is invalid. The valid range is 0 through " + (base.mipmapCount - 1).ToString());
			}
			bool flag3 = face < CubemapFace.PositiveX || face >= (CubemapFace)6;
			if (flag3)
			{
				throw new ArgumentException("The passed in face " + face.ToString() + " is invalid. The valid range is 0 through 5.");
			}
			bool flag4 = this.GetWritableImageData(0).ToInt64() == 0L;
			if (flag4)
			{
				throw new UnityException("Texture '" + base.name + "' has no data.");
			}
			ulong pixelDataOffset = base.GetPixelDataOffset(base.mipmapCount, (int)face);
			ulong pixelDataOffset2 = base.GetPixelDataOffset(mipLevel, (int)face);
			ulong pixelDataSize = base.GetPixelDataSize(mipLevel, (int)face);
			int num = UnsafeUtility.SizeOf<T>();
			ulong num2 = pixelDataSize / (ulong)((long)num);
			bool flag5 = num2 > 2147483647UL;
			if (flag5)
			{
				throw base.CreateNativeArrayLengthOverflowException();
			}
			IntPtr value = new IntPtr((long)this.GetWritableImageData(0) + (long)(pixelDataOffset * (ulong)((long)face) + pixelDataOffset2));
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)value, (int)num2, Allocator.None);
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x0001A871 File Offset: 0x00018A71
		[ExcludeFromDocs]
		public void SetPixel(CubemapFace face, int x, int y, Color color)
		{
			this.SetPixel(face, x, y, color, 0);
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x0001A884 File Offset: 0x00018A84
		public void SetPixel(CubemapFace face, int x, int y, Color color, [DefaultValue("0")] int mip)
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			this.SetPixelImpl((int)face, mip, x, y, color);
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x0001A8B8 File Offset: 0x00018AB8
		[ExcludeFromDocs]
		public Color GetPixel(CubemapFace face, int x, int y)
		{
			return this.GetPixel(face, x, y, 0);
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0001A8D4 File Offset: 0x00018AD4
		public Color GetPixel(CubemapFace face, int x, int y, [DefaultValue("0")] int mip)
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			return this.GetPixelImpl((int)face, mip, x, y);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0001A908 File Offset: 0x00018B08
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable)
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			this.ApplyImpl(updateMipmaps, makeNoLongerReadable);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0001A934 File Offset: 0x00018B34
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps)
		{
			this.Apply(updateMipmaps, false);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x0001A940 File Offset: 0x00018B40
		[ExcludeFromDocs]
		public void Apply()
		{
			this.Apply(true, false);
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x0001A94C File Offset: 0x00018B4C
		private static void ValidateIsNotCrunched(TextureCreationFlags flags)
		{
			bool flag = (flags &= TextureCreationFlags.Crunch) > TextureCreationFlags.None;
			if (flag)
			{
				throw new ArgumentException("Crunched Cubemap is not supported for textures created from script.");
			}
		}

		// Token: 0x06001309 RID: 4873
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetPixelImpl_Injected(int image, int mip, int x, int y, ref Color color);

		// Token: 0x0600130A RID: 4874
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetPixelImpl_Injected(int image, int mip, int x, int y, out Color ret);
	}
}
