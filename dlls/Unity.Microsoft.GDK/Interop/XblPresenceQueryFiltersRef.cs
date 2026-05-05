using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200021E RID: 542
	[StructLayout(LayoutKind.Sequential)]
	internal class XblPresenceQueryFiltersRef
	{
		// Token: 0x06000DDA RID: 3546 RVA: 0x00011110 File Offset: 0x0000F310
		internal XblPresenceQueryFiltersRef(XblPresenceQueryFilters filters, DisposableCollection disposableCollection)
		{
			this.deviceTypes = Converters.ClassArrayToPtr<XblPresenceDeviceType, XblPresenceDeviceType>(filters.DeviceTypes, (XblPresenceDeviceType dt, DisposableCollection _) => dt, disposableCollection, out this.deviceTypesCount);
			this.titleIds = Converters.ClassArrayToPtr<uint, uint>(filters.TitleIds, (uint titleId, DisposableCollection _) => titleId, disposableCollection, out this.titleIdsCount);
			this.detailLevel = filters.DetailLevel;
			this.onlineOnly = filters.OnlineOnly;
			this.broadcastingOnly = filters.BroadcastingOnly;
		}

		// Token: 0x0400077C RID: 1916
		private readonly IntPtr deviceTypes;

		// Token: 0x0400077D RID: 1917
		private readonly SizeT deviceTypesCount;

		// Token: 0x0400077E RID: 1918
		private readonly IntPtr titleIds;

		// Token: 0x0400077F RID: 1919
		private readonly SizeT titleIdsCount;

		// Token: 0x04000780 RID: 1920
		internal readonly XblPresenceDetailLevel detailLevel;

		// Token: 0x04000781 RID: 1921
		[MarshalAs(UnmanagedType.U1)]
		internal bool onlineOnly;

		// Token: 0x04000782 RID: 1922
		[MarshalAs(UnmanagedType.U1)]
		internal bool broadcastingOnly;
	}
}
