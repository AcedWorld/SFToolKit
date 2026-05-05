using System;
using System.Diagnostics;
using Rewired;

// Token: 0x02000294 RID: 660
internal static class gGcDZEDshQiaoZVVzsgdkNxpPeIv
{
	// Token: 0x060013BF RID: 5055 RVA: 0x0001B5AA File Offset: 0x000197AA
	[Conditional("STEAM_DEBUG")]
	public static void YqZdhGGGSRdBcEkSkHbcvFnMxiOYA(object A_0)
	{
		if (A_0 == null)
		{
			A_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + ((A_0 != null) ? A_0.ToString() : null));
	}

	// Token: 0x060013C0 RID: 5056 RVA: 0x0001B5D1 File Offset: 0x000197D1
	[Conditional("STEAM_DEBUG")]
	public static void PAoKoYbANutEwuxynYyKMcxIqAVi(object A_0)
	{
		if (A_0 == null)
		{
			A_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + ((A_0 != null) ? A_0.ToString() : null));
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x0001B5F8 File Offset: 0x000197F8
	[Conditional("STEAM_DEBUG")]
	public static void CTsXkyKrsQuqxbkoWBVWsMbjqWZf(object A_0)
	{
		if (A_0 == null)
		{
			A_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + ((A_0 != null) ? A_0.ToString() : null));
	}
}
