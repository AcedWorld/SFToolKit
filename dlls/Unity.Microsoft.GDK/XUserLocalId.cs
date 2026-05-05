using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001A8 RID: 424
	[MovedFrom("Unity.GameCore")]
	public class XUserLocalId
	{
		// Token: 0x060009EE RID: 2542 RVA: 0x0000F259 File Offset: 0x0000D459
		internal XUserLocalId(XUserLocalId interop)
		{
			this.interop = interop;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0000F268 File Offset: 0x0000D468
		public XUserLocalId()
		{
			this.interop = default(XUserLocalId);
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0000F27C File Offset: 0x0000D47C
		// (set) Token: 0x060009F1 RID: 2545 RVA: 0x0000F289 File Offset: 0x0000D489
		public ulong Value
		{
			get
			{
				return this.interop.value;
			}
			set
			{
				this.interop.value = value;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0000F297 File Offset: 0x0000D497
		// (set) Token: 0x060009F3 RID: 2547 RVA: 0x0000F2A4 File Offset: 0x0000D4A4
		[Obsolete("Please use Value instead, (UnityUpgradable) -> Value", true)]
		public ulong value
		{
			get
			{
				return this.interop.value;
			}
			set
			{
				this.interop.value = value;
			}
		}

		// Token: 0x040005C8 RID: 1480
		internal XUserLocalId interop;
	}
}
