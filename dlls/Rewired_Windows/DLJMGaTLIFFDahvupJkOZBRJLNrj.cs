using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x0200003C RID: 60
internal class DLJMGaTLIFFDahvupJkOZBRJLNrj : IDisposable
{
	// Token: 0x06000255 RID: 597
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	private static extern ushort wCDxzWjKdIonyIkwZKCCuwHRqPtc([In] ref DLJMGaTLIFFDahvupJkOZBRJLNrj.NbWUrTsEFfILIMqiwHzmfHEiROQH);

	// Token: 0x06000256 RID: 598
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	private static extern bool KmmzTVhVOeRooIzVOzKkBjGnDCXM([MarshalAs(UnmanagedType.LPWStr)] string, IntPtr);

	// Token: 0x06000257 RID: 599
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	private static extern IntPtr kmcmmfQALjOIbcHLtPZpQajPRCZi(uint, [MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.LPWStr)] string, uint, int, int, int, int, IntPtr, IntPtr, IntPtr, IntPtr);

	// Token: 0x06000258 RID: 600
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	private static extern IntPtr gHAGbuUknOqLpkLGizMnRGLyFYZgA(IntPtr, uint, IntPtr, IntPtr);

	// Token: 0x06000259 RID: 601
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	private static extern bool kLoAWJESptFdbQhHkrUsPiwALfVS(IntPtr);

	// Token: 0x0600025A RID: 602
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	private static extern bool bvhauSjeHLoHzltpCFnRuLiPfLlBA(IntPtr);

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x0600025B RID: 603 RVA: 0x0001284E File Offset: 0x00010A4E
	public IntPtr UradimpePZJbUJETzZGUOMPnDILu
	{
		get
		{
			return this.gPchKuzDJMTSERqqCvwWmdxOyYYj;
		}
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x0600025C RID: 604 RVA: 0x00012856 File Offset: 0x00010A56
	public uint aWHoUahghjibZCfyoqlzWgYATVXPA
	{
		get
		{
			return this.PujSiYaabRwlHmpPQffSmStvxAPl;
		}
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x0600025D RID: 605 RVA: 0x0001285E File Offset: 0x00010A5E
	public bool gGyEnVbANtoMhUOnJWbnTCUhPAUF
	{
		get
		{
			return this.gPchKuzDJMTSERqqCvwWmdxOyYYj != IntPtr.Zero && DLJMGaTLIFFDahvupJkOZBRJLNrj.bvhauSjeHLoHzltpCFnRuLiPfLlBA(this.gPchKuzDJMTSERqqCvwWmdxOyYYj);
		}
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0001287F File Offset: 0x00010A7F
	public void Dispose()
	{
		this.WPyqKosdZoOSWrpYclgipzAEYqFH(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x000292A4 File Offset: 0x000274A4
	protected virtual void bFaSxUiLKJpsjkRmqhUhPRGNdZmP()
	{
		try
		{
			this.WPyqKosdZoOSWrpYclgipzAEYqFH(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000260 RID: 608 RVA: 0x000292D4 File Offset: 0x000274D4
	private void WPyqKosdZoOSWrpYclgipzAEYqFH(bool A_1)
	{
		if (!this.BWuiTzNSbGfahEZnPOhKTCKwCQCi)
		{
			if (A_1)
			{
				ObjectInstanceTracker.Default.Unregister(this.PujSiYaabRwlHmpPQffSmStvxAPl);
			}
			if (this.gPchKuzDJMTSERqqCvwWmdxOyYYj != IntPtr.Zero)
			{
				DLJMGaTLIFFDahvupJkOZBRJLNrj.kLoAWJESptFdbQhHkrUsPiwALfVS(this.gPchKuzDJMTSERqqCvwWmdxOyYYj);
				this.gPchKuzDJMTSERqqCvwWmdxOyYYj = IntPtr.Zero;
			}
			if (this.oxZJsiTsZDqycLCJvCoAuAoxWWtB != 0 && !string.IsNullOrEmpty(this.hSPeYYnQvDzryPBfCNaYrJQFLJC))
			{
				DLJMGaTLIFFDahvupJkOZBRJLNrj.KmmzTVhVOeRooIzVOzKkBjGnDCXM(this.hSPeYYnQvDzryPBfCNaYrJQFLJC, IntPtr.Zero);
			}
			this.BWuiTzNSbGfahEZnPOhKTCKwCQCi = true;
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00029354 File Offset: 0x00027554
	public DLJMGaTLIFFDahvupJkOZBRJLNrj(string A_1, bool A_2, DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl A_3)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			throw new ArgumentNullException("className");
		}
		if (A_3 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		this.PujSiYaabRwlHmpPQffSmStvxAPl = ObjectInstanceTracker.Default.Register(this);
		this.hSPeYYnQvDzryPBfCNaYrJQFLJC = A_1;
		this.MhkoUdNNvVlrZUKHQjefUCpDuuAy = new DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl(DLJMGaTLIFFDahvupJkOZBRJLNrj.jVgPIktXeRvKnktMtKRRhJoJqkWT);
		this.JwcfvmZCQxeOPQLsUFsRKGtTJqeBb = A_3;
		this.ZwMgFtcAhhiJgnrQqNOZEwpeFPvfB = 0;
		DLJMGaTLIFFDahvupJkOZBRJLNrj.NbWUrTsEFfILIMqiwHzmfHEiROQH nbWUrTsEFfILIMqiwHzmfHEiROQH = default(DLJMGaTLIFFDahvupJkOZBRJLNrj.NbWUrTsEFfILIMqiwHzmfHEiROQH);
		nbWUrTsEFfILIMqiwHzmfHEiROQH.QiaXgROFqJqFmVGlBmxainsigDlc = Marshal.GetFunctionPointerForDelegate<DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl>(this.MhkoUdNNvVlrZUKHQjefUCpDuuAy);
		while (this.oxZJsiTsZDqycLCJvCoAuAoxWWtB == 0 && this.ZwMgFtcAhhiJgnrQqNOZEwpeFPvfB < 20)
		{
			nbWUrTsEFfILIMqiwHzmfHEiROQH.hSrwORzOJlygWfYvQVGneehUspce = A_1;
			this.oxZJsiTsZDqycLCJvCoAuAoxWWtB = DLJMGaTLIFFDahvupJkOZBRJLNrj.wCDxzWjKdIonyIkwZKCCuwHRqPtc(ref nbWUrTsEFfILIMqiwHzmfHEiROQH);
			if (this.oxZJsiTsZDqycLCJvCoAuAoxWWtB != 0)
			{
				break;
			}
			this.ZwMgFtcAhhiJgnrQqNOZEwpeFPvfB++;
			A_1 = this.hSPeYYnQvDzryPBfCNaYrJQFLJC + this.ZwMgFtcAhhiJgnrQqNOZEwpeFPvfB.ToString();
		}
		if (this.oxZJsiTsZDqycLCJvCoAuAoxWWtB == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (this.hSPeYYnQvDzryPBfCNaYrJQFLJC != A_1)
		{
			this.hSPeYYnQvDzryPBfCNaYrJQFLJC = A_1;
		}
		if (A_2)
		{
			this.gPchKuzDJMTSERqqCvwWmdxOyYYj = this.aSEsDIQAYazSVHtXtwAsVgGCorGD(A_1, new IntPtr((int)this.PujSiYaabRwlHmpPQffSmStvxAPl));
			return;
		}
		this.gPchKuzDJMTSERqqCvwWmdxOyYYj = this.fslAoSfdmSvbYGuNmALQctwzCkYcA(A_1, new IntPtr((int)this.PujSiYaabRwlHmpPQffSmStvxAPl));
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00029490 File Offset: 0x00027690
	private IntPtr fslAoSfdmSvbYGuNmALQctwzCkYcA(string A_1, IntPtr A_2)
	{
		return DLJMGaTLIFFDahvupJkOZBRJLNrj.kmcmmfQALjOIbcHLtPZpQajPRCZi(0U, A_1, string.Empty, 0U, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, A_2);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x000294C0 File Offset: 0x000276C0
	private IntPtr aSEsDIQAYazSVHtXtwAsVgGCorGD(string A_1, IntPtr A_2)
	{
		return DLJMGaTLIFFDahvupJkOZBRJLNrj.kmcmmfQALjOIbcHLtPZpQajPRCZi(0U, A_1, string.Empty, 0U, 0, 0, 0, 0, KastMvGkvyaNUEWReDndMRsEYrtnA.YVhjgNJisNhXWxCIkxFgeTwxMpHH, IntPtr.Zero, IntPtr.Zero, A_2);
	}

	// Token: 0x06000264 RID: 612 RVA: 0x000294F0 File Offset: 0x000276F0
	[MonoPInvokeCallback(typeof(DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl))]
	private unsafe static IntPtr jVgPIktXeRvKnktMtKRRhJoJqkWT(IntPtr A_0, uint A_1, IntPtr A_2, IntPtr A_3)
	{
		if (A_0 == IntPtr.Zero)
		{
			return DLJMGaTLIFFDahvupJkOZBRJLNrj.gHAGbuUknOqLpkLGizMnRGLyFYZgA(A_0, A_1, A_2, A_3);
		}
		bool flag = false;
		uint instanceId = 0U;
		if (A_1 == 1U)
		{
			DLJMGaTLIFFDahvupJkOZBRJLNrj.yDGNGVrcZuEbsdWsxrsLbrCZzNGe* ptr = (DLJMGaTLIFFDahvupJkOZBRJLNrj.yDGNGVrcZuEbsdWsxrsLbrCZzNGe*)((void*)A_3);
			if (ptr->KIQXuCGSsohPOlhEHzQmetEtcBvu != IntPtr.Zero)
			{
				wLURyKQfpGlmweDJGGSrwwzrDUJFA.KDeHKerecLKIxHfgkBKciMXnBzub(A_0, -21, ptr->KIQXuCGSsohPOlhEHzQmetEtcBvu);
			}
		}
		else
		{
			instanceId = (uint)wLURyKQfpGlmweDJGGSrwwzrDUJFA.JuOVCBsCjDiYAfraKqxXIUXUpmwgb(A_0, -21).ToInt32();
			flag = true;
		}
		DLJMGaTLIFFDahvupJkOZBRJLNrj dljmgaTLIFFDahvupJkOZBRJLNrj;
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<DLJMGaTLIFFDahvupJkOZBRJLNrj>(instanceId, out dljmgaTLIFFDahvupJkOZBRJLNrj))
		{
			dljmgaTLIFFDahvupJkOZBRJLNrj.JwcfvmZCQxeOPQLsUFsRKGtTJqeBb(A_0, A_1, A_2, A_3);
		}
		return DLJMGaTLIFFDahvupJkOZBRJLNrj.gHAGbuUknOqLpkLGizMnRGLyFYZgA(A_0, A_1, A_2, A_3);
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0001288E File Offset: 0x00010A8E
	public void aaQTnxHnlVxGVvJxAGhuXEsgzyeU(DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl A_1)
	{
		this.JwcfvmZCQxeOPQLsUFsRKGtTJqeBb = A_1;
	}

	// Token: 0x040001E6 RID: 486
	private const int FrZsASwFQqBuMzgythKXZglZXNqK = 20;

	// Token: 0x040001E7 RID: 487
	private const int VbtnqyjxPZcPQkLbzwqLxoYIXUih = 1410;

	// Token: 0x040001E8 RID: 488
	private readonly ushort oxZJsiTsZDqycLCJvCoAuAoxWWtB;

	// Token: 0x040001E9 RID: 489
	private readonly string hSPeYYnQvDzryPBfCNaYrJQFLJC;

	// Token: 0x040001EA RID: 490
	private bool BWuiTzNSbGfahEZnPOhKTCKwCQCi;

	// Token: 0x040001EB RID: 491
	private IntPtr gPchKuzDJMTSERqqCvwWmdxOyYYj;

	// Token: 0x040001EC RID: 492
	private int ZwMgFtcAhhiJgnrQqNOZEwpeFPvfB;

	// Token: 0x040001ED RID: 493
	private uint PujSiYaabRwlHmpPQffSmStvxAPl;

	// Token: 0x040001EE RID: 494
	private DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl MhkoUdNNvVlrZUKHQjefUCpDuuAy;

	// Token: 0x040001EF RID: 495
	private DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl JwcfvmZCQxeOPQLsUFsRKGtTJqeBb;

	// Token: 0x0200003D RID: 61
	// (Invoke) Token: 0x06000267 RID: 615
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr osqZvvGFouEfTOmJrimLXBVCYjbl(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	// Token: 0x0200003E RID: 62
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct NbWUrTsEFfILIMqiwHzmfHEiROQH
	{
		// Token: 0x040001F0 RID: 496
		public uint uESldbrkKZbDoACFZBpcQQsISSqlA;

		// Token: 0x040001F1 RID: 497
		public IntPtr QiaXgROFqJqFmVGlBmxainsigDlc;

		// Token: 0x040001F2 RID: 498
		public int IAFGPlLPRzTDcEjzvsLvAJibeTCI;

		// Token: 0x040001F3 RID: 499
		public int QeBfPpnbSZqMWPaQEKMnvNvYCoz;

		// Token: 0x040001F4 RID: 500
		public IntPtr xJDkjgPskwQOCDWUPaqvqSJScJjN;

		// Token: 0x040001F5 RID: 501
		public IntPtr yZGYCJyOgtxOxEmusqcaKDvKjuqk;

		// Token: 0x040001F6 RID: 502
		public IntPtr YiUPfzurpAiBEjwRjThZUagVHDIL;

		// Token: 0x040001F7 RID: 503
		public IntPtr ehsgamaHcEaICamdeAVSaFidyjQlc;

		// Token: 0x040001F8 RID: 504
		[MarshalAs(UnmanagedType.LPWStr)]
		public string mwNskgTlNqkZoKHpUNDdDAZijTqq;

		// Token: 0x040001F9 RID: 505
		[MarshalAs(UnmanagedType.LPWStr)]
		public string hSrwORzOJlygWfYvQVGneehUspce;
	}

	// Token: 0x0200003F RID: 63
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct yDGNGVrcZuEbsdWsxrsLbrCZzNGe
	{
		// Token: 0x040001FA RID: 506
		public IntPtr KIQXuCGSsohPOlhEHzQmetEtcBvu;

		// Token: 0x040001FB RID: 507
		public IntPtr ZzAIgsWFNVaVWecDWYWhIZvlntiPA;

		// Token: 0x040001FC RID: 508
		public IntPtr eDiOgOhhwSohEmfYAEVCGXvALGaGA;

		// Token: 0x040001FD RID: 509
		public IntPtr GxYUJWWJjdHsrrxdoJBargJXxtpF;

		// Token: 0x040001FE RID: 510
		public int NcusvmVQyuEdkafZtEnxgJcGwHLL;

		// Token: 0x040001FF RID: 511
		public int asQwqUIkQRzEjxNBrHGZjIHyKMomA;

		// Token: 0x04000200 RID: 512
		public int LfGlGiRNIJBtWJRJoPajghblRRTV;

		// Token: 0x04000201 RID: 513
		public int whIIEApPPdOEjnsBgzWbzUkSLqhk;

		// Token: 0x04000202 RID: 514
		public int eQewYyjlAJbajQiMoInlbrtuaGBEA;

		// Token: 0x04000203 RID: 515
		public IntPtr zjEwVoKLaxvMSkhWQqkxFLGYIOMj;

		// Token: 0x04000204 RID: 516
		public IntPtr afhPtKQlCkaPyyZeFefFIrSAmQEq;

		// Token: 0x04000205 RID: 517
		public uint prSrKsXvMWRxzAedorCmztzOPObN;
	}
}
