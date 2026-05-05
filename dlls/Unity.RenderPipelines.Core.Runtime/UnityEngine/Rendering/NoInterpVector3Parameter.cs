using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000109 RID: 265
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpVector3Parameter : VolumeParameter<Vector3>
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x00026C90 File Offset: 0x00024E90
		public NoInterpVector3Parameter(Vector3 value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
