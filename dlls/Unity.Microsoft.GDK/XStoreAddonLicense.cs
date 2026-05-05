using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000180 RID: 384
	[MovedFrom("Unity.GameCore")]
	public class XStoreAddonLicense
	{
		// Token: 0x06000958 RID: 2392 RVA: 0x0000EB35 File Offset: 0x0000CD35
		internal XStoreAddonLicense(XStoreAddonLicense interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0000EB44 File Offset: 0x0000CD44
		public XStoreAddonLicense()
		{
			this.interop = default(XStoreAddonLicense);
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x0000EB58 File Offset: 0x0000CD58
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x0000EB65 File Offset: 0x0000CD65
		public string SkuStoreId
		{
			get
			{
				return this.interop.skuStoreId;
			}
			set
			{
				this.interop.skuStoreId = value;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x0000EB73 File Offset: 0x0000CD73
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x0000EB80 File Offset: 0x0000CD80
		public string InAppOfferToken
		{
			get
			{
				return this.interop.inAppOfferToken;
			}
			set
			{
				this.interop.inAppOfferToken = value;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x0000EB8E File Offset: 0x0000CD8E
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x0000EB9B File Offset: 0x0000CD9B
		public bool IsActive
		{
			get
			{
				return this.interop.isActive;
			}
			set
			{
				this.interop.isActive = value;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x0000EBA9 File Offset: 0x0000CDA9
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x0000EBB6 File Offset: 0x0000CDB6
		public long ExpirationDate
		{
			get
			{
				return this.interop.expirationDate;
			}
			set
			{
				this.interop.expirationDate = value;
			}
		}

		// Token: 0x04000551 RID: 1361
		internal XStoreAddonLicense interop;
	}
}
