using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000106 RID: 262
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class Vector2Parameter : VolumeParameter<Vector2>
	{
		// Token: 0x06000832 RID: 2098 RVA: 0x00026BB0 File Offset: 0x00024DB0
		public Vector2Parameter(Vector2 value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00026BBC File Offset: 0x00024DBC
		public override void Interp(Vector2 from, Vector2 to, float t)
		{
			this.m_Value.x = from.x + (to.x - from.x) * t;
			this.m_Value.y = from.y + (to.y - from.y) * t;
		}
	}
}
