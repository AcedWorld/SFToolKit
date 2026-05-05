using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000EF RID: 239
	[MovedFrom("Unity.GameCore")]
	public class XblSocialRelationship
	{
		// Token: 0x0600065B RID: 1627 RVA: 0x0000BD8E File Offset: 0x00009F8E
		internal XblSocialRelationship(XblSocialRelationship interopHandle)
		{
			this.XboxUserId = interopHandle.xboxUserId;
			this.IsFavourite = interopHandle.isFavorite;
			this.IsFollowingCaller = interopHandle.isFollowingCaller;
			this.SocialNetworks = interopHandle.GetSocialNetworks();
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x0000BDC7 File Offset: 0x00009FC7
		public ulong XboxUserId { get; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0000BDCF File Offset: 0x00009FCF
		public bool IsFavourite { get; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0000BDD7 File Offset: 0x00009FD7
		public bool IsFollowingCaller { get; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x0000BDDF File Offset: 0x00009FDF
		public string[] SocialNetworks { get; }
	}
}
