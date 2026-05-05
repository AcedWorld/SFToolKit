using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000223 RID: 547
	internal struct XblPermissionDenyReasonDetails
	{
		// Token: 0x06000DDF RID: 3551 RVA: 0x00011245 File Offset: 0x0000F445
		internal XblPermissionDenyReasonDetails(XblPermissionDenyReasonDetails publicObject)
		{
			this.reason = publicObject.Reason;
			this.restrictedPrivilege = publicObject.RestrictedPrivilege;
			this.restrictedPrivacySetting = publicObject.RestrictedPrivacySetting;
		}

		// Token: 0x04000795 RID: 1941
		internal readonly XblPermissionDenyReason reason;

		// Token: 0x04000796 RID: 1942
		internal readonly XblPrivilege restrictedPrivilege;

		// Token: 0x04000797 RID: 1943
		internal readonly XblPrivacySetting restrictedPrivacySetting;
	}
}
