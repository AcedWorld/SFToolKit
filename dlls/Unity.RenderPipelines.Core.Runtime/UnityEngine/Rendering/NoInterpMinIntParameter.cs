using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F5 RID: 245
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpMinIntParameter : VolumeParameter<int>
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0002672D File Offset: 0x0002492D
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x00026735 File Offset: 0x00024935
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

		// Token: 0x06000804 RID: 2052 RVA: 0x00026749 File Offset: 0x00024949
		public NoInterpMinIntParameter(int value, int min, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
		}

		// Token: 0x040004DE RID: 1246
		[NonSerialized]
		public int min;
	}
}
