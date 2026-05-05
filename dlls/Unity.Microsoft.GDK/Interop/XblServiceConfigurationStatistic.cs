using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A0 RID: 672
	public struct XblServiceConfigurationStatistic
	{
		// Token: 0x040008DE RID: 2270
		[FixedBuffer(typeof(sbyte), 40)]
		public XblServiceConfigurationStatistic.<serviceConfigurationId>e__FixedBuffer serviceConfigurationId;

		// Token: 0x040008DF RID: 2271
		public unsafe XblStatistic* statistics;

		// Token: 0x040008E0 RID: 2272
		public uint statisticsCount;

		// Token: 0x02000349 RID: 841
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <serviceConfigurationId>e__FixedBuffer
		{
			// Token: 0x040009C9 RID: 2505
			public sbyte FixedElementField;
		}
	}
}
