using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001AF RID: 431
	[DebuggerDisplay("{mask.humanizedData}")]
	[Serializable]
	public struct FrameSettingsOverrideMask
	{
		// Token: 0x040014D5 RID: 5333
		[SerializeField]
		public BitArray128 mask;
	}
}
