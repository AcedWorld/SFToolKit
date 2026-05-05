using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000093 RID: 147
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionHandle : EquatableHandle
	{
		// Token: 0x060004DA RID: 1242 RVA: 0x0000A5AA File Offset: 0x000087AA
		internal XblMultiplayerSessionHandle(XblMultiplayerSessionHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.intPtr)
		{
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000A5BE File Offset: 0x000087BE
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000A5D0 File Offset: 0x000087D0
		internal static int WrapInteropHandleAndReturnHResult(int hresult, XblMultiplayerSessionHandle interopHandle, out XblMultiplayerSessionHandle sessionHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				sessionHandle = new XblMultiplayerSessionHandle(interopHandle);
			}
			else
			{
				sessionHandle = null;
			}
			return hresult;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000A5E8 File Offset: 0x000087E8
		protected override bool ReleaseHandle()
		{
			XblInterop.XblMultiplayerSessionCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}
	}
}
