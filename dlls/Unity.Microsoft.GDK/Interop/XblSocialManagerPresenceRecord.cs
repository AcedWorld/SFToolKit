using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200022C RID: 556
	internal struct XblSocialManagerPresenceRecord
	{
		// Token: 0x06000DE6 RID: 3558 RVA: 0x000112FC File Offset: 0x0000F4FC
		internal XblSocialManagerPresenceRecord(XblSocialManagerPresenceRecord presenceRecord)
		{
			this.userState = presenceRecord.UserState;
			this.presenceTitleRecords = Converters.ConvertArrayToFixedLength<XblSocialManagerPresenceTitleRecord, XblSocialManagerPresenceTitleRecord>(presenceRecord.PresenceTitleRecords, 6, (XblSocialManagerPresenceTitleRecord r) => new XblSocialManagerPresenceTitleRecord(r));
			this.presenceTitleCount = Convert.ToUInt32(this.presenceTitleRecords.Length);
		}

		// Token: 0x040007B5 RID: 1973
		internal readonly XblPresenceUserState userState;

		// Token: 0x040007B6 RID: 1974
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		internal readonly XblSocialManagerPresenceTitleRecord[] presenceTitleRecords;

		// Token: 0x040007B7 RID: 1975
		internal readonly uint presenceTitleCount;
	}
}
