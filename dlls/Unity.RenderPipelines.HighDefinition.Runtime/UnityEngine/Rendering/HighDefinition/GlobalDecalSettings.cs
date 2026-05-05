using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000FC RID: 252
	[Serializable]
	public struct GlobalDecalSettings
	{
		// Token: 0x060009E4 RID: 2532 RVA: 0x000554E4 File Offset: 0x000536E4
		internal static GlobalDecalSettings NewDefault()
		{
			return new GlobalDecalSettings
			{
				drawDistance = 1000,
				atlasWidth = 4096,
				atlasHeight = 4096
			};
		}

		// Token: 0x04000AB6 RID: 2742
		public int drawDistance;

		// Token: 0x04000AB7 RID: 2743
		public int atlasWidth;

		// Token: 0x04000AB8 RID: 2744
		public int atlasHeight;

		// Token: 0x04000AB9 RID: 2745
		public bool perChannelMask;
	}
}
