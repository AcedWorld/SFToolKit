using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Utils;

// Token: 0x020000D8 RID: 216
internal class UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>
{
	// Token: 0x17000178 RID: 376
	// (get) Token: 0x0600071A RID: 1818 RVA: 0x00014D00 File Offset: 0x00012F00
	public bool dEuWrWEuMuRLEfvelqBlJqCXPzLm
	{
		get
		{
			return this.iHspEfUubXAEnOVjhxZqtpigEreQ == UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.AwaitingResult || this.iHspEfUubXAEnOVjhxZqtpigEreQ == UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.ResultReceived;
		}
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00014D16 File Offset: 0x00012F16
	public bool tyWUOmZxIPUWAGNTSMzHnebuMTZT()
	{
		bool flag = this.iHspEfUubXAEnOVjhxZqtpigEreQ == UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.ResultReceived;
		if (flag)
		{
			this.iHspEfUubXAEnOVjhxZqtpigEreQ = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.Idle;
		}
		return flag;
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x0600071C RID: 1820 RVA: 0x00014D2B File Offset: 0x00012F2B
	public \u0001 jPEZROqMpmOrikUBVDIpnrJrIBJO
	{
		get
		{
			return this.dbaeojJaSztKOFFPUkVWKHzidHgz;
		}
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x000367A8 File Offset: 0x000349A8
	public UHsWCAvrjUBCvVSiOhWZLujgvmAM(bool A_1, Func<\u0001> A_2)
	{
		this.gOviNoyFBYtvqgCKxClzEethXbQHA = A_1;
		if (A_2 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		this.ImCAoQAUNODBLdrKcECSLGKfznHOD = A_2;
		this.gsgsIOELxeAzjkBDxhlHadjsiNTO = new WaitCallback(this.krkhzfmLyJIRQOHidXWCoTJtQmtG);
		this.zFNGEviCcHwPmdPvHzfHQlGSkYJbA = new object();
		this.iHspEfUubXAEnOVjhxZqtpigEreQ = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.Idle;
		if (A_1)
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.BqSyuDKMHVGjqheZYGNqJUetCDmk();
		}
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00036804 File Offset: 0x00034A04
	public bool VlWTpnOmouJNHovmWjtCiEYLYIbj()
	{
		object obj = this.zFNGEviCcHwPmdPvHzfHQlGSkYJbA;
		lock (obj)
		{
			if (this.iHspEfUubXAEnOVjhxZqtpigEreQ == UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.AwaitingResult)
			{
				return false;
			}
			this.dbaeojJaSztKOFFPUkVWKHzidHgz = default(\u0001);
			this.iHspEfUubXAEnOVjhxZqtpigEreQ = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.AwaitingResult;
		}
		if (this.gOviNoyFBYtvqgCKxClzEethXbQHA)
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.LPbseuaLHjahoRPPexCqzmMuIMH(this.gsgsIOELxeAzjkBDxhlHadjsiNTO);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(this.gsgsIOELxeAzjkBDxhlHadjsiNTO, this);
		}
		return true;
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00036884 File Offset: 0x00034A84
	public void pHkBJvOWTdCtPUpRPohpUtkRjYrN()
	{
		object obj = this.zFNGEviCcHwPmdPvHzfHQlGSkYJbA;
		lock (obj)
		{
			this.dbaeojJaSztKOFFPUkVWKHzidHgz = default(\u0001);
			this.iHspEfUubXAEnOVjhxZqtpigEreQ = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.Idle;
		}
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x000368D4 File Offset: 0x00034AD4
	private void krkhzfmLyJIRQOHidXWCoTJtQmtG(object A_1)
	{
		object obj = this.zFNGEviCcHwPmdPvHzfHQlGSkYJbA;
		lock (obj)
		{
			if (this.iHspEfUubXAEnOVjhxZqtpigEreQ == UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.AwaitingResult)
			{
				this.dbaeojJaSztKOFFPUkVWKHzidHgz = this.ImCAoQAUNODBLdrKcECSLGKfznHOD();
				this.iHspEfUubXAEnOVjhxZqtpigEreQ = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq.ResultReceived;
			}
		}
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x00014D33 File Offset: 0x00012F33
	public void eJRoAWWYCTmYLtClrCmkPPBxhWgT()
	{
		this.zeNKCIPisTsnqGwiQHxQvhneaGrq(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x00036934 File Offset: 0x00034B34
	protected virtual void BQyOgEplmTfUDHRPggwMjzwDNiPY()
	{
		try
		{
			this.zeNKCIPisTsnqGwiQHxQvhneaGrq(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x00014D42 File Offset: 0x00012F42
	protected virtual void zeNKCIPisTsnqGwiQHxQvhneaGrq(bool A_1)
	{
		if (this.SrCHKcBzmTCLSTtzAEezPAdHHguV)
		{
			return;
		}
		if (A_1)
		{
			this.pHkBJvOWTdCtPUpRPohpUtkRjYrN();
		}
		if (this.gOviNoyFBYtvqgCKxClzEethXbQHA)
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.JMnitVulZtMrWNGyqARVcdtBJKzKA();
		}
		this.SrCHKcBzmTCLSTtzAEezPAdHHguV = true;
	}

	// Token: 0x0400080F RID: 2063
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.LcnmslqXoojMJKEttCSNxwZbDApq iHspEfUubXAEnOVjhxZqtpigEreQ;

	// Token: 0x04000810 RID: 2064
	private \u0001 dbaeojJaSztKOFFPUkVWKHzidHgz;

	// Token: 0x04000811 RID: 2065
	private WaitCallback gsgsIOELxeAzjkBDxhlHadjsiNTO;

	// Token: 0x04000812 RID: 2066
	private object zFNGEviCcHwPmdPvHzfHQlGSkYJbA;

	// Token: 0x04000813 RID: 2067
	private Func<\u0001> ImCAoQAUNODBLdrKcECSLGKfznHOD;

	// Token: 0x04000814 RID: 2068
	private bool gOviNoyFBYtvqgCKxClzEethXbQHA;

	// Token: 0x04000815 RID: 2069
	private bool SrCHKcBzmTCLSTtzAEezPAdHHguV;

	// Token: 0x020000D9 RID: 217
	private enum LcnmslqXoojMJKEttCSNxwZbDApq
	{
		// Token: 0x04000817 RID: 2071
		Idle,
		// Token: 0x04000818 RID: 2072
		AwaitingResult,
		// Token: 0x04000819 RID: 2073
		ResultReceived
	}

	// Token: 0x020000DA RID: 218
	private sealed class XIrwqQAGvSVkzhEgPEMQFwdDtocgA
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00014D6A File Offset: 0x00012F6A
		private static UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA BjbiGCKAPbNleBJItpSgjcIeoMSu
		{
			get
			{
				return UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM ?? new UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA();
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00036964 File Offset: 0x00034B64
		private UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD flXNoGCitaCbniNXhDAnbyaeuQQOA
		{
			get
			{
				UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD result;
				if ((result = this.vjPoFXzwqENxjynTcnXFACUSgByr) == null)
				{
					result = (this.vjPoFXzwqENxjynTcnXFACUSgByr = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD());
				}
				return result;
			}
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0003698C File Offset: 0x00034B8C
		private XIrwqQAGvSVkzhEgPEMQFwdDtocgA()
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA xirwqQAGvSVkzhEgPEMQFwdDtocgA = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM;
			if (xirwqQAGvSVkzhEgPEMQFwdDtocgA != null)
			{
				xirwqQAGvSVkzhEgPEMQFwdDtocgA.NvpmEssMgDjTASDRYAQyYLOVORxe();
			}
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM = this;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00014D7A File Offset: 0x00012F7A
		private void YZvfPBPivJhedtQkOWBEPaFzNOzR()
		{
			this.lXVuUpoPmSjXyRnoDCMWdGXdYKPI++;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00014D8A File Offset: 0x00012F8A
		private void NGWahCsWYuTVQRzkaBFLGGtFTJPW()
		{
			this.lXVuUpoPmSjXyRnoDCMWdGXdYKPI--;
			if (this.lXVuUpoPmSjXyRnoDCMWdGXdYKPI < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", true);
			}
			if (this.lXVuUpoPmSjXyRnoDCMWdGXdYKPI == 0)
			{
				this.NvpmEssMgDjTASDRYAQyYLOVORxe();
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00014DBC File Offset: 0x00012FBC
		private void nQHwjJWTvbCgyWWPtepsNqLlRysH(WaitCallback A_1)
		{
			this.flXNoGCitaCbniNXhDAnbyaeuQQOA.rLByBfpezfRmImSYYdEPVwTBHxOg(A_1);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00014DCA File Offset: 0x00012FCA
		private void xLHjCkQutkRnphefUDqHMsqhbEmm()
		{
			this.flXNoGCitaCbniNXhDAnbyaeuQQOA.BAUtRxkxibOTYPdndHQhtfvypMbM();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00014DD7 File Offset: 0x00012FD7
		private bool gXRBYxbKJYoCUmKamiDPXPSnsOPjA()
		{
			return this.flXNoGCitaCbniNXhDAnbyaeuQQOA.yYumwWABrInyJFDBKiNQHTwBmNXnA();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00014DE4 File Offset: 0x00012FE4
		private void NvpmEssMgDjTASDRYAQyYLOVORxe()
		{
			this.FttbDBFPKQNZcxRtnJRFWIVuIDbP(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x000369B4 File Offset: 0x00034BB4
		protected void DZSBUTggXFJWiCyRjdQwlcYjMiJIb()
		{
			try
			{
				this.FttbDBFPKQNZcxRtnJRFWIVuIDbP(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000369E4 File Offset: 0x00034BE4
		private void FttbDBFPKQNZcxRtnJRFWIVuIDbP(bool A_1)
		{
			if (this.swhhiTogkVfXtPKeXKrhAJLliHXe)
			{
				return;
			}
			if (A_1 && this.vjPoFXzwqENxjynTcnXFACUSgByr != null)
			{
				this.vjPoFXzwqENxjynTcnXFACUSgByr.Dispose();
				this.vjPoFXzwqENxjynTcnXFACUSgByr = null;
			}
			this.lXVuUpoPmSjXyRnoDCMWdGXdYKPI = 0;
			if (UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM == this)
			{
				UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM = null;
			}
			this.swhhiTogkVfXtPKeXKrhAJLliHXe = true;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00014DF3 File Offset: 0x00012FF3
		public static void BqSyuDKMHVGjqheZYGNqJUetCDmk()
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.BjbiGCKAPbNleBJItpSgjcIeoMSu.YZvfPBPivJhedtQkOWBEPaFzNOzR();
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00036A34 File Offset: 0x00034C34
		public static void JMnitVulZtMrWNGyqARVcdtBJKzKA()
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA xirwqQAGvSVkzhEgPEMQFwdDtocgA = UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.qQdRZxOFelRVmZoIsPutqBRiJUdM;
			if (xirwqQAGvSVkzhEgPEMQFwdDtocgA == null)
			{
				return;
			}
			xirwqQAGvSVkzhEgPEMQFwdDtocgA.NGWahCsWYuTVQRzkaBFLGGtFTJPW();
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00014DFF File Offset: 0x00012FFF
		public static void LPbseuaLHjahoRPPexCqzmMuIMH(WaitCallback A_0)
		{
			UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.BjbiGCKAPbNleBJItpSgjcIeoMSu.nQHwjJWTvbCgyWWPtepsNqLlRysH(A_0);
		}

		// Token: 0x0400081A RID: 2074
		private static UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA qQdRZxOFelRVmZoIsPutqBRiJUdM;

		// Token: 0x0400081B RID: 2075
		private UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD vjPoFXzwqENxjynTcnXFACUSgByr;

		// Token: 0x0400081C RID: 2076
		private int lXVuUpoPmSjXyRnoDCMWdGXdYKPI;

		// Token: 0x0400081D RID: 2077
		private bool swhhiTogkVfXtPKeXKrhAJLliHXe;

		// Token: 0x020000DB RID: 219
		private class ZccBzxaEuvANizuJnuPrCydMSyCD : IDisposable
		{
			// Token: 0x06000732 RID: 1842 RVA: 0x00014E0C File Offset: 0x0001300C
			public ZccBzxaEuvANizuJnuPrCydMSyCD()
			{
				this.nZFAnuADqWhHWUJrPQRGdQwcDEe = new object();
				this.ytYpbDpqnDjEOnrhKTzVpYtdhdBE = new List<WaitCallback>();
				this.bsNGKFgWLTUEZigijoXoWyQbOOknA = new List<WaitCallback>();
				this.fHictmHXbSzohRZXFAVgrvoVHaWm = new AutoResetEvent(false);
			}

			// Token: 0x06000733 RID: 1843 RVA: 0x00036A54 File Offset: 0x00034C54
			public void rLByBfpezfRmImSYYdEPVwTBHxOg(WaitCallback A_1)
			{
				if (!this.xgDQRLyVVctqkKBwsPhnoRlptxxr())
				{
					return;
				}
				if (A_1 == null)
				{
					throw new ArgumentNullException("waitCallback");
				}
				object obj = this.nZFAnuADqWhHWUJrPQRGdQwcDEe;
				lock (obj)
				{
					this.ytYpbDpqnDjEOnrhKTzVpYtdhdBE.Add(A_1);
				}
				this.fHictmHXbSzohRZXFAVgrvoVHaWm.Set();
			}

			// Token: 0x06000734 RID: 1844 RVA: 0x00014E41 File Offset: 0x00013041
			public void BAUtRxkxibOTYPdndHQhtfvypMbM()
			{
				this.QPOhUtcIkuqcRoMYxzDgZBGuhTUt();
			}

			// Token: 0x06000735 RID: 1845 RVA: 0x00014E49 File Offset: 0x00013049
			public bool yYumwWABrInyJFDBKiNQHTwBmNXnA()
			{
				return this.xgDQRLyVVctqkKBwsPhnoRlptxxr();
			}

			// Token: 0x06000736 RID: 1846 RVA: 0x00014E51 File Offset: 0x00013051
			private bool xgDQRLyVVctqkKBwsPhnoRlptxxr()
			{
				return !this.NeDNSocNSTLgYcYjzPGtHVWsCeBN && !this.kUywfPoLrJJSWmXaJsOfJgMyvfYf && (this.YkJWaFXKbfizAbNfJjnFBbrevJbnb || this.dpQbgmegKwbPJahnnqadqzjlaJfC != null || this.JpRTFyjeBcflvNzVbMZEWvZzEoyD());
			}

			// Token: 0x06000737 RID: 1847 RVA: 0x00036AC0 File Offset: 0x00034CC0
			private bool JpRTFyjeBcflvNzVbMZEWvZzEoyD()
			{
				UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD.LnSlXcKEBveRkfJkZfgiiEdjpLcB lnSlXcKEBveRkfJkZfgiiEdjpLcB = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD.LnSlXcKEBveRkfJkZfgiiEdjpLcB();
				lnSlXcKEBveRkfJkZfgiiEdjpLcB.ByVUFHhDNvCeydMRXaMegzOTihRJ = this;
				bool result;
				try
				{
					lnSlXcKEBveRkfJkZfgiiEdjpLcB.zwepLEgcxDGOPoatIFLxendierEl = new ManualResetEvent(false);
					this.dpQbgmegKwbPJahnnqadqzjlaJfC = new Thread(new ThreadStart(lnSlXcKEBveRkfJkZfgiiEdjpLcB.tvlgJcEoRWikMgLFmJzgEomDQjIjA));
					this.dpQbgmegKwbPJahnnqadqzjlaJfC.Start();
					lnSlXcKEBveRkfJkZfgiiEdjpLcB.zwepLEgcxDGOPoatIFLxendierEl.WaitOne();
					result = true;
				}
				catch (Exception ex)
				{
					string str = "An exception occurred trying to initialize the thread pool.\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null), true);
					this.dpQbgmegKwbPJahnnqadqzjlaJfC = null;
					this.NeDNSocNSTLgYcYjzPGtHVWsCeBN = true;
					result = false;
				}
				return result;
			}

			// Token: 0x06000738 RID: 1848 RVA: 0x00036B5C File Offset: 0x00034D5C
			private void RDAysKuhfxycueUJMpZCisigDqnp()
			{
				this.YkJWaFXKbfizAbNfJjnFBbrevJbnb = true;
				object obj;
				while (!this.kUywfPoLrJJSWmXaJsOfJgMyvfYf)
				{
					this.fHictmHXbSzohRZXFAVgrvoVHaWm.WaitOne();
					if (this.kUywfPoLrJJSWmXaJsOfJgMyvfYf)
					{
						break;
					}
					obj = this.nZFAnuADqWhHWUJrPQRGdQwcDEe;
					lock (obj)
					{
						MiscTools.Swap<List<WaitCallback>>(ref this.ytYpbDpqnDjEOnrhKTzVpYtdhdBE, ref this.bsNGKFgWLTUEZigijoXoWyQbOOknA);
					}
					List<WaitCallback> list = this.bsNGKFgWLTUEZigijoXoWyQbOOknA;
					int count = list.Count;
					if (count != 0)
					{
						for (int i = 0; i < count; i++)
						{
							try
							{
								list[i](null);
							}
							catch (Exception ex)
							{
								string str = "Exception occurred in thread pool callback.\n";
								Exception ex2 = ex;
								Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null), true);
							}
						}
						list.Clear();
					}
				}
				obj = this.nZFAnuADqWhHWUJrPQRGdQwcDEe;
				lock (obj)
				{
					this.ytYpbDpqnDjEOnrhKTzVpYtdhdBE.Clear();
					this.bsNGKFgWLTUEZigijoXoWyQbOOknA.Clear();
				}
				this.kUywfPoLrJJSWmXaJsOfJgMyvfYf = false;
				this.YkJWaFXKbfizAbNfJjnFBbrevJbnb = false;
			}

			// Token: 0x06000739 RID: 1849 RVA: 0x00014E81 File Offset: 0x00013081
			private void WGGHfcMBQWpIBcehYgwJGheMNfeDA()
			{
				this.dpQbgmegKwbPJahnnqadqzjlaJfC = null;
				this.NeDNSocNSTLgYcYjzPGtHVWsCeBN = false;
				this.kUywfPoLrJJSWmXaJsOfJgMyvfYf = true;
			}

			// Token: 0x0600073A RID: 1850 RVA: 0x00036C88 File Offset: 0x00034E88
			private void QPOhUtcIkuqcRoMYxzDgZBGuhTUt()
			{
				this.WGGHfcMBQWpIBcehYgwJGheMNfeDA();
				try
				{
					this.fHictmHXbSzohRZXFAVgrvoVHaWm.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			// Token: 0x0600073B RID: 1851 RVA: 0x00014E98 File Offset: 0x00013098
			public void Dispose()
			{
				this.bowgeThbmpLPJyNVfROqaseAPiPV(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x0600073C RID: 1852 RVA: 0x00036CBC File Offset: 0x00034EBC
			protected virtual void lLcfiSkMGgZehsTebnOIxBrgnDWTA()
			{
				try
				{
					this.bowgeThbmpLPJyNVfROqaseAPiPV(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			// Token: 0x0600073D RID: 1853 RVA: 0x00014EA7 File Offset: 0x000130A7
			protected virtual void bowgeThbmpLPJyNVfROqaseAPiPV(bool A_1)
			{
				if (this.PCpOfeeRklXQBWPRubrBBfQEonhBA)
				{
					return;
				}
				this.QPOhUtcIkuqcRoMYxzDgZBGuhTUt();
				this.PCpOfeeRklXQBWPRubrBBfQEonhBA = true;
			}

			// Token: 0x0400081E RID: 2078
			private readonly object nZFAnuADqWhHWUJrPQRGdQwcDEe;

			// Token: 0x0400081F RID: 2079
			private List<WaitCallback> ytYpbDpqnDjEOnrhKTzVpYtdhdBE;

			// Token: 0x04000820 RID: 2080
			private List<WaitCallback> bsNGKFgWLTUEZigijoXoWyQbOOknA;

			// Token: 0x04000821 RID: 2081
			private Thread dpQbgmegKwbPJahnnqadqzjlaJfC;

			// Token: 0x04000822 RID: 2082
			private AutoResetEvent fHictmHXbSzohRZXFAVgrvoVHaWm;

			// Token: 0x04000823 RID: 2083
			private bool YkJWaFXKbfizAbNfJjnFBbrevJbnb;

			// Token: 0x04000824 RID: 2084
			private bool kUywfPoLrJJSWmXaJsOfJgMyvfYf;

			// Token: 0x04000825 RID: 2085
			private bool NeDNSocNSTLgYcYjzPGtHVWsCeBN;

			// Token: 0x04000826 RID: 2086
			private bool PCpOfeeRklXQBWPRubrBBfQEonhBA;

			// Token: 0x020000DC RID: 220
			[CompilerGenerated]
			private sealed class LnSlXcKEBveRkfJkZfgiiEdjpLcB
			{
				// Token: 0x0600073F RID: 1855 RVA: 0x00014EC1 File Offset: 0x000130C1
				internal void tvlgJcEoRWikMgLFmJzgEomDQjIjA()
				{
					this.zwepLEgcxDGOPoatIFLxendierEl.Set();
					this.ByVUFHhDNvCeydMRXaMegzOTihRJ.RDAysKuhfxycueUJMpZCisigDqnp();
				}

				// Token: 0x04000827 RID: 2087
				public UHsWCAvrjUBCvVSiOhWZLujgvmAM<\u0001>.XIrwqQAGvSVkzhEgPEMQFwdDtocgA.ZccBzxaEuvANizuJnuPrCydMSyCD ByVUFHhDNvCeydMRXaMegzOTihRJ;

				// Token: 0x04000828 RID: 2088
				public ManualResetEvent zwepLEgcxDGOPoatIFLxendierEl;
			}
		}
	}
}
