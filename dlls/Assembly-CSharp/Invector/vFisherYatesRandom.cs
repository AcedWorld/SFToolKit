using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200033F RID: 831
	public class vFisherYatesRandom
	{
		// Token: 0x06001116 RID: 4374 RVA: 0x0005CB5C File Offset: 0x0005AD5C
		public int Next(int len)
		{
			if (len <= 1)
			{
				return 0;
			}
			if (this.randomIndices == null || this.randomIndices.Length != len)
			{
				this.randomIndices = new int[len];
				for (int i = 0; i < this.randomIndices.Length; i++)
				{
					this.randomIndices[i] = i;
				}
			}
			if (this.randomIndex == 0)
			{
				int num = 0;
				do
				{
					for (int j = 0; j < len - 1; j++)
					{
						int num2 = Random.Range(j, len);
						if (num2 != j)
						{
							int num3 = this.randomIndices[j];
							this.randomIndices[j] = this.randomIndices[num2];
							this.randomIndices[num2] = num3;
						}
					}
				}
				while (this.prevValue == this.randomIndices[0] && ++num < 10);
			}
			int result = this.randomIndices[this.randomIndex];
			int num4 = this.randomIndex + 1;
			this.randomIndex = num4;
			if (num4 >= this.randomIndices.Length)
			{
				this.randomIndex = 0;
			}
			this.prevValue = result;
			return result;
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0005CC4C File Offset: 0x0005AE4C
		public int Range(int min, int max)
		{
			int num = max - min + 1;
			if (num <= 1)
			{
				return max;
			}
			if (this.randomIndices == null || this.randomIndices.Length != num)
			{
				this.randomIndices = new int[num];
				for (int i = 0; i < this.randomIndices.Length; i++)
				{
					this.randomIndices[i] = min + i;
				}
			}
			if (this.randomIndex == 0)
			{
				int num2 = 0;
				do
				{
					for (int j = 0; j < num - 1; j++)
					{
						int num3 = Random.Range(j, num);
						if (num3 != j)
						{
							int num4 = this.randomIndices[j];
							this.randomIndices[j] = this.randomIndices[num3];
							this.randomIndices[num3] = num4;
						}
					}
				}
				while (this.prevValue == this.randomIndices[0] && ++num2 < 10);
			}
			int result = this.randomIndices[this.randomIndex];
			int num5 = this.randomIndex + 1;
			this.randomIndex = num5;
			if (num5 >= this.randomIndices.Length)
			{
				this.randomIndex = 0;
			}
			this.prevValue = result;
			return result;
		}

		// Token: 0x040016F8 RID: 5880
		private int[] randomIndices;

		// Token: 0x040016F9 RID: 5881
		private int randomIndex;

		// Token: 0x040016FA RID: 5882
		private int prevValue = -1;
	}
}
