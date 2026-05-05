using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000106 RID: 262
	public static class HashSetExtensions
	{
		// Token: 0x060009F2 RID: 2546 RVA: 0x0001FA48 File Offset: 0x0001DC48
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0001FA9C File Offset: 0x0001DC9C
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0001FB24 File Offset: 0x0001DD24
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0001FB78 File Offset: 0x0001DD78
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0001FBCC File Offset: 0x0001DDCC
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0001FC54 File Offset: 0x0001DE54
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0001FCA8 File Offset: 0x0001DEA8
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0001FCFC File Offset: 0x0001DEFC
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0001FD84 File Offset: 0x0001DF84
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x0001FDD8 File Offset: 0x0001DFD8
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0001FE2C File Offset: 0x0001E02C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0001FEB4 File Offset: 0x0001E0B4
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0001FF08 File Offset: 0x0001E108
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0001FF5C File Offset: 0x0001E15C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0001FFE4 File Offset: 0x0001E1E4
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00020038 File Offset: 0x0001E238
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0002008C File Offset: 0x0001E28C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00020114 File Offset: 0x0001E314
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00020168 File Offset: 0x0001E368
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000201BC File Offset: 0x0001E3BC
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00020244 File Offset: 0x0001E444
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00020298 File Offset: 0x0001E498
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000202EC File Offset: 0x0001E4EC
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00020374 File Offset: 0x0001E574
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x000203C8 File Offset: 0x0001E5C8
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0002041C File Offset: 0x0001E61C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000204A4 File Offset: 0x0001E6A4
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x000204F8 File Offset: 0x0001E6F8
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0002054C File Offset: 0x0001E74C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x000205D4 File Offset: 0x0001E7D4
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00020628 File Offset: 0x0001E828
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0002067C File Offset: 0x0001E87C
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00020704 File Offset: 0x0001E904
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00020758 File Offset: 0x0001E958
		public static void ExceptWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000207AC File Offset: 0x0001E9AC
		public static void IntersectWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			UnsafeList<T> other2 = new UnsafeList<T>(container.Count(), Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			foreach (T item in other)
			{
				if (container.Contains(item))
				{
					other2.Add(item);
				}
			}
			container.Clear();
			container.UnionWith(other2);
			other2.Dispose();
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00020834 File Offset: 0x0001EA34
		public static void UnionWith<[IsUnmanaged] T>(this UnsafeHashSet<T> container, UnsafeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}
	}
}
