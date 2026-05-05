using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x02000125 RID: 293
	internal struct BatchedSendQueue : IDisposable
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x000230CF File Offset: 0x000212CF
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x000230DD File Offset: 0x000212DD
		private int HeadIndex
		{
			get
			{
				return this.m_HeadTailIndices[0];
			}
			set
			{
				this.m_HeadTailIndices[0] = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x000230EC File Offset: 0x000212EC
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x000230FA File Offset: 0x000212FA
		private int TailIndex
		{
			get
			{
				return this.m_HeadTailIndices[1];
			}
			set
			{
				this.m_HeadTailIndices[1] = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00023109 File Offset: 0x00021309
		public int Length
		{
			get
			{
				return this.TailIndex - this.HeadIndex;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00023118 File Offset: 0x00021318
		public int Capacity
		{
			get
			{
				return this.m_Data.Length;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x00023125 File Offset: 0x00021325
		public bool IsEmpty
		{
			get
			{
				return this.HeadIndex == this.TailIndex;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00023135 File Offset: 0x00021335
		public bool IsCreated
		{
			get
			{
				return this.m_Data.IsCreated;
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00023144 File Offset: 0x00021344
		public BatchedSendQueue(int capacity)
		{
			this.m_MaximumCapacity = capacity + (capacity & 1);
			this.m_MinimumCapacity = this.m_MaximumCapacity;
			while (this.m_MinimumCapacity / 2 >= 4096)
			{
				this.m_MinimumCapacity /= 2;
			}
			this.m_Data = new NativeList<byte>(this.m_MinimumCapacity, Allocator.Persistent);
			this.m_HeadTailIndices = new NativeArray<int>(2, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_Data.ResizeUninitialized(this.m_MinimumCapacity);
			this.HeadIndex = 0;
			this.TailIndex = 0;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x000231CB File Offset: 0x000213CB
		public void Dispose()
		{
			if (this.IsCreated)
			{
				this.m_Data.Dispose();
				this.m_HeadTailIndices.Dispose();
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000231EB File Offset: 0x000213EB
		private unsafe void WriteBytes(ref DataStreamWriter writer, byte* data, int length)
		{
			writer.WriteBytes(data, length);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000231F8 File Offset: 0x000213F8
		private unsafe void AppendDataAtTail(ArraySegment<byte> data)
		{
			DataStreamWriter dataStreamWriter = new DataStreamWriter((byte*)this.m_Data.GetUnsafePtr<byte>() + this.TailIndex, this.Capacity - this.TailIndex);
			dataStreamWriter.WriteInt(data.Count);
			byte[] array;
			byte* ptr;
			if ((array = data.Array) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			this.WriteBytes(ref dataStreamWriter, ptr + data.Offset, data.Count);
			array = null;
			this.TailIndex += 4 + data.Count;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00023288 File Offset: 0x00021488
		public unsafe bool PushMessage(ArraySegment<byte> message)
		{
			if (!this.IsCreated)
			{
				return false;
			}
			if (this.Capacity - this.TailIndex >= 4 + message.Count)
			{
				this.AppendDataAtTail(message);
				return true;
			}
			if (this.HeadIndex > 0 && this.Length > 0)
			{
				UnsafeUtility.MemMove(this.m_Data.GetUnsafePtr<byte>(), (void*)((byte*)this.m_Data.GetUnsafePtr<byte>() + this.HeadIndex), (long)this.Length);
				this.TailIndex = this.Length;
				this.HeadIndex = 0;
			}
			if (this.Capacity - this.TailIndex >= 4 + message.Count)
			{
				this.AppendDataAtTail(message);
				while (this.TailIndex < this.Capacity / 4 && this.Capacity > this.m_MinimumCapacity)
				{
					this.m_Data.ResizeUninitialized(this.Capacity / 2);
				}
				return true;
			}
			while (this.Capacity - this.TailIndex < 4 + message.Count)
			{
				if (this.Capacity * 2 > this.m_MaximumCapacity)
				{
					return false;
				}
				this.m_Data.ResizeUninitialized(this.Capacity * 2);
			}
			this.AppendDataAtTail(message);
			return true;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x000233A8 File Offset: 0x000215A8
		public unsafe int FillWriterWithMessages(ref DataStreamWriter writer, int softMaxBytes = 0)
		{
			if (!this.IsCreated || this.Length == 0)
			{
				return 0;
			}
			softMaxBytes = ((softMaxBytes == 0) ? writer.Capacity : Math.Min(softMaxBytes, writer.Capacity));
			DataStreamReader dataStreamReader = new DataStreamReader(this.m_Data.AsArray());
			int i = this.HeadIndex;
			dataStreamReader.SeekSet(i);
			int num = dataStreamReader.ReadInt();
			int num2 = num + 4;
			if (num2 > softMaxBytes && num2 <= writer.Capacity)
			{
				writer.WriteInt(num);
				this.WriteBytes(ref writer, (byte*)this.m_Data.GetUnsafePtr<byte>() + dataStreamReader.GetBytesRead(), num);
				return num2;
			}
			int num3 = 0;
			while (i < this.TailIndex)
			{
				dataStreamReader.SeekSet(i);
				num = dataStreamReader.ReadInt();
				num2 = num + 4;
				if (num3 + num2 > softMaxBytes)
				{
					break;
				}
				writer.WriteInt(num);
				this.WriteBytes(ref writer, (byte*)this.m_Data.GetUnsafePtr<byte>() + dataStreamReader.GetBytesRead(), num);
				i += num2;
				num3 += num2;
			}
			return num3;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00023498 File Offset: 0x00021698
		public unsafe int FillWriterWithBytes(ref DataStreamWriter writer, int maxBytes = 0)
		{
			if (!this.IsCreated || this.Length == 0)
			{
				return 0;
			}
			int num = Math.Min((maxBytes == 0) ? writer.Capacity : Math.Min(maxBytes, writer.Capacity), this.Length);
			this.WriteBytes(ref writer, (byte*)this.m_Data.GetUnsafePtr<byte>() + this.HeadIndex, num);
			return num;
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000234F5 File Offset: 0x000216F5
		public void Consume(int size)
		{
			if (size >= this.Length)
			{
				this.HeadIndex = 0;
				this.TailIndex = 0;
				this.m_Data.ResizeUninitialized(this.m_MinimumCapacity);
				return;
			}
			this.HeadIndex += size;
		}

		// Token: 0x04000384 RID: 900
		private NativeList<byte> m_Data;

		// Token: 0x04000385 RID: 901
		private NativeArray<int> m_HeadTailIndices;

		// Token: 0x04000386 RID: 902
		private int m_MaximumCapacity;

		// Token: 0x04000387 RID: 903
		private int m_MinimumCapacity;

		// Token: 0x04000388 RID: 904
		public const int PerMessageOverhead = 4;

		// Token: 0x04000389 RID: 905
		internal const int MinimumMinimumCapacity = 4096;

		// Token: 0x0400038A RID: 906
		private const int k_HeadInternalIndex = 0;

		// Token: 0x0400038B RID: 907
		private const int k_TailInternalIndex = 1;
	}
}
