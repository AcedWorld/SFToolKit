using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F6 RID: 246
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class MaxIntParameter : IntParameter
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0002675A File Offset: 0x0002495A
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x00026762 File Offset: 0x00024962
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

		// Token: 0x06000807 RID: 2055 RVA: 0x00026776 File Offset: 0x00024976
		public MaxIntParameter(int value, int max, bool overrideState = false) : base(value, overrideState)
		{
			this.max = max;
		}

		// Token: 0x040004DF RID: 1247
		[NonSerialized]
		public int max;
	}
}
