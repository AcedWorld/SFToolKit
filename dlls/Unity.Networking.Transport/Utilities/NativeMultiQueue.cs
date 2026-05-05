using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C5 RID: 197
	internal struct NativeMultiQueue<[IsUnmanaged] T> : IDisposable where T : struct, ValueType
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00010BD0 File Offset: 0x0000EDD0
		public bool IsCreated
		{
			get
			{
				return this.m_Queue.IsCreated;
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00010BE0 File Offset: 0x0000EDE0
		public NativeMultiQueue(int initialMessageCapacity)
		{
			this.m_MaxItems = new NativeArray<int>(1, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_MaxItems[0] = initialMessageCapacity;
			this.m_Queue = new NativeList<T>(initialMessageCapacity, Allocator.Persistent);
			this.m_QueueHeadTail = new NativeList<int>(2, Allocator.Persistent);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00010C2C File Offset: 0x0000EE2C
		public void Dispose()
		{
			this.m_MaxItems.Dispose();
			this.m_Queue.Dispose();
			this.m_QueueHeadTail.Dispose();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00010C50 File Offset: 0x0000EE50
		public void Enqueue(int bucket, T value)
		{
			if (bucket >= this.m_QueueHeadTail.Length / 2)
			{
				int i = this.m_QueueHeadTail.Length;
				this.m_QueueHeadTail.ResizeUninitialized((bucket + 1) * 2);
				while (i < this.m_QueueHeadTail.Length)
				{
					this.m_QueueHeadTail[i] = 0;
					i++;
				}
				this.m_Queue.ResizeUninitialized(this.m_QueueHeadTail.Length / 2 * this.m_MaxItems[0]);
			}
			int j = this.m_QueueHeadTail[bucket * 2 + 1];
			if (j >= this.m_MaxItems[0])
			{
				int num = this.m_MaxItems[0];
				while (j >= this.m_MaxItems[0])
				{
					this.m_MaxItems[0] = this.m_MaxItems[0] * 2;
				}
				int num2 = this.m_QueueHeadTail.Length / 2;
				this.m_Queue.ResizeUninitialized(num2 * this.m_MaxItems[0]);
				for (int k = num2 - 1; k >= 0; k--)
				{
					for (int l = this.m_QueueHeadTail[k * 2 + 1] - 1; l >= this.m_QueueHeadTail[k * 2]; l--)
					{
						this.m_Queue[k * this.m_MaxItems[0] + l] = this.m_Queue[k * num + l];
					}
				}
			}
			this.m_Queue[this.m_MaxItems[0] * bucket + j] = value;
			this.m_QueueHeadTail[bucket * 2 + 1] = j + 1;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00010DF4 File Offset: 0x0000EFF4
		public bool Dequeue(int bucket, out T value)
		{
			if (bucket < 0 || bucket >= this.m_QueueHeadTail.Length / 2)
			{
				value = default(T);
				return false;
			}
			int num = this.m_QueueHeadTail[bucket * 2];
			if (num >= this.m_QueueHeadTail[bucket * 2 + 1])
			{
				this.m_QueueHeadTail[bucket * 2] = (this.m_QueueHeadTail[bucket * 2 + 1] = 0);
				value = default(T);
				return false;
			}
			if (num + 1 == this.m_QueueHeadTail[bucket * 2 + 1])
			{
				this.m_QueueHeadTail[bucket * 2] = (this.m_QueueHeadTail[bucket * 2 + 1] = 0);
			}
			else
			{
				this.m_QueueHeadTail[bucket * 2] = num + 1;
			}
			value = this.m_Queue[this.m_MaxItems[0] * bucket + num];
			return true;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00010ED8 File Offset: 0x0000F0D8
		public bool Peek(int bucket, out T value)
		{
			if (bucket < 0 || bucket >= this.m_QueueHeadTail.Length / 2)
			{
				value = default(T);
				return false;
			}
			int num = this.m_QueueHeadTail[bucket * 2];
			if (num >= this.m_QueueHeadTail[bucket * 2 + 1])
			{
				value = default(T);
				return false;
			}
			value = this.m_Queue[this.m_MaxItems[0] * bucket + num];
			return true;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00010F4F File Offset: 0x0000F14F
		public void Clear(int bucket)
		{
			if (bucket < 0 || bucket >= this.m_QueueHeadTail.Length / 2)
			{
				return;
			}
			this.m_QueueHeadTail[bucket * 2] = 0;
			this.m_QueueHeadTail[bucket * 2 + 1] = 0;
		}

		// Token: 0x040002B7 RID: 695
		private NativeList<T> m_Queue;

		// Token: 0x040002B8 RID: 696
		private NativeList<int> m_QueueHeadTail;

		// Token: 0x040002B9 RID: 697
		private NativeArray<int> m_MaxItems;
	}
}
