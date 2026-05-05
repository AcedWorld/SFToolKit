using System;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x0200003E RID: 62
	internal struct NetworkEventQueue : IDisposable
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00008189 File Offset: 0x00006389
		private int MaxEvents
		{
			get
			{
				return this.m_ConnectionEventQ.Length / (this.m_ConnectionEventHeadTail.Length / 2);
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000081A4 File Offset: 0x000063A4
		public NetworkEventQueue(int queueSizePerConnection)
		{
			this.m_MasterEventQ = new NativeQueue<NetworkEventQueue.SubQueueItem>(Allocator.Persistent);
			this.m_ConnectionEventQ = new NativeList<NetworkEvent>(queueSizePerConnection, Allocator.Persistent);
			this.m_ConnectionEventHeadTail = new NativeList<int>(2, Allocator.Persistent);
			this.m_ConnectionEventQ.ResizeUninitialized(queueSizePerConnection);
			int num = 0;
			this.m_ConnectionEventHeadTail.Add(num);
			num = 0;
			this.m_ConnectionEventHeadTail.Add(num);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00008210 File Offset: 0x00006410
		public void Dispose()
		{
			this.m_MasterEventQ.Dispose();
			this.m_ConnectionEventQ.Dispose();
			this.m_ConnectionEventHeadTail.Dispose();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00008234 File Offset: 0x00006434
		public NetworkEvent.Type PopEvent(out int id, out int offset, out int size)
		{
			int num;
			return this.PopEvent(out id, out offset, out size, out num);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000824C File Offset: 0x0000644C
		public NetworkEvent.Type PopEvent(out int id, out int offset, out int size, out int pipelineId)
		{
			offset = 0;
			size = 0;
			id = -1;
			pipelineId = 0;
			NetworkEventQueue.SubQueueItem subQueueItem;
			while (this.m_MasterEventQ.TryDequeue(out subQueueItem))
			{
				if (this.m_ConnectionEventHeadTail[subQueueItem.connection * 2] == subQueueItem.idx)
				{
					id = subQueueItem.connection;
					return this.PopEventForConnection(subQueueItem.connection, out offset, out size, out pipelineId);
				}
			}
			return NetworkEvent.Type.Empty;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000082AC File Offset: 0x000064AC
		public NetworkEvent.Type PopEventForConnection(int connectionId, out int offset, out int size)
		{
			int num;
			return this.PopEventForConnection(connectionId, out offset, out size, out num);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000082C4 File Offset: 0x000064C4
		public NetworkEvent.Type PopEventForConnection(int connectionId, out int offset, out int size, out int pipelineId)
		{
			offset = 0;
			size = 0;
			pipelineId = 0;
			if (connectionId < 0 || connectionId >= this.m_ConnectionEventHeadTail.Length / 2)
			{
				return NetworkEvent.Type.Empty;
			}
			int num = this.m_ConnectionEventHeadTail[connectionId * 2];
			if (num >= this.m_ConnectionEventHeadTail[connectionId * 2 + 1])
			{
				return NetworkEvent.Type.Empty;
			}
			this.m_ConnectionEventHeadTail[connectionId * 2] = num + 1;
			NetworkEvent networkEvent = this.m_ConnectionEventQ[connectionId * this.MaxEvents + num];
			pipelineId = (int)networkEvent.pipelineId;
			if (networkEvent.type == NetworkEvent.Type.Data)
			{
				offset = networkEvent.offset;
				size = networkEvent.size;
			}
			else if (networkEvent.type == NetworkEvent.Type.Disconnect && networkEvent.status != 0)
			{
				offset = -networkEvent.status;
			}
			return networkEvent.type;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00008380 File Offset: 0x00006580
		public int GetCountForConnection(int connectionId)
		{
			if (connectionId < 0 || connectionId >= this.m_ConnectionEventHeadTail.Length / 2)
			{
				return 0;
			}
			return this.m_ConnectionEventHeadTail[connectionId * 2 + 1] - this.m_ConnectionEventHeadTail[connectionId * 2];
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000083B8 File Offset: 0x000065B8
		public void PushEvent(NetworkEvent ev)
		{
			int num = this.MaxEvents;
			if (ev.connectionId >= this.m_ConnectionEventHeadTail.Length / 2)
			{
				int i = this.m_ConnectionEventHeadTail.Length;
				this.m_ConnectionEventHeadTail.ResizeUninitialized((ev.connectionId + 1) * 2);
				while (i < this.m_ConnectionEventHeadTail.Length)
				{
					this.m_ConnectionEventHeadTail[i] = 0;
					i++;
				}
				this.m_ConnectionEventQ.ResizeUninitialized(this.m_ConnectionEventHeadTail.Length / 2 * num);
			}
			int j = this.m_ConnectionEventHeadTail[ev.connectionId * 2 + 1];
			if (j >= num)
			{
				int num2 = num;
				while (j >= num)
				{
					num *= 2;
				}
				int num3 = this.m_ConnectionEventHeadTail.Length / 2;
				this.m_ConnectionEventQ.ResizeUninitialized(num3 * num);
				for (int k = num3 - 1; k >= 0; k--)
				{
					for (int l = this.m_ConnectionEventHeadTail[k * 2 + 1] - 1; l >= this.m_ConnectionEventHeadTail[k * 2]; l--)
					{
						this.m_ConnectionEventQ[k * num + l] = this.m_ConnectionEventQ[k * num2 + l];
					}
				}
			}
			this.m_ConnectionEventQ[ev.connectionId * num + j] = ev;
			this.m_ConnectionEventHeadTail[ev.connectionId * 2 + 1] = j + 1;
			this.m_MasterEventQ.Enqueue(new NetworkEventQueue.SubQueueItem
			{
				connection = ev.connectionId,
				idx = j
			});
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008544 File Offset: 0x00006744
		internal void Clear()
		{
			this.m_MasterEventQ.Clear();
			for (int i = 0; i < this.m_ConnectionEventHeadTail.Length; i++)
			{
				this.m_ConnectionEventHeadTail[i] = 0;
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00008580 File Offset: 0x00006780
		public NetworkEventQueue.Concurrent ToConcurrent()
		{
			NetworkEventQueue.Concurrent result;
			result.m_ConnectionEventQ = this.m_ConnectionEventQ;
			result.m_ConnectionEventHeadTail = new NetworkEventQueue.Concurrent.ConcurrentConnectionQueue(this.m_ConnectionEventHeadTail);
			return result;
		}

		// Token: 0x040000D7 RID: 215
		private NativeQueue<NetworkEventQueue.SubQueueItem> m_MasterEventQ;

		// Token: 0x040000D8 RID: 216
		private NativeList<NetworkEvent> m_ConnectionEventQ;

		// Token: 0x040000D9 RID: 217
		private NativeList<int> m_ConnectionEventHeadTail;

		// Token: 0x0200003F RID: 63
		private struct SubQueueItem
		{
			// Token: 0x040000DA RID: 218
			public int connection;

			// Token: 0x040000DB RID: 219
			public int idx;
		}

		// Token: 0x02000040 RID: 64
		public struct Concurrent
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000176 RID: 374 RVA: 0x000085AD File Offset: 0x000067AD
			private int MaxEvents
			{
				get
				{
					return this.m_ConnectionEventQ.Length / (this.m_ConnectionEventHeadTail.Length / 2);
				}
			}

			// Token: 0x06000177 RID: 375 RVA: 0x000085C8 File Offset: 0x000067C8
			public NetworkEvent.Type PopEventForConnection(int connectionId, out int offset, out int size)
			{
				int num;
				return this.PopEventForConnection(connectionId, out offset, out size, out num);
			}

			// Token: 0x06000178 RID: 376 RVA: 0x000085E0 File Offset: 0x000067E0
			public NetworkEvent.Type PopEventForConnection(int connectionId, out int offset, out int size, out int pipelineId)
			{
				offset = 0;
				size = 0;
				pipelineId = 0;
				int num = this.m_ConnectionEventHeadTail.Dequeue(connectionId);
				if (num < 0)
				{
					return NetworkEvent.Type.Empty;
				}
				NetworkEvent networkEvent = this.m_ConnectionEventQ[connectionId * this.MaxEvents + num];
				pipelineId = (int)networkEvent.pipelineId;
				if (networkEvent.type == NetworkEvent.Type.Data)
				{
					offset = networkEvent.offset;
					size = networkEvent.size;
				}
				else if (networkEvent.type == NetworkEvent.Type.Disconnect && networkEvent.status != 0)
				{
					offset = -networkEvent.status;
				}
				return networkEvent.type;
			}

			// Token: 0x040000DC RID: 220
			[ReadOnly]
			internal NativeList<NetworkEvent> m_ConnectionEventQ;

			// Token: 0x040000DD RID: 221
			internal NetworkEventQueue.Concurrent.ConcurrentConnectionQueue m_ConnectionEventHeadTail;

			// Token: 0x02000041 RID: 65
			[NativeContainer]
			[NativeContainerIsAtomicWriteOnly]
			internal struct ConcurrentConnectionQueue
			{
				// Token: 0x06000179 RID: 377 RVA: 0x00008664 File Offset: 0x00006864
				public unsafe ConcurrentConnectionQueue(NativeList<int> queue)
				{
					this.m_ConnectionEventHeadTail = (UnsafeList<int>*)NativeListUnsafeUtility.GetInternalListDataPtrUnchecked<int>(ref queue);
				}

				// Token: 0x1700002F RID: 47
				// (get) Token: 0x0600017A RID: 378 RVA: 0x00008673 File Offset: 0x00006873
				public unsafe int Length
				{
					get
					{
						return this.m_ConnectionEventHeadTail->Length;
					}
				}

				// Token: 0x0600017B RID: 379 RVA: 0x00008680 File Offset: 0x00006880
				public unsafe int Dequeue(int connectionId)
				{
					int i = -1;
					if (connectionId < 0 || connectionId >= this.m_ConnectionEventHeadTail->Length / 2)
					{
						return -1;
					}
					while (i < 0)
					{
						i = this.m_ConnectionEventHeadTail->Ptr[connectionId * 2];
						if (i >= this.m_ConnectionEventHeadTail->Ptr[connectionId * 2 + 1])
						{
							return -1;
						}
						if (Interlocked.CompareExchange(ref this.m_ConnectionEventHeadTail->Ptr[connectionId * 2], i + 1, i) != i)
						{
							i = -1;
						}
					}
					return i;
				}

				// Token: 0x040000DE RID: 222
				[NativeDisableUnsafePtrRestriction]
				private unsafe UnsafeList<int>* m_ConnectionEventHeadTail;
			}
		}
	}
}
