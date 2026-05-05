using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000239 RID: 569
	internal struct XblUserStatisticsResultInternal
	{
		// Token: 0x06000DEC RID: 3564 RVA: 0x0001147B File Offset: 0x0000F67B
		internal T[] GetServiceConfigStatistics<T>(Func<XblServiceConfigurationStatisticInternal, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblServiceConfigurationStatisticInternal>(this.serviceConfigStatistics, this.serviceConfigStatisticsCount, ctor);
		}

		// Token: 0x040007EE RID: 2030
		internal readonly ulong xboxUserId;

		// Token: 0x040007EF RID: 2031
		private readonly IntPtr serviceConfigStatistics;

		// Token: 0x040007F0 RID: 2032
		private readonly uint serviceConfigStatisticsCount;
	}
}
