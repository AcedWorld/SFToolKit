using System;
using System.Collections.Generic;

namespace UnityEngine
{
	// Token: 0x02000285 RID: 645
	internal class MeshSubsetCombineUtility
	{
		// Token: 0x02000286 RID: 646
		public struct MeshInstance
		{
			// Token: 0x0400092B RID: 2347
			public int meshInstanceID;

			// Token: 0x0400092C RID: 2348
			public int rendererInstanceID;

			// Token: 0x0400092D RID: 2349
			public int additionalVertexStreamsMeshInstanceID;

			// Token: 0x0400092E RID: 2350
			public int enlightenVertexStreamMeshInstanceID;

			// Token: 0x0400092F RID: 2351
			public Matrix4x4 transform;

			// Token: 0x04000930 RID: 2352
			public Vector4 lightmapScaleOffset;

			// Token: 0x04000931 RID: 2353
			public Vector4 realtimeLightmapScaleOffset;
		}

		// Token: 0x02000287 RID: 647
		public struct SubMeshInstance
		{
			// Token: 0x04000932 RID: 2354
			public int meshInstanceID;

			// Token: 0x04000933 RID: 2355
			public int vertexOffset;

			// Token: 0x04000934 RID: 2356
			public int gameObjectInstanceID;

			// Token: 0x04000935 RID: 2357
			public int subMeshIndex;

			// Token: 0x04000936 RID: 2358
			public Matrix4x4 transform;
		}

		// Token: 0x02000288 RID: 648
		public struct MeshContainer
		{
			// Token: 0x04000937 RID: 2359
			public GameObject gameObject;

			// Token: 0x04000938 RID: 2360
			public MeshSubsetCombineUtility.MeshInstance instance;

			// Token: 0x04000939 RID: 2361
			public List<MeshSubsetCombineUtility.SubMeshInstance> subMeshInstances;
		}
	}
}
