using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x02000445 RID: 1093
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	public struct ThreadedBatchContext
	{
		// Token: 0x06002464 RID: 9316 RVA: 0x0003D2E0 File Offset: 0x0003B4E0
		[FreeFunction("BatchRendererGroup::AddDrawCommandBatch_Threaded", IsThreadSafe = true)]
		private static BatchID AddDrawCommandBatch(IntPtr brg, IntPtr values, int count, GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize)
		{
			BatchID result;
			ThreadedBatchContext.AddDrawCommandBatch_Injected(brg, values, count, ref buffer, bufferOffset, windowSize, out result);
			return result;
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x0003D2FE File Offset: 0x0003B4FE
		[FreeFunction("BatchRendererGroup::SetDrawCommandBatchBuffer_Threaded", IsThreadSafe = true)]
		private static void SetDrawCommandBatchBuffer(IntPtr brg, BatchID batchID, GraphicsBufferHandle buffer)
		{
			ThreadedBatchContext.SetDrawCommandBatchBuffer_Injected(brg, ref batchID, ref buffer);
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x0003D30A File Offset: 0x0003B50A
		[FreeFunction("BatchRendererGroup::RemoveDrawCommandBatch_Threaded", IsThreadSafe = true)]
		private static void RemoveDrawCommandBatch(IntPtr brg, BatchID batchID)
		{
			ThreadedBatchContext.RemoveDrawCommandBatch_Injected(brg, ref batchID);
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x0003D314 File Offset: 0x0003B514
		public BatchID AddBatch(NativeArray<MetadataValue> batchMetadata, GraphicsBufferHandle buffer)
		{
			return ThreadedBatchContext.AddDrawCommandBatch(this.batchRendererGroup, (IntPtr)batchMetadata.GetUnsafeReadOnlyPtr<MetadataValue>(), batchMetadata.Length, buffer, 0U, 0U);
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x0003D348 File Offset: 0x0003B548
		public BatchID AddBatch(NativeArray<MetadataValue> batchMetadata, GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize)
		{
			return ThreadedBatchContext.AddDrawCommandBatch(this.batchRendererGroup, (IntPtr)batchMetadata.GetUnsafeReadOnlyPtr<MetadataValue>(), batchMetadata.Length, buffer, bufferOffset, windowSize);
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x0003D37B File Offset: 0x0003B57B
		public void SetBatchBuffer(BatchID batchID, GraphicsBufferHandle buffer)
		{
			ThreadedBatchContext.SetDrawCommandBatchBuffer(this.batchRendererGroup, batchID, buffer);
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x0003D38C File Offset: 0x0003B58C
		public void RemoveBatch(BatchID batchID)
		{
			ThreadedBatchContext.RemoveDrawCommandBatch(this.batchRendererGroup, batchID);
		}

		// Token: 0x0600246B RID: 9323
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddDrawCommandBatch_Injected(IntPtr brg, IntPtr values, int count, ref GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize, out BatchID ret);

		// Token: 0x0600246C RID: 9324
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDrawCommandBatchBuffer_Injected(IntPtr brg, ref BatchID batchID, ref GraphicsBufferHandle buffer);

		// Token: 0x0600246D RID: 9325
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveDrawCommandBatch_Injected(IntPtr brg, ref BatchID batchID);

		// Token: 0x04000D98 RID: 3480
		public IntPtr batchRendererGroup;
	}
}
