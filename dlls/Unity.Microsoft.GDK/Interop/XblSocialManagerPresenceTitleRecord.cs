using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200022D RID: 557
	internal struct XblSocialManagerPresenceTitleRecord
	{
		// Token: 0x06000DE7 RID: 3559 RVA: 0x0001135C File Offset: 0x0000F55C
		internal XblSocialManagerPresenceTitleRecord(XblSocialManagerPresenceTitleRecord titleRecord)
		{
			this.titleId = titleRecord.TitleId;
			this.titleName = Converters.StringToNullTerminatedUTF8ByteArray(titleRecord.TitleName, 300);
			this.isTitleActive = titleRecord.IsTitleActive;
			this.presenceText = Converters.StringToNullTerminatedUTF8ByteArray(titleRecord.PresenceText, 300);
			this.isBroadcasting = titleRecord.IsBroadcasting;
			this.deviceType = titleRecord.DeviceType;
			this.isPrimary = titleRecord.IsPrimary;
		}

		// Token: 0x040007B8 RID: 1976
		internal readonly uint titleId;

		// Token: 0x040007B9 RID: 1977
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
		internal readonly byte[] titleName;

		// Token: 0x040007BA RID: 1978
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isTitleActive;

		// Token: 0x040007BB RID: 1979
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
		internal readonly byte[] presenceText;

		// Token: 0x040007BC RID: 1980
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isBroadcasting;

		// Token: 0x040007BD RID: 1981
		internal readonly XblPresenceDeviceType deviceType;

		// Token: 0x040007BE RID: 1982
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isPrimary;
	}
}
