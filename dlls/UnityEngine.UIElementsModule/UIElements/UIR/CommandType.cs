using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000440 RID: 1088
	internal enum CommandType
	{
		// Token: 0x04000F0C RID: 3852
		Draw,
		// Token: 0x04000F0D RID: 3853
		ImmediateCull,
		// Token: 0x04000F0E RID: 3854
		Immediate,
		// Token: 0x04000F0F RID: 3855
		PushView,
		// Token: 0x04000F10 RID: 3856
		PopView,
		// Token: 0x04000F11 RID: 3857
		PushScissor,
		// Token: 0x04000F12 RID: 3858
		PopScissor,
		// Token: 0x04000F13 RID: 3859
		PushRenderTexture,
		// Token: 0x04000F14 RID: 3860
		PopRenderTexture,
		// Token: 0x04000F15 RID: 3861
		BlitToPreviousRT,
		// Token: 0x04000F16 RID: 3862
		PushDefaultMaterial,
		// Token: 0x04000F17 RID: 3863
		PopDefaultMaterial
	}
}
