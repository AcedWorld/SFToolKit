using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

// Token: 0x020002CF RID: 719
internal class hCScdGJDBOkdnOPGkrrPXBSVwrVO : ccXakXCgrJLXlFnKEJgyvIhrSJFOb, gAkEWbhxgbYyrIrsrBCPaLxymaOwA, QWwLqtkMlbiJnhExHgcNehpVJThK, IDisposable
{
	// Token: 0x1700035E RID: 862
	// (get) Token: 0x0600155E RID: 5470 RVA: 0x0001BECA File Offset: 0x0001A0CA
	public bool[] gKbblzjVtjOCKIcvOfqHxmwXJSnG
	{
		get
		{
			if (this.HNXfSWJRixJxdEIKdPomPAjjePAdb.Current == null)
			{
				return null;
			}
			return this.HNXfSWJRixJxdEIKdPomPAjjePAdb.Current.effectiveValue;
		}
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x0001BEEB File Offset: 0x0001A0EB
	public hCScdGJDBOkdnOPGkrrPXBSVwrVO(gdTQNPtfPdCCoXDeSpbzXzWFikml A_1, AwnnodsOIsxGkOjbmSXwCAEEhdBEA A_2) : this(A_1, A_2, KcBnCtRRUXbgShJnEUIrDApWFHEo.Joystick)
	{
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x0001BEF6 File Offset: 0x0001A0F6
	protected hCScdGJDBOkdnOPGkrrPXBSVwrVO(gdTQNPtfPdCCoXDeSpbzXzWFikml A_1, AwnnodsOIsxGkOjbmSXwCAEEhdBEA A_2, KcBnCtRRUXbgShJnEUIrDApWFHEo A_3) : this(A_1, A_2, A_3, A_2.SnkezaHKcWUgcPvYgaLIAwTFDbeTA, A_2.kWRnaPMqchyeUQUAhEyMQQBogOqA, A_2.QDNrcALgRxLhouPVMMqyxOiNYfr, A_2.aTDDxkffbnXcdBmOnWImviJYVQkVA)
	{
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x0004B44C File Offset: 0x0004964C
	protected hCScdGJDBOkdnOPGkrrPXBSVwrVO(cfxHuPCEmxaZkGhZDavRmWdnXrKUB A_1, AwnnodsOIsxGkOjbmSXwCAEEhdBEA A_2, KcBnCtRRUXbgShJnEUIrDApWFHEo A_3, int A_4, int A_5, int A_6, int A_7) : base(A_1, A_2, A_3)
	{
		this.weYNykGeaeJPGTeemBIJNvhgAhDhA = A_4;
		this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ = A_5;
		this.NCcdAGECmHFpVEVVbOSPAVbTZaMhb = A_6;
		this.BBxLtqMFCkQwwQILXhkollYIWtuJ = A_7;
		if (A_5 > 0)
		{
			this.zqIBYNNQpHArwegNeIOwbOdIazKbc = new short[A_5];
		}
		this.HNXfSWJRixJxdEIKdPomPAjjePAdb = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, A_4);
		if (A_6 > 0)
		{
			this.PQQMlBCmuJAufXlVIatqjAmVRsbB = new short[A_6];
		}
		if (A_7 > 0)
		{
			this.ltLplqijswQZJQDwALVJYGqKulAO = new short[A_7 * 2];
		}
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x0004B4D8 File Offset: 0x000496D8
	public void TjyrgwYLenviWzlVzwvKQhCXIANw(ahUUPlizYNgaLHTIoVYkrEwoekAt A_1, byte A_2, short A_3, double A_4)
	{
		this.HbsBKokdZeLKMkPqRMYYgyhfJGsuB = true;
		switch (A_1)
		{
		case ahUUPlizYNgaLHTIoVYkrEwoekAt.Button:
			if ((int)A_2 >= this.weYNykGeaeJPGTeemBIJNvhgAhDhA)
			{
				return;
			}
			this.HNXfSWJRixJxdEIKdPomPAjjePAdb.SetValue((int)A_2, A_3 > 0, A_4);
			return;
		case ahUUPlizYNgaLHTIoVYkrEwoekAt.Axis:
			if ((int)A_2 >= this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ)
			{
				return;
			}
			this.zqIBYNNQpHArwegNeIOwbOdIazKbc[(int)A_2] = A_3;
			return;
		case ahUUPlizYNgaLHTIoVYkrEwoekAt.Hat:
			if ((int)A_2 >= this.NCcdAGECmHFpVEVVbOSPAVbTZaMhb)
			{
				return;
			}
			this.PQQMlBCmuJAufXlVIatqjAmVRsbB[(int)A_2] = A_3;
			return;
		case ahUUPlizYNgaLHTIoVYkrEwoekAt.Ball:
			if ((int)A_2 >= this.BBxLtqMFCkQwwQILXhkollYIWtuJ)
			{
				return;
			}
			this.ltLplqijswQZJQDwALVJYGqKulAO[(int)A_2] = A_3;
			return;
		default:
			throw new NotImplementedException();
		}
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x0001BF19 File Offset: 0x0001A119
	public override void jhrjQWWIhyHFSgsZMpAkLybqogDvA(UpdateLoopType A_1)
	{
		this.HNXfSWJRixJxdEIKdPomPAjjePAdb.SetUpdateLoop(A_1);
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x0001BF27 File Offset: 0x0001A127
	public override void BFWZNWbMSYBBaJhRACGnXookekEuA()
	{
		this.HNXfSWJRixJxdEIKdPomPAjjePAdb.Current.ClearWasTrueThisFrame();
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001565 RID: 5477 RVA: 0x0001BF39 File Offset: 0x0001A139
	public int wRPKEIiIMIiVkFuDoAhjfeDkorcvB
	{
		get
		{
			return this.qznrZSkVufiYjJZVBqxucrCPBJPh;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001566 RID: 5478 RVA: 0x0001BF41 File Offset: 0x0001A141
	public int aRRgiRVgPIFTpWYYFshJIMpuFgwP
	{
		get
		{
			return this.weYNykGeaeJPGTeemBIJNvhgAhDhA;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001567 RID: 5479 RVA: 0x0001BF49 File Offset: 0x0001A149
	public int KCoPWTNCdmhpOfarIjSQwtNBOnGhb
	{
		get
		{
			return this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ;
		}
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001568 RID: 5480 RVA: 0x0001BF51 File Offset: 0x0001A151
	public int LvoZSYWOkcOyruNQCtYUOxHhDWw
	{
		get
		{
			return this.NCcdAGECmHFpVEVVbOSPAVbTZaMhb;
		}
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001569 RID: 5481 RVA: 0x0001BF59 File Offset: 0x0001A159
	public int jcevaTqoXURshLLufrZVrWRkrWkG
	{
		get
		{
			return this.BBxLtqMFCkQwwQILXhkollYIWtuJ;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600156A RID: 5482 RVA: 0x0001BF61 File Offset: 0x0001A161
	public bool FfIPJdaSbRTJFYzHWpwbbsbLHUJp
	{
		get
		{
			return this.weYNykGeaeJPGTeemBIJNvhgAhDhA > 0 || this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ > 0 || this.NCcdAGECmHFpVEVVbOSPAVbTZaMhb > 0 || this.BBxLtqMFCkQwwQILXhkollYIWtuJ > 0;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x0600156B RID: 5483 RVA: 0x0001B9A5 File Offset: 0x00019BA5
	public InputSource seDogDOvnVvWEUwimMlEDLfvKjSl
	{
		get
		{
			return InputSource.SDL2;
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x0600156C RID: 5484 RVA: 0x0001BF89 File Offset: 0x0001A189
	public bool FEcqYuiRLeUGPlsgxtjmPVTQMIYp
	{
		get
		{
			return this.HbsBKokdZeLKMkPqRMYYgyhfJGsuB;
		}
	}

	// Token: 0x0600156D RID: 5485 RVA: 0x0001BF91 File Offset: 0x0001A191
	public float ZWiXJWjqmdWCtbiIONNYdLuPuUOT(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ)
		{
			return 0f;
		}
		return this.fWfIxJkZarchdhYYrAyKoGDlflSt((int)this.zqIBYNNQpHArwegNeIOwbOdIazKbc[A_1]);
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x0001BFB4 File Offset: 0x0001A1B4
	public int QoJHFIIyXbhzgFCIjsQySkTRGgyH(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.AHfjHOjsUdHLhQmAriXOVCtHRBcQ)
		{
			return 0;
		}
		return (int)this.zqIBYNNQpHArwegNeIOwbOdIazKbc[A_1];
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x0001BFCD File Offset: 0x0001A1CD
	public bool BLhrHvfnwHXxAXmkRmbyakCTwbbI(int A_1)
	{
		return A_1 >= 0 && A_1 < this.weYNykGeaeJPGTeemBIJNvhgAhDhA && this.HNXfSWJRixJxdEIKdPomPAjjePAdb.Current.effectiveValue[A_1];
	}

	// Token: 0x06001570 RID: 5488 RVA: 0x0001BFF0 File Offset: 0x0001A1F0
	public int fVmGnSMDTrcONaLnvArQpyRmBIqJ(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.NCcdAGECmHFpVEVVbOSPAVbTZaMhb)
		{
			return -1;
		}
		return this.cVFEzqyXPBaqQkohadCtdWiEhsHEB(this.PQQMlBCmuJAufXlVIatqjAmVRsbB[A_1]);
	}

	// Token: 0x06001571 RID: 5489 RVA: 0x0001C00F File Offset: 0x0001A20F
	public Vector2 WzJFaHYUfrsCydxGjmNnSuQSpPuM(int A_1)
	{
		return Vector2.zero;
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x0004B564 File Offset: 0x00049764
	protected void BuEBObFLOjVqTKzdRNNMPaEduhuvA(gdTQNPtfPdCCoXDeSpbzXzWFikml A_1)
	{
		if (!base.AyUphnUpgWuvtMVHJETolaBqkFSi)
		{
			return;
		}
		if (OVAKMTRSqGwLcMwowcaAZSrdOdKd.AWCsVWSnUqGvHXNifuZVbcUUxKgj(A_1) <= 0)
		{
			return;
		}
		IntPtr intPtr = OVAKMTRSqGwLcMwowcaAZSrdOdKd.hlRcLsbLEyaYJEMoipaOdvHBoEnn(A_1);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (OVAKMTRSqGwLcMwowcaAZSrdOdKd.bBtUNkcYzbfGzHJqfqUajNWgjXCA(intPtr) != 0)
		{
			OVAKMTRSqGwLcMwowcaAZSrdOdKd.NfHgBroMkROfCpPpXBiKkXwjrOMf(intPtr);
			return;
		}
		this.iqMeRbUTbMHjznRkIiYyadNEQCgC = new xMCcsOGRxwueqcyehyzeoTpXbwIw(intPtr);
		this.pTatHwNXefScYkGpJNxVSIOGcVtO = true;
		this.pmRcZxyXDltDdryzKHaZipbRdzJ = (OVAKMTRSqGwLcMwowcaAZSrdOdKd.cPkkYAYxOpkClzuDbUWoruuxtQYk(this.iqMeRbUTbMHjznRkIiYyadNEQCgC) > 0);
		if (this.pmRcZxyXDltDdryzKHaZipbRdzJ)
		{
			this.OnDrohrSiEUhgiSSkNKKuBFPrZuG = 2;
		}
		this.NutCsOVyWZTiEVkaHDeapjIEalAo = new float[this.OnDrohrSiEUhgiSSkNKKuBFPrZuG];
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x0001C016 File Offset: 0x0001A216
	protected virtual void lnYYgSBpcunLgOJIggmlqlCaqEUw()
	{
		this.BuEBObFLOjVqTKzdRNNMPaEduhuvA(this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA as gdTQNPtfPdCCoXDeSpbzXzWFikml);
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x0004B600 File Offset: 0x00049800
	protected virtual void nhHOfuoODEhcVTlUsXTgKaApqXoN()
	{
		if (this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA == null || !this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA.IsValid)
		{
			return;
		}
		if (!this.lZxoAcunJRsmNxeTdGwustQczTgB())
		{
			this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA.Clear();
			return;
		}
		OVAKMTRSqGwLcMwowcaAZSrdOdKd.dhjRSasjtwFBQYaLMTqqxsphgomi(this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA);
		this.jvdcElAFnBFyYcMYUYSBYDPvIMEjA.Clear();
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x0001C029 File Offset: 0x0001A229
	private float fWfIxJkZarchdhYYrAyKoGDlflSt(int A_1)
	{
		if (A_1 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange((float)A_1, -32767f, 32768f, -1f, 1f);
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x0004B654 File Offset: 0x00049854
	private int cVFEzqyXPBaqQkohadCtdWiEhsHEB(short A_1)
	{
		switch (A_1)
		{
		case 0:
			return -1;
		case 1:
			return 0;
		case 2:
			return 9000;
		case 3:
			return 4500;
		case 4:
			return 18000;
		case 6:
			return 13500;
		case 8:
			return 27000;
		case 9:
			return 31500;
		case 12:
			return 22500;
		}
		return -1;
	}

	// Token: 0x04002EE8 RID: 12008
	public readonly int weYNykGeaeJPGTeemBIJNvhgAhDhA;

	// Token: 0x04002EE9 RID: 12009
	public readonly int AHfjHOjsUdHLhQmAriXOVCtHRBcQ;

	// Token: 0x04002EEA RID: 12010
	public readonly int NCcdAGECmHFpVEVVbOSPAVbTZaMhb;

	// Token: 0x04002EEB RID: 12011
	public readonly int BBxLtqMFCkQwwQILXhkollYIWtuJ;

	// Token: 0x04002EEC RID: 12012
	public readonly short[] zqIBYNNQpHArwegNeIOwbOdIazKbc;

	// Token: 0x04002EED RID: 12013
	private readonly ButtonLoopSet HNXfSWJRixJxdEIKdPomPAjjePAdb;

	// Token: 0x04002EEE RID: 12014
	public readonly short[] PQQMlBCmuJAufXlVIatqjAmVRsbB;

	// Token: 0x04002EEF RID: 12015
	public readonly short[] ltLplqijswQZJQDwALVJYGqKulAO;

	// Token: 0x04002EF0 RID: 12016
	private bool HbsBKokdZeLKMkPqRMYYgyhfJGsuB;
}
