using System;
using Rewired.Utils;

// Token: 0x020002FB RID: 763
internal class UnptiYUxBEDyXRujUEnkdeIKIoPk
{
	// Token: 0x1400002D RID: 45
	// (add) Token: 0x0600160A RID: 5642 RVA: 0x0004D628 File Offset: 0x0004B828
	// (remove) Token: 0x0600160B RID: 5643 RVA: 0x0004D660 File Offset: 0x0004B860
	public event Action ztNbeMSTMsaUVsclhemevRUkIIOp;

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x0001C73C File Offset: 0x0001A93C
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x0001C74A File Offset: 0x0001A94A
	public float kEsBudgJSBjLmBXIUoFwHyyKoNffb
	{
		get
		{
			return this.fWVGltOpfXXwmxtYelPZyvGKdlJk(this.HFVYGbtFLyRpFFhyjEuedVEPqaQCb);
		}
		set
		{
			this.HFVYGbtFLyRpFFhyjEuedVEPqaQCb = this.jCeIKwlGarahmNWghNurEYJxbPHj(value);
			if (this.ztNbeMSTMsaUVsclhemevRUkIIOp != null)
			{
				this.ztNbeMSTMsaUVsclhemevRUkIIOp();
			}
		}
	}

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x0001C76C File Offset: 0x0001A96C
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x0001C774 File Offset: 0x0001A974
	public int jytYrChQDenkTUaEnqBMeGDoorVS
	{
		get
		{
			return this.HFVYGbtFLyRpFFhyjEuedVEPqaQCb;
		}
		set
		{
			this.HFVYGbtFLyRpFFhyjEuedVEPqaQCb = value;
			if (this.ztNbeMSTMsaUVsclhemevRUkIIOp != null)
			{
				this.ztNbeMSTMsaUVsclhemevRUkIIOp();
			}
		}
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x0001C790 File Offset: 0x0001A990
	public UnptiYUxBEDyXRujUEnkdeIKIoPk(int A_1, int A_2)
	{
		this.MKKdqUKLFHvuMdZdZFKpFkUberBA = A_1;
		this.znBesahGTjGbDwKovGtGObiPMPcD = A_2;
	}

	// Token: 0x06001611 RID: 5649 RVA: 0x0001C7A6 File Offset: 0x0001A9A6
	private float fWVGltOpfXXwmxtYelPZyvGKdlJk(int A_1)
	{
		return MathTools.Clamp((float)A_1 / (float)this.znBesahGTjGbDwKovGtGObiPMPcD, 0f, 1f);
	}

	// Token: 0x06001612 RID: 5650 RVA: 0x0001C7C1 File Offset: 0x0001A9C1
	private int jCeIKwlGarahmNWghNurEYJxbPHj(float A_1)
	{
		return MathTools.Clamp((int)(A_1 * (float)this.znBesahGTjGbDwKovGtGObiPMPcD), this.MKKdqUKLFHvuMdZdZFKpFkUberBA, this.znBesahGTjGbDwKovGtGObiPMPcD);
	}

	// Token: 0x0400310E RID: 12558
	private int HFVYGbtFLyRpFFhyjEuedVEPqaQCb;

	// Token: 0x0400310F RID: 12559
	private int MKKdqUKLFHvuMdZdZFKpFkUberBA;

	// Token: 0x04003110 RID: 12560
	private int znBesahGTjGbDwKovGtGObiPMPcD;
}
