using System;
using Rewired.Utils;

// Token: 0x020000E1 RID: 225
internal class bxLmBpBgWqThrxuxOJdyAmAMzBBF : IDisposable
{
	// Token: 0x17000186 RID: 390
	// (get) Token: 0x060007C6 RID: 1990 RVA: 0x00015784 File Offset: 0x00013984
	public int CChljmZpvvdbtMtpnTJgkJcADexi
	{
		get
		{
			return this.sWLGqcmBdcKJFthgIaPwhutOXpkq;
		}
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0001578C File Offset: 0x0001398C
	public int VWjrmAofihCoYihoGMczebbBPmTGb
	{
		get
		{
			return this.aJiFftgYyttedFHkGgJsSPXhnpoJA;
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x060007C8 RID: 1992 RVA: 0x00015794 File Offset: 0x00013994
	public bool DHuViVVGqZHnbWWqVBqAkywFcvIL
	{
		get
		{
			return this.jEAjtWFlRUzoPBlcKobXeOcIgyNTB;
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x0001579C File Offset: 0x0001399C
	public bxLmBpBgWqThrxuxOJdyAmAMzBBF(int A_1)
	{
		this.sWLGqcmBdcKJFthgIaPwhutOXpkq = A_1;
		if (A_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		this.FnCoaOlsrgQCeOruxDEeLYwmdpcl = new rldBWJiPNwVWNAQGlSaZBtbmtjRwA(A_1);
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x00038458 File Offset: 0x00036658
	public unsafe int IewrDIMBSYPXlGVpqhrKDLdxGOB(byte* A_1, int A_2, int A_3, out int A_4, out uint A_5)
	{
		A_4 = (int)this.OpDQsCSGdEgzYELLHaMoNHcpSubdb;
		A_5 = this.SpvdqdCIZNOMlweXTbRlKdGykHts;
		if (A_1 == null || A_2 <= 0 || A_3 <= 0)
		{
			return 0;
		}
		if (A_3 > A_2)
		{
			A_3 = A_2;
		}
		int num = this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.YeJHPsFeZhMbXdDIaHWhLzkgszVpB(A_1, A_2, A_3, (int)this.OpDQsCSGdEgzYELLHaMoNHcpSubdb, 0);
		if (num == 0)
		{
			return 0;
		}
		if (num < A_3)
		{
			num += this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.YeJHPsFeZhMbXdDIaHWhLzkgszVpB(A_1 + num, A_2 - num, A_3 - num, 0, 0);
		}
		this.VItFyVHvkTiYyAUnDVQReZCbxeKoB(num);
		return num;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000157C6 File Offset: 0x000139C6
	public unsafe int FUFzufgCiYOVZVfPtQSIyxrOdPYf(IntPtr A_1, int A_2, int A_3, out int A_4, out uint A_5)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0 || A_3 <= 0)
		{
			A_4 = (int)this.OpDQsCSGdEgzYELLHaMoNHcpSubdb;
			A_5 = this.SpvdqdCIZNOMlweXTbRlKdGykHts;
			return 0;
		}
		return this.IewrDIMBSYPXlGVpqhrKDLdxGOB((byte*)((void*)A_1), A_2, A_3, out A_4, out A_5);
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x000384D0 File Offset: 0x000366D0
	public unsafe int NWUfcBnLwPHeSOAdSRKvsOswPW(byte[] A_1, int A_2, out int A_3, out uint A_4)
	{
		if (A_1 == null || A_2 <= 0)
		{
			A_3 = (int)this.OpDQsCSGdEgzYELLHaMoNHcpSubdb;
			A_4 = this.SpvdqdCIZNOMlweXTbRlKdGykHts;
			return 0;
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
		return this.IewrDIMBSYPXlGVpqhrKDLdxGOB(ptr, A_1.Length, A_2, out A_3, out A_4);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x00038520 File Offset: 0x00036720
	public unsafe int NpoEgfaAGLFShRuddbqTAMhnWXjrA(byte* A_1, int A_2, int A_3)
	{
		int num;
		uint num2;
		return this.IewrDIMBSYPXlGVpqhrKDLdxGOB(A_1, A_2, A_3, out num, out num2);
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x0003853C File Offset: 0x0003673C
	public int xaTfaOUyrxEwsolxceVjTbToAxUz(IntPtr A_1, int A_2, int A_3)
	{
		int num;
		uint num2;
		return this.FUFzufgCiYOVZVfPtQSIyxrOdPYf(A_1, A_2, A_3, out num, out num2);
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x00038558 File Offset: 0x00036758
	public int XLHYEPMGHughigtUHYbzyWaphkfCA(byte[] A_1, int A_2)
	{
		int num;
		uint num2;
		return this.NWUfcBnLwPHeSOAdSRKvsOswPW(A_1, A_2, out num, out num2);
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x00038574 File Offset: 0x00036774
	public unsafe int BtRLjzXruHqCnSWdEddClSeDDtahA(byte* A_1, int A_2, int A_3)
	{
		if (A_1 == null || A_2 <= 0 || A_3 <= 0 || this.aJiFftgYyttedFHkGgJsSPXhnpoJA == 0)
		{
			return 0;
		}
		if (A_3 > A_2)
		{
			A_3 = A_2;
		}
		if (A_3 > this.aJiFftgYyttedFHkGgJsSPXhnpoJA)
		{
			A_3 = this.aJiFftgYyttedFHkGgJsSPXhnpoJA;
		}
		int num = this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.GxwdbhBUTKUUkNdtiRFOCVSOxbvU(A_1, A_2, A_3, (int)this.iPSpTKWrpkDkuwYBMCUXkMInUaoO, 0);
		if (num <= 0)
		{
			return 0;
		}
		if (num < A_3)
		{
			num += this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.GxwdbhBUTKUUkNdtiRFOCVSOxbvU(A_1 + num, A_2 - num, A_3 - num, 0, 0);
		}
		this.IKcQHYWIDUDrHhTwwwryrExFlAdFA(num);
		return num;
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x000385F4 File Offset: 0x000367F4
	public unsafe int SNFcEniGfoalYxqjexfYaOXaHniaA(byte[] A_1, int A_2)
	{
		if (A_1 == null || A_2 <= 0)
		{
			return 0;
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
		return this.BtRLjzXruHqCnSWdEddClSeDDtahA(ptr, A_1.Length, A_2);
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x00015804 File Offset: 0x00013A04
	public unsafe int EDDgVNYgmTeMkdACxFSqeIomfMrXA(IntPtr A_1, int A_2, int A_3)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0 || A_3 <= 0)
		{
			return 0;
		}
		return this.BtRLjzXruHqCnSWdEddClSeDDtahA((byte*)((void*)A_1), A_2, A_3);
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00038630 File Offset: 0x00036830
	public unsafe int vsUfjzYOOEgniBqCEsqYxGlqeJErA(byte* A_1, int A_2, int A_3, int A_4)
	{
		if (A_1 == null || A_2 <= 0 || A_3 <= 0 || this.aJiFftgYyttedFHkGgJsSPXhnpoJA == 0 || A_4 < 0 || A_4 >= this.sWLGqcmBdcKJFthgIaPwhutOXpkq)
		{
			return 0;
		}
		if (A_3 > A_2)
		{
			A_3 = A_2;
		}
		if (A_3 > this.aJiFftgYyttedFHkGgJsSPXhnpoJA)
		{
			A_3 = this.aJiFftgYyttedFHkGgJsSPXhnpoJA;
		}
		int num = this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.GxwdbhBUTKUUkNdtiRFOCVSOxbvU(A_1, A_2, A_3, A_4, 0);
		if (num <= 0)
		{
			return 0;
		}
		if (num < A_3)
		{
			num += this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.GxwdbhBUTKUUkNdtiRFOCVSOxbvU(A_1 + num, A_2 - num, A_3 - num, 0, 0);
		}
		return num;
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000386B4 File Offset: 0x000368B4
	public unsafe int iGBhZVIflQGqMBFfZQzEaItKmjlYA(byte[] A_1, int A_2, int A_3)
	{
		if (A_1 == null || A_2 <= 0 || A_2 <= 0 || A_3 <= 0)
		{
			return 0;
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
		return this.vsUfjzYOOEgniBqCEsqYxGlqeJErA(ptr, A_1.Length, A_2, A_3);
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x0001582B File Offset: 0x00013A2B
	public unsafe int xJyYOAWGJHImOepfyZllsWLAkcfl(IntPtr A_1, int A_2, int A_3, int A_4)
	{
		if (A_1 == IntPtr.Zero || A_2 <= 0 || A_3 <= 0 || A_4 <= 0)
		{
			return 0;
		}
		return this.vsUfjzYOOEgniBqCEsqYxGlqeJErA((byte*)((void*)A_1), A_2, A_3, A_4);
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000386F8 File Offset: 0x000368F8
	public bool UnLumDhRgxGtsHINNuPyqwUXoSdSA(int A_1, uint A_2)
	{
		if (A_1 < 0 || A_1 >= this.sWLGqcmBdcKJFthgIaPwhutOXpkq)
		{
			return false;
		}
		if ((long)A_1 < this.OpDQsCSGdEgzYELLHaMoNHcpSubdb)
		{
			if (A_2 == this.SpvdqdCIZNOMlweXTbRlKdGykHts)
			{
				return true;
			}
		}
		else if ((long)A_1 >= this.OpDQsCSGdEgzYELLHaMoNHcpSubdb)
		{
			if (this.SpvdqdCIZNOMlweXTbRlKdGykHts == 0U)
			{
				return false;
			}
			if (this.SpvdqdCIZNOMlweXTbRlKdGykHts - 1U == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x00015859 File Offset: 0x00013A59
	public void nJiwrhjTjwvPmsMbPGMCkeQwcyoJA()
	{
		this.OpDQsCSGdEgzYELLHaMoNHcpSubdb = 0L;
		this.iPSpTKWrpkDkuwYBMCUXkMInUaoO = 0L;
		this.aJiFftgYyttedFHkGgJsSPXhnpoJA = 0;
		this.jEAjtWFlRUzoPBlcKobXeOcIgyNTB = false;
		this.SpvdqdCIZNOMlweXTbRlKdGykHts = 0U;
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x0003874C File Offset: 0x0003694C
	private void VItFyVHvkTiYyAUnDVQReZCbxeKoB(int A_1)
	{
		if (A_1 <= 0)
		{
			return;
		}
		int num = (int)this.OpDQsCSGdEgzYELLHaMoNHcpSubdb;
		this.OpDQsCSGdEgzYELLHaMoNHcpSubdb += (long)A_1;
		bool flag = false;
		if ((long)num < this.iPSpTKWrpkDkuwYBMCUXkMInUaoO)
		{
			if (this.OpDQsCSGdEgzYELLHaMoNHcpSubdb > this.iPSpTKWrpkDkuwYBMCUXkMInUaoO)
			{
				flag = true;
			}
		}
		else if ((long)num > this.iPSpTKWrpkDkuwYBMCUXkMInUaoO)
		{
			if (this.OpDQsCSGdEgzYELLHaMoNHcpSubdb - (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq > this.iPSpTKWrpkDkuwYBMCUXkMInUaoO)
			{
				flag = true;
			}
		}
		else if (this.aJiFftgYyttedFHkGgJsSPXhnpoJA > 0)
		{
			flag = true;
		}
		if (flag)
		{
			this.jEAjtWFlRUzoPBlcKobXeOcIgyNTB = true;
			this.iPSpTKWrpkDkuwYBMCUXkMInUaoO = this.OpDQsCSGdEgzYELLHaMoNHcpSubdb;
			if (this.iPSpTKWrpkDkuwYBMCUXkMInUaoO >= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq)
			{
				this.iPSpTKWrpkDkuwYBMCUXkMInUaoO -= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq;
			}
		}
		if (this.OpDQsCSGdEgzYELLHaMoNHcpSubdb >= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq)
		{
			this.OpDQsCSGdEgzYELLHaMoNHcpSubdb -= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq;
			this.YTxuJpHGikHwZiiVRTOmlNyXCQbP();
		}
		this.aJiFftgYyttedFHkGgJsSPXhnpoJA = (int)MathTools.Clamp((long)this.aJiFftgYyttedFHkGgJsSPXhnpoJA + (long)A_1, 0L, (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq);
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x00038844 File Offset: 0x00036A44
	private void IKcQHYWIDUDrHhTwwwryrExFlAdFA(int A_1)
	{
		if (A_1 <= 0)
		{
			return;
		}
		if (this.jEAjtWFlRUzoPBlcKobXeOcIgyNTB)
		{
			this.jEAjtWFlRUzoPBlcKobXeOcIgyNTB = false;
		}
		this.iPSpTKWrpkDkuwYBMCUXkMInUaoO += (long)A_1;
		if (this.iPSpTKWrpkDkuwYBMCUXkMInUaoO >= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq)
		{
			this.iPSpTKWrpkDkuwYBMCUXkMInUaoO -= (long)this.sWLGqcmBdcKJFthgIaPwhutOXpkq;
		}
		long num = (long)this.aJiFftgYyttedFHkGgJsSPXhnpoJA - (long)A_1;
		this.aJiFftgYyttedFHkGgJsSPXhnpoJA = ((num < 0L) ? 0 : ((int)num));
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x00015880 File Offset: 0x00013A80
	private void YTxuJpHGikHwZiiVRTOmlNyXCQbP()
	{
		if (this.SpvdqdCIZNOMlweXTbRlKdGykHts == 4294967295U)
		{
			this.SpvdqdCIZNOMlweXTbRlKdGykHts = 0U;
			return;
		}
		this.SpvdqdCIZNOMlweXTbRlKdGykHts += 1U;
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000158A1 File Offset: 0x00013AA1
	public void Dispose()
	{
		this.YwxlUoUJuBrEPgqVrfURCUzhlnKdb(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000388B4 File Offset: 0x00036AB4
	protected virtual void zzQATYEbOEMUvFoOZakUwXZSbaQfA()
	{
		try
		{
			this.YwxlUoUJuBrEPgqVrfURCUzhlnKdb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000158B0 File Offset: 0x00013AB0
	protected void YwxlUoUJuBrEPgqVrfURCUzhlnKdb(bool A_1)
	{
		if (this.ftpitdoEGYqndbnqCWCoaDnyyCXg)
		{
			return;
		}
		if (A_1 && this.FnCoaOlsrgQCeOruxDEeLYwmdpcl != null)
		{
			this.FnCoaOlsrgQCeOruxDEeLYwmdpcl.Dispose();
		}
		this.ftpitdoEGYqndbnqCWCoaDnyyCXg = true;
	}

	// Token: 0x04000833 RID: 2099
	private readonly rldBWJiPNwVWNAQGlSaZBtbmtjRwA FnCoaOlsrgQCeOruxDEeLYwmdpcl;

	// Token: 0x04000834 RID: 2100
	private readonly int sWLGqcmBdcKJFthgIaPwhutOXpkq;

	// Token: 0x04000835 RID: 2101
	private long OpDQsCSGdEgzYELLHaMoNHcpSubdb;

	// Token: 0x04000836 RID: 2102
	private long iPSpTKWrpkDkuwYBMCUXkMInUaoO;

	// Token: 0x04000837 RID: 2103
	private int aJiFftgYyttedFHkGgJsSPXhnpoJA;

	// Token: 0x04000838 RID: 2104
	private bool jEAjtWFlRUzoPBlcKobXeOcIgyNTB;

	// Token: 0x04000839 RID: 2105
	private uint SpvdqdCIZNOMlweXTbRlKdGykHts;

	// Token: 0x0400083A RID: 2106
	private bool ftpitdoEGYqndbnqCWCoaDnyyCXg;
}
