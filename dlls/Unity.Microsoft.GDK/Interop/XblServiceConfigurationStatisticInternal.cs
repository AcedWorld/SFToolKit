using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000236 RID: 566
	internal struct XblServiceConfigurationStatisticInternal
	{
		// Token: 0x06000DEB RID: 3563 RVA: 0x00011467 File Offset: 0x0000F667
		internal T[] GetStatistics<T>(Func<XblStatisticInternal, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblStatisticInternal>(this.statistics, this.statisticsCount, ctor);
		}

		// Token: 0x040007E5 RID: 2021
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		// Token: 0x040007E6 RID: 2022
		private readonly IntPtr statistics;

		// Token: 0x040007E7 RID: 2023
		private readonly uint statisticsCount;
	}
}
