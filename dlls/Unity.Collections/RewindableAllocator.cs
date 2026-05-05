using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x020000C4 RID: 196
	[BurstCompile]
	public struct RewindableAllocator : AllocatorManager.IAllocator, IDisposable
	{
		// Token: 0x0600080C RID: 2060 RVA: 0x00019060 File Offset: 0x00017260
		public unsafe void Initialize(int initialSizeInBytes, bool enableBlockFree = false)
		{
			this.m_spinner = default(Spinner);
			this.m_block = new UnmanagedArray<RewindableAllocator.MemoryBlock>(64, Allocator.Persistent);
			*this.m_block[0] = new RewindableAllocator.MemoryBlock((long)initialSizeInBytes);
			this.m_last = (this.m_used = (this.m_best = 0));
			this.m_enableBlockFree = enableBlockFree;
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x000190C4 File Offset: 0x000172C4
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x000190CC File Offset: 0x000172CC
		public bool EnableBlockFree
		{
			get
			{
				return this.m_enableBlockFree;
			}
			set
			{
				this.m_enableBlockFree = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x000190D5 File Offset: 0x000172D5
		public int BlocksAllocated
		{
			get
			{
				return this.m_last + 1;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x000190DF File Offset: 0x000172DF
		public int InitialSizeInBytes
		{
			get
			{
				return (int)this.m_block[0].m_bytes;
			}
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x000190F4 File Offset: 0x000172F4
		public void Rewind()
		{
			if (JobsUtility.IsExecutingJob)
			{
				throw new InvalidOperationException("You cannot Rewind a RewindableAllocator from a Job.");
			}
			this.m_handle.Rewind();
			while (this.m_last > this.m_used)
			{
				int num = this.m_last;
				this.m_last = num - 1;
				this.m_block[num].Dispose();
			}
			while (this.m_used > 0)
			{
				int num = this.m_used;
				this.m_used = num - 1;
				this.m_block[num].Rewind();
			}
			this.m_block[0].Rewind();
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0001918C File Offset: 0x0001738C
		public void Dispose()
		{
			if (JobsUtility.IsExecutingJob)
			{
				throw new InvalidOperationException("You cannot Dispose a RewindableAllocator from a Job.");
			}
			this.m_used = 0;
			this.Rewind();
			this.m_block[0].Dispose();
			this.m_block.Dispose();
			this.m_last = (this.m_used = (this.m_best = 0));
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x000191ED File Offset: 0x000173ED
		[NotBurstCompatible]
		public AllocatorManager.TryFunction Function
		{
			get
			{
				return new AllocatorManager.TryFunction(RewindableAllocator.Try);
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x000191FC File Offset: 0x000173FC
		public unsafe int Try(ref AllocatorManager.Block block)
		{
			if (block.Range.Pointer == IntPtr.Zero)
			{
				int num = this.m_block[this.m_best].TryAllocate(ref block);
				if (num == 0)
				{
					return num;
				}
				this.m_spinner.Lock();
				int i;
				for (i = 0; i <= this.m_last; i++)
				{
					num = this.m_block[i].TryAllocate(ref block);
					if (num == 0)
					{
						this.m_used = ((i > this.m_used) ? i : this.m_used);
						this.m_best = i;
						this.m_spinner.Unlock();
						return num;
					}
				}
				long bytes = math.max(this.m_block[0].m_bytes << i, math.ceilpow2(block.Bytes));
				*this.m_block[i] = new RewindableAllocator.MemoryBlock(bytes);
				num = this.m_block[i].TryAllocate(ref block);
				this.m_best = i;
				this.m_used = i;
				this.m_last = i;
				this.m_spinner.Unlock();
				return num;
			}
			else
			{
				if (block.Range.Items == 0)
				{
					if (this.m_enableBlockFree)
					{
						this.m_spinner.Lock();
						if (this.m_block[this.m_best].Contains(block.Range.Pointer) && Interlocked.Decrement(ref this.m_block[this.m_best].m_allocations) == 0L)
						{
							this.m_block[this.m_best].Rewind();
						}
						this.m_spinner.Unlock();
					}
					return 0;
				}
				return -1;
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00019395 File Offset: 0x00017595
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		internal static int Try(IntPtr state, ref AllocatorManager.Block block)
		{
			return RewindableAllocator.Try_000006E8$BurstDirectCall.Invoke(state, ref block);
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0001939E File Offset: 0x0001759E
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x000193A6 File Offset: 0x000175A6
		public AllocatorManager.AllocatorHandle Handle
		{
			get
			{
				return this.m_handle;
			}
			set
			{
				this.m_handle = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x000193AF File Offset: 0x000175AF
		public Allocator ToAllocator
		{
			get
			{
				return this.m_handle.ToAllocator;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x000193BC File Offset: 0x000175BC
		public bool IsCustomAllocator
		{
			get
			{
				return this.m_handle.IsCustomAllocator;
			}
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x000193CC File Offset: 0x000175CC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public NativeArray<T> AllocateNativeArray<T>(int length) where T : struct
		{
			return new NativeArray<T>
			{
				m_Buffer = ref this.AllocateStruct(default(T), length),
				m_Length = length,
				m_AllocatorLabel = Allocator.None
			};
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0001940C File Offset: 0x0001760C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe NativeList<T> AllocateNativeList<[IsUnmanaged] T>(int capacity) where T : struct, ValueType
		{
			NativeList<T> nativeList = default(NativeList<T>);
			nativeList.m_ListData = ref this.Allocate(default(UnsafeList<T>), 1);
			nativeList.m_ListData->Ptr = ref this.Allocate(default(T), capacity);
			nativeList.m_ListData->m_capacity = capacity;
			nativeList.m_ListData->m_length = 0;
			nativeList.m_ListData->Allocator = Allocator.None;
			nativeList.m_DeprecatedAllocator = Allocator.None;
			return nativeList;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0001948A File Offset: 0x0001768A
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int Try$BurstManaged(IntPtr state, ref AllocatorManager.Block block)
		{
			return ((RewindableAllocator*)((void*)state))->Try(ref block);
		}

		// Token: 0x040002C6 RID: 710
		private Spinner m_spinner;

		// Token: 0x040002C7 RID: 711
		private AllocatorManager.AllocatorHandle m_handle;

		// Token: 0x040002C8 RID: 712
		private UnmanagedArray<RewindableAllocator.MemoryBlock> m_block;

		// Token: 0x040002C9 RID: 713
		private int m_best;

		// Token: 0x040002CA RID: 714
		private int m_last;

		// Token: 0x040002CB RID: 715
		private int m_used;

		// Token: 0x040002CC RID: 716
		private bool m_enableBlockFree;

		// Token: 0x020000C5 RID: 197
		[BurstCompatible]
		internal struct MemoryBlock : IDisposable
		{
			// Token: 0x0600081D RID: 2077 RVA: 0x00019498 File Offset: 0x00017698
			public unsafe MemoryBlock(long bytes)
			{
				this.m_pointer = (byte*)Memory.Unmanaged.Allocate(bytes, 16384, Allocator.Persistent);
				this.m_bytes = bytes;
				this.m_current = 0L;
				this.m_allocations = 0L;
			}

			// Token: 0x0600081E RID: 2078 RVA: 0x000194C8 File Offset: 0x000176C8
			public void Rewind()
			{
				this.m_current = 0L;
				this.m_allocations = 0L;
			}

			// Token: 0x0600081F RID: 2079 RVA: 0x000194DA File Offset: 0x000176DA
			public void Dispose()
			{
				Memory.Unmanaged.Free<byte>(this.m_pointer, Allocator.Persistent);
				this.m_pointer = null;
				this.m_bytes = 0L;
				this.m_current = 0L;
				this.m_allocations = 0L;
			}

			// Token: 0x06000820 RID: 2080 RVA: 0x00019510 File Offset: 0x00017710
			public unsafe int TryAllocate(ref AllocatorManager.Block block)
			{
				int num = math.max(64, block.Alignment);
				int num2 = (num != 64) ? 1 : 0;
				int num3 = 63;
				if (num2 == 1)
				{
					num = (num + num3 & ~num3);
				}
				long num4 = (long)num - 1L;
				long num5 = block.Bytes + (long)(num2 * num) + num4 & ~num4;
				long num6 = Interlocked.Add(ref this.m_current, num5) - num5;
				num6 = (num6 + num4 & ~num4);
				if (num6 + block.Bytes > this.m_bytes)
				{
					return -1;
				}
				block.Range.Pointer = (IntPtr)((void*)(this.m_pointer + num6));
				block.AllocatedItems = block.Range.Items;
				Interlocked.Increment(ref this.m_allocations);
				return 0;
			}

			// Token: 0x06000821 RID: 2081 RVA: 0x000195C4 File Offset: 0x000177C4
			public unsafe bool Contains(IntPtr ptr)
			{
				void* ptr2 = (void*)ptr;
				return ptr2 >= (void*)this.m_pointer && ptr2 < (void*)(this.m_pointer + this.m_current);
			}

			// Token: 0x040002CD RID: 717
			public const int kMaximumAlignment = 16384;

			// Token: 0x040002CE RID: 718
			public unsafe byte* m_pointer;

			// Token: 0x040002CF RID: 719
			public long m_bytes;

			// Token: 0x040002D0 RID: 720
			public long m_current;

			// Token: 0x040002D1 RID: 721
			public long m_allocations;
		}

		// Token: 0x020000C6 RID: 198
		// (Invoke) Token: 0x06000823 RID: 2083
		public delegate int Try_000006E8$PostfixBurstDelegate(IntPtr state, ref AllocatorManager.Block block);

		// Token: 0x020000C7 RID: 199
		internal static class Try_000006E8$BurstDirectCall
		{
			// Token: 0x06000826 RID: 2086 RVA: 0x000195F4 File Offset: 0x000177F4
			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr A_0)
			{
				if (RewindableAllocator.Try_000006E8$BurstDirectCall.Pointer == 0)
				{
					RewindableAllocator.Try_000006E8$BurstDirectCall.Pointer = BurstCompiler.GetILPPMethodFunctionPointer2(RewindableAllocator.Try_000006E8$BurstDirectCall.DeferredCompilation, methodof(RewindableAllocator.Try$BurstManaged(IntPtr, AllocatorManager.Block*)).MethodHandle, typeof(RewindableAllocator.Try_000006E8$PostfixBurstDelegate).TypeHandle);
				}
				A_0 = RewindableAllocator.Try_000006E8$BurstDirectCall.Pointer;
			}

			// Token: 0x06000827 RID: 2087 RVA: 0x00019620 File Offset: 0x00017820
			private static IntPtr GetFunctionPointer()
			{
				IntPtr result = (IntPtr)0;
				RewindableAllocator.Try_000006E8$BurstDirectCall.GetFunctionPointerDiscard(ref result);
				return result;
			}

			// Token: 0x06000828 RID: 2088 RVA: 0x00019638 File Offset: 0x00017838
			public unsafe static void Constructor()
			{
				RewindableAllocator.Try_000006E8$BurstDirectCall.DeferredCompilation = BurstCompiler.CompileILPPMethod2(methodof(RewindableAllocator.Try(IntPtr, AllocatorManager.Block*)).MethodHandle);
			}

			// Token: 0x06000829 RID: 2089 RVA: 0x000024A3 File Offset: 0x000006A3
			public static void Initialize()
			{
			}

			// Token: 0x0600082A RID: 2090 RVA: 0x00019649 File Offset: 0x00017849
			// Note: this type is marked as 'beforefieldinit'.
			static Try_000006E8$BurstDirectCall()
			{
				RewindableAllocator.Try_000006E8$BurstDirectCall.Constructor();
			}

			// Token: 0x0600082B RID: 2091 RVA: 0x00019650 File Offset: 0x00017850
			public static int Invoke(IntPtr state, ref AllocatorManager.Block block)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = RewindableAllocator.Try_000006E8$BurstDirectCall.GetFunctionPointer();
					if (functionPointer != 0)
					{
						return calli(System.Int32(System.IntPtr,Unity.Collections.AllocatorManager/Block&), state, ref block, functionPointer);
					}
				}
				return RewindableAllocator.Try$BurstManaged(state, ref block);
			}

			// Token: 0x040002D2 RID: 722
			private static IntPtr Pointer;

			// Token: 0x040002D3 RID: 723
			private static IntPtr DeferredCompilation;
		}
	}
}
