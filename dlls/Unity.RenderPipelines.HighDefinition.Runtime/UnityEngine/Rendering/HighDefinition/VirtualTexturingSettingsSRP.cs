using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001CC RID: 460
	[Serializable]
	internal sealed class VirtualTexturingSettingsSRP
	{
		// Token: 0x040015DC RID: 5596
		public int streamingCpuCacheSizeInMegaBytes = 256;

		// Token: 0x040015DD RID: 5597
		public int streamingMipPreloadTexturesPerFrame;

		// Token: 0x040015DE RID: 5598
		public int streamingPreloadMipCount = 1;

		// Token: 0x040015DF RID: 5599
		public List<GPUCacheSettingSRP> streamingGpuCacheSettings = new List<GPUCacheSettingSRP>
		{
			new GPUCacheSettingSRP
			{
				format = GraphicsFormat.None,
				sizeInMegaBytes = 128U
			}
		};
	}
}
