using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000029 RID: 41
	public class XAppCaptureLocalStreamHandle : EquatableHandle
	{
		// Token: 0x06000304 RID: 772 RVA: 0x00009174 File Offset: 0x00007374
		public XAppCaptureLocalStreamHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00009183 File Offset: 0x00007383
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0000918B File Offset: 0x0000738B
		public int CloseResult { get; private set; }

		// Token: 0x06000307 RID: 775 RVA: 0x00009194 File Offset: 0x00007394
		protected override bool ReleaseHandle()
		{
			this.CloseResult = NativeMethods.XAppCaptureCloseLocalStream(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return HR.SUCCEEDED(this.CloseResult);
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000091BD File Offset: 0x000073BD
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
