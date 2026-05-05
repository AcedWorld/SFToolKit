using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001CE RID: 462
	[NativeHeader("Runtime/Streaming/TextureStreamingManager.h")]
	[NativeHeader("Runtime/Graphics/Texture.h")]
	[UsedByNativeCode]
	public class Texture : Object
	{
		// Token: 0x06001218 RID: 4632 RVA: 0x0001117A File Offset: 0x0000F37A
		protected Texture()
		{
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06001219 RID: 4633
		// (set) Token: 0x0600121A RID: 4634
		[Obsolete("masterTextureLimit has been deprecated. Use globalMipmapLimit instead (UnityUpgradable) -> globalMipmapLimit", false)]
		[NativeProperty("ActiveGlobalMipmapLimit")]
		public static extern int masterTextureLimit { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x0600121B RID: 4635
		// (set) Token: 0x0600121C RID: 4636
		[Obsolete("globalMipmapLimit is not supported. Use QualitySettings.globalTextureMipmapLimit or Mipmap Limit Groups instead.", false)]
		[NativeProperty("ActiveGlobalMipmapLimit")]
		public static extern int globalMipmapLimit { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x0600121D RID: 4637
		public extern int mipmapCount { [NativeName("GetMipmapCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x0600121E RID: 4638
		// (set) Token: 0x0600121F RID: 4639
		[NativeProperty("AnisoLimit")]
		public static extern AnisotropicFiltering anisotropicFiltering { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001220 RID: 4640
		[NativeName("SetGlobalAnisoLimits")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetGlobalAnisotropicFilteringLimits(int forcedMin, int globalMax);

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001221 RID: 4641 RVA: 0x000193DC File Offset: 0x000175DC
		public virtual GraphicsFormat graphicsFormat
		{
			get
			{
				return GraphicsFormatUtility.GetFormat(this);
			}
		}

		// Token: 0x06001222 RID: 4642
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetDataWidth();

		// Token: 0x06001223 RID: 4643
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetDataHeight();

		// Token: 0x06001224 RID: 4644
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern TextureDimension GetDimension();

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06001225 RID: 4645 RVA: 0x000193F4 File Offset: 0x000175F4
		// (set) Token: 0x06001226 RID: 4646 RVA: 0x0001940C File Offset: 0x0001760C
		public virtual int width
		{
			get
			{
				return this.GetDataWidth();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x00019414 File Offset: 0x00017614
		// (set) Token: 0x06001228 RID: 4648 RVA: 0x0001940C File Offset: 0x0001760C
		public virtual int height
		{
			get
			{
				return this.GetDataHeight();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06001229 RID: 4649 RVA: 0x0001942C File Offset: 0x0001762C
		// (set) Token: 0x0600122A RID: 4650 RVA: 0x0001940C File Offset: 0x0001760C
		public virtual TextureDimension dimension
		{
			get
			{
				return this.GetDimension();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600122B RID: 4651
		internal extern bool isNativeTexture { [NativeName("IsNativeTexture")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x0600122C RID: 4652
		public virtual extern bool isReadable { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x0600122D RID: 4653
		// (set) Token: 0x0600122E RID: 4654
		public extern TextureWrapMode wrapMode { [NativeName("GetWrapModeU")] [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x0600122F RID: 4655
		// (set) Token: 0x06001230 RID: 4656
		public extern TextureWrapMode wrapModeU { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06001231 RID: 4657
		// (set) Token: 0x06001232 RID: 4658
		public extern TextureWrapMode wrapModeV { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001233 RID: 4659
		// (set) Token: 0x06001234 RID: 4660
		public extern TextureWrapMode wrapModeW { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001235 RID: 4661
		// (set) Token: 0x06001236 RID: 4662
		public extern FilterMode filterMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001237 RID: 4663
		// (set) Token: 0x06001238 RID: 4664
		public extern int anisoLevel { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001239 RID: 4665
		// (set) Token: 0x0600123A RID: 4666
		public extern float mipMapBias { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x00019444 File Offset: 0x00017644
		public Vector2 texelSize
		{
			[NativeName("GetTexelSize")]
			get
			{
				Vector2 result;
				this.get_texelSize_Injected(out result);
				return result;
			}
		}

		// Token: 0x0600123C RID: 4668
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetNativeTexturePtr();

		// Token: 0x0600123D RID: 4669 RVA: 0x0001945C File Offset: 0x0001765C
		[Obsolete("Use GetNativeTexturePtr instead.", false)]
		public int GetNativeTextureID()
		{
			return (int)this.GetNativeTexturePtr();
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600123E RID: 4670
		public extern uint updateCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600123F RID: 4671
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void IncrementUpdateCount();

		// Token: 0x06001240 RID: 4672
		[NativeMethod("GetActiveTextureColorSpace")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int Internal_GetActiveTextureColorSpace();

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06001241 RID: 4673 RVA: 0x0001947C File Offset: 0x0001767C
		internal ColorSpace activeTextureColorSpace
		{
			[VisibleToOtherModules(new string[]
			{
				"UnityEngine.UIElementsModule",
				"Unity.UIElements"
			})]
			get
			{
				return (this.Internal_GetActiveTextureColorSpace() == 0) ? ColorSpace.Linear : ColorSpace.Gamma;
			}
		}

		// Token: 0x06001242 RID: 4674
		[NativeMethod("GetStoredColorSpace")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern TextureColorSpace Internal_GetStoredColorSpace();

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06001243 RID: 4675 RVA: 0x0001949C File Offset: 0x0001769C
		public bool isDataSRGB
		{
			get
			{
				return this.Internal_GetStoredColorSpace() == TextureColorSpace.sRGB;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001244 RID: 4676
		public static extern ulong totalTextureMemory { [FreeFunction("GetTextureStreamingManager().GetTotalTextureMemory")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06001245 RID: 4677
		public static extern ulong desiredTextureMemory { [FreeFunction("GetTextureStreamingManager().GetDesiredTextureMemory")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06001246 RID: 4678
		public static extern ulong targetTextureMemory { [FreeFunction("GetTextureStreamingManager().GetTargetTextureMemory")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06001247 RID: 4679
		public static extern ulong currentTextureMemory { [FreeFunction("GetTextureStreamingManager().GetCurrentTextureMemory")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06001248 RID: 4680
		public static extern ulong nonStreamingTextureMemory { [FreeFunction("GetTextureStreamingManager().GetNonStreamingTextureMemory")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06001249 RID: 4681
		public static extern ulong streamingMipmapUploadCount { [FreeFunction("GetTextureStreamingManager().GetStreamingMipmapUploadCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600124A RID: 4682
		public static extern ulong streamingRendererCount { [FreeFunction("GetTextureStreamingManager().GetStreamingRendererCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600124B RID: 4683
		public static extern ulong streamingTextureCount { [FreeFunction("GetTextureStreamingManager().GetStreamingTextureCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x0600124C RID: 4684
		public static extern ulong nonStreamingTextureCount { [FreeFunction("GetTextureStreamingManager().GetNonStreamingTextureCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x0600124D RID: 4685
		public static extern ulong streamingTexturePendingLoadCount { [FreeFunction("GetTextureStreamingManager().GetStreamingTexturePendingLoadCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x0600124E RID: 4686
		public static extern ulong streamingTextureLoadingCount { [FreeFunction("GetTextureStreamingManager().GetStreamingTextureLoadingCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600124F RID: 4687
		[FreeFunction("GetTextureStreamingManager().SetStreamingTextureMaterialDebugProperties")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStreamingTextureMaterialDebugProperties();

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06001250 RID: 4688
		// (set) Token: 0x06001251 RID: 4689
		public static extern bool streamingTextureForceLoadAll { [FreeFunction(Name = "GetTextureStreamingManager().GetForceLoadAll")] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetForceLoadAll")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06001252 RID: 4690
		// (set) Token: 0x06001253 RID: 4691
		public static extern bool streamingTextureDiscardUnusedMips { [FreeFunction(Name = "GetTextureStreamingManager().GetDiscardUnusedMips")] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetDiscardUnusedMips")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06001254 RID: 4692
		// (set) Token: 0x06001255 RID: 4693
		public static extern bool allowThreadedTextureCreation { [FreeFunction(Name = "Texture2DScripting::IsCreateTextureThreadedEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "Texture2DScripting::EnableCreateTextureThreaded")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001256 RID: 4694
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern ulong GetPixelDataSize(int mipLevel, int element = 0);

		// Token: 0x06001257 RID: 4695
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern ulong GetPixelDataOffset(int mipLevel, int element = 0);

		// Token: 0x06001258 RID: 4696 RVA: 0x000194B8 File Offset: 0x000176B8
		internal TextureColorSpace GetTextureColorSpace(bool linear)
		{
			return linear ? TextureColorSpace.Linear : TextureColorSpace.sRGB;
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x000194D4 File Offset: 0x000176D4
		internal TextureColorSpace GetTextureColorSpace(GraphicsFormat format)
		{
			return this.GetTextureColorSpace(!GraphicsFormatUtility.IsSRGBFormat(format));
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x000194F8 File Offset: 0x000176F8
		internal bool ValidateFormat(RenderTextureFormat format)
		{
			bool flag = SystemInfo.SupportsRenderTextureFormat(format);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Debug.LogError(string.Format("RenderTexture creation failed. '{0}' is not supported on this platform. Use 'SystemInfo.SupportsRenderTextureFormat' C# API to check format support.", format.ToString()), this);
				result = false;
			}
			return result;
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x0001953C File Offset: 0x0001773C
		internal bool ValidateFormat(TextureFormat format)
		{
			bool flag = SystemInfo.SupportsTextureFormat(format);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = GraphicsFormatUtility.IsCompressedFormat(format) && GraphicsFormatUtility.CanDecompressFormat(GraphicsFormatUtility.GetGraphicsFormat(format, false));
				if (flag2)
				{
					Debug.LogWarning(string.Format("'{0}' is not supported on this platform. Decompressing texture. Use 'SystemInfo.SupportsTextureFormat' C# API to check format support.", format.ToString()), this);
					result = true;
				}
				else
				{
					Debug.LogError(string.Format("Texture creation failed. '{0}' is not supported on this platform. Use 'SystemInfo.SupportsTextureFormat' C# API to check format support.", format.ToString()), this);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000195BC File Offset: 0x000177BC
		internal bool ValidateFormat(GraphicsFormat format, FormatUsage usage)
		{
			bool flag = usage != FormatUsage.Render && (format == GraphicsFormat.ShadowAuto || format == GraphicsFormat.DepthAuto);
			bool result;
			if (flag)
			{
				Debug.LogWarning(string.Format("'{0}' is not allowed because it is an auto format and not an exact format. Use GraphicsFormatUtility.GetDepthStencilFormat to get an exact depth/stencil format.", format.ToString()), this);
				result = false;
			}
			else
			{
				bool flag2 = SystemInfo.IsFormatSupported(format, usage);
				if (flag2)
				{
					result = true;
				}
				else
				{
					Debug.LogError(string.Format("Texture creation failed. '{0}' is not supported for {1} usage on this platform. Use 'SystemInfo.IsFormatSupported' C# API to check format support.", format.ToString(), usage.ToString()), this);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x0001964C File Offset: 0x0001784C
		internal UnityException CreateNonReadableException(Texture t)
		{
			return new UnityException(string.Format("Texture '{0}' is not readable, the texture memory can not be accessed from scripts. You can make the texture readable in the Texture Import Settings.", t.name));
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00019674 File Offset: 0x00017874
		internal UnityException CreateNativeArrayLengthOverflowException()
		{
			return new UnityException("Failed to create NativeArray, length exceeds the allowed maximum of Int32.MaxValue. Use a larger type as template argument to reduce the array length.");
		}

		// Token: 0x06001260 RID: 4704
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_texelSize_Injected(out Vector2 ret);

		// Token: 0x04000654 RID: 1620
		public static readonly int GenerateAllMips = -1;
	}
}
