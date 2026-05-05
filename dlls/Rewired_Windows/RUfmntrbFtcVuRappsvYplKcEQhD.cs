using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

// Token: 0x020000E2 RID: 226
internal class RUfmntrbFtcVuRappsvYplKcEQhD : IDisposable
{
	// Token: 0x17000189 RID: 393
	// (get) Token: 0x060007DE RID: 2014 RVA: 0x000158D8 File Offset: 0x00013AD8
	public bool LLtRezxIQdeVaejWnuDhWkhKYepr
	{
		get
		{
			return this.UERZzDYjVYcxBgeQZqWWkgMkipvq();
		}
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000388E4 File Offset: 0x00036AE4
	public RUfmntrbFtcVuRappsvYplKcEQhD(int A_1, int A_2, Action<object> A_3 = null)
	{
		if (A_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		this.GVgCZxHLXCWGNUZsywdFHxmIwKQ = new bxLmBpBgWqThrxuxOJdyAmAMzBBF(A_1);
		this.ytdgEAcKHOLcYsmQrVICvtBLauyQ = new ObjectPool<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>(A_2, new Func<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>(RUfmntrbFtcVuRappsvYplKcEQhD.uFzBveTSAEhYZVrAaHKLNBIwdDpq.<>9.SUftNkBjfZXsSJMZUBPkRsbEHRrC), new Action<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>(RUfmntrbFtcVuRappsvYplKcEQhD.uFzBveTSAEhYZVrAaHKLNBIwdDpq.<>9.MuBSKQzDyWbrjvYBUziDeEgDNvrc));
		this.FmIemmgHDFLrKkVljaVvfUwfjWoh = new Queue<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>(A_2);
		this.lHVFHSNjIBMaMqepEEsvcGNKLOvX = A_3;
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x00038970 File Offset: 0x00036B70
	public unsafe bool EPuVJxSFEaQArAFWdkRNpYTTgLsl(byte* A_1, int A_2, object A_3)
	{
		if (A_1 == null || A_2 <= 0)
		{
			return false;
		}
		int num;
		uint num2;
		if (this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.IewrDIMBSYPXlGVpqhrKDLdxGOB(A_1, A_2, A_2, out num, out num2) < A_2)
		{
			return false;
		}
		RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc dbjiBpEqzfpDZaFUgnCodOwOQHUbc = this.ytdgEAcKHOLcYsmQrVICvtBLauyQ.Get();
		dbjiBpEqzfpDZaFUgnCodOwOQHUbc.IZtuCLxfcDHhsiytzWzsUtfuvlsA(num, A_2, num2, A_3);
		this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Enqueue(dbjiBpEqzfpDZaFUgnCodOwOQHUbc);
		return true;
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000158E0 File Offset: 0x00013AE0
	public unsafe bool pwCllDwYwOFgiIRGtmXChFnMlfoO(byte* A_1, int A_2)
	{
		return this.EPuVJxSFEaQArAFWdkRNpYTTgLsl(A_1, A_2, null);
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x000158EB File Offset: 0x00013AEB
	public unsafe bool TmmBwbKqrtkqsFDfCLupULMDaBpg(IntPtr A_1, int A_2, object A_3)
	{
		return !(A_1 == IntPtr.Zero) && A_2 > 0 && this.EPuVJxSFEaQArAFWdkRNpYTTgLsl((byte*)((void*)A_1), A_2, A_3);
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x0001590E File Offset: 0x00013B0E
	public bool ARTUQHUfMNmDEFssZoscokeoYSDE(IntPtr A_1, int A_2)
	{
		return this.TmmBwbKqrtkqsFDfCLupULMDaBpg(A_1, A_2, null);
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x000389C4 File Offset: 0x00036BC4
	public unsafe bool AiPAswSNXteCrGJCclQTAcjzOKGT(byte[] A_1, int A_2, object A_3, int A_4 = 0)
	{
		if (A_1 == null || A_2 > A_1.Length)
		{
			return false;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_4 + A_2 > A_1.Length)
		{
			return false;
		}
		byte* ptr;
		if (A_1 == null || A_1.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &A_1[0];
		}
		byte* ptr2 = ptr + A_4;
		return this.EPuVJxSFEaQArAFWdkRNpYTTgLsl(ptr2, A_2, A_3);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00015919 File Offset: 0x00013B19
	public bool LHKyFNDOPkpArjwCYACXGErlDOLr(byte[] A_1, int A_2, int A_3 = 0)
	{
		return this.AiPAswSNXteCrGJCclQTAcjzOKGT(A_1, A_2, null, A_3);
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00038A18 File Offset: 0x00036C18
	public unsafe int mEWMiKyaxxRGRocjpYLhYoKWExgW(byte* A_1, int A_2, out object A_3)
	{
		if (A_1 == null || A_2 <= 0)
		{
			A_3 = null;
			return -1;
		}
		RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc dbjiBpEqzfpDZaFUgnCodOwOQHUbc = this.IeNBxEiQVPrXMduMNffjOrywikfDb(false);
		if (dbjiBpEqzfpDZaFUgnCodOwOQHUbc == null)
		{
			A_3 = null;
			return -1;
		}
		if (A_2 < dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", true);
			A_3 = null;
			return -1;
		}
		int num = this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.vsUfjzYOOEgniBqCEsqYxGlqeJErA(A_1, A_2, dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT, dbjiBpEqzfpDZaFUgnCodOwOQHUbc.ijvnDcXJNcJJExNRhkfOFuBCNQfl);
		if (num != dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			A_3 = null;
			return -1;
		}
		A_3 = dbjiBpEqzfpDZaFUgnCodOwOQHUbc.JBdGbdGcPnOPjRozsGoxPgZUfWVSA;
		return num;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x00038A9C File Offset: 0x00036C9C
	public unsafe int qfNsCbIWvFUJiJZofclKbZbSLcYA(byte* A_1, int A_2)
	{
		object obj;
		return this.mEWMiKyaxxRGRocjpYLhYoKWExgW(A_1, A_2, out obj);
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x00015925 File Offset: 0x00013B25
	public unsafe int kUNfckaODASaggipNAQIBmVnCihjA(IntPtr A_1, int A_2, out object A_3)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0)
		{
			A_3 = null;
			return -1;
		}
		return this.mEWMiKyaxxRGRocjpYLhYoKWExgW((byte*)((void*)A_1), A_2, out A_3);
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x00038AB4 File Offset: 0x00036CB4
	public int WFWYhCsmtcaOeVsdNanSBCeJhvQo(IntPtr A_1, int A_2)
	{
		object obj;
		return this.kUNfckaODASaggipNAQIBmVnCihjA(A_1, A_2, out obj);
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x00038ACC File Offset: 0x00036CCC
	public unsafe int awRAKLgAEadRsOGfBPOXZWraaQOvA(byte[] A_1, out object A_2)
	{
		if (A_1 == null || A_1.Length == 0)
		{
			A_2 = null;
			return -1;
		}
		byte* ptr;
		if (A_1 == null || A_1.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &A_1[0];
		}
		return this.mEWMiKyaxxRGRocjpYLhYoKWExgW(ptr, A_1.Length, out A_2);
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x00038B08 File Offset: 0x00036D08
	public int GiAWEkKXENFMLBXNCTKzFIJyYLCR(byte[] A_1)
	{
		object obj;
		return this.awRAKLgAEadRsOGfBPOXZWraaQOvA(A_1, out obj);
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x00038B20 File Offset: 0x00036D20
	public int inVgCmSWQZHOFhLigpQvRIwyoKRy()
	{
		RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc dbjiBpEqzfpDZaFUgnCodOwOQHUbc = this.IeNBxEiQVPrXMduMNffjOrywikfDb(false);
		if (dbjiBpEqzfpDZaFUgnCodOwOQHUbc == null)
		{
			return -1;
		}
		return dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT;
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x00038B40 File Offset: 0x00036D40
	public unsafe int iJcfILteJrIHcOEXVmctzNaMKXYo(byte* A_1, int A_2, out object A_3)
	{
		if (A_1 == null || A_2 <= 0)
		{
			A_3 = null;
			return -1;
		}
		RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc dbjiBpEqzfpDZaFUgnCodOwOQHUbc = this.IeNBxEiQVPrXMduMNffjOrywikfDb(true);
		if (dbjiBpEqzfpDZaFUgnCodOwOQHUbc == null)
		{
			A_3 = null;
			return -1;
		}
		if (A_2 < dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", true);
			A_3 = null;
			this.QUKbfevpNvBHZSDIgZHWsguGBCIW(dbjiBpEqzfpDZaFUgnCodOwOQHUbc, true);
			return -1;
		}
		int num = this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.vsUfjzYOOEgniBqCEsqYxGlqeJErA(A_1, A_2, dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT, dbjiBpEqzfpDZaFUgnCodOwOQHUbc.ijvnDcXJNcJJExNRhkfOFuBCNQfl);
		if (num != dbjiBpEqzfpDZaFUgnCodOwOQHUbc.mGFrsgPPYoDaoXmVcNHsnvqNJTXT)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			A_3 = null;
			this.QUKbfevpNvBHZSDIgZHWsguGBCIW(dbjiBpEqzfpDZaFUgnCodOwOQHUbc, true);
			return -1;
		}
		A_3 = dbjiBpEqzfpDZaFUgnCodOwOQHUbc.JBdGbdGcPnOPjRozsGoxPgZUfWVSA;
		this.QUKbfevpNvBHZSDIgZHWsguGBCIW(dbjiBpEqzfpDZaFUgnCodOwOQHUbc, false);
		return num;
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x00038BD8 File Offset: 0x00036DD8
	public unsafe int QHjCvakcHWpfunBsVUjghgHFABds(byte* A_1, int A_2)
	{
		object obj;
		return this.iJcfILteJrIHcOEXVmctzNaMKXYo(A_1, A_2, out obj);
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x0001594B File Offset: 0x00013B4B
	public unsafe int QoDPLxAiJBOCWGiRGGwfYgzVpwlJ(IntPtr A_1, int A_2, out object A_3)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0)
		{
			A_3 = null;
			return -1;
		}
		return this.iJcfILteJrIHcOEXVmctzNaMKXYo((byte*)((void*)A_1), A_2, out A_3);
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x00038BF0 File Offset: 0x00036DF0
	public int zGIgAexNvYWQypDZtUOewgwsDbZi(IntPtr A_1, int A_2)
	{
		object obj;
		return this.QoDPLxAiJBOCWGiRGGwfYgzVpwlJ(A_1, A_2, out obj);
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00038C08 File Offset: 0x00036E08
	public unsafe int OQathESBOinDtXmIHzjWbgOovGlI(byte[] A_1, out object A_2)
	{
		if (A_1 == null || A_1.Length == 0)
		{
			A_2 = null;
			return -1;
		}
		byte* ptr;
		if (A_1 == null || A_1.Length == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = &A_1[0];
		}
		return this.iJcfILteJrIHcOEXVmctzNaMKXYo(ptr, A_1.Length, out A_2);
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00038C44 File Offset: 0x00036E44
	public int KHYfgtCsxwdFvieTTslJqnCPukuAA(byte[] A_1)
	{
		object obj;
		return this.OQathESBOinDtXmIHzjWbgOovGlI(A_1, out obj);
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00015971 File Offset: 0x00013B71
	public void sYlbJMkydTOXJfMAhJNqYLtbdBVgA()
	{
		this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.nJiwrhjTjwvPmsMbPGMCkeQwcyoJA();
		while (this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Count > 0)
		{
			this.QUKbfevpNvBHZSDIgZHWsguGBCIW(this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Dequeue(), true);
		}
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00038C5C File Offset: 0x00036E5C
	private RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc IeNBxEiQVPrXMduMNffjOrywikfDb(bool A_1)
	{
		while (this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Count > 0)
		{
			RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc dbjiBpEqzfpDZaFUgnCodOwOQHUbc = A_1 ? this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Dequeue() : this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Peek();
			if (this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.UnLumDhRgxGtsHINNuPyqwUXoSdSA(dbjiBpEqzfpDZaFUgnCodOwOQHUbc.ijvnDcXJNcJJExNRhkfOFuBCNQfl, dbjiBpEqzfpDZaFUgnCodOwOQHUbc.REVgSpkkQCFDbTYeZzjVgoTCQAHf))
			{
				return dbjiBpEqzfpDZaFUgnCodOwOQHUbc;
			}
			if (!A_1)
			{
				dbjiBpEqzfpDZaFUgnCodOwOQHUbc = this.FmIemmgHDFLrKkVljaVvfUwfjWoh.Dequeue();
			}
			this.QUKbfevpNvBHZSDIgZHWsguGBCIW(dbjiBpEqzfpDZaFUgnCodOwOQHUbc, true);
		}
		return null;
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x000159A0 File Offset: 0x00013BA0
	private bool UERZzDYjVYcxBgeQZqWWkgMkipvq()
	{
		return this.IeNBxEiQVPrXMduMNffjOrywikfDb(false) != null;
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x000159AC File Offset: 0x00013BAC
	private void QUKbfevpNvBHZSDIgZHWsguGBCIW(RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_2 && this.lHVFHSNjIBMaMqepEEsvcGNKLOvX != null && A_1.JBdGbdGcPnOPjRozsGoxPgZUfWVSA != null)
		{
			this.lHVFHSNjIBMaMqepEEsvcGNKLOvX(A_1.JBdGbdGcPnOPjRozsGoxPgZUfWVSA);
		}
		this.ytdgEAcKHOLcYsmQrVICvtBLauyQ.Return(A_1);
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000159E3 File Offset: 0x00013BE3
	public void Dispose()
	{
		this.pzMkFmUiclRhIjUhzYlHvBrjiOBy(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x00038CC8 File Offset: 0x00036EC8
	protected virtual void YDZnlAdTNlkmNLcqOQgcQquiAPHS()
	{
		try
		{
			this.pzMkFmUiclRhIjUhzYlHvBrjiOBy(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x000159F2 File Offset: 0x00013BF2
	protected void pzMkFmUiclRhIjUhzYlHvBrjiOBy(bool A_1)
	{
		if (this.SpyNamQxKcRKuylIRfIpGZyUVEgLA)
		{
			return;
		}
		if (A_1)
		{
			this.sYlbJMkydTOXJfMAhJNqYLtbdBVgA();
			if (this.GVgCZxHLXCWGNUZsywdFHxmIwKQ != null)
			{
				this.GVgCZxHLXCWGNUZsywdFHxmIwKQ.Dispose();
			}
		}
		this.SpyNamQxKcRKuylIRfIpGZyUVEgLA = true;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00015A20 File Offset: 0x00013C20
	public static bool uDbgIQgJUMtgjPUwqWWXDdKVdRDP(RUfmntrbFtcVuRappsvYplKcEQhD A_0, RUfmntrbFtcVuRappsvYplKcEQhD A_1)
	{
		if (A_0 == null || A_1 == null)
		{
			return false;
		}
		MiscTools.Swap<bxLmBpBgWqThrxuxOJdyAmAMzBBF>(ref A_0.GVgCZxHLXCWGNUZsywdFHxmIwKQ, ref A_1.GVgCZxHLXCWGNUZsywdFHxmIwKQ);
		MiscTools.Swap<ObjectPool<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>>(ref A_0.ytdgEAcKHOLcYsmQrVICvtBLauyQ, ref A_1.ytdgEAcKHOLcYsmQrVICvtBLauyQ);
		MiscTools.Swap<Queue<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc>>(ref A_0.FmIemmgHDFLrKkVljaVvfUwfjWoh, ref A_1.FmIemmgHDFLrKkVljaVvfUwfjWoh);
		return true;
	}

	// Token: 0x0400083B RID: 2107
	private bxLmBpBgWqThrxuxOJdyAmAMzBBF GVgCZxHLXCWGNUZsywdFHxmIwKQ;

	// Token: 0x0400083C RID: 2108
	private ObjectPool<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc> ytdgEAcKHOLcYsmQrVICvtBLauyQ;

	// Token: 0x0400083D RID: 2109
	private Queue<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc> FmIemmgHDFLrKkVljaVvfUwfjWoh;

	// Token: 0x0400083E RID: 2110
	private Action<object> lHVFHSNjIBMaMqepEEsvcGNKLOvX;

	// Token: 0x0400083F RID: 2111
	private bool SpyNamQxKcRKuylIRfIpGZyUVEgLA;

	// Token: 0x020000E3 RID: 227
	private class DBjiBpEqzfpDZaFUgnCodOwOQHUbc
	{
		// Token: 0x060007FC RID: 2044 RVA: 0x00015A5E File Offset: 0x00013C5E
		public void IZtuCLxfcDHhsiytzWzsUtfuvlsA(int A_1, int A_2, uint A_3, object A_4)
		{
			this.ijvnDcXJNcJJExNRhkfOFuBCNQfl = A_1;
			this.mGFrsgPPYoDaoXmVcNHsnvqNJTXT = A_2;
			this.REVgSpkkQCFDbTYeZzjVgoTCQAHf = A_3;
			this.JBdGbdGcPnOPjRozsGoxPgZUfWVSA = A_4;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00015A7D File Offset: 0x00013C7D
		public void ZiODgyBfoKvcxHCUgjCsDScwjjErA()
		{
			this.JBdGbdGcPnOPjRozsGoxPgZUfWVSA = null;
		}

		// Token: 0x04000840 RID: 2112
		public int ijvnDcXJNcJJExNRhkfOFuBCNQfl;

		// Token: 0x04000841 RID: 2113
		public int mGFrsgPPYoDaoXmVcNHsnvqNJTXT;

		// Token: 0x04000842 RID: 2114
		public uint REVgSpkkQCFDbTYeZzjVgoTCQAHf;

		// Token: 0x04000843 RID: 2115
		public object JBdGbdGcPnOPjRozsGoxPgZUfWVSA;
	}

	// Token: 0x020000E4 RID: 228
	[CompilerGenerated]
	[Serializable]
	private sealed class uFzBveTSAEhYZVrAaHKLNBIwdDpq
	{
		// Token: 0x06000800 RID: 2048 RVA: 0x00015A92 File Offset: 0x00013C92
		internal RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc SUftNkBjfZXsSJMZUBPkRsbEHRrC()
		{
			return new RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc();
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00015A99 File Offset: 0x00013C99
		internal void MuBSKQzDyWbrjvYBUziDeEgDNvrc(RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc A_1)
		{
			A_1.ZiODgyBfoKvcxHCUgjCsDScwjjErA();
		}

		// Token: 0x04000844 RID: 2116
		public static readonly RUfmntrbFtcVuRappsvYplKcEQhD.uFzBveTSAEhYZVrAaHKLNBIwdDpq <>9 = new RUfmntrbFtcVuRappsvYplKcEQhD.uFzBveTSAEhYZVrAaHKLNBIwdDpq();

		// Token: 0x04000845 RID: 2117
		public static Func<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc> <>9__6_0;

		// Token: 0x04000846 RID: 2118
		public static Action<RUfmntrbFtcVuRappsvYplKcEQhD.DBjiBpEqzfpDZaFUgnCodOwOQHUbc> <>9__6_1;
	}
}
