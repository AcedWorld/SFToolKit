using System;

namespace Unity.Netcode
{
	// Token: 0x0200010B RID: 267
	public interface INetworkSerializable
	{
		// Token: 0x0600083C RID: 2108
		void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter;
	}
}
