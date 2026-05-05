using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FD RID: 253
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpMinFloatParameter : VolumeParameter<float>
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0002687A File Offset: 0x00024A7A
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x00026882 File Offset: 0x00024A82
		public override float value
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

		// Token: 0x06000819 RID: 2073 RVA: 0x00026896 File Offset: 0x00024A96
		public NoInterpMinFloatParameter(float value, float min, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
		}

		// Token: 0x040004E6 RID: 1254
		[NonSerialized]
		public float min;
	}
}
