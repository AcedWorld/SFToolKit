using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x020000E0 RID: 224
[DefaultMember("Item")]
internal struct SJAJLDiJOLyVqzEpDZsiUQxoqTZV : IDisposable
{
	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06000799 RID: 1945 RVA: 0x00015432 File Offset: 0x00013632
	public unsafe byte* SfHVrRAhJHgOPBXisFgTLEhBMoAGA
	{
		get
		{
			return this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb;
		}
	}

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x0600079A RID: 1946 RVA: 0x0001543A File Offset: 0x0001363A
	public unsafe IntPtr XhpwlpdGhamjCXfwZzdjbICWIsRKA
	{
		get
		{
			return (IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb);
		}
	}

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x0600079B RID: 1947 RVA: 0x00015447 File Offset: 0x00013647
	public int pDzAzUbFRJhJxkrDuCrObmvIysWcc
	{
		get
		{
			return this.lYzsjgJOPcqqckqOTuUBCFgpRQWG;
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x0600079C RID: 1948 RVA: 0x0001544F File Offset: 0x0001364F
	// (set) Token: 0x0600079D RID: 1949 RVA: 0x0001546D File Offset: 0x0001366D
	public unsafe byte MotltqHoZsKqwWcVNRRioOlUisJy
	{
		get
		{
			if (A_1 < 0 || A_1 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
			{
				throw new IndexOutOfRangeException();
			}
			return this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[A_1];
		}
		set
		{
			if (A_1 < 0 || A_1 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
			{
				throw new IndexOutOfRangeException();
			}
			this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[A_1] = value;
		}
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x0001548C File Offset: 0x0001368C
	public SJAJLDiJOLyVqzEpDZsiUQxoqTZV(int A_1)
	{
		this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb = null;
		this.lYzsjgJOPcqqckqOTuUBCFgpRQWG = 0;
		this.iDxDSGDDnVEeoAlldxWLYJjRnczw = false;
		this.yxlzMWrVVUAYfxhVWefAgXknwqgS(A_1);
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x000154AC File Offset: 0x000136AC
	public unsafe IntPtr enidhMPFmPHHcbDGKmORvRHuVjyZ(int A_1 = 0)
	{
		if (A_1 == 0)
		{
			return (IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb);
		}
		if (A_1 < 0 || A_1 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)((void*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1));
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x00037D5C File Offset: 0x00035F5C
	public unsafe string hWvpiUabKLrExxsaoRZgjvgFnlUR()
	{
		string text = "";
		for (int i = 0; i < this.lYzsjgJOPcqqckqOTuUBCFgpRQWG; i++)
		{
			text = text + this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[i].ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x000154E2 File Offset: 0x000136E2
	public unsafe bool oblPoCzuGGMFXDGJGfCaBfBtQImTA(int A_1, byte A_2)
	{
		if (1 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return ((int)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[A_1] & 1 << (int)A_2) != 0;
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x00015520 File Offset: 0x00013720
	public unsafe byte ORTlSYVQXImyiqfcrvLZmoqAiQsK(int A_1)
	{
		if (1 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[A_1];
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00015545 File Offset: 0x00013745
	public unsafe short hwDokToVfoFkUbjMOqCZhAvBedwg(int A_1)
	{
		if (2 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1);
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x0001556A File Offset: 0x0001376A
	public unsafe ushort YuYqUXmKYHPDqavppYiBvNWasbnm(int A_1)
	{
		if (2 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1);
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x0001558F File Offset: 0x0001378F
	public unsafe int hbJWlJmrAsdfQavrxHKJKuXoeNvr(int A_1)
	{
		if (4 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1);
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000155B4 File Offset: 0x000137B4
	public unsafe uint QhfGOhgeDOkekhiUIydMvpXfUXeZB(int A_1)
	{
		if (4 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1);
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x000155D9 File Offset: 0x000137D9
	public unsafe long INZFunkTMxxXnjVuGhUZyeSwAtNFA(int A_1)
	{
		if (8 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1);
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x000155D9 File Offset: 0x000137D9
	public unsafe ulong rtFbMDTBGQbpikqtSXiJXZTeWoUC(int A_1)
	{
		if (8 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return (ulong)(*(long*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1));
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x00037DA0 File Offset: 0x00035FA0
	public unsafe void gScwOnYgsAdBBHTyxcLBRQjdjIMU(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = A_1.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (A_2 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (A_4 >= num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (A_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (A_3 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (A_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (A_4 + A_2 > num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (A_2 + A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb), A_1, A_3, A_4, A_2, true);
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x00037E84 File Offset: 0x00036084
	public unsafe void PCrGOjeKQtbxdrKAbBBrGDChRbeOb(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (A_3 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (A_3 > A_2)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (A_5 >= A_2)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (A_5 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (A_4 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (A_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (A_5 + A_3 > A_2)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (A_3 + A_4 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, A_1, A_4, A_5, A_3);
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x000155FE File Offset: 0x000137FE
	public unsafe void vFGHiPDCaEADwfMCWKgrhLUaGYN(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		this.PCrGOjeKQtbxdrKAbBBrGDChRbeOb((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00037F64 File Offset: 0x00036164
	public unsafe int BhqzRIgVEJGBDcSbvGysNzzdyPYe(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null || A_2 <= 0)
		{
			return 0;
		}
		int num = A_1.Length;
		if (num == 0)
		{
			return 0;
		}
		if (A_3 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			return 0;
		}
		if (A_4 >= num)
		{
			return 0;
		}
		if (A_3 < 0)
		{
			A_3 = 0;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_3 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			A_2 = this.lYzsjgJOPcqqckqOTuUBCFgpRQWG - A_3;
		}
		if (A_4 + A_2 > num)
		{
			A_2 = num - A_4;
		}
		if (A_2 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb), A_1, A_3, A_4, A_2, true);
		return A_2;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x00037FE4 File Offset: 0x000361E4
	public unsafe int tIRvnsJmpiloMAMGkUPGjkoaezLx(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null || A_3 <= 0)
		{
			return 0;
		}
		if (A_4 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			return 0;
		}
		if (A_5 >= A_2)
		{
			return 0;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_5 < 0)
		{
			A_5 = 0;
		}
		if (A_4 + A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			A_3 = this.lYzsjgJOPcqqckqOTuUBCFgpRQWG - A_4;
		}
		if (A_5 + A_3 > A_2)
		{
			A_3 = A_2 - A_5;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, A_1, A_4, A_5, A_3);
		return A_3;
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x00015612 File Offset: 0x00013812
	public unsafe int qHCVfRjnIJpmhfNzTbaUAgWOpTh(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero)
		{
			return 0;
		}
		return this.tIRvnsJmpiloMAMGkUPGjkoaezLx((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x00038058 File Offset: 0x00036258
	public unsafe void xrGreczUERubXuPxeZQjWlNUTSbm(int A_1, byte A_2, bool A_3)
	{
		if (1 + A_1 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (A_3)
		{
			byte* ptr = this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1;
			*ptr |= (byte)(1 << (int)A_2);
			return;
		}
		byte* ptr2 = this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_1;
		*ptr2 &= (byte)(~(byte)(1 << (int)A_2));
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x00015635 File Offset: 0x00013835
	public unsafe void ERyAyczKzWdWIOlkcoIYvobLisaL(byte A_1, int A_2)
	{
		if (1 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb[A_2] = A_1;
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x0001565B File Offset: 0x0001385B
	public unsafe void QZPQRNCfOzcYwobYrnDJsWSaTCzR(short A_1, int A_2)
	{
		if (2 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = A_1;
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x0001565B File Offset: 0x0001385B
	public unsafe void VzGhVGCntCkkfsilvxyIROmdkhhg(ushort A_1, int A_2)
	{
		if (2 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = (short)A_1;
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x00015681 File Offset: 0x00013881
	public unsafe void xzxtNjQxQStfJKQQdSYSDBfQZudw(int A_1, int A_2)
	{
		if (4 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = A_1;
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x00015681 File Offset: 0x00013881
	public unsafe void VIGWCmWKxPoTRUYAtmKdjXFNcpbT(uint A_1, int A_2)
	{
		if (4 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = (int)A_1;
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x000156A7 File Offset: 0x000138A7
	public unsafe void SOiuyhTfVwXrBsNsRULNvmHwualt(long A_1, int A_2)
	{
		if (8 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = A_1;
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000156A7 File Offset: 0x000138A7
	public unsafe void TgTBecjVteAQXGKxCdnzUFHVEiWNA(ulong A_1, int A_2)
	{
		if (8 + A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb + A_2) = (long)A_1;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000380BC File Offset: 0x000362BC
	public unsafe void OJGLbKfIOjeyohQZNPNPofPEiYGH(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = A_1.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (A_2 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (A_2 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (A_4 >= num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (A_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (A_3 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (A_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (A_4 + A_2 > num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (A_2 + A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(A_1, (IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb), A_4, A_3, A_2, true);
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x000381A0 File Offset: 0x000363A0
	public unsafe void BJajNmWGIvMPAhZIVJzXHARxjZgC(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (A_3 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (A_3 > A_2)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (A_5 >= A_2)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (A_5 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (A_4 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (A_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (A_5 + A_3 > A_2)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (A_3 + A_4 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(A_1, this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, A_5, A_4, A_3);
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x000156CD File Offset: 0x000138CD
	public unsafe void tJVzgEaNrgNuDfJvqQBIKHPCaJnL(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		this.BJajNmWGIvMPAhZIVJzXHARxjZgC((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x00038280 File Offset: 0x00036480
	public unsafe int NBjXpAqEyNyVQnUiiVfSBNJCcTJt(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null)
		{
			return 0;
		}
		int num = A_1.Length;
		if (num == 0 || A_2 <= 0 || A_4 >= num || A_3 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			return 0;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_3 < 0)
		{
			A_3 = 0;
		}
		if (A_4 + A_2 > num)
		{
			A_2 = num - A_4;
		}
		if (A_2 + A_3 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			A_2 = this.lYzsjgJOPcqqckqOTuUBCFgpRQWG - A_3;
		}
		NativeTools.CopyMemory(A_1, (IntPtr)((void*)this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb), A_4, A_3, A_2, true);
		return A_2;
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000382F8 File Offset: 0x000364F8
	public unsafe int AbhpzuVQkzcvsZrybDxlCKnvbaWN(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null || A_2 <= 0 || A_3 <= 0 || A_5 >= A_2 || A_4 >= this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			return 0;
		}
		if (A_5 < 0)
		{
			A_5 = 0;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_5 + A_3 > A_2)
		{
			A_3 = A_2 - A_5;
		}
		if (A_3 + A_4 > this.lYzsjgJOPcqqckqOTuUBCFgpRQWG)
		{
			A_3 = this.lYzsjgJOPcqqckqOTuUBCFgpRQWG - A_4;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(A_1, this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, A_5, A_4, A_3);
		return A_3;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x000156E1 File Offset: 0x000138E1
	public unsafe int AQhaHBxuNbvDWXbBEGwfsXLjdVik(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		return this.AbhpzuVQkzcvsZrybDxlCKnvbaWN((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x0003836C File Offset: 0x0003656C
	public unsafe bool yxlzMWrVVUAYfxhVWefAgXknwqgS(int A_1)
	{
		if (A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (this.lYzsjgJOPcqqckqOTuUBCFgpRQWG == A_1)
		{
			return true;
		}
		this.PSTWUPPOnDACdULdSavJlarVewOD();
		if (A_1 == 0)
		{
			return true;
		}
		this.lYzsjgJOPcqqckqOTuUBCFgpRQWG = A_1;
		this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb = (byte*)((void*)Marshal.AllocHGlobal(A_1));
		this.vOcFkwQJvYvFRucSqFFBbvYfdYer();
		return true;
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000156F5 File Offset: 0x000138F5
	public void vOcFkwQJvYvFRucSqFFBbvYfdYer()
	{
		if (this.lYzsjgJOPcqqckqOTuUBCFgpRQWG == 0)
		{
			return;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.SCyGjgOnlZPdVplOabQlJqZFNOkvA(this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, this.lYzsjgJOPcqqckqOTuUBCFgpRQWG);
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000383C0 File Offset: 0x000365C0
	public void PSTWUPPOnDACdULdSavJlarVewOD()
	{
		if (this.lYzsjgJOPcqqckqOTuUBCFgpRQWG == 0)
		{
			return;
		}
		try
		{
			if (this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb != null)
			{
				Marshal.FreeHGlobal(this.XhpwlpdGhamjCXfwZzdjbICWIsRKA);
			}
		}
		catch
		{
		}
		this.llKeDuJqFmvRSFJZtOPgCJdDGNOrb = null;
		this.lYzsjgJOPcqqckqOTuUBCFgpRQWG = 0;
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x00038410 File Offset: 0x00036610
	public string lkMLgTBIdFSggLNQfAbTuQgGhlrdA()
	{
		string text = "";
		for (int i = 0; i < this.lYzsjgJOPcqqckqOTuUBCFgpRQWG; i++)
		{
			text = text + this.ORTlSYVQXImyiqfcrvLZmoqAiQsK(i).ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x00015711 File Offset: 0x00013911
	public void Dispose()
	{
		this.wCTXGKNcBWQKNMLXbmgQjNXxKZws(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x0001572A File Offset: 0x0001392A
	private void wCTXGKNcBWQKNMLXbmgQjNXxKZws(bool A_1)
	{
		if (this.iDxDSGDDnVEeoAlldxWLYJjRnczw)
		{
			return;
		}
		this.PSTWUPPOnDACdULdSavJlarVewOD();
		this.iDxDSGDDnVEeoAlldxWLYJjRnczw = true;
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x0001543A File Offset: 0x0001363A
	public unsafe static IntPtr qiOHAGJXQylWHBdMreaEwPBhalVy(SJAJLDiJOLyVqzEpDZsiUQxoqTZV A_0)
	{
		return (IntPtr)((void*)A_0.llKeDuJqFmvRSFJZtOPgCJdDGNOrb);
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x00015432 File Offset: 0x00013632
	public unsafe static void* qiOHAGJXQylWHBdMreaEwPBhalVy(SJAJLDiJOLyVqzEpDZsiUQxoqTZV A_0)
	{
		return (void*)A_0.llKeDuJqFmvRSFJZtOPgCJdDGNOrb;
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00015744 File Offset: 0x00013944
	public static bool LFYcxbEdHQemckaXemgheLvojhEw(SJAJLDiJOLyVqzEpDZsiUQxoqTZV A_0, SJAJLDiJOLyVqzEpDZsiUQxoqTZV A_1)
	{
		if (A_0.lYzsjgJOPcqqckqOTuUBCFgpRQWG == 0)
		{
			A_1.PSTWUPPOnDACdULdSavJlarVewOD();
			return true;
		}
		if (A_1.yxlzMWrVVUAYfxhVWefAgXknwqgS(A_0.lYzsjgJOPcqqckqOTuUBCFgpRQWG))
		{
			A_1.BJajNmWGIvMPAhZIVJzXHARxjZgC(A_0.llKeDuJqFmvRSFJZtOPgCJdDGNOrb, A_0.lYzsjgJOPcqqckqOTuUBCFgpRQWG, A_0.lYzsjgJOPcqqckqOTuUBCFgpRQWG, 0, 0);
			return true;
		}
		return false;
	}

	// Token: 0x04000830 RID: 2096
	private unsafe byte* llKeDuJqFmvRSFJZtOPgCJdDGNOrb;

	// Token: 0x04000831 RID: 2097
	private int lYzsjgJOPcqqckqOTuUBCFgpRQWG;

	// Token: 0x04000832 RID: 2098
	private bool iDxDSGDDnVEeoAlldxWLYJjRnczw;
}
