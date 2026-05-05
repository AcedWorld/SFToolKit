using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000152 RID: 338
	internal struct CameraData
	{
		// Token: 0x06000AE7 RID: 2791 RVA: 0x0005AF10 File Offset: 0x00059110
		public void ResetIteration()
		{
			this.accumulatedWeight = 0f;
			this.currentIteration = 0U;
		}

		// Token: 0x04000C1D RID: 3101
		public uint width;

		// Token: 0x04000C1E RID: 3102
		public uint height;

		// Token: 0x04000C1F RID: 3103
		public bool skyEnabled;

		// Token: 0x04000C20 RID: 3104
		public bool fogEnabled;

		// Token: 0x04000C21 RID: 3105
		public AccelerationStructureSize accelSize;

		// Token: 0x04000C22 RID: 3106
		public float accumulatedWeight;

		// Token: 0x04000C23 RID: 3107
		public uint currentIteration;
	}
}
