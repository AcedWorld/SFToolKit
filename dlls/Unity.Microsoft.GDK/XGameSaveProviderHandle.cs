using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000129 RID: 297
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveProviderHandle : EquatableHandle
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x0000D096 File Offset: 0x0000B296
		public XGameSaveProviderHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0000D0A5 File Offset: 0x0000B2A5
		protected override bool ReleaseHandle()
		{
			NativeMethods.XGameSaveCloseProvider(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x0000D0BE File Offset: 0x0000B2BE
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
