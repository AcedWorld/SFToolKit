using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F9 RID: 249
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpClampedIntParameter : VolumeParameter<int>
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x000267EF File Offset: 0x000249EF
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x000267F7 File Offset: 0x000249F7
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

		// Token: 0x06000810 RID: 2064 RVA: 0x00026811 File Offset: 0x00024A11
		public NoInterpClampedIntParameter(int value, int min, int max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x040004E3 RID: 1251
		[NonSerialized]
		public int min;

		// Token: 0x040004E4 RID: 1252
		[NonSerialized]
		public int max;
	}
}
