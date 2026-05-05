using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200012A RID: 298
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveContainerHandle : EquatableHandle
	{
		// Token: 0x06000786 RID: 1926 RVA: 0x0000D0D0 File Offset: 0x0000B2D0
		public XGameSaveContainerHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0000D0DF File Offset: 0x0000B2DF
		protected override bool ReleaseHandle()
		{
			NativeMethods.XGameSaveCloseContainer(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
