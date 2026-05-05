using System;

namespace UnityEngine
{
	// Token: 0x0200022C RID: 556
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class CreateAssetMenuAttribute : Attribute
	{
		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001848 RID: 6216 RVA: 0x00028520 File Offset: 0x00026720
		// (set) Token: 0x06001849 RID: 6217 RVA: 0x00028528 File Offset: 0x00026728
		public string menuName { get; set; }

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x0600184A RID: 6218 RVA: 0x00028531 File Offset: 0x00026731
		// (set) Token: 0x0600184B RID: 6219 RVA: 0x00028539 File Offset: 0x00026739
		public string fileName { get; set; }

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x0600184C RID: 6220 RVA: 0x00028542 File Offset: 0x00026742
		// (set) Token: 0x0600184D RID: 6221 RVA: 0x0002854A File Offset: 0x0002674A
		public int order { get; set; }
	}
}
