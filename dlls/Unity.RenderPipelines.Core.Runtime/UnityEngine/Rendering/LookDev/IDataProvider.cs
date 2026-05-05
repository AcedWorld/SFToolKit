using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.LookDev
{
	// Token: 0x0200011A RID: 282
	public interface IDataProvider
	{
		// Token: 0x06000877 RID: 2167
		void FirstInitScene(StageRuntimeInterface stage);

		// Token: 0x06000878 RID: 2168
		void UpdateSky(Camera camera, Sky sky, StageRuntimeInterface stage);

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000879 RID: 2169
		IEnumerable<string> supportedDebugModes { get; }

		// Token: 0x0600087A RID: 2170
		void UpdateDebugMode(int debugIndex);

		// Token: 0x0600087B RID: 2171
		void GetShadowMask(ref RenderTexture output, StageRuntimeInterface stage);

		// Token: 0x0600087C RID: 2172
		void OnBeginRendering(StageRuntimeInterface stage);

		// Token: 0x0600087D RID: 2173
		void OnEndRendering(StageRuntimeInterface stage);

		// Token: 0x0600087E RID: 2174
		void Cleanup(StageRuntimeInterface SRI);
	}
}
