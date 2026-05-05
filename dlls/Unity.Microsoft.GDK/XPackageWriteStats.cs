using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000161 RID: 353
	[MovedFrom("Unity.GameCore")]
	public class XPackageWriteStats
	{
		// Token: 0x0600087C RID: 2172 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
		internal XPackageWriteStats(XPackageWriteStats interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0000DDDF File Offset: 0x0000BFDF
		public XPackageWriteStats()
		{
			this.interop = default(XPackageWriteStats);
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0000DDF3 File Offset: 0x0000BFF3
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x0000DE00 File Offset: 0x0000C000
		public ulong Interval
		{
			get
			{
				return this.interop.interval;
			}
			set
			{
				this.interop.interval = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0000DE0E File Offset: 0x0000C00E
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0000DE1B File Offset: 0x0000C01B
		public ulong Budget
		{
			get
			{
				return this.interop.budget;
			}
			set
			{
				this.interop.budget = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x0000DE29 File Offset: 0x0000C029
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x0000DE36 File Offset: 0x0000C036
		public ulong Elapsed
		{
			get
			{
				return this.interop.elapsed;
			}
			set
			{
				this.interop.elapsed = value;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x0000DE44 File Offset: 0x0000C044
		// (set) Token: 0x06000885 RID: 2181 RVA: 0x0000DE51 File Offset: 0x0000C051
		public ulong BytesWritten
		{
			get
			{
				return this.interop.bytesWritten;
			}
			set
			{
				this.interop.bytesWritten = value;
			}
		}

		// Token: 0x0400050F RID: 1295
		internal XPackageWriteStats interop;
	}
}
