using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200015F RID: 351
	public struct OverrideLayer<T> : IDisposable
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0002839F File Offset: 0x0002659F
		public readonly OverrideStack<T> stack { get; }

		// Token: 0x0600094D RID: 2381 RVA: 0x000283A7 File Offset: 0x000265A7
		internal OverrideLayer(OverrideStack<T> stack, T item)
		{
			Ensure.That("stack").IsNotNull<OverrideStack<T>>(stack);
			this.stack = stack;
			stack.BeginOverride(item);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000283C7 File Offset: 0x000265C7
		public void Dispose()
		{
			this.stack.EndOverride();
		}
	}
}
