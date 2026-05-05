using System;
using Rewired.Utils.Classes.Data;

// Token: 0x020002E4 RID: 740
internal class oPOwiIBMGNECtKWjLBTodfZcpRzbB : zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x060015B7 RID: 5559 RVA: 0x0001C35D File Offset: 0x0001A55D
	public oPOwiIBMGNECtKWjLBTodfZcpRzbB(byte A_1, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_2, oPOwiIBMGNECtKWjLBTodfZcpRzbB.aankzZbnLfoSaQWxDdlUyRdNJwZA A_3) : base(A_1, A_2)
	{
		this.rwlYZokRVLxCbSLZRloZDQdzJyVE = A_3;
		this.oBbCmhwshxdAuGgliMJapvmlFtEU = ((A_2.bitSize > 0) ? ((A_2.bitSize + 8 - 1) / 8) : 0);
		this.NPkovZDQZVgszBFZUScJaQBnGFqZA = A_2.dataIndex;
	}

	// Token: 0x060015B8 RID: 5560 RVA: 0x0001C398 File Offset: 0x0001A598
	public oPOwiIBMGNECtKWjLBTodfZcpRzbB(byte A_1, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_2, Func<int, int> A_3) : this(A_1, A_2, oPOwiIBMGNECtKWjLBTodfZcpRzbB.aankzZbnLfoSaQWxDdlUyRdNJwZA.Custom)
	{
		this.jtLVbOFehYeBgSMFovilySdnPhkX = A_3;
	}

	// Token: 0x060015B9 RID: 5561 RVA: 0x0004C304 File Offset: 0x0004A504
	public virtual void RhUEvWmtArQtyUBQocagMSrPYqrW(NativeBuffer A_1, double A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_1[0] != this.ZEmAzjmzLpNGaBBQPUjRDHfQsujS)
		{
			return;
		}
		this.xYAhtNDhVIzKbBABOhumHTuPtHhBA = A_2;
		if (this.oBbCmhwshxdAuGgliMJapvmlFtEU == 1)
		{
			this.EGzhEHTbRhYxMxjfUDqHmJQOmSxt = (int)A_1[this.NPkovZDQZVgszBFZUScJaQBnGFqZA];
		}
		else
		{
			this.EGzhEHTbRhYxMxjfUDqHmJQOmSxt = 0;
			for (int i = 0; i < this.oBbCmhwshxdAuGgliMJapvmlFtEU; i++)
			{
				this.EGzhEHTbRhYxMxjfUDqHmJQOmSxt |= (int)A_1[this.NPkovZDQZVgszBFZUScJaQBnGFqZA + i] << 8 * i;
			}
		}
		if (this.rwlYZokRVLxCbSLZRloZDQdzJyVE == oPOwiIBMGNECtKWjLBTodfZcpRzbB.aankzZbnLfoSaQWxDdlUyRdNJwZA.Custom && this.jtLVbOFehYeBgSMFovilySdnPhkX != null)
		{
			this.EGzhEHTbRhYxMxjfUDqHmJQOmSxt = this.jtLVbOFehYeBgSMFovilySdnPhkX(this.EGzhEHTbRhYxMxjfUDqHmJQOmSxt);
		}
	}

	// Token: 0x04002F4B RID: 12107
	public int EGzhEHTbRhYxMxjfUDqHmJQOmSxt;

	// Token: 0x04002F4C RID: 12108
	public double xYAhtNDhVIzKbBABOhumHTuPtHhBA;

	// Token: 0x04002F4D RID: 12109
	public readonly int oBbCmhwshxdAuGgliMJapvmlFtEU;

	// Token: 0x04002F4E RID: 12110
	public readonly int NPkovZDQZVgszBFZUScJaQBnGFqZA;

	// Token: 0x04002F4F RID: 12111
	public readonly oPOwiIBMGNECtKWjLBTodfZcpRzbB.aankzZbnLfoSaQWxDdlUyRdNJwZA rwlYZokRVLxCbSLZRloZDQdzJyVE;

	// Token: 0x04002F50 RID: 12112
	private Func<int, int> jtLVbOFehYeBgSMFovilySdnPhkX;

	// Token: 0x020002E5 RID: 741
	public enum aankzZbnLfoSaQWxDdlUyRdNJwZA
	{
		// Token: 0x04002F52 RID: 12114
		Default,
		// Token: 0x04002F53 RID: 12115
		Custom
	}
}
