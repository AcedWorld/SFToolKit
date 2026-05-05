using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000174 RID: 372
	[MovedFrom("Unity.GameCore")]
	public class XStoreCanAcquireLicenseResult
	{
		// Token: 0x060008D3 RID: 2259 RVA: 0x0000E161 File Offset: 0x0000C361
		internal XStoreCanAcquireLicenseResult(XStoreCanAcquireLicenseResult interop)
		{
			this.interop = interop;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0000E170 File Offset: 0x0000C370
		public XStoreCanAcquireLicenseResult()
		{
			this.interop = default(XStoreCanAcquireLicenseResult);
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x0000E184 File Offset: 0x0000C384
		// (set) Token: 0x060008D6 RID: 2262 RVA: 0x0000E191 File Offset: 0x0000C391
		public string LicensableSku
		{
			get
			{
				return this.interop.licensableSku;
			}
			set
			{
				this.interop.licensableSku = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0000E19F File Offset: 0x0000C39F
		// (set) Token: 0x060008D8 RID: 2264 RVA: 0x0000E1AC File Offset: 0x0000C3AC
		public XStoreCanLicenseStatus Status
		{
			get
			{
				return this.interop.status;
			}
			set
			{
				this.interop.status = value;
			}
		}

		// Token: 0x0400052C RID: 1324
		internal XStoreCanAcquireLicenseResult interop;
	}
}
