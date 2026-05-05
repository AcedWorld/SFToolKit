using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200015F RID: 351
	[MovedFrom("Unity.GameCore")]
	public class XPackageDetails
	{
		// Token: 0x0600085E RID: 2142 RVA: 0x0000DC0C File Offset: 0x0000BE0C
		internal XPackageDetails(XPackageDetails interop)
		{
			this.interop = interop;
			this._XVersion = new XVersion(interop.version);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0000DC2C File Offset: 0x0000BE2C
		public XPackageDetails()
		{
			this.interop = default(XPackageDetails);
			this._XVersion = new XVersion();
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x0000DC4B File Offset: 0x0000BE4B
		// (set) Token: 0x06000861 RID: 2145 RVA: 0x0000DC58 File Offset: 0x0000BE58
		public string PackageIdentifier
		{
			get
			{
				return this.interop.packageIdentifier;
			}
			set
			{
				this.interop.packageIdentifier = value;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0000DC66 File Offset: 0x0000BE66
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x0000DC6E File Offset: 0x0000BE6E
		public XVersion Version
		{
			get
			{
				return this._XVersion;
			}
			set
			{
				this._XVersion = value;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0000DC77 File Offset: 0x0000BE77
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x0000DC84 File Offset: 0x0000BE84
		public XPackageKind Kind
		{
			get
			{
				return this.interop.kind;
			}
			set
			{
				this.interop.kind = value;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0000DC92 File Offset: 0x0000BE92
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0000DC9F File Offset: 0x0000BE9F
		public string DisplayName
		{
			get
			{
				return this.interop.displayName;
			}
			set
			{
				this.interop.displayName = value;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0000DCAD File Offset: 0x0000BEAD
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0000DCBA File Offset: 0x0000BEBA
		public string Description
		{
			get
			{
				return this.interop.description;
			}
			set
			{
				this.interop.description = value;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0000DCC8 File Offset: 0x0000BEC8
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0000DCD5 File Offset: 0x0000BED5
		public string Publisher
		{
			get
			{
				return this.interop.publisher;
			}
			set
			{
				this.interop.publisher = value;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0000DCE3 File Offset: 0x0000BEE3
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		public string StoreId
		{
			get
			{
				return this.interop.storeId;
			}
			set
			{
				this.interop.storeId = value;
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0000DCFE File Offset: 0x0000BEFE
		// (set) Token: 0x0600086F RID: 2159 RVA: 0x0000DD0B File Offset: 0x0000BF0B
		public bool Installing
		{
			get
			{
				return this.interop.installing;
			}
			set
			{
				this.interop.installing = value;
			}
		}

		// Token: 0x0400050B RID: 1291
		internal XPackageDetails interop;

		// Token: 0x0400050C RID: 1292
		internal XVersion _XVersion;
	}
}
