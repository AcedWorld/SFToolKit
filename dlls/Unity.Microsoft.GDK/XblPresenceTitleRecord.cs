using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D2 RID: 210
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceTitleRecord
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x0000B9CC File Offset: 0x00009BCC
		internal XblPresenceTitleRecord(XblPresenceTitleRecord interopRecord)
		{
			this.TitleId = interopRecord.titleId;
			this.TitleName = interopRecord.titleName.GetString();
			this.LastModified = interopRecord.lastModified.DateTime;
			this.TitleActive = interopRecord.titleActive;
			this.RichPresenceString = interopRecord.richPresenceString.GetString();
			this.ViewState = interopRecord.viewState;
			this.BroadcastRecord = interopRecord.GetBroadcastRecord<XblPresenceBroadcastRecord>((XblPresenceBroadcastRecord br) => new XblPresenceBroadcastRecord(br));
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0000BA6B File Offset: 0x00009C6B
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0000BA73 File Offset: 0x00009C73
		public uint TitleId { get; private set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000BA7C File Offset: 0x00009C7C
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000BA84 File Offset: 0x00009C84
		public string TitleName { get; private set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0000BA8D File Offset: 0x00009C8D
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x0000BA95 File Offset: 0x00009C95
		public DateTime LastModified { get; private set; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0000BA9E File Offset: 0x00009C9E
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x0000BAA6 File Offset: 0x00009CA6
		public bool TitleActive { get; private set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000BAAF File Offset: 0x00009CAF
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x0000BAB7 File Offset: 0x00009CB7
		public string RichPresenceString { get; private set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		// (set) Token: 0x060005FE RID: 1534 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		public XblPresenceTitleViewState ViewState { get; private set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x0000BAD1 File Offset: 0x00009CD1
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x0000BAD9 File Offset: 0x00009CD9
		public XblPresenceBroadcastRecord BroadcastRecord { get; private set; }
	}
}
