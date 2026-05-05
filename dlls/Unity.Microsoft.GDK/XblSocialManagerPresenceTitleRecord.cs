using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F9 RID: 249
	[MovedFrom("Unity.GameCore")]
	public class XblSocialManagerPresenceTitleRecord
	{
		// Token: 0x0600067B RID: 1659 RVA: 0x0000C054 File Offset: 0x0000A254
		internal XblSocialManagerPresenceTitleRecord(XblSocialManagerPresenceTitleRecord interopRecord)
		{
			this.TitleId = interopRecord.titleId;
			this.TitleName = Converters.ByteArrayToString(interopRecord.titleName);
			this.IsTitleActive = interopRecord.isTitleActive;
			this.PresenceText = Converters.ByteArrayToString(interopRecord.presenceText);
			this.IsBroadcasting = interopRecord.isBroadcasting;
			this.DeviceType = interopRecord.deviceType;
			this.IsPrimary = interopRecord.isPrimary;
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x0000C0C5 File Offset: 0x0000A2C5
		// (set) Token: 0x0600067D RID: 1661 RVA: 0x0000C0CD File Offset: 0x0000A2CD
		public uint TitleId { get; private set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0000C0D6 File Offset: 0x0000A2D6
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x0000C0DE File Offset: 0x0000A2DE
		public string TitleName { get; private set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x0000C0E7 File Offset: 0x0000A2E7
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x0000C0EF File Offset: 0x0000A2EF
		public bool IsTitleActive { get; private set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x0000C100 File Offset: 0x0000A300
		public string PresenceText { get; private set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0000C109 File Offset: 0x0000A309
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x0000C111 File Offset: 0x0000A311
		public bool IsBroadcasting { get; private set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x0000C11A File Offset: 0x0000A31A
		// (set) Token: 0x06000687 RID: 1671 RVA: 0x0000C122 File Offset: 0x0000A322
		public XblPresenceDeviceType DeviceType { get; private set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000C12B File Offset: 0x0000A32B
		// (set) Token: 0x06000689 RID: 1673 RVA: 0x0000C133 File Offset: 0x0000A333
		public bool IsPrimary { get; private set; }
	}
}
