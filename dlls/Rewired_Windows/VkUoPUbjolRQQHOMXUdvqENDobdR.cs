using System;

// Token: 0x020000E5 RID: 229
internal class VkUoPUbjolRQQHOMXUdvqENDobdR : IDisposable
{
	// Token: 0x1700018A RID: 394
	// (get) Token: 0x06000802 RID: 2050 RVA: 0x00015AA1 File Offset: 0x00013CA1
	public int UCOcLwiVHkvXbHHyacYyZPfShTtu
	{
		get
		{
			return this.sMvytZZfSSZpwbDSfQdmVYVSvCIK;
		}
	}

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06000803 RID: 2051 RVA: 0x00015AA9 File Offset: 0x00013CA9
	public int HxDgEQwfavBLmvjWfXAzcCFQhafKA
	{
		get
		{
			return this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU;
		}
	}

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06000804 RID: 2052 RVA: 0x00038CF8 File Offset: 0x00036EF8
	public bool[] JkfEFkzkkzSagqNbdtAnmhmUBXLfA
	{
		get
		{
			bool[] result;
			if ((result = this.OQiwFHqzfBffwAAnKLtISeQmCKDCA) == null)
			{
				result = (this.OQiwFHqzfBffwAAnKLtISeQmCKDCA = new bool[this.sMvytZZfSSZpwbDSfQdmVYVSvCIK]);
			}
			return result;
		}
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x00038D24 File Offset: 0x00036F24
	public VkUoPUbjolRQQHOMXUdvqENDobdR(int A_1, int A_2)
	{
		if (A_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU = A_1;
		this.sMvytZZfSSZpwbDSfQdmVYVSvCIK = A_2;
		int num = A_1 * A_2;
		int num2 = num / 8 + ((num % 8 != 0) ? 1 : 0);
		this.kacNtLUBuTQqHbfbUBsFqTtXciaW = new rldBWJiPNwVWNAQGlSaZBtbmtjRwA(num2);
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x00038D84 File Offset: 0x00036F84
	public unsafe void ghLqxBbdrhwjNkfCVtNsmmMijAWY(int A_1, byte* A_2, int A_3)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (A_2 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (A_3 < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + this.sMvytZZfSSZpwbDSfQdmVYVSvCIK.ToString() + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK; i++)
		{
			int num3;
			byte b;
			this.UJeKZyeGccRXCDpavXhOLTPjTHMi(A_1, i, out num3, out b);
			A_2[i] = (this.kacNtLUBuTQqHbfbUBsFqTtXciaW.HqVqpouAmVeHIigYUmzXdyHgyjYRB(num3, b) ? ((byte)((int)A_2[num] | 1 << num2)) : ((byte)((int)A_2[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x00015AB1 File Offset: 0x00013CB1
	public unsafe void LQpafxdHVqVOWQzjtqyrPUEjQZyr(int A_1, IntPtr A_2, int A_3)
	{
		if (A_2 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		this.ghLqxBbdrhwjNkfCVtNsmmMijAWY(A_1, (byte*)((void*)A_2), A_3);
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x00038E44 File Offset: 0x00037044
	public unsafe void CQAFTujXMXzxtlYOAnVSMtUDQAfJA(int A_1, out byte A_2)
	{
		byte b = 0;
		byte* ptr = &b;
		this.ghLqxBbdrhwjNkfCVtNsmmMijAWY(A_1, ptr, 64);
		A_2 = b;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x00038E64 File Offset: 0x00037064
	public void BBTBkaxhxbGfojLeDMXxtjvgCyoDA(int A_1, out sbyte A_2)
	{
		byte b;
		this.CQAFTujXMXzxtlYOAnVSMtUDQAfJA(A_1, out b);
		A_2 = (sbyte)b;
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x00038E80 File Offset: 0x00037080
	public unsafe void MApwbKxTzdRHLvqFFKdybQEOPsig(int A_1, out short A_2)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		this.ghLqxBbdrhwjNkfCVtNsmmMijAWY(A_1, ptr, 64);
		A_2 = num;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x00038EA0 File Offset: 0x000370A0
	public void XahbCsDbrkScVBHDBczBcnlzPdqKA(int A_1, out ushort A_2)
	{
		short num;
		this.MApwbKxTzdRHLvqFFKdybQEOPsig(A_1, out num);
		A_2 = (ushort)num;
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00038EBC File Offset: 0x000370BC
	public unsafe void ylecVXtQkSAMWQGglUjFAjUyUKFS(int A_1, out int A_2)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		this.ghLqxBbdrhwjNkfCVtNsmmMijAWY(A_1, ptr, 64);
		A_2 = num;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00038EDC File Offset: 0x000370DC
	public void aWegYMFaysNgYClxAUcEHZpCFpVQA(int A_1, out uint A_2)
	{
		int num;
		this.ylecVXtQkSAMWQGglUjFAjUyUKFS(A_1, out num);
		A_2 = (uint)num;
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x00038EF8 File Offset: 0x000370F8
	public unsafe void AZhsqmknhrAMIfHKpWCjHsYnQEcl(int A_1, out long A_2)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		this.ghLqxBbdrhwjNkfCVtNsmmMijAWY(A_1, ptr, 64);
		A_2 = num;
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00038F1C File Offset: 0x0003711C
	public void kAUXHEUfSzCDmsWnreCZOtqZJYLL(int A_1, out ulong A_2)
	{
		long num;
		this.AZhsqmknhrAMIfHKpWCjHsYnQEcl(A_1, out num);
		A_2 = (ulong)num;
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00038F38 File Offset: 0x00037138
	public void QsoIdHRLFgqdhUuOJSORppWCnEHJ(int A_1, bool[] A_2)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (A_2 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (A_2.Length < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK)
		{
			throw new Exception("valueBuffer.Length must be >= " + this.sMvytZZfSSZpwbDSfQdmVYVSvCIK.ToString());
		}
		for (int i = 0; i < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK; i++)
		{
			int num;
			byte b;
			this.UJeKZyeGccRXCDpavXhOLTPjTHMi(A_1, i, out num, out b);
			A_2[i] = this.kacNtLUBuTQqHbfbUBsFqTtXciaW.HqVqpouAmVeHIigYUmzXdyHgyjYRB(num, b);
		}
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00038FC4 File Offset: 0x000371C4
	public unsafe void RjsyTAbnxpqTmSoCkBSrlxZQGLiD(int A_1, byte* A_2, int A_3)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (A_2 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (A_3 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK; i++)
		{
			int num3;
			byte b;
			this.UJeKZyeGccRXCDpavXhOLTPjTHMi(A_1, i, out num3, out b);
			bool flag = i < A_3 && ((int)A_2[num] & 1 << num2) != 0;
			this.kacNtLUBuTQqHbfbUBsFqTtXciaW.PXsyXEMcCaLAMKvUQRFDUTxclDzv(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x00015AD9 File Offset: 0x00013CD9
	public unsafe void tGEwAJGIvWwTOtrrUOiuXuuFgKoW(int A_1, IntPtr A_2, int A_3)
	{
		if (A_2 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		this.RjsyTAbnxpqTmSoCkBSrlxZQGLiD(A_1, (byte*)((void*)A_2), A_3);
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x00039064 File Offset: 0x00037264
	public unsafe void nYojNKSiwhqblbKiSlEfzLHPnMZV(int A_1, byte A_2)
	{
		byte* ptr = &A_2;
		this.RjsyTAbnxpqTmSoCkBSrlxZQGLiD(A_1, ptr, 8);
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x00015B01 File Offset: 0x00013D01
	public void NXVUnZbDJoFVESjoQIHxXXqiGaGp(int A_1, sbyte A_2)
	{
		this.nYojNKSiwhqblbKiSlEfzLHPnMZV(A_1, (byte)A_2);
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x00039080 File Offset: 0x00037280
	public unsafe void jpuKcQDdCcKyWnmRCaPmyyBdyMCe(int A_1, short A_2)
	{
		byte* ptr = (byte*)(&A_2);
		this.RjsyTAbnxpqTmSoCkBSrlxZQGLiD(A_1, ptr, 16);
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x00015B0C File Offset: 0x00013D0C
	public void SBTrEFBFALddAjdpYXHkTQKweoneA(int A_1, ushort A_2)
	{
		this.jpuKcQDdCcKyWnmRCaPmyyBdyMCe(A_1, (short)A_2);
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x0003909C File Offset: 0x0003729C
	public unsafe void DJRRHpFWQsNQLSiXHItvRCsTIrAB(int A_1, int A_2)
	{
		byte* ptr = (byte*)(&A_2);
		this.RjsyTAbnxpqTmSoCkBSrlxZQGLiD(A_1, ptr, 32);
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x00015B17 File Offset: 0x00013D17
	public void pNapfscaotjnOCdIXTtTbentqwth(int A_1, uint A_2)
	{
		this.DJRRHpFWQsNQLSiXHItvRCsTIrAB(A_1, (int)A_2);
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x000390B8 File Offset: 0x000372B8
	public unsafe void gWQpMVrmFaTgYkrRbgzSoiZzJiAx(int A_1, long A_2)
	{
		byte* ptr = (byte*)(&A_2);
		this.RjsyTAbnxpqTmSoCkBSrlxZQGLiD(A_1, ptr, 64);
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00015B21 File Offset: 0x00013D21
	public void fZEnTgZBlybYBsISQZFlmsqZSnIS(int A_1, ulong A_2)
	{
		this.gWQpMVrmFaTgYkrRbgzSoiZzJiAx(A_1, (long)A_2);
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x000390D4 File Offset: 0x000372D4
	public void tfdpZvqkmzboUOdGpXLsdihvOjpV(int A_1, bool[] A_2)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (A_2 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (A_2.Length < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK)
		{
			throw new Exception("valueBuffer.Length must be >= " + this.sMvytZZfSSZpwbDSfQdmVYVSvCIK.ToString());
		}
		for (int i = 0; i < this.sMvytZZfSSZpwbDSfQdmVYVSvCIK; i++)
		{
			int num;
			byte b;
			this.UJeKZyeGccRXCDpavXhOLTPjTHMi(A_1, i, out num, out b);
			this.kacNtLUBuTQqHbfbUBsFqTtXciaW.PXsyXEMcCaLAMKvUQRFDUTxclDzv(num, b, A_2[i]);
		}
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x00039160 File Offset: 0x00037360
	private void UJeKZyeGccRXCDpavXhOLTPjTHMi(int A_1, int A_2, out int A_3, out byte A_4)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (A_2 < 0 || A_2 >= this.sMvytZZfSSZpwbDSfQdmVYVSvCIK)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = A_1 * this.sMvytZZfSSZpwbDSfQdmVYVSvCIK + A_2;
		A_3 = num / this.sMvytZZfSSZpwbDSfQdmVYVSvCIK;
		A_4 = (byte)(num - A_3 * this.sMvytZZfSSZpwbDSfQdmVYVSvCIK);
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000391C4 File Offset: 0x000373C4
	private int CmdJGjLnFkjWSFNTcvSbklfWkyCOA(int A_1, out byte A_2)
	{
		if (A_1 < 0 || A_1 >= this.qzBFJDDlQrUAjHHIvBCwIgfvmBwU * this.sMvytZZfSSZpwbDSfQdmVYVSvCIK)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = A_1 / this.sMvytZZfSSZpwbDSfQdmVYVSvCIK;
		A_2 = (byte)(A_1 - num * this.sMvytZZfSSZpwbDSfQdmVYVSvCIK);
		return num;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00015B2B File Offset: 0x00013D2B
	public void Dispose()
	{
		this.kuhxifSjwBDEwPiieYGAMqWnIhid(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x00039208 File Offset: 0x00037408
	protected virtual void sMORzvSMHsAQCuIrEofWBXTlTCbP()
	{
		try
		{
			this.kuhxifSjwBDEwPiieYGAMqWnIhid(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x00015B3A File Offset: 0x00013D3A
	protected virtual void kuhxifSjwBDEwPiieYGAMqWnIhid(bool A_1)
	{
		if (this.ZryfkFkzfkNKLtlKWRVjvdKJtHU)
		{
			return;
		}
		if (A_1 && this.kacNtLUBuTQqHbfbUBsFqTtXciaW != null)
		{
			this.kacNtLUBuTQqHbfbUBsFqTtXciaW.Dispose();
		}
		this.ZryfkFkzfkNKLtlKWRVjvdKJtHU = true;
	}

	// Token: 0x04000847 RID: 2119
	private readonly rldBWJiPNwVWNAQGlSaZBtbmtjRwA kacNtLUBuTQqHbfbUBsFqTtXciaW;

	// Token: 0x04000848 RID: 2120
	private bool[] OQiwFHqzfBffwAAnKLtISeQmCKDCA;

	// Token: 0x04000849 RID: 2121
	protected readonly int sMvytZZfSSZpwbDSfQdmVYVSvCIK;

	// Token: 0x0400084A RID: 2122
	protected readonly int qzBFJDDlQrUAjHHIvBCwIgfvmBwU;

	// Token: 0x0400084B RID: 2123
	private bool ZryfkFkzfkNKLtlKWRVjvdKJtHU;
}
