using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F8 RID: 248
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class ClampedIntParameter : IntParameter
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x000267B4 File Offset: 0x000249B4
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x000267BC File Offset: 0x000249BC
		public override int value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Clamp(value, this.min, this.max);
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x000267D6 File Offset: 0x000249D6
		public ClampedIntParameter(int value, int min, int max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x040004E1 RID: 1249
		[NonSerialized]
		public int min;

		// Token: 0x040004E2 RID: 1250
		[NonSerialized]
		public int max;
	}
}
