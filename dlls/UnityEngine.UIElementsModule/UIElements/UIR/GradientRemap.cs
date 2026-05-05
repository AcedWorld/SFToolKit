using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000473 RID: 1139
	internal class GradientRemap : LinkedPoolItem<GradientRemap>
	{
		// Token: 0x0600233F RID: 9023 RVA: 0x00088D9C File Offset: 0x00086F9C
		public void Reset()
		{
			this.origIndex = 0;
			this.destIndex = 0;
			this.location = default(RectInt);
			this.atlas = TextureId.invalid;
		}

		// Token: 0x04001063 RID: 4195
		public int origIndex;

		// Token: 0x04001064 RID: 4196
		public int destIndex;

		// Token: 0x04001065 RID: 4197
		public RectInt location;

		// Token: 0x04001066 RID: 4198
		public GradientRemap next;

		// Token: 0x04001067 RID: 4199
		public TextureId atlas;
	}
}
