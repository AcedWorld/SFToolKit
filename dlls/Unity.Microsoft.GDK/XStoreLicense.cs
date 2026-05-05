using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017C RID: 380
	[MovedFrom("Unity.GameCore")]
	public class XStoreLicense : EquatableHandle
	{
		// Token: 0x06000934 RID: 2356 RVA: 0x0000E741 File Offset: 0x0000C941
		public XStoreLicense(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0000E750 File Offset: 0x0000C950
		protected override bool ReleaseHandle()
		{
			NativeMethods.XStoreCloseLicenseHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x0000E769 File Offset: 0x0000C969
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
