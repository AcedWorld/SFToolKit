using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000016 RID: 22
	[MovedFrom("Unity.GameCore")]
	public class XColor
	{
		// Token: 0x0600023F RID: 575 RVA: 0x00008668 File Offset: 0x00006868
		internal XColor(XColor interop)
		{
			this._argb = new ARGB(interop.Argb);
			this._interop = interop;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00008688 File Offset: 0x00006888
		public XColor()
		{
			this._interop = default(XColor);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000869C File Offset: 0x0000689C
		internal XColor interop
		{
			get
			{
				this._interop.Argb = this._argb.interop;
				return this._interop;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000086BA File Offset: 0x000068BA
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000086C2 File Offset: 0x000068C2
		public ARGB Argb
		{
			get
			{
				return this._argb;
			}
			set
			{
				this._argb = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000086CB File Offset: 0x000068CB
		// (set) Token: 0x06000245 RID: 581 RVA: 0x000086D8 File Offset: 0x000068D8
		public uint Value
		{
			get
			{
				return this._interop.Value;
			}
			set
			{
				this._interop.Value = value;
			}
		}

		// Token: 0x0400009B RID: 155
		internal XColor _interop;

		// Token: 0x0400009C RID: 156
		internal ARGB _argb;
	}
}
