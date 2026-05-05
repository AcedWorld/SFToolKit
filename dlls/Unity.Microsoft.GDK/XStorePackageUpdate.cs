using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000182 RID: 386
	[MovedFrom("Unity.GameCore")]
	public class XStorePackageUpdate
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x0000EC02 File Offset: 0x0000CE02
		internal XStorePackageUpdate(XStorePackageUpdate interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0000EC11 File Offset: 0x0000CE11
		public XStorePackageUpdate()
		{
			this.interop = default(XStorePackageUpdate);
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x0000EC25 File Offset: 0x0000CE25
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x0000EC32 File Offset: 0x0000CE32
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

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0000EC40 File Offset: 0x0000CE40
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x0000EC4D File Offset: 0x0000CE4D
		public bool IsMandatory
		{
			get
			{
				return this.interop.isMandatory;
			}
			set
			{
				this.interop.isMandatory = value;
			}
		}

		// Token: 0x04000553 RID: 1363
		internal XStorePackageUpdate interop;
	}
}
