using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000FA RID: 250
	[MovedFrom("Unity.GameCore")]
	public class XblSocialManagerUser
	{
		// Token: 0x0600068A RID: 1674 RVA: 0x0000C13C File Offset: 0x0000A33C
		internal XblSocialManagerUser(XblSocialManagerUser interopUser)
		{
			this.XboxUserId = interopUser.xboxUserId;
			this.IsFavorite = interopUser.isFavorite;
			this.IsFollowingUser = interopUser.isFollowingUser;
			this.IsFollowedByCaller = interopUser.isFollowedByCaller;
			this.DisplayName = Converters.ByteArrayToString(interopUser.displayName);
			this.RealName = Converters.ByteArrayToString(interopUser.realName);
			this.DisplayPicUrlRaw = Converters.ByteArrayToString(interopUser.displayPicUrlRaw);
			this.UseAvatar = interopUser.useAvatar;
			this.Gamerscore = Converters.ByteArrayToString(interopUser.gamerscore);
			this.Gamertag = Converters.ByteArrayToString(interopUser.gamertag);
			this.ModernGamertag = Converters.ByteArrayToString(interopUser.modernGamertag);
			this.ModernGamertagSuffix = Converters.ByteArrayToString(interopUser.modernGamertagSuffix);
			this.UniqueModernGamertag = Converters.ByteArrayToString(interopUser.uniqueModernGamertag);
			this.PresenceRecord = new XblSocialManagerPresenceRecord(interopUser.presenceRecord);
			this.TitleHistory = new XblTitleHistory(interopUser.titleHistory);
			this.PreferredColor = new XblPreferredColor(interopUser.preferredColor);
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000C246 File Offset: 0x0000A446
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x0000C24E File Offset: 0x0000A44E
		public ulong XboxUserId { get; private set; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000C257 File Offset: 0x0000A457
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x0000C25F File Offset: 0x0000A45F
		public bool IsFavorite { get; private set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x0000C268 File Offset: 0x0000A468
		// (set) Token: 0x06000690 RID: 1680 RVA: 0x0000C270 File Offset: 0x0000A470
		public bool IsFollowingUser { get; private set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000C279 File Offset: 0x0000A479
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x0000C281 File Offset: 0x0000A481
		public bool IsFollowedByCaller { get; private set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0000C28A File Offset: 0x0000A48A
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x0000C292 File Offset: 0x0000A492
		public string DisplayName { get; private set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0000C29B File Offset: 0x0000A49B
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x0000C2A3 File Offset: 0x0000A4A3
		public string RealName { get; private set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0000C2AC File Offset: 0x0000A4AC
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x0000C2B4 File Offset: 0x0000A4B4
		public string DisplayPicUrlRaw { get; private set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000C2BD File Offset: 0x0000A4BD
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x0000C2C5 File Offset: 0x0000A4C5
		public bool UseAvatar { get; private set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000C2CE File Offset: 0x0000A4CE
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x0000C2D6 File Offset: 0x0000A4D6
		public string Gamerscore { get; private set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0000C2DF File Offset: 0x0000A4DF
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x0000C2E7 File Offset: 0x0000A4E7
		public string Gamertag { get; private set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
		public string ModernGamertag { get; private set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x0000C301 File Offset: 0x0000A501
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x0000C309 File Offset: 0x0000A509
		public string ModernGamertagSuffix { get; private set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0000C312 File Offset: 0x0000A512
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x0000C31A File Offset: 0x0000A51A
		public string UniqueModernGamertag { get; private set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0000C323 File Offset: 0x0000A523
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0000C32B File Offset: 0x0000A52B
		public XblSocialManagerPresenceRecord PresenceRecord { get; private set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0000C334 File Offset: 0x0000A534
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0000C33C File Offset: 0x0000A53C
		public XblTitleHistory TitleHistory { get; private set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0000C345 File Offset: 0x0000A545
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0000C34D File Offset: 0x0000A54D
		public XblPreferredColor PreferredColor { get; private set; }
	}
}
