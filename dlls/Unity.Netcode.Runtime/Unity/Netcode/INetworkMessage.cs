using System;

namespace Unity.Netcode
{
	// Token: 0x0200005A RID: 90
	internal interface INetworkMessage
	{
		// Token: 0x06000254 RID: 596
		void Serialize(FastBufferWriter writer, int targetVersion);

		// Token: 0x06000255 RID: 597
		bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion);

		// Token: 0x06000256 RID: 598
		void Handle(ref NetworkContext context);

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000257 RID: 599
		int Version { get; }
	}
}
