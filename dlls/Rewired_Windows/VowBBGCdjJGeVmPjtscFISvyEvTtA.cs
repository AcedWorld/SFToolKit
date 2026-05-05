using System;
using Rewired.Utils.Classes.Data;

// Token: 0x020002D2 RID: 722
internal class VowBBGCdjJGeVmPjtscFISvyEvTtA : zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x06001580 RID: 5504 RVA: 0x0004BB04 File Offset: 0x00049D04
	public VowBBGCdjJGeVmPjtscFISvyEvTtA(byte A_1, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_2, int A_3, Action<byte[], float[]> A_4) : base(A_1, A_2)
	{
		this.bmIgCitWoujyBdynciLMEvcTpTQEb = A_3;
		this.xfyGOMVuDhRtjrtzhFpLnrULpGwy = A_4;
		this.TiDElcBqwwAZchlcQwEEEwreauwmA = ((A_2.bitSize > 0) ? ((A_2.bitSize + 8 - 1) / 8) : 0);
		this.DwKxyyqUPmxvKBzFIkfeAORvCaFE = A_2.dataIndex;
		this.DyyNNEiNyALpzNlDLachIcOtFWh = new byte[this.TiDElcBqwwAZchlcQwEEEwreauwmA];
		this.wxlPSRPpXOGcnsgwYrXChZnlGJzD = new float[A_3];
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x0004BB70 File Offset: 0x00049D70
	public virtual void duDothfFQGDbbPWwjewypheCKZtN(NativeBuffer A_1, double A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_1[0] != this.ZEmAzjmzLpNGaBBQPUjRDHfQsujS)
		{
			return;
		}
		this.qajiebhlsRSSDHNAcThHraIWSqrVA = A_2;
		for (int i = 0; i < this.TiDElcBqwwAZchlcQwEEEwreauwmA; i++)
		{
			this.DyyNNEiNyALpzNlDLachIcOtFWh[i] = A_1[this.DwKxyyqUPmxvKBzFIkfeAORvCaFE + i];
		}
		if (this.xfyGOMVuDhRtjrtzhFpLnrULpGwy != null)
		{
			this.xfyGOMVuDhRtjrtzhFpLnrULpGwy(this.DyyNNEiNyALpzNlDLachIcOtFWh, this.wxlPSRPpXOGcnsgwYrXChZnlGJzD);
		}
	}

	// Token: 0x06001582 RID: 5506 RVA: 0x0004BBE0 File Offset: 0x00049DE0
	public void FpCwODEIjuKvuVLoRIeFtScfpQRh(float[] A_1, double A_2)
	{
		this.qajiebhlsRSSDHNAcThHraIWSqrVA = A_2;
		for (int i = 0; i < this.bmIgCitWoujyBdynciLMEvcTpTQEb; i++)
		{
			this.wxlPSRPpXOGcnsgwYrXChZnlGJzD[i] = A_1[i];
		}
	}

	// Token: 0x04002F00 RID: 12032
	public readonly float[] wxlPSRPpXOGcnsgwYrXChZnlGJzD;

	// Token: 0x04002F01 RID: 12033
	public double qajiebhlsRSSDHNAcThHraIWSqrVA;

	// Token: 0x04002F02 RID: 12034
	public readonly int bmIgCitWoujyBdynciLMEvcTpTQEb;

	// Token: 0x04002F03 RID: 12035
	private readonly byte[] DyyNNEiNyALpzNlDLachIcOtFWh;

	// Token: 0x04002F04 RID: 12036
	private readonly int TiDElcBqwwAZchlcQwEEEwreauwmA;

	// Token: 0x04002F05 RID: 12037
	private readonly int DwKxyyqUPmxvKBzFIkfeAORvCaFE;

	// Token: 0x04002F06 RID: 12038
	private readonly Action<byte[], float[]> xfyGOMVuDhRtjrtzhFpLnrULpGwy;
}
