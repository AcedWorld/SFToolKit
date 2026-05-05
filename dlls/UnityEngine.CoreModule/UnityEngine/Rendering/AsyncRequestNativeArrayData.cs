using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E0 RID: 992
	[UsedByNativeCode]
	[NativeHeader("Runtime/Graphics/AsyncGPUReadbackManaged.h")]
	internal struct AsyncRequestNativeArrayData
	{
		// Token: 0x06002171 RID: 8561 RVA: 0x00037820 File Offset: 0x00035A20
		public static AsyncRequestNativeArrayData CreateAndCheckAccess<T>(NativeArray<T> array) where T : struct
		{
			bool flag = array.m_AllocatorLabel == Allocator.Temp || array.m_AllocatorLabel == Allocator.TempJob;
			if (flag)
			{
				throw new ArgumentException("AsyncGPUReadback cannot use Temp memory as input since the result may only become available at an unspecified point in the future.");
			}
			return new AsyncRequestNativeArrayData
			{
				nativeArrayBuffer = array.GetUnsafePtr<T>(),
				lengthInBytes = (long)array.Length * (long)UnsafeUtility.SizeOf<T>()
			};
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x00037884 File Offset: 0x00035A84
		public static AsyncRequestNativeArrayData CreateAndCheckAccess<T>(NativeSlice<T> array) where T : struct
		{
			return new AsyncRequestNativeArrayData
			{
				nativeArrayBuffer = array.GetUnsafePtr<T>(),
				lengthInBytes = (long)array.Length * (long)UnsafeUtility.SizeOf<T>()
			};
		}

		// Token: 0x04000B0B RID: 2827
		public unsafe void* nativeArrayBuffer;

		// Token: 0x04000B0C RID: 2828
		public long lengthInBytes;
	}
}
