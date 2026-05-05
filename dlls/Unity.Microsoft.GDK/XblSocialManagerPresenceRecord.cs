using System;
using System.Linq;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F8 RID: 248
	[MovedFrom("Unity.GameCore")]
	public class XblSocialManagerPresenceRecord
	{
		// Token: 0x06000678 RID: 1656 RVA: 0x0000BFC4 File Offset: 0x0000A1C4
		internal XblSocialManagerPresenceRecord(XblSocialManagerPresenceRecord interopRecord)
		{
			this.UserState = interopRecord.userState;
			this.PresenceTitleRecords = (from r in interopRecord.presenceTitleRecords.Where((XblSocialManagerPresenceTitleRecord r, int index) => index < (int)interopRecord.presenceTitleCount)
			select new XblSocialManagerPresenceTitleRecord(r)).ToArray<XblSocialManagerPresenceTitleRecord>();
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000C040 File Offset: 0x0000A240
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x0000C048 File Offset: 0x0000A248
		public XblPresenceUserState UserState { get; private set; }

		// Token: 0x040003E7 RID: 999
		public XblSocialManagerPresenceTitleRecord[] PresenceTitleRecords;
	}
}
