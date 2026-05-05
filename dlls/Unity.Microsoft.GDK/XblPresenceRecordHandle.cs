using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D0 RID: 208
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceRecordHandle : EquatableHandle
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x0000B906 File Offset: 0x00009B06
		internal XblPresenceRecordHandle(XblPresenceRecordHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.intPtr)
		{
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000B91A File Offset: 0x00009B1A
		internal static int WrapInteropHandleAndReturnHResult(int hresult, XblPresenceRecordHandle interopHandle, out XblPresenceRecordHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblPresenceRecordHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0000B932 File Offset: 0x00009B32
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000B944 File Offset: 0x00009B44
		protected override bool ReleaseHandle()
		{
			XblInterop.XblPresenceRecordCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}
	}
}
