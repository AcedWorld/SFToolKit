using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001AA RID: 426
	public class XUserDeviceAssociationChange
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
		internal XUserDeviceAssociationChange(XUserDeviceAssociationChange interop)
		{
			this._deviceId = new APP_LOCAL_DEVICE_ID(interop.deviceId);
			this._oldUser = new XUserLocalId(interop.oldUser);
			this._newUser = new XUserLocalId(interop.newUser);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0000F32B File Offset: 0x0000D52B
		public XUserDeviceAssociationChange()
		{
			this._oldUser = new XUserLocalId();
			this._newUser = new XUserLocalId();
			this._deviceId = new APP_LOCAL_DEVICE_ID();
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x0000F354 File Offset: 0x0000D554
		// (set) Token: 0x060009FB RID: 2555 RVA: 0x0000F35C File Offset: 0x0000D55C
		public APP_LOCAL_DEVICE_ID DeviceId
		{
			get
			{
				return this._deviceId;
			}
			set
			{
				this._deviceId = value;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x0000F365 File Offset: 0x0000D565
		// (set) Token: 0x060009FD RID: 2557 RVA: 0x0000F36D File Offset: 0x0000D56D
		public XUserLocalId OldUser
		{
			get
			{
				return this._oldUser;
			}
			set
			{
				this._oldUser = value;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x0000F376 File Offset: 0x0000D576
		// (set) Token: 0x060009FF RID: 2559 RVA: 0x0000F37E File Offset: 0x0000D57E
		public XUserLocalId NewUser
		{
			get
			{
				return this._newUser;
			}
			set
			{
				this._newUser = value;
			}
		}

		// Token: 0x040005CA RID: 1482
		internal APP_LOCAL_DEVICE_ID _deviceId;

		// Token: 0x040005CB RID: 1483
		internal XUserLocalId _oldUser;

		// Token: 0x040005CC RID: 1484
		internal XUserLocalId _newUser;
	}
}
