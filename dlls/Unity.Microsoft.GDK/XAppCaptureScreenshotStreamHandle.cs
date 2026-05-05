using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200002A RID: 42
	public class XAppCaptureScreenshotStreamHandle : EquatableHandle
	{
		// Token: 0x06000309 RID: 777 RVA: 0x000091CF File Offset: 0x000073CF
		public XAppCaptureScreenshotStreamHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000091DE File Offset: 0x000073DE
		protected override bool ReleaseHandle()
		{
			this.CloseResult = NativeMethods.XAppCaptureCloseScreenshotStream(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return HR.SUCCEEDED(this.CloseResult);
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00009207 File Offset: 0x00007407
		// (set) Token: 0x0600030C RID: 780 RVA: 0x0000920F File Offset: 0x0000740F
		public int CloseResult { get; private set; }

		// Token: 0x0600030D RID: 781 RVA: 0x00009218 File Offset: 0x00007418
		internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out XAppCaptureScreenshotStreamHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XAppCaptureScreenshotStreamHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00009230 File Offset: 0x00007430
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
