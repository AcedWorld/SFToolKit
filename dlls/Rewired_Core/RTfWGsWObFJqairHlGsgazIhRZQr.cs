using System;

// Token: 0x020004AE RID: 1198
internal static class RTfWGsWObFJqairHlGsgazIhRZQr
{
	// Token: 0x060030B0 RID: 12464 RVA: 0x000A9224 File Offset: 0x000A7424
	public static bool AKnOHdWWknnQvDAbsCxbDgAMUnbQA(int A_0)
	{
		if ((A_0 & 1) != 0)
		{
			int num = (int)Math.Sqrt((double)A_0);
			for (int i = 3; i <= num; i += 2)
			{
				if (A_0 % i == 0)
				{
					return false;
				}
			}
			return true;
		}
		return A_0 == 2;
	}

	// Token: 0x060030B1 RID: 12465 RVA: 0x000A9258 File Offset: 0x000A7458
	public static int UDYvUFmBNbGCFjvYZfgoTbkyGwcFb(int A_0)
	{
		if (A_0 < 0)
		{
			throw new ArgumentException("Arg_HTCapacityOverflow");
		}
		for (int i = 0; i < RTfWGsWObFJqairHlGsgazIhRZQr.FjQdeZoAayjhRUgOrqrgNdDnaSZk.Length; i++)
		{
			int num = RTfWGsWObFJqairHlGsgazIhRZQr.FjQdeZoAayjhRUgOrqrgNdDnaSZk[i];
			if (num >= A_0)
			{
				return num;
			}
		}
		for (int j = A_0 | 1; j < 2147483647; j += 2)
		{
			if (RTfWGsWObFJqairHlGsgazIhRZQr.AKnOHdWWknnQvDAbsCxbDgAMUnbQA(j) && (j - 1) % 101 != 0)
			{
				return j;
			}
		}
		return A_0;
	}

	// Token: 0x060030B2 RID: 12466 RVA: 0x0002540A File Offset: 0x0002360A
	public static int lEZImpYSfEguaqklSYOlYSEwNSaF()
	{
		return RTfWGsWObFJqairHlGsgazIhRZQr.FjQdeZoAayjhRUgOrqrgNdDnaSZk[0];
	}

	// Token: 0x060030B3 RID: 12467 RVA: 0x000A92BC File Offset: 0x000A74BC
	public static int kUzpkdUNdwlsKlkWifATGnbYgNoHA(int A_0)
	{
		int num = 2 * A_0;
		if (num > 2146435069 && 2146435069 > A_0)
		{
			return 2146435069;
		}
		return RTfWGsWObFJqairHlGsgazIhRZQr.UDYvUFmBNbGCFjvYZfgoTbkyGwcFb(num);
	}

	// Token: 0x04001AA4 RID: 6820
	public static readonly int[] FjQdeZoAayjhRUgOrqrgNdDnaSZk = new int[]
	{
		3,
		7,
		11,
		17,
		23,
		29,
		37,
		47,
		59,
		71,
		89,
		107,
		131,
		163,
		197,
		239,
		293,
		353,
		431,
		521,
		631,
		761,
		919,
		1103,
		1327,
		1597,
		1931,
		2333,
		2801,
		3371,
		4049,
		4861,
		5839,
		7013,
		8419,
		10103,
		12143,
		14591,
		17519,
		21023,
		25229,
		30293,
		36353,
		43627,
		52361,
		62851,
		75431,
		90523,
		108631,
		130363,
		156437,
		187751,
		225307,
		270371,
		324449,
		389357,
		467237,
		560689,
		672827,
		807403,
		968897,
		1162687,
		1395263,
		1674319,
		2009191,
		2411033,
		2893249,
		3471899,
		4166287,
		4999559,
		5999471,
		7199369
	};

	// Token: 0x04001AA5 RID: 6821
	public const int AYLfStORToeHLzmGSkcPPgNGSBob = 101;

	// Token: 0x04001AA6 RID: 6822
	public const int vjDvXXYjAnmGmagpRlHCBpPvoQFy = 2146435069;
}
