using System;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200014E RID: 334
	[NativeHeader("Runtime/GfxDevice/FrameTiming.h")]
	public struct FrameTiming
	{
		// Token: 0x0400042E RID: 1070
		[NativeName("totalFrameTime")]
		public double cpuFrameTime;

		// Token: 0x0400042F RID: 1071
		[NativeName("mainThreadActiveTime")]
		public double cpuMainThreadFrameTime;

		// Token: 0x04000430 RID: 1072
		[NativeName("mainThreadPresentWaitTime")]
		public double cpuMainThreadPresentWaitTime;

		// Token: 0x04000431 RID: 1073
		[NativeName("renderThreadActiveTime")]
		public double cpuRenderThreadFrameTime;

		// Token: 0x04000432 RID: 1074
		[NativeName("gpuFrameTime")]
		public double gpuFrameTime;

		// Token: 0x04000433 RID: 1075
		[NativeName("frameStartTimestamp")]
		public ulong frameStartTimestamp;

		// Token: 0x04000434 RID: 1076
		[NativeName("firstSubmitTimestamp")]
		public ulong firstSubmitTimestamp;

		// Token: 0x04000435 RID: 1077
		[NativeName("presentFrameTimestamp")]
		public ulong cpuTimePresentCalled;

		// Token: 0x04000436 RID: 1078
		[NativeName("frameCompleteTimestamp")]
		public ulong cpuTimeFrameComplete;

		// Token: 0x04000437 RID: 1079
		[NativeName("heightScale")]
		public float heightScale;

		// Token: 0x04000438 RID: 1080
		[NativeName("widthScale")]
		public float widthScale;

		// Token: 0x04000439 RID: 1081
		[NativeName("syncInterval")]
		public uint syncInterval;
	}
}
