using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010A RID: 266
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class Vector4Parameter : VolumeParameter<Vector4>
	{
		// Token: 0x06000838 RID: 2104 RVA: 0x00026C9A File Offset: 0x00024E9A
		public Vector4Parameter(Vector4 value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00026CA4 File Offset: 0x00024EA4
		public override void Interp(Vector4 from, Vector4 to, float t)
		{
			this.m_Value.x = from.x + (to.x - from.x) * t;
			this.m_Value.y = from.y + (to.y - from.y) * t;
			this.m_Value.z = from.z + (to.z - from.z) * t;
			this.m_Value.w = from.w + (to.w - from.w) * t;
		}
	}
}
