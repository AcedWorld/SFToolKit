using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200009B RID: 155
	public static class RelayParameterExtensions
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000DE54 File Offset: 0x0000C054
		public static ref NetworkSettings WithRelayParameters(this NetworkSettings settings, ref RelayServerData serverData, int relayConnectionTimeMS = 3000)
		{
			RelayNetworkParameter relayNetworkParameter = new RelayNetworkParameter
			{
				ServerData = serverData,
				RelayConnectionTimeMS = relayConnectionTimeMS
			};
			settings.AddRawParameterStruct<RelayNetworkParameter>(ref relayNetworkParameter);
			return ref settings;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000DE8C File Offset: 0x0000C08C
		public static RelayNetworkParameter GetRelayParameters(this NetworkSettings settings)
		{
			RelayNetworkParameter result;
			if (!settings.TryGet<RelayNetworkParameter>(out result))
			{
				throw new InvalidOperationException("Can't extract Relay parameters: RelayNetworkParameter must be provided to the NetworkSettings");
			}
			return result;
		}
	}
}
