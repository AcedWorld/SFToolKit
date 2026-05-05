using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AC RID: 172
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerConnectionAddressDeviceTokenPair
	{
		// Token: 0x06000561 RID: 1377 RVA: 0x0000AF00 File Offset: 0x00009100
		internal XblMultiplayerConnectionAddressDeviceTokenPair(XblMultiplayerConnectionAddressDeviceTokenPair interopStruct)
		{
			this.ConnectionAddress = interopStruct.connectionAddress.GetString();
			this.DeviceToken = new XblDeviceToken(interopStruct.deviceToken);
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0000AF38 File Offset: 0x00009138
		public string ConnectionAddress { get; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0000AF40 File Offset: 0x00009140
		public XblDeviceToken DeviceToken { get; }
	}
}
