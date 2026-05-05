using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000018 RID: 24
	[Serializable]
	internal struct SceneEventMetric : INetworkMetricEvent
	{
		// Token: 0x06000048 RID: 72 RVA: 0x00002637 File Offset: 0x00000837
		public SceneEventMetric(ConnectionInfo connection, string sceneEventType, string sceneName, long bytesCount)
		{
			this = new SceneEventMetric(connection, StringConversionUtility.ConvertToFixedString(sceneEventType), StringConversionUtility.ConvertToFixedString(sceneName), bytesCount);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000264E File Offset: 0x0000084E
		public SceneEventMetric(ConnectionInfo connection, FixedString64Bytes sceneEventType, FixedString64Bytes sceneName, long bytesCount)
		{
			this.Connection = connection;
			this.SceneEventType = sceneEventType;
			this.SceneName = sceneName;
			this.BytesCount = bytesCount;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004A RID: 74 RVA: 0x0000266D File Offset: 0x0000086D
		public readonly ConnectionInfo Connection { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002675 File Offset: 0x00000875
		public readonly FixedString64Bytes SceneEventType { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000267D File Offset: 0x0000087D
		public readonly FixedString64Bytes SceneName { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002685 File Offset: 0x00000885
		public readonly long BytesCount { get; }
	}
}
