using System;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000045 RID: 69
	public struct NetworkConfigParameter : INetworkParameter
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00008734 File Offset: 0x00006934
		public bool Validate()
		{
			bool flag = true;
			if (this.connectTimeoutMS < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "connectTimeoutMS", this.connectTimeoutMS));
			}
			if (this.maxConnectAttempts < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "maxConnectAttempts", this.maxConnectAttempts));
			}
			if (this.disconnectTimeoutMS < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "disconnectTimeoutMS", this.disconnectTimeoutMS));
			}
			if (this.heartbeatTimeoutMS < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "heartbeatTimeoutMS", this.heartbeatTimeoutMS));
			}
			if (this.maxFrameTimeMS < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "maxFrameTimeMS", this.maxFrameTimeMS));
			}
			if (this.fixedFrameTimeMS < 0)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "fixedFrameTimeMS", this.fixedFrameTimeMS));
			}
			if (this.maxMessageSize <= 0 || this.maxMessageSize > 1472)
			{
				flag = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater than 0 and less than or equal to {2}", "maxMessageSize", this.maxMessageSize, 1472));
			}
			if (flag && this.maxMessageSize < 548)
			{
				Debug.LogWarning(string.Format("{0} value ({1}) is unnecessarily low. 548 should be safe in all circumstances.", "maxMessageSize", this.maxMessageSize));
			}
			return flag;
		}

		// Token: 0x040000EB RID: 235
		public int connectTimeoutMS;

		// Token: 0x040000EC RID: 236
		public int maxConnectAttempts;

		// Token: 0x040000ED RID: 237
		public int disconnectTimeoutMS;

		// Token: 0x040000EE RID: 238
		public int heartbeatTimeoutMS;

		// Token: 0x040000EF RID: 239
		public int maxFrameTimeMS;

		// Token: 0x040000F0 RID: 240
		public int fixedFrameTimeMS;

		// Token: 0x040000F1 RID: 241
		public int maxMessageSize;
	}
}
