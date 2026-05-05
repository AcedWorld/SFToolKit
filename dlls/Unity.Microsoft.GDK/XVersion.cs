using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200018D RID: 397
	[MovedFrom("Unity.GameCore")]
	public class XVersion
	{
		// Token: 0x0600099E RID: 2462 RVA: 0x0000EE68 File Offset: 0x0000D068
		internal XVersion(XVersion interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0000EE77 File Offset: 0x0000D077
		public XVersion()
		{
			this.interop = default(XVersion);
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0000EE8B File Offset: 0x0000D08B
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x0000EE98 File Offset: 0x0000D098
		public ushort Major
		{
			get
			{
				return this.interop.major;
			}
			set
			{
				this.interop.major = value;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0000EEA6 File Offset: 0x0000D0A6
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x0000EEB3 File Offset: 0x0000D0B3
		public ushort Minor
		{
			get
			{
				return this.interop.minor;
			}
			set
			{
				this.interop.minor = value;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x0000EEC1 File Offset: 0x0000D0C1
		// (set) Token: 0x060009A5 RID: 2469 RVA: 0x0000EECE File Offset: 0x0000D0CE
		public ushort Build
		{
			get
			{
				return this.interop.build;
			}
			set
			{
				this.interop.build = value;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0000EEDC File Offset: 0x0000D0DC
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x0000EEE9 File Offset: 0x0000D0E9
		public ushort Revision
		{
			get
			{
				return this.interop.revision;
			}
			set
			{
				this.interop.revision = value;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0000EEF7 File Offset: 0x0000D0F7
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0000EF04 File Offset: 0x0000D104
		public ulong Value
		{
			get
			{
				return this.interop.Value;
			}
			set
			{
				this.interop.Value = value;
			}
		}

		// Token: 0x04000576 RID: 1398
		internal XVersion interop;
	}
}
