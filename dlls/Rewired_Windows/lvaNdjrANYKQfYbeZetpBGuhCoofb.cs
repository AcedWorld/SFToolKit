using System;
using System.Runtime.CompilerServices;

// Token: 0x02000256 RID: 598
internal class lvaNdjrANYKQfYbeZetpBGuhCoofb
{
	// Token: 0x06000F74 RID: 3956 RVA: 0x00019D7A File Offset: 0x00017F7A
	public lvaNdjrANYKQfYbeZetpBGuhCoofb(int A_1)
	{
		Array.Resize<byte>(ref this.NUjTYBtcjLSNUUWkZmuuieChHzrH, A_1 - 1);
	}

	// Token: 0x06000F75 RID: 3957 RVA: 0x00046A0C File Offset: 0x00044C0C
	public lvaNdjrANYKQfYbeZetpBGuhCoofb(int A_1, SUacMwOayTZKOyVCOmIAhOpIjuaFA A_2)
	{
		this.kPdEbvRzBMZZVYeCSBbKZcGweqgW = A_2.kMErAmtvYlNsTnkVuUPrqEPkeLA;
		Array.Resize<byte>(ref this.NUjTYBtcjLSNUUWkZmuuieChHzrH, A_1 - 1);
		if (A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA != null)
		{
			if (A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA.Length == 0)
			{
				this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = false;
				return;
			}
			this.uwZKCLbktBmclAkibWkfDHIyNzPV = A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA[0];
			this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = true;
			if (A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA.Length > 1)
			{
				int length = A_1 - 1;
				if (A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA.Length < A_1 - 1)
				{
					length = A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA.Length;
				}
				Array.Copy(A_2.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA, 1, this.NUjTYBtcjLSNUUWkZmuuieChHzrH, 0, length);
				return;
			}
		}
		else
		{
			this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = false;
		}
	}

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000F76 RID: 3958 RVA: 0x00019D9C File Offset: 0x00017F9C
	// (set) Token: 0x06000F77 RID: 3959 RVA: 0x00019DA4 File Offset: 0x00017FA4
	public bool HyjBWIbskhAUQgNPDhCnPExcmLZTc { get; private set; }

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000F78 RID: 3960 RVA: 0x00019DAD File Offset: 0x00017FAD
	public SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz bCUtJwFSHFBjkezkmHyqrfRXDvft
	{
		get
		{
			return this.kPdEbvRzBMZZVYeCSBbKZcGweqgW;
		}
	}

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000F79 RID: 3961 RVA: 0x00019DB5 File Offset: 0x00017FB5
	// (set) Token: 0x06000F7A RID: 3962 RVA: 0x00019DBD File Offset: 0x00017FBD
	public byte EWWhrjZBCltYLnGyTILULnplEPLp
	{
		get
		{
			return this.uwZKCLbktBmclAkibWkfDHIyNzPV;
		}
		set
		{
			this.uwZKCLbktBmclAkibWkfDHIyNzPV = value;
			this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = true;
		}
	}

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000F7B RID: 3963 RVA: 0x00019DCD File Offset: 0x00017FCD
	// (set) Token: 0x06000F7C RID: 3964 RVA: 0x00019DD5 File Offset: 0x00017FD5
	public byte[] klooLMRWfUPBKUCrDSIsbasPAjBhA
	{
		get
		{
			return this.NUjTYBtcjLSNUUWkZmuuieChHzrH;
		}
		set
		{
			this.NUjTYBtcjLSNUUWkZmuuieChHzrH = value;
			this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = true;
		}
	}

	// Token: 0x06000F7D RID: 3965 RVA: 0x00046AB4 File Offset: 0x00044CB4
	public byte[] mexealhJdWbhjrOBTBkJCoOxNCSx()
	{
		byte[] array = null;
		Array.Resize<byte>(ref array, this.NUjTYBtcjLSNUUWkZmuuieChHzrH.Length + 1);
		array[0] = this.uwZKCLbktBmclAkibWkfDHIyNzPV;
		Array.Copy(this.NUjTYBtcjLSNUUWkZmuuieChHzrH, 0, array, 1, this.NUjTYBtcjLSNUUWkZmuuieChHzrH.Length);
		return array;
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x00046AF4 File Offset: 0x00044CF4
	public void BoBGkxiUqVEVfGCyQGapHWXIXzXmA(byte[] A_1, SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz A_2)
	{
		if (A_1 != null && A_1.Length != 0)
		{
			if (this.NUjTYBtcjLSNUUWkZmuuieChHzrH.Length != A_1.Length - 1)
			{
				Array.Resize<byte>(ref this.NUjTYBtcjLSNUUWkZmuuieChHzrH, A_1.Length - 1);
			}
			Array.Copy(A_1, 1, this.NUjTYBtcjLSNUUWkZmuuieChHzrH, 0, A_1.Length - 1);
		}
		else
		{
			this.uwZKCLbktBmclAkibWkfDHIyNzPV = 0;
			if (this.NUjTYBtcjLSNUUWkZmuuieChHzrH == null || this.NUjTYBtcjLSNUUWkZmuuieChHzrH.Length != 0)
			{
				this.NUjTYBtcjLSNUUWkZmuuieChHzrH = new byte[0];
			}
		}
		this.kPdEbvRzBMZZVYeCSBbKZcGweqgW = A_2;
		this.HyjBWIbskhAUQgNPDhCnPExcmLZTc = true;
	}

	// Token: 0x04002A6F RID: 10863
	private byte uwZKCLbktBmclAkibWkfDHIyNzPV;

	// Token: 0x04002A70 RID: 10864
	private byte[] NUjTYBtcjLSNUUWkZmuuieChHzrH = new byte[0];

	// Token: 0x04002A71 RID: 10865
	private SUacMwOayTZKOyVCOmIAhOpIjuaFA.QvFBdRendFHjksdsTPLahkLdMJRz kPdEbvRzBMZZVYeCSBbKZcGweqgW;

	// Token: 0x04002A72 RID: 10866
	[CompilerGenerated]
	private bool mmKUmcqUjlMdTrFiHxVPvVvRbkHG;
}
