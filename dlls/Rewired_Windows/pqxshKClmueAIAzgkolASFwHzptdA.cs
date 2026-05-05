using System;

// Token: 0x02000137 RID: 311
internal struct pqxshKClmueAIAzgkolASFwHzptdA
{
	// Token: 0x06000AF2 RID: 2802 RVA: 0x0003C9B8 File Offset: 0x0003ABB8
	public static pqxshKClmueAIAzgkolASFwHzptdA eQwGTvhqeUzfpQJhuJKJUnCWTYS(byte[] A_0, int A_1)
	{
		pqxshKClmueAIAzgkolASFwHzptdA result = default(pqxshKClmueAIAzgkolASFwHzptdA);
		if (pqxshKClmueAIAzgkolASFwHzptdA.HhRWmZovOicnDCtwOnNFlPJuyHyv)
		{
			result.XMHffQmcwmOCggRnoMrjMzCRLrqv = BitConverter.ToUInt64(A_0, A_1);
		}
		else
		{
			result.mLLcIVjToBZwQpjIxwSvgIuYPTXyA = BitConverter.ToUInt32(A_0, A_1);
		}
		return result;
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x00017BFD File Offset: 0x00015DFD
	public static uint OdYvBEAewbihjHuTTuZYGoeAEZBL(pqxshKClmueAIAzgkolASFwHzptdA A_0)
	{
		if (pqxshKClmueAIAzgkolASFwHzptdA.HhRWmZovOicnDCtwOnNFlPJuyHyv)
		{
			return (uint)A_0.XMHffQmcwmOCggRnoMrjMzCRLrqv;
		}
		return A_0.mLLcIVjToBZwQpjIxwSvgIuYPTXyA;
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x00017C14 File Offset: 0x00015E14
	public static ulong OdYvBEAewbihjHuTTuZYGoeAEZBL(pqxshKClmueAIAzgkolASFwHzptdA A_0)
	{
		if (pqxshKClmueAIAzgkolASFwHzptdA.HhRWmZovOicnDCtwOnNFlPJuyHyv)
		{
			return A_0.XMHffQmcwmOCggRnoMrjMzCRLrqv;
		}
		return (ulong)A_0.mLLcIVjToBZwQpjIxwSvgIuYPTXyA;
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x00017C2B File Offset: 0x00015E2B
	public string KudaBSDqjXKIqUUjzbhNAQXhjQUGc()
	{
		if (pqxshKClmueAIAzgkolASFwHzptdA.HhRWmZovOicnDCtwOnNFlPJuyHyv)
		{
			return this.XMHffQmcwmOCggRnoMrjMzCRLrqv.ToString();
		}
		return this.mLLcIVjToBZwQpjIxwSvgIuYPTXyA.ToString();
	}

	// Token: 0x04000966 RID: 2406
	private uint mLLcIVjToBZwQpjIxwSvgIuYPTXyA;

	// Token: 0x04000967 RID: 2407
	private ulong XMHffQmcwmOCggRnoMrjMzCRLrqv;

	// Token: 0x04000968 RID: 2408
	private static readonly bool HhRWmZovOicnDCtwOnNFlPJuyHyv = IntPtr.Size == 8;

	// Token: 0x04000969 RID: 2409
	public static readonly int nZeaqlgnbaiRmcNZWYxkovPuDUl = pqxshKClmueAIAzgkolASFwHzptdA.HhRWmZovOicnDCtwOnNFlPJuyHyv ? 8 : 4;
}
