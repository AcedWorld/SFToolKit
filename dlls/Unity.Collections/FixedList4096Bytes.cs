using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Collections
{
	// Token: 0x02000047 RID: 71
	[DebuggerTypeProxy(typeof(FixedList4096BytesDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	[Serializable]
	public struct FixedList4096Bytes<[IsUnmanaged] T> : INativeList<T>, IIndexable<T>, IEnumerable<!0>, IEnumerable, IEquatable<FixedList32Bytes<T>>, IComparable<FixedList32Bytes<T>>, IEquatable<FixedList64Bytes<T>>, IComparable<FixedList64Bytes<T>>, IEquatable<FixedList128Bytes<T>>, IComparable<FixedList128Bytes<T>>, IEquatable<FixedList512Bytes<T>>, IComparable<FixedList512Bytes<T>>, IEquatable<FixedList4096Bytes<T>>, IComparable<FixedList4096Bytes<T>> where T : struct, ValueType
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000735F File Offset: 0x0000555F
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00007367 File Offset: 0x00005567
		[CreateProperty]
		public int Length
		{
			get
			{
				return (int)this.length;
			}
			set
			{
				this.length = (ushort)value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00007371 File Offset: 0x00005571
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00007379 File Offset: 0x00005579
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00007384 File Offset: 0x00005584
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00007394 File Offset: 0x00005594
		internal unsafe byte* Buffer
		{
			get
			{
				fixed (byte* ptr = &this.buffer.offset0000.byte0000)
				{
					return ptr + FixedList.PaddingBytes<T>();
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000241 RID: 577 RVA: 0x000073BA File Offset: 0x000055BA
		// (set) Token: 0x06000242 RID: 578 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<FixedBytes4094, T>();
			}
			set
			{
			}
		}

		// Token: 0x17000056 RID: 86
		public unsafe T this[int index]
		{
			get
			{
				return UnsafeUtility.ReadArrayElement<T>((void*)this.Buffer, CollectionHelper.AssumePositive(index));
			}
			set
			{
				UnsafeUtility.WriteArrayElement<T>((void*)this.Buffer, CollectionHelper.AssumePositive(index), value);
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000073E8 File Offset: 0x000055E8
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000073F6 File Offset: 0x000055F6
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000740C File Offset: 0x0000560C
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00007438 File Offset: 0x00005638
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000747A File Offset: 0x0000567A
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00007483 File Offset: 0x00005683
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000748D File Offset: 0x0000568D
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00007498 File Offset: 0x00005698
		public unsafe void InsertRangeWithBeginEnd(int begin, int end)
		{
			int num = end - begin;
			if (num < 1)
			{
				return;
			}
			int num2 = (int)this.length - begin;
			this.Length += num;
			if (num2 < 1)
			{
				return;
			}
			int num3 = num2 * UnsafeUtility.SizeOf<T>();
			byte* ptr = this.Buffer;
			byte* destination = ptr + end * UnsafeUtility.SizeOf<T>();
			byte* source = ptr + begin * UnsafeUtility.SizeOf<T>();
			UnsafeUtility.MemMove((void*)destination, (void*)source, (long)num3);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000074F6 File Offset: 0x000056F6
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000750F File Offset: 0x0000570F
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000751C File Offset: 0x0000571C
		public unsafe void RemoveRangeSwapBack(int index, int count)
		{
			if (count > 0)
			{
				int num = math.max(this.Length - count, index + count);
				int num2 = UnsafeUtility.SizeOf<T>();
				void* destination = (void*)(this.Buffer + index * num2);
				void* source = (void*)(this.Buffer + num * num2);
				UnsafeUtility.MemCpy(destination, source, (long)((this.Length - num) * num2));
				this.Length -= count;
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000757A File Offset: 0x0000577A
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00007586 File Offset: 0x00005786
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00007590 File Offset: 0x00005790
		public unsafe void RemoveRange(int index, int count)
		{
			if (count > 0)
			{
				int num = math.min(index + count, this.Length);
				int num2 = UnsafeUtility.SizeOf<T>();
				void* destination = (void*)(this.Buffer + index * num2);
				void* source = (void*)(this.Buffer + num * num2);
				UnsafeUtility.MemCpy(destination, source, (long)((this.Length - num) * num2));
				this.Length -= count;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000075EC File Offset: 0x000057EC
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000075F8 File Offset: 0x000057F8
		[NotBurstCompatible]
		public unsafe T[] ToArray()
		{
			T[] array = new T[this.Length];
			byte* source = this.Buffer;
			fixed (T[] array2 = array)
			{
				T* destination;
				if (array == null || array2.Length == 0)
				{
					destination = null;
				}
				else
				{
					destination = &array2[0];
				}
				UnsafeUtility.MemCpy((void*)destination, (void*)source, (long)this.LengthInBytes);
			}
			return array;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000763F File Offset: 0x0000583F
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00007668 File Offset: 0x00005868
		public unsafe static bool operator ==(in FixedList4096Bytes<T> a, in FixedList32Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList4096Bytes<T> fixedList4096Bytes = a;
			void* ptr = (void*)fixedList4096Bytes.Buffer;
			FixedList32Bytes<T> fixedList32Bytes = b;
			void* ptr2 = (void*)fixedList32Bytes.Buffer;
			fixedList4096Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList4096Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000076B8 File Offset: 0x000058B8
		public static bool operator !=(in FixedList4096Bytes<T> a, in FixedList32Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000076C4 File Offset: 0x000058C4
		public unsafe int CompareTo(FixedList32Bytes<T> other)
		{
			fixed (byte* ptr = &this.buffer.offset0000.byte0000)
			{
				byte* ptr2 = ptr;
				byte* ptr3 = &other.buffer.offset0000.byte0000;
				byte* ptr4 = ptr2 + FixedList.PaddingBytes<T>();
				byte* ptr5 = ptr3 + FixedList.PaddingBytes<T>();
				int num = math.min(this.Length, other.Length);
				for (int i = 0; i < num; i++)
				{
					int num2 = UnsafeUtility.MemCmp((void*)(ptr4 + sizeof(T) * i), (void*)(ptr5 + sizeof(T) * i), (long)sizeof(T));
					if (num2 != 0)
					{
						return num2;
					}
				}
				return this.Length.CompareTo(other.Length);
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000776C File Offset: 0x0000596C
		public bool Equals(FixedList32Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00007778 File Offset: 0x00005978
		public FixedList4096Bytes(in FixedList32Bytes<T> other)
		{
			this = default(FixedList4096Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000778C File Offset: 0x0000598C
		internal unsafe int Initialize(in FixedList32Bytes<T> other)
		{
			FixedList32Bytes<T> fixedList32Bytes = other;
			if (fixedList32Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes4094);
			void* destination = (void*)this.Buffer;
			fixedList32Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList32Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000077EA File Offset: 0x000059EA
		public static implicit operator FixedList4096Bytes<T>(in FixedList32Bytes<T> other)
		{
			return new FixedList4096Bytes<T>(ref other);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000077F4 File Offset: 0x000059F4
		public unsafe static bool operator ==(in FixedList4096Bytes<T> a, in FixedList64Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList4096Bytes<T> fixedList4096Bytes = a;
			void* ptr = (void*)fixedList4096Bytes.Buffer;
			FixedList64Bytes<T> fixedList64Bytes = b;
			void* ptr2 = (void*)fixedList64Bytes.Buffer;
			fixedList4096Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList4096Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00007844 File Offset: 0x00005A44
		public static bool operator !=(in FixedList4096Bytes<T> a, in FixedList64Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00007850 File Offset: 0x00005A50
		public unsafe int CompareTo(FixedList64Bytes<T> other)
		{
			fixed (byte* ptr = &this.buffer.offset0000.byte0000)
			{
				byte* ptr2 = ptr;
				byte* ptr3 = &other.buffer.offset0000.byte0000;
				byte* ptr4 = ptr2 + FixedList.PaddingBytes<T>();
				byte* ptr5 = ptr3 + FixedList.PaddingBytes<T>();
				int num = math.min(this.Length, other.Length);
				for (int i = 0; i < num; i++)
				{
					int num2 = UnsafeUtility.MemCmp((void*)(ptr4 + sizeof(T) * i), (void*)(ptr5 + sizeof(T) * i), (long)sizeof(T));
					if (num2 != 0)
					{
						return num2;
					}
				}
				return this.Length.CompareTo(other.Length);
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000078F8 File Offset: 0x00005AF8
		public bool Equals(FixedList64Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00007904 File Offset: 0x00005B04
		public FixedList4096Bytes(in FixedList64Bytes<T> other)
		{
			this = default(FixedList4096Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00007918 File Offset: 0x00005B18
		internal unsafe int Initialize(in FixedList64Bytes<T> other)
		{
			FixedList64Bytes<T> fixedList64Bytes = other;
			if (fixedList64Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes4094);
			void* destination = (void*)this.Buffer;
			fixedList64Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList64Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00007976 File Offset: 0x00005B76
		public static implicit operator FixedList4096Bytes<T>(in FixedList64Bytes<T> other)
		{
			return new FixedList4096Bytes<T>(ref other);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00007980 File Offset: 0x00005B80
		public unsafe static bool operator ==(in FixedList4096Bytes<T> a, in FixedList128Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList4096Bytes<T> fixedList4096Bytes = a;
			void* ptr = (void*)fixedList4096Bytes.Buffer;
			FixedList128Bytes<T> fixedList128Bytes = b;
			void* ptr2 = (void*)fixedList128Bytes.Buffer;
			fixedList4096Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList4096Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000079D0 File Offset: 0x00005BD0
		public static bool operator !=(in FixedList4096Bytes<T> a, in FixedList128Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000079DC File Offset: 0x00005BDC
		public unsafe int CompareTo(FixedList128Bytes<T> other)
		{
			fixed (byte* ptr = &this.buffer.offset0000.byte0000)
			{
				byte* ptr2 = ptr;
				byte* ptr3 = &other.buffer.offset0000.byte0000;
				byte* ptr4 = ptr2 + FixedList.PaddingBytes<T>();
				byte* ptr5 = ptr3 + FixedList.PaddingBytes<T>();
				int num = math.min(this.Length, other.Length);
				for (int i = 0; i < num; i++)
				{
					int num2 = UnsafeUtility.MemCmp((void*)(ptr4 + sizeof(T) * i), (void*)(ptr5 + sizeof(T) * i), (long)sizeof(T));
					if (num2 != 0)
					{
						return num2;
					}
				}
				return this.Length.CompareTo(other.Length);
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00007A84 File Offset: 0x00005C84
		public bool Equals(FixedList128Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00007A90 File Offset: 0x00005C90
		public FixedList4096Bytes(in FixedList128Bytes<T> other)
		{
			this = default(FixedList4096Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00007AA4 File Offset: 0x00005CA4
		internal unsafe int Initialize(in FixedList128Bytes<T> other)
		{
			FixedList128Bytes<T> fixedList128Bytes = other;
			if (fixedList128Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes4094);
			void* destination = (void*)this.Buffer;
			fixedList128Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList128Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00007B02 File Offset: 0x00005D02
		public static implicit operator FixedList4096Bytes<T>(in FixedList128Bytes<T> other)
		{
			return new FixedList4096Bytes<T>(ref other);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00007B0C File Offset: 0x00005D0C
		public unsafe static bool operator ==(in FixedList4096Bytes<T> a, in FixedList512Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList4096Bytes<T> fixedList4096Bytes = a;
			void* ptr = (void*)fixedList4096Bytes.Buffer;
			FixedList512Bytes<T> fixedList512Bytes = b;
			void* ptr2 = (void*)fixedList512Bytes.Buffer;
			fixedList4096Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList4096Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00007B5C File Offset: 0x00005D5C
		public static bool operator !=(in FixedList4096Bytes<T> a, in FixedList512Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00007B68 File Offset: 0x00005D68
		public unsafe int CompareTo(FixedList512Bytes<T> other)
		{
			fixed (byte* ptr = &this.buffer.offset0000.byte0000)
			{
				byte* ptr2 = ptr;
				byte* ptr3 = &other.buffer.offset0000.byte0000;
				byte* ptr4 = ptr2 + FixedList.PaddingBytes<T>();
				byte* ptr5 = ptr3 + FixedList.PaddingBytes<T>();
				int num = math.min(this.Length, other.Length);
				for (int i = 0; i < num; i++)
				{
					int num2 = UnsafeUtility.MemCmp((void*)(ptr4 + sizeof(T) * i), (void*)(ptr5 + sizeof(T) * i), (long)sizeof(T));
					if (num2 != 0)
					{
						return num2;
					}
				}
				return this.Length.CompareTo(other.Length);
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00007C10 File Offset: 0x00005E10
		public bool Equals(FixedList512Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00007C1C File Offset: 0x00005E1C
		public FixedList4096Bytes(in FixedList512Bytes<T> other)
		{
			this = default(FixedList4096Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007C30 File Offset: 0x00005E30
		internal unsafe int Initialize(in FixedList512Bytes<T> other)
		{
			FixedList512Bytes<T> fixedList512Bytes = other;
			if (fixedList512Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes4094);
			void* destination = (void*)this.Buffer;
			fixedList512Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList512Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00007C8E File Offset: 0x00005E8E
		public static implicit operator FixedList4096Bytes<T>(in FixedList512Bytes<T> other)
		{
			return new FixedList4096Bytes<T>(ref other);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00007C98 File Offset: 0x00005E98
		public unsafe static bool operator ==(in FixedList4096Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList4096Bytes<T> fixedList4096Bytes = a;
			void* ptr = (void*)fixedList4096Bytes.Buffer;
			fixedList4096Bytes = b;
			void* ptr2 = (void*)fixedList4096Bytes.Buffer;
			fixedList4096Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList4096Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00007CE8 File Offset: 0x00005EE8
		public static bool operator !=(in FixedList4096Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00007CF4 File Offset: 0x00005EF4
		public unsafe int CompareTo(FixedList4096Bytes<T> other)
		{
			fixed (byte* ptr = &this.buffer.offset0000.byte0000)
			{
				byte* ptr2 = ptr;
				byte* ptr3 = &other.buffer.offset0000.byte0000;
				byte* ptr4 = ptr2 + FixedList.PaddingBytes<T>();
				byte* ptr5 = ptr3 + FixedList.PaddingBytes<T>();
				int num = math.min(this.Length, other.Length);
				for (int i = 0; i < num; i++)
				{
					int num2 = UnsafeUtility.MemCmp((void*)(ptr4 + sizeof(T) * i), (void*)(ptr5 + sizeof(T) * i), (long)sizeof(T));
					if (num2 != 0)
					{
						return num2;
					}
				}
				return this.Length.CompareTo(other.Length);
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007D9C File Offset: 0x00005F9C
		public bool Equals(FixedList4096Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007DA8 File Offset: 0x00005FA8
		[NotBurstCompatible]
		public override bool Equals(object obj)
		{
			if (obj is FixedList32Bytes<T>)
			{
				FixedList32Bytes<T> other = (FixedList32Bytes<T>)obj;
				return this.Equals(other);
			}
			if (obj is FixedList64Bytes<T>)
			{
				FixedList64Bytes<T> other2 = (FixedList64Bytes<T>)obj;
				return this.Equals(other2);
			}
			if (obj is FixedList128Bytes<T>)
			{
				FixedList128Bytes<T> other3 = (FixedList128Bytes<T>)obj;
				return this.Equals(other3);
			}
			if (obj is FixedList512Bytes<T>)
			{
				FixedList512Bytes<T> other4 = (FixedList512Bytes<T>)obj;
				return this.Equals(other4);
			}
			if (obj is FixedList4096Bytes<T>)
			{
				FixedList4096Bytes<T> other5 = (FixedList4096Bytes<T>)obj;
				return this.Equals(other5);
			}
			return false;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00007E2B File Offset: 0x0000602B
		public FixedList4096Bytes<T>.Enumerator GetEnumerator()
		{
			return new FixedList4096Bytes<T>.Enumerator(ref this);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040000AF RID: 175
		[SerializeField]
		internal ushort length;

		// Token: 0x040000B0 RID: 176
		[SerializeField]
		internal FixedBytes4094 buffer;

		// Token: 0x02000048 RID: 72
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x0600027A RID: 634 RVA: 0x00007E33 File Offset: 0x00006033
			public Enumerator(ref FixedList4096Bytes<T> list)
			{
				this.m_List = list;
				this.m_Index = -1;
			}

			// Token: 0x0600027B RID: 635 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x0600027C RID: 636 RVA: 0x00007E48 File Offset: 0x00006048
			public bool MoveNext()
			{
				this.m_Index++;
				return this.m_Index < this.m_List.Length;
			}

			// Token: 0x0600027D RID: 637 RVA: 0x00007E6B File Offset: 0x0000606B
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x0600027E RID: 638 RVA: 0x00007E74 File Offset: 0x00006074
			public T Current
			{
				get
				{
					return this.m_List[this.m_Index];
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x0600027F RID: 639 RVA: 0x00007E87 File Offset: 0x00006087
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000B1 RID: 177
			private FixedList4096Bytes<T> m_List;

			// Token: 0x040000B2 RID: 178
			private int m_Index;
		}
	}
}
