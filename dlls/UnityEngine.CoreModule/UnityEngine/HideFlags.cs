using System;

namespace UnityEngine
{
	// Token: 0x02000267 RID: 615
	[Flags]
	public enum HideFlags
	{
		// Token: 0x040008EC RID: 2284
		None = 0,
		// Token: 0x040008ED RID: 2285
		HideInHierarchy = 1,
		// Token: 0x040008EE RID: 2286
		HideInInspector = 2,
		// Token: 0x040008EF RID: 2287
		DontSaveInEditor = 4,
		// Token: 0x040008F0 RID: 2288
		NotEditable = 8,
		// Token: 0x040008F1 RID: 2289
		DontSaveInBuild = 16,
		// Token: 0x040008F2 RID: 2290
		DontUnloadUnusedAsset = 32,
		// Token: 0x040008F3 RID: 2291
		DontSave = 52,
		// Token: 0x040008F4 RID: 2292
		HideAndDontSave = 61
	}
}
