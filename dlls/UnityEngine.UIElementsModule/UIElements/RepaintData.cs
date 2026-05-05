using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000290 RID: 656
	internal class RepaintData
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x000413CC File Offset: 0x0003F5CC
		// (set) Token: 0x06001240 RID: 4672 RVA: 0x000413D4 File Offset: 0x0003F5D4
		public Matrix4x4 currentOffset { get; set; } = Matrix4x4.identity;

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06001241 RID: 4673 RVA: 0x000413DD File Offset: 0x0003F5DD
		// (set) Token: 0x06001242 RID: 4674 RVA: 0x000413E5 File Offset: 0x0003F5E5
		public Vector2 mousePosition { get; set; }

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06001243 RID: 4675 RVA: 0x000413EE File Offset: 0x0003F5EE
		// (set) Token: 0x06001244 RID: 4676 RVA: 0x000413F6 File Offset: 0x0003F5F6
		public Rect currentWorldClip { get; set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06001245 RID: 4677 RVA: 0x000413FF File Offset: 0x0003F5FF
		// (set) Token: 0x06001246 RID: 4678 RVA: 0x00041407 File Offset: 0x0003F607
		public Event repaintEvent { get; set; }
	}
}
