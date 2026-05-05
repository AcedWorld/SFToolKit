using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000151 RID: 337
	[NativeHeader("Runtime/Graphics/LightmapSettings.h")]
	[StaticAccessor("GetLightmapSettings()")]
	public sealed class LightmapSettings : Object
	{
		// Token: 0x06000A85 RID: 2693 RVA: 0x0001117A File Offset: 0x0000F37A
		private LightmapSettings()
		{
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000A86 RID: 2694
		// (set) Token: 0x06000A87 RID: 2695
		public static extern LightmapData[] lightmaps { [FreeFunction] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(ThrowsException = true)] [MethodImpl(MethodImplOptions.InternalCall)] [param: Unmarshalled] set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000A88 RID: 2696
		// (set) Token: 0x06000A89 RID: 2697
		public static extern LightmapsMode lightmapsMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(ThrowsException = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000A8A RID: 2698
		// (set) Token: 0x06000A8B RID: 2699
		public static extern LightProbes lightProbes { [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetLightProbes")] [FreeFunction] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000A8C RID: 2700
		[NativeName("ResetAndAwakeFromLoad")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Reset();

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00011184 File Offset: 0x0000F384
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("Use lightmapsMode instead.", false)]
		public static LightmapsModeLegacy lightmapsModeLegacy
		{
			get
			{
				return LightmapsModeLegacy.Single;
			}
			set
			{
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00011198 File Offset: 0x0000F398
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("Use QualitySettings.desiredColorSpace instead.", false)]
		public static ColorSpace bakedColorSpace
		{
			get
			{
				return QualitySettings.desiredColorSpace;
			}
			set
			{
			}
		}
	}
}
