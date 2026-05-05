using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x020000DF RID: 223
[DefaultMember("Item")]
internal class rldBWJiPNwVWNAQGlSaZBtbmtjRwA : IDisposable
{
	// Token: 0x1700017E RID: 382
	// (get) Token: 0x06000767 RID: 1895 RVA: 0x00015080 File Offset: 0x00013280
	public unsafe byte* qkLRHlbrHhLfqzFiBGTLtKVnaStY
	{
		get
		{
			return this.vraMknjBoFWmecwYDuHfUYymkttW;
		}
	}

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x06000768 RID: 1896 RVA: 0x00015088 File Offset: 0x00013288
	public unsafe IntPtr pTqePlWfDkrAVqwmLmietZbIwjOh
	{
		get
		{
			return (IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW);
		}
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x06000769 RID: 1897 RVA: 0x00015095 File Offset: 0x00013295
	public int PTLkfnJgYepizzWbxMjqfLqDRATD
	{
		get
		{
			return this.sPSagrbsrlUiGJndKcOzMfYzwQXDA;
		}
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x0600076A RID: 1898 RVA: 0x0001509D File Offset: 0x0001329D
	// (set) Token: 0x0600076B RID: 1899 RVA: 0x000150BB File Offset: 0x000132BB
	public unsafe byte vwLvBEeoxrzKRqJEBjcfDWFlPPcp
	{
		get
		{
			if (A_1 < 0 || A_1 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
			{
				throw new IndexOutOfRangeException();
			}
			return this.vraMknjBoFWmecwYDuHfUYymkttW[A_1];
		}
		set
		{
			if (A_1 < 0 || A_1 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
			{
				throw new IndexOutOfRangeException();
			}
			this.vraMknjBoFWmecwYDuHfUYymkttW[A_1] = value;
		}
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x000150DA File Offset: 0x000132DA
	public rldBWJiPNwVWNAQGlSaZBtbmtjRwA(int A_1)
	{
		this.LSoycKIzDrtcVgeGNupPwfhFqePX(A_1);
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x000150EA File Offset: 0x000132EA
	public unsafe IntPtr VFHDJRGLpaUEBDfCaoRwSOLOKHwu(int A_1 = 0)
	{
		if (A_1 == 0)
		{
			return (IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW);
		}
		if (A_1 < 0 || A_1 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)((void*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1));
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x000375CC File Offset: 0x000357CC
	public unsafe string gaZQZTTaoxEdPDiEkScgchYBTTvEB()
	{
		string text = "";
		for (int i = 0; i < this.sPSagrbsrlUiGJndKcOzMfYzwQXDA; i++)
		{
			text = text + this.vraMknjBoFWmecwYDuHfUYymkttW[i].ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00015120 File Offset: 0x00013320
	public unsafe bool HqVqpouAmVeHIigYUmzXdyHgyjYRB(int A_1, byte A_2)
	{
		if (1 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return ((int)this.vraMknjBoFWmecwYDuHfUYymkttW[A_1] & 1 << (int)A_2) != 0;
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x0001515E File Offset: 0x0001335E
	public unsafe byte CYJMMdiYJjVPDvyTPacyRaCTEtKI(int A_1)
	{
		if (1 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return this.vraMknjBoFWmecwYDuHfUYymkttW[A_1];
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x00015183 File Offset: 0x00013383
	public unsafe short artGWpfDuoXwBCSzHGgoYPMLqoTUA(int A_1)
	{
		if (2 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x000151A8 File Offset: 0x000133A8
	public unsafe ushort OEJMNfNfIHdwkUGeTFjNjmVvyaLpA(int A_1)
	{
		if (2 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x000151CD File Offset: 0x000133CD
	public unsafe int GSABGssbkODStLrHojAITdspdnEAA(int A_1)
	{
		if (4 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x000151F2 File Offset: 0x000133F2
	public unsafe uint NCpARItmXfFKREUJiIyYGSQVAaVhb(int A_1)
	{
		if (4 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00015217 File Offset: 0x00013417
	public unsafe long nXKCoxnDHTyeuVTpKhXvOUUsIdFP(int A_1)
	{
		if (8 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x00015217 File Offset: 0x00013417
	public unsafe ulong BrttYYwfWGITlBuWKAtjuwHfxhIQ(int A_1)
	{
		if (8 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return (ulong)(*(long*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1));
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x0001523C File Offset: 0x0001343C
	public unsafe float RWFiNESkCZNxspmmkWkSelfeNVSR(int A_1)
	{
		if (4 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x00015261 File Offset: 0x00013461
	public unsafe double ESgCZzdNiTelFHQhjTTSkOskisAlB(int A_1)
	{
		if (8 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_1);
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x00037610 File Offset: 0x00035810
	public unsafe void PnIsiPNkVHlnCEWhdkEFqPhYbyMb(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_2 + A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW), A_1, A_3, A_4, A_2, true);
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x000376F4 File Offset: 0x000358F4
	public unsafe void qFLhTNaYVpcAFNdhuHFVLfsIjPgyA(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
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
		if (A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_4 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 + A_4 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.vraMknjBoFWmecwYDuHfUYymkttW, A_1, A_4, A_5, A_3);
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x00015286 File Offset: 0x00013486
	public unsafe void JmzsWKVQFxXbzeNNPwtTubjZVWhI(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		this.qFLhTNaYVpcAFNdhuHFVLfsIjPgyA((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x000377D4 File Offset: 0x000359D4
	public unsafe int fnZSoTaugrCzKfijjjSsIvNUeuFm(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_3 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			A_2 = this.sPSagrbsrlUiGJndKcOzMfYzwQXDA - A_3;
		}
		if (A_4 + A_2 > num)
		{
			A_2 = num - A_4;
		}
		if (A_2 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW), A_1, A_3, A_4, A_2, true);
		return A_2;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x00037854 File Offset: 0x00035A54
	public unsafe int GxwdbhBUTKUUkNdtiRFOCVSOxbvU(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null || A_3 <= 0)
		{
			return 0;
		}
		if (A_4 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_4 + A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			A_3 = this.sPSagrbsrlUiGJndKcOzMfYzwQXDA - A_4;
		}
		if (A_5 + A_3 > A_2)
		{
			A_3 = A_2 - A_5;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.vraMknjBoFWmecwYDuHfUYymkttW, A_1, A_4, A_5, A_3);
		return A_3;
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x0001529A File Offset: 0x0001349A
	public unsafe int CTZQSuelmOKFbLTAmgVgQzmKuVdf(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero)
		{
			return 0;
		}
		return this.GxwdbhBUTKUUkNdtiRFOCVSOxbvU((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x000378C8 File Offset: 0x00035AC8
	public unsafe void PXsyXEMcCaLAMKvUQRFDUTxclDzv(int A_1, byte A_2, bool A_3)
	{
		if (1 + A_1 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (A_3)
		{
			byte* ptr = this.vraMknjBoFWmecwYDuHfUYymkttW + A_1;
			*ptr |= (byte)(1 << (int)A_2);
			return;
		}
		byte* ptr2 = this.vraMknjBoFWmecwYDuHfUYymkttW + A_1;
		*ptr2 &= (byte)(~(byte)(1 << (int)A_2));
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x000152BD File Offset: 0x000134BD
	public unsafe void YcRZrLkBtMuOJwdLRmnEclUiObPN(byte A_1, int A_2)
	{
		if (1 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		this.vraMknjBoFWmecwYDuHfUYymkttW[A_2] = A_1;
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x000152E3 File Offset: 0x000134E3
	public unsafe void LjnNJKfhsNsDZyBaSMCTeTWKIWTu(short A_1, int A_2)
	{
		if (2 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = A_1;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x000152E3 File Offset: 0x000134E3
	public unsafe void jNbUkCjIehZDDqFXbarytdXnMdfN(ushort A_1, int A_2)
	{
		if (2 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = (short)A_1;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x00015309 File Offset: 0x00013509
	public unsafe void KUJgimLaaKHkxswoSyjIBrIXzNd(int A_1, int A_2)
	{
		if (4 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = A_1;
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x00015309 File Offset: 0x00013509
	public unsafe void yIdDQwWgqkFlOebxPtvddOmQskP(uint A_1, int A_2)
	{
		if (4 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = (int)A_1;
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x0001532F File Offset: 0x0001352F
	public unsafe void zXIZVQOSKQdZvUvnnADkRJzGeGZq(long A_1, int A_2)
	{
		if (8 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = A_1;
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x0001532F File Offset: 0x0001352F
	public unsafe void kLlVTzYAcehBngBkNPDVqdDiAQYiA(ulong A_1, int A_2)
	{
		if (8 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = (long)A_1;
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x00015355 File Offset: 0x00013555
	public unsafe void YWNGuIDaBlkugyAhqCSCzTKDAAuY(float A_1, int A_2)
	{
		if (4 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = A_1;
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x0001537B File Offset: 0x0001357B
	public unsafe void OqJlwMNKwvkhlEqxVxjWfObKezCi(double A_1, int A_2)
	{
		if (8 + A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(this.vraMknjBoFWmecwYDuHfUYymkttW + A_2) = A_1;
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x0003792C File Offset: 0x00035B2C
	public unsafe void ZkxCjNkRgJNBdfwRYSPQcXapOzjxA(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_2 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_2 + A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(A_1, (IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW), A_4, A_3, A_2, true);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00037A10 File Offset: 0x00035C10
	public unsafe void FNypiTtVHBLSYQMgWazoTeDOGNMg(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
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
		if (A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_4 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 + A_4 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(A_1, this.vraMknjBoFWmecwYDuHfUYymkttW, A_5, A_4, A_3);
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x000153A1 File Offset: 0x000135A1
	public unsafe void wiSXWHfbIKPVvIKUZSnFFGeIHhBA(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		this.FNypiTtVHBLSYQMgWazoTeDOGNMg((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x00037AF0 File Offset: 0x00035CF0
	public unsafe int sfVMSAgfPyhIzieIWugQMRJBAKdT(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null)
		{
			return 0;
		}
		int num = A_1.Length;
		if (num == 0 || A_2 <= 0 || A_4 >= num || A_3 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_2 + A_3 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			A_2 = this.sPSagrbsrlUiGJndKcOzMfYzwQXDA - A_3;
		}
		NativeTools.CopyMemory(A_1, (IntPtr)((void*)this.vraMknjBoFWmecwYDuHfUYymkttW), A_4, A_3, A_2, true);
		return A_2;
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x00037B68 File Offset: 0x00035D68
	public unsafe int YeJHPsFeZhMbXdDIaHWhLzkgszVpB(byte* A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == null || A_2 <= 0 || A_3 <= 0 || A_5 >= A_2 || A_4 >= this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
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
		if (A_3 + A_4 > this.sPSagrbsrlUiGJndKcOzMfYzwQXDA)
		{
			A_3 = this.sPSagrbsrlUiGJndKcOzMfYzwQXDA - A_4;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(A_1, this.vraMknjBoFWmecwYDuHfUYymkttW, A_5, A_4, A_3);
		return A_3;
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x000153B5 File Offset: 0x000135B5
	public unsafe int ILqeDelcJbOjLKHzWCRsxUoLtXdc(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		return this.YeJHPsFeZhMbXdDIaHWhLzkgszVpB((byte*)((void*)A_1), A_2, A_3, A_4, A_5);
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00037BDC File Offset: 0x00035DDC
	public unsafe bool LSoycKIzDrtcVgeGNupPwfhFqePX(int A_1)
	{
		if (A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (this.sPSagrbsrlUiGJndKcOzMfYzwQXDA == A_1)
		{
			return true;
		}
		this.yderZnbFEzMISEnmaheWevYtAbIDA();
		if (A_1 == 0)
		{
			return true;
		}
		this.sPSagrbsrlUiGJndKcOzMfYzwQXDA = A_1;
		this.vraMknjBoFWmecwYDuHfUYymkttW = (byte*)((void*)Marshal.AllocHGlobal(A_1));
		this.EHXQuxoJUAajDGxUOAhDEcQtMJVJA();
		return true;
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x000153C9 File Offset: 0x000135C9
	public void EHXQuxoJUAajDGxUOAhDEcQtMJVJA()
	{
		if (this.sPSagrbsrlUiGJndKcOzMfYzwQXDA == 0)
		{
			return;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.SCyGjgOnlZPdVplOabQlJqZFNOkvA(this.vraMknjBoFWmecwYDuHfUYymkttW, this.sPSagrbsrlUiGJndKcOzMfYzwQXDA);
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00037C30 File Offset: 0x00035E30
	public void yderZnbFEzMISEnmaheWevYtAbIDA()
	{
		if (this.sPSagrbsrlUiGJndKcOzMfYzwQXDA == 0)
		{
			return;
		}
		try
		{
			if (this.vraMknjBoFWmecwYDuHfUYymkttW != null)
			{
				Marshal.FreeHGlobal(this.pTqePlWfDkrAVqwmLmietZbIwjOh);
			}
		}
		catch
		{
		}
		this.vraMknjBoFWmecwYDuHfUYymkttW = null;
		this.sPSagrbsrlUiGJndKcOzMfYzwQXDA = 0;
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x00037C80 File Offset: 0x00035E80
	public virtual string vpoEuVfeFPejqWBOHWzVvlWiRGro()
	{
		string text = "";
		for (int i = 0; i < this.sPSagrbsrlUiGJndKcOzMfYzwQXDA; i++)
		{
			text = text + this.CYJMMdiYJjVPDvyTPacyRaCTEtKI(i).ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x000153E5 File Offset: 0x000135E5
	public void Dispose()
	{
		this.VpeWjTfxRmFnvcxsiOgBfsWVNAAl(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00037CC8 File Offset: 0x00035EC8
	protected virtual void uHrHOysgnOAvgwUutDeVgbSOjMFv()
	{
		try
		{
			this.VpeWjTfxRmFnvcxsiOgBfsWVNAAl(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x000153F4 File Offset: 0x000135F4
	protected virtual void VpeWjTfxRmFnvcxsiOgBfsWVNAAl(bool A_1)
	{
		if (this.EoxeldWirWpcIrhWPEcjAMmCKjvk)
		{
			return;
		}
		this.yderZnbFEzMISEnmaheWevYtAbIDA();
		this.EoxeldWirWpcIrhWPEcjAMmCKjvk = true;
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0001540E File Offset: 0x0001360E
	public unsafe static IntPtr BGZAgqFCOJwbYkvyudUcLwURrQAX(rldBWJiPNwVWNAQGlSaZBtbmtjRwA A_0)
	{
		if (A_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)((void*)A_0.vraMknjBoFWmecwYDuHfUYymkttW);
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00015424 File Offset: 0x00013624
	public unsafe static void* BGZAgqFCOJwbYkvyudUcLwURrQAX(rldBWJiPNwVWNAQGlSaZBtbmtjRwA A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		return (void*)A_0.vraMknjBoFWmecwYDuHfUYymkttW;
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x00037CF8 File Offset: 0x00035EF8
	public static bool PxRaNBAiLaaYIGKLBBcGKVPTsCjpB(rldBWJiPNwVWNAQGlSaZBtbmtjRwA A_0, rldBWJiPNwVWNAQGlSaZBtbmtjRwA A_1)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (A_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (A_0.sPSagrbsrlUiGJndKcOzMfYzwQXDA == 0)
		{
			A_1.yderZnbFEzMISEnmaheWevYtAbIDA();
			return true;
		}
		if (A_1.LSoycKIzDrtcVgeGNupPwfhFqePX(A_0.sPSagrbsrlUiGJndKcOzMfYzwQXDA))
		{
			A_1.FNypiTtVHBLSYQMgWazoTeDOGNMg(A_0.vraMknjBoFWmecwYDuHfUYymkttW, A_0.sPSagrbsrlUiGJndKcOzMfYzwQXDA, A_0.sPSagrbsrlUiGJndKcOzMfYzwQXDA, 0, 0);
			return true;
		}
		return false;
	}

	// Token: 0x0400082D RID: 2093
	private unsafe byte* vraMknjBoFWmecwYDuHfUYymkttW;

	// Token: 0x0400082E RID: 2094
	private int sPSagrbsrlUiGJndKcOzMfYzwQXDA;

	// Token: 0x0400082F RID: 2095
	private bool EoxeldWirWpcIrhWPEcjAMmCKjvk;
}
