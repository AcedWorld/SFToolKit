using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000008 RID: 8
	public static class BaselibNetworkParameterExtensions
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000024B4 File Offset: 0x000006B4
		public static ref NetworkSettings WithBaselibNetworkInterfaceParameters(this NetworkSettings settings, int receiveQueueCapacity = 64, int sendQueueCapacity = 64, uint maximumPayloadSize = 2000U)
		{
			BaselibNetworkParameter baselibNetworkParameter = new BaselibNetworkParameter
			{
				receiveQueueCapacity = receiveQueueCapacity,
				sendQueueCapacity = sendQueueCapacity,
				maximumPayloadSize = maximumPayloadSize
			};
			settings.AddRawParameterStruct<BaselibNetworkParameter>(ref baselibNetworkParameter);
			return ref settings;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024EC File Offset: 0x000006EC
		public static BaselibNetworkParameter GetBaselibNetworkInterfaceParameters(this NetworkSettings settings)
		{
			BaselibNetworkParameter result;
			if (!settings.TryGet<BaselibNetworkParameter>(out result))
			{
				result.receiveQueueCapacity = 64;
				result.sendQueueCapacity = 64;
				result.maximumPayloadSize = 2000U;
			}
			return result;
		}

		// Token: 0x04000007 RID: 7
		internal const int k_defaultRxQueueSize = 64;

		// Token: 0x04000008 RID: 8
		internal const int k_defaultTxQueueSize = 64;

		// Token: 0x04000009 RID: 9
		internal const uint k_defaultMaximumPayloadSize = 2000U;
	}
}
