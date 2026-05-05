using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200015B RID: 347
	[MovedFrom("Unity.GameCore")]
	public class XPackageInstallationMonitorHandle : EquatableHandle
	{
		// Token: 0x06000844 RID: 2116 RVA: 0x0000DA73 File Offset: 0x0000BC73
		public XPackageInstallationMonitorHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0000DA82 File Offset: 0x0000BC82
		protected override bool ReleaseHandle()
		{
			NativeMethods.XPackageCloseInstallationMonitorHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0000DA9B File Offset: 0x0000BC9B
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
