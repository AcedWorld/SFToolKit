using System;
using Unity.Networking.Transport;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x0200012B RID: 299
	public interface INetworkStreamDriverConstructor
	{
		// Token: 0x06000964 RID: 2404
		void CreateDriver(UnityTransport transport, out NetworkDriver driver, out NetworkPipeline unreliableFragmentedPipeline, out NetworkPipeline unreliableSequencedFragmentedPipeline, out NetworkPipeline reliableSequencedPipeline);
	}
}
