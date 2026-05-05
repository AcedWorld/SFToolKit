using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200006D RID: 109
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementsResultHandle : EquatableHandle
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x00009B29 File Offset: 0x00007D29
		internal XblAchievementsResultHandle(XblAchievementsResultHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.handle)
		{
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00009B3D File Offset: 0x00007D3D
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00009B4F File Offset: 0x00007D4F
		protected override bool ReleaseHandle()
		{
			XblInterop.XblAchievementsResultCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}
	}
}
