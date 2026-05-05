using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200019A RID: 410
	public class XTaskQueueTerminateCallbackHandle
	{
		// Token: 0x060009E3 RID: 2531 RVA: 0x0000F1A6 File Offset: 0x0000D3A6
		internal XTaskQueueTerminateCallbackHandle(XTaskQueueTerminatedCallback callback, IntPtr context)
		{
			this.interop = new XTaskQueueTerminateCallbackHandle(callback, context);
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x0000F1BB File Offset: 0x0000D3BB
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0000F1C8 File Offset: 0x0000D3C8
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x0000F1D5 File Offset: 0x0000D3D5
		public ulong Token
		{
			get
			{
				return this.interop.Token;
			}
			set
			{
				this.interop.Token = value;
			}
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0000F1E3 File Offset: 0x0000D3E3
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x04000588 RID: 1416
		internal XTaskQueueTerminateCallbackHandle interop;
	}
}
