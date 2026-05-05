using System;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;

namespace UnityEngine.Jobs
{
	// Token: 0x020002BF RID: 703
	public static class IJobParallelForTransformExtensions
	{
		// Token: 0x06001E0F RID: 7695 RVA: 0x000319BB File Offset: 0x0002FBBB
		public static void EarlyJobInit<T>() where T : struct, IJobParallelForTransform
		{
			IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.Initialize();
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x000319C4 File Offset: 0x0002FBC4
		private unsafe static IntPtr GetReflectionData<T>() where T : struct, IJobParallelForTransform
		{
			IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.Initialize();
			return *IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.jobReflectionData.Data;
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x000319EC File Offset: 0x0002FBEC
		public static JobHandle Schedule<T>(this T jobData, TransformAccessArray transforms, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), dependsOn, ScheduleMode.Batched);
			return JobsUtility.ScheduleParallelForTransform(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule());
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x00031A24 File Offset: 0x0002FC24
		public static JobHandle ScheduleReadOnly<T>(this T jobData, TransformAccessArray transforms, int batchSize, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), dependsOn, ScheduleMode.Batched);
			return JobsUtility.ScheduleParallelForTransformReadOnly(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule(), batchSize);
		}

		// Token: 0x06001E13 RID: 7699 RVA: 0x00031A5C File Offset: 0x0002FC5C
		public static void RunReadOnly<T>(this T jobData, TransformAccessArray transforms) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), default(JobHandle), ScheduleMode.Run);
			JobsUtility.ScheduleParallelForTransformReadOnly(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule(), transforms.length);
		}

		// Token: 0x06001E14 RID: 7700 RVA: 0x00031AA0 File Offset: 0x0002FCA0
		public static JobHandle ScheduleByRef<T>(this T jobData, TransformAccessArray transforms, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), dependsOn, ScheduleMode.Batched);
			return JobsUtility.ScheduleParallelForTransform(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule());
		}

		// Token: 0x06001E15 RID: 7701 RVA: 0x00031AD4 File Offset: 0x0002FCD4
		public static JobHandle ScheduleReadOnlyByRef<T>(this T jobData, TransformAccessArray transforms, int batchSize, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), dependsOn, ScheduleMode.Batched);
			return JobsUtility.ScheduleParallelForTransformReadOnly(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule(), batchSize);
		}

		// Token: 0x06001E16 RID: 7702 RVA: 0x00031B0C File Offset: 0x0002FD0C
		public static void RunReadOnlyByRef<T>(this T jobData, TransformAccessArray transforms) where T : struct, IJobParallelForTransform
		{
			JobsUtility.JobScheduleParameters jobScheduleParameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf<T>(ref jobData), IJobParallelForTransformExtensions.GetReflectionData<T>(), default(JobHandle), ScheduleMode.Run);
			JobsUtility.ScheduleParallelForTransformReadOnly(ref jobScheduleParameters, transforms.GetTransformAccessArrayForSchedule(), transforms.length);
		}

		// Token: 0x020002C0 RID: 704
		internal struct TransformParallelForLoopStruct<T> where T : struct, IJobParallelForTransform
		{
			// Token: 0x06001E17 RID: 7703 RVA: 0x00031B4C File Offset: 0x0002FD4C
			[BurstDiscard]
			internal unsafe static void Initialize()
			{
				bool flag = *IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.jobReflectionData.Data == IntPtr.Zero;
				if (flag)
				{
					*IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.jobReflectionData.Data = JobsUtility.CreateJobReflectionData(typeof(T), new IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.ExecuteJobFunction(IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.Execute), null, null);
				}
			}

			// Token: 0x06001E18 RID: 7704 RVA: 0x00031B9C File Offset: 0x0002FD9C
			public unsafe static void Execute(ref T jobData, IntPtr jobData2, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
			{
				IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.TransformJobData transformJobData;
				UnsafeUtility.CopyPtrToStructure<IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>.TransformJobData>((void*)jobData2, out transformJobData);
				int* ptr = (int*)((void*)TransformAccessArray.GetSortedToUserIndex(transformJobData.TransformAccessArray));
				TransformAccess* ptr2 = (TransformAccess*)((void*)TransformAccessArray.GetSortedTransformAccess(transformJobData.TransformAccessArray));
				bool flag = transformJobData.IsReadOnly == 1;
				if (flag)
				{
					for (;;)
					{
						int num;
						int num2;
						bool flag2 = !JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out num, out num2);
						if (flag2)
						{
							break;
						}
						int num3 = num2;
						for (int i = num; i < num3; i++)
						{
							int num4 = i;
							int index = ptr[num4];
							TransformAccess transform = ptr2[num4];
							jobData.Execute(index, transform);
						}
					}
				}
				else
				{
					int num5;
					int num6;
					JobsUtility.GetJobRange(ref ranges, jobIndex, out num5, out num6);
					for (int j = num5; j < num6; j++)
					{
						int num7 = j;
						int index2 = ptr[num7];
						TransformAccess transform2 = ptr2[num7];
						jobData.Execute(index2, transform2);
					}
				}
			}

			// Token: 0x040009ED RID: 2541
			internal static readonly BurstLike.SharedStatic<IntPtr> jobReflectionData = BurstLike.SharedStatic<IntPtr>.GetOrCreate<IJobParallelForTransformExtensions.TransformParallelForLoopStruct<T>>(0U);

			// Token: 0x020002C1 RID: 705
			private struct TransformJobData
			{
				// Token: 0x040009EE RID: 2542
				public IntPtr TransformAccessArray;

				// Token: 0x040009EF RID: 2543
				public int IsReadOnly;
			}

			// Token: 0x020002C2 RID: 706
			// (Invoke) Token: 0x06001E1B RID: 7707
			public delegate void ExecuteJobFunction(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	}
}
