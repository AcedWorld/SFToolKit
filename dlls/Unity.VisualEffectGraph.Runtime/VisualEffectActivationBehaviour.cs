using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.VFX.Utility;

// Token: 0x02000003 RID: 3
[Serializable]
internal class VisualEffectActivationBehaviour : PlayableBehaviour
{
	// Token: 0x04000003 RID: 3
	[SerializeField]
	public ExposedProperty onClipEnter = "OnPlay";

	// Token: 0x04000004 RID: 4
	[SerializeField]
	public ExposedProperty onClipExit = "OnStop";

	// Token: 0x04000005 RID: 5
	[SerializeField]
	public VisualEffectActivationBehaviour.EventState[] clipEnterEventAttributes;

	// Token: 0x04000006 RID: 6
	[SerializeField]
	public VisualEffectActivationBehaviour.EventState[] clipExitEventAttributes;

	// Token: 0x02000042 RID: 66
	[Serializable]
	public enum AttributeType
	{
		// Token: 0x04000118 RID: 280
		Float = 1,
		// Token: 0x04000119 RID: 281
		Float2,
		// Token: 0x0400011A RID: 282
		Float3,
		// Token: 0x0400011B RID: 283
		Float4,
		// Token: 0x0400011C RID: 284
		Int32,
		// Token: 0x0400011D RID: 285
		Uint32,
		// Token: 0x0400011E RID: 286
		Boolean = 17
	}

	// Token: 0x02000043 RID: 67
	[Serializable]
	public struct EventState
	{
		// Token: 0x0400011F RID: 287
		public ExposedProperty attribute;

		// Token: 0x04000120 RID: 288
		public VisualEffectActivationBehaviour.AttributeType type;

		// Token: 0x04000121 RID: 289
		public float[] values;
	}
}
