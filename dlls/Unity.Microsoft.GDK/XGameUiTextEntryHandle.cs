using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000148 RID: 328
	public class XGameUiTextEntryHandle : EquatableHandle
	{
		// Token: 0x06000802 RID: 2050 RVA: 0x0000D748 File Offset: 0x0000B948
		public XGameUiTextEntryHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0000D757 File Offset: 0x0000B957
		protected override bool ReleaseHandle()
		{
			NativeMethods.XGameUiTextEntryClose(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0000D770 File Offset: 0x0000B970
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
