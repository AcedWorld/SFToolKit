using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200006D RID: 109
	internal struct FrameTimeSample
	{
		// Token: 0x0600038A RID: 906 RVA: 0x0000FD4C File Offset: 0x0000DF4C
		internal FrameTimeSample(float initValue)
		{
			this.FramesPerSecond = initValue;
			this.FullFrameTime = initValue;
			this.MainThreadCPUFrameTime = initValue;
			this.MainThreadCPUPresentWaitTime = initValue;
			this.RenderThreadCPUFrameTime = initValue;
			this.GPUFrameTime = initValue;
		}

		// Token: 0x04000205 RID: 517
		internal float FramesPerSecond;

		// Token: 0x04000206 RID: 518
		internal float FullFrameTime;

		// Token: 0x04000207 RID: 519
		internal float MainThreadCPUFrameTime;

		// Token: 0x04000208 RID: 520
		internal float MainThreadCPUPresentWaitTime;

		// Token: 0x04000209 RID: 521
		internal float RenderThreadCPUFrameTime;

		// Token: 0x0400020A RID: 522
		internal float GPUFrameTime;
	}
}
