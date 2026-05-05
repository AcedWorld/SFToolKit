using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000FB RID: 251
	[MovedFrom("Unity.GameCore")]
	public class XblSocialManagerUserGroupHandle : EquatableHandle
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x0000C356 File Offset: 0x0000A556
		internal XblSocialManagerUserGroupHandle(XblSocialManagerUserGroupHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.Handle)
		{
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0000C36A File Offset: 0x0000A56A
		internal static int WrapAndReturnHResult(int hresult, XblSocialManagerUserGroupHandle interopHandle, out XblSocialManagerUserGroupHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblSocialManagerUserGroupHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x0000C382 File Offset: 0x0000A582
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0000C394 File Offset: 0x0000A594
		protected override bool ReleaseHandle()
		{
			return true;
		}
	}
}
