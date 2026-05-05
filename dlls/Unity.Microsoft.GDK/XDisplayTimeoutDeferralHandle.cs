using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200011E RID: 286
	[MovedFrom("Unity.GameCore")]
	public class XDisplayTimeoutDeferralHandle : EquatableHandle
	{
		// Token: 0x0600074D RID: 1869 RVA: 0x0000CE2E File Offset: 0x0000B02E
		public XDisplayTimeoutDeferralHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0000CE3D File Offset: 0x0000B03D
		protected override bool ReleaseHandle()
		{
			NativeMethods.XDisplayCloseTimeoutDeferralHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x0000CE57 File Offset: 0x0000B057
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
