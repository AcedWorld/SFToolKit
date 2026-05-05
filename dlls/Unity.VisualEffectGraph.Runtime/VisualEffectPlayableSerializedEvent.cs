using System;
using UnityEngine.VFX.Utility;

namespace UnityEngine.VFX
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	internal struct VisualEffectPlayableSerializedEvent
	{
		// Token: 0x0400002D RID: 45
		public Color editorColor;

		// Token: 0x0400002E RID: 46
		public double time;

		// Token: 0x0400002F RID: 47
		public PlayableTimeSpace timeSpace;

		// Token: 0x04000030 RID: 48
		public ExposedProperty name;

		// Token: 0x04000031 RID: 49
		public EventAttributes eventAttributes;
	}
}
