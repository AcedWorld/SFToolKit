using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000155 RID: 341
	public class XNetworkingRegisterConnectivityHintChangedCallbackToken
	{
		// Token: 0x06000838 RID: 2104 RVA: 0x0000D9C3 File Offset: 0x0000BBC3
		internal XNetworkingRegisterConnectivityHintChangedCallbackToken(XNetworkingConnectivityHintChangedCallback callback, IntPtr context)
		{
			this.interop = new XNetworkingRegisterConnectivityHintChangedCallbackToken(callback, context);
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0000D9D8 File Offset: 0x0000BBD8
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0000D9E5 File Offset: 0x0000BBE5
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x0000D9F2 File Offset: 0x0000BBF2
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

		// Token: 0x0600083C RID: 2108 RVA: 0x0000DA00 File Offset: 0x0000BC00
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0000DA0E File Offset: 0x0000BC0E
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x040004F5 RID: 1269
		internal XNetworkingRegisterConnectivityHintChangedCallbackToken interop;
	}
}
