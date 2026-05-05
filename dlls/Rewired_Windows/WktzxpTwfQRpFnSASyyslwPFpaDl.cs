using System;

// Token: 0x020000A2 RID: 162
internal class WktzxpTwfQRpFnSASyyslwPFpaDl : IEquatable<WktzxpTwfQRpFnSASyyslwPFpaDl>
{
	// Token: 0x17000119 RID: 281
	// (get) Token: 0x060005A9 RID: 1449 RVA: 0x00013DB2 File Offset: 0x00011FB2
	public IntPtr xTnEyWcUvjrbwceGKuWjarIZSzlu
	{
		get
		{
			return this.SFRkozLENfWDuQUZUpkeGEzXEdOX;
		}
	}

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x060005AA RID: 1450 RVA: 0x00013DBA File Offset: 0x00011FBA
	public bool dSsvKQHeqUaVSCSLXZhUByhrytwbA
	{
		get
		{
			return this.SFRkozLENfWDuQUZUpkeGEzXEdOX != IntPtr.Zero;
		}
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00013DCC File Offset: 0x00011FCC
	public WktzxpTwfQRpFnSASyyslwPFpaDl(IntPtr A_1)
	{
		if (A_1 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		this.SFRkozLENfWDuQUZUpkeGEzXEdOX = A_1;
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x00013DF3 File Offset: 0x00011FF3
	public virtual bool vzUETOTISEaPGWIIlbPYhkwxBCTbA(object A_1)
	{
		return A_1 != null && A_1 is WktzxpTwfQRpFnSASyyslwPFpaDl && ((WktzxpTwfQRpFnSASyyslwPFpaDl)A_1).SFRkozLENfWDuQUZUpkeGEzXEdOX == this.SFRkozLENfWDuQUZUpkeGEzXEdOX;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00013E1A File Offset: 0x0001201A
	public virtual int SrzIRdVIrWuPUlaVFBPOcFpczBFLA()
	{
		return base.GetHashCode();
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00013E22 File Offset: 0x00012022
	public bool Equals(WktzxpTwfQRpFnSASyyslwPFpaDl other)
	{
		return other != null && this.SFRkozLENfWDuQUZUpkeGEzXEdOX == other.SFRkozLENfWDuQUZUpkeGEzXEdOX;
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00013E3A File Offset: 0x0001203A
	public static bool mdLlXvkWnwOUrtNUsszTyRBCHdmN(WktzxpTwfQRpFnSASyyslwPFpaDl A_0, WktzxpTwfQRpFnSASyyslwPFpaDl A_1)
	{
		return (A_0 == null && A_1 == null) || (A_0 != null && A_1 != null && A_0.Equals(A_1));
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00013E53 File Offset: 0x00012053
	public static bool LwbEAICQdUXsiPWaNZCvvziebGylA(WktzxpTwfQRpFnSASyyslwPFpaDl A_0, WktzxpTwfQRpFnSASyyslwPFpaDl A_1)
	{
		return (A_0 != null || A_1 != null) && (A_0 == null || A_1 == null || !A_0.Equals(A_1));
	}

	// Token: 0x04000637 RID: 1591
	private IntPtr SFRkozLENfWDuQUZUpkeGEzXEdOX;
}
