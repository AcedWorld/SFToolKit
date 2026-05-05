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
	// Token: 0x020001D3 RID: 467
	[ExcludeFromPreset]
	[NativeHeader("Runtime/Graphics/Texture2DArray.h")]
	public sealed class Texture2DArray : Texture
	{
		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x0600133B RID: 4923
		public static extern int allSlices { [NativeName("GetAllTextureLayersIdentifier")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x0600133C RID: 4924
		public extern int depth { [NativeName("GetTextureLayerCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x0600133D RID: 4925
		public extern TextureFormat format { [NativeName("GetTextureFormat")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x0600133E RID: 4926
		public override extern bool isReadable { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600133F RID: 4927
		[FreeFunction("Texture2DArrayScripting::Create")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_CreateImpl([Writable] Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags);

		// Token: 0x06001340 RID: 4928 RVA: 0x0001AF9C File Offset: 0x0001919C
		private static void Internal_Create([Writable] Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags)
		{
			bool flag = !Texture2DArray.Internal_CreateImpl(mono, w, h, d, mipCount, format, colorSpace, flags);
			if (flag)
			{
				throw new UnityException("Failed to create 2D array texture because of invalid parameters.");
			}
		}

		// Token: 0x06001341 RID: 4929
		[FreeFunction(Name = "Texture2DArrayScripting::Apply", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable);

		// Token: 0x06001342 RID: 4930
		[FreeFunction(Name = "Texture2DArrayScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Color[] GetPixels(int arrayElement, int miplevel);

		// Token: 0x06001343 RID: 4931 RVA: 0x0001AFD0 File Offset: 0x000191D0
		public Color[] GetPixels(int arrayElement)
		{
			return this.GetPixels(arrayElement, 0);
		}

		// Token: 0x06001344 RID: 4932
		[FreeFunction(Name = "Texture2DArrayScripting::SetPixelDataArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImplArray(Array data, int mipLevel, int element, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x06001345 RID: 4933
		[FreeFunction(Name = "Texture2DArrayScripting::SetPixelData", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool SetPixelDataImpl(IntPtr data, int mipLevel, int element, int elementSize, int dataArraySize, int sourceDataStartIndex = 0);

		// Token: 0x06001346 RID: 4934
		[FreeFunction(Name = "Texture2DArrayScripting::GetPixels32", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Color32[] GetPixels32(int arrayElement, int miplevel);

		// Token: 0x06001347 RID: 4935 RVA: 0x0001AFEC File Offset: 0x000191EC
		public Color32[] GetPixels32(int arrayElement)
		{
			return this.GetPixels32(arrayElement, 0);
		}

		// Token: 0x06001348 RID: 4936
		[FreeFunction(Name = "Texture2DArrayScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPixels([Unmarshalled] Color[] colors, int arrayElement, int miplevel);

		// Token: 0x06001349 RID: 4937 RVA: 0x0001B006 File Offset: 0x00019206
		public void SetPixels(Color[] colors, int arrayElement)
		{
			this.SetPixels(colors, arrayElement, 0);
		}

		// Token: 0x0600134A RID: 4938
		[FreeFunction(Name = "Texture2DArrayScripting::SetPixels32", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPixels32([Unmarshalled] Color32[] colors, int arrayElement, int miplevel);

		// Token: 0x0600134B RID: 4939 RVA: 0x0001B013 File Offset: 0x00019213
		public void SetPixels32(Color32[] colors, int arrayElement)
		{
			this.SetPixels32(colors, arrayElement, 0);
		}

		// Token: 0x0600134C RID: 4940
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetImageDataPointer();

		// Token: 0x0600134D RID: 4941 RVA: 0x0001B020 File Offset: 0x00019220
		internal bool ValidateFormat(TextureFormat format, int width, int height)
		{
			bool flag = base.ValidateFormat(format);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = TextureFormat.PVRTC_RGB2 <= format && format <= TextureFormat.PVRTC_RGBA4;
				bool flag4 = flag3 && (width != height || !Mathf.IsPowerOfTwo(width));
				if (flag4)
				{
					throw new UnityException(string.Format("'{0}' demands texture to be square and have power-of-two dimensions", format.ToString()));
				}
			}
			return flag;
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x0001B08C File Offset: 0x0001928C
		internal bool ValidateFormat(GraphicsFormat format, int width, int height)
		{
			bool flag = base.ValidateFormat(format, FormatUsage.Sample);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = GraphicsFormatUtility.IsPVRTCFormat(format);
				bool flag4 = flag3 && (width != height || !Mathf.IsPowerOfTwo(width));
				if (flag4)
				{
					throw new UnityException(string.Format("'{0}' demands texture to be square and have power-of-two dimensions", format.ToString()));
				}
			}
			return flag;
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0001B0EF File Offset: 0x000192EF
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags) : this(width, height, depth, SystemInfo.GetGraphicsFormat(format), flags)
		{
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0001B108 File Offset: 0x00019308
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags, int mipCount) : this(width, height, depth, SystemInfo.GetGraphicsFormat(format), flags)
		{
			GraphicsFormat graphicsFormat = SystemInfo.GetGraphicsFormat(format);
			bool flag = !this.ValidateFormat(graphicsFormat, width, height);
			if (!flag)
			{
				Texture2DArray.ValidateIsNotCrunched(flags);
				Texture2DArray.Internal_Create(this, width, height, depth, mipCount, graphicsFormat, base.GetTextureColorSpace(graphicsFormat), flags);
			}
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x0001B161 File Offset: 0x00019361
		[RequiredByNativeCode]
		public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags) : this(width, height, depth, format, flags, Texture.GenerateAllMips)
		{
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0001B178 File Offset: 0x00019378
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount)
		{
			bool flag = !this.ValidateFormat(format, width, height);
			if (!flag)
			{
				Texture2DArray.ValidateIsNotCrunched(flags);
				Texture2DArray.Internal_Create(this, width, height, depth, mipCount, format, base.GetTextureColorSpace(format), flags);
			}
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x0001B1C0 File Offset: 0x000193C0
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear, bool createUninitialized)
		{
			bool flag = !this.ValidateFormat(textureFormat, width, height);
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
				Texture2DArray.ValidateIsNotCrunched(textureCreationFlags);
				Texture2DArray.Internal_Create(this, width, height, depth, mipCount, graphicsFormat, base.GetTextureColorSpace(linear), textureCreationFlags);
			}
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x0001B23C File Offset: 0x0001943C
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear) : this(width, height, depth, textureFormat, mipCount, linear, false)
		{
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0001B250 File Offset: 0x00019450
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized) : this(width, height, depth, textureFormat, mipChain ? Texture.GenerateAllMips : 1, linear, createUninitialized)
		{
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x0001B26F File Offset: 0x0001946F
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool linear) : this(width, height, depth, textureFormat, mipChain ? Texture.GenerateAllMips : 1, linear)
		{
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0001B28C File Offset: 0x0001948C
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain) : this(width, height, depth, textureFormat, mipChain ? Texture.GenerateAllMips : 1, false)
		{
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x0001B2A8 File Offset: 0x000194A8
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable)
		{
			bool flag = !this.isReadable;
			if (flag)
			{
				throw base.CreateNonReadableException(this);
			}
			this.ApplyImpl(updateMipmaps, makeNoLongerReadable);
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x0001B2D4 File Offset: 0x000194D4
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps)
		{
			this.Apply(updateMipmaps, false);
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x0001B2E0 File Offset: 0x000194E0
		[ExcludeFromDocs]
		public void Apply()
		{
			this.Apply(true, false);
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x0001B2EC File Offset: 0x000194EC
		public void SetPixelData<T>(T[] data, int mipLevel, int element, [DefaultValue("0")] int sourceDataStartIndex = 0)
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
			this.SetPixelDataImplArray(data, mipLevel, element, Marshal.SizeOf<T>(data[0]), data.Length, sourceDataStartIndex);
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x0001B358 File Offset: 0x00019558
		public void SetPixelData<T>(NativeArray<T> data, int mipLevel, int element, [DefaultValue("0")] int sourceDataStartIndex = 0) where T : struct
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
			this.SetPixelDataImpl((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), mipLevel, element, UnsafeUtility.SizeOf<T>(), data.Length, sourceDataStartIndex);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x0001B3D8 File Offset: 0x000195D8
		public unsafe NativeArray<T> GetPixelData<T>(int mipLevel, int element) where T : struct
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
			bool flag3 = element < 0 || element >= this.depth;
			if (flag3)
			{
				throw new ArgumentException("The passed in element " + element.ToString() + " is invalid. The valid range is 0 through " + (this.depth - 1).ToString());
			}
			ulong pixelDataOffset = base.GetPixelDataOffset(base.mipmapCount, element);
			ulong pixelDataOffset2 = base.GetPixelDataOffset(mipLevel, element);
			ulong pixelDataSize = base.GetPixelDataSize(mipLevel, element);
			int num = UnsafeUtility.SizeOf<T>();
			ulong num2 = pixelDataSize / (ulong)((long)num);
			bool flag4 = num2 > 2147483647UL;
			if (flag4)
			{
				throw base.CreateNativeArrayLengthOverflowException();
			}
			IntPtr value = new IntPtr((long)this.GetImageDataPointer() + (long)(pixelDataOffset * (ulong)((long)element) + pixelDataOffset2));
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)value, (int)num2, Allocator.None);
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x0001B500 File Offset: 0x00019700
		private static void ValidateIsNotCrunched(TextureCreationFlags flags)
		{
			bool flag = (flags &= TextureCreationFlags.Crunch) > TextureCreationFlags.None;
			if (flag)
			{
				throw new ArgumentException("Crunched Texture2DArray is not supported.");
			}
		}
	}
}
