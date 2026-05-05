using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000179 RID: 377
	[MovedFrom("Unity.GameCore")]
	public class XStoreSubscriptionInfo
	{
		// Token: 0x06000915 RID: 2325 RVA: 0x0000E549 File Offset: 0x0000C749
		internal XStoreSubscriptionInfo(XStoreSubscriptionInfo interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0000E558 File Offset: 0x0000C758
		public XStoreSubscriptionInfo()
		{
			this.interop = default(XStoreSubscriptionInfo);
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x0000E56C File Offset: 0x0000C76C
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x0000E579 File Offset: 0x0000C779
		public bool HasTrialPeriod
		{
			get
			{
				return this.interop.hasTrialPeriod;
			}
			set
			{
				this.interop.hasTrialPeriod = value;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x0000E587 File Offset: 0x0000C787
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x0000E594 File Offset: 0x0000C794
		public XStoreDurationUnit TrialPeriodUnit
		{
			get
			{
				return this.interop.trialPeriodUnit;
			}
			set
			{
				this.interop.trialPeriodUnit = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x0000E5A2 File Offset: 0x0000C7A2
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x0000E5AF File Offset: 0x0000C7AF
		public uint TrialPeriod
		{
			get
			{
				return this.interop.trialPeriod;
			}
			set
			{
				this.interop.trialPeriod = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0000E5BD File Offset: 0x0000C7BD
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x0000E5CA File Offset: 0x0000C7CA
		public XStoreDurationUnit BillingPeriodUnit
		{
			get
			{
				return this.interop.billingPeriodUnit;
			}
			set
			{
				this.interop.billingPeriodUnit = value;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0000E5D8 File Offset: 0x0000C7D8
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x0000E5E5 File Offset: 0x0000C7E5
		public uint BillingPeriod
		{
			get
			{
				return this.interop.billingPeriod;
			}
			set
			{
				this.interop.billingPeriod = value;
			}
		}

		// Token: 0x04000532 RID: 1330
		internal XStoreSubscriptionInfo interop;
	}
}
