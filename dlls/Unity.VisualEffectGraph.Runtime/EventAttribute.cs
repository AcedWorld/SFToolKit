using System;
using UnityEngine.VFX.Utility;

namespace UnityEngine.VFX
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	internal abstract class EventAttribute
	{
		// Token: 0x0600002D RID: 45
		public abstract bool ApplyToVFX(VFXEventAttribute eventAttribute);

		// Token: 0x04000024 RID: 36
		public ExposedProperty id;
	}
}
