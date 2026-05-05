using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x020000B3 RID: 179
	[BurstCompatible]
	public static class NativeSortExtension
	{
		// Token: 0x06000720 RID: 1824 RVA: 0x000170C0 File Offset: 0x000152C0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static void Sort<[IsUnmanaged] T>(T* array, int length) where T : struct, ValueType, IComparable<T>
		{
			NativeSortExtension.IntroSort<T, NativeSortExtension.DefaultComparer<T>>((void*)array, length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000170DD File Offset: 0x000152DD
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(T* array, int length, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			NativeSortExtension.IntroSort<T, U>((void*)array, length, comp);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000170E8 File Offset: 0x000152E8
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(T*, int).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T>(T* array, int length, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.Sort<T, NativeSortExtension.DefaultComparer<T>>(array, length, default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00017108 File Offset: 0x00015308
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(T* array, int length) where T : struct, ValueType, IComparable<T>
		{
			return new SortJob<T, NativeSortExtension.DefaultComparer<T>>
			{
				Data = array,
				Length = length,
				Comp = default(NativeSortExtension.DefaultComparer<T>)
			};
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001713C File Offset: 0x0001533C
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(T*, int, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T, U>(T* array, int length, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			if (length == 0)
			{
				return inputDeps;
			}
			int num = (length + 1023) / 1024;
			int num2 = math.max(1, 128);
			int innerloopBatchCount = num / num2;
			JobHandle dependsOn = new NativeSortExtension.SegmentSort<T, U>
			{
				Data = array,
				Comp = comp,
				Length = length,
				SegmentWidth = 1024
			}.Schedule(num, innerloopBatchCount, inputDeps);
			return new NativeSortExtension.SegmentSortMerge<T, U>
			{
				Data = array,
				Comp = comp,
				Length = length,
				SegmentWidth = 1024
			}.Schedule(dependsOn);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x000171D8 File Offset: 0x000153D8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(T* array, int length, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return new SortJob<T, U>
			{
				Data = array,
				Length = length,
				Comp = comp
			};
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00017208 File Offset: 0x00015408
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe static int BinarySearch<[IsUnmanaged] T>(T* ptr, int length, T value) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.BinarySearch<T, NativeSortExtension.DefaultComparer<T>>(ptr, length, value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00017228 File Offset: 0x00015428
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static int BinarySearch<[IsUnmanaged] T, U>(T* ptr, int length, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			int num = 0;
			for (int num2 = length; num2 != 0; num2 >>= 1)
			{
				int num3 = num + (num2 >> 1);
				T y = ptr[(IntPtr)num3 * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
				int num4 = comp.Compare(value, y);
				if (num4 == 0)
				{
					return num3;
				}
				if (num4 > 0)
				{
					num = num3 + 1;
					num2--;
				}
			}
			return ~num;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00017280 File Offset: 0x00015480
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static void Sort<T>(this NativeArray<T> array) where T : struct, IComparable<T>
		{
			NativeSortExtension.IntroSortStruct<T, NativeSortExtension.DefaultComparer<T>>(array.GetUnsafePtr<T>(), array.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000172A8 File Offset: 0x000154A8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public static void Sort<T, U>(this NativeArray<T> array, U comp) where T : struct where U : IComparer<T>
		{
			NativeSortExtension.IntroSortStruct<T, U>(array.GetUnsafePtr<T>(), array.Length, comp);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x000172C0 File Offset: 0x000154C0
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeArray<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T>(this NativeArray<T> array, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.Sort<T, NativeSortExtension.DefaultComparer<T>>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array), array.Length, default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x000172EC File Offset: 0x000154EC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(this NativeArray<T> array) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.SortJob<T, NativeSortExtension.DefaultComparer<T>>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array), array.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00017314 File Offset: 0x00015514
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeArray<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T, U>(this NativeArray<T> array, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.Sort<T, U>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array), array.Length, comp, inputDeps);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001732C File Offset: 0x0001552C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(this NativeArray<T> array, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return new SortJob<T, U>
			{
				Data = (T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array),
				Length = array.Length,
				Comp = comp
			};
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00017368 File Offset: 0x00015568
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static int BinarySearch<[IsUnmanaged] T>(this NativeArray<T> array, T value) where T : struct, ValueType, IComparable<T>
		{
			return array.BinarySearch(value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00017385 File Offset: 0x00015585
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static int BinarySearch<[IsUnmanaged] T, U>(this NativeArray<T> array, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.BinarySearch<T, U>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array), array.Length, value, comp);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0001739C File Offset: 0x0001559C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static void Sort<[IsUnmanaged] T>(this NativeList<T> list) where T : struct, ValueType, IComparable<T>
		{
			list.Sort(default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000173B8 File Offset: 0x000155B8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public static void Sort<[IsUnmanaged] T, U>(this NativeList<T> list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			NativeSortExtension.IntroSort<T, U>(list.GetUnsafePtr<T>(), list.Length, comp);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000173D0 File Offset: 0x000155D0
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeList<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public static JobHandle Sort<[IsUnmanaged] T>(this NativeList<T> array, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return array.Sort(default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000173F0 File Offset: 0x000155F0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(this NativeList<T> list) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.SortJob<T, NativeSortExtension.DefaultComparer<T>>((T*)list.GetUnsafePtr<T>(), list.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00017418 File Offset: 0x00015618
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeList<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T, U>(this NativeList<T> list, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.Sort<T, U>((T*)list.GetUnsafePtr<T>(), list.Length, comp, inputDeps);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001742E File Offset: 0x0001562E
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(this NativeList<T> list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.SortJob<T, U>((T*)list.GetUnsafePtr<T>(), list.Length, comp);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00017444 File Offset: 0x00015644
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static int BinarySearch<[IsUnmanaged] T>(this NativeList<T> list, T value) where T : struct, ValueType, IComparable<T>
		{
			return list.BinarySearch(value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00017461 File Offset: 0x00015661
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static int BinarySearch<[IsUnmanaged] T, U>(this NativeList<T> list, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.BinarySearch<T, U>((T*)list.GetUnsafePtr<T>(), list.Length, value, comp);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00017478 File Offset: 0x00015678
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static void Sort<[IsUnmanaged] T>(this UnsafeList<T> list) where T : struct, ValueType, IComparable<T>
		{
			list.Sort(default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00017494 File Offset: 0x00015694
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static void Sort<[IsUnmanaged] T, U>(this UnsafeList<T> list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			NativeSortExtension.IntroSort<T, U>((void*)list.Ptr, list.Length, comp);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000174AC File Offset: 0x000156AC
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this UnsafeList<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public static JobHandle Sort<[IsUnmanaged] T>(this UnsafeList<T> list, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return list.Sort(default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000174CC File Offset: 0x000156CC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(this UnsafeList<T> list) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.SortJob<T, NativeSortExtension.DefaultComparer<T>>(list.Ptr, list.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000174F4 File Offset: 0x000156F4
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this UnsafeList<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public static JobHandle Sort<[IsUnmanaged] T, U>(this UnsafeList<T> list, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.Sort<T, U>(list.Ptr, list.Length, comp, inputDeps);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0001750A File Offset: 0x0001570A
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(this UnsafeList<T> list, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.SortJob<T, U>(list.Ptr, list.Length, comp);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00017520 File Offset: 0x00015720
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static int BinarySearch<[IsUnmanaged] T>(this UnsafeList<T> list, T value) where T : struct, ValueType, IComparable<T>
		{
			return list.BinarySearch(value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001753D File Offset: 0x0001573D
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public static int BinarySearch<[IsUnmanaged] T, U>(this UnsafeList<T> list, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.BinarySearch<T, U>(list.Ptr, list.Length, value, comp);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00017554 File Offset: 0x00015754
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static void Sort<T>(this NativeSlice<T> slice) where T : struct, IComparable<T>
		{
			slice.Sort(default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00017570 File Offset: 0x00015770
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public static void Sort<T, U>(this NativeSlice<T> slice, U comp) where T : struct where U : IComparer<T>
		{
			NativeSortExtension.IntroSortStruct<T, U>(slice.GetUnsafePtr<T>(), slice.Length, comp);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00017588 File Offset: 0x00015788
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeSlice<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public static JobHandle Sort<[IsUnmanaged] T>(this NativeSlice<T> slice, JobHandle inputDeps) where T : struct, ValueType, IComparable<T>
		{
			return slice.Sort(default(NativeSortExtension.DefaultComparer<T>), inputDeps);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x000175A8 File Offset: 0x000157A8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, NativeSortExtension.DefaultComparer<T>> SortJob<[IsUnmanaged] T>(this NativeSlice<T> slice) where T : struct, ValueType, IComparable<T>
		{
			return NativeSortExtension.SortJob<T, NativeSortExtension.DefaultComparer<T>>((T*)slice.GetUnsafePtr<T>(), slice.Length, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000175D0 File Offset: 0x000157D0
		[NotBurstCompatible]
		[Obsolete("Instead call SortJob(this NativeSlice<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", false)]
		public unsafe static JobHandle Sort<[IsUnmanaged] T, U>(this NativeSlice<T> slice, U comp, JobHandle inputDeps) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.Sort<T, U>((T*)slice.GetUnsafePtr<T>(), slice.Length, comp, inputDeps);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x000175E6 File Offset: 0x000157E6
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
		public unsafe static SortJob<T, U> SortJob<[IsUnmanaged] T, U>(this NativeSlice<T> slice, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.SortJob<T, U>((T*)slice.GetUnsafePtr<T>(), slice.Length, comp);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x000175FC File Offset: 0x000157FC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static int BinarySearch<[IsUnmanaged] T>(this NativeSlice<T> slice, T value) where T : struct, ValueType, IComparable<T>
		{
			return slice.BinarySearch(value, default(NativeSortExtension.DefaultComparer<T>));
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00017619 File Offset: 0x00015819
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		public unsafe static int BinarySearch<[IsUnmanaged] T, U>(this NativeSlice<T> slice, T value, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			return NativeSortExtension.BinarySearch<T, U>((T*)slice.GetUnsafePtr<T>(), slice.Length, value, comp);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0001762F File Offset: 0x0001582F
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(NativeSortExtension.DefaultComparer<int>)
		})]
		internal unsafe static void IntroSort<[IsUnmanaged] T, U>(void* array, int length, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			NativeSortExtension.IntroSort<T, U>(array, 0, length - 1, 2 * CollectionHelper.Log2Floor(length), comp);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00017644 File Offset: 0x00015844
		private unsafe static void IntroSort<[IsUnmanaged] T, U>(void* array, int lo, int hi, int depth, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			while (hi > lo)
			{
				int num = hi - lo + 1;
				if (num <= 16)
				{
					if (num == 1)
					{
						return;
					}
					if (num == 2)
					{
						NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, lo, hi, comp);
						return;
					}
					if (num == 3)
					{
						NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, lo, hi - 1, comp);
						NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, lo, hi, comp);
						NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, hi - 1, hi, comp);
						return;
					}
					NativeSortExtension.InsertionSort<T, U>(array, lo, hi, comp);
					return;
				}
				else
				{
					if (depth == 0)
					{
						NativeSortExtension.HeapSort<T, U>(array, lo, hi, comp);
						return;
					}
					depth--;
					int num2 = NativeSortExtension.Partition<T, U>(array, lo, hi, comp);
					NativeSortExtension.IntroSort<T, U>(array, num2 + 1, hi, depth, comp);
					hi = num2 - 1;
				}
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000176E0 File Offset: 0x000158E0
		private unsafe static void InsertionSort<[IsUnmanaged] T, U>(void* array, int lo, int hi, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			for (int i = lo; i < hi; i++)
			{
				int num = i;
				T t = UnsafeUtility.ReadArrayElement<T>(array, i + 1);
				while (num >= lo && comp.Compare(t, UnsafeUtility.ReadArrayElement<T>(array, num)) < 0)
				{
					UnsafeUtility.WriteArrayElement<T>(array, num + 1, UnsafeUtility.ReadArrayElement<T>(array, num));
					num--;
				}
				UnsafeUtility.WriteArrayElement<T>(array, num + 1, t);
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00017744 File Offset: 0x00015944
		private unsafe static int Partition<[IsUnmanaged] T, U>(void* array, int lo, int hi, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			int num = lo + (hi - lo) / 2;
			NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, lo, num, comp);
			NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, lo, hi, comp);
			NativeSortExtension.SwapIfGreaterWithItems<T, U>(array, num, hi, comp);
			T x = UnsafeUtility.ReadArrayElement<T>(array, num);
			NativeSortExtension.Swap<T>(array, num, hi - 1);
			int i = lo;
			int num2 = hi - 1;
			while (i < num2)
			{
				while (comp.Compare(x, UnsafeUtility.ReadArrayElement<T>(array, ++i)) > 0)
				{
				}
				while (comp.Compare(x, UnsafeUtility.ReadArrayElement<T>(array, --num2)) < 0)
				{
				}
				if (i >= num2)
				{
					break;
				}
				NativeSortExtension.Swap<T>(array, i, num2);
			}
			NativeSortExtension.Swap<T>(array, i, hi - 1);
			return i;
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x000177E4 File Offset: 0x000159E4
		private unsafe static void HeapSort<[IsUnmanaged] T, U>(void* array, int lo, int hi, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			int num = hi - lo + 1;
			for (int i = num / 2; i >= 1; i--)
			{
				NativeSortExtension.Heapify<T, U>(array, i, num, lo, comp);
			}
			for (int j = num; j > 1; j--)
			{
				NativeSortExtension.Swap<T>(array, lo, lo + j - 1);
				NativeSortExtension.Heapify<T, U>(array, 1, j - 1, lo, comp);
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00017834 File Offset: 0x00015A34
		private unsafe static void Heapify<[IsUnmanaged] T, U>(void* array, int i, int n, int lo, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			T t = UnsafeUtility.ReadArrayElement<T>(array, lo + i - 1);
			while (i <= n / 2)
			{
				int num = 2 * i;
				if (num < n && comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1), UnsafeUtility.ReadArrayElement<T>(array, lo + num)) < 0)
				{
					num++;
				}
				if (comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1), t) < 0)
				{
					break;
				}
				UnsafeUtility.WriteArrayElement<T>(array, lo + i - 1, UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1));
				i = num;
			}
			UnsafeUtility.WriteArrayElement<T>(array, lo + i - 1, t);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000178C8 File Offset: 0x00015AC8
		private unsafe static void Swap<[IsUnmanaged] T>(void* array, int lhs, int rhs) where T : struct, ValueType
		{
			T value = UnsafeUtility.ReadArrayElement<T>(array, lhs);
			UnsafeUtility.WriteArrayElement<T>(array, lhs, UnsafeUtility.ReadArrayElement<T>(array, rhs));
			UnsafeUtility.WriteArrayElement<T>(array, rhs, value);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000178F3 File Offset: 0x00015AF3
		private unsafe static void SwapIfGreaterWithItems<[IsUnmanaged] T, U>(void* array, int lhs, int rhs, U comp) where T : struct, ValueType where U : IComparer<T>
		{
			if (lhs != rhs && comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lhs), UnsafeUtility.ReadArrayElement<T>(array, rhs)) > 0)
			{
				NativeSortExtension.Swap<T>(array, lhs, rhs);
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0001791F File Offset: 0x00015B1F
		private unsafe static void IntroSortStruct<T, U>(void* array, int length, U comp) where T : struct where U : IComparer<T>
		{
			NativeSortExtension.IntroSortStruct<T, U>(array, 0, length - 1, 2 * CollectionHelper.Log2Floor(length), comp);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00017934 File Offset: 0x00015B34
		private unsafe static void IntroSortStruct<T, U>(void* array, int lo, int hi, int depth, U comp) where T : struct where U : IComparer<T>
		{
			while (hi > lo)
			{
				int num = hi - lo + 1;
				if (num <= 16)
				{
					if (num == 1)
					{
						return;
					}
					if (num == 2)
					{
						NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, lo, hi, comp);
						return;
					}
					if (num == 3)
					{
						NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, lo, hi - 1, comp);
						NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, lo, hi, comp);
						NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, hi - 1, hi, comp);
						return;
					}
					NativeSortExtension.InsertionSortStruct<T, U>(array, lo, hi, comp);
					return;
				}
				else
				{
					if (depth == 0)
					{
						NativeSortExtension.HeapSortStruct<T, U>(array, lo, hi, comp);
						return;
					}
					depth--;
					int num2 = NativeSortExtension.PartitionStruct<T, U>(array, lo, hi, comp);
					NativeSortExtension.IntroSortStruct<T, U>(array, num2 + 1, hi, depth, comp);
					hi = num2 - 1;
				}
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x000179D0 File Offset: 0x00015BD0
		private unsafe static void InsertionSortStruct<T, U>(void* array, int lo, int hi, U comp) where T : struct where U : IComparer<T>
		{
			for (int i = lo; i < hi; i++)
			{
				int num = i;
				T t = UnsafeUtility.ReadArrayElement<T>(array, i + 1);
				while (num >= lo && comp.Compare(t, UnsafeUtility.ReadArrayElement<T>(array, num)) < 0)
				{
					UnsafeUtility.WriteArrayElement<T>(array, num + 1, UnsafeUtility.ReadArrayElement<T>(array, num));
					num--;
				}
				UnsafeUtility.WriteArrayElement<T>(array, num + 1, t);
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00017A34 File Offset: 0x00015C34
		private unsafe static int PartitionStruct<T, U>(void* array, int lo, int hi, U comp) where T : struct where U : IComparer<T>
		{
			int num = lo + (hi - lo) / 2;
			NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, lo, num, comp);
			NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, lo, hi, comp);
			NativeSortExtension.SwapIfGreaterWithItemsStruct<T, U>(array, num, hi, comp);
			T x = UnsafeUtility.ReadArrayElement<T>(array, num);
			NativeSortExtension.SwapStruct<T>(array, num, hi - 1);
			int i = lo;
			int num2 = hi - 1;
			while (i < num2)
			{
				while (comp.Compare(x, UnsafeUtility.ReadArrayElement<T>(array, ++i)) > 0)
				{
				}
				while (comp.Compare(x, UnsafeUtility.ReadArrayElement<T>(array, --num2)) < 0)
				{
				}
				if (i >= num2)
				{
					break;
				}
				NativeSortExtension.SwapStruct<T>(array, i, num2);
			}
			NativeSortExtension.SwapStruct<T>(array, i, hi - 1);
			return i;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00017AD4 File Offset: 0x00015CD4
		private unsafe static void HeapSortStruct<T, U>(void* array, int lo, int hi, U comp) where T : struct where U : IComparer<T>
		{
			int num = hi - lo + 1;
			for (int i = num / 2; i >= 1; i--)
			{
				NativeSortExtension.HeapifyStruct<T, U>(array, i, num, lo, comp);
			}
			for (int j = num; j > 1; j--)
			{
				NativeSortExtension.SwapStruct<T>(array, lo, lo + j - 1);
				NativeSortExtension.HeapifyStruct<T, U>(array, 1, j - 1, lo, comp);
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00017B24 File Offset: 0x00015D24
		private unsafe static void HeapifyStruct<T, U>(void* array, int i, int n, int lo, U comp) where T : struct where U : IComparer<T>
		{
			T t = UnsafeUtility.ReadArrayElement<T>(array, lo + i - 1);
			while (i <= n / 2)
			{
				int num = 2 * i;
				if (num < n && comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1), UnsafeUtility.ReadArrayElement<T>(array, lo + num)) < 0)
				{
					num++;
				}
				if (comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1), t) < 0)
				{
					break;
				}
				UnsafeUtility.WriteArrayElement<T>(array, lo + i - 1, UnsafeUtility.ReadArrayElement<T>(array, lo + num - 1));
				i = num;
			}
			UnsafeUtility.WriteArrayElement<T>(array, lo + i - 1, t);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00017BB8 File Offset: 0x00015DB8
		private unsafe static void SwapStruct<T>(void* array, int lhs, int rhs) where T : struct
		{
			T value = UnsafeUtility.ReadArrayElement<T>(array, lhs);
			UnsafeUtility.WriteArrayElement<T>(array, lhs, UnsafeUtility.ReadArrayElement<T>(array, rhs));
			UnsafeUtility.WriteArrayElement<T>(array, rhs, value);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00017BE3 File Offset: 0x00015DE3
		private unsafe static void SwapIfGreaterWithItemsStruct<T, U>(void* array, int lhs, int rhs, U comp) where T : struct where U : IComparer<T>
		{
			if (lhs != rhs && comp.Compare(UnsafeUtility.ReadArrayElement<T>(array, lhs), UnsafeUtility.ReadArrayElement<T>(array, rhs)) > 0)
			{
				NativeSortExtension.SwapStruct<T>(array, lhs, rhs);
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00017C0F File Offset: 0x00015E0F
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckStrideMatchesSize<T>(int stride) where T : struct
		{
			if (stride != UnsafeUtility.SizeOf<T>())
			{
				throw new InvalidOperationException("Sort requires that stride matches the size of the source type");
			}
		}

		// Token: 0x040002A2 RID: 674
		private const int k_IntrosortSizeThreshold = 16;

		// Token: 0x020000B4 RID: 180
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct DefaultComparer<T> : IComparer<T> where T : IComparable<T>
		{
			// Token: 0x06000759 RID: 1881 RVA: 0x00017C24 File Offset: 0x00015E24
			public int Compare(T x, T y)
			{
				return x.CompareTo(y);
			}
		}

		// Token: 0x020000B5 RID: 181
		[BurstCompile]
		private struct SegmentSort<[IsUnmanaged] T, U> : IJobParallelFor where T : struct, ValueType where U : IComparer<T>
		{
			// Token: 0x0600075A RID: 1882 RVA: 0x00017C34 File Offset: 0x00015E34
			public void Execute(int index)
			{
				int num = index * this.SegmentWidth;
				int length = (this.Length - num < this.SegmentWidth) ? (this.Length - num) : this.SegmentWidth;
				NativeSortExtension.Sort<T, U>(this.Data + (IntPtr)num * (IntPtr)sizeof(T) / (IntPtr)sizeof(T), length, this.Comp);
			}

			// Token: 0x040002A3 RID: 675
			[NativeDisableUnsafePtrRestriction]
			public unsafe T* Data;

			// Token: 0x040002A4 RID: 676
			public U Comp;

			// Token: 0x040002A5 RID: 677
			public int Length;

			// Token: 0x040002A6 RID: 678
			public int SegmentWidth;
		}

		// Token: 0x020000B6 RID: 182
		[BurstCompile]
		private struct SegmentSortMerge<[IsUnmanaged] T, U> : IJob where T : struct, ValueType where U : IComparer<T>
		{
			// Token: 0x0600075B RID: 1883 RVA: 0x00017C88 File Offset: 0x00015E88
			public unsafe void Execute()
			{
				int num = (this.Length + (this.SegmentWidth - 1)) / this.SegmentWidth;
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)num) * 4)];
				T* ptr2 = (T*)Memory.Unmanaged.Allocate((long)(UnsafeUtility.SizeOf<T>() * this.Length), 16, Allocator.Temp);
				for (int i = 0; i < this.Length; i++)
				{
					int num2 = -1;
					T t = default(T);
					for (int j = 0; j < num; j++)
					{
						int num3 = j * this.SegmentWidth;
						int num4 = ptr[j];
						int num5 = (this.Length - num3 < this.SegmentWidth) ? (this.Length - num3) : this.SegmentWidth;
						if (num4 != num5)
						{
							T t2 = this.Data[(IntPtr)(num3 + num4) * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
							if (num2 == -1 || this.Comp.Compare(t2, t) <= 0)
							{
								t = t2;
								num2 = j;
							}
						}
					}
					ptr[num2]++;
					ptr2[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)] = t;
				}
				UnsafeUtility.MemCpy((void*)this.Data, (void*)ptr2, (long)(UnsafeUtility.SizeOf<T>() * this.Length));
			}

			// Token: 0x040002A7 RID: 679
			[NativeDisableUnsafePtrRestriction]
			public unsafe T* Data;

			// Token: 0x040002A8 RID: 680
			public U Comp;

			// Token: 0x040002A9 RID: 681
			public int Length;

			// Token: 0x040002AA RID: 682
			public int SegmentWidth;
		}
	}
}
