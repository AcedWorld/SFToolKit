using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000184 RID: 388
	public class XStoreRateAndReviewResult
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x0000ED56 File Offset: 0x0000CF56
		internal XStoreRateAndReviewResult(XStoreRateAndReviewResult interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0000ED65 File Offset: 0x0000CF65
		public XStoreRateAndReviewResult()
		{
			this.interop = default(XStoreRateAndReviewResult);
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0000ED79 File Offset: 0x0000CF79
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x0000ED86 File Offset: 0x0000CF86
		public bool WasUpdated
		{
			get
			{
				return this.interop.wasUpdated;
			}
			set
			{
				this.interop.wasUpdated = value;
			}
		}

		// Token: 0x04000555 RID: 1365
		internal XStoreRateAndReviewResult interop;
	}
}
