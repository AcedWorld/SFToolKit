using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FC RID: 252
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class MinFloatParameter : FloatParameter
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0002684D File Offset: 0x00024A4D
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x00026855 File Offset: 0x00024A55
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

		// Token: 0x06000816 RID: 2070 RVA: 0x00026869 File Offset: 0x00024A69
		public MinFloatParameter(float value, float min, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
		}

		// Token: 0x040004E5 RID: 1253
		[NonSerialized]
		public float min;
	}
}
