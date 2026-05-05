using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000016 RID: 22
	internal struct MinAndMax
	{
		// Token: 0x06000054 RID: 84 RVA: 0x0000278F File Offset: 0x0000098F
		public MinAndMax(float min, float max)
		{
			this.Min = min;
			this.Max = max;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000055 RID: 85 RVA: 0x0000279F File Offset: 0x0000099F
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000027A7 File Offset: 0x000009A7
		public float Min { readonly get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000027B0 File Offset: 0x000009B0
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000027B8 File Offset: 0x000009B8
		public float Max { readonly get; set; }
	}
}
