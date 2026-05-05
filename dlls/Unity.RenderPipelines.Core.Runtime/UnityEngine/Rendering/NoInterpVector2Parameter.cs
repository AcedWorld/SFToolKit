using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000107 RID: 263
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpVector2Parameter : VolumeParameter<Vector2>
	{
		// Token: 0x06000834 RID: 2100 RVA: 0x00026C0B File Offset: 0x00024E0B
		public NoInterpVector2Parameter(Vector2 value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
