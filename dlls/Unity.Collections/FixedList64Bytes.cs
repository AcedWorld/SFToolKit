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
	// Token: 0x02000038 RID: 56
	[DebuggerTypeProxy(typeof(FixedList64BytesDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	[Serializable]
	public struct FixedList64Bytes<[IsUnmanaged] T> : INativeList<T>, IIndexable<T>, IEnumerable<!0>, IEnumerable, IEquatable<FixedList32Bytes<T>>, IComparable<FixedList32Bytes<T>>, IEquatable<FixedList64Bytes<T>>, IComparable<FixedList64Bytes<T>>, IEquatable<FixedList128Bytes<T>>, IComparable<FixedList128Bytes<T>>, IEquatable<FixedList512Bytes<T>>, IComparable<FixedList512Bytes<T>>, IEquatable<FixedList4096Bytes<T>>, IComparable<FixedList4096Bytes<T>> where T : struct, ValueType
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0000502B File Offset: 0x0000322B
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00005033 File Offset: 0x00003233
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

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0000503D File Offset: 0x0000323D
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00005045 File Offset: 0x00003245
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00005050 File Offset: 0x00003250
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00005060 File Offset: 0x00003260
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00005086 File Offset: 0x00003286
		// (set) Token: 0x06000161 RID: 353 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<FixedBytes62, T>();
			}
			set
			{
			}
		}

		// Token: 0x17000038 RID: 56
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

		// Token: 0x06000164 RID: 356 RVA: 0x000050B4 File Offset: 0x000032B4
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000050C2 File Offset: 0x000032C2
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000050D8 File Offset: 0x000032D8
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005104 File Offset: 0x00003304
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00005146 File Offset: 0x00003346
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000514F File Offset: 0x0000334F
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00005159 File Offset: 0x00003359
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00005164 File Offset: 0x00003364
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

		// Token: 0x0600016C RID: 364 RVA: 0x000051C2 File Offset: 0x000033C2
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000051DB File Offset: 0x000033DB
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000051E8 File Offset: 0x000033E8
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

		// Token: 0x0600016F RID: 367 RVA: 0x00005246 File Offset: 0x00003446
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005252 File Offset: 0x00003452
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000525C File Offset: 0x0000345C
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

		// Token: 0x06000172 RID: 370 RVA: 0x000052B8 File Offset: 0x000034B8
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000052C4 File Offset: 0x000034C4
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

		// Token: 0x06000174 RID: 372 RVA: 0x0000530B File Offset: 0x0000350B
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00005334 File Offset: 0x00003534
		public unsafe static bool operator ==(in FixedList64Bytes<T> a, in FixedList32Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList64Bytes<T> fixedList64Bytes = a;
			void* ptr = (void*)fixedList64Bytes.Buffer;
			FixedList32Bytes<T> fixedList32Bytes = b;
			void* ptr2 = (void*)fixedList32Bytes.Buffer;
			fixedList64Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList64Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005384 File Offset: 0x00003584
		public static bool operator !=(in FixedList64Bytes<T> a, in FixedList32Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00005390 File Offset: 0x00003590
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

		// Token: 0x06000178 RID: 376 RVA: 0x00005438 File Offset: 0x00003638
		public bool Equals(FixedList32Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00005444 File Offset: 0x00003644
		public FixedList64Bytes(in FixedList32Bytes<T> other)
		{
			this = default(FixedList64Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00005458 File Offset: 0x00003658
		internal unsafe int Initialize(in FixedList32Bytes<T> other)
		{
			FixedList32Bytes<T> fixedList32Bytes = other;
			if (fixedList32Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes62);
			void* destination = (void*)this.Buffer;
			fixedList32Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList32Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000054B6 File Offset: 0x000036B6
		public static implicit operator FixedList64Bytes<T>(in FixedList32Bytes<T> other)
		{
			return new FixedList64Bytes<T>(ref other);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000054C0 File Offset: 0x000036C0
		public unsafe static bool operator ==(in FixedList64Bytes<T> a, in FixedList64Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList64Bytes<T> fixedList64Bytes = a;
			void* ptr = (void*)fixedList64Bytes.Buffer;
			fixedList64Bytes = b;
			void* ptr2 = (void*)fixedList64Bytes.Buffer;
			fixedList64Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList64Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005510 File Offset: 0x00003710
		public static bool operator !=(in FixedList64Bytes<T> a, in FixedList64Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000551C File Offset: 0x0000371C
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

		// Token: 0x0600017F RID: 383 RVA: 0x000055C4 File Offset: 0x000037C4
		public bool Equals(FixedList64Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000055D0 File Offset: 0x000037D0
		public unsafe static bool operator ==(in FixedList64Bytes<T> a, in FixedList128Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList64Bytes<T> fixedList64Bytes = a;
			void* ptr = (void*)fixedList64Bytes.Buffer;
			FixedList128Bytes<T> fixedList128Bytes = b;
			void* ptr2 = (void*)fixedList128Bytes.Buffer;
			fixedList64Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList64Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005620 File Offset: 0x00003820
		public static bool operator !=(in FixedList64Bytes<T> a, in FixedList128Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000562C File Offset: 0x0000382C
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

		// Token: 0x06000183 RID: 387 RVA: 0x000056D4 File Offset: 0x000038D4
		public bool Equals(FixedList128Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000056E0 File Offset: 0x000038E0
		public FixedList64Bytes(in FixedList128Bytes<T> other)
		{
			this = default(FixedList64Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000056F4 File Offset: 0x000038F4
		internal unsafe int Initialize(in FixedList128Bytes<T> other)
		{
			FixedList128Bytes<T> fixedList128Bytes = other;
			if (fixedList128Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes62);
			void* destination = (void*)this.Buffer;
			fixedList128Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList128Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00005752 File Offset: 0x00003952
		public static implicit operator FixedList64Bytes<T>(in FixedList128Bytes<T> other)
		{
			return new FixedList64Bytes<T>(ref other);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000575C File Offset: 0x0000395C
		public unsafe static bool operator ==(in FixedList64Bytes<T> a, in FixedList512Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList64Bytes<T> fixedList64Bytes = a;
			void* ptr = (void*)fixedList64Bytes.Buffer;
			FixedList512Bytes<T> fixedList512Bytes = b;
			void* ptr2 = (void*)fixedList512Bytes.Buffer;
			fixedList64Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList64Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000057AC File Offset: 0x000039AC
		public static bool operator !=(in FixedList64Bytes<T> a, in FixedList512Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000057B8 File Offset: 0x000039B8
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

		// Token: 0x0600018A RID: 394 RVA: 0x00005860 File Offset: 0x00003A60
		public bool Equals(FixedList512Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000586C File Offset: 0x00003A6C
		public FixedList64Bytes(in FixedList512Bytes<T> other)
		{
			this = default(FixedList64Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00005880 File Offset: 0x00003A80
		internal unsafe int Initialize(in FixedList512Bytes<T> other)
		{
			FixedList512Bytes<T> fixedList512Bytes = other;
			if (fixedList512Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes62);
			void* destination = (void*)this.Buffer;
			fixedList512Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList512Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000058DE File Offset: 0x00003ADE
		public static implicit operator FixedList64Bytes<T>(in FixedList512Bytes<T> other)
		{
			return new FixedList64Bytes<T>(ref other);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000058E8 File Offset: 0x00003AE8
		public unsafe static bool operator ==(in FixedList64Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList64Bytes<T> fixedList64Bytes = a;
			void* ptr = (void*)fixedList64Bytes.Buffer;
			FixedList4096Bytes<T> fixedList4096Bytes = b;
			void* ptr2 = (void*)fixedList4096Bytes.Buffer;
			fixedList64Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList64Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005938 File Offset: 0x00003B38
		public static bool operator !=(in FixedList64Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00005944 File Offset: 0x00003B44
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

		// Token: 0x06000191 RID: 401 RVA: 0x000059EC File Offset: 0x00003BEC
		public bool Equals(FixedList4096Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000059F8 File Offset: 0x00003BF8
		public FixedList64Bytes(in FixedList4096Bytes<T> other)
		{
			this = default(FixedList64Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005A0C File Offset: 0x00003C0C
		internal unsafe int Initialize(in FixedList4096Bytes<T> other)
		{
			FixedList4096Bytes<T> fixedList4096Bytes = other;
			if (fixedList4096Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes62);
			void* destination = (void*)this.Buffer;
			fixedList4096Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList4096Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00005A6A File Offset: 0x00003C6A
		public static implicit operator FixedList64Bytes<T>(in FixedList4096Bytes<T> other)
		{
			return new FixedList64Bytes<T>(ref other);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00005A74 File Offset: 0x00003C74
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

		// Token: 0x06000196 RID: 406 RVA: 0x00005AF7 File Offset: 0x00003CF7
		public FixedList64Bytes<T>.Enumerator GetEnumerator()
		{
			return new FixedList64Bytes<T>.Enumerator(ref this);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040000A0 RID: 160
		[SerializeField]
		internal ushort length;

		// Token: 0x040000A1 RID: 161
		[SerializeField]
		internal FixedBytes62 buffer;

		// Token: 0x02000039 RID: 57
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x06000199 RID: 409 RVA: 0x00005AFF File Offset: 0x00003CFF
			public Enumerator(ref FixedList64Bytes<T> list)
			{
				this.m_List = list;
				this.m_Index = -1;
			}

			// Token: 0x0600019A RID: 410 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x0600019B RID: 411 RVA: 0x00005B14 File Offset: 0x00003D14
			public bool MoveNext()
			{
				this.m_Index++;
				return this.m_Index < this.m_List.Length;
			}

			// Token: 0x0600019C RID: 412 RVA: 0x00005B37 File Offset: 0x00003D37
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x0600019D RID: 413 RVA: 0x00005B40 File Offset: 0x00003D40
			public T Current
			{
				get
				{
					return this.m_List[this.m_Index];
				}
			}

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x0600019E RID: 414 RVA: 0x00005B53 File Offset: 0x00003D53
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000A2 RID: 162
			private FixedList64Bytes<T> m_List;

			// Token: 0x040000A3 RID: 163
			private int m_Index;
		}
	}
}
