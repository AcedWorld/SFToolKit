using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200046E RID: 1134
	internal class VectorImageRenderInfoPool : LinkedPool<VectorImageRenderInfo>
	{
		// Token: 0x06002333 RID: 9011 RVA: 0x00088C8C File Offset: 0x00086E8C
		public VectorImageRenderInfoPool() : base(() => new VectorImageRenderInfo(), delegate(VectorImageRenderInfo vectorImageInfo)
		{
			vectorImageInfo.Reset();
		}, 10000)
		{
		}
	}
}
