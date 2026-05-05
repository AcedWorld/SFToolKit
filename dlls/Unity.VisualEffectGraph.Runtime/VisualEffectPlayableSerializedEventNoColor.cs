using System;
using UnityEngine.VFX.Utility;

namespace UnityEngine.VFX
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	internal struct VisualEffectPlayableSerializedEventNoColor
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002D90 File Offset: 0x00000F90
		public static implicit operator VisualEffectPlayableSerializedEvent(VisualEffectPlayableSerializedEventNoColor evt)
		{
			return new VisualEffectPlayableSerializedEvent
			{
				time = evt.time,
				timeSpace = evt.timeSpace,
				name = evt.name,
				eventAttributes = evt.eventAttributes
			};
		}

		// Token: 0x04000032 RID: 50
		public double time;

		// Token: 0x04000033 RID: 51
		public PlayableTimeSpace timeSpace;

		// Token: 0x04000034 RID: 52
		public ExposedProperty name;

		// Token: 0x04000035 RID: 53
		public EventAttributes eventAttributes;
	}
}
