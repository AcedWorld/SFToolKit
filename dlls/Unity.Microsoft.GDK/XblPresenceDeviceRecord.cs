using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000CC RID: 204
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceDeviceRecord
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x0000B811 File Offset: 0x00009A11
		internal XblPresenceDeviceRecord(XblPresenceDeviceRecord interopRecord)
		{
			this.DeviceType = interopRecord.deviceType;
			this.TitleRecords = interopRecord.GetTitleRecords<XblPresenceTitleRecord>((XblPresenceTitleRecord tr) => new XblPresenceTitleRecord(tr));
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0000B851 File Offset: 0x00009A51
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x0000B859 File Offset: 0x00009A59
		public XblPresenceDeviceType DeviceType { get; private set; }

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x0000B862 File Offset: 0x00009A62
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x0000B86A File Offset: 0x00009A6A
		public XblPresenceTitleRecord[] TitleRecords { get; private set; }
	}
}
