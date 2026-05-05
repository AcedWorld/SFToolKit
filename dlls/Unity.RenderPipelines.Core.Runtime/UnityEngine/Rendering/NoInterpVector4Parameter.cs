using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010B RID: 267
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpVector4Parameter : VolumeParameter<Vector4>
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x00026D35 File Offset: 0x00024F35
		public NoInterpVector4Parameter(Vector4 value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
