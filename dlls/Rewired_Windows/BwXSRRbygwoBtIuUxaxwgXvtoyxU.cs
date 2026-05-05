using System;
using System.Threading;

// Token: 0x0200024A RID: 586
internal class BwXSRRbygwoBtIuUxaxwgXvtoyxU
{
	// Token: 0x14000026 RID: 38
	// (add) Token: 0x06000F25 RID: 3877 RVA: 0x0004586C File Offset: 0x00043A6C
	// (remove) Token: 0x06000F26 RID: 3878 RVA: 0x000458A4 File Offset: 0x00043AA4
	public event BwXSRRbygwoBtIuUxaxwgXvtoyxU.KLEPIcUKmiQSIWlLdBtqQJjjLrIO EHaiDsjgoEVhhXbOFUPUktPpVFiR;

	// Token: 0x14000027 RID: 39
	// (add) Token: 0x06000F27 RID: 3879 RVA: 0x000458DC File Offset: 0x00043ADC
	// (remove) Token: 0x06000F28 RID: 3880 RVA: 0x00045914 File Offset: 0x00043B14
	public event BwXSRRbygwoBtIuUxaxwgXvtoyxU.mboAhZfNdrpduMTttMHmConRRVoAA DFoKBQTVHJNdpjSMQvcLopaknbzu;

	// Token: 0x06000F29 RID: 3881 RVA: 0x00019BAE File Offset: 0x00017DAE
	public BwXSRRbygwoBtIuUxaxwgXvtoyxU(gGETNRbPSWqlyBUigXMEkvuRFmnB A_1)
	{
		this.MYQaAeFxlJCaMIUduILhVPvXUYtd = A_1;
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x0004594C File Offset: 0x00043B4C
	public void OLTTQOvOomiYvwXlJqbMPtPGDBUg()
	{
		Action action = new Action(this.xDLbaPqaqRdRkJKIRMhaFgRsFUErA);
		action.BeginInvoke(new AsyncCallback(BwXSRRbygwoBtIuUxaxwgXvtoyxU.KeJXHDfNnAwZXvpFkDkwEesDproo), action);
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x0004597C File Offset: 0x00043B7C
	private void xDLbaPqaqRdRkJKIRMhaFgRsFUErA()
	{
		bool flag = this.MYQaAeFxlJCaMIUduILhVPvXUYtd.GRjaFvgfGDGwZBcbodEqOqRJHXClA;
		if (flag != this.uEcnPUyflcrJbarANTdZFjqEbuA)
		{
			if (flag && this.EHaiDsjgoEVhhXbOFUPUktPpVFiR != null)
			{
				this.EHaiDsjgoEVhhXbOFUPUktPpVFiR();
			}
			else if (!flag && this.DFoKBQTVHJNdpjSMQvcLopaknbzu != null)
			{
				this.DFoKBQTVHJNdpjSMQvcLopaknbzu();
			}
			this.uEcnPUyflcrJbarANTdZFjqEbuA = flag;
		}
		Thread.Sleep(500);
		if (this.MYQaAeFxlJCaMIUduILhVPvXUYtd.UefnKBAkkgeeaFfkfwKbmuIPGEhBA)
		{
			this.OLTTQOvOomiYvwXlJqbMPtPGDBUg();
		}
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x00019BBD File Offset: 0x00017DBD
	private static void KeJXHDfNnAwZXvpFkDkwEesDproo(IAsyncResult A_0)
	{
		((Action)A_0.AsyncState).EndInvoke(A_0);
	}

	// Token: 0x04002A4A RID: 10826
	private readonly gGETNRbPSWqlyBUigXMEkvuRFmnB MYQaAeFxlJCaMIUduILhVPvXUYtd;

	// Token: 0x04002A4B RID: 10827
	private bool uEcnPUyflcrJbarANTdZFjqEbuA;

	// Token: 0x0200024B RID: 587
	// (Invoke) Token: 0x06000F2E RID: 3886
	public delegate void KLEPIcUKmiQSIWlLdBtqQJjjLrIO();

	// Token: 0x0200024C RID: 588
	// (Invoke) Token: 0x06000F32 RID: 3890
	public delegate void mboAhZfNdrpduMTttMHmConRRVoAA();
}
