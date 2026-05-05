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
	// Token: 0x02000042 RID: 66
	[DebuggerTypeProxy(typeof(FixedList512BytesDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	[Serializable]
	public struct FixedList512Bytes<[IsUnmanaged] T> : INativeList<T>, IIndexable<T>, IEnumerable<!0>, IEnumerable, IEquatable<FixedList32Bytes<T>>, IComparable<FixedList32Bytes<T>>, IEquatable<FixedList64Bytes<T>>, IComparable<FixedList64Bytes<T>>, IEquatable<FixedList128Bytes<T>>, IComparable<FixedList128Bytes<T>>, IEquatable<FixedList512Bytes<T>>, IComparable<FixedList512Bytes<T>>, IEquatable<FixedList4096Bytes<T>>, IComparable<FixedList4096Bytes<T>> where T : struct, ValueType
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000067A3 File Offset: 0x000049A3
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000067AB File Offset: 0x000049AB
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

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000067B5 File Offset: 0x000049B5
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000067BD File Offset: 0x000049BD
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000067C8 File Offset: 0x000049C8
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000067D8 File Offset: 0x000049D8
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000067FE File Offset: 0x000049FE
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<FixedBytes510, T>();
			}
			set
			{
			}
		}

		// Token: 0x1700004C RID: 76
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

		// Token: 0x060001FA RID: 506 RVA: 0x0000682C File Offset: 0x00004A2C
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000683A File Offset: 0x00004A3A
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006850 File Offset: 0x00004A50
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000687C File Offset: 0x00004A7C
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000068BE File Offset: 0x00004ABE
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000068C7 File Offset: 0x00004AC7
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000068D1 File Offset: 0x00004AD1
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000068DC File Offset: 0x00004ADC
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

		// Token: 0x06000202 RID: 514 RVA: 0x0000693A File Offset: 0x00004B3A
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00006953 File Offset: 0x00004B53
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00006960 File Offset: 0x00004B60
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

		// Token: 0x06000205 RID: 517 RVA: 0x000069BE File Offset: 0x00004BBE
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000069CA File Offset: 0x00004BCA
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000069D4 File Offset: 0x00004BD4
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

		// Token: 0x06000208 RID: 520 RVA: 0x00006A30 File Offset: 0x00004C30
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00006A3C File Offset: 0x00004C3C
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

		// Token: 0x0600020A RID: 522 RVA: 0x00006A83 File Offset: 0x00004C83
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00006AAC File Offset: 0x00004CAC
		public unsafe static bool operator ==(in FixedList512Bytes<T> a, in FixedList32Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList512Bytes<T> fixedList512Bytes = a;
			void* ptr = (void*)fixedList512Bytes.Buffer;
			FixedList32Bytes<T> fixedList32Bytes = b;
			void* ptr2 = (void*)fixedList32Bytes.Buffer;
			fixedList512Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList512Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00006AFC File Offset: 0x00004CFC
		public static bool operator !=(in FixedList512Bytes<T> a, in FixedList32Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00006B08 File Offset: 0x00004D08
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

		// Token: 0x0600020E RID: 526 RVA: 0x00006BB0 File Offset: 0x00004DB0
		public bool Equals(FixedList32Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00006BBC File Offset: 0x00004DBC
		public FixedList512Bytes(in FixedList32Bytes<T> other)
		{
			this = default(FixedList512Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00006BD0 File Offset: 0x00004DD0
		internal unsafe int Initialize(in FixedList32Bytes<T> other)
		{
			FixedList32Bytes<T> fixedList32Bytes = other;
			if (fixedList32Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes510);
			void* destination = (void*)this.Buffer;
			fixedList32Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList32Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00006C2E File Offset: 0x00004E2E
		public static implicit operator FixedList512Bytes<T>(in FixedList32Bytes<T> other)
		{
			return new FixedList512Bytes<T>(ref other);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00006C38 File Offset: 0x00004E38
		public unsafe static bool operator ==(in FixedList512Bytes<T> a, in FixedList64Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList512Bytes<T> fixedList512Bytes = a;
			void* ptr = (void*)fixedList512Bytes.Buffer;
			FixedList64Bytes<T> fixedList64Bytes = b;
			void* ptr2 = (void*)fixedList64Bytes.Buffer;
			fixedList512Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList512Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00006C88 File Offset: 0x00004E88
		public static bool operator !=(in FixedList512Bytes<T> a, in FixedList64Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00006C94 File Offset: 0x00004E94
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

		// Token: 0x06000215 RID: 533 RVA: 0x00006D3C File Offset: 0x00004F3C
		public bool Equals(FixedList64Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00006D48 File Offset: 0x00004F48
		public FixedList512Bytes(in FixedList64Bytes<T> other)
		{
			this = default(FixedList512Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00006D5C File Offset: 0x00004F5C
		internal unsafe int Initialize(in FixedList64Bytes<T> other)
		{
			FixedList64Bytes<T> fixedList64Bytes = other;
			if (fixedList64Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes510);
			void* destination = (void*)this.Buffer;
			fixedList64Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList64Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00006DBA File Offset: 0x00004FBA
		public static implicit operator FixedList512Bytes<T>(in FixedList64Bytes<T> other)
		{
			return new FixedList512Bytes<T>(ref other);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00006DC4 File Offset: 0x00004FC4
		public unsafe static bool operator ==(in FixedList512Bytes<T> a, in FixedList128Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList512Bytes<T> fixedList512Bytes = a;
			void* ptr = (void*)fixedList512Bytes.Buffer;
			FixedList128Bytes<T> fixedList128Bytes = b;
			void* ptr2 = (void*)fixedList128Bytes.Buffer;
			fixedList512Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList512Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00006E14 File Offset: 0x00005014
		public static bool operator !=(in FixedList512Bytes<T> a, in FixedList128Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00006E20 File Offset: 0x00005020
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

		// Token: 0x0600021C RID: 540 RVA: 0x00006EC8 File Offset: 0x000050C8
		public bool Equals(FixedList128Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00006ED4 File Offset: 0x000050D4
		public FixedList512Bytes(in FixedList128Bytes<T> other)
		{
			this = default(FixedList512Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00006EE8 File Offset: 0x000050E8
		internal unsafe int Initialize(in FixedList128Bytes<T> other)
		{
			FixedList128Bytes<T> fixedList128Bytes = other;
			if (fixedList128Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes510);
			void* destination = (void*)this.Buffer;
			fixedList128Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList128Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00006F46 File Offset: 0x00005146
		public static implicit operator FixedList512Bytes<T>(in FixedList128Bytes<T> other)
		{
			return new FixedList512Bytes<T>(ref other);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00006F50 File Offset: 0x00005150
		public unsafe static bool operator ==(in FixedList512Bytes<T> a, in FixedList512Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList512Bytes<T> fixedList512Bytes = a;
			void* ptr = (void*)fixedList512Bytes.Buffer;
			fixedList512Bytes = b;
			void* ptr2 = (void*)fixedList512Bytes.Buffer;
			fixedList512Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList512Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00006FA0 File Offset: 0x000051A0
		public static bool operator !=(in FixedList512Bytes<T> a, in FixedList512Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00006FAC File Offset: 0x000051AC
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

		// Token: 0x06000223 RID: 547 RVA: 0x00007054 File Offset: 0x00005254
		public bool Equals(FixedList512Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00007060 File Offset: 0x00005260
		public unsafe static bool operator ==(in FixedList512Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList512Bytes<T> fixedList512Bytes = a;
			void* ptr = (void*)fixedList512Bytes.Buffer;
			FixedList4096Bytes<T> fixedList4096Bytes = b;
			void* ptr2 = (void*)fixedList4096Bytes.Buffer;
			fixedList512Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList512Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000070B0 File Offset: 0x000052B0
		public static bool operator !=(in FixedList512Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000070BC File Offset: 0x000052BC
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

		// Token: 0x06000227 RID: 551 RVA: 0x00007164 File Offset: 0x00005364
		public bool Equals(FixedList4096Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00007170 File Offset: 0x00005370
		public FixedList512Bytes(in FixedList4096Bytes<T> other)
		{
			this = default(FixedList512Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00007184 File Offset: 0x00005384
		internal unsafe int Initialize(in FixedList4096Bytes<T> other)
		{
			FixedList4096Bytes<T> fixedList4096Bytes = other;
			if (fixedList4096Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes510);
			void* destination = (void*)this.Buffer;
			fixedList4096Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList4096Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000071E2 File Offset: 0x000053E2
		public static implicit operator FixedList512Bytes<T>(in FixedList4096Bytes<T> other)
		{
			return new FixedList512Bytes<T>(ref other);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000071EC File Offset: 0x000053EC
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

		// Token: 0x0600022C RID: 556 RVA: 0x0000726F File Offset: 0x0000546F
		public FixedList512Bytes<T>.Enumerator GetEnumerator()
		{
			return new FixedList512Bytes<T>.Enumerator(ref this);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040000AA RID: 170
		[SerializeField]
		internal ushort length;

		// Token: 0x040000AB RID: 171
		[SerializeField]
		internal FixedBytes510 buffer;

		// Token: 0x02000043 RID: 67
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x0600022F RID: 559 RVA: 0x00007277 File Offset: 0x00005477
			public Enumerator(ref FixedList512Bytes<T> list)
			{
				this.m_List = list;
				this.m_Index = -1;
			}

			// Token: 0x06000230 RID: 560 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000231 RID: 561 RVA: 0x0000728C File Offset: 0x0000548C
			public bool MoveNext()
			{
				this.m_Index++;
				return this.m_Index < this.m_List.Length;
			}

			// Token: 0x06000232 RID: 562 RVA: 0x000072AF File Offset: 0x000054AF
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x06000233 RID: 563 RVA: 0x000072B8 File Offset: 0x000054B8
			public T Current
			{
				get
				{
					return this.m_List[this.m_Index];
				}
			}

			// Token: 0x1700004E RID: 78
			// (get) Token: 0x06000234 RID: 564 RVA: 0x000072CB File Offset: 0x000054CB
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000AC RID: 172
			private FixedList512Bytes<T> m_List;

			// Token: 0x040000AD RID: 173
			private int m_Index;
		}
	}
}
