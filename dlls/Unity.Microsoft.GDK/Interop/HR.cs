using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C2 RID: 450
	public class HR
	{
		// Token: 0x06000A88 RID: 2696 RVA: 0x0000FD6C File Offset: 0x0000DF6C
		public static bool SUCCEEDED(int hr)
		{
			return hr >= 0;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0000FD75 File Offset: 0x0000DF75
		public static bool FAILED(int hr)
		{
			return hr < 0;
		}

		// Token: 0x040005DA RID: 1498
		public const int S_OK = 0;

		// Token: 0x040005DB RID: 1499
		public const int E_NOTIMPL = -2147467263;

		// Token: 0x040005DC RID: 1500
		public const int E_NOINTERFACE = -2147467262;

		// Token: 0x040005DD RID: 1501
		public const int E_POINTER = -2147467261;

		// Token: 0x040005DE RID: 1502
		public const int E_ABORT = -2147467260;

		// Token: 0x040005DF RID: 1503
		public const int E_ACCESSDENIED = -2147024891;

		// Token: 0x040005E0 RID: 1504
		public const int E_OUTOFMEMORY = -2147024882;

		// Token: 0x040005E1 RID: 1505
		public const int E_INVALIDARG = -2147024809;

		// Token: 0x040005E2 RID: 1506
		public const int E_PENDING = -2147483638;

		// Token: 0x040005E3 RID: 1507
		public const int E_UNEXPECTED = -2147418113;

		// Token: 0x040005E4 RID: 1508
		public const int E_NOT_SUPPORTED = -2147024846;

		// Token: 0x040005E5 RID: 1509
		public const int E_TIME_CRITICAL_THREAD = -2147024480;

		// Token: 0x040005E6 RID: 1510
		public const int E_NO_TASK_QUEUE = -2147024469;

		// Token: 0x040005E7 RID: 1511
		public const int E_NOT_SUFFICIENT_BUFFER = -2147024774;

		// Token: 0x040005E8 RID: 1512
		public const int E_BOUNDS = -2147483637;
	}
}
