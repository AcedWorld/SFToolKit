using System;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200009C RID: 156
	public struct RelayNetworkParameter : INetworkParameter
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		public bool Validate()
		{
			bool result = true;
			if (this.ServerData.Endpoint == default(NetworkEndPoint))
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be a valid value", "Endpoint", this.ServerData.Endpoint));
			}
			if (this.ServerData.AllocationId == default(RelayAllocationId))
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be a valid value", "AllocationId", this.ServerData.AllocationId));
			}
			if (this.RelayConnectionTimeMS < 0)
			{
				result = false;
				Debug.LogError(string.Format("{0} value({1}) must be greater or equal to 0", "RelayConnectionTimeMS", this.RelayConnectionTimeMS));
			}
			return result;
		}

		// Token: 0x040001FE RID: 510
		internal const int k_DefaultConnectionTimeMS = 3000;

		// Token: 0x040001FF RID: 511
		public RelayServerData ServerData;

		// Token: 0x04000200 RID: 512
		public int RelayConnectionTimeMS;
	}
}
