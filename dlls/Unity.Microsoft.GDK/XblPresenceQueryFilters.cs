using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000CF RID: 207
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceQueryFilters
	{
		// Token: 0x060005DA RID: 1498 RVA: 0x0000B873 File Offset: 0x00009A73
		private XblPresenceQueryFilters(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly)
		{
			this.DeviceTypes = deviceTypes;
			this.TitleIds = titleIds;
			this.DetailLevel = detailLevel;
			this.OnlineOnly = onlineOnly;
			this.BroadcastingOnly = broadcastingOnly;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0000B8A0 File Offset: 0x00009AA0
		public static int Create(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly, out XblPresenceQueryFilters queryFilters)
		{
			queryFilters = new XblPresenceQueryFilters(deviceTypes, titleIds, detailLevel, onlineOnly, broadcastingOnly);
			return 0;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x0000B8B1 File Offset: 0x00009AB1
		// (set) Token: 0x060005DD RID: 1501 RVA: 0x0000B8B9 File Offset: 0x00009AB9
		public XblPresenceDeviceType[] DeviceTypes { get; private set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x0000B8C2 File Offset: 0x00009AC2
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x0000B8CA File Offset: 0x00009ACA
		public uint[] TitleIds { get; private set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x0000B8D3 File Offset: 0x00009AD3
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x0000B8DB File Offset: 0x00009ADB
		public XblPresenceDetailLevel DetailLevel { get; private set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0000B8E4 File Offset: 0x00009AE4
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x0000B8EC File Offset: 0x00009AEC
		public bool OnlineOnly { get; private set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x0000B8F5 File Offset: 0x00009AF5
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x0000B8FD File Offset: 0x00009AFD
		public bool BroadcastingOnly { get; private set; }
	}
}
