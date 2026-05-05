using System;

// Token: 0x02000161 RID: 353
internal struct qfbVmoiTxWecqFPlWHtxrqxyfhlkA
{
	// Token: 0x06000B76 RID: 2934 RVA: 0x0003E0E0 File Offset: 0x0003C2E0
	public static qfbVmoiTxWecqFPlWHtxrqxyfhlkA PsOdbPjGawPjUgLQzkxefmrhySnIB(byte[] A_0, int A_1)
	{
		qfbVmoiTxWecqFPlWHtxrqxyfhlkA result = default(qfbVmoiTxWecqFPlWHtxrqxyfhlkA);
		if (qfbVmoiTxWecqFPlWHtxrqxyfhlkA.HUHdCOIOnzekYphhVVRZTkcVkOVu)
		{
			result.YZkpGphfgrPAhgikJZWVSxaSTvpg = BitConverter.ToUInt64(A_0, A_1);
		}
		else
		{
			result.mhLFnmEmjpXCTSxRHEeHCRixHCsx = BitConverter.ToUInt32(A_0, A_1);
		}
		return result;
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x00017FDE File Offset: 0x000161DE
	public static uint tmJBmSBrPWymSLVVsslXcBfVrYLVA(qfbVmoiTxWecqFPlWHtxrqxyfhlkA A_0)
	{
		if (qfbVmoiTxWecqFPlWHtxrqxyfhlkA.HUHdCOIOnzekYphhVVRZTkcVkOVu)
		{
			return (uint)A_0.YZkpGphfgrPAhgikJZWVSxaSTvpg;
		}
		return A_0.mhLFnmEmjpXCTSxRHEeHCRixHCsx;
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x00017FF5 File Offset: 0x000161F5
	public static ulong tmJBmSBrPWymSLVVsslXcBfVrYLVA(qfbVmoiTxWecqFPlWHtxrqxyfhlkA A_0)
	{
		if (qfbVmoiTxWecqFPlWHtxrqxyfhlkA.HUHdCOIOnzekYphhVVRZTkcVkOVu)
		{
			return A_0.YZkpGphfgrPAhgikJZWVSxaSTvpg;
		}
		return (ulong)A_0.mhLFnmEmjpXCTSxRHEeHCRixHCsx;
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0001800C File Offset: 0x0001620C
	public string KfFEEyFxtlpVoWDdStENMApfiocp()
	{
		if (qfbVmoiTxWecqFPlWHtxrqxyfhlkA.HUHdCOIOnzekYphhVVRZTkcVkOVu)
		{
			return this.YZkpGphfgrPAhgikJZWVSxaSTvpg.ToString();
		}
		return this.mhLFnmEmjpXCTSxRHEeHCRixHCsx.ToString();
	}

	// Token: 0x04001576 RID: 5494
	private uint mhLFnmEmjpXCTSxRHEeHCRixHCsx;

	// Token: 0x04001577 RID: 5495
	private ulong YZkpGphfgrPAhgikJZWVSxaSTvpg;

	// Token: 0x04001578 RID: 5496
	private static readonly bool HUHdCOIOnzekYphhVVRZTkcVkOVu = IntPtr.Size == 8;

	// Token: 0x04001579 RID: 5497
	public static readonly int hMUBYcOvmveJfbvkbhYsPrHnHsBAb = qfbVmoiTxWecqFPlWHtxrqxyfhlkA.HUHdCOIOnzekYphhVVRZTkcVkOVu ? 8 : 4;
}
