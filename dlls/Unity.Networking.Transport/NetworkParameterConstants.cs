using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000043 RID: 67
	public struct NetworkParameterConstants
	{
		// Token: 0x040000DF RID: 223
		public const int InitialEventQueueSize = 100;

		// Token: 0x040000E0 RID: 224
		public const int InvalidConnectionId = -1;

		// Token: 0x040000E1 RID: 225
		public const int DriverDataStreamSize = 65536;

		// Token: 0x040000E2 RID: 226
		public const int ConnectTimeoutMS = 1000;

		// Token: 0x040000E3 RID: 227
		public const int MaxConnectAttempts = 60;

		// Token: 0x040000E4 RID: 228
		public const int DisconnectTimeoutMS = 30000;

		// Token: 0x040000E5 RID: 229
		public const int HeartbeatTimeoutMS = 500;

		// Token: 0x040000E6 RID: 230
		public const int MaxMessageSize = 1400;

		// Token: 0x040000E7 RID: 231
		public const int MTU = 1400;

		// Token: 0x040000E8 RID: 232
		internal const int MaxPacketBufferSize = 1472;
	}
}
