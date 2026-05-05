using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000214 RID: 532
	internal struct XblMultiplayerSessionCapabilities
	{
		// Token: 0x06000DC6 RID: 3526 RVA: 0x00010E94 File Offset: 0x0000F094
		internal XblMultiplayerSessionCapabilities(XblMultiplayerSessionCapabilities publicObject)
		{
			this.Connectivity = new NativeBool(publicObject.Connectivity);
			this.Team = new NativeBool(publicObject.Team);
			this.Arbitration = new NativeBool(publicObject.Arbitration);
			this.SuppressPresenceActivityCheck = new NativeBool(publicObject.SuppressPresenceActivityCheck);
			this.Gameplay = new NativeBool(publicObject.Gameplay);
			this.Large = new NativeBool(publicObject.Large);
			this.ConnectionRequiredForActiveMembers = new NativeBool(publicObject.ConnectionRequiredForActiveMembers);
			this.UserAuthorizationStyle = new NativeBool(publicObject.UserAuthorizationStyle);
			this.Crossplay = new NativeBool(publicObject.Crossplay);
			this.Searchable = new NativeBool(publicObject.Searchable);
			this.HasOwners = new NativeBool(publicObject.HasOwners);
		}

		// Token: 0x0400074B RID: 1867
		internal readonly NativeBool Connectivity;

		// Token: 0x0400074C RID: 1868
		internal readonly NativeBool Team;

		// Token: 0x0400074D RID: 1869
		internal readonly NativeBool Arbitration;

		// Token: 0x0400074E RID: 1870
		internal readonly NativeBool SuppressPresenceActivityCheck;

		// Token: 0x0400074F RID: 1871
		internal readonly NativeBool Gameplay;

		// Token: 0x04000750 RID: 1872
		internal readonly NativeBool Large;

		// Token: 0x04000751 RID: 1873
		internal readonly NativeBool ConnectionRequiredForActiveMembers;

		// Token: 0x04000752 RID: 1874
		internal readonly NativeBool UserAuthorizationStyle;

		// Token: 0x04000753 RID: 1875
		internal readonly NativeBool Crossplay;

		// Token: 0x04000754 RID: 1876
		internal readonly NativeBool Searchable;

		// Token: 0x04000755 RID: 1877
		internal readonly NativeBool HasOwners;
	}
}
