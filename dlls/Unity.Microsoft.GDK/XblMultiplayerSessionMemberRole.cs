using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000098 RID: 152
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionMemberRole
	{
		// Token: 0x0600050A RID: 1290 RVA: 0x0000A975 File Offset: 0x00008B75
		internal XblMultiplayerSessionMemberRole(XblMultiplayerSessionMemberRole interopHandle)
		{
			this.InteropHandle = interopHandle;
			this.RoleTypeName = interopHandle.roleTypeName.GetString();
			this.RoleName = interopHandle.roleName.GetString();
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0000A9A8 File Offset: 0x00008BA8
		public string RoleTypeName { get; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		public string RoleName { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0000A9B8 File Offset: 0x00008BB8
		internal XblMultiplayerSessionMemberRole InteropHandle { get; }
	}
}
