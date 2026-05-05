using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200000F RID: 15
	public sealed class CloningContext : IPoolable, IDisposable
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002B11 File Offset: 0x00000D11
		public Dictionary<object, object> clonings { get; } = new Dictionary<object, object>(ReferenceEqualityComparer.Instance);

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002B19 File Offset: 0x00000D19
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002B21 File Offset: 0x00000D21
		public ICloner fallbackCloner { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002B2A File Offset: 0x00000D2A
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002B32 File Offset: 0x00000D32
		public bool tryPreserveInstances { get; private set; }

		// Token: 0x0600004D RID: 77 RVA: 0x00002B3B File Offset: 0x00000D3B
		void IPoolable.New()
		{
			this.disposed = false;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002B44 File Offset: 0x00000D44
		void IPoolable.Free()
		{
			this.disposed = true;
			this.clonings.Clear();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002B58 File Offset: 0x00000D58
		public void Dispose()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(this.ToString());
			}
			GenericPool<CloningContext>.Free(this);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002B74 File Offset: 0x00000D74
		public static CloningContext New(ICloner fallbackCloner, bool tryPreserveInstances)
		{
			CloningContext cloningContext = GenericPool<CloningContext>.New(() => new CloningContext());
			cloningContext.fallbackCloner = fallbackCloner;
			cloningContext.tryPreserveInstances = tryPreserveInstances;
			return cloningContext;
		}

		// Token: 0x04000012 RID: 18
		private bool disposed;
	}
}
