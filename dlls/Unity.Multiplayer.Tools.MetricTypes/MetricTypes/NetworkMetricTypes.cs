using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000011 RID: 17
	internal static class NetworkMetricTypes
	{
		// Token: 0x04000046 RID: 70
		public static readonly DirectionalMetricInfo NetworkMessageSent = new DirectionalMetricInfo(DirectedMetricType.NetworkMessageSent);

		// Token: 0x04000047 RID: 71
		public static readonly DirectionalMetricInfo NetworkMessageReceived = new DirectionalMetricInfo(DirectedMetricType.NetworkMessageReceived);

		// Token: 0x04000048 RID: 72
		public static readonly DirectionalMetricInfo TotalBytesSent = new DirectionalMetricInfo(DirectedMetricType.TotalBytesSent);

		// Token: 0x04000049 RID: 73
		public static readonly DirectionalMetricInfo TotalBytesReceived = new DirectionalMetricInfo(DirectedMetricType.TotalBytesReceived);

		// Token: 0x0400004A RID: 74
		public static readonly DirectionalMetricInfo RpcSent = new DirectionalMetricInfo(DirectedMetricType.RpcSent);

		// Token: 0x0400004B RID: 75
		public static readonly DirectionalMetricInfo RpcReceived = new DirectionalMetricInfo(DirectedMetricType.RpcReceived);

		// Token: 0x0400004C RID: 76
		public static readonly DirectionalMetricInfo NamedMessageSent = new DirectionalMetricInfo(DirectedMetricType.NamedMessageSent);

		// Token: 0x0400004D RID: 77
		public static readonly DirectionalMetricInfo NamedMessageReceived = new DirectionalMetricInfo(DirectedMetricType.NamedMessageReceived);

		// Token: 0x0400004E RID: 78
		public static readonly DirectionalMetricInfo UnnamedMessageSent = new DirectionalMetricInfo(DirectedMetricType.UnnamedMessageSent);

		// Token: 0x0400004F RID: 79
		public static readonly DirectionalMetricInfo UnnamedMessageReceived = new DirectionalMetricInfo(DirectedMetricType.UnnamedMessageReceived);

		// Token: 0x04000050 RID: 80
		public static readonly DirectionalMetricInfo NetworkVariableDeltaSent = new DirectionalMetricInfo(DirectedMetricType.NetworkVariableDeltaSent);

		// Token: 0x04000051 RID: 81
		public static readonly DirectionalMetricInfo NetworkVariableDeltaReceived = new DirectionalMetricInfo(DirectedMetricType.NetworkVariableDeltaReceived);

		// Token: 0x04000052 RID: 82
		public static readonly DirectionalMetricInfo ObjectSpawnedSent = new DirectionalMetricInfo(DirectedMetricType.ObjectSpawnedSent);

		// Token: 0x04000053 RID: 83
		public static readonly DirectionalMetricInfo ObjectSpawnedReceived = new DirectionalMetricInfo(DirectedMetricType.ObjectSpawnedReceived);

		// Token: 0x04000054 RID: 84
		public static readonly DirectionalMetricInfo ObjectDestroyedSent = new DirectionalMetricInfo(DirectedMetricType.ObjectDestroyedSent);

		// Token: 0x04000055 RID: 85
		public static readonly DirectionalMetricInfo ObjectDestroyedReceived = new DirectionalMetricInfo(DirectedMetricType.ObjectDestroyedReceived);

		// Token: 0x04000056 RID: 86
		public static readonly DirectionalMetricInfo OwnershipChangeSent = new DirectionalMetricInfo(DirectedMetricType.OwnershipChangeSent);

		// Token: 0x04000057 RID: 87
		public static readonly DirectionalMetricInfo OwnershipChangeReceived = new DirectionalMetricInfo(DirectedMetricType.OwnershipChangeReceived);

		// Token: 0x04000058 RID: 88
		public static readonly DirectionalMetricInfo ServerLogSent = new DirectionalMetricInfo(DirectedMetricType.ServerLogSent);

		// Token: 0x04000059 RID: 89
		public static readonly DirectionalMetricInfo ServerLogReceived = new DirectionalMetricInfo(DirectedMetricType.ServerLogReceived);

		// Token: 0x0400005A RID: 90
		public static readonly DirectionalMetricInfo SceneEventSent = new DirectionalMetricInfo(DirectedMetricType.SceneEventSent);

		// Token: 0x0400005B RID: 91
		public static readonly DirectionalMetricInfo SceneEventReceived = new DirectionalMetricInfo(DirectedMetricType.SceneEventReceived);

		// Token: 0x0400005C RID: 92
		public static readonly DirectionalMetricInfo PacketsSent = new DirectionalMetricInfo(DirectedMetricType.PacketsSent);

		// Token: 0x0400005D RID: 93
		public static readonly DirectionalMetricInfo PacketsReceived = new DirectionalMetricInfo(DirectedMetricType.PacketsReceived);

		// Token: 0x0400005E RID: 94
		public static readonly DirectionalMetricInfo RttToServer = new DirectionalMetricInfo(DirectedMetricType.RttToServer);

		// Token: 0x0400005F RID: 95
		public static readonly DirectionalMetricInfo NetworkObjects = new DirectionalMetricInfo(DirectedMetricType.NetworkObjects);

		// Token: 0x04000060 RID: 96
		public static readonly DirectionalMetricInfo ConnectedClients = new DirectionalMetricInfo(DirectedMetricType.Connections);

		// Token: 0x04000061 RID: 97
		public static readonly DirectionalMetricInfo PacketLoss = new DirectionalMetricInfo(DirectedMetricType.PacketLoss);
	}
}
