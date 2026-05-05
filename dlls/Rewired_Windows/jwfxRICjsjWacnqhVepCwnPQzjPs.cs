using System;

// Token: 0x02000160 RID: 352
internal struct jwfxRICjsjWacnqhVepCwnPQzjPs
{
	// Token: 0x06000B71 RID: 2929 RVA: 0x0003E0A4 File Offset: 0x0003C2A4
	public static jwfxRICjsjWacnqhVepCwnPQzjPs WNryMrsYLXtJFhnepWEbirdfNknG(byte[] A_0, int A_1)
	{
		jwfxRICjsjWacnqhVepCwnPQzjPs result = default(jwfxRICjsjWacnqhVepCwnPQzjPs);
		if (jwfxRICjsjWacnqhVepCwnPQzjPs.kbpdIzJaKvsXjHfdhbllxpvDYRtqA)
		{
			result.PNwDTuJyXbjUTCbetKTfeNcmcwqZA = BitConverter.ToInt64(A_0, A_1);
		}
		else
		{
			result.ErPgvfktqsikqRomdqSYHRgmgfNL = BitConverter.ToInt32(A_0, A_1);
		}
		return result;
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x00017F71 File Offset: 0x00016171
	public static int RHUZuWpypXuFTsDixbsWslJXUGwI(jwfxRICjsjWacnqhVepCwnPQzjPs A_0)
	{
		if (jwfxRICjsjWacnqhVepCwnPQzjPs.kbpdIzJaKvsXjHfdhbllxpvDYRtqA)
		{
			return (int)A_0.PNwDTuJyXbjUTCbetKTfeNcmcwqZA;
		}
		return A_0.ErPgvfktqsikqRomdqSYHRgmgfNL;
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x00017F88 File Offset: 0x00016188
	public static long RHUZuWpypXuFTsDixbsWslJXUGwI(jwfxRICjsjWacnqhVepCwnPQzjPs A_0)
	{
		if (jwfxRICjsjWacnqhVepCwnPQzjPs.kbpdIzJaKvsXjHfdhbllxpvDYRtqA)
		{
			return A_0.PNwDTuJyXbjUTCbetKTfeNcmcwqZA;
		}
		return (long)A_0.ErPgvfktqsikqRomdqSYHRgmgfNL;
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x00017F9F File Offset: 0x0001619F
	public string VBlRbNOQDlUqxxgMXSEJCmgZnei()
	{
		if (jwfxRICjsjWacnqhVepCwnPQzjPs.kbpdIzJaKvsXjHfdhbllxpvDYRtqA)
		{
			return this.PNwDTuJyXbjUTCbetKTfeNcmcwqZA.ToString();
		}
		return this.ErPgvfktqsikqRomdqSYHRgmgfNL.ToString();
	}

	// Token: 0x04001572 RID: 5490
	private int ErPgvfktqsikqRomdqSYHRgmgfNL;

	// Token: 0x04001573 RID: 5491
	private long PNwDTuJyXbjUTCbetKTfeNcmcwqZA;

	// Token: 0x04001574 RID: 5492
	private static readonly bool kbpdIzJaKvsXjHfdhbllxpvDYRtqA = IntPtr.Size == 8;

	// Token: 0x04001575 RID: 5493
	public static readonly int moYcLhujPyTatOFwBCVEyfqfIhgn = jwfxRICjsjWacnqhVepCwnPQzjPs.kbpdIzJaKvsXjHfdhbllxpvDYRtqA ? 8 : 4;
}
