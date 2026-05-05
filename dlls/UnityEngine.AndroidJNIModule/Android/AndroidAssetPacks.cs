using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Android
{
	// Token: 0x0200001A RID: 26
	[NativeHeader("Modules/AndroidJNI/Public/AndroidAssetPacksBindingsHelpers.h")]
	[StaticAccessor("AndroidAssetPacksBindingsHelpers", StaticAccessorType.DoubleColon)]
	public static class AndroidAssetPacks
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00009C6C File Offset: 0x00007E6C
		public static bool coreUnityAssetPacksDownloaded
		{
			get
			{
				return AndroidAssetPacks.CoreUnityAssetPacksDownloaded();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00009C84 File Offset: 0x00007E84
		internal static string dataPackName
		{
			get
			{
				return AndroidAssetPacks.GetDataPackName();
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00009C9C File Offset: 0x00007E9C
		internal static string streamingAssetsPackName
		{
			get
			{
				return AndroidAssetPacks.GetStreamingAssetsPackName();
			}
		}

		// Token: 0x0600023F RID: 575
		[NativeConditional("PLATFORM_ANDROID")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CoreUnityAssetPacksDownloaded();

		// Token: 0x06000240 RID: 576 RVA: 0x00009CB4 File Offset: 0x00007EB4
		public static string[] GetCoreUnityAssetPackNames()
		{
			return new string[0];
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00009CCC File Offset: 0x00007ECC
		public static void GetAssetPackStateAsync(string[] assetPackNames, Action<ulong, AndroidAssetPackState[]> callback)
		{
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009CD0 File Offset: 0x00007ED0
		public static GetAssetPackStateAsyncOperation GetAssetPackStateAsync(string[] assetPackNames)
		{
			return null;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009CCC File Offset: 0x00007ECC
		public static void DownloadAssetPackAsync(string[] assetPackNames, Action<AndroidAssetPackInfo> callback)
		{
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00009CE4 File Offset: 0x00007EE4
		public static DownloadAssetPackAsyncOperation DownloadAssetPackAsync(string[] assetPackNames)
		{
			return null;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00009CCC File Offset: 0x00007ECC
		public static void RequestToUseMobileDataAsync(Action<AndroidAssetPackUseMobileDataRequestResult> callback)
		{
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00009CF8 File Offset: 0x00007EF8
		public static RequestToUseMobileDataAsyncOperation RequestToUseMobileDataAsync()
		{
			return null;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00009D0C File Offset: 0x00007F0C
		public static string GetAssetPackPath(string assetPackName)
		{
			return "";
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00009CCC File Offset: 0x00007ECC
		public static void CancelAssetPackDownload(string[] assetPackNames)
		{
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00009CCC File Offset: 0x00007ECC
		public static void RemoveAssetPack(string assetPackName)
		{
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00009D24 File Offset: 0x00007F24
		private static string GetDataPackName()
		{
			return "UnityDataAssetPack";
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009D3C File Offset: 0x00007F3C
		private static string GetStreamingAssetsPackName()
		{
			return "UnityStreamingAssetsPack";
		}
	}
}
