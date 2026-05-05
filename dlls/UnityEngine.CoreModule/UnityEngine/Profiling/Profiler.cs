using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Profiling
{
	// Token: 0x020002BA RID: 698
	[NativeHeader("Runtime/Profiler/ScriptBindings/Profiler.bindings.h")]
	[NativeHeader("Runtime/Profiler/Profiler.h")]
	[NativeHeader("Runtime/Profiler/MemoryProfiler.h")]
	[NativeHeader("Runtime/Allocator/MemoryManager.h")]
	[UsedByNativeCode]
	[MovedFrom("UnityEngine")]
	[NativeHeader("Runtime/Utilities/MemoryUtilities.h")]
	[NativeHeader("Runtime/ScriptingBackend/ScriptingApi.h")]
	public sealed class Profiler
	{
		// Token: 0x06001DB3 RID: 7603 RVA: 0x00009E2F File Offset: 0x0000802F
		private Profiler()
		{
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001DB4 RID: 7604
		public static extern bool supported { [NativeMethod(Name = "profiler_is_available", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06001DB5 RID: 7605
		// (set) Token: 0x06001DB6 RID: 7606
		[StaticAccessor("ProfilerBindings", StaticAccessorType.DoubleColon)]
		public static extern string logFile { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06001DB7 RID: 7607
		// (set) Token: 0x06001DB8 RID: 7608
		public static extern bool enableBinaryLog { [NativeMethod(Name = "ProfilerBindings::IsBinaryLogEnabled", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "ProfilerBindings::SetBinaryLogEnabled", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06001DB9 RID: 7609
		// (set) Token: 0x06001DBA RID: 7610
		public static extern int maxUsedMemory { [NativeMethod(Name = "ProfilerBindings::GetMaxUsedMemory", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "ProfilerBindings::SetMaxUsedMemory", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06001DBB RID: 7611
		// (set) Token: 0x06001DBC RID: 7612
		public static extern bool enabled { [NativeConditional("ENABLE_PROFILER")] [NativeMethod(Name = "profiler_is_enabled", IsFreeFunction = true, IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "ProfilerBindings::SetProfilerEnabled", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06001DBD RID: 7613
		// (set) Token: 0x06001DBE RID: 7614
		public static extern bool enableAllocationCallstacks { [NativeMethod(Name = "ProfilerBindings::IsAllocationCallstackCaptureEnabled", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "ProfilerBindings::SetAllocationCallstackCaptureEnabled", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001DBF RID: 7615
		[FreeFunction("ProfilerBindings::profiler_set_area_enabled")]
		[Conditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetAreaEnabled(ProfilerArea area, bool enabled);

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x00030F7C File Offset: 0x0002F17C
		public static int areaCount
		{
			get
			{
				return Enum.GetNames(typeof(ProfilerArea)).Length;
			}
		}

		// Token: 0x06001DC1 RID: 7617
		[FreeFunction("ProfilerBindings::profiler_is_area_enabled")]
		[NativeConditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetAreaEnabled(ProfilerArea area);

		// Token: 0x06001DC2 RID: 7618 RVA: 0x00030FA0 File Offset: 0x0002F1A0
		[Conditional("UNITY_EDITOR")]
		public static void AddFramesFromFile(string file)
		{
			bool flag = string.IsNullOrEmpty(file);
			if (flag)
			{
				Debug.LogError("AddFramesFromFile: Invalid or empty path");
			}
			else
			{
				Profiler.AddFramesFromFile_Internal(file, true);
			}
		}

		// Token: 0x06001DC3 RID: 7619
		[NativeMethod(Name = "LoadFromFile")]
		[NativeHeader("Modules/ProfilerEditor/Public/ProfilerSession.h")]
		[NativeConditional("ENABLE_PROFILER && UNITY_EDITOR")]
		[StaticAccessor("profiling::GetProfilerSessionPtr()", StaticAccessorType.Arrow)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddFramesFromFile_Internal(string file, bool keepExistingFrames);

		// Token: 0x06001DC4 RID: 7620 RVA: 0x00030FD0 File Offset: 0x0002F1D0
		[Conditional("ENABLE_PROFILER")]
		public static void BeginThreadProfiling(string threadGroupName, string threadName)
		{
			bool flag = string.IsNullOrEmpty(threadGroupName);
			if (flag)
			{
				throw new ArgumentException("Argument should be a valid string", "threadGroupName");
			}
			bool flag2 = string.IsNullOrEmpty(threadName);
			if (flag2)
			{
				throw new ArgumentException("Argument should be a valid string", "threadName");
			}
			Profiler.BeginThreadProfilingInternal(threadGroupName, threadName);
		}

		// Token: 0x06001DC5 RID: 7621
		[NativeMethod(Name = "ProfilerBindings::BeginThreadProfiling", IsFreeFunction = true, IsThreadSafe = true)]
		[NativeConditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginThreadProfilingInternal(string threadGroupName, string threadName);

		// Token: 0x06001DC6 RID: 7622 RVA: 0x00002669 File Offset: 0x00000869
		[NativeConditional("ENABLE_PROFILER")]
		public static void EndThreadProfiling()
		{
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x0003101A File Offset: 0x0002F21A
		[Conditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BeginSample(string name)
		{
			Profiler.ValidateArguments(name);
			Profiler.BeginSampleImpl(name, null);
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x0003102C File Offset: 0x0002F22C
		[Conditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BeginSample(string name, Object targetObject)
		{
			Profiler.ValidateArguments(name);
			Profiler.BeginSampleImpl(name, targetObject);
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x00031040 File Offset: 0x0002F240
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ValidateArguments(string name)
		{
			bool flag = string.IsNullOrEmpty(name);
			if (flag)
			{
				throw new ArgumentException("Argument should be a valid string.", "name");
			}
		}

		// Token: 0x06001DCA RID: 7626
		[NativeMethod(Name = "ProfilerBindings::BeginSample", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginSampleImpl(string name, Object targetObject);

		// Token: 0x06001DCB RID: 7627
		[NativeMethod(Name = "ProfilerBindings::EndSample", IsFreeFunction = true, IsThreadSafe = true)]
		[Conditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndSample();

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001DCC RID: 7628 RVA: 0x0003106C File Offset: 0x0002F26C
		// (set) Token: 0x06001DCD RID: 7629 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("maxNumberOfSamplesPerFrame has been depricated. Use maxUsedMemory instead")]
		public static int maxNumberOfSamplesPerFrame
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001DCE RID: 7630 RVA: 0x00031080 File Offset: 0x0002F280
		[Obsolete("usedHeapSize has been deprecated since it is limited to 4GB. Please use usedHeapSizeLong instead.")]
		public static uint usedHeapSize
		{
			get
			{
				return (uint)Profiler.usedHeapSizeLong;
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001DCF RID: 7631
		public static extern long usedHeapSizeLong { [NativeMethod(Name = "GetUsedHeapSize", IsFreeFunction = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001DD0 RID: 7632 RVA: 0x00031098 File Offset: 0x0002F298
		[Obsolete("GetRuntimeMemorySize has been deprecated since it is limited to 2GB. Please use GetRuntimeMemorySizeLong() instead.")]
		public static int GetRuntimeMemorySize(Object o)
		{
			return (int)Profiler.GetRuntimeMemorySizeLong(o);
		}

		// Token: 0x06001DD1 RID: 7633
		[NativeMethod(Name = "ProfilerBindings::GetRuntimeMemorySizeLong", IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetRuntimeMemorySizeLong([NotNull("ArgumentNullException")] Object o);

		// Token: 0x06001DD2 RID: 7634 RVA: 0x000310B4 File Offset: 0x0002F2B4
		[Obsolete("GetMonoHeapSize has been deprecated since it is limited to 4GB. Please use GetMonoHeapSizeLong() instead.")]
		public static uint GetMonoHeapSize()
		{
			return (uint)Profiler.GetMonoHeapSizeLong();
		}

		// Token: 0x06001DD3 RID: 7635
		[NativeMethod(Name = "scripting_gc_get_heap_size", IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetMonoHeapSizeLong();

		// Token: 0x06001DD4 RID: 7636 RVA: 0x000310CC File Offset: 0x0002F2CC
		[Obsolete("GetMonoUsedSize has been deprecated since it is limited to 4GB. Please use GetMonoUsedSizeLong() instead.")]
		public static uint GetMonoUsedSize()
		{
			return (uint)Profiler.GetMonoUsedSizeLong();
		}

		// Token: 0x06001DD5 RID: 7637
		[NativeMethod(Name = "scripting_gc_get_used_size", IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetMonoUsedSizeLong();

		// Token: 0x06001DD6 RID: 7638
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool SetTempAllocatorRequestedSize(uint size);

		// Token: 0x06001DD7 RID: 7639
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetTempAllocatorSize();

		// Token: 0x06001DD8 RID: 7640 RVA: 0x000310E4 File Offset: 0x0002F2E4
		[Obsolete("GetTotalAllocatedMemory has been deprecated since it is limited to 4GB. Please use GetTotalAllocatedMemoryLong() instead.")]
		public static uint GetTotalAllocatedMemory()
		{
			return (uint)Profiler.GetTotalAllocatedMemoryLong();
		}

		// Token: 0x06001DD9 RID: 7641
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[NativeMethod(Name = "GetTotalAllocatedMemory")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetTotalAllocatedMemoryLong();

		// Token: 0x06001DDA RID: 7642 RVA: 0x000310FC File Offset: 0x0002F2FC
		[Obsolete("GetTotalUnusedReservedMemory has been deprecated since it is limited to 4GB. Please use GetTotalUnusedReservedMemoryLong() instead.")]
		public static uint GetTotalUnusedReservedMemory()
		{
			return (uint)Profiler.GetTotalUnusedReservedMemoryLong();
		}

		// Token: 0x06001DDB RID: 7643
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[NativeMethod(Name = "GetTotalUnusedReservedMemory")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetTotalUnusedReservedMemoryLong();

		// Token: 0x06001DDC RID: 7644 RVA: 0x00031114 File Offset: 0x0002F314
		[Obsolete("GetTotalReservedMemory has been deprecated since it is limited to 4GB. Please use GetTotalReservedMemoryLong() instead.")]
		public static uint GetTotalReservedMemory()
		{
			return (uint)Profiler.GetTotalReservedMemoryLong();
		}

		// Token: 0x06001DDD RID: 7645
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[NativeMethod(Name = "GetTotalReservedMemory")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetTotalReservedMemoryLong();

		// Token: 0x06001DDE RID: 7646 RVA: 0x0003112C File Offset: 0x0002F32C
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		public static long GetTotalFragmentationInfo(NativeArray<int> stats)
		{
			return Profiler.InternalGetTotalFragmentationInfo((IntPtr)stats.GetUnsafePtr<int>(), stats.Length);
		}

		// Token: 0x06001DDF RID: 7647
		[NativeConditional("ENABLE_MEMORY_MANAGER")]
		[NativeMethod(Name = "GetTotalFragmentationInfo")]
		[StaticAccessor("GetMemoryManager()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long InternalGetTotalFragmentationInfo(IntPtr pStats, int count);

		// Token: 0x06001DE0 RID: 7648
		[NativeMethod(Name = "GetRegisteredGFXDriverMemory", IsThreadSafe = true)]
		[StaticAccessor("MemoryProfiler", StaticAccessorType.DoubleColon)]
		[NativeConditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetAllocatedMemoryForGraphicsDriver();

		// Token: 0x06001DE1 RID: 7649 RVA: 0x00031158 File Offset: 0x0002F358
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitFrameMetaData(Guid id, int tag, Array data)
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			Type elementType = data.GetType().GetElementType();
			bool flag2 = !UnsafeUtility.IsBlittable(elementType);
			if (flag2)
			{
				throw new ArgumentException(string.Format("{0} type must be blittable", elementType));
			}
			Profiler.Internal_EmitGlobalMetaData_Array((void*)(&id), 16, tag, data, data.Length, UnsafeUtility.SizeOf(elementType), true);
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x000311C0 File Offset: 0x0002F3C0
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitFrameMetaData<T>(Guid id, int tag, List<T> data) where T : struct
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			Type typeFromHandle = typeof(T);
			bool flag2 = !UnsafeUtility.IsBlittable(typeof(T));
			if (flag2)
			{
				throw new ArgumentException(string.Format("{0} type must be blittable", typeFromHandle));
			}
			Profiler.Internal_EmitGlobalMetaData_Array((void*)(&id), 16, tag, NoAllocHelpers.ExtractArrayFromList(data), data.Count, UnsafeUtility.SizeOf(typeFromHandle), true);
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x00031232 File Offset: 0x0002F432
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitFrameMetaData<T>(Guid id, int tag, NativeArray<T> data) where T : struct
		{
			Profiler.Internal_EmitGlobalMetaData_Native((void*)(&id), 16, tag, (IntPtr)data.GetUnsafeReadOnlyPtr<T>(), data.Length, UnsafeUtility.SizeOf<T>(), true);
		}

		// Token: 0x06001DE4 RID: 7652 RVA: 0x0003125C File Offset: 0x0002F45C
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitSessionMetaData(Guid id, int tag, Array data)
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			Type elementType = data.GetType().GetElementType();
			bool flag2 = !UnsafeUtility.IsBlittable(elementType);
			if (flag2)
			{
				throw new ArgumentException(string.Format("{0} type must be blittable", elementType));
			}
			Profiler.Internal_EmitGlobalMetaData_Array((void*)(&id), 16, tag, data, data.Length, UnsafeUtility.SizeOf(elementType), false);
		}

		// Token: 0x06001DE5 RID: 7653 RVA: 0x000312C4 File Offset: 0x0002F4C4
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitSessionMetaData<T>(Guid id, int tag, List<T> data) where T : struct
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			Type typeFromHandle = typeof(T);
			bool flag2 = !UnsafeUtility.IsBlittable(typeof(T));
			if (flag2)
			{
				throw new ArgumentException(string.Format("{0} type must be blittable", typeFromHandle));
			}
			Profiler.Internal_EmitGlobalMetaData_Array((void*)(&id), 16, tag, NoAllocHelpers.ExtractArrayFromList(data), data.Count, UnsafeUtility.SizeOf(typeFromHandle), false);
		}

		// Token: 0x06001DE6 RID: 7654 RVA: 0x00031336 File Offset: 0x0002F536
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void EmitSessionMetaData<T>(Guid id, int tag, NativeArray<T> data) where T : struct
		{
			Profiler.Internal_EmitGlobalMetaData_Native((void*)(&id), 16, tag, (IntPtr)data.GetUnsafeReadOnlyPtr<T>(), data.Length, UnsafeUtility.SizeOf<T>(), false);
		}

		// Token: 0x06001DE7 RID: 7655
		[NativeMethod(Name = "ProfilerBindings::Internal_EmitGlobalMetaData_Array", IsFreeFunction = true, IsThreadSafe = true)]
		[NativeConditional("ENABLE_PROFILER")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Internal_EmitGlobalMetaData_Array(void* id, int idLen, int tag, Array data, int count, int elementSize, bool frameData);

		// Token: 0x06001DE8 RID: 7656
		[NativeConditional("ENABLE_PROFILER")]
		[NativeMethod(Name = "ProfilerBindings::Internal_EmitGlobalMetaData_Native", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Internal_EmitGlobalMetaData_Native(void* id, int idLen, int tag, IntPtr data, int count, int elementSize, bool frameData);

		// Token: 0x06001DE9 RID: 7657 RVA: 0x00031360 File Offset: 0x0002F560
		[Conditional("ENABLE_PROFILER")]
		public static void SetCategoryEnabled(ProfilerCategory category, bool enabled)
		{
			bool flag = category == ProfilerCategory.Any;
			if (flag)
			{
				throw new ArgumentException("Argument should be a valid category", "category");
			}
			Profiler.Internal_SetCategoryEnabled(category, enabled);
		}

		// Token: 0x06001DEA RID: 7658 RVA: 0x000313A4 File Offset: 0x0002F5A4
		public static bool IsCategoryEnabled(ProfilerCategory category)
		{
			bool flag = category == ProfilerCategory.Any;
			if (flag)
			{
				throw new ArgumentException("Argument should be a valid category", "category");
			}
			return Profiler.Internal_IsCategoryEnabled(category);
		}

		// Token: 0x06001DEB RID: 7659
		[NativeConditional("ENABLE_PROFILER")]
		[NativeMethod(Name = "GetCategoriesCount")]
		[StaticAccessor("profiling::GetProfilerManagerPtr()", StaticAccessorType.Arrow)]
		[NativeHeader("Runtime/Profiler/ProfilerManager.h")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint GetCategoriesCount();

		// Token: 0x06001DEC RID: 7660 RVA: 0x000313E8 File Offset: 0x0002F5E8
		[Conditional("ENABLE_PROFILER")]
		public static void GetAllCategories(ProfilerCategory[] categories)
		{
			int num = 0;
			while ((long)num < Math.Min((long)((ulong)Profiler.GetCategoriesCount()), (long)categories.Length))
			{
				categories[num] = new ProfilerCategory((ushort)num);
				num++;
			}
		}

		// Token: 0x06001DED RID: 7661 RVA: 0x00031424 File Offset: 0x0002F624
		[Conditional("ENABLE_PROFILER")]
		public static void GetAllCategories(NativeArray<ProfilerCategory> categories)
		{
			int num = 0;
			while ((long)num < Math.Min((long)((ulong)Profiler.GetCategoriesCount()), (long)categories.Length))
			{
				categories[num] = new ProfilerCategory((ushort)num);
				num++;
			}
		}

		// Token: 0x06001DEE RID: 7662
		[NativeConditional("ENABLE_PROFILER")]
		[NativeMethod(Name = "profiler_set_category_enable", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_SetCategoryEnabled(ushort categoryId, bool enabled);

		// Token: 0x06001DEF RID: 7663
		[NativeConditional("ENABLE_PROFILER")]
		[NativeMethod(Name = "profiler_is_category_enabled", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_IsCategoryEnabled(ushort categoryId);

		// Token: 0x040009E5 RID: 2533
		internal const uint invalidProfilerArea = 4294967295U;
	}
}
