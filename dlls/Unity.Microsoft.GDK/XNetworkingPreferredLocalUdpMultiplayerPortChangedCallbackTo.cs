using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000156 RID: 342
	public class XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x0000DA1B File Offset: 0x0000BC1B
		internal XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, IntPtr context)
		{
			this.interop = new XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(callback, context);
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0000DA30 File Offset: 0x0000BC30
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0000DA3D File Offset: 0x0000BC3D
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0000DA4A File Offset: 0x0000BC4A
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

		// Token: 0x06000842 RID: 2114 RVA: 0x0000DA58 File Offset: 0x0000BC58
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0000DA66 File Offset: 0x0000BC66
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x040004F6 RID: 1270
		internal XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken interop;
	}
}
