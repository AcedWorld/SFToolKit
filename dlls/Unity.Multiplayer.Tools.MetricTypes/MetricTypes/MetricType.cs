using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200000A RID: 10
	internal enum MetricType
	{
		// Token: 0x0400000B RID: 11
		None,
		// Token: 0x0400000C RID: 12
		TotalBytes,
		// Token: 0x0400000D RID: 13
		Rpc,
		// Token: 0x0400000E RID: 14
		NamedMessage,
		// Token: 0x0400000F RID: 15
		UnnamedMessage,
		// Token: 0x04000010 RID: 16
		NetworkVariableDelta,
		// Token: 0x04000011 RID: 17
		ObjectSpawned,
		// Token: 0x04000012 RID: 18
		ObjectDestroyed,
		// Token: 0x04000013 RID: 19
		OwnershipChange,
		// Token: 0x04000014 RID: 20
		ServerLog,
		// Token: 0x04000015 RID: 21
		SceneEvent,
		// Token: 0x04000016 RID: 22
		NetworkMessage,
		// Token: 0x04000017 RID: 23
		Packets,
		// Token: 0x04000018 RID: 24
		RttToServer,
		// Token: 0x04000019 RID: 25
		NetworkObjects,
		// Token: 0x0400001A RID: 26
		Connections,
		// Token: 0x0400001B RID: 27
		PacketLoss
	}
}
