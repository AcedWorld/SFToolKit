using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000E4 RID: 228
	[MovedFrom("Unity.GameCore")]
	public class XblUserProfile
	{
		// Token: 0x0600062F RID: 1583 RVA: 0x0000BC10 File Offset: 0x00009E10
		internal XblUserProfile(XblUserProfile interopStruct)
		{
			this.XboxUserId = interopStruct.xboxUserId;
			this.AppDisplayName = Converters.ByteArrayToString(interopStruct.appDisplayName);
			this.AppDisplayPictureResizeUri = Converters.ByteArrayToString(interopStruct.appDisplayPictureResizeUri);
			this.GameDisplayName = Converters.ByteArrayToString(interopStruct.gameDisplayName);
			this.GameDisplayPictureResizeUri = Converters.ByteArrayToString(interopStruct.gameDisplayPictureResizeUri);
			this.Gamerscore = Converters.ByteArrayToString(interopStruct.gamerscore);
			this.Gamertag = Converters.ByteArrayToString(interopStruct.gamertag);
			this.ModernGamertag = Converters.ByteArrayToString(interopStruct.modernGamertag);
			this.ModernGamertagSuffix = Converters.ByteArrayToString(interopStruct.modernGamertagSuffix);
			this.UniqueModernGamertag = Converters.ByteArrayToString(interopStruct.uniqueModernGamertag);
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x0000BCC8 File Offset: 0x00009EC8
		// (set) Token: 0x06000631 RID: 1585 RVA: 0x0000BCD0 File Offset: 0x00009ED0
		public ulong XboxUserId { get; private set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0000BCD9 File Offset: 0x00009ED9
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x0000BCE1 File Offset: 0x00009EE1
		public string AppDisplayName { get; private set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x0000BCEA File Offset: 0x00009EEA
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public string AppDisplayPictureResizeUri { get; private set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x0000BCFB File Offset: 0x00009EFB
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x0000BD03 File Offset: 0x00009F03
		public string GameDisplayName { get; private set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0000BD0C File Offset: 0x00009F0C
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x0000BD14 File Offset: 0x00009F14
		public string GameDisplayPictureResizeUri { get; private set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0000BD1D File Offset: 0x00009F1D
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x0000BD25 File Offset: 0x00009F25
		public string Gamerscore { get; private set; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0000BD2E File Offset: 0x00009F2E
		// (set) Token: 0x0600063D RID: 1597 RVA: 0x0000BD36 File Offset: 0x00009F36
		public string Gamertag { get; private set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000BD3F File Offset: 0x00009F3F
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x0000BD47 File Offset: 0x00009F47
		public string ModernGamertag { get; private set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000BD50 File Offset: 0x00009F50
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x0000BD58 File Offset: 0x00009F58
		public string ModernGamertagSuffix { get; private set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000BD61 File Offset: 0x00009F61
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x0000BD69 File Offset: 0x00009F69
		public string UniqueModernGamertag { get; private set; }
	}
}
