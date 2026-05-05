using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000090 RID: 144
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSearchHandle : EquatableHandle
	{
		// Token: 0x060004D2 RID: 1234 RVA: 0x0000A509 File Offset: 0x00008709
		internal XblMultiplayerSearchHandle(XblMultiplayerSearchHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.Ptr)
		{
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000A51D File Offset: 0x0000871D
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000A52F File Offset: 0x0000872F
		internal static int WrapInteropHandleAndReturnHResult(int hresult, XblMultiplayerSearchHandle interopHandle, out XblMultiplayerSearchHandle userHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				userHandle = new XblMultiplayerSearchHandle(interopHandle);
			}
			else
			{
				userHandle = null;
			}
			return hresult;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000A547 File Offset: 0x00008747
		protected override bool ReleaseHandle()
		{
			XblInterop.XblMultiplayerSearchHandleCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}
	}
}
