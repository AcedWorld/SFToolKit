using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F2 RID: 242
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class IntParameter : VolumeParameter<int>
	{
		// Token: 0x060007FC RID: 2044 RVA: 0x000266DA File Offset: 0x000248DA
		public IntParameter(int value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x000266E4 File Offset: 0x000248E4
		public sealed override void Interp(int from, int to, float t)
		{
			this.m_Value = (int)((float)from + (float)(to - from) * t);
		}
	}
}
