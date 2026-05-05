using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x02000006 RID: 6
	public static class AllocatorManager
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000002CC
		internal static AllocatorManager.Block AllocateBlock<[IsUnmanaged] T>(this T t, int sizeOf, int alignOf, int items) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			AllocatorManager.Block result = default(AllocatorManager.Block);
			result.Range.Pointer = IntPtr.Zero;
			result.Range.Items = items;
			result.Range.Allocator = t.Handle;
			result.BytesPerItem = sizeOf;
			result.Alignment = math.max(64, alignOf);
			t.Try(ref result);
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000213E File Offset: 0x0000033E
		internal static AllocatorManager.Block AllocateBlock<[IsUnmanaged] T, [IsUnmanaged] U>(this T t, U u, int items) where T : struct, ValueType, AllocatorManager.IAllocator where U : struct, ValueType
		{
			return ref t.AllocateBlock(UnsafeUtility.SizeOf<U>(), UnsafeUtility.AlignOf<U>(), items);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002151 File Offset: 0x00000351
		internal unsafe static void* Allocate<[IsUnmanaged] T>(this T t, int sizeOf, int alignOf, int items) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			return (void*)ref t.AllocateBlock(sizeOf, alignOf, items).Range.Pointer;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000216B File Offset: 0x0000036B
		internal unsafe static U* Allocate<[IsUnmanaged] T, [IsUnmanaged] U>(this T t, U u, int items) where T : struct, ValueType, AllocatorManager.IAllocator where U : struct, ValueType
		{
			return (U*)ref t.Allocate(UnsafeUtility.SizeOf<U>(), UnsafeUtility.AlignOf<U>(), items);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000216B File Offset: 0x0000036B
		internal unsafe static void* AllocateStruct<[IsUnmanaged] T, U>(this T t, U u, int items) where T : struct, ValueType, AllocatorManager.IAllocator where U : struct
		{
			return ref t.Allocate(UnsafeUtility.SizeOf<U>(), UnsafeUtility.AlignOf<U>(), items);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000217E File Offset: 0x0000037E
		internal static void FreeBlock<[IsUnmanaged] T>(this T t, ref AllocatorManager.Block block) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			block.Range.Items = 0;
			t.Try(ref block);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000219C File Offset: 0x0000039C
		internal unsafe static void Free<[IsUnmanaged] T>(this T t, void* pointer, int sizeOf, int alignOf, int items) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			if (pointer == null)
			{
				return;
			}
			AllocatorManager.Block block = default(AllocatorManager.Block);
			block.AllocatedItems = items;
			block.Range.Pointer = (IntPtr)pointer;
			block.BytesPerItem = sizeOf;
			block.Alignment = alignOf;
			ref t.FreeBlock(ref block);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021EA File Offset: 0x000003EA
		internal unsafe static void Free<[IsUnmanaged] T, [IsUnmanaged] U>(this T t, U* pointer, int items) where T : struct, ValueType, AllocatorManager.IAllocator where U : struct, ValueType
		{
			ref t.Free((void*)pointer, UnsafeUtility.SizeOf<U>(), UnsafeUtility.AlignOf<U>(), items);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021FE File Offset: 0x000003FE
		public unsafe static void* Allocate(AllocatorManager.AllocatorHandle handle, int itemSizeInBytes, int alignmentInBytes, int items = 1)
		{
			return ref handle.Allocate(itemSizeInBytes, alignmentInBytes, items);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000220C File Offset: 0x0000040C
		public unsafe static T* Allocate<[IsUnmanaged] T>(AllocatorManager.AllocatorHandle handle, int items = 1) where T : struct, ValueType
		{
			return ref handle.Allocate(default(T), items);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000222A File Offset: 0x0000042A
		public unsafe static void Free(AllocatorManager.AllocatorHandle handle, void* pointer, int itemSizeInBytes, int alignmentInBytes, int items = 1)
		{
			ref handle.Free(pointer, itemSizeInBytes, alignmentInBytes, items);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002238 File Offset: 0x00000438
		public unsafe static void Free(AllocatorManager.AllocatorHandle handle, void* pointer)
		{
			ref handle.Free((byte*)pointer, 1);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002243 File Offset: 0x00000443
		public unsafe static void Free<[IsUnmanaged] T>(AllocatorManager.AllocatorHandle handle, T* pointer, int items = 1) where T : struct, ValueType
		{
			ref handle.Free(pointer, items);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000224E File Offset: 0x0000044E
		[BurstDiscard]
		private static void CheckDelegate(ref bool useDelegate)
		{
			useDelegate = true;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002254 File Offset: 0x00000454
		private static bool UseDelegate()
		{
			bool result = false;
			AllocatorManager.CheckDelegate(ref result);
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000226C File Offset: 0x0000046C
		private unsafe static int allocate_block(ref AllocatorManager.Block block)
		{
			AllocatorManager.TableEntry tableEntry = default(AllocatorManager.TableEntry);
			tableEntry = *block.Range.Allocator.TableEntry;
			FunctionPointer<AllocatorManager.TryFunction> functionPointer = new FunctionPointer<AllocatorManager.TryFunction>(tableEntry.function);
			return functionPointer.Invoke(tableEntry.state, ref block);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000022B8 File Offset: 0x000004B8
		[BurstDiscard]
		private unsafe static void forward_mono_allocate_block(ref AllocatorManager.Block block, ref int error)
		{
			AllocatorManager.TableEntry tableEntry = default(AllocatorManager.TableEntry);
			tableEntry = *block.Range.Allocator.TableEntry;
			if (block.Range.Allocator.Handle.Index >= 32768)
			{
				throw new ArgumentException("Allocator index into TryFunction delegate table exceeds maximum.");
			}
			ref AllocatorManager.TryFunction ptr = ref AllocatorManager.Managed.TryFunctionDelegates[(int)block.Range.Allocator.Handle.Index];
			error = ptr(tableEntry.state, ref block);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000233A File Offset: 0x0000053A
		internal static Allocator LegacyOf(AllocatorManager.AllocatorHandle handle)
		{
			if (handle.Value >= 64)
			{
				return Allocator.Persistent;
			}
			return (Allocator)handle.Value;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002350 File Offset: 0x00000550
		private unsafe static int TryLegacy(ref AllocatorManager.Block block)
		{
			if (block.Range.Pointer == IntPtr.Zero)
			{
				block.Range.Pointer = (IntPtr)Memory.Unmanaged.Allocate(block.Bytes, block.Alignment, AllocatorManager.LegacyOf(block.Range.Allocator));
				block.AllocatedItems = block.Range.Items;
				if (!(block.Range.Pointer == IntPtr.Zero))
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (block.Bytes == 0L)
				{
					if (AllocatorManager.LegacyOf(block.Range.Allocator) != Allocator.None)
					{
						Memory.Unmanaged.Free((void*)block.Range.Pointer, AllocatorManager.LegacyOf(block.Range.Allocator));
					}
					block.Range.Pointer = IntPtr.Zero;
					block.AllocatedItems = 0;
					return 0;
				}
				return -1;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002438 File Offset: 0x00000638
		public unsafe static int Try(ref AllocatorManager.Block block)
		{
			if (block.Range.Allocator.Value < 64)
			{
				return AllocatorManager.TryLegacy(ref block);
			}
			AllocatorManager.TableEntry tableEntry = default(AllocatorManager.TableEntry);
			tableEntry = *block.Range.Allocator.TableEntry;
			new FunctionPointer<AllocatorManager.TryFunction>(tableEntry.function);
			if (AllocatorManager.UseDelegate())
			{
				int result = 0;
				AllocatorManager.forward_mono_allocate_block(ref block, ref result);
				return result;
			}
			return AllocatorManager.allocate_block(ref block);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024A3 File Offset: 0x000006A3
		public static void Initialize()
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024A8 File Offset: 0x000006A8
		internal static void Install(AllocatorManager.AllocatorHandle handle, IntPtr allocatorState, FunctionPointer<AllocatorManager.TryFunction> functionPointer, AllocatorManager.TryFunction function)
		{
			if (functionPointer.Value == IntPtr.Zero)
			{
				ref handle.Unregister<AllocatorManager.AllocatorHandle>();
				return;
			}
			if (ConcurrentMask.Succeeded(ConcurrentMask.TryAllocate<Long1024>(AllocatorManager.SharedStatics.IsInstalled.Ref.Data, handle.Value, 1)))
			{
				handle.Install(new AllocatorManager.TableEntry
				{
					state = allocatorState,
					function = functionPointer.Value
				});
				AllocatorManager.Managed.RegisterDelegate((int)handle.Index, function);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002520 File Offset: 0x00000720
		internal static void Install(AllocatorManager.AllocatorHandle handle, IntPtr allocatorState, AllocatorManager.TryFunction function)
		{
			FunctionPointer<AllocatorManager.TryFunction> functionPointer = (function == null) ? new FunctionPointer<AllocatorManager.TryFunction>(IntPtr.Zero) : BurstCompiler.CompileFunctionPointer<AllocatorManager.TryFunction>(function);
			AllocatorManager.Install(handle, allocatorState, functionPointer, function);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000254C File Offset: 0x0000074C
		internal static AllocatorManager.AllocatorHandle Register(IntPtr allocatorState, FunctionPointer<AllocatorManager.TryFunction> functionPointer)
		{
			AllocatorManager.TableEntry tableEntry = new AllocatorManager.TableEntry
			{
				state = allocatorState,
				function = functionPointer.Value
			};
			int num;
			int error = ConcurrentMask.TryAllocate<Long1024>(AllocatorManager.SharedStatics.IsInstalled.Ref.Data, out num, 1, AllocatorManager.SharedStatics.IsInstalled.Ref.Data.Length, 1);
			AllocatorManager.AllocatorHandle result = default(AllocatorManager.AllocatorHandle);
			if (ConcurrentMask.Succeeded(error))
			{
				result.Index = (ushort)num;
				result.Install(tableEntry);
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025BC File Offset: 0x000007BC
		[NotBurstCompatible]
		public static void Register<[IsUnmanaged] T>(this T t) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			FunctionPointer<AllocatorManager.TryFunction> functionPointer = (t.Function == null) ? new FunctionPointer<AllocatorManager.TryFunction>(IntPtr.Zero) : BurstCompiler.CompileFunctionPointer<AllocatorManager.TryFunction>(t.Function);
			t.Handle = AllocatorManager.Register((IntPtr)UnsafeUtility.AddressOf<T>(ref t), functionPointer);
			AllocatorManager.Managed.RegisterDelegate((int)t.Handle.Index, t.Function);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002634 File Offset: 0x00000834
		public static void UnmanagedUnregister<[IsUnmanaged] T>(this T t) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			if (t.Handle.IsInstalled)
			{
				t.Handle.Install(default(AllocatorManager.TableEntry));
				ConcurrentMask.TryFree<Long1024>(AllocatorManager.SharedStatics.IsInstalled.Ref.Data, t.Handle.Value, 1);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000269C File Offset: 0x0000089C
		[NotBurstCompatible]
		public static void Unregister<[IsUnmanaged] T>(this T t) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			if (t.Handle.IsInstalled)
			{
				t.Handle.Install(default(AllocatorManager.TableEntry));
				ConcurrentMask.TryFree<Long1024>(AllocatorManager.SharedStatics.IsInstalled.Ref.Data, t.Handle.Value, 1);
				AllocatorManager.Managed.UnregisterDelegate((int)t.Handle.Index);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002718 File Offset: 0x00000918
		[NotBurstCompatible]
		internal unsafe static ref T CreateAllocator<[IsUnmanaged] T>(AllocatorManager.AllocatorHandle backingAllocator) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			T* ptr = (T*)Memory.Unmanaged.Allocate((long)UnsafeUtility.SizeOf<T>(), 16, backingAllocator);
			*ptr = default(T);
			ref T ptr2 = ref UnsafeUtility.AsRef<T>((void*)ptr);
			ref ptr2.Register<T>();
			return ref ptr2;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002747 File Offset: 0x00000947
		[NotBurstCompatible]
		internal static void DestroyAllocator<[IsUnmanaged] T>(this T t, AllocatorManager.AllocatorHandle backingAllocator) where T : struct, ValueType, AllocatorManager.IAllocator
		{
			ref t.Unregister<T>();
			Memory.Unmanaged.Free(UnsafeUtility.AddressOf<T>(ref t), backingAllocator);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024A3 File Offset: 0x000006A3
		public static void Shutdown()
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000275B File Offset: 0x0000095B
		internal static bool IsCustomAllocator(AllocatorManager.AllocatorHandle allocator)
		{
			return allocator.Index >= 64;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000276A File Offset: 0x0000096A
		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		internal static void CheckFailedToAllocate(int error)
		{
			if (error != 0)
			{
				throw new ArgumentException("failed to allocate");
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000277A File Offset: 0x0000097A
		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		internal static void CheckFailedToFree(int error)
		{
			if (error != 0)
			{
				throw new ArgumentException("failed to free");
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		internal static void CheckValid(AllocatorManager.AllocatorHandle handle)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000281D File Offset: 0x00000A1D
		public static void Initialize$StackAllocator_Try_00000980$BurstDirectCall()
		{
			AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Initialize();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002824 File Offset: 0x00000A24
		public static void Initialize$SlabAllocator_Try_0000098E$BurstDirectCall()
		{
			AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Initialize();
		}

		// Token: 0x04000006 RID: 6
		public static readonly AllocatorManager.AllocatorHandle Invalid = new AllocatorManager.AllocatorHandle
		{
			Index = 0
		};

		// Token: 0x04000007 RID: 7
		public static readonly AllocatorManager.AllocatorHandle None = new AllocatorManager.AllocatorHandle
		{
			Index = 1
		};

		// Token: 0x04000008 RID: 8
		public static readonly AllocatorManager.AllocatorHandle Temp = new AllocatorManager.AllocatorHandle
		{
			Index = 2
		};

		// Token: 0x04000009 RID: 9
		public static readonly AllocatorManager.AllocatorHandle TempJob = new AllocatorManager.AllocatorHandle
		{
			Index = 3
		};

		// Token: 0x0400000A RID: 10
		public static readonly AllocatorManager.AllocatorHandle Persistent = new AllocatorManager.AllocatorHandle
		{
			Index = 4
		};

		// Token: 0x0400000B RID: 11
		public static readonly AllocatorManager.AllocatorHandle AudioKernel = new AllocatorManager.AllocatorHandle
		{
			Index = 5
		};

		// Token: 0x0400000C RID: 12
		public const int kErrorNone = 0;

		// Token: 0x0400000D RID: 13
		public const int kErrorBufferOverflow = -1;

		// Token: 0x0400000E RID: 14
		public const ushort FirstUserIndex = 64;

		// Token: 0x02000007 RID: 7
		// (Invoke) Token: 0x0600002B RID: 43
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int TryFunction(IntPtr allocatorState, ref AllocatorManager.Block block);

		// Token: 0x02000008 RID: 8
		public struct AllocatorHandle : AllocatorManager.IAllocator, IDisposable
		{
			// Token: 0x17000001 RID: 1
			// (get) Token: 0x0600002E RID: 46 RVA: 0x0000282B File Offset: 0x00000A2B
			internal ref AllocatorManager.TableEntry TableEntry
			{
				get
				{
					return AllocatorManager.SharedStatics.TableEntry.Ref.Data.ElementAt((int)this.Index);
				}
			}

			// Token: 0x17000002 RID: 2
			// (get) Token: 0x0600002F RID: 47 RVA: 0x00002842 File Offset: 0x00000A42
			internal unsafe bool IsInstalled
			{
				get
				{
					return (*AllocatorManager.SharedStatics.IsInstalled.Ref.Data.ElementAt(this.Index >> 6) >> (int)this.Index & 1L) != 0L;
				}
			}

			// Token: 0x06000030 RID: 48 RVA: 0x000024A3 File Offset: 0x000006A3
			internal void IncrementVersion()
			{
			}

			// Token: 0x06000031 RID: 49 RVA: 0x000024A3 File Offset: 0x000006A3
			internal void Rewind()
			{
			}

			// Token: 0x06000032 RID: 50 RVA: 0x00002870 File Offset: 0x00000A70
			internal unsafe void Install(AllocatorManager.TableEntry tableEntry)
			{
				this.Rewind();
				*this.TableEntry = tableEntry;
			}

			// Token: 0x06000033 RID: 51 RVA: 0x00002884 File Offset: 0x00000A84
			public static implicit operator AllocatorManager.AllocatorHandle(Allocator a)
			{
				return new AllocatorManager.AllocatorHandle
				{
					Index = (ushort)(a & (Allocator)65535),
					Version = (ushort)(a >> 16)
				};
			}

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x06000034 RID: 52 RVA: 0x000028B5 File Offset: 0x00000AB5
			public int Value
			{
				get
				{
					return (int)this.Index;
				}
			}

			// Token: 0x06000035 RID: 53 RVA: 0x000028C0 File Offset: 0x00000AC0
			public int TryAllocateBlock<T>(out AllocatorManager.Block block, int items) where T : struct
			{
				block = new AllocatorManager.Block
				{
					Range = new AllocatorManager.Range
					{
						Items = items,
						Allocator = this
					},
					BytesPerItem = UnsafeUtility.SizeOf<T>(),
					Alignment = 1 << math.min(3, math.tzcnt(UnsafeUtility.SizeOf<T>()))
				};
				return this.Try(ref block);
			}

			// Token: 0x06000036 RID: 54 RVA: 0x00002930 File Offset: 0x00000B30
			public AllocatorManager.Block AllocateBlock<T>(int items) where T : struct
			{
				AllocatorManager.Block result;
				this.TryAllocateBlock<T>(out result, items);
				return result;
			}

			// Token: 0x06000037 RID: 55 RVA: 0x00002948 File Offset: 0x00000B48
			[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
			private static void CheckAllocatedSuccessfully(int error)
			{
				if (error != 0)
				{
					throw new ArgumentException(string.Format("Error {0}: Failed to Allocate", error));
				}
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000038 RID: 56 RVA: 0x00002963 File Offset: 0x00000B63
			public AllocatorManager.TryFunction Function
			{
				get
				{
					return null;
				}
			}

			// Token: 0x06000039 RID: 57 RVA: 0x00002966 File Offset: 0x00000B66
			public int Try(ref AllocatorManager.Block block)
			{
				block.Range.Allocator = this;
				return AllocatorManager.Try(ref block);
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600003A RID: 58 RVA: 0x0000297F File Offset: 0x00000B7F
			// (set) Token: 0x0600003B RID: 59 RVA: 0x00002987 File Offset: 0x00000B87
			public AllocatorManager.AllocatorHandle Handle
			{
				get
				{
					return this;
				}
				set
				{
					this = value;
				}
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x0600003C RID: 60 RVA: 0x00002990 File Offset: 0x00000B90
			public Allocator ToAllocator
			{
				get
				{
					uint index = (uint)this.Index;
					return (Allocator)((int)this.Version << 16 | (int)index);
				}
			}

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x0600003D RID: 61 RVA: 0x0000275B File Offset: 0x0000095B
			public bool IsCustomAllocator
			{
				get
				{
					return this.Index >= 64;
				}
			}

			// Token: 0x0600003E RID: 62 RVA: 0x000029AF File Offset: 0x00000BAF
			public void Dispose()
			{
				this.Rewind();
			}

			// Token: 0x0400000F RID: 15
			public ushort Index;

			// Token: 0x04000010 RID: 16
			public ushort Version;
		}

		// Token: 0x02000009 RID: 9
		public struct BlockHandle
		{
			// Token: 0x04000011 RID: 17
			public ushort Value;
		}

		// Token: 0x0200000A RID: 10
		public struct Range : IDisposable
		{
			// Token: 0x0600003F RID: 63 RVA: 0x000029B8 File Offset: 0x00000BB8
			public void Dispose()
			{
				AllocatorManager.Block block = new AllocatorManager.Block
				{
					Range = this
				};
				block.Dispose();
				this = block.Range;
			}

			// Token: 0x04000012 RID: 18
			public IntPtr Pointer;

			// Token: 0x04000013 RID: 19
			public int Items;

			// Token: 0x04000014 RID: 20
			public AllocatorManager.AllocatorHandle Allocator;
		}

		// Token: 0x0200000B RID: 11
		public struct Block : IDisposable
		{
			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000040 RID: 64 RVA: 0x000029EF File Offset: 0x00000BEF
			public long Bytes
			{
				get
				{
					return (long)(this.BytesPerItem * this.Range.Items);
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000041 RID: 65 RVA: 0x00002A04 File Offset: 0x00000C04
			public long AllocatedBytes
			{
				get
				{
					return (long)(this.BytesPerItem * this.AllocatedItems);
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000042 RID: 66 RVA: 0x00002A14 File Offset: 0x00000C14
			// (set) Token: 0x06000043 RID: 67 RVA: 0x00002A21 File Offset: 0x00000C21
			public int Alignment
			{
				get
				{
					return 1 << (int)this.Log2Alignment;
				}
				set
				{
					this.Log2Alignment = (byte)(32 - math.lzcnt(math.max(1, value) - 1));
				}
			}

			// Token: 0x06000044 RID: 68 RVA: 0x00002A3B File Offset: 0x00000C3B
			public void Dispose()
			{
				this.TryFree();
			}

			// Token: 0x06000045 RID: 69 RVA: 0x00002A44 File Offset: 0x00000C44
			public int TryAllocate()
			{
				this.Range.Pointer = IntPtr.Zero;
				return AllocatorManager.Try(ref this);
			}

			// Token: 0x06000046 RID: 70 RVA: 0x00002A5C File Offset: 0x00000C5C
			public int TryFree()
			{
				this.Range.Items = 0;
				return AllocatorManager.Try(ref this);
			}

			// Token: 0x06000047 RID: 71 RVA: 0x00002A70 File Offset: 0x00000C70
			public void Allocate()
			{
				this.TryAllocate();
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00002A3B File Offset: 0x00000C3B
			public void Free()
			{
				this.TryFree();
			}

			// Token: 0x06000049 RID: 73 RVA: 0x00002A79 File Offset: 0x00000C79
			[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
			private void CheckFailedToAllocate(int error)
			{
				if (error != 0)
				{
					throw new ArgumentException(string.Format("Error {0}: Failed to Allocate {1}", error, this));
				}
			}

			// Token: 0x0600004A RID: 74 RVA: 0x00002A9F File Offset: 0x00000C9F
			[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
			private void CheckFailedToFree(int error)
			{
				if (error != 0)
				{
					throw new ArgumentException(string.Format("Error {0}: Failed to Free {1}", error, this));
				}
			}

			// Token: 0x04000015 RID: 21
			public AllocatorManager.Range Range;

			// Token: 0x04000016 RID: 22
			public int BytesPerItem;

			// Token: 0x04000017 RID: 23
			public int AllocatedItems;

			// Token: 0x04000018 RID: 24
			public byte Log2Alignment;

			// Token: 0x04000019 RID: 25
			public byte Padding0;

			// Token: 0x0400001A RID: 26
			public ushort Padding1;

			// Token: 0x0400001B RID: 27
			public uint Padding2;
		}

		// Token: 0x0200000C RID: 12
		public interface IAllocator : IDisposable
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600004B RID: 75
			AllocatorManager.TryFunction Function { get; }

			// Token: 0x0600004C RID: 76
			int Try(ref AllocatorManager.Block block);

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600004D RID: 77
			// (set) Token: 0x0600004E RID: 78
			AllocatorManager.AllocatorHandle Handle { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600004F RID: 79
			Allocator ToAllocator { get; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000050 RID: 80
			bool IsCustomAllocator { get; }
		}

		// Token: 0x0200000D RID: 13
		[BurstCompile(CompileSynchronously = true)]
		internal struct StackAllocator : AllocatorManager.IAllocator, IDisposable
		{
			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00002AC5 File Offset: 0x00000CC5
			// (set) Token: 0x06000052 RID: 82 RVA: 0x00002ACD File Offset: 0x00000CCD
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

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000053 RID: 83 RVA: 0x00002AD6 File Offset: 0x00000CD6
			public Allocator ToAllocator
			{
				get
				{
					return this.m_handle.ToAllocator;
				}
			}

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000054 RID: 84 RVA: 0x00002AE3 File Offset: 0x00000CE3
			public bool IsCustomAllocator
			{
				get
				{
					return this.m_handle.IsCustomAllocator;
				}
			}

			// Token: 0x06000055 RID: 85 RVA: 0x00002AF0 File Offset: 0x00000CF0
			public void Initialize(AllocatorManager.Block storage)
			{
				this.m_storage = storage;
				this.m_top = 0L;
			}

			// Token: 0x06000056 RID: 86 RVA: 0x00002B04 File Offset: 0x00000D04
			public unsafe int Try(ref AllocatorManager.Block block)
			{
				if (block.Range.Pointer == IntPtr.Zero)
				{
					if (this.m_top + block.Bytes > this.m_storage.Bytes)
					{
						return -1;
					}
					block.Range.Pointer = (IntPtr)((void*)((byte*)((void*)this.m_storage.Range.Pointer) + this.m_top));
					block.AllocatedItems = block.Range.Items;
					this.m_top += block.Bytes;
					return 0;
				}
				else
				{
					if (block.Bytes != 0L)
					{
						return -1;
					}
					if ((long)((byte*)((void*)block.Range.Pointer) - (byte*)((void*)this.m_storage.Range.Pointer)) == this.m_top - block.AllocatedBytes)
					{
						this.m_top -= block.AllocatedBytes;
						block.Range.Pointer = IntPtr.Zero;
						block.AllocatedItems = 0;
						return 0;
					}
					return -1;
				}
			}

			// Token: 0x06000057 RID: 87 RVA: 0x00002C06 File Offset: 0x00000E06
			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
			public static int Try(IntPtr allocatorState, ref AllocatorManager.Block block)
			{
				return AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Invoke(allocatorState, ref block);
			}

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000058 RID: 88 RVA: 0x00002C0F File Offset: 0x00000E0F
			public AllocatorManager.TryFunction Function
			{
				get
				{
					return new AllocatorManager.TryFunction(AllocatorManager.StackAllocator.Try);
				}
			}

			// Token: 0x06000059 RID: 89 RVA: 0x00002C1D File Offset: 0x00000E1D
			public void Dispose()
			{
				this.m_handle.Rewind();
			}

			// Token: 0x0600005A RID: 90 RVA: 0x00002C2A File Offset: 0x00000E2A
			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe static int Try$BurstManaged(IntPtr allocatorState, ref AllocatorManager.Block block)
			{
				return ((AllocatorManager.StackAllocator*)((void*)allocatorState))->Try(ref block);
			}

			// Token: 0x0400001C RID: 28
			internal AllocatorManager.AllocatorHandle m_handle;

			// Token: 0x0400001D RID: 29
			internal AllocatorManager.Block m_storage;

			// Token: 0x0400001E RID: 30
			internal long m_top;

			// Token: 0x0200000E RID: 14
			// (Invoke) Token: 0x0600005C RID: 92
			public delegate int Try_00000980$PostfixBurstDelegate(IntPtr allocatorState, ref AllocatorManager.Block block);

			// Token: 0x0200000F RID: 15
			internal static class Try_00000980$BurstDirectCall
			{
				// Token: 0x0600005F RID: 95 RVA: 0x00002C38 File Offset: 0x00000E38
				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr A_0)
				{
					if (AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Pointer == 0)
					{
						AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Pointer = BurstCompiler.GetILPPMethodFunctionPointer2(AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.DeferredCompilation, methodof(AllocatorManager.StackAllocator.Try$BurstManaged(IntPtr, AllocatorManager.Block*)).MethodHandle, typeof(AllocatorManager.StackAllocator.Try_00000980$PostfixBurstDelegate).TypeHandle);
					}
					A_0 = AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Pointer;
				}

				// Token: 0x06000060 RID: 96 RVA: 0x00002C64 File Offset: 0x00000E64
				private static IntPtr GetFunctionPointer()
				{
					IntPtr result = (IntPtr)0;
					AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.GetFunctionPointerDiscard(ref result);
					return result;
				}

				// Token: 0x06000061 RID: 97 RVA: 0x00002C7C File Offset: 0x00000E7C
				public unsafe static void Constructor()
				{
					AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.DeferredCompilation = BurstCompiler.CompileILPPMethod2(methodof(AllocatorManager.StackAllocator.Try(IntPtr, AllocatorManager.Block*)).MethodHandle);
				}

				// Token: 0x06000062 RID: 98 RVA: 0x000024A3 File Offset: 0x000006A3
				public static void Initialize()
				{
				}

				// Token: 0x06000063 RID: 99 RVA: 0x00002C8D File Offset: 0x00000E8D
				// Note: this type is marked as 'beforefieldinit'.
				static Try_00000980$BurstDirectCall()
				{
					AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.Constructor();
				}

				// Token: 0x06000064 RID: 100 RVA: 0x00002C94 File Offset: 0x00000E94
				public static int Invoke(IntPtr allocatorState, ref AllocatorManager.Block block)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = AllocatorManager.StackAllocator.Try_00000980$BurstDirectCall.GetFunctionPointer();
						if (functionPointer != 0)
						{
							return calli(System.Int32(System.IntPtr,Unity.Collections.AllocatorManager/Block&), allocatorState, ref block, functionPointer);
						}
					}
					return AllocatorManager.StackAllocator.Try$BurstManaged(allocatorState, ref block);
				}

				// Token: 0x0400001F RID: 31
				private static IntPtr Pointer;

				// Token: 0x04000020 RID: 32
				private static IntPtr DeferredCompilation;
			}
		}

		// Token: 0x02000010 RID: 16
		[BurstCompile(CompileSynchronously = true)]
		internal struct SlabAllocator : AllocatorManager.IAllocator, IDisposable
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000065 RID: 101 RVA: 0x00002CC7 File Offset: 0x00000EC7
			// (set) Token: 0x06000066 RID: 102 RVA: 0x00002CCF File Offset: 0x00000ECF
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

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000067 RID: 103 RVA: 0x00002CD8 File Offset: 0x00000ED8
			public Allocator ToAllocator
			{
				get
				{
					return this.m_handle.ToAllocator;
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000068 RID: 104 RVA: 0x00002CE5 File Offset: 0x00000EE5
			public bool IsCustomAllocator
			{
				get
				{
					return this.m_handle.IsCustomAllocator;
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000069 RID: 105 RVA: 0x00002CF2 File Offset: 0x00000EF2
			public long BudgetInBytes
			{
				get
				{
					return this.budgetInBytes;
				}
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600006A RID: 106 RVA: 0x00002CFA File Offset: 0x00000EFA
			public long AllocatedBytes
			{
				get
				{
					return this.allocatedBytes;
				}
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600006B RID: 107 RVA: 0x00002D02 File Offset: 0x00000F02
			// (set) Token: 0x0600006C RID: 108 RVA: 0x00002D0F File Offset: 0x00000F0F
			internal int SlabSizeInBytes
			{
				get
				{
					return 1 << this.Log2SlabSizeInBytes;
				}
				set
				{
					this.Log2SlabSizeInBytes = (int)((byte)(32 - math.lzcnt(math.max(1, value) - 1)));
				}
			}

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00002D29 File Offset: 0x00000F29
			internal int Slabs
			{
				get
				{
					return (int)(this.Storage.Bytes >> this.Log2SlabSizeInBytes);
				}
			}

			// Token: 0x0600006E RID: 110 RVA: 0x00002D44 File Offset: 0x00000F44
			internal void Initialize(AllocatorManager.Block storage, int slabSizeInBytes, long budget)
			{
				this.Storage = storage;
				this.Log2SlabSizeInBytes = 0;
				this.Occupied = default(FixedList4096Bytes<int>);
				this.budgetInBytes = budget;
				this.allocatedBytes = 0L;
				this.SlabSizeInBytes = slabSizeInBytes;
				this.Occupied.Length = (this.Slabs + 31) / 32;
			}

			// Token: 0x0600006F RID: 111 RVA: 0x00002D98 File Offset: 0x00000F98
			public int Try(ref AllocatorManager.Block block)
			{
				if (block.Range.Pointer == IntPtr.Zero)
				{
					if (block.Bytes + this.allocatedBytes > this.budgetInBytes)
					{
						return -2;
					}
					if (block.Bytes > (long)this.SlabSizeInBytes)
					{
						return -1;
					}
					for (int i = 0; i < this.Occupied.Length; i++)
					{
						int num = this.Occupied[i];
						if (num != -1)
						{
							for (int j = 0; j < 32; j++)
							{
								if ((num & 1 << j) == 0)
								{
									ref FixedList4096Bytes<int> ptr = ref this.Occupied;
									int index = i;
									ptr[index] |= 1 << j;
									block.Range.Pointer = this.Storage.Range.Pointer + (int)((long)this.SlabSizeInBytes * ((long)i * 32L + (long)j));
									block.AllocatedItems = this.SlabSizeInBytes / block.BytesPerItem;
									this.allocatedBytes += block.Bytes;
									return 0;
								}
							}
						}
					}
					return -1;
				}
				else
				{
					if (block.Bytes == 0L)
					{
						ulong num2 = (ulong)((long)block.Range.Pointer - (long)this.Storage.Range.Pointer) >> this.Log2SlabSizeInBytes;
						int num3 = (int)(num2 >> 5);
						int num4 = (int)(num2 & 31UL);
						ref FixedList4096Bytes<int> ptr = ref this.Occupied;
						int index = num3;
						ptr[index] &= ~(1 << num4);
						block.Range.Pointer = IntPtr.Zero;
						int num5 = block.AllocatedItems * block.BytesPerItem;
						this.allocatedBytes -= (long)num5;
						block.AllocatedItems = 0;
						return 0;
					}
					return -1;
				}
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00002F57 File Offset: 0x00001157
			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
			public static int Try(IntPtr allocatorState, ref AllocatorManager.Block block)
			{
				return AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Invoke(allocatorState, ref block);
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00002F60 File Offset: 0x00001160
			public AllocatorManager.TryFunction Function
			{
				get
				{
					return new AllocatorManager.TryFunction(AllocatorManager.SlabAllocator.Try);
				}
			}

			// Token: 0x06000072 RID: 114 RVA: 0x00002F6E File Offset: 0x0000116E
			public void Dispose()
			{
				this.m_handle.Rewind();
			}

			// Token: 0x06000073 RID: 115 RVA: 0x00002F7B File Offset: 0x0000117B
			[BurstCompile(CompileSynchronously = true)]
			[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe static int Try$BurstManaged(IntPtr allocatorState, ref AllocatorManager.Block block)
			{
				return ((AllocatorManager.SlabAllocator*)((void*)allocatorState))->Try(ref block);
			}

			// Token: 0x04000021 RID: 33
			internal AllocatorManager.AllocatorHandle m_handle;

			// Token: 0x04000022 RID: 34
			internal AllocatorManager.Block Storage;

			// Token: 0x04000023 RID: 35
			internal int Log2SlabSizeInBytes;

			// Token: 0x04000024 RID: 36
			internal FixedList4096Bytes<int> Occupied;

			// Token: 0x04000025 RID: 37
			internal long budgetInBytes;

			// Token: 0x04000026 RID: 38
			internal long allocatedBytes;

			// Token: 0x02000011 RID: 17
			// (Invoke) Token: 0x06000075 RID: 117
			public delegate int Try_0000098E$PostfixBurstDelegate(IntPtr allocatorState, ref AllocatorManager.Block block);

			// Token: 0x02000012 RID: 18
			internal static class Try_0000098E$BurstDirectCall
			{
				// Token: 0x06000078 RID: 120 RVA: 0x00002F89 File Offset: 0x00001189
				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr A_0)
				{
					if (AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Pointer == 0)
					{
						AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Pointer = BurstCompiler.GetILPPMethodFunctionPointer2(AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.DeferredCompilation, methodof(AllocatorManager.SlabAllocator.Try$BurstManaged(IntPtr, AllocatorManager.Block*)).MethodHandle, typeof(AllocatorManager.SlabAllocator.Try_0000098E$PostfixBurstDelegate).TypeHandle);
					}
					A_0 = AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Pointer;
				}

				// Token: 0x06000079 RID: 121 RVA: 0x00002FB8 File Offset: 0x000011B8
				private static IntPtr GetFunctionPointer()
				{
					IntPtr result = (IntPtr)0;
					AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.GetFunctionPointerDiscard(ref result);
					return result;
				}

				// Token: 0x0600007A RID: 122 RVA: 0x00002FD0 File Offset: 0x000011D0
				public unsafe static void Constructor()
				{
					AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.DeferredCompilation = BurstCompiler.CompileILPPMethod2(methodof(AllocatorManager.SlabAllocator.Try(IntPtr, AllocatorManager.Block*)).MethodHandle);
				}

				// Token: 0x0600007B RID: 123 RVA: 0x000024A3 File Offset: 0x000006A3
				public static void Initialize()
				{
				}

				// Token: 0x0600007C RID: 124 RVA: 0x00002FE1 File Offset: 0x000011E1
				// Note: this type is marked as 'beforefieldinit'.
				static Try_0000098E$BurstDirectCall()
				{
					AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.Constructor();
				}

				// Token: 0x0600007D RID: 125 RVA: 0x00002FE8 File Offset: 0x000011E8
				public static int Invoke(IntPtr allocatorState, ref AllocatorManager.Block block)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = AllocatorManager.SlabAllocator.Try_0000098E$BurstDirectCall.GetFunctionPointer();
						if (functionPointer != 0)
						{
							return calli(System.Int32(System.IntPtr,Unity.Collections.AllocatorManager/Block&), allocatorState, ref block, functionPointer);
						}
					}
					return AllocatorManager.SlabAllocator.Try$BurstManaged(allocatorState, ref block);
				}

				// Token: 0x04000027 RID: 39
				private static IntPtr Pointer;

				// Token: 0x04000028 RID: 40
				private static IntPtr DeferredCompilation;
			}
		}

		// Token: 0x02000013 RID: 19
		internal struct TableEntry
		{
			// Token: 0x04000029 RID: 41
			internal IntPtr function;

			// Token: 0x0400002A RID: 42
			internal IntPtr state;
		}

		// Token: 0x02000014 RID: 20
		internal struct Array16<[IsUnmanaged] T> where T : struct, ValueType
		{
			// Token: 0x0400002B RID: 43
			internal T f0;

			// Token: 0x0400002C RID: 44
			internal T f1;

			// Token: 0x0400002D RID: 45
			internal T f2;

			// Token: 0x0400002E RID: 46
			internal T f3;

			// Token: 0x0400002F RID: 47
			internal T f4;

			// Token: 0x04000030 RID: 48
			internal T f5;

			// Token: 0x04000031 RID: 49
			internal T f6;

			// Token: 0x04000032 RID: 50
			internal T f7;

			// Token: 0x04000033 RID: 51
			internal T f8;

			// Token: 0x04000034 RID: 52
			internal T f9;

			// Token: 0x04000035 RID: 53
			internal T f10;

			// Token: 0x04000036 RID: 54
			internal T f11;

			// Token: 0x04000037 RID: 55
			internal T f12;

			// Token: 0x04000038 RID: 56
			internal T f13;

			// Token: 0x04000039 RID: 57
			internal T f14;

			// Token: 0x0400003A RID: 58
			internal T f15;
		}

		// Token: 0x02000015 RID: 21
		internal struct Array256<[IsUnmanaged] T> where T : struct, ValueType
		{
			// Token: 0x0400003B RID: 59
			internal AllocatorManager.Array16<T> f0;

			// Token: 0x0400003C RID: 60
			internal AllocatorManager.Array16<T> f1;

			// Token: 0x0400003D RID: 61
			internal AllocatorManager.Array16<T> f2;

			// Token: 0x0400003E RID: 62
			internal AllocatorManager.Array16<T> f3;

			// Token: 0x0400003F RID: 63
			internal AllocatorManager.Array16<T> f4;

			// Token: 0x04000040 RID: 64
			internal AllocatorManager.Array16<T> f5;

			// Token: 0x04000041 RID: 65
			internal AllocatorManager.Array16<T> f6;

			// Token: 0x04000042 RID: 66
			internal AllocatorManager.Array16<T> f7;

			// Token: 0x04000043 RID: 67
			internal AllocatorManager.Array16<T> f8;

			// Token: 0x04000044 RID: 68
			internal AllocatorManager.Array16<T> f9;

			// Token: 0x04000045 RID: 69
			internal AllocatorManager.Array16<T> f10;

			// Token: 0x04000046 RID: 70
			internal AllocatorManager.Array16<T> f11;

			// Token: 0x04000047 RID: 71
			internal AllocatorManager.Array16<T> f12;

			// Token: 0x04000048 RID: 72
			internal AllocatorManager.Array16<T> f13;

			// Token: 0x04000049 RID: 73
			internal AllocatorManager.Array16<T> f14;

			// Token: 0x0400004A RID: 74
			internal AllocatorManager.Array16<T> f15;
		}

		// Token: 0x02000016 RID: 22
		internal struct Array4096<[IsUnmanaged] T> where T : struct, ValueType
		{
			// Token: 0x0400004B RID: 75
			internal AllocatorManager.Array256<T> f0;

			// Token: 0x0400004C RID: 76
			internal AllocatorManager.Array256<T> f1;

			// Token: 0x0400004D RID: 77
			internal AllocatorManager.Array256<T> f2;

			// Token: 0x0400004E RID: 78
			internal AllocatorManager.Array256<T> f3;

			// Token: 0x0400004F RID: 79
			internal AllocatorManager.Array256<T> f4;

			// Token: 0x04000050 RID: 80
			internal AllocatorManager.Array256<T> f5;

			// Token: 0x04000051 RID: 81
			internal AllocatorManager.Array256<T> f6;

			// Token: 0x04000052 RID: 82
			internal AllocatorManager.Array256<T> f7;

			// Token: 0x04000053 RID: 83
			internal AllocatorManager.Array256<T> f8;

			// Token: 0x04000054 RID: 84
			internal AllocatorManager.Array256<T> f9;

			// Token: 0x04000055 RID: 85
			internal AllocatorManager.Array256<T> f10;

			// Token: 0x04000056 RID: 86
			internal AllocatorManager.Array256<T> f11;

			// Token: 0x04000057 RID: 87
			internal AllocatorManager.Array256<T> f12;

			// Token: 0x04000058 RID: 88
			internal AllocatorManager.Array256<T> f13;

			// Token: 0x04000059 RID: 89
			internal AllocatorManager.Array256<T> f14;

			// Token: 0x0400005A RID: 90
			internal AllocatorManager.Array256<T> f15;
		}

		// Token: 0x02000017 RID: 23
		internal struct Array32768<[IsUnmanaged] T> : IIndexable<T> where T : struct, ValueType
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600007E RID: 126 RVA: 0x0000301B File Offset: 0x0000121B
			// (set) Token: 0x0600007F RID: 127 RVA: 0x000024A3 File Offset: 0x000006A3
			public int Length
			{
				get
				{
					return 32768;
				}
				set
				{
				}
			}

			// Token: 0x06000080 RID: 128 RVA: 0x00003024 File Offset: 0x00001224
			public unsafe ref T ElementAt(int index)
			{
				fixed (AllocatorManager.Array4096<T>* ptr = &this.f0)
				{
					return UnsafeUtility.AsRef<T>((void*)((byte*)ptr + (IntPtr)index * (IntPtr)sizeof(T)));
				}
			}

			// Token: 0x0400005B RID: 91
			internal AllocatorManager.Array4096<T> f0;

			// Token: 0x0400005C RID: 92
			internal AllocatorManager.Array4096<T> f1;

			// Token: 0x0400005D RID: 93
			internal AllocatorManager.Array4096<T> f2;

			// Token: 0x0400005E RID: 94
			internal AllocatorManager.Array4096<T> f3;

			// Token: 0x0400005F RID: 95
			internal AllocatorManager.Array4096<T> f4;

			// Token: 0x04000060 RID: 96
			internal AllocatorManager.Array4096<T> f5;

			// Token: 0x04000061 RID: 97
			internal AllocatorManager.Array4096<T> f6;

			// Token: 0x04000062 RID: 98
			internal AllocatorManager.Array4096<T> f7;
		}

		// Token: 0x02000018 RID: 24
		internal sealed class SharedStatics
		{
			// Token: 0x02000019 RID: 25
			internal sealed class IsInstalled
			{
				// Token: 0x04000063 RID: 99
				internal static readonly SharedStatic<Long1024> Ref = SharedStatic<Long1024>.GetOrCreateUnsafe(0U, -4832911380680317357L, 0L);
			}

			// Token: 0x0200001A RID: 26
			internal sealed class TableEntry
			{
				// Token: 0x04000064 RID: 100
				internal static readonly SharedStatic<AllocatorManager.Array32768<AllocatorManager.TableEntry>> Ref = SharedStatic<AllocatorManager.Array32768<AllocatorManager.TableEntry>>.GetOrCreateUnsafe(0U, -1297938794087215229L, 0L);
			}
		}

		// Token: 0x0200001B RID: 27
		internal static class Managed
		{
			// Token: 0x06000086 RID: 134 RVA: 0x00003087 File Offset: 0x00001287
			[NotBurstCompatible]
			public static void RegisterDelegate(int index, AllocatorManager.TryFunction function)
			{
				if (index >= 32768)
				{
					throw new ArgumentException("index to be registered in TryFunction delegate table exceeds maximum.");
				}
				AllocatorManager.Managed.TryFunctionDelegates[index] = function;
			}

			// Token: 0x06000087 RID: 135 RVA: 0x000030A4 File Offset: 0x000012A4
			[NotBurstCompatible]
			public static void UnregisterDelegate(int index)
			{
				if (index >= 32768)
				{
					throw new ArgumentException("index to be unregistered in TryFunction delegate table exceeds maximum.");
				}
				AllocatorManager.Managed.TryFunctionDelegates[index] = null;
			}

			// Token: 0x04000065 RID: 101
			internal const int kMaxNumCustomAllocator = 32768;

			// Token: 0x04000066 RID: 102
			internal static AllocatorManager.TryFunction[] TryFunctionDelegates = new AllocatorManager.TryFunction[32768];
		}
	}
}
