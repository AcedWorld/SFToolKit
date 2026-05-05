using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F4 RID: 244
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class MinIntParameter : IntParameter
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x00026700 File Offset: 0x00024900
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x00026708 File Offset: 0x00024908
		public override int value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Max(value, this.min);
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0002671C File Offset: 0x0002491C
		public MinIntParameter(int value, int min, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
		}

		// Token: 0x040004DD RID: 1245
		[NonSerialized]
		public int min;
	}
}
