using System;
using Rewired.Utils;

// Token: 0x020000E9 RID: 233
internal static class rDYcHfJUMVKfEiJasMCndFkbsfgPB
{
	// Token: 0x0600084E RID: 2126 RVA: 0x00015E8B File Offset: 0x0001408B
	private unsafe static void PCODZfgDvEBaJIpeEgSLsryTUbcCB(byte* A_0, byte* A_1, int A_2)
	{
		if (A_2 < 0)
		{
			throw new Exception("Negative length in memcopy!");
		}
		if (SystemInfo.is64Bit)
		{
			rDYcHfJUMVKfEiJasMCndFkbsfgPB.htvLyipAIxGGALJHXWcdDrvmqHhv(A_0, A_1, (ulong)((long)A_2));
			return;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.msiGwlImHLVJGEsIJLqqryjNHWuB(A_0, A_1, (uint)A_2);
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x00039790 File Offset: 0x00037990
	private unsafe static void msiGwlImHLVJGEsIJLqqryjNHWuB(byte* A_0, byte* A_1, uint A_2)
	{
		if (A_0 - A_1 < A_2)
		{
			throw new Exception("Overlapping buffers not supported!");
		}
		switch (A_2)
		{
		case 0U:
			return;
		case 1U:
			*A_0 = *A_1;
			return;
		case 2U:
			*(short*)A_0 = *(short*)A_1;
			return;
		case 3U:
			*(short*)A_0 = *(short*)A_1;
			A_0[2] = A_1[2];
			return;
		case 4U:
			*(int*)A_0 = *(int*)A_1;
			return;
		case 5U:
			*(int*)A_0 = *(int*)A_1;
			A_0[4] = A_1[4];
			return;
		case 6U:
			*(int*)A_0 = *(int*)A_1;
			*(short*)(A_0 + 4) = *(short*)(A_1 + 4);
			return;
		case 7U:
			*(int*)A_0 = *(int*)A_1;
			*(short*)(A_0 + 4) = *(short*)(A_1 + 4);
			A_0[6] = A_1[6];
			return;
		case 8U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			return;
		case 9U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			A_0[8] = A_1[8];
			return;
		case 10U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(short*)(A_0 + 8) = *(short*)(A_1 + 8);
			return;
		case 11U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(short*)(A_0 + 8) = *(short*)(A_1 + 8);
			A_0[10] = A_1[10];
			return;
		case 12U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
			return;
		case 13U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
			A_0[12] = A_1[12];
			return;
		case 14U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
			*(short*)(A_0 + 12) = *(short*)(A_1 + 12);
			return;
		case 15U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
			*(short*)(A_0 + 12) = *(short*)(A_1 + 12);
			A_0[14] = A_1[14];
			return;
		case 16U:
			*(int*)A_0 = *(int*)A_1;
			*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
			*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
			*(int*)(A_0 + 12) = *(int*)(A_1 + 12);
			return;
		default:
			if ((A_0 & 3) != 0)
			{
				if ((A_0 & 1) != 0)
				{
					*A_0 = *A_1;
					A_1++;
					A_0++;
					A_2 -= 1U;
					if ((A_0 & 2) == 0)
					{
						goto IL_1D7;
					}
				}
				*(short*)A_0 = *(short*)A_1;
				A_1 += 2;
				A_0 += 2;
				A_2 -= 2U;
			}
			IL_1D7:
			for (uint num = A_2 / 16U; num > 0U; num -= 1U)
			{
				*(int*)A_0 = *(int*)A_1;
				*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
				*(int*)(A_0 + (IntPtr)2 * 4) = *(int*)(A_1 + (IntPtr)2 * 4);
				*(int*)(A_0 + (IntPtr)3 * 4) = *(int*)(A_1 + (IntPtr)3 * 4);
				A_0 += 16;
				A_1 += 16;
			}
			if ((A_2 & 8U) != 0U)
			{
				*(int*)A_0 = *(int*)A_1;
				*(int*)(A_0 + 4) = *(int*)(A_1 + 4);
				A_0 += 8;
				A_1 += 8;
			}
			if ((A_2 & 4U) != 0U)
			{
				*(int*)A_0 = *(int*)A_1;
				A_0 += 4;
				A_1 += 4;
			}
			if ((A_2 & 2U) != 0U)
			{
				*(short*)A_0 = *(short*)A_1;
				A_0 += 2;
				A_1 += 2;
			}
			if ((A_2 & 1U) != 0U)
			{
				*A_0 = *A_1;
			}
			return;
		}
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x00039A04 File Offset: 0x00037C04
	private unsafe static void htvLyipAIxGGALJHXWcdDrvmqHhv(byte* A_0, byte* A_1, ulong A_2)
	{
		if ((ulong)(A_0 - A_1) < A_2)
		{
			throw new Exception("Overlapping buffers not supported!");
		}
		ulong num = A_2;
		if (num <= 16UL)
		{
			switch ((uint)num)
			{
			case 0U:
				return;
			case 1U:
				*A_0 = *A_1;
				return;
			case 2U:
				*(short*)A_0 = *(short*)A_1;
				return;
			case 3U:
				*(short*)A_0 = *(short*)A_1;
				A_0[2] = A_1[2];
				return;
			case 4U:
				*(int*)A_0 = *(int*)A_1;
				return;
			case 5U:
				*(int*)A_0 = *(int*)A_1;
				A_0[4] = A_1[4];
				return;
			case 6U:
				*(int*)A_0 = *(int*)A_1;
				*(short*)(A_0 + 4) = *(short*)(A_1 + 4);
				return;
			case 7U:
				*(int*)A_0 = *(int*)A_1;
				*(short*)(A_0 + 4) = *(short*)(A_1 + 4);
				A_0[6] = A_1[6];
				return;
			case 8U:
				*(long*)A_0 = *(long*)A_1;
				return;
			case 9U:
				*(long*)A_0 = *(long*)A_1;
				A_0[8] = A_1[8];
				return;
			case 10U:
				*(long*)A_0 = *(long*)A_1;
				*(short*)(A_0 + 8) = *(short*)(A_1 + 8);
				return;
			case 11U:
				*(long*)A_0 = *(long*)A_1;
				*(short*)(A_0 + 8) = *(short*)(A_1 + 8);
				A_0[10] = A_1[10];
				return;
			case 12U:
				*(long*)A_0 = *(long*)A_1;
				*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
				return;
			case 13U:
				*(long*)A_0 = *(long*)A_1;
				*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
				A_0[12] = A_1[12];
				return;
			case 14U:
				*(long*)A_0 = *(long*)A_1;
				*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
				*(short*)(A_0 + 12) = *(short*)(A_1 + 12);
				return;
			case 15U:
				*(long*)A_0 = *(long*)A_1;
				*(int*)(A_0 + 8) = *(int*)(A_1 + 8);
				*(short*)(A_0 + 12) = *(short*)(A_1 + 12);
				A_0[14] = A_1[14];
				return;
			case 16U:
				*(long*)A_0 = *(long*)A_1;
				*(long*)(A_0 + 8) = *(long*)(A_1 + 8);
				return;
			}
		}
		if ((A_0 & 3) != 0)
		{
			if ((A_0 & 1) != 0)
			{
				*A_0 = *A_1;
				A_1++;
				A_0++;
				A_2 -= 1UL;
				if ((A_0 & 2) == 0)
				{
					goto IL_194;
				}
			}
			*(short*)A_0 = *(short*)A_1;
			A_1 += 2;
			A_0 += 2;
			A_2 -= 2UL;
		}
		IL_194:
		if ((A_0 & 4) != 0)
		{
			*(int*)A_0 = *(int*)A_1;
			A_1 += 4;
			A_0 += 4;
			A_2 -= 4UL;
		}
		for (ulong num2 = A_2 / 16UL; num2 > 0UL; num2 -= 1UL)
		{
			*(long*)A_0 = *(long*)A_1;
			*(long*)(A_0 + 8) = *(long*)(A_1 + 8);
			A_0 += 16;
			A_1 += 16;
		}
		if ((A_2 & 8UL) != 0UL)
		{
			*(long*)A_0 = *(long*)A_1;
			A_0 += 8;
			A_1 += 8;
		}
		if ((A_2 & 4UL) != 0UL)
		{
			*(int*)A_0 = *(int*)A_1;
			A_0 += 4;
			A_1 += 4;
		}
		if ((A_2 & 2UL) != 0UL)
		{
			*(short*)A_0 = *(short*)A_1;
			A_0 += 2;
			A_1 += 2;
		}
		if ((A_2 & 1UL) != 0UL)
		{
			*A_0 = *A_1;
		}
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x00039C30 File Offset: 0x00037E30
	public unsafe static bool hXvSugMYGJQmEjgQOnuPWwFRdqIC(byte* A_0, byte* A_1, int A_2, int A_3, int A_4)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (A_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (A_2 < 0 || A_3 < 0 || A_4 < 0)
		{
			throw new Exception("Index and bytesToCopy must be non-negative!");
		}
		if (SystemInfo.is64Bit)
		{
			rDYcHfJUMVKfEiJasMCndFkbsfgPB.htvLyipAIxGGALJHXWcdDrvmqHhv(A_1 + A_3, A_0 + A_2, checked((ulong)A_4));
		}
		else
		{
			rDYcHfJUMVKfEiJasMCndFkbsfgPB.msiGwlImHLVJGEsIJLqqryjNHWuB(A_1 + A_3, A_0 + A_2, checked((uint)A_4));
		}
		return true;
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00015EB5 File Offset: 0x000140B5
	public unsafe static bool TFcjZNvRvMqSstckecwhetgWqiARA(IntPtr A_0, IntPtr A_1, int A_2, int A_3, int A_4)
	{
		return rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC((byte*)((void*)A_0), (byte*)((void*)A_1), A_2, A_3, A_4);
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00015ECC File Offset: 0x000140CC
	public unsafe static bool vmzZEPSKPeXEfYueidZROUbjvCgN(byte* A_0, byte* A_1, int A_2, int A_3, int A_4)
	{
		if (SystemInfo.is64Bit)
		{
			rDYcHfJUMVKfEiJasMCndFkbsfgPB.htvLyipAIxGGALJHXWcdDrvmqHhv(A_1 + A_3, A_0 + A_2, checked((ulong)A_4));
		}
		else
		{
			rDYcHfJUMVKfEiJasMCndFkbsfgPB.msiGwlImHLVJGEsIJLqqryjNHWuB(A_1 + A_3, A_0 + A_2, checked((uint)A_4));
		}
		return true;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x00039C9C File Offset: 0x00037E9C
	public unsafe static void SCyGjgOnlZPdVplOabQlJqZFNOkvA(byte* A_0, int A_1)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (A_1 >= 8)
		{
			int num = A_1 / 8 * 8;
			for (int i = 0; i < num; i += 8)
			{
				*(long*)(A_0 + i) = 0L;
			}
			for (int j = num; j < A_1; j++)
			{
				A_0[j] = 0;
			}
			return;
		}
		for (int k = 0; k < A_1; k++)
		{
			A_0[k] = 0;
		}
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00015EF4 File Offset: 0x000140F4
	public unsafe static void YdWgWBPBnXJfLDQFsdmrEiwipxFeA(IntPtr A_0, int A_1)
	{
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.SCyGjgOnlZPdVplOabQlJqZFNOkvA((byte*)((void*)A_0), A_1);
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00015F02 File Offset: 0x00014102
	public unsafe static bool ddxTIVLLqzIwtcaSeXjgGSIiNxoU(byte* A_0, int A_1, byte A_2, bool A_3 = true)
	{
		return rDYcHfJUMVKfEiJasMCndFkbsfgPB.imzSeYmgZwbsjHrVppDJCVnYFrHU(A_0, A_1, 0, A_1, A_2, A_3);
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x00039CF8 File Offset: 0x00037EF8
	public unsafe static bool imzSeYmgZwbsjHrVppDJCVnYFrHU(byte* A_0, int A_1, int A_2, int A_3, byte A_4, bool A_5 = true)
	{
		if (!A_5)
		{
			if (A_0 == null)
			{
				return false;
			}
			if (A_1 <= 0)
			{
				return false;
			}
			if (A_2 < 0)
			{
				A_2 = 0;
			}
			if (A_3 <= 0)
			{
				return false;
			}
			if (A_2 + A_3 > A_1)
			{
				return false;
			}
		}
		else
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (A_1 <= 0)
			{
				throw new Exception("bufferLength must be > 0");
			}
			if (A_2 < 0)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex");
			}
			if (A_3 <= 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (A_2 + A_3 > A_1)
			{
				throw new Exception("startIndex + length must be less than or equal to bufferLength.");
			}
		}
		if (A_2 > 0)
		{
			A_0 += A_2;
		}
		if (A_3 >= 8)
		{
			long* ptr = (long*)A_0;
			int num = A_3 / 8;
			if (A_4 != 0)
			{
				long num2 = 0L;
				byte* ptr2 = (byte*)(&num2);
				for (int i = 0; i < 8; i++)
				{
					ptr2[i] = A_4;
				}
				for (int j = 0; j < num; j++)
				{
					ptr[j] = num2;
				}
			}
			else
			{
				for (int k = 0; k < num; k++)
				{
					ptr[k] = 0L;
				}
			}
			for (int l = num * 8; l < A_3; l++)
			{
				A_0[l] = A_4;
			}
		}
		else
		{
			for (int m = 0; m < A_3; m++)
			{
				A_0[m] = A_4;
			}
		}
		return true;
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x00015F0F File Offset: 0x0001410F
	public unsafe static bool dzMTosGBbISnxPCzZUFArnbhguqX(IntPtr A_0, int A_1, byte A_2, bool A_3 = true)
	{
		return rDYcHfJUMVKfEiJasMCndFkbsfgPB.imzSeYmgZwbsjHrVppDJCVnYFrHU((byte*)((void*)A_0), A_1, 0, A_1, A_2, A_3);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x00015F21 File Offset: 0x00014121
	public unsafe static bool RoFCNIxQHVdDPPFmjedqBSsRCoZBA(IntPtr A_0, int A_1, int A_2, int A_3, byte A_4, bool A_5 = true)
	{
		return rDYcHfJUMVKfEiJasMCndFkbsfgPB.imzSeYmgZwbsjHrVppDJCVnYFrHU((byte*)((void*)A_0), A_1, A_2, A_3, A_4, A_5);
	}
}
