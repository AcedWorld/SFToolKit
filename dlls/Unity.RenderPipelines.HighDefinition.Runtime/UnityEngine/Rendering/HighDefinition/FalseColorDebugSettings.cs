using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200003C RID: 60
	[Serializable]
	public class FalseColorDebugSettings
	{
		// Token: 0x04000174 RID: 372
		public bool falseColor;

		// Token: 0x04000175 RID: 373
		public float colorThreshold0;

		// Token: 0x04000176 RID: 374
		public float colorThreshold1 = 2f;

		// Token: 0x04000177 RID: 375
		public float colorThreshold2 = 10f;

		// Token: 0x04000178 RID: 376
		public float colorThreshold3 = 20f;
	}
}
