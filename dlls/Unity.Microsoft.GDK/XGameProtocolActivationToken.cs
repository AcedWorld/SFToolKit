using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000124 RID: 292
	public class XGameProtocolActivationToken
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0000CEC5 File Offset: 0x0000B0C5
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x0000CECD File Offset: 0x0000B0CD
		internal XGameProtocolActivationToken interop { get; private set; }

		// Token: 0x06000765 RID: 1893 RVA: 0x0000CED6 File Offset: 0x0000B0D6
		internal XGameProtocolActivationToken(XGameProtocolActivationCallback callback, IntPtr context)
		{
			this.interop = new XGameProtocolActivationToken(callback, context);
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x0000CEEB File Offset: 0x0000B0EB
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x0000CEF8 File Offset: 0x0000B0F8
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

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0000CF06 File Offset: 0x0000B106
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0000CF13 File Offset: 0x0000B113
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}
	}
}
