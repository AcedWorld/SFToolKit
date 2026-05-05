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
	// Token: 0x0200003D RID: 61
	[DebuggerTypeProxy(typeof(FixedList128BytesDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	[Serializable]
	public struct FixedList128Bytes<[IsUnmanaged] T> : INativeList<T>, IIndexable<T>, IEnumerable<!0>, IEnumerable, IEquatable<FixedList32Bytes<T>>, IComparable<FixedList32Bytes<T>>, IEquatable<FixedList64Bytes<T>>, IComparable<FixedList64Bytes<T>>, IEquatable<FixedList128Bytes<T>>, IComparable<FixedList128Bytes<T>>, IEquatable<FixedList512Bytes<T>>, IComparable<FixedList512Bytes<T>>, IEquatable<FixedList4096Bytes<T>>, IComparable<FixedList4096Bytes<T>> where T : struct, ValueType
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00005BE7 File Offset: 0x00003DE7
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00005BEF File Offset: 0x00003DEF
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

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00005BF9 File Offset: 0x00003DF9
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00005C01 File Offset: 0x00003E01
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00005C0C File Offset: 0x00003E0C
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00005C1C File Offset: 0x00003E1C
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

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00005C42 File Offset: 0x00003E42
		// (set) Token: 0x060001AC RID: 428 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<FixedBytes126, T>();
			}
			set
			{
			}
		}

		// Token: 0x17000042 RID: 66
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

		// Token: 0x060001AF RID: 431 RVA: 0x00005C70 File Offset: 0x00003E70
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00005C7E File Offset: 0x00003E7E
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00005C94 File Offset: 0x00003E94
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00005CC0 File Offset: 0x00003EC0
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00005D02 File Offset: 0x00003F02
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005D0B File Offset: 0x00003F0B
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00005D15 File Offset: 0x00003F15
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00005D20 File Offset: 0x00003F20
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

		// Token: 0x060001B7 RID: 439 RVA: 0x00005D7E File Offset: 0x00003F7E
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00005D97 File Offset: 0x00003F97
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005DA4 File Offset: 0x00003FA4
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

		// Token: 0x060001BA RID: 442 RVA: 0x00005E02 File Offset: 0x00004002
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00005E0E File Offset: 0x0000400E
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00005E18 File Offset: 0x00004018
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

		// Token: 0x060001BD RID: 445 RVA: 0x00005E74 File Offset: 0x00004074
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00005E80 File Offset: 0x00004080
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

		// Token: 0x060001BF RID: 447 RVA: 0x00005EC7 File Offset: 0x000040C7
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00005EF0 File Offset: 0x000040F0
		public unsafe static bool operator ==(in FixedList128Bytes<T> a, in FixedList32Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList128Bytes<T> fixedList128Bytes = a;
			void* ptr = (void*)fixedList128Bytes.Buffer;
			FixedList32Bytes<T> fixedList32Bytes = b;
			void* ptr2 = (void*)fixedList32Bytes.Buffer;
			fixedList128Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList128Bytes.LengthInBytes) == 0;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005F40 File Offset: 0x00004140
		public static bool operator !=(in FixedList128Bytes<T> a, in FixedList32Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00005F4C File Offset: 0x0000414C
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

		// Token: 0x060001C3 RID: 451 RVA: 0x00005FF4 File Offset: 0x000041F4
		public bool Equals(FixedList32Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00006000 File Offset: 0x00004200
		public FixedList128Bytes(in FixedList32Bytes<T> other)
		{
			this = default(FixedList128Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00006014 File Offset: 0x00004214
		internal unsafe int Initialize(in FixedList32Bytes<T> other)
		{
			FixedList32Bytes<T> fixedList32Bytes = other;
			if (fixedList32Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes126);
			void* destination = (void*)this.Buffer;
			fixedList32Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList32Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00006072 File Offset: 0x00004272
		public static implicit operator FixedList128Bytes<T>(in FixedList32Bytes<T> other)
		{
			return new FixedList128Bytes<T>(ref other);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000607C File Offset: 0x0000427C
		public unsafe static bool operator ==(in FixedList128Bytes<T> a, in FixedList64Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList128Bytes<T> fixedList128Bytes = a;
			void* ptr = (void*)fixedList128Bytes.Buffer;
			FixedList64Bytes<T> fixedList64Bytes = b;
			void* ptr2 = (void*)fixedList64Bytes.Buffer;
			fixedList128Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList128Bytes.LengthInBytes) == 0;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000060CC File Offset: 0x000042CC
		public static bool operator !=(in FixedList128Bytes<T> a, in FixedList64Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000060D8 File Offset: 0x000042D8
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

		// Token: 0x060001CA RID: 458 RVA: 0x00006180 File Offset: 0x00004380
		public bool Equals(FixedList64Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000618C File Offset: 0x0000438C
		public FixedList128Bytes(in FixedList64Bytes<T> other)
		{
			this = default(FixedList128Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000061A0 File Offset: 0x000043A0
		internal unsafe int Initialize(in FixedList64Bytes<T> other)
		{
			FixedList64Bytes<T> fixedList64Bytes = other;
			if (fixedList64Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes126);
			void* destination = (void*)this.Buffer;
			fixedList64Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList64Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000061FE File Offset: 0x000043FE
		public static implicit operator FixedList128Bytes<T>(in FixedList64Bytes<T> other)
		{
			return new FixedList128Bytes<T>(ref other);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00006208 File Offset: 0x00004408
		public unsafe static bool operator ==(in FixedList128Bytes<T> a, in FixedList128Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList128Bytes<T> fixedList128Bytes = a;
			void* ptr = (void*)fixedList128Bytes.Buffer;
			fixedList128Bytes = b;
			void* ptr2 = (void*)fixedList128Bytes.Buffer;
			fixedList128Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList128Bytes.LengthInBytes) == 0;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00006258 File Offset: 0x00004458
		public static bool operator !=(in FixedList128Bytes<T> a, in FixedList128Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00006264 File Offset: 0x00004464
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

		// Token: 0x060001D1 RID: 465 RVA: 0x0000630C File Offset: 0x0000450C
		public bool Equals(FixedList128Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00006318 File Offset: 0x00004518
		public unsafe static bool operator ==(in FixedList128Bytes<T> a, in FixedList512Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList128Bytes<T> fixedList128Bytes = a;
			void* ptr = (void*)fixedList128Bytes.Buffer;
			FixedList512Bytes<T> fixedList512Bytes = b;
			void* ptr2 = (void*)fixedList512Bytes.Buffer;
			fixedList128Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList128Bytes.LengthInBytes) == 0;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00006368 File Offset: 0x00004568
		public static bool operator !=(in FixedList128Bytes<T> a, in FixedList512Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00006374 File Offset: 0x00004574
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

		// Token: 0x060001D5 RID: 469 RVA: 0x0000641C File Offset: 0x0000461C
		public bool Equals(FixedList512Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00006428 File Offset: 0x00004628
		public FixedList128Bytes(in FixedList512Bytes<T> other)
		{
			this = default(FixedList128Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000643C File Offset: 0x0000463C
		internal unsafe int Initialize(in FixedList512Bytes<T> other)
		{
			FixedList512Bytes<T> fixedList512Bytes = other;
			if (fixedList512Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes126);
			void* destination = (void*)this.Buffer;
			fixedList512Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList512Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000649A File Offset: 0x0000469A
		public static implicit operator FixedList128Bytes<T>(in FixedList512Bytes<T> other)
		{
			return new FixedList128Bytes<T>(ref other);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000064A4 File Offset: 0x000046A4
		public unsafe static bool operator ==(in FixedList128Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList128Bytes<T> fixedList128Bytes = a;
			void* ptr = (void*)fixedList128Bytes.Buffer;
			FixedList4096Bytes<T> fixedList4096Bytes = b;
			void* ptr2 = (void*)fixedList4096Bytes.Buffer;
			fixedList128Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList128Bytes.LengthInBytes) == 0;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000064F4 File Offset: 0x000046F4
		public static bool operator !=(in FixedList128Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00006500 File Offset: 0x00004700
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

		// Token: 0x060001DC RID: 476 RVA: 0x000065A8 File Offset: 0x000047A8
		public bool Equals(FixedList4096Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000065B4 File Offset: 0x000047B4
		public FixedList128Bytes(in FixedList4096Bytes<T> other)
		{
			this = default(FixedList128Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000065C8 File Offset: 0x000047C8
		internal unsafe int Initialize(in FixedList4096Bytes<T> other)
		{
			FixedList4096Bytes<T> fixedList4096Bytes = other;
			if (fixedList4096Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes126);
			void* destination = (void*)this.Buffer;
			fixedList4096Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList4096Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00006626 File Offset: 0x00004826
		public static implicit operator FixedList128Bytes<T>(in FixedList4096Bytes<T> other)
		{
			return new FixedList128Bytes<T>(ref other);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00006630 File Offset: 0x00004830
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

		// Token: 0x060001E1 RID: 481 RVA: 0x000066B3 File Offset: 0x000048B3
		public FixedList128Bytes<T>.Enumerator GetEnumerator()
		{
			return new FixedList128Bytes<T>.Enumerator(ref this);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040000A5 RID: 165
		[SerializeField]
		internal ushort length;

		// Token: 0x040000A6 RID: 166
		[SerializeField]
		internal FixedBytes126 buffer;

		// Token: 0x0200003E RID: 62
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x060001E4 RID: 484 RVA: 0x000066BB File Offset: 0x000048BB
			public Enumerator(ref FixedList128Bytes<T> list)
			{
				this.m_List = list;
				this.m_Index = -1;
			}

			// Token: 0x060001E5 RID: 485 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060001E6 RID: 486 RVA: 0x000066D0 File Offset: 0x000048D0
			public bool MoveNext()
			{
				this.m_Index++;
				return this.m_Index < this.m_List.Length;
			}

			// Token: 0x060001E7 RID: 487 RVA: 0x000066F3 File Offset: 0x000048F3
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060001E8 RID: 488 RVA: 0x000066FC File Offset: 0x000048FC
			public T Current
			{
				get
				{
					return this.m_List[this.m_Index];
				}
			}

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000670F File Offset: 0x0000490F
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000A7 RID: 167
			private FixedList128Bytes<T> m_List;

			// Token: 0x040000A8 RID: 168
			private int m_Index;
		}
	}
}
