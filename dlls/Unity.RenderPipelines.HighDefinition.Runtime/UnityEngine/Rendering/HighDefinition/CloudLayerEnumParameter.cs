using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001D6 RID: 470
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class CloudLayerEnumParameter<T> : VolumeParameter<T>
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x00071DEB File Offset: 0x0006FFEB
		public CloudLayerEnumParameter(T value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
