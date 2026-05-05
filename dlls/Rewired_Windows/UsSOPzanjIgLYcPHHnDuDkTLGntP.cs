using System;

// Token: 0x020000FF RID: 255
internal struct UsSOPzanjIgLYcPHHnDuDkTLGntP : IEquatable<UsSOPzanjIgLYcPHHnDuDkTLGntP>
{
	// Token: 0x060008F0 RID: 2288 RVA: 0x00016467 File Offset: 0x00014667
	public UsSOPzanjIgLYcPHHnDuDkTLGntP(int A_1, int A_2)
	{
		this.CHHjiTGmHfRRQJnktCRaHsADXNLSA = A_1;
		this.VuyUSeRQwbUbdgQTiEKcLyAArdqj = A_2;
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00016477 File Offset: 0x00014677
	public bool Equals(UsSOPzanjIgLYcPHHnDuDkTLGntP other)
	{
		return other.CHHjiTGmHfRRQJnktCRaHsADXNLSA == this.CHHjiTGmHfRRQJnktCRaHsADXNLSA && other.VuyUSeRQwbUbdgQTiEKcLyAArdqj == this.VuyUSeRQwbUbdgQTiEKcLyAArdqj;
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x00016497 File Offset: 0x00014697
	public bool ucOZAThhJrgoxHdUynMJaIbkoxeOb(object A_1)
	{
		return A_1 != null && !(A_1.GetType() != typeof(UsSOPzanjIgLYcPHHnDuDkTLGntP)) && this.Equals((UsSOPzanjIgLYcPHHnDuDkTLGntP)A_1);
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000164C3 File Offset: 0x000146C3
	public int REDhFoyBMEqVGbgwTvNZAkSEQAED()
	{
		return this.CHHjiTGmHfRRQJnktCRaHsADXNLSA * 397 ^ this.VuyUSeRQwbUbdgQTiEKcLyAArdqj;
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000164D8 File Offset: 0x000146D8
	public static bool NNcNtdfevtjIXxYuCJXTLwOCrtbh(UsSOPzanjIgLYcPHHnDuDkTLGntP A_0, UsSOPzanjIgLYcPHHnDuDkTLGntP A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000164E2 File Offset: 0x000146E2
	public static bool dHcWaDQLSWbtkftQBjWdUAFaHxedA(UsSOPzanjIgLYcPHHnDuDkTLGntP A_0, UsSOPzanjIgLYcPHHnDuDkTLGntP A_1)
	{
		return !A_0.Equals(A_1);
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x000164EF File Offset: 0x000146EF
	public string GlksOjDARtibUCiRDgSrRNtamxdH()
	{
		return string.Format("({0},{1})", this.CHHjiTGmHfRRQJnktCRaHsADXNLSA, this.VuyUSeRQwbUbdgQTiEKcLyAArdqj);
	}

	// Token: 0x0400086C RID: 2156
	public static readonly UsSOPzanjIgLYcPHHnDuDkTLGntP mxuCMOOaRWuutsRjpHHkKSyTQiAV = new UsSOPzanjIgLYcPHHnDuDkTLGntP(0, 0);

	// Token: 0x0400086D RID: 2157
	public int CHHjiTGmHfRRQJnktCRaHsADXNLSA;

	// Token: 0x0400086E RID: 2158
	public int VuyUSeRQwbUbdgQTiEKcLyAArdqj;
}
