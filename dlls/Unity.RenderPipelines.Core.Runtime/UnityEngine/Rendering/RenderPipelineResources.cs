using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000AB RID: 171
	public abstract class RenderPipelineResources : ScriptableObject
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0001B7F0 File Offset: 0x000199F0
		protected virtual string packagePath
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0001B7F3 File Offset: 0x000199F3
		internal string packagePath_Internal
		{
			get
			{
				return this.packagePath;
			}
		}
	}
}
