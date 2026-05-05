using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200029F RID: 671
	public struct XblRequestedStatistics
	{
		// Token: 0x040008DB RID: 2267
		[FixedBuffer(typeof(sbyte), 40)]
		public XblRequestedStatistics.<serviceConfigurationId>e__FixedBuffer serviceConfigurationId;

		// Token: 0x040008DC RID: 2268
		public unsafe sbyte** statistics;

		// Token: 0x040008DD RID: 2269
		public uint statisticsCount;

		// Token: 0x02000348 RID: 840
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <serviceConfigurationId>e__FixedBuffer
		{
			// Token: 0x040009C8 RID: 2504
			public sbyte FixedElementField;
		}
	}
}
