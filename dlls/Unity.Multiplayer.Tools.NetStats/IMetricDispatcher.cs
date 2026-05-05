using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000005 RID: 5
	internal interface IMetricDispatcher
	{
		// Token: 0x06000005 RID: 5
		void RegisterObserver(IMetricObserver observer);

		// Token: 0x06000006 RID: 6
		void SetConnectionId(ulong connectionId);

		// Token: 0x06000007 RID: 7
		void Dispatch();
	}
}
