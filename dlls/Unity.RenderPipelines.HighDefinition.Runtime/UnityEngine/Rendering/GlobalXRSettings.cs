using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	public struct GlobalXRSettings
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000437C File Offset: 0x0000257C
		internal static GlobalXRSettings NewDefault()
		{
			return new GlobalXRSettings
			{
				singlePass = true,
				occlusionMesh = true,
				cameraJitter = false,
				allowMotionBlur = false
			};
		}

		// Token: 0x0400009D RID: 157
		public bool singlePass;

		// Token: 0x0400009E RID: 158
		public bool occlusionMesh;

		// Token: 0x0400009F RID: 159
		public bool cameraJitter;

		// Token: 0x040000A0 RID: 160
		public bool allowMotionBlur;
	}
}
