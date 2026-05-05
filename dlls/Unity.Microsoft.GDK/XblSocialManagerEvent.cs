using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F5 RID: 245
	[MovedFrom("Unity.GameCore")]
	public class XblSocialManagerEvent
	{
		// Token: 0x0600066D RID: 1645 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		internal XblSocialManagerEvent(XblSocialManagerEvent interopEvent)
		{
			this.User = new XUserHandle(interopEvent.user, false);
			this.EventType = interopEvent.eventType;
			this.Hr = interopEvent.hr;
			this.LoadedGroup = new XblSocialManagerUserGroupHandle(interopEvent.loadedGroup);
			this.UsersAffected = Array.ConvertAll<XblSocialManagerUser, XblSocialManagerUser>(interopEvent.GetUserArray(), (XblSocialManagerUser u) => new XblSocialManagerUser(u));
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0000BF6F File Offset: 0x0000A16F
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x0000BF77 File Offset: 0x0000A177
		public XUserHandle User { get; private set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0000BF80 File Offset: 0x0000A180
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x0000BF88 File Offset: 0x0000A188
		public XblSocialManagerEventType EventType { get; private set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0000BF91 File Offset: 0x0000A191
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x0000BF99 File Offset: 0x0000A199
		public int Hr { get; private set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000BFA2 File Offset: 0x0000A1A2
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0000BFAA File Offset: 0x0000A1AA
		public XblSocialManagerUserGroupHandle LoadedGroup { get; private set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x0000BFB3 File Offset: 0x0000A1B3
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x0000BFBB File Offset: 0x0000A1BB
		public XblSocialManagerUser[] UsersAffected { get; private set; }
	}
}
