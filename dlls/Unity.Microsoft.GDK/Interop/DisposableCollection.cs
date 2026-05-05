using System;
using System.Collections.Generic;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001BA RID: 442
	public class DisposableCollection : IDisposable
	{
		// Token: 0x06000A62 RID: 2658 RVA: 0x0000FCA1 File Offset: 0x0000DEA1
		public DisposableCollection()
		{
			this.disposables = new List<IDisposable>();
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0000FCB4 File Offset: 0x0000DEB4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0000FCC4 File Offset: 0x0000DEC4
		private void Dispose(bool isDisposing)
		{
			foreach (IDisposable disposable in this.disposables)
			{
				DisposableBuffer disposableBuffer = (DisposableBuffer)disposable;
				if (disposableBuffer != null)
				{
					disposableBuffer.Dispose();
				}
			}
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0000FD20 File Offset: 0x0000DF20
		~DisposableCollection()
		{
			this.Dispose(false);
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0000FD50 File Offset: 0x0000DF50
		public T Add<T>(T disposable) where T : IDisposable
		{
			this.disposables.Add(disposable);
			return disposable;
		}

		// Token: 0x040005D5 RID: 1493
		private readonly List<IDisposable> disposables;
	}
}
