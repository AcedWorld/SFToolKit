using System;
using Rewired.Utils;

// Token: 0x02000061 RID: 97
internal class ihwszOdiGYsRSXWvkodJEoTjuDiw : XbBMUwVQJwEvDLtpBqADdgXlHeWg
{
	// Token: 0x17000085 RID: 133
	// (get) Token: 0x0600033D RID: 829 RVA: 0x0002A944 File Offset: 0x00028B44
	public virtual int VKRYWMZHkHIznywPVqRInADnarzE
	{
		get
		{
			int num = (int)this.MdEkFfkLDDnBrMjoRMUEHYrIjRhw;
			if (this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq && this.FuEhTcThImcAeXZYbPqMzWKvTJLU && num > this.VBYCpgJqgunUgyCyyxRpRqoMBzrC)
			{
				num += this.CaCwMhmYWqFSZzbvMAfITtzFHfxr;
			}
			if (num == this.ODcJvmufbdlroBGaVkpZsbkapRHE)
			{
				return this.yFXAewbDMvrJleRJBFJdBplSorbd;
			}
			return (int)ihwszOdiGYsRSXWvkodJEoTjuDiw.EZbfSVfSAcgoeIhVFJnDgtOHbverB((float)num, (float)this.qnFFuokiazEEtyWboWyqJXIIIMpg, (float)this.JmhFRckhWfmZlgiuBYldXMJvOhYuB, (float)this.qUcssPuXHovuNUvvlcDPDkhDGGMfA, (float)this.aHqVnPpauJBMxIgUYAGcYOkUDFYi);
		}
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0002A9B0 File Offset: 0x00028BB0
	public ihwszOdiGYsRSXWvkodJEoTjuDiw(byte A_1, ushort A_2, ushort A_3, int A_4, int A_5, int A_6, int A_7, int A_8, int A_9, uint A_10, uint A_11, int A_12, bool A_13) : base(A_1, A_2, A_3, A_4, A_5)
	{
		this.qnFFuokiazEEtyWboWyqJXIIIMpg = A_6;
		this.JmhFRckhWfmZlgiuBYldXMJvOhYuB = A_7;
		this.oZLMamtylOzijNLCGXONSWIQXdnA = A_10;
		this.dVAqDGRiRRxOascZtBukgTmisGGoA = A_11;
		this.RqpupRcVVGiAXcYRXgsJTcomuVVG = A_12;
		this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq = (A_6 < 0 || A_7 < 0);
		if (A_6 > A_7 || A_7 - A_6 < 2)
		{
			if (A_6 == 0 && A_7 < 0 && A_8 == 0 && A_9 < 0)
			{
				this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq = false;
			}
			if (A_5 > 1 && A_5 < 32)
			{
				int num = 1 << A_5;
				if (this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq)
				{
					this.ODcJvmufbdlroBGaVkpZsbkapRHE = 0;
					this.qnFFuokiazEEtyWboWyqJXIIIMpg = num * -1;
					this.JmhFRckhWfmZlgiuBYldXMJvOhYuB = num - 1;
				}
				else
				{
					this.ODcJvmufbdlroBGaVkpZsbkapRHE = num >> 1;
					this.qnFFuokiazEEtyWboWyqJXIIIMpg = 0;
					this.JmhFRckhWfmZlgiuBYldXMJvOhYuB = num - 1;
				}
			}
			else if (this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq)
			{
				this.ODcJvmufbdlroBGaVkpZsbkapRHE = 0;
				this.qnFFuokiazEEtyWboWyqJXIIIMpg = -32768;
				this.JmhFRckhWfmZlgiuBYldXMJvOhYuB = 32767;
			}
			else
			{
				this.ODcJvmufbdlroBGaVkpZsbkapRHE = 32768;
				this.qnFFuokiazEEtyWboWyqJXIIIMpg = 0;
				this.JmhFRckhWfmZlgiuBYldXMJvOhYuB = 65535;
			}
		}
		else
		{
			this.ODcJvmufbdlroBGaVkpZsbkapRHE = (this.JmhFRckhWfmZlgiuBYldXMJvOhYuB - this.qnFFuokiazEEtyWboWyqJXIIIMpg) / 2;
		}
		this.yFXAewbDMvrJleRJBFJdBplSorbd = 0;
		this.qUcssPuXHovuNUvvlcDPDkhDGGMfA = -65535;
		this.aHqVnPpauJBMxIgUYAGcYOkUDFYi = 65535;
		if (this.cYxmsJSAnTwxCGQhJVRdwaAkBMNq)
		{
			this.SwXMmDFcnHshzZuWNOprYPchKUmg();
			this.ODcJvmufbdlroBGaVkpZsbkapRHE = A_7 + 1 + A_6;
		}
		if (A_13)
		{
			this.qnFFuokiazEEtyWboWyqJXIIIMpg = 0;
			this.ODcJvmufbdlroBGaVkpZsbkapRHE = 0;
			this.qUcssPuXHovuNUvvlcDPDkhDGGMfA = 0;
		}
		this.ELicurNVRQfnsDEcqntepAoGqkEJA();
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00012F37 File Offset: 0x00011137
	public virtual void pIBlROmnkAHfxFHKAWqNtMxCqxkbb()
	{
		this.MdEkFfkLDDnBrMjoRMUEHYrIjRhw = (uint)this.ODcJvmufbdlroBGaVkpZsbkapRHE;
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0002AB34 File Offset: 0x00028D34
	private static float EZbfSVfSAcgoeIhVFJnDgtOHbverB(float A_0, float A_1, float A_2, float A_3, float A_4)
	{
		float num = A_2 - A_1;
		float result;
		if (MathTools.Approximately(num, 0f))
		{
			result = A_3;
		}
		else
		{
			float num2 = A_4 - A_3;
			result = (A_0 - A_1) * num2 / num + A_3;
		}
		return result;
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0002AB68 File Offset: 0x00028D68
	private static int aqvJkuwaTTPOJerjKacABrQfLxid(int A_0, int A_1, int A_2, int A_3, int A_4)
	{
		int num = A_2 - A_1;
		long num2;
		if (num == 0)
		{
			num2 = (long)A_3;
		}
		else
		{
			int num3 = A_4 - A_3;
			num2 = (long)(A_0 - A_1) * (long)num3 / (long)num + (long)A_3;
		}
		return (int)num2;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0002AB98 File Offset: 0x00028D98
	private void SwXMmDFcnHshzZuWNOprYPchKUmg()
	{
		if (this.NfjAmyWfjIaQtUaggVtBiqNIrNMe <= 0 || this.NfjAmyWfjIaQtUaggVtBiqNIrNMe >= 32)
		{
			return;
		}
		int num = 1 << this.NfjAmyWfjIaQtUaggVtBiqNIrNMe;
		int num2 = num >> 1;
		this.VBYCpgJqgunUgyCyyxRpRqoMBzrC = num2 - 1;
		this.CaCwMhmYWqFSZzbvMAfITtzFHfxr = num * -1;
		this.FuEhTcThImcAeXZYbPqMzWKvTJLU = true;
	}

	// Token: 0x040004EF RID: 1263
	public readonly bool cYxmsJSAnTwxCGQhJVRdwaAkBMNq;

	// Token: 0x040004F0 RID: 1264
	private int VBYCpgJqgunUgyCyyxRpRqoMBzrC;

	// Token: 0x040004F1 RID: 1265
	private int CaCwMhmYWqFSZzbvMAfITtzFHfxr;

	// Token: 0x040004F2 RID: 1266
	private bool FuEhTcThImcAeXZYbPqMzWKvTJLU;

	// Token: 0x040004F3 RID: 1267
	public readonly int qnFFuokiazEEtyWboWyqJXIIIMpg;

	// Token: 0x040004F4 RID: 1268
	public readonly int JmhFRckhWfmZlgiuBYldXMJvOhYuB;

	// Token: 0x040004F5 RID: 1269
	public readonly int ODcJvmufbdlroBGaVkpZsbkapRHE;

	// Token: 0x040004F6 RID: 1270
	public readonly int qUcssPuXHovuNUvvlcDPDkhDGGMfA;

	// Token: 0x040004F7 RID: 1271
	public readonly int aHqVnPpauJBMxIgUYAGcYOkUDFYi;

	// Token: 0x040004F8 RID: 1272
	public readonly int yFXAewbDMvrJleRJBFJdBplSorbd;

	// Token: 0x040004F9 RID: 1273
	public readonly uint oZLMamtylOzijNLCGXONSWIQXdnA;

	// Token: 0x040004FA RID: 1274
	public readonly uint dVAqDGRiRRxOascZtBukgTmisGGoA;

	// Token: 0x040004FB RID: 1275
	public readonly int RqpupRcVVGiAXcYRXgsJTcomuVVG;

	// Token: 0x040004FC RID: 1276
	public uint MdEkFfkLDDnBrMjoRMUEHYrIjRhw;
}
