using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000053 RID: 83
	public static class NetworkPipelineParametersExtensions
	{
		// Token: 0x0600019E RID: 414 RVA: 0x00008C80 File Offset: 0x00006E80
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static ref NetworkSettings WithPipelineParameters(this NetworkSettings settings, int initialCapacity = 0)
		{
			NetworkPipelineParams networkPipelineParams = new NetworkPipelineParams
			{
				initialCapacity = initialCapacity
			};
			settings.AddRawParameterStruct<NetworkPipelineParams>(ref networkPipelineParams);
			return ref settings;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00008CA8 File Offset: 0x00006EA8
		public static NetworkPipelineParams GetPipelineParameters(this NetworkSettings settings)
		{
			NetworkPipelineParams result;
			if (!settings.TryGet<NetworkPipelineParams>(out result))
			{
				result.initialCapacity = 0;
			}
			return result;
		}
	}
}
