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
	// Token: 0x02000033 RID: 51
	[DebuggerTypeProxy(typeof(FixedList32BytesDebugView<>))]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	[Serializable]
	public struct FixedList32Bytes<[IsUnmanaged] T> : INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable, IEquatable<FixedList32Bytes<T>>, IComparable<FixedList32Bytes<T>>, IEquatable<FixedList64Bytes<T>>, IComparable<FixedList64Bytes<T>>, IEquatable<FixedList128Bytes<T>>, IComparable<FixedList128Bytes<T>>, IEquatable<FixedList512Bytes<T>>, IComparable<FixedList512Bytes<T>>, IEquatable<FixedList4096Bytes<T>>, IComparable<FixedList4096Bytes<T>> where T : struct, ValueType
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004467 File Offset: 0x00002667
		// (set) Token: 0x06000110 RID: 272 RVA: 0x0000446F File Offset: 0x0000266F
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004479 File Offset: 0x00002679
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00004481 File Offset: 0x00002681
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0000448C File Offset: 0x0000268C
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0000449C File Offset: 0x0000269C
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

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000044C2 File Offset: 0x000026C2
		// (set) Token: 0x06000116 RID: 278 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<FixedBytes30, T>();
			}
			set
			{
			}
		}

		// Token: 0x1700002E RID: 46
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

		// Token: 0x06000119 RID: 281 RVA: 0x000044F0 File Offset: 0x000026F0
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000044FE File Offset: 0x000026FE
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004514 File Offset: 0x00002714
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004540 File Offset: 0x00002740
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004582 File Offset: 0x00002782
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000458B File Offset: 0x0000278B
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004595 File Offset: 0x00002795
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000045A0 File Offset: 0x000027A0
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

		// Token: 0x06000121 RID: 289 RVA: 0x000045FE File Offset: 0x000027FE
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004617 File Offset: 0x00002817
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004624 File Offset: 0x00002824
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

		// Token: 0x06000124 RID: 292 RVA: 0x00004682 File Offset: 0x00002882
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000468E File Offset: 0x0000288E
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004698 File Offset: 0x00002898
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

		// Token: 0x06000127 RID: 295 RVA: 0x000046F4 File Offset: 0x000028F4
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004700 File Offset: 0x00002900
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

		// Token: 0x06000129 RID: 297 RVA: 0x00004747 File Offset: 0x00002947
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004770 File Offset: 0x00002970
		public unsafe static bool operator ==(in FixedList32Bytes<T> a, in FixedList32Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList32Bytes<T> fixedList32Bytes = a;
			void* ptr = (void*)fixedList32Bytes.Buffer;
			fixedList32Bytes = b;
			void* ptr2 = (void*)fixedList32Bytes.Buffer;
			fixedList32Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList32Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000047C0 File Offset: 0x000029C0
		public static bool operator !=(in FixedList32Bytes<T> a, in FixedList32Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000047CC File Offset: 0x000029CC
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

		// Token: 0x0600012D RID: 301 RVA: 0x00004874 File Offset: 0x00002A74
		public bool Equals(FixedList32Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004880 File Offset: 0x00002A80
		public unsafe static bool operator ==(in FixedList32Bytes<T> a, in FixedList64Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList32Bytes<T> fixedList32Bytes = a;
			void* ptr = (void*)fixedList32Bytes.Buffer;
			FixedList64Bytes<T> fixedList64Bytes = b;
			void* ptr2 = (void*)fixedList64Bytes.Buffer;
			fixedList32Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList32Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000048D0 File Offset: 0x00002AD0
		public static bool operator !=(in FixedList32Bytes<T> a, in FixedList64Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000048DC File Offset: 0x00002ADC
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

		// Token: 0x06000131 RID: 305 RVA: 0x00004984 File Offset: 0x00002B84
		public bool Equals(FixedList64Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004990 File Offset: 0x00002B90
		public FixedList32Bytes(in FixedList64Bytes<T> other)
		{
			this = default(FixedList32Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000049A4 File Offset: 0x00002BA4
		internal unsafe int Initialize(in FixedList64Bytes<T> other)
		{
			FixedList64Bytes<T> fixedList64Bytes = other;
			if (fixedList64Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes30);
			void* destination = (void*)this.Buffer;
			fixedList64Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList64Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004A02 File Offset: 0x00002C02
		public static implicit operator FixedList32Bytes<T>(in FixedList64Bytes<T> other)
		{
			return new FixedList32Bytes<T>(ref other);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00004A0C File Offset: 0x00002C0C
		public unsafe static bool operator ==(in FixedList32Bytes<T> a, in FixedList128Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList32Bytes<T> fixedList32Bytes = a;
			void* ptr = (void*)fixedList32Bytes.Buffer;
			FixedList128Bytes<T> fixedList128Bytes = b;
			void* ptr2 = (void*)fixedList128Bytes.Buffer;
			fixedList32Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList32Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00004A5C File Offset: 0x00002C5C
		public static bool operator !=(in FixedList32Bytes<T> a, in FixedList128Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00004A68 File Offset: 0x00002C68
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

		// Token: 0x06000138 RID: 312 RVA: 0x00004B10 File Offset: 0x00002D10
		public bool Equals(FixedList128Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004B1C File Offset: 0x00002D1C
		public FixedList32Bytes(in FixedList128Bytes<T> other)
		{
			this = default(FixedList32Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004B30 File Offset: 0x00002D30
		internal unsafe int Initialize(in FixedList128Bytes<T> other)
		{
			FixedList128Bytes<T> fixedList128Bytes = other;
			if (fixedList128Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes30);
			void* destination = (void*)this.Buffer;
			fixedList128Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList128Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00004B8E File Offset: 0x00002D8E
		public static implicit operator FixedList32Bytes<T>(in FixedList128Bytes<T> other)
		{
			return new FixedList32Bytes<T>(ref other);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004B98 File Offset: 0x00002D98
		public unsafe static bool operator ==(in FixedList32Bytes<T> a, in FixedList512Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList32Bytes<T> fixedList32Bytes = a;
			void* ptr = (void*)fixedList32Bytes.Buffer;
			FixedList512Bytes<T> fixedList512Bytes = b;
			void* ptr2 = (void*)fixedList512Bytes.Buffer;
			fixedList32Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList32Bytes.LengthInBytes) == 0;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004BE8 File Offset: 0x00002DE8
		public static bool operator !=(in FixedList32Bytes<T> a, in FixedList512Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004BF4 File Offset: 0x00002DF4
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

		// Token: 0x0600013F RID: 319 RVA: 0x00004C9C File Offset: 0x00002E9C
		public bool Equals(FixedList512Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004CA8 File Offset: 0x00002EA8
		public FixedList32Bytes(in FixedList512Bytes<T> other)
		{
			this = default(FixedList32Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004CBC File Offset: 0x00002EBC
		internal unsafe int Initialize(in FixedList512Bytes<T> other)
		{
			FixedList512Bytes<T> fixedList512Bytes = other;
			if (fixedList512Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes30);
			void* destination = (void*)this.Buffer;
			fixedList512Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList512Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004D1A File Offset: 0x00002F1A
		public static implicit operator FixedList32Bytes<T>(in FixedList512Bytes<T> other)
		{
			return new FixedList32Bytes<T>(ref other);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004D24 File Offset: 0x00002F24
		public unsafe static bool operator ==(in FixedList32Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			if (a.length != b.length)
			{
				return false;
			}
			FixedList32Bytes<T> fixedList32Bytes = a;
			void* ptr = (void*)fixedList32Bytes.Buffer;
			FixedList4096Bytes<T> fixedList4096Bytes = b;
			void* ptr2 = (void*)fixedList4096Bytes.Buffer;
			fixedList32Bytes = a;
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)fixedList32Bytes.LengthInBytes) == 0;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004D74 File Offset: 0x00002F74
		public static bool operator !=(in FixedList32Bytes<T> a, in FixedList4096Bytes<T> b)
		{
			return !(a == b);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004D80 File Offset: 0x00002F80
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

		// Token: 0x06000146 RID: 326 RVA: 0x00004E28 File Offset: 0x00003028
		public bool Equals(FixedList4096Bytes<T> other)
		{
			return this.CompareTo(other) == 0;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004E34 File Offset: 0x00003034
		public FixedList32Bytes(in FixedList4096Bytes<T> other)
		{
			this = default(FixedList32Bytes<T>);
			this.Initialize(other);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004E48 File Offset: 0x00003048
		internal unsafe int Initialize(in FixedList4096Bytes<T> other)
		{
			FixedList4096Bytes<T> fixedList4096Bytes = other;
			if (fixedList4096Bytes.Length > this.Capacity)
			{
				return 1;
			}
			this.length = other.length;
			this.buffer = default(FixedBytes30);
			void* destination = (void*)this.Buffer;
			fixedList4096Bytes = other;
			UnsafeUtility.MemCpy(destination, (void*)fixedList4096Bytes.Buffer, (long)this.LengthInBytes);
			return 0;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004EA6 File Offset: 0x000030A6
		public static implicit operator FixedList32Bytes<T>(in FixedList4096Bytes<T> other)
		{
			return new FixedList32Bytes<T>(ref other);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004EB0 File Offset: 0x000030B0
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

		// Token: 0x0600014B RID: 331 RVA: 0x00004F33 File Offset: 0x00003133
		public FixedList32Bytes<T>.Enumerator GetEnumerator()
		{
			return new FixedList32Bytes<T>.Enumerator(ref this);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004F3B File Offset: 0x0000313B
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400009B RID: 155
		[SerializeField]
		internal ushort length;

		// Token: 0x0400009C RID: 156
		[SerializeField]
		internal FixedBytes30 buffer;

		// Token: 0x02000034 RID: 52
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x0600014E RID: 334 RVA: 0x00004F42 File Offset: 0x00003142
			public Enumerator(ref FixedList32Bytes<T> list)
			{
				this.m_List = list;
				this.m_Index = -1;
			}

			// Token: 0x0600014F RID: 335 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000150 RID: 336 RVA: 0x00004F57 File Offset: 0x00003157
			public bool MoveNext()
			{
				this.m_Index++;
				return this.m_Index < this.m_List.Length;
			}

			// Token: 0x06000151 RID: 337 RVA: 0x00004F7A File Offset: 0x0000317A
			public void Reset()
			{
				this.m_Index = -1;
			}

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x06000152 RID: 338 RVA: 0x00004F83 File Offset: 0x00003183
			public T Current
			{
				get
				{
					return this.m_List[this.m_Index];
				}
			}

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000153 RID: 339 RVA: 0x00004F96 File Offset: 0x00003196
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400009D RID: 157
			private FixedList32Bytes<T> m_List;

			// Token: 0x0400009E RID: 158
			private int m_Index;
		}
	}
}
