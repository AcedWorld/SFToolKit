using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000003 RID: 3
	public class CallbackWrapper<T> : IDisposable where T : Delegate
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C8 File Offset: 0x000002C8
		public CallbackWrapper(T callback, IntPtr context, T staticCallback)
		{
			if (staticCallback.Target != null)
			{
				throw new InvalidOperationException("staticCallback must point to a static method");
			}
			this.Callback = callback;
			this.Context = context;
			this.selfPtr = GCHandle.Alloc(this);
			this.StaticCallback = staticCallback;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		~CallbackWrapper()
		{
			this.Dispose(false);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002144 File Offset: 0x00000344
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000214C File Offset: 0x0000034C
		public T StaticCallback { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002155 File Offset: 0x00000355
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000215D File Offset: 0x0000035D
		public T Callback { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002166 File Offset: 0x00000366
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000216E File Offset: 0x0000036E
		public IntPtr Context { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002177 File Offset: 0x00000377
		public IntPtr CallbackContext
		{
			get
			{
				return GCHandle.ToIntPtr(this.selfPtr);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002184 File Offset: 0x00000384
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002193 File Offset: 0x00000393
		protected virtual void Dispose(bool disposing)
		{
			this.selfPtr.Free();
		}

		// Token: 0x04000001 RID: 1
		private GCHandle selfPtr;
	}
}
