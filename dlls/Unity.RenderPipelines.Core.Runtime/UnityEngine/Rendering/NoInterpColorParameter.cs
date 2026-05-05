using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000105 RID: 261
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpColorParameter : VolumeParameter<Color>
	{
		// Token: 0x06000830 RID: 2096 RVA: 0x00026B61 File Offset: 0x00024D61
		public NoInterpColorParameter(Color value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00026B79 File Offset: 0x00024D79
		public NoInterpColorParameter(Color value, bool hdr, bool showAlpha, bool showEyeDropper, bool overrideState = false) : base(value, overrideState)
		{
			this.hdr = hdr;
			this.showAlpha = showAlpha;
			this.showEyeDropper = showEyeDropper;
			this.overrideState = overrideState;
		}

		// Token: 0x040004F4 RID: 1268
		public bool hdr;

		// Token: 0x040004F5 RID: 1269
		[NonSerialized]
		public bool showAlpha = true;

		// Token: 0x040004F6 RID: 1270
		[NonSerialized]
		public bool showEyeDropper = true;
	}
}
