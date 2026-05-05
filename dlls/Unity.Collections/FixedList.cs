using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Collections
{
	// Token: 0x02000030 RID: 48
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(FixedBytes30)
	})]
	[Serializable]
	internal struct FixedList<[IsUnmanaged] T, [IsUnmanaged] U> : INativeList<T>, IIndexable<T> where T : struct, ValueType where U : struct, ValueType
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x000040FB File Offset: 0x000022FB
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00004103 File Offset: 0x00002303
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

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000410D File Offset: 0x0000230D
		[CreateProperty]
		private IEnumerable<T> Elements
		{
			get
			{
				return this.ToArray();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00004115 File Offset: 0x00002315
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00004120 File Offset: 0x00002320
		internal int LengthInBytes
		{
			get
			{
				return this.Length * UnsafeUtility.SizeOf<T>();
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00004130 File Offset: 0x00002330
		internal unsafe byte* Buffer
		{
			get
			{
				fixed (U* ptr = &this.buffer)
				{
					return (byte*)ptr + FixedList.PaddingBytes<T>();
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000414C File Offset: 0x0000234C
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return FixedList.Capacity<U, T>();
			}
			set
			{
			}
		}

		// Token: 0x17000027 RID: 39
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

		// Token: 0x060000FA RID: 250 RVA: 0x0000417A File Offset: 0x0000237A
		public unsafe ref T ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<T>((void*)this.Buffer, index);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004188 File Offset: 0x00002388
		public unsafe override int GetHashCode()
		{
			return (int)CollectionHelper.Hash((void*)this.Buffer, this.LengthInBytes);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000419C File Offset: 0x0000239C
		public void Add(in T item)
		{
			int num = this.Length;
			this.Length = num + 1;
			this[num] = item;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000041C8 File Offset: 0x000023C8
		public unsafe void AddRange(void* ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				int num = this.Length;
				this.Length = num + 1;
				this[num] = *(T*)((byte*)ptr + (IntPtr)i * (IntPtr)sizeof(T));
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000420A File Offset: 0x0000240A
		public void AddNoResize(in T item)
		{
			this.Add(item);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004213 File Offset: 0x00002413
		public unsafe void AddRangeNoResize(void* ptr, int length)
		{
			this.AddRange(ptr, length);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000421D File Offset: 0x0000241D
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004228 File Offset: 0x00002428
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

		// Token: 0x06000102 RID: 258 RVA: 0x00004286 File Offset: 0x00002486
		public void Insert(int index, in T item)
		{
			this.InsertRangeWithBeginEnd(index, index + 1);
			this[index] = item;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000429F File Offset: 0x0000249F
		public void RemoveAtSwapBack(int index)
		{
			this.RemoveRangeSwapBack(index, 1);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000042AC File Offset: 0x000024AC
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

		// Token: 0x06000105 RID: 261 RVA: 0x0000430A File Offset: 0x0000250A
		[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeSwapBackWithBeginEnd(int begin, int end)
		{
			this.RemoveRangeSwapBack(begin, end - begin);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004316 File Offset: 0x00002516
		public void RemoveAt(int index)
		{
			this.RemoveRange(index, 1);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004320 File Offset: 0x00002520
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

		// Token: 0x06000108 RID: 264 RVA: 0x0000437C File Offset: 0x0000257C
		[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", false)]
		public void RemoveRangeWithBeginEnd(int begin, int end)
		{
			this.RemoveRange(begin, end - begin);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004388 File Offset: 0x00002588
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

		// Token: 0x0600010A RID: 266 RVA: 0x000043CF File Offset: 0x000025CF
		public unsafe NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), (void*)this.Buffer, (long)this.LengthInBytes);
			return nativeArray;
		}

		// Token: 0x04000099 RID: 153
		[SerializeField]
		internal ushort length;

		// Token: 0x0400009A RID: 154
		[SerializeField]
		internal U buffer;
	}
}
