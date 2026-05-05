using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F7 RID: 247
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpMaxIntParameter : VolumeParameter<int>
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00026787 File Offset: 0x00024987
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0002678F File Offset: 0x0002498F
		public override int value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Min(value, this.max);
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x000267A3 File Offset: 0x000249A3
		public NoInterpMaxIntParameter(int value, int max, bool overrideState = false) : base(value, overrideState)
		{
			this.max = max;
		}

		// Token: 0x040004E0 RID: 1248
		[NonSerialized]
		public int max;
	}
}
