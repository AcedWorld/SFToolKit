using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200003F RID: 63
	[DebuggerDisplay("Size = {size} Capacity = {capacity}")]
	public class DynamicArray<T> where T : new()
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000B052 File Offset: 0x00009252
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000B05A File Offset: 0x0000925A
		public int size { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000B063 File Offset: 0x00009263
		public int capacity
		{
			get
			{
				return this.m_Array.Length;
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000B06D File Offset: 0x0000926D
		public DynamicArray()
		{
			this.m_Array = new T[32];
			this.size = 0;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000B089 File Offset: 0x00009289
		public DynamicArray(int size)
		{
			this.m_Array = new T[size];
			this.size = size;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000B0A4 File Offset: 0x000092A4
		public void Clear()
		{
			this.size = 0;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000B0AD File Offset: 0x000092AD
		public bool Contains(T item)
		{
			return this.IndexOf(item) != -1;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000B0BC File Offset: 0x000092BC
		public int Add(in T value)
		{
			int size = this.size;
			if (size >= this.m_Array.Length)
			{
				T[] array = new T[this.m_Array.Length * 2];
				Array.Copy(this.m_Array, array, this.m_Array.Length);
				this.m_Array = array;
			}
			this.m_Array[size] = value;
			int size2 = this.size;
			this.size = size2 + 1;
			this.BumpVersion();
			return size;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000B130 File Offset: 0x00009330
		public unsafe void AddRange(DynamicArray<T> array)
		{
			this.Reserve(this.size + array.size, true);
			for (int i = 0; i < array.size; i++)
			{
				T[] array2 = this.m_Array;
				int size = this.size;
				this.size = size + 1;
				array2[size] = *array[i];
			}
			this.BumpVersion();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000B190 File Offset: 0x00009390
		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num != -1)
			{
				this.RemoveAt(num);
				return true;
			}
			return false;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000B1B4 File Offset: 0x000093B4
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.size)
			{
				throw new IndexOutOfRangeException();
			}
			if (index != this.size - 1)
			{
				Array.Copy(this.m_Array, index + 1, this.m_Array, index, this.size - index - 1);
			}
			int size = this.size;
			this.size = size - 1;
			this.BumpVersion();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000B214 File Offset: 0x00009414
		public void RemoveRange(int index, int count)
		{
			if (count == 0)
			{
				return;
			}
			if (index < 0 || index >= this.size || count < 0 || index + count > this.size)
			{
				throw new ArgumentOutOfRangeException();
			}
			Array.Copy(this.m_Array, index + count, this.m_Array, index, this.size - index - count);
			this.size -= count;
			this.BumpVersion();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000B27C File Offset: 0x0000947C
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			for (int i = startIndex; i < this.size; i++)
			{
				if (match(this.m_Array[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000B2B4 File Offset: 0x000094B4
		public int IndexOf(T item, int index, int count)
		{
			int num = index;
			while (num < this.size && count > 0)
			{
				if (this.m_Array[num].Equals(item))
				{
					return num;
				}
				num++;
				count--;
			}
			return -1;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000B300 File Offset: 0x00009500
		public int IndexOf(T item, int index)
		{
			for (int i = index; i < this.size; i++)
			{
				if (this.m_Array[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000B342 File Offset: 0x00009542
		public int IndexOf(T item)
		{
			return this.IndexOf(item, 0);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000B34C File Offset: 0x0000954C
		public void Resize(int newSize, bool keepContent = false)
		{
			this.Reserve(newSize, keepContent);
			this.size = newSize;
			this.BumpVersion();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000B364 File Offset: 0x00009564
		public void Reserve(int newCapacity, bool keepContent = false)
		{
			if (newCapacity > this.m_Array.Length)
			{
				if (keepContent)
				{
					T[] array = new T[newCapacity];
					Array.Copy(this.m_Array, array, this.m_Array.Length);
					this.m_Array = array;
					return;
				}
				this.m_Array = new T[newCapacity];
			}
		}

		// Token: 0x17000042 RID: 66
		public T this[int index]
		{
			get
			{
				return ref this.m_Array[index];
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000B3BC File Offset: 0x000095BC
		public static implicit operator T[](DynamicArray<T> array)
		{
			return array.m_Array;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000B3C4 File Offset: 0x000095C4
		public DynamicArray<T>.Iterator GetEnumerator()
		{
			return new DynamicArray<T>.Iterator(this);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B3CC File Offset: 0x000095CC
		public DynamicArray<T>.RangeEnumerable SubRange(int first, int numItems)
		{
			return new DynamicArray<T>.RangeEnumerable
			{
				iterator = new DynamicArray<T>.RangeEnumerable.RangeIterator(this, first, numItems)
			};
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B3F1 File Offset: 0x000095F1
		internal void BumpVersion()
		{
		}

		// Token: 0x0400014C RID: 332
		private T[] m_Array;

		// Token: 0x02000159 RID: 345
		public struct Iterator
		{
			// Token: 0x060009DE RID: 2526 RVA: 0x0002BF56 File Offset: 0x0002A156
			public Iterator(DynamicArray<T> setOwner)
			{
				this.owner = setOwner;
				this.index = -1;
			}

			// Token: 0x1700014C RID: 332
			// (get) Token: 0x060009DF RID: 2527 RVA: 0x0002BF66 File Offset: 0x0002A166
			public ref T Current
			{
				get
				{
					return this.owner[this.index];
				}
			}

			// Token: 0x060009E0 RID: 2528 RVA: 0x0002BF79 File Offset: 0x0002A179
			public bool MoveNext()
			{
				this.index++;
				return this.index < this.owner.size;
			}

			// Token: 0x060009E1 RID: 2529 RVA: 0x0002BF9C File Offset: 0x0002A19C
			public void Reset()
			{
				this.index = -1;
			}

			// Token: 0x040005E6 RID: 1510
			private readonly DynamicArray<T> owner;

			// Token: 0x040005E7 RID: 1511
			private int index;
		}

		// Token: 0x0200015A RID: 346
		public struct RangeEnumerable
		{
			// Token: 0x060009E2 RID: 2530 RVA: 0x0002BFA5 File Offset: 0x0002A1A5
			public DynamicArray<T>.RangeEnumerable.RangeIterator GetEnumerator()
			{
				return this.iterator;
			}

			// Token: 0x040005E8 RID: 1512
			public DynamicArray<T>.RangeEnumerable.RangeIterator iterator;

			// Token: 0x020001EB RID: 491
			public struct RangeIterator
			{
				// Token: 0x06000B91 RID: 2961 RVA: 0x0002FFB5 File Offset: 0x0002E1B5
				public RangeIterator(DynamicArray<T> setOwner, int first, int numItems)
				{
					this.owner = setOwner;
					this.first = first;
					this.index = first - 1;
					this.last = first + numItems;
				}

				// Token: 0x17000194 RID: 404
				// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0002FFD7 File Offset: 0x0002E1D7
				public ref T Current
				{
					get
					{
						return this.owner[this.index];
					}
				}

				// Token: 0x06000B93 RID: 2963 RVA: 0x0002FFEA File Offset: 0x0002E1EA
				public bool MoveNext()
				{
					this.index++;
					return this.index < this.last;
				}

				// Token: 0x06000B94 RID: 2964 RVA: 0x00030008 File Offset: 0x0002E208
				public void Reset()
				{
					this.index = this.first - 1;
				}

				// Token: 0x040007BF RID: 1983
				private readonly DynamicArray<T> owner;

				// Token: 0x040007C0 RID: 1984
				private int index;

				// Token: 0x040007C1 RID: 1985
				private int first;

				// Token: 0x040007C2 RID: 1986
				private int last;
			}
		}
	}
}
