using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

// Token: 0x02000112 RID: 274
[DefaultMember("Item")]
[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct qCqIBPaXfxjAqItjUhVdAyyFkGwAB : IEquatable<qCqIBPaXfxjAqItjUhVdAyyFkGwAB>, IFormattable
{
	// Token: 0x060009FD RID: 2557 RVA: 0x000173EA File Offset: 0x000155EA
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB(float A_1)
	{
		this.EhulLFHPwUfVSsKKVPGVaiBMdoqH = A_1;
		this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = A_1;
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x000173FA File Offset: 0x000155FA
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB(float A_1, float A_2)
	{
		this.EhulLFHPwUfVSsKKVPGVaiBMdoqH = A_1;
		this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = A_2;
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x0001740A File Offset: 0x0001560A
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB(float[] A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (A_1.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		this.EhulLFHPwUfVSsKKVPGVaiBMdoqH = A_1[0];
		this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = A_1[1];
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00017442 File Offset: 0x00015642
	public bool RiJNnNyOBvaUWEGuLvwxouiSIxUD
	{
		get
		{
			return ACVTseoaUnpTFsXommHYwDIfFbWHA.jrOfVrGLsHKPdDpokkZtHwXRcjIZb(this.EhulLFHPwUfVSsKKVPGVaiBMdoqH * this.EhulLFHPwUfVSsKKVPGVaiBMdoqH + this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00017464 File Offset: 0x00015664
	public bool LOBLLiDCSJXqyUbcqVHelVJuGrhW
	{
		get
		{
			return this.EhulLFHPwUfVSsKKVPGVaiBMdoqH == 0f && this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA == 0f;
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00017482 File Offset: 0x00015682
	// (set) Token: 0x06000A03 RID: 2563 RVA: 0x000174AA File Offset: 0x000156AA
	public float FXvTVDNExRhUuwuTMRRZMenEQYqH
	{
		get
		{
			if (A_1 == 0)
			{
				return this.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
			}
			if (A_1 != 1)
			{
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
			return this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		}
		set
		{
			if (A_1 == 0)
			{
				this.EhulLFHPwUfVSsKKVPGVaiBMdoqH = value;
				return;
			}
			if (A_1 != 1)
			{
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
			this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = value;
		}
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x000174D4 File Offset: 0x000156D4
	public float ZswyjpmzwkZupuwkFclNNnKcmRkm()
	{
		return (float)Math.Sqrt((double)(this.EhulLFHPwUfVSsKKVPGVaiBMdoqH * this.EhulLFHPwUfVSsKKVPGVaiBMdoqH + this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA));
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x000174F8 File Offset: 0x000156F8
	public float mSgUndPCycaPBHHMyPhfwAvFOqnN()
	{
		return this.EhulLFHPwUfVSsKKVPGVaiBMdoqH * this.EhulLFHPwUfVSsKKVPGVaiBMdoqH + this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x0003B744 File Offset: 0x00039944
	public void HRyRoQFZFaxEtjKIByFGzVMUeFbA()
	{
		float num = this.ZswyjpmzwkZupuwkFclNNnKcmRkm();
		if (!ACVTseoaUnpTFsXommHYwDIfFbWHA.TjfQxNkTkfYeEEaaZPNZQKMeOGEG(num))
		{
			float num2 = 1f / num;
			this.EhulLFHPwUfVSsKKVPGVaiBMdoqH *= num2;
			this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA *= num2;
		}
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x00017515 File Offset: 0x00015715
	public float[] WpiagOFeCqsffEZRtSAKlWsjgSFqA()
	{
		return new float[]
		{
			this.EhulLFHPwUfVSsKKVPGVaiBMdoqH,
			this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA
		};
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x0001752F File Offset: 0x0001572F
	public static void HCRSSahjCITSQMFvtWtdmemwhzahA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x00017556 File Offset: 0x00015756
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB WUlCNRTOLYaLxQFlgFbSJeTTRLfb(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x00017577 File Offset: 0x00015777
	public static void sdniCAdEfrAlDQKyhNrTOIbwQrlF(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref float A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1);
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x00017596 File Offset: 0x00015796
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB YJilZnpgWnNMzypafqjnsdulrVzg(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1);
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x000175AD File Offset: 0x000157AD
	public static void REilqTvqifbMndPNxSAlIKCywrrI(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x000175D4 File Offset: 0x000157D4
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB TDclZojaDWGWPgnNHuawfnGhEjobb(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x000175F5 File Offset: 0x000157F5
	public static void LUIXRJFndSDjkxIFSjNlvfgulMHl(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref float A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1);
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x00017614 File Offset: 0x00015814
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB WcwSzHKwFvGneNLgpZLXjUAqlNOh(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1);
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x0001762B File Offset: 0x0001582B
	public static void RZXaWoeOKbJohAjyHBtyejjDmBHjd(ref float A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0001764A File Offset: 0x0001584A
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB aEBNuzfwOJBsALynjILctwJNrsKU(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x00017661 File Offset: 0x00015861
	public static void iMzhyqmkYghlVxiNkeYIfNJvojLY(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1);
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x0001767E File Offset: 0x0001587E
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB OApARqhoXfCfqneBRAhgewHPdoAr(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1);
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x00017695 File Offset: 0x00015895
	public static void lXAAzVxdEucdqdCkHaugMssRiMRZ(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x000176BC File Offset: 0x000158BC
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB yRZjNPDeIbxEphTQIpnVqArdMIZl(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x000176DD File Offset: 0x000158DD
	public static void xehvLxoAUOKtRtEKCEoluodLqrhm(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH / A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA / A_1);
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x000176FA File Offset: 0x000158FA
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB zpWMEmBlKbHRnjlCoQKEjwtONNPG(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH / A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA / A_1);
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x00017711 File Offset: 0x00015911
	public static void QIZXIxrVGUOTMewFViGyrnDHocd(float A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 / A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 / A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0001772E File Offset: 0x0001592E
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB InDNpSUseqBzAkXjkOZLibRLLtbw(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 / A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 / A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x00017745 File Offset: 0x00015945
	public static void fbgJVsTrPAOVgGcowJrBGzMfGiHC(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		A_1 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(-A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH, -A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x00017760 File Offset: 0x00015960
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB qQyOfpQZjTbuglZANPHDOnvycdZfA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(-A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH, -A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x0003B784 File Offset: 0x00039984
	public static void AWzeyYaiLVkTJJwfhkmzFhjAFTWqA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, float A_3, float A_4, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_5)
	{
		A_5 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_3 * (A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH) + A_4 * (A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH), A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_3 * (A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) + A_4 * (A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA));
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x0003B7EC File Offset: 0x000399EC
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB HEnJyZqNgkTmxJZWpPLHqZWWHUyO(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, float A_3, float A_4)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.AWzeyYaiLVkTJJwfhkmzFhjAFTWqA(ref A_0, ref A_1, ref A_2, A_3, A_4, out result);
		return result;
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x0003B80C File Offset: 0x00039A0C
	public static void dFQWVhbjadaalPbHJcwnFGaxWMfhA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		num = ((num > A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH) ? A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH : num);
		num = ((num < A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH) ? A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH : num);
		float num2 = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		num2 = ((num2 > A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) ? A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA : num2);
		num2 = ((num2 < A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) ? A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA : num2);
		A_3 = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(num, num2);
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x0003B880 File Offset: 0x00039A80
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB jcPhWwAdOWlynxfuWoExQZFHXFnwA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.dFQWVhbjadaalPbHJcwnFGaxWMfhA(ref A_0, ref A_1, ref A_2, out result);
		return result;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0003B89C File Offset: 0x00039A9C
	public void DdjqBHekBDFOzMSbEUyweYrPBAVb()
	{
		this.EhulLFHPwUfVSsKKVPGVaiBMdoqH = ((this.EhulLFHPwUfVSsKKVPGVaiBMdoqH < 0f) ? 0f : ((this.EhulLFHPwUfVSsKKVPGVaiBMdoqH > 1f) ? 1f : this.EhulLFHPwUfVSsKKVPGVaiBMdoqH));
		this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = ((this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA < 0f) ? 0f : ((this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA > 1f) ? 1f : this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA));
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x0003B914 File Offset: 0x00039B14
	public static void thMNKFNMTlgsvlLJGACxdWJRCWbeb(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out float A_2)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		float num2 = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		A_2 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x0003B950 File Offset: 0x00039B50
	public static float frjTTUEnjIaGoPkHAKVwOUeQKCO(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		float num2 = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		return (float)Math.Sqrt((double)(num * num + num2 * num2));
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x0003B988 File Offset: 0x00039B88
	public static void ZdvfQKfcdMdMJNHzSonEoCSnNmDG(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out float A_2)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		float num2 = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		A_2 = num * num + num2 * num2;
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x0003B9BC File Offset: 0x00039BBC
	public static float YOcIzvStsKzzPwRNUfMPTNtlPQj(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		float num2 = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		return num * num + num2 * num2;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x00017775 File Offset: 0x00015975
	public static void gsXtqSSvbgQvjDKsqJteRsUewaJm(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out float A_2)
	{
		A_2 = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x00017794 File Offset: 0x00015994
	public static float LuwDRlsahsMWwkmjZYkjBuufQHWh(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000177B1 File Offset: 0x000159B1
	public static void YaiCJXdLhWMAVZqZMlqNdfOZRoonA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		A_1 = A_0;
		A_1.HRyRoQFZFaxEtjKIByFGzVMUeFbA();
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x000177C5 File Offset: 0x000159C5
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB IljbckdOYOQgSmSlhmYptmDnSSrBb(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0)
	{
		A_0.HRyRoQFZFaxEtjKIByFGzVMUeFbA();
		return A_0;
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x000177CF File Offset: 0x000159CF
	public static void FmCmeMsWaKOCmvsriLwEulsHjvQy(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, float A_2, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3)
	{
		A_3.EhulLFHPwUfVSsKKVPGVaiBMdoqH = ACVTseoaUnpTFsXommHYwDIfFbWHA.dYERyqSpZupISItebJfFTgyFWuKM(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_2);
		A_3.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = ACVTseoaUnpTFsXommHYwDIfFbWHA.dYERyqSpZupISItebJfFTgyFWuKM(A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA, A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA, A_2);
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x0003B9EC File Offset: 0x00039BEC
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB XMAOCldhmtncaLAwemXutNxDuHTb(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, float A_2)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.FmCmeMsWaKOCmvsriLwEulsHjvQy(ref A_0, ref A_1, A_2, out result);
		return result;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x00017801 File Offset: 0x00015A01
	public static void zKSdnLgeXAByTnuvHeGExTGowxNqA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, float A_2, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3)
	{
		A_2 = ACVTseoaUnpTFsXommHYwDIfFbWHA.DBCzqxYVwOJclUUpbmtSHifCfDdd(A_2);
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.FmCmeMsWaKOCmvsriLwEulsHjvQy(ref A_0, ref A_1, A_2, out A_3);
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x0003BA08 File Offset: 0x00039C08
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB QgCZdBQdhoJFDesAsCEkgoAdIMOo(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, float A_2)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.zKSdnLgeXAByTnuvHeGExTGowxNqA(ref A_0, ref A_1, A_2, out result);
		return result;
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x0003BA24 File Offset: 0x00039C24
	public static void bHBpMAYlqXtJoIcZmZsUEMwXdOLJA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3, float A_4, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_5)
	{
		float num = A_4 * A_4;
		float num2 = A_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + A_4;
		float num6 = num2 - num;
		A_5.EhulLFHPwUfVSsKKVPGVaiBMdoqH = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * num3 + A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH * num4 + A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH * num5 + A_3.EhulLFHPwUfVSsKKVPGVaiBMdoqH * num6;
		A_5.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * num3 + A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * num4 + A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * num5 + A_3.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * num6;
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x0003BAD0 File Offset: 0x00039CD0
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB hnAupiAkmSczpOjgaaBwcVVYkjExA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3, float A_4)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.bHBpMAYlqXtJoIcZmZsUEMwXdOLJA(ref A_0, ref A_1, ref A_2, ref A_3, A_4, out result);
		return result;
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x0003BAF0 File Offset: 0x00039CF0
	public static void QeptSLlzrPdvuXzUouYYtYwZRTnb(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3, float A_4, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_5)
	{
		float num = A_4 * A_4;
		float num2 = A_4 * num;
		A_5.EhulLFHPwUfVSsKKVPGVaiBMdoqH = 0.5f * (2f * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH + (-A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH) * A_4 + (2f * A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - 5f * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH + 4f * A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_3.EhulLFHPwUfVSsKKVPGVaiBMdoqH) * num + (-A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + 3f * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH - 3f * A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_3.EhulLFHPwUfVSsKKVPGVaiBMdoqH) * num2);
		A_5.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = 0.5f * (2f * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + (-A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) * A_4 + (2f * A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - 5f * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + 4f * A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_3.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) * num + (-A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + 3f * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - 3f * A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_3.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) * num2);
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x0003BC14 File Offset: 0x00039E14
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB mbWvEHdYOGFJqZIXuCqFbWRgLQqjA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_3, float A_4)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.QeptSLlzrPdvuXzUouYYtYwZRTnb(ref A_0, ref A_1, ref A_2, ref A_3, A_4, out result);
		return result;
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x0003BC34 File Offset: 0x00039E34
	public static void siyjYNEHPbJcgRVUxKSQwqlGmHFG(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH = ((A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH > A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH) ? A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH : A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH);
		A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = ((A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA > A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) ? A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA : A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x0003BC88 File Offset: 0x00039E88
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB FhXzzhYWIPQNkWcVCSCVPEOtCIIx(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.siyjYNEHPbJcgRVUxKSQwqlGmHFG(ref A_0, ref A_1, out result);
		return result;
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x0003BCA4 File Offset: 0x00039EA4
	public static void RQlcymLjKiDaUHlilYjJxqDfpLid(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH = ((A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH < A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH) ? A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH : A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH);
		A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = ((A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA < A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA) ? A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA : A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x0003BCF8 File Offset: 0x00039EF8
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB kxhTZhBqPLENgUYXgJMfZGwgeCKdA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.RQlcymLjKiDaUHlilYjJxqDfpLid(ref A_0, ref A_1, out result);
		return result;
	}

	// Token: 0x06000A35 RID: 2613 RVA: 0x0003BD14 File Offset: 0x00039F14
	public static void rEAJIZlLpfhNWFzjVBHPUNAGWGbLA(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_2)
	{
		float num = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		A_2.EhulLFHPwUfVSsKKVPGVaiBMdoqH = A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - 2f * num * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
		A_2.zIdinbmUoEeKBlIQLDYxCrGNpGsJA = A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - 2f * num * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x0003BD74 File Offset: 0x00039F74
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB enrpzetSymDwNAbHgRcSocfeyVKN(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB result;
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB.rEAJIZlLpfhNWFzjVBHPUNAGWGbLA(ref A_0, ref A_1, out result);
		return result;
	}

	// Token: 0x06000A37 RID: 2615 RVA: 0x0003BD90 File Offset: 0x00039F90
	public static void lkMiFqvlWdYvnSGDhvHJnxKOsbdp(qCqIBPaXfxjAqItjUhVdAyyFkGwAB[] A_0, params qCqIBPaXfxjAqItjUhVdAyyFkGwAB[] A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (A_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (A_0.Length < A_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < A_1.Length; i++)
		{
			qCqIBPaXfxjAqItjUhVdAyyFkGwAB qCqIBPaXfxjAqItjUhVdAyyFkGwAB = A_1[i];
			for (int j = 0; j < i; j++)
			{
				qCqIBPaXfxjAqItjUhVdAyyFkGwAB = qCqIBPaXfxjAqItjUhVdAyyFkGwAB.bebBBsSWTveRRkBcBfpcEArcELhIA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB, qCqIBPaXfxjAqItjUhVdAyyFkGwAB.mCWngeWgyEUtbJdTSigHcAYvRjeO(qCqIBPaXfxjAqItjUhVdAyyFkGwAB.LuwDRlsahsMWwkmjZYkjBuufQHWh(A_0[j], qCqIBPaXfxjAqItjUhVdAyyFkGwAB) / qCqIBPaXfxjAqItjUhVdAyyFkGwAB.LuwDRlsahsMWwkmjZYkjBuufQHWh(A_0[j], A_0[j]), A_0[j]));
			}
			A_0[i] = qCqIBPaXfxjAqItjUhVdAyyFkGwAB;
		}
	}

	// Token: 0x06000A38 RID: 2616 RVA: 0x0003BE30 File Offset: 0x0003A030
	public static void OIHzZKNVUFlGAHGyawGBpORKEbSW(qCqIBPaXfxjAqItjUhVdAyyFkGwAB[] A_0, params qCqIBPaXfxjAqItjUhVdAyyFkGwAB[] A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (A_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (A_0.Length < A_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < A_1.Length; i++)
		{
			qCqIBPaXfxjAqItjUhVdAyyFkGwAB qCqIBPaXfxjAqItjUhVdAyyFkGwAB = A_1[i];
			for (int j = 0; j < i; j++)
			{
				qCqIBPaXfxjAqItjUhVdAyyFkGwAB = qCqIBPaXfxjAqItjUhVdAyyFkGwAB.bebBBsSWTveRRkBcBfpcEArcELhIA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB, qCqIBPaXfxjAqItjUhVdAyyFkGwAB.mCWngeWgyEUtbJdTSigHcAYvRjeO(qCqIBPaXfxjAqItjUhVdAyyFkGwAB.LuwDRlsahsMWwkmjZYkjBuufQHWh(A_0[j], qCqIBPaXfxjAqItjUhVdAyyFkGwAB), A_0[j]));
			}
			qCqIBPaXfxjAqItjUhVdAyyFkGwAB.HRyRoQFZFaxEtjKIByFGzVMUeFbA();
			A_0[i] = qCqIBPaXfxjAqItjUhVdAyyFkGwAB;
		}
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x00017556 File Offset: 0x00015756
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB DLJYuyKQjIxfSXWKTVnUuPPhHmbbA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x000176BC File Offset: 0x000158BC
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB mszboeKJHjfvtZmFKGJmUMQBdkIS(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x00012237 File Offset: 0x00010437
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB TSaxAvDfSwDfwcuKDkjPxPMMNyWcb(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0)
	{
		return A_0;
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x000175D4 File Offset: 0x000157D4
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB bebBBsSWTveRRkBcBfpcEArcELhIA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x00017760 File Offset: 0x00015960
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB gbgRwkLFXeJmBvqRWngvpUGgKEEN(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(-A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH, -A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x00017814 File Offset: 0x00015A14
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB mCWngeWgyEUtbJdTSigHcAYvRjeO(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_0, A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_0);
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0001767E File Offset: 0x0001587E
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB FFgfMgfGXoEDIXXSjJPjmyCmEcDu(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH * A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA * A_1);
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x000176FA File Offset: 0x000158FA
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB RXPdyTwcKxJBKNLTvvtrUKAszCFx(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH / A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA / A_1);
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x0001772E File Offset: 0x0001592E
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB RgAQQUsUtKnDKmigiBtRgaxwltOM(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 / A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 / A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x0001782B File Offset: 0x00015A2B
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB VTRlarOmaCgrIqHTeLUNxppjfNAfA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH / A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA / A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x00017596 File Offset: 0x00015796
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB GcZBECFiMQvkzKvWXcouIfydvjYh(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH + A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA + A_1);
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0001784C File Offset: 0x00015A4C
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB SliEfswhSbhKFBmExXjGtahKjkpsA(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 + A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 + A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x00017614 File Offset: 0x00015814
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB cRcrUJlBNlyegpSjsjmZOojpbWABA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, float A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0.EhulLFHPwUfVSsKKVPGVaiBMdoqH - A_1, A_0.zIdinbmUoEeKBlIQLDYxCrGNpGsJA - A_1);
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x0001764A File Offset: 0x0001584A
	public static qCqIBPaXfxjAqItjUhVdAyyFkGwAB XGGBBOBzspINCqBfsxPJpLePKQBaA(float A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(A_0 - A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_0 - A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x00017863 File Offset: 0x00015A63
	public static bool koCmvqVAHnprqhBPRBojCjvLiNAU(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return A_0.EWLmicBNVcDEdkkkEmWoWBfiOUZL(ref A_1);
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0001786E File Offset: 0x00015A6E
	public static bool SJcSxkjzVLTtfOPzhexivAVzfXE(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_0, qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return !A_0.EWLmicBNVcDEdkkkEmWoWBfiOUZL(ref A_1);
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x0001787C File Offset: 0x00015A7C
	public string QpYDssGXfsrkUJDWBJimuxpeJprMA()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", this.EhulLFHPwUfVSsKKVPGVaiBMdoqH, this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0003BEC4 File Offset: 0x0003A0C4
	public string MmDkrDzLNAeXDAnZOmYICSHEKdNLA(string A_1)
	{
		if (A_1 == null)
		{
			return this.ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", this.EhulLFHPwUfVSsKKVPGVaiBMdoqH.ToString(A_1, CultureInfo.CurrentCulture), this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA.ToString(A_1, CultureInfo.CurrentCulture));
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x000178A3 File Offset: 0x00015AA3
	public string RFidYXGLqyVeXPEhBbIgTKnQxcng(IFormatProvider A_1)
	{
		return string.Format(A_1, "X:{0} Y:{1}", this.EhulLFHPwUfVSsKKVPGVaiBMdoqH, this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x000178C6 File Offset: 0x00015AC6
	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			this.RFidYXGLqyVeXPEhBbIgTKnQxcng(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", this.EhulLFHPwUfVSsKKVPGVaiBMdoqH.ToString(format, formatProvider), this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA.ToString(format, formatProvider));
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x000178F8 File Offset: 0x00015AF8
	public int jAtRgFWGsnbvNghUPMqkoqjxGjRn()
	{
		return this.EhulLFHPwUfVSsKKVPGVaiBMdoqH.GetHashCode() * 397 ^ this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA.GetHashCode();
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x00017917 File Offset: 0x00015B17
	public bool EWLmicBNVcDEdkkkEmWoWBfiOUZL(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, this.EhulLFHPwUfVSsKKVPGVaiBMdoqH) && ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA, this.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0001793F File Offset: 0x00015B3F
	public bool Equals(qCqIBPaXfxjAqItjUhVdAyyFkGwAB other)
	{
		return this.EWLmicBNVcDEdkkkEmWoWBfiOUZL(ref other);
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x0003BF14 File Offset: 0x0003A114
	public bool FXwMSNHnWqPJbOknqIFzkWJTyXVj(object A_1)
	{
		if (!(A_1 is qCqIBPaXfxjAqItjUhVdAyyFkGwAB))
		{
			return false;
		}
		qCqIBPaXfxjAqItjUhVdAyyFkGwAB qCqIBPaXfxjAqItjUhVdAyyFkGwAB = (qCqIBPaXfxjAqItjUhVdAyyFkGwAB)A_1;
		return this.EWLmicBNVcDEdkkkEmWoWBfiOUZL(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB);
	}

	// Token: 0x040008A2 RID: 2210
	public static readonly int snQKedfVRSsrzLQKqwzNchQiNnRO = Marshal.SizeOf(typeof(qCqIBPaXfxjAqItjUhVdAyyFkGwAB));

	// Token: 0x040008A3 RID: 2211
	public static readonly qCqIBPaXfxjAqItjUhVdAyyFkGwAB uiuAyZcrmsQKlCgKgGKuyusBqCDE = default(qCqIBPaXfxjAqItjUhVdAyyFkGwAB);

	// Token: 0x040008A4 RID: 2212
	public static readonly qCqIBPaXfxjAqItjUhVdAyyFkGwAB LzUAYqHjJLimtAzxjPHJPKFWikEqA = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(1f, 0f);

	// Token: 0x040008A5 RID: 2213
	public static readonly qCqIBPaXfxjAqItjUhVdAyyFkGwAB OwoeiTxPrQQidcBlEskKZbFfDmnH = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(0f, 1f);

	// Token: 0x040008A6 RID: 2214
	public static readonly qCqIBPaXfxjAqItjUhVdAyyFkGwAB sUMBAFBhagCJNpAJZNBnnugLsnUW = new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(1f, 1f);

	// Token: 0x040008A7 RID: 2215
	public float EhulLFHPwUfVSsKKVPGVaiBMdoqH;

	// Token: 0x040008A8 RID: 2216
	public float zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
}
