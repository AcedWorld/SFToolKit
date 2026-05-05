using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200007A RID: 122
	[MovedFrom("Unity.GameCore")]
	public class XblHttpCallHandle : EquatableHandle
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x00009D23 File Offset: 0x00007F23
		internal XblHttpCallHandle(XblHttpCallHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.handle)
		{
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00009D37 File Offset: 0x00007F37
		internal static int WrapInteropHandleAndReturnHResult(int hresult, XblHttpCallHandle interopHandle, out XblHttpCallHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblHttpCallHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00009D4F File Offset: 0x00007F4F
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00009D61 File Offset: 0x00007F61
		protected override bool ReleaseHandle()
		{
			XblInterop.XblHttpCallCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}
	}
}
