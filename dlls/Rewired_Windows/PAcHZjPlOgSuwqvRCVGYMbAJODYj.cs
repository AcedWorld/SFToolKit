using System;

// Token: 0x02000108 RID: 264
internal struct PAcHZjPlOgSuwqvRCVGYMbAJODYj : IEquatable<PAcHZjPlOgSuwqvRCVGYMbAJODYj>
{
	// Token: 0x060009BD RID: 2493 RVA: 0x000171C6 File Offset: 0x000153C6
	public PAcHZjPlOgSuwqvRCVGYMbAJODYj(int A_1, int A_2)
	{
		this.bpCsBPzfHsCQDCNAekRYLvAgfjUcb = A_1;
		this.YigYzBzGVmthImYaPkopHnMMoiCO = A_2;
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x000171D6 File Offset: 0x000153D6
	public bool Equals(PAcHZjPlOgSuwqvRCVGYMbAJODYj other)
	{
		return other.bpCsBPzfHsCQDCNAekRYLvAgfjUcb == this.bpCsBPzfHsCQDCNAekRYLvAgfjUcb && other.YigYzBzGVmthImYaPkopHnMMoiCO == this.YigYzBzGVmthImYaPkopHnMMoiCO;
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x000171F6 File Offset: 0x000153F6
	public bool JWLiJtJdsZiHmYgOZVGAQjmRfNly(object A_1)
	{
		return A_1 != null && !(A_1.GetType() != typeof(PAcHZjPlOgSuwqvRCVGYMbAJODYj)) && this.Equals((PAcHZjPlOgSuwqvRCVGYMbAJODYj)A_1);
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x00017222 File Offset: 0x00015422
	public int ddnBxwdbNbIOtqbAlTrpBkDaFQNXA()
	{
		return this.bpCsBPzfHsCQDCNAekRYLvAgfjUcb * 397 ^ this.YigYzBzGVmthImYaPkopHnMMoiCO;
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x00017237 File Offset: 0x00015437
	public static bool izErvFDsGkfPeHUzCoEKEszrggRJ(PAcHZjPlOgSuwqvRCVGYMbAJODYj A_0, PAcHZjPlOgSuwqvRCVGYMbAJODYj A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x00017241 File Offset: 0x00015441
	public static bool hCrQUQQJsJZjVVIvuFicgRsPvjGAA(PAcHZjPlOgSuwqvRCVGYMbAJODYj A_0, PAcHZjPlOgSuwqvRCVGYMbAJODYj A_1)
	{
		return !A_0.Equals(A_1);
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x0001724E File Offset: 0x0001544E
	public string bdqEXzDmTfSxnWFNztbXyilxBVhl()
	{
		return string.Format("({0},{1})", this.bpCsBPzfHsCQDCNAekRYLvAgfjUcb, this.YigYzBzGVmthImYaPkopHnMMoiCO);
	}

	// Token: 0x0400089A RID: 2202
	public static readonly PAcHZjPlOgSuwqvRCVGYMbAJODYj pXIeajFPzGWJCBjvqVzitxLRhQqp = new PAcHZjPlOgSuwqvRCVGYMbAJODYj(0, 0);

	// Token: 0x0400089B RID: 2203
	public static readonly PAcHZjPlOgSuwqvRCVGYMbAJODYj PbXBBnBZvIMxxDDFBedGIymxGGKk = PAcHZjPlOgSuwqvRCVGYMbAJODYj.pXIeajFPzGWJCBjvqVzitxLRhQqp;

	// Token: 0x0400089C RID: 2204
	public int bpCsBPzfHsCQDCNAekRYLvAgfjUcb;

	// Token: 0x0400089D RID: 2205
	public int YigYzBzGVmthImYaPkopHnMMoiCO;
}
