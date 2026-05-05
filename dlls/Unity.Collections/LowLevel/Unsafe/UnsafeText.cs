using System;
using System.Diagnostics;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000128 RID: 296
	[BurstCompatible]
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	public struct UnsafeText : INativeDisposable, IDisposable, IUTF8Bytes, INativeList<byte>, IIndexable<byte>
	{
		// Token: 0x06000AF8 RID: 2808 RVA: 0x00022A64 File Offset: 0x00020C64
		public unsafe UnsafeText(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this.m_UntypedListData = default(UntypedUnsafeList);
			*ref this.AsUnsafeListOfBytes() = new UnsafeList<byte>(capacity + 1, allocator, NativeArrayOptions.UninitializedMemory);
			this.Length = 0;
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00022A8E File Offset: 0x00020C8E
		public bool IsCreated
		{
			get
			{
				return ref this.AsUnsafeListOfBytes().IsCreated;
			}
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00022A9B File Offset: 0x00020C9B
		public void Dispose()
		{
			ref this.AsUnsafeListOfBytes().Dispose();
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00022AA8 File Offset: 0x00020CA8
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return ref this.AsUnsafeListOfBytes().Dispose(inputDeps);
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x00022AB6 File Offset: 0x00020CB6
		public bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.Length == 0;
			}
		}

		// Token: 0x17000132 RID: 306
		public byte this[int index]
		{
			get
			{
				return UnsafeUtility.ReadArrayElement<byte>(this.m_UntypedListData.Ptr, index);
			}
			set
			{
				UnsafeUtility.WriteArrayElement<byte>(this.m_UntypedListData.Ptr, index, value);
			}
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00022AF2 File Offset: 0x00020CF2
		public ref byte ElementAt(int index)
		{
			return UnsafeUtility.ArrayElementAsRef<byte>(this.m_UntypedListData.Ptr, index);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00022B05 File Offset: 0x00020D05
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00022B0E File Offset: 0x00020D0E
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)this.m_UntypedListData.Ptr;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00022B1B File Offset: 0x00020D1B
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			ref this.AsUnsafeListOfBytes().Resize(newLength + 1, clearOptions);
			ref this.AsUnsafeListOfBytes()[newLength] = 0;
			return true;
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x00022B3A File Offset: 0x00020D3A
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x00022B49 File Offset: 0x00020D49
		public int Capacity
		{
			get
			{
				return ref this.AsUnsafeListOfBytes().Capacity - 1;
			}
			set
			{
				ref this.AsUnsafeListOfBytes().SetCapacity(value + 1);
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00022B59 File Offset: 0x00020D59
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00022B68 File Offset: 0x00020D68
		public int Length
		{
			get
			{
				return ref this.AsUnsafeListOfBytes().Length - 1;
			}
			set
			{
				ref this.AsUnsafeListOfBytes().Resize(value + 1, NativeArrayOptions.UninitializedMemory);
				ref this.AsUnsafeListOfBytes()[value] = 0;
			}
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00022B86 File Offset: 0x00020D86
		[NotBurstCompatible]
		public override string ToString()
		{
			if (!this.IsCreated)
			{
				return "";
			}
			return ref this.ConvertToString<UnsafeText>();
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00022B9C File Offset: 0x00020D9C
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= this.Length)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in UnsafeText of {1} length.", index, this.Length));
			}
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00022BED File Offset: 0x00020DED
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ThrowCopyError(CopyError error, string source)
		{
			throw new ArgumentException(string.Format("UnsafeText: {0} while copying \"{1}\"", error, source));
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00022C05 File Offset: 0x00020E05
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCapacityInRange(int value, int length)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value {0} must be positive.", value));
			}
			if (value < length)
			{
				throw new ArgumentOutOfRangeException(string.Format("Value {0} is out of range in NativeList of '{1}' Length.", value, length));
			}
		}

		// Token: 0x040003D1 RID: 977
		internal UntypedUnsafeList m_UntypedListData;
	}
}
