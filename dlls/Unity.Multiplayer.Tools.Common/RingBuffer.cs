using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000017 RID: 23
	internal class RingBuffer<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000027C1 File Offset: 0x000009C1
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000027C9 File Offset: 0x000009C9
		public int Length { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000027D2 File Offset: 0x000009D2
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000027E2 File Offset: 0x000009E2
		public int Capacity
		{
			get
			{
				T[] buffer = this.m_Buffer;
				if (buffer == null)
				{
					return 0;
				}
				return buffer.Length;
			}
			set
			{
				this.ThrowIfCapacityLessThanZero(value);
				this.UpdateCapacity(value);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000027F2 File Offset: 0x000009F2
		public RingBuffer(int capacity)
		{
			this.ThrowIfCapacityLessThanZero(capacity);
			if (capacity > 0)
			{
				this.m_Buffer = new T[capacity];
			}
			else
			{
				this.m_Buffer = null;
			}
			this.m_Begin = 0;
			this.Length = 0;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002828 File Offset: 0x00000A28
		public RingBuffer(T[] values)
		{
			this.m_Buffer = values;
			this.m_Begin = 0;
			this.Length = values.Length;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002848 File Offset: 0x00000A48
		public void PushBack(T value)
		{
			int capacity = this.Capacity;
			if (capacity <= 0)
			{
				return;
			}
			int num = (this.m_Begin + this.Length) % capacity;
			this.m_Buffer[num] = value;
			if (this.Length < capacity)
			{
				int length = this.Length;
				this.Length = length + 1;
				return;
			}
			this.m_Begin = (this.m_Begin + 1) % capacity;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000028A8 File Offset: 0x00000AA8
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000028B4 File Offset: 0x00000AB4
		private void UpdateCapacity(int newCapacity)
		{
			int capacity = this.Capacity;
			if (newCapacity == capacity)
			{
				return;
			}
			if (newCapacity == 0)
			{
				this.m_Buffer = null;
				this.m_Begin = 0;
				this.Length = 0;
				return;
			}
			T[] buffer = this.m_Buffer;
			int begin = this.m_Begin;
			int length = this.Length;
			this.m_Buffer = new T[newCapacity];
			this.m_Begin = 0;
			this.Length = Math.Min(length, newCapacity);
			int num = begin + (length - this.Length);
			for (int i = 0; i < this.Length; i++)
			{
				int num2 = (i + num) % capacity;
				this.m_Buffer[i] = buffer[num2];
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002956 File Offset: 0x00000B56
		private bool ContainsIndex(int index)
		{
			return 0 <= index && index < this.Length;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002967 File Offset: 0x00000B67
		private bool ContainsIndex(Index index)
		{
			return this.ContainsIndex(index.IsFromEnd ? (index.Value - 1) : index.Value);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000298A File Offset: 0x00000B8A
		private void ThrowIfIndexOutOfRange(int index)
		{
			if (!this.ContainsIndex(index))
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range [0, {1})", index, this.Length));
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000029B6 File Offset: 0x00000BB6
		private void ThrowIfCapacityLessThanZero(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentException(string.Format("RingBuffer capacity argument {0} is < 0", capacity));
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000029D2 File Offset: 0x00000BD2
		private void ThrowIfIndexOutOfRange(Index index)
		{
			if (!this.ContainsIndex(index))
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range [0, {1})", index, this.Length));
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000029FE File Offset: 0x00000BFE
		private int GetBufferIndex(int index)
		{
			return (index + this.m_Begin) % this.Capacity;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002A0F File Offset: 0x00000C0F
		private int GetBufferIndexFromEnd(int index)
		{
			return this.GetBufferIndex(this.Length - 1 - index);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002A21 File Offset: 0x00000C21
		private int GetBufferIndex(Index index)
		{
			if (index.IsFromEnd)
			{
				return this.GetBufferIndexFromEnd(index.Value - 1);
			}
			return this.GetBufferIndex(index.Value);
		}

		// Token: 0x17000012 RID: 18
		public T this[int index]
		{
			get
			{
				this.ThrowIfIndexOutOfRange(index);
				return this.m_Buffer[this.GetBufferIndex(index)];
			}
			set
			{
				this.ThrowIfIndexOutOfRange(index);
				this.m_Buffer[this.GetBufferIndex(index)] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		public T this[Index index]
		{
			get
			{
				this.ThrowIfIndexOutOfRange(index);
				return this.m_Buffer[this.GetBufferIndex(index)];
			}
			set
			{
				this.ThrowIfIndexOutOfRange(index);
				this.m_Buffer[this.GetBufferIndex(index)] = value;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public T GetValueOrDefault(int index)
		{
			if (this.ContainsIndex(index))
			{
				return this[index];
			}
			return default(T);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public T GetValueOrDefault(Index index)
		{
			if (this.ContainsIndex(index))
			{
				return this[index];
			}
			return default(T);
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002B07 File Offset: 0x00000D07
		public T LeastRecent
		{
			get
			{
				return this[0];
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002B10 File Offset: 0x00000D10
		public T LeastRecentOrDefault
		{
			get
			{
				if (this.Length <= 0)
				{
					return default(T);
				}
				return this.LeastRecent;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002B36 File Offset: 0x00000D36
		public T MostRecent
		{
			get
			{
				return this[new Index(1, true)];
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002B48 File Offset: 0x00000D48
		public T MostRecentOrDefault
		{
			get
			{
				if (this.Length <= 0)
				{
					return default(T);
				}
				return this.MostRecent;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002B6E File Offset: 0x00000D6E
		public IEnumerator<T> GetEnumerator()
		{
			int num;
			for (int i = 0; i < this.Length; i = num)
			{
				yield return this[i];
				num = i + 1;
			}
			yield break;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002B7D File Offset: 0x00000D7D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000019 RID: 25
		[CanBeNull]
		private T[] m_Buffer;

		// Token: 0x0400001A RID: 26
		private int m_Begin;
	}
}
