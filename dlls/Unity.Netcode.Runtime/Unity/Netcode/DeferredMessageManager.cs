using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x02000050 RID: 80
	internal class DeferredMessageManager : IDeferredNetworkMessageManager
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0000BA36 File Offset: 0x00009C36
		internal DeferredMessageManager(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000BA50 File Offset: 0x00009C50
		public virtual void DeferMessage(IDeferredNetworkMessageManager.TriggerType trigger, ulong key, FastBufferReader reader, ref NetworkContext context)
		{
			Dictionary<ulong, DeferredMessageManager.TriggerInfo> dictionary;
			if (!this.m_Triggers.TryGetValue(trigger, out dictionary))
			{
				dictionary = new Dictionary<ulong, DeferredMessageManager.TriggerInfo>();
				this.m_Triggers[trigger] = dictionary;
			}
			DeferredMessageManager.TriggerInfo value;
			if (!dictionary.TryGetValue(key, out value))
			{
				value = new DeferredMessageManager.TriggerInfo
				{
					Expiry = this.m_NetworkManager.RealTimeProvider.RealTimeSinceStartup + this.m_NetworkManager.NetworkConfig.SpawnTimeout,
					TriggerData = new NativeList<DeferredMessageManager.TriggerData>(Allocator.Persistent)
				};
				dictionary[key] = value;
			}
			DeferredMessageManager.TriggerData triggerData = default(DeferredMessageManager.TriggerData);
			triggerData.Reader = new FastBufferReader(reader.GetUnsafePtr(), Allocator.Persistent, reader.Length, 0, Allocator.Temp);
			triggerData.Header = context.Header;
			triggerData.Timestamp = context.Timestamp;
			triggerData.SenderId = context.SenderId;
			triggerData.SerializedHeaderSize = context.SerializedHeaderSize;
			value.TriggerData.Add(triggerData);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000BB44 File Offset: 0x00009D44
		public unsafe virtual void CleanupStaleTriggers()
		{
			foreach (KeyValuePair<IDeferredNetworkMessageManager.TriggerType, Dictionary<ulong, DeferredMessageManager.TriggerInfo>> keyValuePair in this.m_Triggers)
			{
				ulong* ptr = stackalloc ulong[checked(unchecked((UIntPtr)keyValuePair.Value.Count) * 8)];
				int num = 0;
				foreach (KeyValuePair<ulong, DeferredMessageManager.TriggerInfo> keyValuePair2 in keyValuePair.Value)
				{
					if (keyValuePair2.Value.Expiry < this.m_NetworkManager.RealTimeProvider.RealTimeSinceStartup)
					{
						ptr[(IntPtr)(num++) * 8] = keyValuePair2.Key;
						this.PurgeTrigger(keyValuePair.Key, keyValuePair2.Key, keyValuePair2.Value);
					}
				}
				for (int i = 0; i < num; i++)
				{
					keyValuePair.Value.Remove(ptr[i]);
				}
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000BC58 File Offset: 0x00009E58
		protected virtual void PurgeTrigger(IDeferredNetworkMessageManager.TriggerType triggerType, ulong key, DeferredMessageManager.TriggerInfo triggerInfo)
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning(string.Format("Deferred messages were received for a trigger of type {0} with key {1}, but that trigger was not received within within {2} second(s).", triggerType, key, this.m_NetworkManager.NetworkConfig.SpawnTimeout));
			}
			foreach (DeferredMessageManager.TriggerData triggerData in triggerInfo.TriggerData)
			{
				FastBufferReader reader = triggerData.Reader;
				reader.Dispose();
			}
			triggerInfo.TriggerData.Dispose();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000BCF8 File Offset: 0x00009EF8
		public virtual void ProcessTriggers(IDeferredNetworkMessageManager.TriggerType trigger, ulong key)
		{
			Dictionary<ulong, DeferredMessageManager.TriggerInfo> dictionary;
			DeferredMessageManager.TriggerInfo triggerInfo;
			if (this.m_Triggers.TryGetValue(trigger, out dictionary) && dictionary.TryGetValue(key, out triggerInfo))
			{
				dictionary.Remove(key);
				foreach (DeferredMessageManager.TriggerData triggerData in triggerInfo.TriggerData)
				{
					this.m_NetworkManager.ConnectionManager.MessageManager.HandleMessage(triggerData.Header, triggerData.Reader, triggerData.SenderId, triggerData.Timestamp, triggerData.SerializedHeaderSize);
				}
				triggerInfo.TriggerData.Dispose();
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000BDAC File Offset: 0x00009FAC
		public virtual void CleanupAllTriggers()
		{
			foreach (KeyValuePair<IDeferredNetworkMessageManager.TriggerType, Dictionary<ulong, DeferredMessageManager.TriggerInfo>> keyValuePair in this.m_Triggers)
			{
				foreach (KeyValuePair<ulong, DeferredMessageManager.TriggerInfo> keyValuePair2 in keyValuePair.Value)
				{
					DeferredMessageManager.TriggerInfo value = keyValuePair2.Value;
					foreach (DeferredMessageManager.TriggerData triggerData in value.TriggerData)
					{
						FastBufferReader reader = triggerData.Reader;
						reader.Dispose();
					}
					value = keyValuePair2.Value;
					value.TriggerData.Dispose();
				}
			}
			this.m_Triggers.Clear();
		}

		// Token: 0x04000122 RID: 290
		protected readonly Dictionary<IDeferredNetworkMessageManager.TriggerType, Dictionary<ulong, DeferredMessageManager.TriggerInfo>> m_Triggers = new Dictionary<IDeferredNetworkMessageManager.TriggerType, Dictionary<ulong, DeferredMessageManager.TriggerInfo>>();

		// Token: 0x04000123 RID: 291
		private readonly NetworkManager m_NetworkManager;

		// Token: 0x02000051 RID: 81
		protected struct TriggerData
		{
			// Token: 0x04000124 RID: 292
			public FastBufferReader Reader;

			// Token: 0x04000125 RID: 293
			public NetworkMessageHeader Header;

			// Token: 0x04000126 RID: 294
			public ulong SenderId;

			// Token: 0x04000127 RID: 295
			public float Timestamp;

			// Token: 0x04000128 RID: 296
			public int SerializedHeaderSize;
		}

		// Token: 0x02000052 RID: 82
		protected struct TriggerInfo
		{
			// Token: 0x04000129 RID: 297
			public float Expiry;

			// Token: 0x0400012A RID: 298
			public NativeList<DeferredMessageManager.TriggerData> TriggerData;
		}
	}
}
