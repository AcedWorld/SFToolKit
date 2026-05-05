using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D8 RID: 216
	[MovedFrom("Unity.GameCore")]
	public class XblPermissionCheckResult
	{
		// Token: 0x06000601 RID: 1537 RVA: 0x0000BAE4 File Offset: 0x00009CE4
		internal XblPermissionCheckResult(XblPermissionCheckResult interopStruct)
		{
			this.IsAllowed = interopStruct.isAllowed.Value;
			this.TargetXuid = interopStruct.targetXuid;
			this.TargetUserType = interopStruct.targetUserType;
			this.PermissionRequested = interopStruct.permissionRequested;
			this.Reasons = interopStruct.GetReasons<XblPermissionDenyReasonDetails>((XblPermissionDenyReasonDetails x) => new XblPermissionDenyReasonDetails(x));
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0000BB5B File Offset: 0x00009D5B
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x0000BB63 File Offset: 0x00009D63
		public bool IsAllowed { get; private set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0000BB6C File Offset: 0x00009D6C
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x0000BB74 File Offset: 0x00009D74
		public ulong TargetXuid { get; private set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x0000BB7D File Offset: 0x00009D7D
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x0000BB85 File Offset: 0x00009D85
		public XblAnonymousUserType TargetUserType { get; private set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x0000BB8E File Offset: 0x00009D8E
		// (set) Token: 0x06000609 RID: 1545 RVA: 0x0000BB96 File Offset: 0x00009D96
		public XblPermission PermissionRequested { get; private set; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x0000BB9F File Offset: 0x00009D9F
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x0000BBA7 File Offset: 0x00009DA7
		public XblPermissionDenyReasonDetails[] Reasons { get; private set; }
	}
}
