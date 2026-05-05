using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200012B RID: 299
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveUpdateHandle : EquatableHandle
	{
		// Token: 0x06000789 RID: 1929 RVA: 0x0000D10A File Offset: 0x0000B30A
		public XGameSaveUpdateHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0000D119 File Offset: 0x0000B319
		protected override bool ReleaseHandle()
		{
			NativeMethods.XGameSaveCloseUpdate(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x0000D133 File Offset: 0x0000B333
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
