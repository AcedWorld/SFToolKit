using System;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000009 RID: 9
	public struct BaselibNetworkParameter : INetworkParameter
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002524 File Offset: 0x00000724
		public bool Validate()
		{
			bool result = true;
			if (this.receiveQueueCapacity <= 0)
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater than 0", "receiveQueueCapacity", this.receiveQueueCapacity));
			}
			if (this.sendQueueCapacity <= 0)
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater than 0", "sendQueueCapacity", this.sendQueueCapacity));
			}
			if (this.maximumPayloadSize <= 0U)
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater than 0", "maximumPayloadSize", this.maximumPayloadSize));
			}
			return result;
		}

		// Token: 0x0400000A RID: 10
		public int receiveQueueCapacity;

		// Token: 0x0400000B RID: 11
		public int sendQueueCapacity;

		// Token: 0x0400000C RID: 12
		public uint maximumPayloadSize;
	}
}
