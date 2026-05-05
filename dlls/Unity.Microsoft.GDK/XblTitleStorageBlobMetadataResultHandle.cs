using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200010C RID: 268
	[MovedFrom("Unity.GameCore")]
	public class XblTitleStorageBlobMetadataResultHandle : EquatableHandle
	{
		// Token: 0x06000700 RID: 1792 RVA: 0x0000C67A File Offset: 0x0000A87A
		internal XblTitleStorageBlobMetadataResultHandle(XblTitleStorageBlobMetadataResultHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.intPtr)
		{
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x0000C68E File Offset: 0x0000A88E
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
		protected override bool ReleaseHandle()
		{
			XblInterop.XblTitleStorageBlobMetadataResultCloseHandle(base.Handle);
			base.SetHandle(this.handle);
			return true;
		}
	}
}
