using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000213 RID: 531
	internal struct XblMultiplayerPerformQoSMeasurementsArgs
	{
		// Token: 0x06000DC4 RID: 3524 RVA: 0x00010E3A File Offset: 0x0000F03A
		internal unsafe T[] GetRemoteClients<T>(Func<XblMultiplayerConnectionAddressDeviceTokenPair, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblMultiplayerConnectionAddressDeviceTokenPair>((IntPtr)((void*)this.remoteClients), this.remoteClientsSize, ctor);
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00010E53 File Offset: 0x0000F053
		internal unsafe XblMultiplayerPerformQoSMeasurementsArgs(XblMultiplayerPerformQoSMeasurementsArgs publicObject, DisposableCollection disposableCollection)
		{
			this.remoteClients = (XblMultiplayerConnectionAddressDeviceTokenPair*)((void*)Converters.ClassArrayToPtr<XblMultiplayerConnectionAddressDeviceTokenPair, XblMultiplayerConnectionAddressDeviceTokenPair>(publicObject.RemoteClients, (XblMultiplayerConnectionAddressDeviceTokenPair x, DisposableCollection dc) => new XblMultiplayerConnectionAddressDeviceTokenPair(x, dc), disposableCollection, out this.remoteClientsSize));
		}

		// Token: 0x04000749 RID: 1865
		private unsafe readonly XblMultiplayerConnectionAddressDeviceTokenPair* remoteClients;

		// Token: 0x0400074A RID: 1866
		internal readonly SizeT remoteClientsSize;
	}
}
