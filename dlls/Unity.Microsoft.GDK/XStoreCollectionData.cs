using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000178 RID: 376
	[MovedFrom("Unity.GameCore")]
	public class XStoreCollectionData
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x0000E44E File Offset: 0x0000C64E
		internal XStoreCollectionData(XStoreCollectionData interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0000E45D File Offset: 0x0000C65D
		public XStoreCollectionData()
		{
			this.interop = default(XStoreCollectionData);
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x0000E471 File Offset: 0x0000C671
		// (set) Token: 0x06000906 RID: 2310 RVA: 0x0000E47E File Offset: 0x0000C67E
		public long AcquiredDate
		{
			get
			{
				return this.interop.acquiredDate;
			}
			set
			{
				this.interop.acquiredDate = value;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x0000E48C File Offset: 0x0000C68C
		// (set) Token: 0x06000908 RID: 2312 RVA: 0x0000E499 File Offset: 0x0000C699
		public long StartDate
		{
			get
			{
				return this.interop.startDate;
			}
			set
			{
				this.interop.startDate = value;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0000E4A7 File Offset: 0x0000C6A7
		// (set) Token: 0x0600090A RID: 2314 RVA: 0x0000E4B4 File Offset: 0x0000C6B4
		public long EndDate
		{
			get
			{
				return this.interop.endDate;
			}
			set
			{
				this.interop.endDate = value;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x0000E4C2 File Offset: 0x0000C6C2
		// (set) Token: 0x0600090C RID: 2316 RVA: 0x0000E4CF File Offset: 0x0000C6CF
		public bool IsTrial
		{
			get
			{
				return this.interop.isTrial;
			}
			set
			{
				this.interop.isTrial = value;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0000E4DD File Offset: 0x0000C6DD
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x0000E4EA File Offset: 0x0000C6EA
		public uint TrialTimeRemainingInSeconds
		{
			get
			{
				return this.interop.trialTimeRemainingInSeconds;
			}
			set
			{
				this.interop.trialTimeRemainingInSeconds = value;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0000E4F8 File Offset: 0x0000C6F8
		// (set) Token: 0x06000910 RID: 2320 RVA: 0x0000E505 File Offset: 0x0000C705
		public uint Quantity
		{
			get
			{
				return this.interop.quantity;
			}
			set
			{
				this.interop.quantity = value;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0000E513 File Offset: 0x0000C713
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x0000E520 File Offset: 0x0000C720
		public string CampaignId
		{
			get
			{
				return this.interop.campaignId;
			}
			set
			{
				this.interop.campaignId = value;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x0000E52E File Offset: 0x0000C72E
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x0000E53B File Offset: 0x0000C73B
		public string DeveloperOfferId
		{
			get
			{
				return this.interop.developerOfferId;
			}
			set
			{
				this.interop.developerOfferId = value;
			}
		}

		// Token: 0x04000531 RID: 1329
		internal XStoreCollectionData interop;
	}
}
