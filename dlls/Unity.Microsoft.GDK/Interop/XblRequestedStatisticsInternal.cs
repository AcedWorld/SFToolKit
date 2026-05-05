using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000235 RID: 565
	internal struct XblRequestedStatisticsInternal
	{
		// Token: 0x06000DE9 RID: 3561 RVA: 0x00011410 File Offset: 0x0000F610
		internal XblRequestedStatisticsInternal(XblRequestedStatistics requestedStatistics, DisposableCollection disposableCollection)
		{
			this.serviceConfigurationId = Converters.StringToNullTerminatedUTF8ByteArray(requestedStatistics.ServiceConfigurationId, 40);
			SizeT sizeT;
			this.statistics = Converters.StringArrayToUTF8StringArray(requestedStatistics.Statistics, disposableCollection, out sizeT);
			this.statisticsCount = sizeT.ToUInt32();
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00011451 File Offset: 0x0000F651
		internal static bool ValidateFields(string scid)
		{
			return scid != null && Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= 40;
		}

		// Token: 0x040007E2 RID: 2018
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		// Token: 0x040007E3 RID: 2019
		private readonly IntPtr statistics;

		// Token: 0x040007E4 RID: 2020
		private readonly uint statisticsCount;
	}
}
