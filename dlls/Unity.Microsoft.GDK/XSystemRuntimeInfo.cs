using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200018F RID: 399
	public class XSystemRuntimeInfo
	{
		// Token: 0x060009B4 RID: 2484 RVA: 0x0000EFCF File Offset: 0x0000D1CF
		internal XSystemRuntimeInfo(XSystemRuntimeInfo interop)
		{
			this._runtimeVersion = new XVersion(interop.runtimeVersion);
			this._availableVersion = new XVersion(interop.availableVersion);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0000EFF9 File Offset: 0x0000D1F9
		public XSystemRuntimeInfo()
		{
			this._runtimeVersion = new XVersion();
			this._availableVersion = new XVersion();
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0000F017 File Offset: 0x0000D217
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x0000F01F File Offset: 0x0000D21F
		public XVersion RuntimeVersion
		{
			get
			{
				return this._runtimeVersion;
			}
			set
			{
				this._runtimeVersion = value;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0000F028 File Offset: 0x0000D228
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x0000F030 File Offset: 0x0000D230
		public XVersion AvailableVersion
		{
			get
			{
				return this._availableVersion;
			}
			set
			{
				this._availableVersion = value;
			}
		}

		// Token: 0x0400057A RID: 1402
		internal XVersion _runtimeVersion;

		// Token: 0x0400057B RID: 1403
		internal XVersion _availableVersion;
	}
}
