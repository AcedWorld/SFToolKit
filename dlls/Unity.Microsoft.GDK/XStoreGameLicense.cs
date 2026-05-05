using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000183 RID: 387
	[MovedFrom("Unity.GameCore")]
	public class XStoreGameLicense
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x0000EC5B File Offset: 0x0000CE5B
		internal XStoreGameLicense(XStoreGameLicense interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0000EC6A File Offset: 0x0000CE6A
		public XStoreGameLicense()
		{
			this.interop = default(XStoreGameLicense);
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0000EC7E File Offset: 0x0000CE7E
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x0000EC8B File Offset: 0x0000CE8B
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

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x0000EC99 File Offset: 0x0000CE99
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x0000ECA6 File Offset: 0x0000CEA6
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

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x0000ECC1 File Offset: 0x0000CEC1
		public bool IsTrialOwnedByThisUser
		{
			get
			{
				return this.interop.isTrialOwnedByThisUser;
			}
			set
			{
				this.interop.isTrialOwnedByThisUser = value;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0000ECCF File Offset: 0x0000CECF
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x0000ECDC File Offset: 0x0000CEDC
		public bool IsDiscLicense
		{
			get
			{
				return this.interop.isDiscLicense;
			}
			set
			{
				this.interop.isDiscLicense = value;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0000ECEA File Offset: 0x0000CEEA
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x0000ECF7 File Offset: 0x0000CEF7
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

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x0000ED05 File Offset: 0x0000CF05
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x0000ED12 File Offset: 0x0000CF12
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

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0000ED20 File Offset: 0x0000CF20
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x0000ED2D File Offset: 0x0000CF2D
		public string TrialUniqueId
		{
			get
			{
				return this.interop.trialUniqueId;
			}
			set
			{
				this.interop.trialUniqueId = value;
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0000ED3B File Offset: 0x0000CF3B
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x0000ED48 File Offset: 0x0000CF48
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

		// Token: 0x04000554 RID: 1364
		internal XStoreGameLicense interop;
	}
}
