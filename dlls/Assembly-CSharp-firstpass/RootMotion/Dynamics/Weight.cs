using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000082 RID: 130
	[Serializable]
	public class Weight
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x00018BEF File Offset: 0x00016DEF
		public Weight(float floatValue)
		{
			this.floatValue = floatValue;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00018C09 File Offset: 0x00016E09
		public Weight(float floatValue, string tooltip)
		{
			this.floatValue = floatValue;
			this.tooltip = tooltip;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00018C2A File Offset: 0x00016E2A
		public float GetValue(float param)
		{
			if (this.mode == Weight.Mode.Curve)
			{
				return this.curve.Evaluate(param);
			}
			return this.floatValue;
		}

		// Token: 0x040003B4 RID: 948
		public Weight.Mode mode;

		// Token: 0x040003B5 RID: 949
		public float floatValue;

		// Token: 0x040003B6 RID: 950
		public AnimationCurve curve;

		// Token: 0x040003B7 RID: 951
		public string tooltip = "";

		// Token: 0x02000083 RID: 131
		[Serializable]
		public enum Mode
		{
			// Token: 0x040003B9 RID: 953
			Float,
			// Token: 0x040003BA RID: 954
			Curve
		}
	}
}
