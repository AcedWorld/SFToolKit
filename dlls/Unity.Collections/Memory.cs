using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x02000087 RID: 135
	[BurstCompatible]
	internal struct Memory
	{
		// Token: 0x060005D6 RID: 1494 RVA: 0x000145A8 File Offset: 0x000127A8
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void CheckByteCountIsReasonable(long size)
		{
			if (size < 0L)
			{
				throw new InvalidOperationException("Attempted to operate on {size} bytes of memory: nonsensical");
			}
			if (size > 1099511627776L)
			{
				throw new InvalidOperationException("Attempted to operate on {size} bytes of memory: too big");
			}
		}

		// Token: 0x04000266 RID: 614
		internal const long k_MaximumRamSizeInBytes = 1099511627776L;

		// Token: 0x02000088 RID: 136
		[BurstCompatible]
		internal struct Unmanaged
		{
			// Token: 0x060005D7 RID: 1495 RVA: 0x000145D1 File Offset: 0x000127D1
			internal unsafe static void* Allocate(long size, int align, AllocatorManager.AllocatorHandle allocator)
			{
				return Memory.Unmanaged.Array.Resize(null, 0L, 1L, allocator, size, align);
			}

			// Token: 0x060005D8 RID: 1496 RVA: 0x000145E1 File Offset: 0x000127E1
			internal unsafe static void Free(void* pointer, AllocatorManager.AllocatorHandle allocator)
			{
				if (pointer == null)
				{
					return;
				}
				Memory.Unmanaged.Array.Resize(pointer, 1L, 0L, allocator, 1L, 1);
			}

			// Token: 0x060005D9 RID: 1497 RVA: 0x000145F8 File Offset: 0x000127F8
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			internal unsafe static T* Allocate<[IsUnmanaged] T>(AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
			{
				return Memory.Unmanaged.Array.Resize<T>(null, 0L, 1L, allocator);
			}

			// Token: 0x060005DA RID: 1498 RVA: 0x00014606 File Offset: 0x00012806
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			internal unsafe static void Free<[IsUnmanaged] T>(T* pointer, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
			{
				if (pointer == null)
				{
					return;
				}
				Memory.Unmanaged.Array.Resize<T>(pointer, 1L, 0L, allocator);
			}

			// Token: 0x02000089 RID: 137
			[BurstCompatible]
			internal struct Array
			{
				// Token: 0x060005DB RID: 1499 RVA: 0x0000275B File Offset: 0x0000095B
				private static bool IsCustom(AllocatorManager.AllocatorHandle allocator)
				{
					return allocator.Index >= 64;
				}

				// Token: 0x060005DC RID: 1500 RVA: 0x0001461C File Offset: 0x0001281C
				private unsafe static void* CustomResize(void* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator, long size, int align)
				{
					AllocatorManager.Block block = default(AllocatorManager.Block);
					block.Range.Allocator = allocator;
					block.Range.Items = (int)newCount;
					block.Range.Pointer = (IntPtr)oldPointer;
					block.BytesPerItem = (int)size;
					block.Alignment = align;
					block.AllocatedItems = (int)oldCount;
					AllocatorManager.Try(ref block);
					return (void*)block.Range.Pointer;
				}

				// Token: 0x060005DD RID: 1501 RVA: 0x00014694 File Offset: 0x00012894
				internal unsafe static void* Resize(void* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator, long size, int align)
				{
					int num = math.max(64, align);
					if (Memory.Unmanaged.Array.IsCustom(allocator))
					{
						return Memory.Unmanaged.Array.CustomResize(oldPointer, oldCount, newCount, allocator, size, num);
					}
					void* ptr = default(void*);
					if (newCount > 0L)
					{
						ptr = UnsafeUtility.Malloc(newCount * size, num, allocator.ToAllocator);
						if (oldCount > 0L)
						{
							long size2 = math.min(oldCount, newCount) * size;
							UnsafeUtility.MemCpy(ptr, oldPointer, size2);
						}
					}
					if (oldCount > 0L)
					{
						UnsafeUtility.Free(oldPointer, allocator.ToAllocator);
					}
					return ptr;
				}

				// Token: 0x060005DE RID: 1502 RVA: 0x0001470A File Offset: 0x0001290A
				[BurstCompatible(GenericTypeArguments = new Type[]
				{
					typeof(int)
				})]
				internal unsafe static T* Resize<[IsUnmanaged] T>(T* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
				{
					return (T*)Memory.Unmanaged.Array.Resize((void*)oldPointer, oldCount, newCount, allocator, (long)UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>());
				}

				// Token: 0x060005DF RID: 1503 RVA: 0x00014720 File Offset: 0x00012920
				[BurstCompatible(GenericTypeArguments = new Type[]
				{
					typeof(int)
				})]
				internal unsafe static T* Allocate<[IsUnmanaged] T>(long count, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
				{
					return Memory.Unmanaged.Array.Resize<T>(null, 0L, count, allocator);
				}

				// Token: 0x060005E0 RID: 1504 RVA: 0x0001472D File Offset: 0x0001292D
				[BurstCompatible(GenericTypeArguments = new Type[]
				{
					typeof(int)
				})]
				internal unsafe static void Free<[IsUnmanaged] T>(T* pointer, long count, AllocatorManager.AllocatorHandle allocator) where T : struct, ValueType
				{
					if (pointer == null)
					{
						return;
					}
					Memory.Unmanaged.Array.Resize<T>(pointer, count, 0L, allocator);
				}
			}
		}

		// Token: 0x0200008A RID: 138
		[BurstCompatible]
		internal struct Array
		{
			// Token: 0x060005E1 RID: 1505 RVA: 0x00014740 File Offset: 0x00012940
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			internal unsafe static void Set<[IsUnmanaged] T>(T* pointer, long count, T t = default(T)) where T : struct, ValueType
			{
				UnsafeUtility.SizeOf<T>();
				int num = 0;
				while ((long)num < count)
				{
					pointer[(IntPtr)num * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)] = t;
					num++;
				}
			}

			// Token: 0x060005E2 RID: 1506 RVA: 0x00014774 File Offset: 0x00012974
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			internal unsafe static void Clear<[IsUnmanaged] T>(T* pointer, long count) where T : struct, ValueType
			{
				long size = count * (long)UnsafeUtility.SizeOf<T>();
				UnsafeUtility.MemClear((void*)pointer, size);
			}

			// Token: 0x060005E3 RID: 1507 RVA: 0x00014794 File Offset: 0x00012994
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			internal unsafe static void Copy<[IsUnmanaged] T>(T* dest, T* src, long count) where T : struct, ValueType
			{
				long size = count * (long)UnsafeUtility.SizeOf<T>();
				UnsafeUtility.MemCpy((void*)dest, (void*)src, size);
			}
		}
	}
}
