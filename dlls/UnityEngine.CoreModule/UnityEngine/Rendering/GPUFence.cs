using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E3 RID: 995
	[Obsolete("GPUFence has been deprecated. Use GraphicsFence instead (UnityUpgradable) -> GraphicsFence", false)]
	public struct GPUFence
	{
		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x00037FA8 File Offset: 0x000361A8
		public bool passed
		{
			get
			{
				return true;
			}
		}
	}
}
