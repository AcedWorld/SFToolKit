using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A3 RID: 675
	public struct XblStatisticChangeEventArgs
	{
		// Token: 0x040008E4 RID: 2276
		public ulong xboxUserId;

		// Token: 0x040008E5 RID: 2277
		[FixedBuffer(typeof(sbyte), 40)]
		public XblStatisticChangeEventArgs.<serviceConfigurationId>e__FixedBuffer serviceConfigurationId;

		// Token: 0x040008E6 RID: 2278
		public XblStatistic latestStatistic;

		// Token: 0x0200034A RID: 842
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <serviceConfigurationId>e__FixedBuffer
		{
			// Token: 0x040009CA RID: 2506
			public sbyte FixedElementField;
		}
	}
}
