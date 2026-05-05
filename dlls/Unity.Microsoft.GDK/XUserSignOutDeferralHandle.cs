using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001B6 RID: 438
	[MovedFrom("Unity.GameCore")]
	public class XUserSignOutDeferralHandle : EquatableHandle
	{
		// Token: 0x06000A43 RID: 2627 RVA: 0x0000F6CD File Offset: 0x0000D8CD
		public XUserSignOutDeferralHandle(IntPtr interopHandle) : base(IntPtr.Zero, true, interopHandle)
		{
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		protected override bool ReleaseHandle()
		{
			NativeMethods.XUserCloseSignOutDeferralHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0000F6F5 File Offset: 0x0000D8F5
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
