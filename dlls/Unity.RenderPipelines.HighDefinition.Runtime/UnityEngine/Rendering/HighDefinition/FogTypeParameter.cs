using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200005E RID: 94
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	internal sealed class FogTypeParameter : VolumeParameter<FogType>
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000E430 File Offset: 0x0000C630
		public FogTypeParameter(FogType value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
