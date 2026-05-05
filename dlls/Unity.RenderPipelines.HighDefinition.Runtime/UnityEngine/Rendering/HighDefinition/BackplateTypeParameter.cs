using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F3 RID: 499
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class BackplateTypeParameter : VolumeParameter<BackplateType>
	{
		// Token: 0x06000F1F RID: 3871 RVA: 0x0007700E File Offset: 0x0007520E
		public BackplateTypeParameter(BackplateType value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
