using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200045C RID: 1116
	public class ObjectIdRequest
	{
		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06002584 RID: 9604 RVA: 0x000400A1 File Offset: 0x0003E2A1
		// (set) Token: 0x06002585 RID: 9605 RVA: 0x000400A9 File Offset: 0x0003E2A9
		public RenderTexture destination { get; set; }

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06002586 RID: 9606 RVA: 0x000400B2 File Offset: 0x0003E2B2
		// (set) Token: 0x06002587 RID: 9607 RVA: 0x000400BA File Offset: 0x0003E2BA
		public int mipLevel { get; set; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06002588 RID: 9608 RVA: 0x000400C3 File Offset: 0x0003E2C3
		// (set) Token: 0x06002589 RID: 9609 RVA: 0x000400CB File Offset: 0x0003E2CB
		public CubemapFace face { get; set; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x0600258A RID: 9610 RVA: 0x000400D4 File Offset: 0x0003E2D4
		// (set) Token: 0x0600258B RID: 9611 RVA: 0x000400DC File Offset: 0x0003E2DC
		public int slice { get; set; }

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x0600258C RID: 9612 RVA: 0x000400E5 File Offset: 0x0003E2E5
		// (set) Token: 0x0600258D RID: 9613 RVA: 0x000400ED File Offset: 0x0003E2ED
		public ObjectIdResult result { get; internal set; }

		// Token: 0x0600258E RID: 9614 RVA: 0x000400F6 File Offset: 0x0003E2F6
		public ObjectIdRequest(RenderTexture destination, int mipLevel = 0, CubemapFace face = CubemapFace.Unknown, int slice = 0)
		{
			this.destination = destination;
			this.mipLevel = mipLevel;
			this.face = face;
			this.slice = slice;
		}
	}
}
