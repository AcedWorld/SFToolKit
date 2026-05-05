using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000121 RID: 289
	[BurstCompatible]
	public struct UnsafeStream : INativeDisposable, IDisposable
	{
		// Token: 0x06000AD5 RID: 2773 RVA: 0x00022205 File Offset: 0x00020405
		public UnsafeStream(int bufferCount, AllocatorManager.AllocatorHandle allocator)
		{
			UnsafeStream.AllocateBlock(out this, allocator);
			this.AllocateForEach(bufferCount);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00022218 File Offset: 0x00020418
		[NotBurstCompatible]
		public unsafe static JobHandle ScheduleConstruct<[IsUnmanaged] T>(out UnsafeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
		{
			UnsafeStream.AllocateBlock(out stream, allocator);
			return new UnsafeStream.ConstructJobList
			{
				List = (UntypedUnsafeList*)bufferCount.GetUnsafeList(),
				Container = stream
			}.Schedule(dependency);
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00022258 File Offset: 0x00020458
		[NotBurstCompatible]
		public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeArray<int> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator)
		{
			UnsafeStream.AllocateBlock(out stream, allocator);
			return new UnsafeStream.ConstructJob
			{
				Length = bufferCount,
				Container = stream
			}.Schedule(dependency);
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00022290 File Offset: 0x00020490
		internal unsafe static void AllocateBlock(out UnsafeStream stream, AllocatorManager.AllocatorHandle allocator)
		{
			int num = 128;
			int num2 = sizeof(UnsafeStreamBlockData) + sizeof(UnsafeStreamBlock*) * num;
			byte* ptr = (byte*)Memory.Unmanaged.Allocate((long)num2, 16, allocator);
			UnsafeUtility.MemClear((void*)ptr, (long)num2);
			UnsafeStreamBlockData* ptr2 = (UnsafeStreamBlockData*)ptr;
			stream.m_Block = ptr2;
			stream.m_Allocator = allocator;
			ptr2->Allocator = allocator;
			ptr2->BlockCount = num;
			ptr2->Blocks = (UnsafeStreamBlock**)(ptr + sizeof(UnsafeStreamBlockData));
			ptr2->Ranges = null;
			ptr2->RangeCount = 0;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00022304 File Offset: 0x00020504
		internal unsafe void AllocateForEach(int forEachCount)
		{
			long size = (long)(sizeof(UnsafeStreamRange) * forEachCount);
			this.m_Block->Ranges = (UnsafeStreamRange*)Memory.Unmanaged.Allocate(size, 16, this.m_Allocator);
			this.m_Block->RangeCount = forEachCount;
			UnsafeUtility.MemClear((void*)this.m_Block->Ranges, size);
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x00022354 File Offset: 0x00020554
		public unsafe bool IsEmpty()
		{
			if (!this.IsCreated)
			{
				return true;
			}
			for (int num = 0; num != this.m_Block->RangeCount; num++)
			{
				if (this.m_Block->Ranges[num].ElementCount > 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x000223A1 File Offset: 0x000205A1
		public bool IsCreated
		{
			get
			{
				return this.m_Block != null;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x000223B0 File Offset: 0x000205B0
		public unsafe int ForEachCount
		{
			get
			{
				return this.m_Block->RangeCount;
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000223BD File Offset: 0x000205BD
		public UnsafeStream.Reader AsReader()
		{
			return new UnsafeStream.Reader(ref this);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x000223C5 File Offset: 0x000205C5
		public UnsafeStream.Writer AsWriter()
		{
			return new UnsafeStream.Writer(ref this);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000223D0 File Offset: 0x000205D0
		public unsafe int Count()
		{
			int num = 0;
			for (int num2 = 0; num2 != this.m_Block->RangeCount; num2++)
			{
				num += this.m_Block->Ranges[num2].ElementCount;
			}
			return num;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00022414 File Offset: 0x00020614
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe NativeArray<T> ToNativeArray<T>(AllocatorManager.AllocatorHandle allocator) where T : struct
		{
			NativeArray<T> result = CollectionHelper.CreateNativeArray<T>(this.Count(), allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeStream.Reader reader = this.AsReader();
			int num = 0;
			for (int num2 = 0; num2 != reader.ForEachCount; num2++)
			{
				reader.BeginForEachIndex(num2);
				int remainingItemCount = reader.RemainingItemCount;
				for (int i = 0; i < remainingItemCount; i++)
				{
					result[num] = *reader.Read<T>();
					num++;
				}
				reader.EndForEachIndex();
			}
			return result;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x00022490 File Offset: 0x00020690
		private unsafe void Deallocate()
		{
			if (this.m_Block == null)
			{
				return;
			}
			for (int num = 0; num != this.m_Block->BlockCount; num++)
			{
				UnsafeStreamBlock* next;
				for (UnsafeStreamBlock* ptr = *(IntPtr*)(this.m_Block->Blocks + (IntPtr)num * (IntPtr)sizeof(UnsafeStreamBlock*) / (IntPtr)sizeof(UnsafeStreamBlock*)); ptr != null; ptr = next)
				{
					next = ptr->Next;
					Memory.Unmanaged.Free<UnsafeStreamBlock>(ptr, this.m_Allocator);
				}
			}
			Memory.Unmanaged.Free<UnsafeStreamRange>(this.m_Block->Ranges, this.m_Allocator);
			Memory.Unmanaged.Free<UnsafeStreamBlockData>(this.m_Block, this.m_Allocator);
			this.m_Block = null;
			this.m_Allocator = Allocator.None;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0002252C File Offset: 0x0002072C
		public void Dispose()
		{
			this.Deallocate();
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00022534 File Offset: 0x00020734
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			JobHandle result = new UnsafeStream.DisposeJob
			{
				Container = this
			}.Schedule(inputDeps);
			this.m_Block = null;
			return result;
		}

		// Token: 0x040003BA RID: 954
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeStreamBlockData* m_Block;

		// Token: 0x040003BB RID: 955
		internal AllocatorManager.AllocatorHandle m_Allocator;

		// Token: 0x02000122 RID: 290
		[BurstCompile]
		private struct DisposeJob : IJob
		{
			// Token: 0x06000AE4 RID: 2788 RVA: 0x00022565 File Offset: 0x00020765
			public void Execute()
			{
				this.Container.Deallocate();
			}

			// Token: 0x040003BC RID: 956
			public UnsafeStream Container;
		}

		// Token: 0x02000123 RID: 291
		[BurstCompile]
		private struct ConstructJobList : IJob
		{
			// Token: 0x06000AE5 RID: 2789 RVA: 0x00022572 File Offset: 0x00020772
			public unsafe void Execute()
			{
				this.Container.AllocateForEach(this.List->m_length);
			}

			// Token: 0x040003BD RID: 957
			public UnsafeStream Container;

			// Token: 0x040003BE RID: 958
			[ReadOnly]
			[NativeDisableUnsafePtrRestriction]
			public unsafe UntypedUnsafeList* List;
		}

		// Token: 0x02000124 RID: 292
		[BurstCompile]
		private struct ConstructJob : IJob
		{
			// Token: 0x06000AE6 RID: 2790 RVA: 0x0002258A File Offset: 0x0002078A
			public void Execute()
			{
				this.Container.AllocateForEach(this.Length[0]);
			}

			// Token: 0x040003BF RID: 959
			public UnsafeStream Container;

			// Token: 0x040003C0 RID: 960
			[ReadOnly]
			public NativeArray<int> Length;
		}

		// Token: 0x02000125 RID: 293
		[BurstCompatible]
		public struct Writer
		{
			// Token: 0x06000AE7 RID: 2791 RVA: 0x000225A4 File Offset: 0x000207A4
			internal Writer(ref UnsafeStream stream)
			{
				this.m_BlockStream = stream.m_Block;
				this.m_ForeachIndex = int.MinValue;
				this.m_ElementCount = -1;
				this.m_CurrentBlock = null;
				this.m_CurrentBlockEnd = null;
				this.m_CurrentPtr = null;
				this.m_FirstBlock = null;
				this.m_NumberOfBlocks = 0;
				this.m_FirstOffset = 0;
				this.m_ThreadIndex = 0;
			}

			// Token: 0x1700012D RID: 301
			// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x00022604 File Offset: 0x00020804
			public unsafe int ForEachCount
			{
				get
				{
					return this.m_BlockStream->RangeCount;
				}
			}

			// Token: 0x06000AE9 RID: 2793 RVA: 0x00022611 File Offset: 0x00020811
			public unsafe void BeginForEachIndex(int foreachIndex)
			{
				this.m_ForeachIndex = foreachIndex;
				this.m_ElementCount = 0;
				this.m_NumberOfBlocks = 0;
				this.m_FirstBlock = this.m_CurrentBlock;
				this.m_FirstOffset = (int)((long)((byte*)this.m_CurrentPtr - (byte*)this.m_CurrentBlock));
			}

			// Token: 0x06000AEA RID: 2794 RVA: 0x0002264C File Offset: 0x0002084C
			public unsafe void EndForEachIndex()
			{
				this.m_BlockStream->Ranges[this.m_ForeachIndex].ElementCount = this.m_ElementCount;
				this.m_BlockStream->Ranges[this.m_ForeachIndex].OffsetInFirstBlock = this.m_FirstOffset;
				this.m_BlockStream->Ranges[this.m_ForeachIndex].Block = this.m_FirstBlock;
				this.m_BlockStream->Ranges[this.m_ForeachIndex].LastOffset = (int)((long)((byte*)this.m_CurrentPtr - (byte*)this.m_CurrentBlock));
				this.m_BlockStream->Ranges[this.m_ForeachIndex].NumberOfBlocks = this.m_NumberOfBlocks;
			}

			// Token: 0x06000AEB RID: 2795 RVA: 0x0002271D File Offset: 0x0002091D
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void Write<T>(T value) where T : struct
			{
				*this.Allocate<T>() = value;
			}

			// Token: 0x06000AEC RID: 2796 RVA: 0x0002272C File Offset: 0x0002092C
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe ref T Allocate<T>() where T : struct
			{
				int size = UnsafeUtility.SizeOf<T>();
				return UnsafeUtility.AsRef<T>((void*)this.Allocate(size));
			}

			// Token: 0x06000AED RID: 2797 RVA: 0x0002274C File Offset: 0x0002094C
			public unsafe byte* Allocate(int size)
			{
				byte* currentPtr = this.m_CurrentPtr;
				this.m_CurrentPtr += size;
				if (this.m_CurrentPtr != this.m_CurrentBlockEnd)
				{
					UnsafeStreamBlock* currentBlock = this.m_CurrentBlock;
					this.m_CurrentBlock = this.m_BlockStream->Allocate(currentBlock, this.m_ThreadIndex);
					this.m_CurrentPtr = &this.m_CurrentBlock->Data.FixedElementField;
					if (this.m_FirstBlock == null)
					{
						this.m_FirstOffset = (int)((long)((byte*)this.m_CurrentPtr - (byte*)this.m_CurrentBlock));
						this.m_FirstBlock = this.m_CurrentBlock;
					}
					else
					{
						this.m_NumberOfBlocks++;
					}
					this.m_CurrentBlockEnd = (byte*)(this.m_CurrentBlock + 4096 / sizeof(UnsafeStreamBlock));
					currentPtr = this.m_CurrentPtr;
					this.m_CurrentPtr += size;
				}
				this.m_ElementCount++;
				return currentPtr;
			}

			// Token: 0x040003C1 RID: 961
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeStreamBlockData* m_BlockStream;

			// Token: 0x040003C2 RID: 962
			[NativeDisableUnsafePtrRestriction]
			private unsafe UnsafeStreamBlock* m_CurrentBlock;

			// Token: 0x040003C3 RID: 963
			[NativeDisableUnsafePtrRestriction]
			private unsafe byte* m_CurrentPtr;

			// Token: 0x040003C4 RID: 964
			[NativeDisableUnsafePtrRestriction]
			private unsafe byte* m_CurrentBlockEnd;

			// Token: 0x040003C5 RID: 965
			internal int m_ForeachIndex;

			// Token: 0x040003C6 RID: 966
			private int m_ElementCount;

			// Token: 0x040003C7 RID: 967
			[NativeDisableUnsafePtrRestriction]
			private unsafe UnsafeStreamBlock* m_FirstBlock;

			// Token: 0x040003C8 RID: 968
			private int m_FirstOffset;

			// Token: 0x040003C9 RID: 969
			private int m_NumberOfBlocks;

			// Token: 0x040003CA RID: 970
			[NativeSetThreadIndex]
			private int m_ThreadIndex;
		}

		// Token: 0x02000126 RID: 294
		[BurstCompatible]
		public struct Reader
		{
			// Token: 0x06000AEE RID: 2798 RVA: 0x00022828 File Offset: 0x00020A28
			internal Reader(ref UnsafeStream stream)
			{
				this.m_BlockStream = stream.m_Block;
				this.m_CurrentBlock = null;
				this.m_CurrentPtr = null;
				this.m_CurrentBlockEnd = null;
				this.m_RemainingItemCount = 0;
				this.m_LastBlockSize = 0;
			}

			// Token: 0x06000AEF RID: 2799 RVA: 0x0002285C File Offset: 0x00020A5C
			public unsafe int BeginForEachIndex(int foreachIndex)
			{
				this.m_RemainingItemCount = this.m_BlockStream->Ranges[foreachIndex].ElementCount;
				this.m_LastBlockSize = this.m_BlockStream->Ranges[foreachIndex].LastOffset;
				this.m_CurrentBlock = this.m_BlockStream->Ranges[foreachIndex].Block;
				this.m_CurrentPtr = (byte*)(this.m_CurrentBlock + this.m_BlockStream->Ranges[foreachIndex].OffsetInFirstBlock / sizeof(UnsafeStreamBlock));
				this.m_CurrentBlockEnd = (byte*)(this.m_CurrentBlock + 4096 / sizeof(UnsafeStreamBlock));
				return this.m_RemainingItemCount;
			}

			// Token: 0x06000AF0 RID: 2800 RVA: 0x000024A3 File Offset: 0x000006A3
			public void EndForEachIndex()
			{
			}

			// Token: 0x1700012E RID: 302
			// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00022908 File Offset: 0x00020B08
			public unsafe int ForEachCount
			{
				get
				{
					return this.m_BlockStream->RangeCount;
				}
			}

			// Token: 0x1700012F RID: 303
			// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00022915 File Offset: 0x00020B15
			public int RemainingItemCount
			{
				get
				{
					return this.m_RemainingItemCount;
				}
			}

			// Token: 0x06000AF3 RID: 2803 RVA: 0x00022920 File Offset: 0x00020B20
			public unsafe byte* ReadUnsafePtr(int size)
			{
				this.m_RemainingItemCount--;
				byte* currentPtr = this.m_CurrentPtr;
				this.m_CurrentPtr += size;
				if (this.m_CurrentPtr != this.m_CurrentBlockEnd)
				{
					this.m_CurrentBlock = this.m_CurrentBlock->Next;
					this.m_CurrentPtr = &this.m_CurrentBlock->Data.FixedElementField;
					this.m_CurrentBlockEnd = (byte*)(this.m_CurrentBlock + 4096 / sizeof(UnsafeStreamBlock));
					currentPtr = this.m_CurrentPtr;
					this.m_CurrentPtr += size;
				}
				return currentPtr;
			}

			// Token: 0x06000AF4 RID: 2804 RVA: 0x000229B0 File Offset: 0x00020BB0
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe ref T Read<T>() where T : struct
			{
				int size = UnsafeUtility.SizeOf<T>();
				return UnsafeUtility.AsRef<T>((void*)this.ReadUnsafePtr(size));
			}

			// Token: 0x06000AF5 RID: 2805 RVA: 0x000229D0 File Offset: 0x00020BD0
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe ref T Peek<T>() where T : struct
			{
				int num = UnsafeUtility.SizeOf<T>();
				byte* ptr = this.m_CurrentPtr;
				if (ptr + num != this.m_CurrentBlockEnd)
				{
					ptr = &this.m_CurrentBlock->Next->Data.FixedElementField;
				}
				return UnsafeUtility.AsRef<T>((void*)ptr);
			}

			// Token: 0x06000AF6 RID: 2806 RVA: 0x00022A14 File Offset: 0x00020C14
			public unsafe int Count()
			{
				int num = 0;
				for (int num2 = 0; num2 != this.m_BlockStream->RangeCount; num2++)
				{
					num += this.m_BlockStream->Ranges[num2].ElementCount;
				}
				return num;
			}

			// Token: 0x040003CB RID: 971
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeStreamBlockData* m_BlockStream;

			// Token: 0x040003CC RID: 972
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeStreamBlock* m_CurrentBlock;

			// Token: 0x040003CD RID: 973
			[NativeDisableUnsafePtrRestriction]
			internal unsafe byte* m_CurrentPtr;

			// Token: 0x040003CE RID: 974
			[NativeDisableUnsafePtrRestriction]
			internal unsafe byte* m_CurrentBlockEnd;

			// Token: 0x040003CF RID: 975
			internal int m_RemainingItemCount;

			// Token: 0x040003D0 RID: 976
			internal int m_LastBlockSize;
		}
	}
}
