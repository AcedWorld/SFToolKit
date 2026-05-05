using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200001E RID: 30
	public class XMetadataPurgedToken
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000260 RID: 608 RVA: 0x000088B3 File Offset: 0x00006AB3
		// (set) Token: 0x06000261 RID: 609 RVA: 0x000088BB File Offset: 0x00006ABB
		internal XMetadataPurgedToken interop { get; private set; }

		// Token: 0x06000262 RID: 610 RVA: 0x000088C4 File Offset: 0x00006AC4
		internal XMetadataPurgedToken(XAppCaptureMetadataPurgedCallback callback, IntPtr context)
		{
			this.interop = new XMetadataPurgedToken(callback, context);
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000263 RID: 611 RVA: 0x000088D9 File Offset: 0x00006AD9
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000264 RID: 612 RVA: 0x000088E6 File Offset: 0x00006AE6
		// (set) Token: 0x06000265 RID: 613 RVA: 0x000088F3 File Offset: 0x00006AF3
		public ulong Token
		{
			get
			{
				return this.interop.Token;
			}
			set
			{
				this.interop.Token = value;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00008901 File Offset: 0x00006B01
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}
	}
}
