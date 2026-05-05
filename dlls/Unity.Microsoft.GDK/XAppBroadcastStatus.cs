using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000021 RID: 33
	[MovedFrom("Unity.GameCore")]
	public class XAppBroadcastStatus
	{
		// Token: 0x0600027B RID: 635 RVA: 0x00008A68 File Offset: 0x00006C68
		internal XAppBroadcastStatus(XAppBroadcastStatus interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00008A77 File Offset: 0x00006C77
		public XAppBroadcastStatus()
		{
			this.interop = default(XAppBroadcastStatus);
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00008A8B File Offset: 0x00006C8B
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00008A98 File Offset: 0x00006C98
		public bool CanStartBroadcast
		{
			get
			{
				return this.interop.canStartBroadcast;
			}
			set
			{
				this.interop.canStartBroadcast = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00008AA6 File Offset: 0x00006CA6
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00008AB3 File Offset: 0x00006CB3
		public bool IsAnyAppBroadcasting
		{
			get
			{
				return this.interop.isAnyAppBroadcasting;
			}
			set
			{
				this.interop.isAnyAppBroadcasting = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00008AC1 File Offset: 0x00006CC1
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00008ACE File Offset: 0x00006CCE
		public bool IsCaptureResourceUnavailable
		{
			get
			{
				return this.interop.isCaptureResourceUnavailable;
			}
			set
			{
				this.interop.isCaptureResourceUnavailable = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00008ADC File Offset: 0x00006CDC
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00008AE9 File Offset: 0x00006CE9
		public bool IsGameStreamInProgress
		{
			get
			{
				return this.interop.isGameStreamInProgress;
			}
			set
			{
				this.interop.isGameStreamInProgress = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00008AF7 File Offset: 0x00006CF7
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00008B04 File Offset: 0x00006D04
		public bool IsGpuConstrained
		{
			get
			{
				return this.interop.isGpuConstrained;
			}
			set
			{
				this.interop.isGpuConstrained = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00008B12 File Offset: 0x00006D12
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00008B1F File Offset: 0x00006D1F
		public bool IsAppInactive
		{
			get
			{
				return this.interop.isAppInactive;
			}
			set
			{
				this.interop.isAppInactive = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00008B2D File Offset: 0x00006D2D
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00008B3A File Offset: 0x00006D3A
		public bool IsBlockedForApp
		{
			get
			{
				return this.interop.isBlockedForApp;
			}
			set
			{
				this.interop.isBlockedForApp = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00008B48 File Offset: 0x00006D48
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00008B55 File Offset: 0x00006D55
		public bool IsDisabledByUser
		{
			get
			{
				return this.interop.isDisabledByUser;
			}
			set
			{
				this.interop.isDisabledByUser = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00008B63 File Offset: 0x00006D63
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00008B70 File Offset: 0x00006D70
		public bool IsDisabledBySystem
		{
			get
			{
				return this.interop.isDisabledBySystem;
			}
			set
			{
				this.interop.isDisabledBySystem = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00008B7E File Offset: 0x00006D7E
		// (set) Token: 0x06000290 RID: 656 RVA: 0x00008B8B File Offset: 0x00006D8B
		[Obsolete("Please use CanStartBroadcast instead, (UnityUpgradable) -> CanStartBroadcast", true)]
		public bool canStartBroadcast
		{
			get
			{
				return this.interop.canStartBroadcast;
			}
			set
			{
				this.interop.canStartBroadcast = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00008B99 File Offset: 0x00006D99
		// (set) Token: 0x06000292 RID: 658 RVA: 0x00008BA6 File Offset: 0x00006DA6
		[Obsolete("Please use IsAnyAppBroadcasting instead, (UnityUpgradable) -> IsAnyAppBroadcasting", true)]
		public bool isAnyAppBroadcasting
		{
			get
			{
				return this.interop.isAnyAppBroadcasting;
			}
			set
			{
				this.interop.isAnyAppBroadcasting = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00008BB4 File Offset: 0x00006DB4
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00008BC1 File Offset: 0x00006DC1
		[Obsolete("Please use IsCaptureResourceUnavailable instead, (UnityUpgradable) -> IsCaptureResourceUnavailable", true)]
		public bool isCaptureResourceUnavailable
		{
			get
			{
				return this.interop.isCaptureResourceUnavailable;
			}
			set
			{
				this.interop.isCaptureResourceUnavailable = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00008BCF File Offset: 0x00006DCF
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00008BDC File Offset: 0x00006DDC
		[Obsolete("Please use IsGameStreamInProgress instead, (UnityUpgradable) -> IsGameStreamInProgress", true)]
		public bool isGameStreamInProgress
		{
			get
			{
				return this.interop.isGameStreamInProgress;
			}
			set
			{
				this.interop.isGameStreamInProgress = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00008BEA File Offset: 0x00006DEA
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00008BF7 File Offset: 0x00006DF7
		[Obsolete("Please use IsGpuConstrained instead, (UnityUpgradable) -> IsGpuConstrained", true)]
		public bool isGpuConstrained
		{
			get
			{
				return this.interop.isGpuConstrained;
			}
			set
			{
				this.interop.isGpuConstrained = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00008C05 File Offset: 0x00006E05
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00008C12 File Offset: 0x00006E12
		[Obsolete("Please use IsAppInactive instead, (UnityUpgradable) -> IsAppInactive", true)]
		public bool isAppInactive
		{
			get
			{
				return this.interop.isAppInactive;
			}
			set
			{
				this.interop.isAppInactive = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00008C20 File Offset: 0x00006E20
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00008C2D File Offset: 0x00006E2D
		[Obsolete("Please use IsBlockedForApp instead, (UnityUpgradable) -> IsBlockedForApp", true)]
		public bool isBlockedForApp
		{
			get
			{
				return this.interop.isBlockedForApp;
			}
			set
			{
				this.interop.isBlockedForApp = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00008C3B File Offset: 0x00006E3B
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00008C48 File Offset: 0x00006E48
		[Obsolete("Please use IsDisabledByUser instead, (UnityUpgradable) -> IsDisabledByUser", true)]
		public bool isDisabledByUser
		{
			get
			{
				return this.interop.isDisabledByUser;
			}
			set
			{
				this.interop.isDisabledByUser = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00008C56 File Offset: 0x00006E56
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00008C63 File Offset: 0x00006E63
		[Obsolete("Please use IsDisabledBySystem instead, (UnityUpgradable) -> IsDisabledBySystem", true)]
		public bool isDisabledBySystem
		{
			get
			{
				return this.interop.isDisabledBySystem;
			}
			set
			{
				this.interop.isDisabledBySystem = value;
			}
		}

		// Token: 0x040000B4 RID: 180
		internal XAppBroadcastStatus interop;
	}
}
