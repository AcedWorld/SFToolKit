using System;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200000B RID: 11
	[MetricTypeEnum(DisplayName = "Built-In Metrics")]
	[MetricTypeSortPriority(SortPriority = SortPriority.VeryHigh)]
	public enum DirectedMetricType
	{
		// Token: 0x0400001D RID: 29
		[MetricMetadata(Units = Units.Bytes)]
		TotalBytesSent = 6,
		// Token: 0x0400001E RID: 30
		[MetricMetadata(Units = Units.Bytes)]
		TotalBytesReceived = 5,
		// Token: 0x0400001F RID: 31
		[MetricMetadata(DisplayName = "RPCs Sent")]
		RpcSent = 10,
		// Token: 0x04000020 RID: 32
		[MetricMetadata(DisplayName = "RPCs Received")]
		RpcReceived = 9,
		// Token: 0x04000021 RID: 33
		[MetricMetadata(DisplayName = "Named Messages Sent")]
		NamedMessageSent = 14,
		// Token: 0x04000022 RID: 34
		[MetricMetadata(DisplayName = "Named Messages Received")]
		NamedMessageReceived = 13,
		// Token: 0x04000023 RID: 35
		[MetricMetadata(DisplayName = "Unnamed Messages Sent")]
		UnnamedMessageSent = 18,
		// Token: 0x04000024 RID: 36
		[MetricMetadata(DisplayName = "Unnamed Messages Received")]
		UnnamedMessageReceived = 17,
		// Token: 0x04000025 RID: 37
		[MetricMetadata(DisplayName = "Network Variable Deltas Sent")]
		NetworkVariableDeltaSent = 22,
		// Token: 0x04000026 RID: 38
		[MetricMetadata(DisplayName = "Network Variable Deltas Received")]
		NetworkVariableDeltaReceived = 21,
		// Token: 0x04000027 RID: 39
		[MetricMetadata(DisplayName = "Objects Spawned Sent")]
		ObjectSpawnedSent = 26,
		// Token: 0x04000028 RID: 40
		[MetricMetadata(DisplayName = "Objects Spawned Received")]
		ObjectSpawnedReceived = 25,
		// Token: 0x04000029 RID: 41
		[MetricMetadata(DisplayName = "Objects Destroyed Sent")]
		ObjectDestroyedSent = 30,
		// Token: 0x0400002A RID: 42
		[MetricMetadata(DisplayName = "Objects Destroyed Received")]
		ObjectDestroyedReceived = 29,
		// Token: 0x0400002B RID: 43
		[MetricMetadata(DisplayName = "Ownership Changes Sent")]
		OwnershipChangeSent = 34,
		// Token: 0x0400002C RID: 44
		[MetricMetadata(DisplayName = "Ownership Changes Received")]
		OwnershipChangeReceived = 33,
		// Token: 0x0400002D RID: 45
		[MetricMetadata(DisplayName = "Server Logs Sent")]
		ServerLogSent = 38,
		// Token: 0x0400002E RID: 46
		[MetricMetadata(DisplayName = "Server Logs Received")]
		ServerLogReceived = 37,
		// Token: 0x0400002F RID: 47
		[MetricMetadata(DisplayName = "Scene Events Sent")]
		SceneEventSent = 42,
		// Token: 0x04000030 RID: 48
		[MetricMetadata(DisplayName = "Scene Events Received")]
		SceneEventReceived = 41,
		// Token: 0x04000031 RID: 49
		[MetricMetadata(DisplayName = "Network Messages Sent")]
		NetworkMessageSent = 46,
		// Token: 0x04000032 RID: 50
		[MetricMetadata(DisplayName = "Network Messages Received")]
		NetworkMessageReceived = 45,
		// Token: 0x04000033 RID: 51
		PacketsSent = 50,
		// Token: 0x04000034 RID: 52
		PacketsReceived = 49,
		// Token: 0x04000035 RID: 53
		[MetricMetadata(DisplayName = "RTT To Server", MetricKind = MetricKind.Gauge, Units = Units.Seconds)]
		RttToServer = 55,
		// Token: 0x04000036 RID: 54
		[MetricMetadata(MetricKind = MetricKind.Gauge)]
		NetworkObjects = 59,
		// Token: 0x04000037 RID: 55
		[MetricMetadata(MetricKind = MetricKind.Gauge)]
		Connections = 63,
		// Token: 0x04000038 RID: 56
		[MetricMetadata(MetricKind = MetricKind.Gauge, DisplayAsPercentage = true)]
		PacketLoss = 65
	}
}
