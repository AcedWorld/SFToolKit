using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000DA RID: 218
	[MovedFrom("Unity.GameCore")]
	public class XblPermissionDenyReasonDetails
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0000BBB0 File Offset: 0x00009DB0
		internal XblPermissionDenyReasonDetails(XblPermissionDenyReasonDetails interopStruct)
		{
			this.Reason = interopStruct.reason;
			this.RestrictedPrivilege = interopStruct.restrictedPrivilege;
			this.RestrictedPrivacySetting = interopStruct.restrictedPrivacySetting;
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x0000BBDC File Offset: 0x00009DDC
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x0000BBE4 File Offset: 0x00009DE4
		public XblPermissionDenyReason Reason { get; private set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0000BBED File Offset: 0x00009DED
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x0000BBF5 File Offset: 0x00009DF5
		public XblPrivilege RestrictedPrivilege { get; private set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0000BBFE File Offset: 0x00009DFE
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x0000BC06 File Offset: 0x00009E06
		public XblPrivacySetting RestrictedPrivacySetting { get; private set; }
	}
}
