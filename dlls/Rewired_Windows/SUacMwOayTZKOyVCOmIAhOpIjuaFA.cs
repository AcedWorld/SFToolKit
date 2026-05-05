using System;
using System.Runtime.CompilerServices;

// Token: 0x02000248 RID: 584
internal class SUacMwOayTZKOyVCOmIAhOpIjuaFA
{
	// Token: 0x06000F1D RID: 3869 RVA: 0x00019B30 File Offset: 0x00017D30
	public SUacMwOayTZKOyVCOmIAhOpIjuaFA(SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz A_1)
	{
		this.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA = new byte[0];
		this.kMErAmtvYlNsTnkVuUPrqEPkeLA = A_1;
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x00019B4B File Offset: 0x00017D4B
	public SUacMwOayTZKOyVCOmIAhOpIjuaFA(byte[] A_1, SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz A_2)
	{
		this.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA = A_1;
		this.kMErAmtvYlNsTnkVuUPrqEPkeLA = A_2;
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x00019B61 File Offset: 0x00017D61
	public SUacMwOayTZKOyVCOmIAhOpIjuaFA(int A_1)
	{
		this.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA = new byte[A_1];
		this.kMErAmtvYlNsTnkVuUPrqEPkeLA = SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz.NoDataRead;
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000F20 RID: 3872 RVA: 0x00019B7C File Offset: 0x00017D7C
	// (set) Token: 0x06000F21 RID: 3873 RVA: 0x00019B84 File Offset: 0x00017D84
	public byte[] SnlFfMeLwJXFbUsWTtYFLqfBBGaXA { get; private set; }

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000F22 RID: 3874 RVA: 0x00019B8D File Offset: 0x00017D8D
	// (set) Token: 0x06000F23 RID: 3875 RVA: 0x00019B95 File Offset: 0x00017D95
	public SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz kMErAmtvYlNsTnkVuUPrqEPkeLA { get; private set; }

	// Token: 0x06000F24 RID: 3876 RVA: 0x00019B9E File Offset: 0x00017D9E
	public void XdapVcVNhZckqKNLudMhUMyPhLqrA(byte[] A_1, SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz A_2)
	{
		this.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA = A_1;
		this.kMErAmtvYlNsTnkVuUPrqEPkeLA = A_2;
	}

	// Token: 0x04002A3D RID: 10813
	[CompilerGenerated]
	private byte[] HiwCoEFnryMHNeEgCVBoXuqwMBtB;

	// Token: 0x04002A3E RID: 10814
	[CompilerGenerated]
	private SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz PNsHoHpNXlgXpmFvtQJwbFSUaFEz;

	// Token: 0x02000249 RID: 585
	public enum QvFBdRendFHjksdsTPLahkLdMJRz
	{
		// Token: 0x04002A40 RID: 10816
		Success,
		// Token: 0x04002A41 RID: 10817
		WaitTimedOut,
		// Token: 0x04002A42 RID: 10818
		WaitFail,
		// Token: 0x04002A43 RID: 10819
		NoDataRead,
		// Token: 0x04002A44 RID: 10820
		ReadError,
		// Token: 0x04002A45 RID: 10821
		NotConnected,
		// Token: 0x04002A46 RID: 10822
		WaitIOCompletion,
		// Token: 0x04002A47 RID: 10823
		WaitAbandoned
	}
}
