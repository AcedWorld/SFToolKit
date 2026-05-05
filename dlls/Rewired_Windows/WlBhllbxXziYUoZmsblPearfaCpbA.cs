using System;
using Rewired.Utils.Classes.Data;

// Token: 0x020002D3 RID: 723
internal class WlBhllbxXziYUoZmsblPearfaCpbA : zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x06001583 RID: 5507 RVA: 0x0004BC10 File Offset: 0x00049E10
	public WlBhllbxXziYUoZmsblPearfaCpbA(byte A_1, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_2, bool A_3, int A_4) : base(A_1, A_2)
	{
		this.ndcxaOotBlyuPtDzjdhCTtkHcyxs = ((A_2.bitSize > 0) ? ((A_2.bitSize + 8 - 1) / 8) : 0);
		this.iyjZSeIyDNgguXWMOtWluFDbXNlE = A_2.dataIndex;
		this.jHpoZTISSQtcpWgYlGWCZymemOFs = A_3;
		this.HfOqFYwbVTDzQPkgOIEEWQFIDvuaA = A_2.logicalMin;
		this.AFkhYLfquLrBWJdUpsKHswLCexBdA = A_2.logicalMax;
		this.GSZMQmgLuRCwpBzwCiHjxiUTqucXA = A_4;
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x0004BC78 File Offset: 0x00049E78
	public virtual void AjvnBWZGKtBWwwYnpjTWLYTfktww(NativeBuffer A_1, double A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_1[0] != this.ZEmAzjmzLpNGaBBQPUjRDHfQsujS)
		{
			return;
		}
		this.sCdzJUqamixajJeJpgenFtEwgzSe = A_2;
		int num = 0;
		if (this.ndcxaOotBlyuPtDzjdhCTtkHcyxs > 1)
		{
			for (int i = 0; i < this.ndcxaOotBlyuPtDzjdhCTtkHcyxs; i++)
			{
				num |= (int)A_1[this.iyjZSeIyDNgguXWMOtWluFDbXNlE + i] << 8 * i;
			}
		}
		else
		{
			num = (int)A_1[this.iyjZSeIyDNgguXWMOtWluFDbXNlE];
		}
		this.vpLcQWUXVRJUFDyXpcrOXKudKkr = num;
	}

	// Token: 0x04002F07 RID: 12039
	public int vpLcQWUXVRJUFDyXpcrOXKudKkr;

	// Token: 0x04002F08 RID: 12040
	public double sCdzJUqamixajJeJpgenFtEwgzSe;

	// Token: 0x04002F09 RID: 12041
	public readonly int ndcxaOotBlyuPtDzjdhCTtkHcyxs;

	// Token: 0x04002F0A RID: 12042
	public readonly int iyjZSeIyDNgguXWMOtWluFDbXNlE;

	// Token: 0x04002F0B RID: 12043
	public readonly bool jHpoZTISSQtcpWgYlGWCZymemOFs;

	// Token: 0x04002F0C RID: 12044
	public readonly int HfOqFYwbVTDzQPkgOIEEWQFIDvuaA;

	// Token: 0x04002F0D RID: 12045
	public readonly int AFkhYLfquLrBWJdUpsKHswLCexBdA;

	// Token: 0x04002F0E RID: 12046
	public readonly int GSZMQmgLuRCwpBzwCiHjxiUTqucXA;
}
