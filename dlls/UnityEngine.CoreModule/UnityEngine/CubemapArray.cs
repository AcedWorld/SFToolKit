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
	// Token: 0x020001D4 RID: 468
	[ExcludeFromPreset]
	[NativeHeader("Runtime/Graphics/CubemapArrayTexture.h")]
	public sealed class CubemapArray : Texture
	{
		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x0600135F RID: 4959
		public extern int cubemapCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06001360 RID: 4960
		public extern TextureFormat format { [NativeName("GetTextureFormat")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06001361 RID: 4961
		public override extern bool isReadable { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001362 RID: 4962
		[FreeFunction("CubemapArrayScripting::Create")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_CreateImpl([Writable] CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags);

		// Token: 0x06001363 RID: 4963 RVA: 0x0001B528 File Offset: 0x00019728
		private static void Internal_Create([Writable] CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags)
		{
			bool flag = !CubemapArray.Internal_CreateImpl(mono, ext, count, mipCount, format, colorSpace, flags);
			if (flag)
			{
				throw new UnityException("Failed to create cubemap array texture because of invalid parameters.");
			}
		}

		// Token: 0x06001364 RID: 4964
		[FreeFunction(Name = "CubemapArrayScripting::Apply", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable);

		// Token: 0x06001365 RID: 4965
		[FreeFunction(Name = "CubemapArrayScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Color[] GetPixels(CubemapFace face, int arrayElement, int miplevel);

		// Token: 0x06001366 RID: 4966 RVA: 0x0001B558 File Offset: 0x00019758
		public Color[] GetPixels(CubemapFace face, int arrayElement)
		{
			return this.GetPixels(face, arrayElement, 0);
		}

		// Token: 0x06001367 RID: 4967
		[FreeFunction(Name = "CubemapArrayScripting::GetPixels32", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Color32[] GetPixels32(CubemapFace face, int arrayElement, int miplevel);

		// Token: 0x06001368 RID: 4968 RVA: 0x0001B574 File Offset: 0x00019774
		public Color32[] GetPixels32(CubemapFace face, int arrayElement)
		{
			return this.GetPixels32(face, arrayElement, 0);
		}

		// Token: 0x06001369 RID: 4969
		[FreeFunction(Name = "CubemapArrayScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPixels([Unmarshalled] Color[] colors, CubemapFace face, int arrayElement, int miplevel);

		// Token: 0x0600136A RID: 4970 RVA: 0x0001B58F File Offset: 0x0001978F
		public void SetPixels(Color[] colors, CubemapFace face, int arrayElement)
		{
			this.SetPixels(colors, face, arrayElement, 0);
		}

		// Token: 0x0600136B RID: 4971
		[FreeFunction(Name = "CubemapArrayScripting::SetPixels32", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPixels32([Unmarshalled] Color32[] colors, CubemapFace face, int arrayElement, int miplevel);

		// Token: 0x0600136C RID: 4972 RVA: 0x0001B59D File Offset: 0x0001979D
		public void SetPixels32(Color32[] colors, CubemapFace face, int arrayElement)
		{
			this.SetPixels32(colors, face, arrayElement, 0);
		}

		// Token: 0x0600136D RID: 4973
		[FreeFunction(Name = "CubemapArrayScripting::SetPixelDataArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImplArray(Array data, int mipLevel, int face, int element, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x0600136E RID: 4974
		[FreeFunction(Name = "CubemapArrayScripting::SetPixelData", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImpl(IntPtr data, int mipLevel, int face, int element, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x0600136F RID: 4975
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetImageDataPointer();

		// Token: 0x06001370 RID: 4976 RVA: 0x0001B5AB File Offset: 0x000197AB
		[ExcludeFromDocs]
		public CubemapArray(int width, int cubemapCount, DefaultFormat format, TextureCreationFlags flags) : this(width, cubemapCount, SystemInfo.GetGraphicsFormat(format), flags)
		{
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0001B5BF File Offset: 0x000197BF
		[ExcludeFromDocs]
		public CubemapArray(int width, int cubemapCount, DefaultFormat format, TextureCreationFlags flags, [DefaultValue("Texture.GenerateAllMips")] int mipCount) : this(width, cubemapCount, SystemInfo.GetGraphicsFormat(format), flags, mipCount)
		{
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0001B5D5 File Offset: 0x000197D5
		[RequiredByNativeCode]
		public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags) : this(width, cubemapCount, format, flags, Texture.GenerateAllMips)
		{
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0001B5EC File Offset: 0x000197EC
		[ExcludeFromDocs]
		public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags, [DefaultValue("Texture.GenerateAllMips")] int mipCount)
		{
			bool flag = !base.ValidateFormat(format, FormatUsage.Sample);
			if (!flag)
			{
				CubemapArray.ValidateIsNotCrunched(flags);
				CubemapArray.Internal_Create(this, width, cubemapCount, mipCount, format, base.GetTextureColorSpace(format), flags);
			}
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0001B630 File Offset: 0x00019830
		public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, int mipCount, bool linear, [DefaultValue("false")] bool createUninitialized)
		{
			bool flag = !base.ValidateFormat(textureFormat);
			if (!flag)
			{
				GraphicsFormat graphicsFormat = GraphicsFormatUtility.GetGraphicsFormat(textureFormat, !linear);
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
				CubemapArray.ValidateIsNotCrunched(textureCreationFlags);
				CubemapArray.Internal_Create(this, width, cubemapCount, mipCount, graphicsFormat, base.GetTextureColorSpace(linear), textureCreationFlags);
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0001B6A6 File Offset: 0x000198A6
		public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, int mipCount, bool linear) : this(width, cubemapCount, textureFormat, mipCount, linear, false)
		{
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x0001B6B8 File Offset: 0x000198B8
		public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized) : this(width, cubemapCount, textureFormat, mipChain ? Texture.GenerateAllMips : 1, linear, createUninitialized)
		{
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0001B6D5 File Offset: 0x000198D5
		[ExcludeFromDocs]
		public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool linear) : this(width, cubemapCount, textureFormat, mipChain ? Texture.GenerateAllMips : 1, linear)
		{
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0001B6F0 File Offset: 0x000198F0
		public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain) : this(width, cubemapCount, textureFormat, mipChain ? Texture.GenerateAllMips : 1, false)
		{
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0001B70C File Offset: 0x0001990C
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable)
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			this.ApplyImpl(updateMipmaps, makeNoLongerReadable);
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x0001B738 File Offset: 0x00019938
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps)
		{
			this.Apply(updateMipmaps, false);
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0001B744 File Offset: 0x00019944
		[ExcludeFromDocs]
		public void Apply()
		{
			this.Apply(true, false);
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0001B750 File Offset: 0x00019950
		public void SetPixelData<T>(T[] data, int mipLevel, CubemapFace face, int element, [DefaultValue("0")] int sourceDataStartIndex = 0)
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
			this.SetPixelDataImplArray(data, mipLevel, (int)face, element, Marshal.SizeOf<T>(data[0]), data.Length, sourceDataStartIndex);
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x0001B7C0 File Offset: 0x000199C0
		public void SetPixelData<T>(NativeArray<T> data, int mipLevel, CubemapFace face, int element, [DefaultValue("0")] int sourceDataStartIndex = 0) where T : struct
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
			this.SetPixelDataImpl((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), mipLevel, (int)face, element, UnsafeUtility.SizeOf<T>(), data.Length, sourceDataStartIndex);
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x0001B840 File Offset: 0x00019A40
		public unsafe NativeArray<T> GetPixelData<T>(int mipLevel, CubemapFace face, int element) where T : struct
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
				throw new ArgumentException("The passed in face " + face.ToString() + " is invalid.  The valid range is 0 through 5");
			}
			bool flag4 = element < 0 || element >= this.cubemapCount;
			if (flag4)
			{
				throw new ArgumentException("The passed in element " + element.ToString() + " is invalid. The valid range is 0 through " + (this.cubemapCount - 1).ToString());
			}
			int num = (int)(element * 6 + face);
			ulong pixelDataOffset = base.GetPixelDataOffset(base.mipmapCount, num);
			ulong pixelDataOffset2 = base.GetPixelDataOffset(mipLevel, num);
			ulong pixelDataSize = base.GetPixelDataSize(mipLevel, num);
			int num2 = UnsafeUtility.SizeOf<T>();
			ulong num3 = pixelDataSize / (ulong)((long)num2);
			bool flag5 = num3 > 2147483647UL;
			if (flag5)
			{
				throw base.CreateNativeArrayLengthOverflowException();
			}
			IntPtr value = new IntPtr((long)this.GetImageDataPointer() + (long)(pixelDataOffset * (ulong)((long)num) + pixelDataOffset2));
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)value, (int)num3, Allocator.None);
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x0001B9A8 File Offset: 0x00019BA8
		private static void ValidateIsNotCrunched(TextureCreationFlags flags)
		{
			bool flag = (flags &= TextureCreationFlags.Crunch) > TextureCreationFlags.None;
			if (flag)
			{
				throw new ArgumentException("Crunched TextureCubeArray is not supported.");
			}
		}
	}
}
