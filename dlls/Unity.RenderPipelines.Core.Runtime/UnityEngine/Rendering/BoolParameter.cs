using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F0 RID: 240
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class BoolParameter : VolumeParameter<bool>
	{
		// Token: 0x060007F9 RID: 2041 RVA: 0x000266B5 File Offset: 0x000248B5
		public BoolParameter(bool value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000266BF File Offset: 0x000248BF
		public BoolParameter(bool value, BoolParameter.DisplayType displayType, bool overrideState = false) : base(value, overrideState)
		{
			this.displayType = displayType;
		}

		// Token: 0x040004DC RID: 1244
		[NonSerialized]
		public BoolParameter.DisplayType displayType;

		// Token: 0x020001D9 RID: 473
		public enum DisplayType
		{
			// Token: 0x040007AB RID: 1963
			Checkbox,
			// Token: 0x040007AC RID: 1964
			EnumPopup
		}
	}
}
