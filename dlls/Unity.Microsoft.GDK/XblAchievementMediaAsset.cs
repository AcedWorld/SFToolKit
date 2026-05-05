using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000062 RID: 98
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementMediaAsset
	{
		// Token: 0x06000419 RID: 1049 RVA: 0x000097E8 File Offset: 0x000079E8
		internal XblAchievementMediaAsset(XblAchievementMediaAsset mediaAsset)
		{
			this.Name = mediaAsset.name.GetString();
			this.MediaAssetType = mediaAsset.mediaAssetType;
			this.Url = mediaAsset.url.GetString();
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000982F File Offset: 0x00007A2F
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x00009837 File Offset: 0x00007A37
		public string Name { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00009840 File Offset: 0x00007A40
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x00009848 File Offset: 0x00007A48
		public XblAchievementMediaAssetType MediaAssetType { get; private set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00009851 File Offset: 0x00007A51
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00009859 File Offset: 0x00007A59
		public string Url { get; private set; }
	}
}
