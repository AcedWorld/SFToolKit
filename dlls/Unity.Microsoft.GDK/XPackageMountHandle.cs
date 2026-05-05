using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200015C RID: 348
	[MovedFrom("Unity.GameCore")]
	public class XPackageMountHandle : EquatableHandle
	{
		// Token: 0x06000847 RID: 2119 RVA: 0x0000DAAD File Offset: 0x0000BCAD
		public XPackageMountHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0000DABC File Offset: 0x0000BCBC
		protected override bool ReleaseHandle()
		{
			NativeMethods.XPackageCloseMountHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0000DAD5 File Offset: 0x0000BCD5
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
