using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000030 RID: 48
	internal interface INetworkSerializable
	{
		// Token: 0x06000132 RID: 306
		void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter;
	}
}
