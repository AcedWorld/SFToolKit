using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000BA RID: 186
	[NativeContainer]
	[BurstCompatible]
	public struct NativeStream : IDisposable
	{
		// Token: 0x0600075F RID: 1887 RVA: 0x00018008 File Offset: 0x00016208
		public NativeStream(int bufferCount, AllocatorManager.AllocatorHandle allocator)
		{
			NativeStream.AllocateBlock(out this, allocator);
			this.m_Stream.AllocateForEach(bufferCount);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00018020 File Offset: 0x00016220
		[NotBurstCompatible]
		public unsafe static JobHandle ScheduleConstruct<[IsUnmanaged] T>(out NativeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
		{
			NativeStream.AllocateBlock(out stream, allocator);
			return new NativeStream.ConstructJobList
			{
				List = (UntypedUnsafeList*)bufferCount.GetUnsafeList(),
				Container = stream
			}.Schedule(dependency);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00018060 File Offset: 0x00016260
		[NotBurstCompatible]
		public static JobHandle ScheduleConstruct(out NativeStream stream, NativeArray<int> bufferCount, JobHandle dependency, AllocatorManager.AllocatorHandle allocator)
		{
			NativeStream.AllocateBlock(out stream, allocator);
			return new NativeStream.ConstructJob
			{
				Length = bufferCount,
				Container = stream
			}.Schedule(dependency);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00018098 File Offset: 0x00016298
		public bool IsEmpty()
		{
			return this.m_Stream.IsEmpty();
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x000180A5 File Offset: 0x000162A5
		public bool IsCreated
		{
			get
			{
				return this.m_Stream.IsCreated;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x000180B2 File Offset: 0x000162B2
		public int ForEachCount
		{
			get
			{
				return this.m_Stream.ForEachCount;
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x000180BF File Offset: 0x000162BF
		public NativeStream.Reader AsReader()
		{
			return new NativeStream.Reader(ref this);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000180C7 File Offset: 0x000162C7
		public NativeStream.Writer AsWriter()
		{
			return new NativeStream.Writer(ref this);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000180CF File Offset: 0x000162CF
		public int Count()
		{
			return this.m_Stream.Count();
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000180DC File Offset: 0x000162DC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public NativeArray<T> ToNativeArray<T>(AllocatorManager.AllocatorHandle allocator) where T : struct
		{
			return this.m_Stream.ToNativeArray<T>(allocator);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x000180EA File Offset: 0x000162EA
		public void Dispose()
		{
			this.m_Stream.Dispose();
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000180F7 File Offset: 0x000162F7
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return this.m_Stream.Dispose(inputDeps);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00018105 File Offset: 0x00016305
		private static void AllocateBlock(out NativeStream stream, AllocatorManager.AllocatorHandle allocator)
		{
			UnsafeStream.AllocateBlock(out stream.m_Stream, allocator);
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00018113 File Offset: 0x00016313
		private void AllocateForEach(int forEachCount)
		{
			this.m_Stream.AllocateForEach(forEachCount);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00018121 File Offset: 0x00016321
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckForEachCountGreaterThanZero(int forEachCount)
		{
			if (forEachCount <= 0)
			{
				throw new ArgumentException("foreachCount must be > 0", "foreachCount");
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReadAccess()
		{
		}

		// Token: 0x040002B6 RID: 694
		private UnsafeStream m_Stream;

		// Token: 0x020000BB RID: 187
		[BurstCompile]
		private struct ConstructJobList : IJob
		{
			// Token: 0x0600076F RID: 1903 RVA: 0x00018137 File Offset: 0x00016337
			public unsafe void Execute()
			{
				this.Container.AllocateForEach(this.List->m_length);
			}

			// Token: 0x040002B7 RID: 695
			public NativeStream Container;

			// Token: 0x040002B8 RID: 696
			[ReadOnly]
			[NativeDisableUnsafePtrRestriction]
			public unsafe UntypedUnsafeList* List;
		}

		// Token: 0x020000BC RID: 188
		[BurstCompile]
		private struct ConstructJob : IJob
		{
			// Token: 0x06000770 RID: 1904 RVA: 0x0001814F File Offset: 0x0001634F
			public void Execute()
			{
				this.Container.AllocateForEach(this.Length[0]);
			}

			// Token: 0x040002B9 RID: 697
			public NativeStream Container;

			// Token: 0x040002BA RID: 698
			[ReadOnly]
			public NativeArray<int> Length;
		}

		// Token: 0x020000BD RID: 189
		[NativeContainer]
		[NativeContainerSupportsMinMaxWriteRestriction]
		[BurstCompatible]
		public struct Writer
		{
			// Token: 0x06000771 RID: 1905 RVA: 0x00018168 File Offset: 0x00016368
			internal Writer(ref NativeStream stream)
			{
				this.m_Writer = stream.m_Stream.AsWriter();
			}

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x06000772 RID: 1906 RVA: 0x0001817B File Offset: 0x0001637B
			public int ForEachCount
			{
				get
				{
					return this.m_Writer.ForEachCount;
				}
			}

			// Token: 0x06000773 RID: 1907 RVA: 0x000024A3 File Offset: 0x000006A3
			public void PatchMinMaxRange(int foreEachIndex)
			{
			}

			// Token: 0x06000774 RID: 1908 RVA: 0x00018188 File Offset: 0x00016388
			public void BeginForEachIndex(int foreachIndex)
			{
				this.m_Writer.BeginForEachIndex(foreachIndex);
			}

			// Token: 0x06000775 RID: 1909 RVA: 0x00018196 File Offset: 0x00016396
			public void EndForEachIndex()
			{
				this.m_Writer.EndForEachIndex();
			}

			// Token: 0x06000776 RID: 1910 RVA: 0x000181A3 File Offset: 0x000163A3
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe void Write<T>(T value) where T : struct
			{
				*this.Allocate<T>() = value;
			}

			// Token: 0x06000777 RID: 1911 RVA: 0x000181B4 File Offset: 0x000163B4
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe ref T Allocate<T>() where T : struct
			{
				int size = UnsafeUtility.SizeOf<T>();
				return UnsafeUtility.AsRef<T>((void*)this.Allocate(size));
			}

			// Token: 0x06000778 RID: 1912 RVA: 0x000181D3 File Offset: 0x000163D3
			public unsafe byte* Allocate(int size)
			{
				return this.m_Writer.Allocate(size);
			}

			// Token: 0x06000779 RID: 1913 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckBeginForEachIndex(int foreachIndex)
			{
			}

			// Token: 0x0600077A RID: 1914 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckEndForEachIndex()
			{
			}

			// Token: 0x0600077B RID: 1915 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckAllocateSize(int size)
			{
			}

			// Token: 0x040002BB RID: 699
			private UnsafeStream.Writer m_Writer;
		}

		// Token: 0x020000BE RID: 190
		[NativeContainer]
		[NativeContainerIsReadOnly]
		[BurstCompatible]
		public struct Reader
		{
			// Token: 0x0600077C RID: 1916 RVA: 0x000181E1 File Offset: 0x000163E1
			internal Reader(ref NativeStream stream)
			{
				this.m_Reader = stream.m_Stream.AsReader();
			}

			// Token: 0x0600077D RID: 1917 RVA: 0x000181F4 File Offset: 0x000163F4
			public int BeginForEachIndex(int foreachIndex)
			{
				return this.m_Reader.BeginForEachIndex(foreachIndex);
			}

			// Token: 0x0600077E RID: 1918 RVA: 0x00018202 File Offset: 0x00016402
			public void EndForEachIndex()
			{
				this.m_Reader.EndForEachIndex();
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x0600077F RID: 1919 RVA: 0x0001820F File Offset: 0x0001640F
			public int ForEachCount
			{
				get
				{
					return this.m_Reader.ForEachCount;
				}
			}

			// Token: 0x170000CD RID: 205
			// (get) Token: 0x06000780 RID: 1920 RVA: 0x0001821C File Offset: 0x0001641C
			public int RemainingItemCount
			{
				get
				{
					return this.m_Reader.RemainingItemCount;
				}
			}

			// Token: 0x06000781 RID: 1921 RVA: 0x0001822C File Offset: 0x0001642C
			public unsafe byte* ReadUnsafePtr(int size)
			{
				this.m_Reader.m_RemainingItemCount = this.m_Reader.m_RemainingItemCount - 1;
				byte* currentPtr = this.m_Reader.m_CurrentPtr;
				this.m_Reader.m_CurrentPtr = this.m_Reader.m_CurrentPtr + size;
				if (this.m_Reader.m_CurrentPtr != this.m_Reader.m_CurrentBlockEnd)
				{
					this.m_Reader.m_CurrentBlock = this.m_Reader.m_CurrentBlock->Next;
					this.m_Reader.m_CurrentPtr = &this.m_Reader.m_CurrentBlock->Data.FixedElementField;
					this.m_Reader.m_CurrentBlockEnd = (byte*)(this.m_Reader.m_CurrentBlock + 4096 / sizeof(UnsafeStreamBlock));
					currentPtr = this.m_Reader.m_CurrentPtr;
					this.m_Reader.m_CurrentPtr = this.m_Reader.m_CurrentPtr + size;
				}
				return currentPtr;
			}

			// Token: 0x06000782 RID: 1922 RVA: 0x000182F4 File Offset: 0x000164F4
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public unsafe ref T Read<T>() where T : struct
			{
				int size = UnsafeUtility.SizeOf<T>();
				return UnsafeUtility.AsRef<T>((void*)this.ReadUnsafePtr(size));
			}

			// Token: 0x06000783 RID: 1923 RVA: 0x00018313 File Offset: 0x00016513
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public ref T Peek<T>() where T : struct
			{
				UnsafeUtility.SizeOf<T>();
				return this.m_Reader.Peek<T>();
			}

			// Token: 0x06000784 RID: 1924 RVA: 0x00018326 File Offset: 0x00016526
			public int Count()
			{
				return this.m_Reader.Count();
			}

			// Token: 0x06000785 RID: 1925 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckNotReadingOutOfBounds(int size)
			{
			}

			// Token: 0x06000786 RID: 1926 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckRead()
			{
			}

			// Token: 0x06000787 RID: 1927 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckReadSize(int size)
			{
			}

			// Token: 0x06000788 RID: 1928 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckBeginForEachIndex(int forEachIndex)
			{
			}

			// Token: 0x06000789 RID: 1929 RVA: 0x00018333 File Offset: 0x00016533
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckEndForEachIndex()
			{
				if (this.m_Reader.m_RemainingItemCount != 0)
				{
					throw new ArgumentException("Not all elements (Count) have been read. If this is intentional, simply skip calling EndForEachIndex();");
				}
				if (this.m_Reader.m_CurrentBlockEnd != this.m_Reader.m_CurrentPtr)
				{
					throw new ArgumentException("Not all data (Data Size) has been read. If this is intentional, simply skip calling EndForEachIndex();");
				}
			}

			// Token: 0x040002BC RID: 700
			private UnsafeStream.Reader m_Reader;
		}
	}
}
