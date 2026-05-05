using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000003 RID: 3
	[NativeHeader("Modules/UnityConnect/UnityAds/UnityAdsSettings.h")]
	internal static class UnityAdsSettings
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14
		// (set) Token: 0x0600000F RID: 15
		[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
		public static extern bool enabled { [ThreadSafe] [MethodImpl(MethodImplOptions.InternalCall)] get; [ThreadSafe] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000010 RID: 16 RVA: 0x0000205C File Offset: 0x0000025C
		[Obsolete("warning No longer supported and will always return true")]
		public static bool IsPlatformEnabled(RuntimePlatform platform)
		{
			return true;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000206F File Offset: 0x0000026F
		[Obsolete("warning No longer supported and will do nothing")]
		public static void SetPlatformEnabled(RuntimePlatform platform, bool value)
		{
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000012 RID: 18
		// (set) Token: 0x06000013 RID: 19
		[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
		public static extern bool initializeOnStartup { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20
		// (set) Token: 0x06000015 RID: 21
		[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
		public static extern bool testMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000016 RID: 22
		[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetGameId(RuntimePlatform platform);

		// Token: 0x06000017 RID: 23
		[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetGameId(RuntimePlatform platform, string gameId);
	}
}
