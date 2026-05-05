using System;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000092 RID: 146
	public static class NetworkDriverRelayExtensions
	{
		// Token: 0x06000277 RID: 631 RVA: 0x0000DB8D File Offset: 0x0000BD8D
		public static RelayConnectionStatus GetRelayConnectionStatus(this NetworkDriver driver)
		{
			if (driver.NetworkProtocol is RelayNetworkProtocol)
			{
				return (RelayConnectionStatus)driver.ProtocolStatus;
			}
			return RelayConnectionStatus.NotUsingRelay;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000DBA8 File Offset: 0x0000BDA8
		public static NetworkConnection Connect(this NetworkDriver driver)
		{
			if (driver.NetworkProtocol is RelayNetworkProtocol)
			{
				return driver.Connect(default(NetworkEndPoint));
			}
			Debug.LogError("Can't call Connect without an endpoint when not using the Relay.");
			return default(NetworkConnection);
		}
	}
}
