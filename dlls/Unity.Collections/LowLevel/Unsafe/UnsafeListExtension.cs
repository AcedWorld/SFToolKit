using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000DD RID: 221
	public static class UnsafeListExtension
	{
		// Token: 0x060008E6 RID: 2278 RVA: 0x0001C674 File Offset: 0x0001A874
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		internal static ref UnsafeList ListData<[IsUnmanaged] T>(this UnsafeList<T> from) where T : struct, ValueType
		{
			return UnsafeUtility.As<UnsafeList<T>, UnsafeList>(ref from);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001C67C File Offset: 0x0001A87C
		public static void Sort<[IsUnmanaged] T>(this UnsafeList list) where T : struct, ValueType, IComparable<T>
		{
			list.Sort(default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001C698 File Offset: 0x0001A898
		public static void Sort<[IsUnmanaged] T, U>(this UnsafeList list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			NativeSortExtension.IntroSort<T, U>(list.Ptr, list.Length, comp);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001C6AC File Offset: 0x0001A8AC
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this UnsafeList).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public static JobHandle Sort<[IsUnmanaged] T>(this UnsafeList container, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return container.Sort(default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001C6CC File Offset: 0x0001A8CC
		public unsafe static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(this UnsafeList list) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.SortJob<T, NativeSortExtension.DefaultComparer<T>>((T*)list.Ptr, list.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001C6F3 File Offset: 0x0001A8F3
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this UnsafeList, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T, U>(this UnsafeList container, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.Sort<T, U>((T*)container.Ptr, container.Length, comp, inputDeps);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001C708 File Offset: 0x0001A908
		public unsafe static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(this UnsafeList list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.SortJob<T, U>((T*)list.Ptr, list.Length, comp);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001C71C File Offset: 0x0001A91C
		public static int BinarySearch<[IsUnmanaged] T>(this UnsafeList container, T value) where T : struct, ValueType, IComparable<T>
		{
			return container.BinarySearch(value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001C739 File Offset: 0x0001A939
		public unsafe static int BinarySearch<[IsUnmanaged] T, U>(this UnsafeList container, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.BinarySearch<T, U>((T*)container.Ptr, container.Length, value, comp);
		}
	}
}
