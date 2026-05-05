using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200018E RID: 398
	[MovedFrom("Unity.GameCore.Interop")]
	public class XSystemAnalyticsInfo
	{
		// Token: 0x060009AA RID: 2474 RVA: 0x0000EF12 File Offset: 0x0000D112
		internal XSystemAnalyticsInfo(XSystemAnalyticsInfo interop)
		{
			this.interop = interop;
			this._osVersion = new XVersion(this.interop.osVersion);
			this._hostingOsVersion = new XVersion(this.interop.hostingOsVersion);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0000EF4D File Offset: 0x0000D14D
		public XSystemAnalyticsInfo()
		{
			this.interop = default(XSystemAnalyticsInfo);
			this._osVersion = new XVersion();
			this._hostingOsVersion = new XVersion();
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x0000EF77 File Offset: 0x0000D177
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x0000EF7F File Offset: 0x0000D17F
		public XVersion OsVersion
		{
			get
			{
				return this._osVersion;
			}
			set
			{
				this._osVersion = value;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x0000EF88 File Offset: 0x0000D188
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x0000EF90 File Offset: 0x0000D190
		public XVersion HostingOsVersion
		{
			get
			{
				return this._hostingOsVersion;
			}
			set
			{
				this._hostingOsVersion = value;
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0000EF99 File Offset: 0x0000D199
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x0000EFA6 File Offset: 0x0000D1A6
		public string Family
		{
			get
			{
				return this.interop.family;
			}
			set
			{
				this.interop.family = value;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0000EFB4 File Offset: 0x0000D1B4
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x0000EFC1 File Offset: 0x0000D1C1
		public string Form
		{
			get
			{
				return this.interop.form;
			}
			set
			{
				this.interop.form = value;
			}
		}

		// Token: 0x04000577 RID: 1399
		internal XSystemAnalyticsInfo interop;

		// Token: 0x04000578 RID: 1400
		private XVersion _osVersion;

		// Token: 0x04000579 RID: 1401
		private XVersion _hostingOsVersion;
	}
}
