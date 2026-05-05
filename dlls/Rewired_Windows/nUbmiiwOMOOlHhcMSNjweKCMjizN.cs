using System;
using Rewired.Utils;

// Token: 0x02000063 RID: 99
internal class nUbmiiwOMOOlHhcMSNjweKCMjizN : XbBMUwVQJwEvDLtpBqADdgXlHeWg
{
	// Token: 0x17000087 RID: 135
	// (get) Token: 0x06000345 RID: 837 RVA: 0x0002AC10 File Offset: 0x00028E10
	public int JKefQXgLEOaENeMoOWgoJbgxzeAp
	{
		get
		{
			if ((ulong)this.ZBlAdjHJhtIBCEObxWEyQpcHTqlUA < (ulong)((long)this.nyPgqcDnDGICKCEwLXNVJVcvfVLHA) || (ulong)this.ZBlAdjHJhtIBCEObxWEyQpcHTqlUA > (ulong)((long)this.MBMEncDYpnrHgpJGFlXomBrOnJTTA))
			{
				return -1;
			}
			int num = (int)(((ulong)this.ZBlAdjHJhtIBCEObxWEyQpcHTqlUA - (ulong)((long)this.nyPgqcDnDGICKCEwLXNVJVcvfVLHA)) / (ulong)((long)this.GzYfdbOwobJtYezJyGBmkaqzJbVIA) * 4500UL);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0002AC6C File Offset: 0x00028E6C
	public nUbmiiwOMOOlHhcMSNjweKCMjizN(byte A_1, ushort A_2, ushort A_3, int A_4, int A_5, int A_6, int A_7, int A_8, int A_9, uint A_10, uint A_11, int A_12) : base(A_1, A_2, A_3, A_4, A_5)
	{
		this.nyPgqcDnDGICKCEwLXNVJVcvfVLHA = A_6;
		this.MBMEncDYpnrHgpJGFlXomBrOnJTTA = A_7;
		this.DCmjnLkFKSfCXTVNTMqHgNZOUDNu = A_10;
		this.udcGLhJtmsEvYjWNQqBrHhCFLaHH = A_11;
		this.QeoNUKsLLvSRHhtmlhIjURkMOWim = A_12;
		this.iuhDRfHVFoTGFIsMeeeeqyphKtjX = A_6 - 1;
		if (this.iuhDRfHVFoTGFIsMeeeeqyphKtjX < 0)
		{
			this.iuhDRfHVFoTGFIsMeeeeqyphKtjX = A_7 + 1;
		}
		this.FIVGVeDVAhnMegOODOlpbJgvoSVs = -1;
		int num = A_7 - A_6 + 1;
		this.GzYfdbOwobJtYezJyGBmkaqzJbVIA = MathTools.Clamp(num / 8, 1, int.MaxValue);
		this.ELicurNVRQfnsDEcqntepAoGqkEJA();
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00012F4D File Offset: 0x0001114D
	public virtual void OTswhQaVCcMIWPyvduWrkNjLCyfp()
	{
		this.ZBlAdjHJhtIBCEObxWEyQpcHTqlUA = (uint)this.iuhDRfHVFoTGFIsMeeeeqyphKtjX;
	}

	// Token: 0x040004FD RID: 1277
	public readonly int nyPgqcDnDGICKCEwLXNVJVcvfVLHA;

	// Token: 0x040004FE RID: 1278
	public readonly int MBMEncDYpnrHgpJGFlXomBrOnJTTA;

	// Token: 0x040004FF RID: 1279
	public readonly int iuhDRfHVFoTGFIsMeeeeqyphKtjX;

	// Token: 0x04000500 RID: 1280
	public readonly int VTWdUUMohfvosoquSlODMBLtdJmbA;

	// Token: 0x04000501 RID: 1281
	public readonly int zTGHxuWrVfgObhoVvgaRFkLNDzWv;

	// Token: 0x04000502 RID: 1282
	public readonly int FIVGVeDVAhnMegOODOlpbJgvoSVs;

	// Token: 0x04000503 RID: 1283
	public readonly uint DCmjnLkFKSfCXTVNTMqHgNZOUDNu;

	// Token: 0x04000504 RID: 1284
	public readonly uint udcGLhJtmsEvYjWNQqBrHhCFLaHH;

	// Token: 0x04000505 RID: 1285
	public readonly int QeoNUKsLLvSRHhtmlhIjURkMOWim;

	// Token: 0x04000506 RID: 1286
	private readonly int GzYfdbOwobJtYezJyGBmkaqzJbVIA;

	// Token: 0x04000507 RID: 1287
	public uint ZBlAdjHJhtIBCEObxWEyQpcHTqlUA;
}
