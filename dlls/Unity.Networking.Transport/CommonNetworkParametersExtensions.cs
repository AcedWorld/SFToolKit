using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000046 RID: 70
	public static class CommonNetworkParametersExtensions
	{
		// Token: 0x0600017F RID: 383 RVA: 0x000088B0 File Offset: 0x00006AB0
		[Obsolete("In Unity Transport 2.0, the data stream size will always be dynamically-sized and this API will be removed.")]
		public static ref NetworkSettings WithDataStreamParameters(this NetworkSettings settings, int size = 0)
		{
			NetworkDataStreamParameter networkDataStreamParameter = new NetworkDataStreamParameter
			{
				size = size
			};
			settings.AddRawParameterStruct<NetworkDataStreamParameter>(ref networkDataStreamParameter);
			return ref settings;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000088D8 File Offset: 0x00006AD8
		public static NetworkDataStreamParameter GetDataStreamParameters(this NetworkSettings settings)
		{
			NetworkDataStreamParameter result;
			if (!settings.TryGet<NetworkDataStreamParameter>(out result))
			{
				result.size = 0;
			}
			return result;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000088F8 File Offset: 0x00006AF8
		public static ref NetworkSettings WithNetworkConfigParameters(this NetworkSettings settings, int connectTimeoutMS = 1000, int maxConnectAttempts = 60, int disconnectTimeoutMS = 30000, int heartbeatTimeoutMS = 500, int maxFrameTimeMS = 0, int fixedFrameTimeMS = 0, int maxMessageSize = 1400)
		{
			NetworkConfigParameter networkConfigParameter = new NetworkConfigParameter
			{
				connectTimeoutMS = connectTimeoutMS,
				maxConnectAttempts = maxConnectAttempts,
				disconnectTimeoutMS = disconnectTimeoutMS,
				heartbeatTimeoutMS = heartbeatTimeoutMS,
				maxFrameTimeMS = maxFrameTimeMS,
				fixedFrameTimeMS = fixedFrameTimeMS,
				maxMessageSize = maxMessageSize
			};
			settings.AddRawParameterStruct<NetworkConfigParameter>(ref networkConfigParameter);
			return ref settings;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008954 File Offset: 0x00006B54
		public static ref NetworkSettings WithNetworkConfigParameters(this NetworkSettings settings, int connectTimeoutMS, int maxConnectAttempts, int disconnectTimeoutMS, int heartbeatTimeoutMS, int maxFrameTimeMS, int fixedFrameTimeMS)
		{
			NetworkConfigParameter networkConfigParameter = new NetworkConfigParameter
			{
				connectTimeoutMS = connectTimeoutMS,
				maxConnectAttempts = maxConnectAttempts,
				disconnectTimeoutMS = disconnectTimeoutMS,
				heartbeatTimeoutMS = heartbeatTimeoutMS,
				maxFrameTimeMS = maxFrameTimeMS,
				fixedFrameTimeMS = fixedFrameTimeMS,
				maxMessageSize = 1400
			};
			settings.AddRawParameterStruct<NetworkConfigParameter>(ref networkConfigParameter);
			return ref settings;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000089B4 File Offset: 0x00006BB4
		public static NetworkConfigParameter GetNetworkConfigParameters(this NetworkSettings settings)
		{
			NetworkConfigParameter result;
			if (!settings.TryGet<NetworkConfigParameter>(out result))
			{
				result.connectTimeoutMS = 1000;
				result.maxConnectAttempts = 60;
				result.disconnectTimeoutMS = 30000;
				result.heartbeatTimeoutMS = 500;
				result.maxFrameTimeMS = 0;
				result.fixedFrameTimeMS = 0;
				result.maxMessageSize = 1400;
			}
			return result;
		}
	}
}
