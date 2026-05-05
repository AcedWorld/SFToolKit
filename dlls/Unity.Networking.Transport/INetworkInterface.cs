using System;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Networking.Transport
{
	// Token: 0x0200001F RID: 31
	public interface INetworkInterface : IDisposable
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000B3 RID: 179
		NetworkInterfaceEndPoint LocalEndPoint { get; }

		// Token: 0x060000B4 RID: 180
		int Initialize(NetworkSettings settings);

		// Token: 0x060000B5 RID: 181
		JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep);

		// Token: 0x060000B6 RID: 182
		JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep);

		// Token: 0x060000B7 RID: 183
		int Bind(NetworkInterfaceEndPoint endpoint);

		// Token: 0x060000B8 RID: 184
		int Listen();

		// Token: 0x060000B9 RID: 185
		NetworkSendInterface CreateSendInterface();

		// Token: 0x060000BA RID: 186
		int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint);

		// Token: 0x060000BB RID: 187
		NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint);
	}
}
