using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200014E RID: 334
	[MovedFrom("Unity.GameCore")]
	public class XNetworkingConnectivityHint
	{
		// Token: 0x06000805 RID: 2053 RVA: 0x0000D782 File Offset: 0x0000B982
		internal XNetworkingConnectivityHint(XNetworkingConnectivityHint interop)
		{
			this.data = interop;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0000D791 File Offset: 0x0000B991
		public XNetworkingConnectivityHint()
		{
			this.data = default(XNetworkingConnectivityHint);
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x0000D7A5 File Offset: 0x0000B9A5
		// (set) Token: 0x06000808 RID: 2056 RVA: 0x0000D7B2 File Offset: 0x0000B9B2
		public XNetworkingConnectivityLevelHint ConnectivityLevel
		{
			get
			{
				return this.data.connectivityLevel;
			}
			set
			{
				this.data.connectivityLevel = value;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x0000D7CD File Offset: 0x0000B9CD
		public XNetworkingConnectivityCostHint ConnectivityCost
		{
			get
			{
				return this.data.connectivityCost;
			}
			set
			{
				this.data.connectivityCost = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000D7DB File Offset: 0x0000B9DB
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
		public uint IanaInterfaceType
		{
			get
			{
				return this.data.ianaInterfaceType;
			}
			set
			{
				this.data.ianaInterfaceType = value;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0000D7F6 File Offset: 0x0000B9F6
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x0000D803 File Offset: 0x0000BA03
		public bool NetworkInitialized
		{
			get
			{
				return this.data.networkInitialized;
			}
			set
			{
				this.data.networkInitialized = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000D811 File Offset: 0x0000BA11
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x0000D81E File Offset: 0x0000BA1E
		public bool ApproachingDataLimit
		{
			get
			{
				return this.data.approachingDataLimit;
			}
			set
			{
				this.data.approachingDataLimit = value;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0000D82C File Offset: 0x0000BA2C
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x0000D839 File Offset: 0x0000BA39
		public bool OverDataLimit
		{
			get
			{
				return this.data.overDataLimit;
			}
			set
			{
				this.data.overDataLimit = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0000D847 File Offset: 0x0000BA47
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x0000D854 File Offset: 0x0000BA54
		public bool Roaming
		{
			get
			{
				return this.data.roaming;
			}
			set
			{
				this.data.roaming = value;
			}
		}

		// Token: 0x040004ED RID: 1261
		internal XNetworkingConnectivityHint data;
	}
}
