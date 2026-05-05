using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017B RID: 379
	[MovedFrom("Unity.GameCore")]
	public class XStoreContext : EquatableHandle
	{
		// Token: 0x06000931 RID: 2353 RVA: 0x0000E707 File Offset: 0x0000C907
		public XStoreContext(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0000E716 File Offset: 0x0000C916
		protected override bool ReleaseHandle()
		{
			NativeMethods.XStoreCloseContextHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x0000E72F File Offset: 0x0000C92F
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
