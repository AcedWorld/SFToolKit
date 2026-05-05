using System;

namespace Unity.Networking.Transport
{
	// Token: 0x0200004A RID: 74
	public interface INetworkPipelineStage
	{
		// Token: 0x06000186 RID: 390
		unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings);

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000187 RID: 391
		int StaticSize { get; }
	}
}
