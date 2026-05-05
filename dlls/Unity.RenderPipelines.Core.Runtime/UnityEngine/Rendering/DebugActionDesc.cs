using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000064 RID: 100
	internal class DebugActionDesc
	{
		// Token: 0x040001E4 RID: 484
		public string axisTrigger = "";

		// Token: 0x040001E5 RID: 485
		public List<string[]> buttonTriggerList = new List<string[]>();

		// Token: 0x040001E6 RID: 486
		public List<KeyCode[]> keyTriggerList = new List<KeyCode[]>();

		// Token: 0x040001E7 RID: 487
		public DebugActionRepeatMode repeatMode;

		// Token: 0x040001E8 RID: 488
		public float repeatDelay;
	}
}
