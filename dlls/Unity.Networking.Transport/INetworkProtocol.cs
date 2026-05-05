using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000059 RID: 89
	internal interface INetworkProtocol : IDisposable
	{
		// Token: 0x060001B8 RID: 440
		void Initialize(NetworkSettings settings);

		// Token: 0x060001B9 RID: 441
		NetworkProtocol CreateProtocolInterface();

		// Token: 0x060001BA RID: 442
		int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint);

		// Token: 0x060001BB RID: 443
		int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint endPoint, out NetworkInterfaceEndPoint address);

		// Token: 0x060001BC RID: 444
		NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address);
	}
}
