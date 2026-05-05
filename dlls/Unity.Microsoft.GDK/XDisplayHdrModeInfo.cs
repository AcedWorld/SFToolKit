using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200011D RID: 285
	[MovedFrom("Unity.GameCore")]
	public class XDisplayHdrModeInfo
	{
		// Token: 0x0600073F RID: 1855 RVA: 0x0000CD69 File Offset: 0x0000AF69
		internal XDisplayHdrModeInfo(XDisplayHdrModeInfo interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0000CD78 File Offset: 0x0000AF78
		public XDisplayHdrModeInfo()
		{
			this.interop = default(XDisplayHdrModeInfo);
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0000CD8C File Offset: 0x0000AF8C
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x0000CD99 File Offset: 0x0000AF99
		public float MinToneMapLuminance
		{
			get
			{
				return this.interop.minToneMapLuminance;
			}
			set
			{
				this.interop.minToneMapLuminance = value;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x0000CDA7 File Offset: 0x0000AFA7
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x0000CDB4 File Offset: 0x0000AFB4
		public float MaxToneMapLuminance
		{
			get
			{
				return this.interop.maxToneMapLuminance;
			}
			set
			{
				this.interop.maxToneMapLuminance = value;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0000CDC2 File Offset: 0x0000AFC2
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x0000CDCF File Offset: 0x0000AFCF
		public float MaxFullFrameToneMapLuminance
		{
			get
			{
				return this.interop.maxFullFrameToneMapLuminance;
			}
			set
			{
				this.interop.maxFullFrameToneMapLuminance = value;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0000CDDD File Offset: 0x0000AFDD
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0000CDEA File Offset: 0x0000AFEA
		[Obsolete("Please use MinToneMapLuminance instead, (UnityUpgradable) -> MinToneMapLuminance", true)]
		public float minToneMapLuminance
		{
			get
			{
				return this.interop.minToneMapLuminance;
			}
			set
			{
				this.interop.minToneMapLuminance = value;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x0000CE05 File Offset: 0x0000B005
		[Obsolete("Please use MaxToneMapLuminance instead, (UnityUpgradable) -> MaxToneMapLuminance", true)]
		public float maxToneMapLuminance
		{
			get
			{
				return this.interop.maxToneMapLuminance;
			}
			set
			{
				this.interop.maxToneMapLuminance = value;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x0000CE13 File Offset: 0x0000B013
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x0000CE20 File Offset: 0x0000B020
		[Obsolete("Please use MaxFullFrameToneMapLuminance instead, (UnityUpgradable) -> MaxFullFrameToneMapLuminance", true)]
		public float maxFullFrameToneMapLuminance
		{
			get
			{
				return this.interop.maxFullFrameToneMapLuminance;
			}
			set
			{
				this.interop.maxFullFrameToneMapLuminance = value;
			}
		}

		// Token: 0x0400043C RID: 1084
		internal XDisplayHdrModeInfo interop;
	}
}
