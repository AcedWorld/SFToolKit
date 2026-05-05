using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x020000B7 RID: 183
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(NativeSortExtension.DefaultComparer<int>)
	}, RequiredUnityDefine = "UNITY_2020_2_OR_NEWER")]
	public struct SortJob<[IsUnmanaged] T, U> where T : struct, ValueType where U : IComparer<T>
	{
		// Token: 0x0600075C RID: 1884 RVA: 0x00017DBC File Offset: 0x00015FBC
		[NotBurstCompatible]
		public JobHandle Schedule(JobHandle inputDeps = default(JobHandle))
		{
			if (this.Length == 0)
			{
				return inputDeps;
			}
			int num = (this.Length + 1023) / 1024;
			int num2 = math.max(1, 128);
			int innerloopBatchCount = num / num2;
			JobHandle dependsOn = new SortJob<T, U>.SegmentSort
			{
				Data = this.Data,
				Comp = this.Comp,
				Length = this.Length,
				SegmentWidth = 1024
			}.Schedule(num, innerloopBatchCount, inputDeps);
			return new SortJob<T, U>.SegmentSortMerge
			{
				Data = this.Data,
				Comp = this.Comp,
				Length = this.Length,
				SegmentWidth = 1024
			}.Schedule(dependsOn);
		}

		// Token: 0x040002AB RID: 683
		public unsafe T* Data;

		// Token: 0x040002AC RID: 684
		public U Comp;

		// Token: 0x040002AD RID: 685
		public int Length;

		// Token: 0x020000B8 RID: 184
		[BurstCompile]
		private struct SegmentSort : IJobParallelFor
		{
			// Token: 0x0600075D RID: 1885 RVA: 0x00017E80 File Offset: 0x00016080
			public void Execute(int index)
			{
				int num = index * this.SegmentWidth;
				int length = (this.Length - num < this.SegmentWidth) ? (this.Length - num) : this.SegmentWidth;
				NativeSortExtension.Sort<T, U>(this.Data + (IntPtr)num * (IntPtr)sizeof(T) / (IntPtr)sizeof(T), length, this.Comp);
			}

			// Token: 0x040002AE RID: 686
			[NativeDisableUnsafePtrRestriction]
			public unsafe T* Data;

			// Token: 0x040002AF RID: 687
			public U Comp;

			// Token: 0x040002B0 RID: 688
			public int Length;

			// Token: 0x040002B1 RID: 689
			public int SegmentWidth;
		}

		// Token: 0x020000B9 RID: 185
		[BurstCompile]
		private struct SegmentSortMerge : IJob
		{
			// Token: 0x0600075E RID: 1886 RVA: 0x00017ED4 File Offset: 0x000160D4
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

			// Token: 0x040002B2 RID: 690
			[NativeDisableUnsafePtrRestriction]
			public unsafe T* Data;

			// Token: 0x040002B3 RID: 691
			public U Comp;

			// Token: 0x040002B4 RID: 692
			public int Length;

			// Token: 0x040002B5 RID: 693
			public int SegmentWidth;
		}
	}
}
