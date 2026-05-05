using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x02000098 RID: 152
	public static class HashSetExtensions
	{
		// Token: 0x06000656 RID: 1622 RVA: 0x0001522C File Offset: 0x0001342C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00015280 File Offset: 0x00013480
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x06000658 RID: 1624 RVA: 0x00015308 File Offset: 0x00013508
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList128Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001535C File Offset: 0x0001355C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x000153B0 File Offset: 0x000135B0
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x0600065B RID: 1627 RVA: 0x00015438 File Offset: 0x00013638
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList32Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001548C File Offset: 0x0001368C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x000154E0 File Offset: 0x000136E0
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x0600065E RID: 1630 RVA: 0x00015568 File Offset: 0x00013768
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList4096Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x000155BC File Offset: 0x000137BC
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00015610 File Offset: 0x00013810
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x06000661 RID: 1633 RVA: 0x00015698 File Offset: 0x00013898
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList512Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000156EC File Offset: 0x000138EC
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00015740 File Offset: 0x00013940
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x06000664 RID: 1636 RVA: 0x000157C8 File Offset: 0x000139C8
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, FixedList64Bytes<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001581C File Offset: 0x00013A1C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00015870 File Offset: 0x00013A70
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x06000667 RID: 1639 RVA: 0x000158F8 File Offset: 0x00013AF8
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001594C File Offset: 0x00013B4C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x000159A0 File Offset: 0x00013BA0
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x0600066A RID: 1642 RVA: 0x00015A28 File Offset: 0x00013C28
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeHashSet<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00015A7C File Offset: 0x00013C7C
		public static void ExceptWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Remove(item);
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00015AD0 File Offset: 0x00013CD0
		public static void IntersectWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
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

		// Token: 0x0600066D RID: 1645 RVA: 0x00015B58 File Offset: 0x00013D58
		public static void UnionWith<[IsUnmanaged] T>(this NativeHashSet<T> container, NativeList<T> other) where T : struct, ValueType, IEquatable<T>
		{
			foreach (T item in other)
			{
				container.Add(item);
			}
		}
	}
}
