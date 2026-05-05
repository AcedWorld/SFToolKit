using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017D RID: 381
	public class XStoreProductQuery : EquatableHandle
	{
		// Token: 0x06000937 RID: 2359 RVA: 0x0000E77B File Offset: 0x0000C97B
		public XStoreProductQuery(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0000E78A File Offset: 0x0000C98A
		protected override bool ReleaseHandle()
		{
			NativeMethods.XStoreCloseProductsQueryHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x0000E7A3 File Offset: 0x0000C9A3
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
