using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000104 RID: 260
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class ColorParameter : VolumeParameter<Color>
	{
		// Token: 0x0600082D RID: 2093 RVA: 0x00026A7E File Offset: 0x00024C7E
		public ColorParameter(Color value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00026A96 File Offset: 0x00024C96
		public ColorParameter(Color value, bool hdr, bool showAlpha, bool showEyeDropper, bool overrideState = false) : base(value, overrideState)
		{
			this.hdr = hdr;
			this.showAlpha = showAlpha;
			this.showEyeDropper = showEyeDropper;
			this.overrideState = overrideState;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00026AD0 File Offset: 0x00024CD0
		public override void Interp(Color from, Color to, float t)
		{
			this.m_Value.r = from.r + (to.r - from.r) * t;
			this.m_Value.g = from.g + (to.g - from.g) * t;
			this.m_Value.b = from.b + (to.b - from.b) * t;
			this.m_Value.a = from.a + (to.a - from.a) * t;
		}

		// Token: 0x040004F1 RID: 1265
		[NonSerialized]
		public bool hdr;

		// Token: 0x040004F2 RID: 1266
		[NonSerialized]
		public bool showAlpha = true;

		// Token: 0x040004F3 RID: 1267
		[NonSerialized]
		public bool showEyeDropper = true;
	}
}
