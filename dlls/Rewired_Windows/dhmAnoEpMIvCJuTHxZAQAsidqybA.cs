using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x020000DE RID: 222
[DefaultMember("Item")]
internal class dhmAnoEpMIvCJuTHxZAQAsidqybA : IDisposable
{
	// Token: 0x1700017C RID: 380
	// (get) Token: 0x06000741 RID: 1857 RVA: 0x00014EE1 File Offset: 0x000130E1
	public bool UAYXyOmYEYFJEsLqiSkOQdRlnPdj
	{
		get
		{
			return this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.IsAllocated;
		}
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x06000742 RID: 1858 RVA: 0x00014EEE File Offset: 0x000130EE
	// (set) Token: 0x06000743 RID: 1859 RVA: 0x00014EF8 File Offset: 0x000130F8
	public byte TKYNdIKSylREYBiDKpDCwZsirokF
	{
		get
		{
			return this.PmLDxqdRTosyJyqdqOksnWBGThUy[A_1];
		}
		set
		{
			this.PmLDxqdRTosyJyqdqOksnWBGThUy[A_1] = value;
		}
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x00014F03 File Offset: 0x00013103
	public dhmAnoEpMIvCJuTHxZAQAsidqybA(int A_1)
	{
		if (A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		this.PKFNrgSzoRKLYhpbQHHiZPJyChPC = A_1;
		this.PmLDxqdRTosyJyqdqOksnWBGThUy = new byte[A_1];
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00014F2D File Offset: 0x0001312D
	public IntPtr ZnxCjBgPriMxSvykRMbJSMaFgpuG()
	{
		if (this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.IsAllocated)
		{
			return this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.AddrOfPinnedObject();
		}
		this.LUzucUnZjjfDeIaAEdBHmuoyFNVp = GCHandle.Alloc(this.PmLDxqdRTosyJyqdqOksnWBGThUy, GCHandleType.Pinned);
		return this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.AddrOfPinnedObject();
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00014F65 File Offset: 0x00013165
	public void zxQhbZCJHuVheziGsyJFZxTANVrU()
	{
		if (!this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.IsAllocated)
		{
			return;
		}
		this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.Free();
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00036CEC File Offset: 0x00034EEC
	public string GMrkcwsmPNEACZtnmjkLQRcBBtie()
	{
		string text = "";
		for (int i = 0; i < this.PKFNrgSzoRKLYhpbQHHiZPJyChPC; i++)
		{
			text = text + this.PmLDxqdRTosyJyqdqOksnWBGThUy[i].ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00014F80 File Offset: 0x00013180
	public bool WcyBPEdUckjWIartPkYPdoIsNFET(int A_1, byte A_2)
	{
		if (1 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return ((int)this.PmLDxqdRTosyJyqdqOksnWBGThUy[A_1] & 1 << (int)A_2) != 0;
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x00014FBD File Offset: 0x000131BD
	public byte VsUvrmnjCAOFAJcpUtJwMulEwDPk(int A_1)
	{
		if (1 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return this.PmLDxqdRTosyJyqdqOksnWBGThUy[A_1];
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x00036D34 File Offset: 0x00034F34
	public unsafe short HiEZtvFEQQCmXFZTyAVSXlZSIANbA(int A_1)
	{
		if (2 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return *(short*)(ptr + A_1);
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00036D7C File Offset: 0x00034F7C
	public unsafe ushort wtddFTLvrlibrMihIIxbwioGOwOE(int A_1)
	{
		if (2 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return *(ushort*)(ptr + A_1);
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00036DC4 File Offset: 0x00034FC4
	public unsafe int LUMhlakAeHNBGionsmACFsIxQvGS(int A_1)
	{
		if (4 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return *(int*)(ptr + A_1);
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00036E0C File Offset: 0x0003500C
	public unsafe uint FyrNrfjCVeLyfQgSACfeSGObtCZQ(int A_1)
	{
		if (4 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return *(uint*)(ptr + A_1);
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x00036E54 File Offset: 0x00035054
	public unsafe long PegCdPedqvTCKcpMkyMbjPsusnal(int A_1)
	{
		if (8 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return *(long*)(ptr + A_1);
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00036E54 File Offset: 0x00035054
	public unsafe ulong YOPVVSgLxjOAjjRlAuImYPIQwsqw(int A_1)
	{
		if (8 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy;
		byte* ptr;
		if ((pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || pmLDxqdRTosyJyqdqOksnWBGThUy.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &pmLDxqdRTosyJyqdqOksnWBGThUy[0];
		}
		return (ulong)(*(long*)(ptr + A_1));
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x00036E9C File Offset: 0x0003509C
	public void LvSFasrBQqPTncHaPsHfQRTBcXwAA(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_2 + A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_3, A_1, A_4, A_2);
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x00036F78 File Offset: 0x00035178
	public void yYuEaCFriqnJjeZQCebQOWNYuQsJB(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero)
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
		if (A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_4 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 + A_4 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_1, A_4, A_5, A_3, true);
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x00037060 File Offset: 0x00035260
	public int kBxBEgwcSUZdfYoJEtKwgNCaDwMiA(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_3 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			A_2 = this.PKFNrgSzoRKLYhpbQHHiZPJyChPC - A_3;
		}
		if (A_4 + A_2 > num)
		{
			A_2 = num - A_4;
		}
		if (A_2 == 0)
		{
			return 0;
		}
		Array.Copy(this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_3, A_1, A_4, A_2);
		return A_2;
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x000370D8 File Offset: 0x000352D8
	public int TyohaqCqJnUzhzUVljwmSOVBxWgJ(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero || A_3 <= 0)
		{
			return 0;
		}
		if (A_4 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_4 + A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			A_3 = this.PKFNrgSzoRKLYhpbQHHiZPJyChPC - A_4;
		}
		if (A_5 + A_3 > A_2)
		{
			A_3 = A_2 - A_5;
		}
		NativeTools.CopyMemory(this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_1, A_4, A_5, A_3, true);
		return A_3;
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x00037154 File Offset: 0x00035354
	public void cExIIaAOOAFiwBhBiYieABdnOFlG(int A_1, byte A_2, bool A_3)
	{
		if (1 + A_1 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (A_2 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (A_3)
		{
			byte[] pmLDxqdRTosyJyqdqOksnWBGThUy = this.PmLDxqdRTosyJyqdqOksnWBGThUy;
			pmLDxqdRTosyJyqdqOksnWBGThUy[A_1] |= (byte)(1 << (int)A_2);
			return;
		}
		byte[] pmLDxqdRTosyJyqdqOksnWBGThUy2 = this.PmLDxqdRTosyJyqdqOksnWBGThUy;
		pmLDxqdRTosyJyqdqOksnWBGThUy2[A_1] &= (byte)(~(byte)(1 << (int)A_2));
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x00014FE1 File Offset: 0x000131E1
	public void WmWYSbhScnKCjdOeakFUWTpLEhWD(byte A_1, int A_2)
	{
		if (1 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		this.PmLDxqdRTosyJyqdqOksnWBGThUy[A_2] = A_1;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x000371C0 File Offset: 0x000353C0
	public unsafe void NoGrytxvpAgFCwNFrvyWVmjfXPbb(short A_1, int A_2)
	{
		if (2 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(short*)(ptr + A_2) = A_1;
		array = null;
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x000371C0 File Offset: 0x000353C0
	public unsafe void HqeLEqTVChqileERNhnUyCAEyOkn(ushort A_1, int A_2)
	{
		if (2 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(short*)(ptr + A_2) = (short)A_1;
		array = null;
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x0003720C File Offset: 0x0003540C
	public unsafe void xDqkOKvgxqKNcKFJORNhtAmRJYkp(int A_1, int A_2)
	{
		if (4 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(int*)(ptr + A_2) = A_1;
		array = null;
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x0003720C File Offset: 0x0003540C
	public unsafe void guLcdWPSuAYkabYxrokOJRWSBcRN(uint A_1, int A_2)
	{
		if (4 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(int*)(ptr + A_2) = (int)A_1;
		array = null;
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00037258 File Offset: 0x00035458
	public unsafe void MdVgQnXRLXQdaQIMzVoeKzRdcPNL(long A_1, int A_2)
	{
		if (8 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(long*)(ptr + A_2) = A_1;
		array = null;
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00037258 File Offset: 0x00035458
	public unsafe void zTtHAZZoykDOPYPXFuCyLawXsgDK(ulong A_1, int A_2)
	{
		if (8 + A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC || A_2 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		byte[] array;
		byte* ptr;
		if ((array = this.PmLDxqdRTosyJyqdqOksnWBGThUy) == null || array.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &array[0];
		}
		*(long*)(ptr + A_2) = (long)A_1;
		array = null;
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x000372A4 File Offset: 0x000354A4
	public void arrJswJKVKQggWIcDwJrAmpmWAem(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
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
		if (A_2 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_2 + A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(A_1, A_4, this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_3, A_2);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00037380 File Offset: 0x00035580
	public void mHGDrZSfDTvOoOyiMqUdqGmkDGzn(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero)
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
		if (A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_4 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 + A_4 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(A_1, this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_5, A_4, A_3, true);
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00037468 File Offset: 0x00035668
	public int AdgFvTCGGnMOSgbyglByUtlKNgwPB(byte[] A_1, int A_2, int A_3 = 0, int A_4 = 0)
	{
		if (A_1 == null)
		{
			return 0;
		}
		int num = A_1.Length;
		if (num == 0 || A_2 <= 0 || A_4 >= num || A_3 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_2 + A_3 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			A_2 = this.PKFNrgSzoRKLYhpbQHHiZPJyChPC - A_3;
		}
		Array.Copy(A_1, A_4, this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_3, A_2);
		return A_2;
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x000374D8 File Offset: 0x000356D8
	public int ssTzEVakLMBqenjYnVQmsHNZpAop(IntPtr A_1, int A_2, int A_3, int A_4 = 0, int A_5 = 0)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0 || A_3 <= 0 || A_5 >= A_2 || A_4 >= this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
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
		if (A_3 + A_4 > this.PKFNrgSzoRKLYhpbQHHiZPJyChPC)
		{
			A_3 = this.PKFNrgSzoRKLYhpbQHHiZPJyChPC - A_4;
		}
		NativeTools.CopyMemory(A_1, this.PmLDxqdRTosyJyqdqOksnWBGThUy, A_5, A_4, A_3, true);
		return A_3;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x00015006 File Offset: 0x00013206
	public void dJWvCFzFKgYiZJjBaWmaCcbRGovIA()
	{
		Array.Clear(this.PmLDxqdRTosyJyqdqOksnWBGThUy, 0, this.PKFNrgSzoRKLYhpbQHHiZPJyChPC);
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00037554 File Offset: 0x00035754
	public virtual string SkLYXYfalGEpUuriGcIWEBVYdNrTA()
	{
		string text = "";
		for (int i = 0; i < this.PKFNrgSzoRKLYhpbQHHiZPJyChPC; i++)
		{
			text = text + this.aGcDTZZLKZTGpwjCLVydwTJkjduq(i).ToString("x2") + " ";
		}
		return text;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x0001501A File Offset: 0x0001321A
	public void Dispose()
	{
		this.raPBiHoYANzlcMhgvrdHdqhTavsI(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x0003759C File Offset: 0x0003579C
	protected virtual void DKbblQtKglbowpGdxsvPfykjxYPk()
	{
		try
		{
			this.raPBiHoYANzlcMhgvrdHdqhTavsI(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x00015029 File Offset: 0x00013229
	protected virtual void raPBiHoYANzlcMhgvrdHdqhTavsI(bool A_1)
	{
		if (this.UinuqYvCjLKNpiOYItUVrKrUucFo)
		{
			return;
		}
		if (this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.IsAllocated)
		{
			this.LUzucUnZjjfDeIaAEdBHmuoyFNVp.Free();
		}
		this.UinuqYvCjLKNpiOYItUVrKrUucFo = true;
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00015055 File Offset: 0x00013255
	public static void TpinGpUNZgUDotHRzmVTVYlbqzMs(dhmAnoEpMIvCJuTHxZAQAsidqybA A_0, dhmAnoEpMIvCJuTHxZAQAsidqybA A_1, int A_2)
	{
		Array.Copy(A_0.PmLDxqdRTosyJyqdqOksnWBGThUy, A_1.PmLDxqdRTosyJyqdqOksnWBGThUy, A_2);
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00015069 File Offset: 0x00013269
	public static void vgCQFqHDvCxoutqAyeSCOoKaTCqF(dhmAnoEpMIvCJuTHxZAQAsidqybA A_0, int A_1, dhmAnoEpMIvCJuTHxZAQAsidqybA A_2, int A_3, int A_4)
	{
		Array.Copy(A_0.PmLDxqdRTosyJyqdqOksnWBGThUy, A_1, A_2.PmLDxqdRTosyJyqdqOksnWBGThUy, A_3, A_4);
	}

	// Token: 0x04000829 RID: 2089
	private readonly byte[] PmLDxqdRTosyJyqdqOksnWBGThUy;

	// Token: 0x0400082A RID: 2090
	public readonly int PKFNrgSzoRKLYhpbQHHiZPJyChPC;

	// Token: 0x0400082B RID: 2091
	private GCHandle LUzucUnZjjfDeIaAEdBHmuoyFNVp;

	// Token: 0x0400082C RID: 2092
	private bool UinuqYvCjLKNpiOYItUVrKrUucFo;
}
