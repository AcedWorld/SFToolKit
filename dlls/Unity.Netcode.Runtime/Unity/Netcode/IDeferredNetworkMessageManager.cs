using System;

namespace Unity.Netcode
{
	// Token: 0x02000056 RID: 86
	internal interface IDeferredNetworkMessageManager
	{
		// Token: 0x06000242 RID: 578
		void DeferMessage(IDeferredNetworkMessageManager.TriggerType trigger, ulong key, FastBufferReader reader, ref NetworkContext context);

		// Token: 0x06000243 RID: 579
		void CleanupStaleTriggers();

		// Token: 0x06000244 RID: 580
		void ProcessTriggers(IDeferredNetworkMessageManager.TriggerType trigger, ulong key);

		// Token: 0x06000245 RID: 581
		void CleanupAllTriggers();

		// Token: 0x02000057 RID: 87
		internal enum TriggerType
		{
			// Token: 0x0400012F RID: 303
			OnSpawn,
			// Token: 0x04000130 RID: 304
			OnAddPrefab,
			// Token: 0x04000131 RID: 305
			OnNextFrame
		}
	}
}
