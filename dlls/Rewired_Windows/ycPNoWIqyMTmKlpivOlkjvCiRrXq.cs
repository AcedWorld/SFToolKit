using System;
using System.Runtime.InteropServices;

// Token: 0x020000EB RID: 235
[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct ycPNoWIqyMTmKlpivOlkjvCiRrXq : IEquatable<ycPNoWIqyMTmKlpivOlkjvCiRrXq>
{
	// Token: 0x06000862 RID: 2146 RVA: 0x00015F53 File Offset: 0x00014153
	public ycPNoWIqyMTmKlpivOlkjvCiRrXq(bool A_1)
	{
		this.EDQEeKgImxvzphXfPrGBioFEIpIib = (A_1 ? 1 : 0);
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x00015F62 File Offset: 0x00014162
	public bool Equals(ycPNoWIqyMTmKlpivOlkjvCiRrXq other)
	{
		return this.EDQEeKgImxvzphXfPrGBioFEIpIib == other.EDQEeKgImxvzphXfPrGBioFEIpIib;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x00015F72 File Offset: 0x00014172
	public bool GWALlKcJugbFEvdoQBzkwrbbqHlo(object A_1)
	{
		return A_1 != null && A_1 is ycPNoWIqyMTmKlpivOlkjvCiRrXq && this.Equals((ycPNoWIqyMTmKlpivOlkjvCiRrXq)A_1);
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x00015F8F File Offset: 0x0001418F
	public int dhhGfoINAOGELKBijzbRcbcHsSkvA()
	{
		return this.EDQEeKgImxvzphXfPrGBioFEIpIib;
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x00015F97 File Offset: 0x00014197
	public static bool CpBkazPbkMmOgmZllpSFGjKyUSBg(ycPNoWIqyMTmKlpivOlkjvCiRrXq A_0, ycPNoWIqyMTmKlpivOlkjvCiRrXq A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x00015FA1 File Offset: 0x000141A1
	public static bool mnQcOuUayfTLCTjhjDBQiICwKmwc(ycPNoWIqyMTmKlpivOlkjvCiRrXq A_0, ycPNoWIqyMTmKlpivOlkjvCiRrXq A_1)
	{
		return !A_0.Equals(A_1);
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x00015FAE File Offset: 0x000141AE
	public static bool BNIshJgMTPwblPVNzoSsCQoYvYve(ycPNoWIqyMTmKlpivOlkjvCiRrXq A_0)
	{
		return A_0.EDQEeKgImxvzphXfPrGBioFEIpIib != 0;
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x00015FB9 File Offset: 0x000141B9
	public static ycPNoWIqyMTmKlpivOlkjvCiRrXq UvqXuOUnpciCtMolbSIlMmjSfqbv(bool A_0)
	{
		return new ycPNoWIqyMTmKlpivOlkjvCiRrXq(A_0);
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x00015FC1 File Offset: 0x000141C1
	public string JRECoWDudtkzVUEKNCeOuERfIhlP()
	{
		return string.Format("{0}", this.EDQEeKgImxvzphXfPrGBioFEIpIib != 0);
	}

	// Token: 0x04000853 RID: 2131
	private int EDQEeKgImxvzphXfPrGBioFEIpIib;
}
