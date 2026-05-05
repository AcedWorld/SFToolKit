using System;
using System.Runtime.InteropServices;

// Token: 0x02000046 RID: 70
[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct hrpcZZIqnmZSMLjZjTNAXapJJkbG
{
	// Token: 0x060002BE RID: 702 RVA: 0x00012952 File Offset: 0x00010B52
	static hrpcZZIqnmZSMLjZjTNAXapJJkbG()
	{
		hrpcZZIqnmZSMLjZjTNAXapJJkbG.uSSuzkUphQszNJOrxqGQdYTcfVer = (hrpcZZIqnmZSMLjZjTNAXapJJkbG.ZSYQTclJRvCVVlFaHcCqwDqfpRGt == 8);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0002992C File Offset: 0x00027B2C
	public static hrpcZZIqnmZSMLjZjTNAXapJJkbG eCkafLFmHWHXPAYGdTcCxpuZgFSvA(byte[] A_0, int A_1)
	{
		hrpcZZIqnmZSMLjZjTNAXapJJkbG hrpcZZIqnmZSMLjZjTNAXapJJkbG = default(hrpcZZIqnmZSMLjZjTNAXapJJkbG);
		if (hrpcZZIqnmZSMLjZjTNAXapJJkbG.uSSuzkUphQszNJOrxqGQdYTcfVer)
		{
			hrpcZZIqnmZSMLjZjTNAXapJJkbG.rXMNhdvXzrGmbnMJZjirmsBCYfQN = BitConverter.ToUInt64(A_0, A_1);
			hrpcZZIqnmZSMLjZjTNAXapJJkbG.ULhVDekLcyHFTLDSrCxHUKlYHJsH = new IntPtr((long)hrpcZZIqnmZSMLjZjTNAXapJJkbG.rXMNhdvXzrGmbnMJZjirmsBCYfQN);
		}
		else
		{
			hrpcZZIqnmZSMLjZjTNAXapJJkbG.wnzNtliLkCSIYasROqnvHzhlgsYo = BitConverter.ToUInt32(A_0, A_1);
			hrpcZZIqnmZSMLjZjTNAXapJJkbG.ULhVDekLcyHFTLDSrCxHUKlYHJsH = new IntPtr((int)hrpcZZIqnmZSMLjZjTNAXapJJkbG.wnzNtliLkCSIYasROqnvHzhlgsYo);
		}
		return hrpcZZIqnmZSMLjZjTNAXapJJkbG;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0001296B File Offset: 0x00010B6B
	public static IntPtr HkvJIvzgYovqNXbBhQyZROqZLDKe(hrpcZZIqnmZSMLjZjTNAXapJJkbG A_0)
	{
		return A_0.ULhVDekLcyHFTLDSrCxHUKlYHJsH;
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x0002998C File Offset: 0x00027B8C
	public static hrpcZZIqnmZSMLjZjTNAXapJJkbG qUExyHmGDHFBGSdyvQzZmRGfFvXe(IntPtr A_0)
	{
		hrpcZZIqnmZSMLjZjTNAXapJJkbG result = default(hrpcZZIqnmZSMLjZjTNAXapJJkbG);
		result.ULhVDekLcyHFTLDSrCxHUKlYHJsH = A_0;
		if (hrpcZZIqnmZSMLjZjTNAXapJJkbG.uSSuzkUphQszNJOrxqGQdYTcfVer)
		{
			result.rXMNhdvXzrGmbnMJZjirmsBCYfQN = (ulong)A_0.ToInt64();
		}
		else
		{
			result.wnzNtliLkCSIYasROqnvHzhlgsYo = (uint)A_0.ToInt32();
		}
		return result;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00012973 File Offset: 0x00010B73
	public string iNmkrDbgpjhGmEiutEBPEcYjpAoEb()
	{
		if (hrpcZZIqnmZSMLjZjTNAXapJJkbG.uSSuzkUphQszNJOrxqGQdYTcfVer)
		{
			return this.rXMNhdvXzrGmbnMJZjirmsBCYfQN.ToString();
		}
		return this.wnzNtliLkCSIYasROqnvHzhlgsYo.ToString();
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00012993 File Offset: 0x00010B93
	public int cMjeMHnPvwbpigunsFleQtbIDHaS()
	{
		if (hrpcZZIqnmZSMLjZjTNAXapJJkbG.uSSuzkUphQszNJOrxqGQdYTcfVer)
		{
			return (int)this.rXMNhdvXzrGmbnMJZjirmsBCYfQN;
		}
		return (int)this.wnzNtliLkCSIYasROqnvHzhlgsYo;
	}

	// Token: 0x04000472 RID: 1138
	[FieldOffset(0)]
	private uint wnzNtliLkCSIYasROqnvHzhlgsYo;

	// Token: 0x04000473 RID: 1139
	[FieldOffset(0)]
	private ulong rXMNhdvXzrGmbnMJZjirmsBCYfQN;

	// Token: 0x04000474 RID: 1140
	[FieldOffset(0)]
	private IntPtr ULhVDekLcyHFTLDSrCxHUKlYHJsH;

	// Token: 0x04000475 RID: 1141
	private static readonly bool uSSuzkUphQszNJOrxqGQdYTcfVer;

	// Token: 0x04000476 RID: 1142
	public static readonly int ZSYQTclJRvCVVlFaHcCqwDqfpRGt = IntPtr.Size;
}
