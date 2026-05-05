using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200019B RID: 411
	public class XTaskQueueHandle : EquatableHandle
	{
		// Token: 0x060009E8 RID: 2536 RVA: 0x0000F1F0 File Offset: 0x0000D3F0
		public XTaskQueueHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0000F1FF File Offset: 0x0000D3FF
		protected override bool ReleaseHandle()
		{
			NativeMethods.XTaskQueueCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x0000F218 File Offset: 0x0000D418
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
