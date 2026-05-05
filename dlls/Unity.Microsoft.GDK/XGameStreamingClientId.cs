using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000134 RID: 308
	public class XGameStreamingClientId
	{
		// Token: 0x06000794 RID: 1940 RVA: 0x0000D145 File Offset: 0x0000B345
		public XGameStreamingClientId(ulong value)
		{
			this.data = default(XGameStreamingClientId);
			this.data.value = value;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0000D165 File Offset: 0x0000B365
		internal XGameStreamingClientId(XGameStreamingClientId interop)
		{
			this.data = interop;
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x0000D174 File Offset: 0x0000B374
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x0000D181 File Offset: 0x0000B381
		public ulong Value
		{
			get
			{
				return this.data.value;
			}
			set
			{
				this.data.value = value;
			}
		}

		// Token: 0x040004A6 RID: 1190
		internal XGameStreamingClientId data;
	}
}
