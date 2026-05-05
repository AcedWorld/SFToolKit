using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AE RID: 174
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerEventArgsHandle : EquatableHandle
	{
		// Token: 0x0600056B RID: 1387 RVA: 0x0000B00D File Offset: 0x0000920D
		internal XblMultiplayerEventArgsHandle(XblMultiplayerEventArgsHandle interopHandle) : base(IntPtr.Zero, false, interopHandle.handle)
		{
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000B021 File Offset: 0x00009221
		internal static int WrapInteropHandleAndReturnHResult(int hresult, XblMultiplayerEventArgsHandle interopHandle, out XblMultiplayerEventArgsHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblMultiplayerEventArgsHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000B039 File Offset: 0x00009239
		protected override bool ReleaseHandle()
		{
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0000B047 File Offset: 0x00009247
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
