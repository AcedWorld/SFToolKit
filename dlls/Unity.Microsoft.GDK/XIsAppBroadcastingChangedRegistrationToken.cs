using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200001D RID: 29
	public class XIsAppBroadcastingChangedRegistrationToken
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00008857 File Offset: 0x00006A57
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0000885F File Offset: 0x00006A5F
		internal XIsAppBroadcastingChangedRegistrationToken interop { get; private set; }

		// Token: 0x0600025B RID: 603 RVA: 0x00008868 File Offset: 0x00006A68
		internal XIsAppBroadcastingChangedRegistrationToken(XAppBroadcastMonitorCallback callback, IntPtr context)
		{
			this.interop = new XIsAppBroadcastingChangedRegistrationToken(callback, context);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0000887D File Offset: 0x00006A7D
		// (set) Token: 0x0600025D RID: 605 RVA: 0x0000888A File Offset: 0x00006A8A
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

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00008898 File Offset: 0x00006A98
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000088A5 File Offset: 0x00006AA5
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}
	}
}
