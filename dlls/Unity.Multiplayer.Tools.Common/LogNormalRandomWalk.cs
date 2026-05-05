using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	internal class LogNormalRandomWalk
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002683 File Offset: 0x00000883
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000268B File Offset: 0x0000088B
		public float Rate { get; set; } = 1f;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002694 File Offset: 0x00000894
		// (set) Token: 0x0600004B RID: 75 RVA: 0x0000269C File Offset: 0x0000089C
		public float Min { get; set; } = 0.01f;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000026A5 File Offset: 0x000008A5
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000026AD File Offset: 0x000008AD
		public float Max { get; set; } = 10f;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000026B6 File Offset: 0x000008B6
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000026BE File Offset: 0x000008BE
		public float Value { get; private set; } = 1f;

		// Token: 0x06000050 RID: 80 RVA: 0x000026C8 File Offset: 0x000008C8
		public float NextFloat(Random random)
		{
			float num = Mathf.Exp(this.Rate * (float)(random.NextDouble() - 0.5));
			this.Value *= num;
			this.Value = Mathf.Clamp(this.Value, this.Min, this.Max);
			return this.Value;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002724 File Offset: 0x00000924
		public int NextInt(Random random)
		{
			return (int)Mathf.Round(this.NextFloat(random));
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002734 File Offset: 0x00000934
		public void Repeat(Random random, Action action)
		{
			int num = this.NextInt(random);
			for (int i = 0; i < num; i++)
			{
				action();
			}
		}
	}
}
