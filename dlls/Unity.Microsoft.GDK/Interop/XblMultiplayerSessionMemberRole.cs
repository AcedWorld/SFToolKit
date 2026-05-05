using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000201 RID: 513
	internal struct XblMultiplayerSessionMemberRole
	{
		// Token: 0x06000DAC RID: 3500 RVA: 0x0001089A File Offset: 0x0000EA9A
		internal XblMultiplayerSessionMemberRole(XblMultiplayerSessionMemberRole publicObject, DisposableCollection disposableCollection)
		{
			this.roleTypeName = new UTF8StringPtr(publicObject.RoleTypeName, disposableCollection);
			this.roleName = new UTF8StringPtr(publicObject.RoleName, disposableCollection);
		}

		// Token: 0x040006F2 RID: 1778
		internal UTF8StringPtr roleTypeName;

		// Token: 0x040006F3 RID: 1779
		internal UTF8StringPtr roleName;
	}
}
