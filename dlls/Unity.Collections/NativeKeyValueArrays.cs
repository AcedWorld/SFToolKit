using System;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x0200008E RID: 142
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct NativeKeyValueArrays<TKey, TValue> : INativeDisposable, IDisposable where TKey : struct where TValue : struct
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x00014C20 File Offset: 0x00012E20
		public int Length
		{
			get
			{
				return this.Keys.Length;
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00014C2D File Offset: 0x00012E2D
		public NativeKeyValueArrays(int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options)
		{
			this.Keys = CollectionHelper.CreateNativeArray<TKey>(length, allocator, options);
			this.Values = CollectionHelper.CreateNativeArray<TValue>(length, allocator, options);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00014C4B File Offset: 0x00012E4B
		public void Dispose()
		{
			this.Keys.Dispose();
			this.Values.Dispose();
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00014C63 File Offset: 0x00012E63
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return this.Keys.Dispose(this.Values.Dispose(inputDeps));
		}

		// Token: 0x04000269 RID: 617
		public NativeArray<TKey> Keys;

		// Token: 0x0400026A RID: 618
		public NativeArray<TValue> Values;
	}
}
