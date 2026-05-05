using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000108 RID: 264
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class Vector3Parameter : VolumeParameter<Vector3>
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x00026C15 File Offset: 0x00024E15
		public Vector3Parameter(Vector3 value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00026C20 File Offset: 0x00024E20
		public override void Interp(Vector3 from, Vector3 to, float t)
		{
			this.m_Value.x = from.x + (to.x - from.x) * t;
			this.m_Value.y = from.y + (to.y - from.y) * t;
			this.m_Value.z = from.z + (to.z - from.z) * t;
		}
	}
}
