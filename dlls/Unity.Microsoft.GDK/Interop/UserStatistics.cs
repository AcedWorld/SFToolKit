using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200029E RID: 670
	public static class UserStatistics
	{
		// Token: 0x06000EA2 RID: 3746
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
		public unsafe static extern int XblUserStatisticsAddStatisticChangedHandler(IntPtr xblContextHandle, XblStatisticChangedHandler handler, void* handlerContext);

		// Token: 0x06000EA3 RID: 3747
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
		public static extern void XblUserStatisticsRemoveStatisticChangedHandler(IntPtr xblContextHandle, int context);

		// Token: 0x06000EA4 RID: 3748
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
		public unsafe static extern int XblUserStatisticsTrackStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

		// Token: 0x06000EA5 RID: 3749
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
		public unsafe static extern int XblUserStatisticsStopTrackingStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

		// Token: 0x06000EA6 RID: 3750
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
		public unsafe static extern int XblUserStatisticsStopTrackingUsers(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount);
	}
}
