using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200020C RID: 524
	internal struct XblMultiplayerConnectionAddressDeviceTokenPair
	{
		// Token: 0x06000DBF RID: 3519 RVA: 0x00010CA9 File Offset: 0x0000EEA9
		internal XblMultiplayerConnectionAddressDeviceTokenPair(XblMultiplayerConnectionAddressDeviceTokenPair publicObject, DisposableCollection disposableCollection)
		{
			this.connectionAddress = new UTF8StringPtr(publicObject.ConnectionAddress, disposableCollection);
			this.deviceToken = new XblDeviceToken(publicObject.DeviceToken);
		}

		// Token: 0x04000729 RID: 1833
		internal readonly UTF8StringPtr connectionAddress;

		// Token: 0x0400072A RID: 1834
		internal readonly XblDeviceToken deviceToken;
	}
}
