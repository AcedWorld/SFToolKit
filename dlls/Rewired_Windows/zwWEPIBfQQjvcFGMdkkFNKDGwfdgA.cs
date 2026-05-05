using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

// Token: 0x020002ED RID: 749
internal class zwWEPIBfQQjvcFGMdkkFNKDGwfdgA : zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x060015EF RID: 5615 RVA: 0x0004CC04 File Offset: 0x0004AE04
	public zwWEPIBfQQjvcFGMdkkFNKDGwfdgA(byte A_1, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchpadInfo A_2, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_3, int A_4, Action<NativeBuffer, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[]> A_5) : base(A_1, A_3)
	{
		this.zHaBxPWglcnCrPeQMuDUXYHyjwCi = A_2;
		this.EwKgvptewbOyNRCmOsawKWLBIQOJ = A_5;
		this.NGqOslOcJapYleFxEtGClskDCexz = new RingBuffer<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG>(A_4);
		this.FHJDJqZPbiYeBxCNlgudkQSdjqxn = new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[A_2.maxTouches];
		this.mbGotkNspciCdWUfwbxMijjJnXsL = new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[A_2.maxTouches];
		for (int i = 0; i < this.mbGotkNspciCdWUfwbxMijjJnXsL.Length; i++)
		{
			this.mbGotkNspciCdWUfwbxMijjJnXsL[i].Clear();
		}
		this.qqcLjAisBVqkPJVDNnATpOpkZTEc = new ObjectPool<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG>(A_4, new Func<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG>(this.ofcQYMkCRUsrhXiavxIsSbTBauPM), null);
	}

	// Token: 0x060015F0 RID: 5616 RVA: 0x0004CC98 File Offset: 0x0004AE98
	public virtual void MDNxxIlXzBFzteIFEvUkOFGGGwyE(NativeBuffer A_1, double A_2)
	{
		if (this.EwKgvptewbOyNRCmOsawKWLBIQOJ == null)
		{
			return;
		}
		this.EwKgvptewbOyNRCmOsawKWLBIQOJ(A_1, this.FHJDJqZPbiYeBxCNlgudkQSdjqxn);
		RingBuffer<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG> ngqOslOcJapYleFxEtGClskDCexz = this.NGqOslOcJapYleFxEtGClskDCexz;
		lock (ngqOslOcJapYleFxEtGClskDCexz)
		{
			zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG gxkRBuPHezDuzJEusFemIKUtvtJG = this.qqcLjAisBVqkPJVDNnATpOpkZTEc.Get();
			for (int i = 0; i < this.zHaBxPWglcnCrPeQMuDUXYHyjwCi.maxTouches; i++)
			{
				gxkRBuPHezDuzJEusFemIKUtvtJG.HIpilCgmHTjnmhZiFIIQxyuMmFkS[i] = this.FHJDJqZPbiYeBxCNlgudkQSdjqxn[i];
			}
			bool flag2;
			CollectionTools.Enqueue<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG>(this.qqcLjAisBVqkPJVDNnATpOpkZTEc, this.NGqOslOcJapYleFxEtGClskDCexz, gxkRBuPHezDuzJEusFemIKUtvtJG, out flag2);
		}
		this.vkUeRYIQcLSTbTFbhCNvnXqTYzVd();
	}

	// Token: 0x060015F1 RID: 5617 RVA: 0x0004CD48 File Offset: 0x0004AF48
	public void vkUeRYIQcLSTbTFbhCNvnXqTYzVd()
	{
		for (int i = 0; i < this.mbGotkNspciCdWUfwbxMijjJnXsL.Length; i++)
		{
			this.mbGotkNspciCdWUfwbxMijjJnXsL[i].Clear();
		}
		RingBuffer<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG> ngqOslOcJapYleFxEtGClskDCexz = this.NGqOslOcJapYleFxEtGClskDCexz;
		lock (ngqOslOcJapYleFxEtGClskDCexz)
		{
			int j = this.NGqOslOcJapYleFxEtGClskDCexz.Count;
			while (j > 0)
			{
				zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG gxkRBuPHezDuzJEusFemIKUtvtJG = this.NGqOslOcJapYleFxEtGClskDCexz.Dequeue();
				j--;
				for (int k = 0; k < gxkRBuPHezDuzJEusFemIKUtvtJG.HIpilCgmHTjnmhZiFIIQxyuMmFkS.Length; k++)
				{
					this.zHaBxPWglcnCrPeQMuDUXYHyjwCi.CalculateTouch(ref gxkRBuPHezDuzJEusFemIKUtvtJG.HIpilCgmHTjnmhZiFIIQxyuMmFkS[k]);
					this.mbGotkNspciCdWUfwbxMijjJnXsL[k] = gxkRBuPHezDuzJEusFemIKUtvtJG.HIpilCgmHTjnmhZiFIIQxyuMmFkS[k];
				}
				this.qqcLjAisBVqkPJVDNnATpOpkZTEc.Return(gxkRBuPHezDuzJEusFemIKUtvtJG);
			}
		}
	}

	// Token: 0x060015F2 RID: 5618 RVA: 0x0004CE24 File Offset: 0x0004B024
	public bool tgKrcXnHuYRQqdFCcKwYoFPjhrei(int A_1)
	{
		for (int i = 0; i < this.mbGotkNspciCdWUfwbxMijjJnXsL.Length; i++)
		{
			if (this.mbGotkNspciCdWUfwbxMijjJnXsL[i].isTouching && this.mbGotkNspciCdWUfwbxMijjJnXsL[i].touchId == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060015F3 RID: 5619 RVA: 0x0001C603 File Offset: 0x0001A803
	[CompilerGenerated]
	private zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG ofcQYMkCRUsrhXiavxIsSbTBauPM()
	{
		return new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG(this.zHaBxPWglcnCrPeQMuDUXYHyjwCi.maxTouches);
	}

	// Token: 0x04002F74 RID: 12148
	private zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchpadInfo zHaBxPWglcnCrPeQMuDUXYHyjwCi;

	// Token: 0x04002F75 RID: 12149
	private RingBuffer<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG> NGqOslOcJapYleFxEtGClskDCexz;

	// Token: 0x04002F76 RID: 12150
	private zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] FHJDJqZPbiYeBxCNlgudkQSdjqxn;

	// Token: 0x04002F77 RID: 12151
	private Action<NativeBuffer, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[]> EwKgvptewbOyNRCmOsawKWLBIQOJ;

	// Token: 0x04002F78 RID: 12152
	public zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] mbGotkNspciCdWUfwbxMijjJnXsL;

	// Token: 0x04002F79 RID: 12153
	private ObjectPool<zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.GXkRBuPHezDuzJEusFemIKUtvtJG> qqcLjAisBVqkPJVDNnATpOpkZTEc;

	// Token: 0x020002EE RID: 750
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TouchpadInfo
	{
		// Token: 0x060015F4 RID: 5620 RVA: 0x0001C615 File Offset: 0x0001A815
		public TouchpadInfo(int A_1, int A_2, int A_3, int A_4, int A_5, bool A_6, bool A_7)
		{
			this.maxTouches = A_1;
			this.minX = A_2;
			this.maxX = A_3;
			this.minY = A_4;
			this.maxY = A_5;
			this.invertY = A_6;
			this.reverseY = A_7;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0004CE70 File Offset: 0x0004B070
		public void CalculateTouch(ref zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData data)
		{
			int num = this.reverseY ? (this.maxY - data.positionRawY) : data.positionRawY;
			data.positionX = MathTools.ValueInNewRange((float)data.positionRawX, (float)this.minX, (float)this.maxX, 0f, 1f);
			data.positionY = MathTools.ValueInNewRange((float)num, (float)this.minY, (float)this.maxY, 0f, 1f);
			data.positionAbsX = data.positionRawX;
			data.positionAbsY = num;
			if (data.positionAbsX > this.maxX)
			{
				data.positionAbsX = this.maxX;
			}
			if (data.positionAbsY > this.maxY)
			{
				data.positionAbsY = this.maxY;
			}
			if (data.positionAbsX < this.minX)
			{
				data.positionAbsX = this.minX;
			}
			if (data.positionAbsY < this.minY)
			{
				data.positionAbsY = this.minY;
			}
			if (this.invertY)
			{
				data.positionY *= -1f;
				data.positionAbsY *= -1;
			}
		}

		// Token: 0x04002F7A RID: 12154
		public int maxTouches;

		// Token: 0x04002F7B RID: 12155
		public int minX;

		// Token: 0x04002F7C RID: 12156
		public int maxX;

		// Token: 0x04002F7D RID: 12157
		public int minY;

		// Token: 0x04002F7E RID: 12158
		public int maxY;

		// Token: 0x04002F7F RID: 12159
		public bool invertY;

		// Token: 0x04002F80 RID: 12160
		public bool reverseY;
	}

	// Token: 0x020002EF RID: 751
	private class GXkRBuPHezDuzJEusFemIKUtvtJG
	{
		// Token: 0x060015F6 RID: 5622 RVA: 0x0001C652 File Offset: 0x0001A852
		public GXkRBuPHezDuzJEusFemIKUtvtJG(int A_1)
		{
			this.HIpilCgmHTjnmhZiFIIQxyuMmFkS = new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[A_1];
		}

		// Token: 0x04002F81 RID: 12161
		public readonly zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] HIpilCgmHTjnmhZiFIIQxyuMmFkS;
	}

	// Token: 0x020002F0 RID: 752
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct TouchData
	{
		// Token: 0x060015F7 RID: 5623 RVA: 0x0004CF88 File Offset: 0x0004B188
		public void Clear()
		{
			this.touchId = -1;
			this.timeStamp = 0f;
			this.isTouching = false;
			this.positionRawX = 0;
			this.positionRawY = 0;
			this.positionX = 0f;
			this.positionY = 0f;
			this.positionAbsX = 0;
			this.positionAbsY = 0;
		}

		// Token: 0x04002F82 RID: 12162
		public int touchId;

		// Token: 0x04002F83 RID: 12163
		public float timeStamp;

		// Token: 0x04002F84 RID: 12164
		public bool isTouching;

		// Token: 0x04002F85 RID: 12165
		public int positionRawX;

		// Token: 0x04002F86 RID: 12166
		public int positionRawY;

		// Token: 0x04002F87 RID: 12167
		public float positionX;

		// Token: 0x04002F88 RID: 12168
		public float positionY;

		// Token: 0x04002F89 RID: 12169
		public int positionAbsX;

		// Token: 0x04002F8A RID: 12170
		public int positionAbsY;
	}
}
