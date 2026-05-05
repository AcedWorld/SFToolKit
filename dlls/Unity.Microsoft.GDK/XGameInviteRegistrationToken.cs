using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000122 RID: 290
	public class XGameInviteRegistrationToken
	{
		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0000CE69 File Offset: 0x0000B069
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x0000CE71 File Offset: 0x0000B071
		internal XGameInviteRegistrationToken interop { get; private set; }

		// Token: 0x0600075A RID: 1882 RVA: 0x0000CE7A File Offset: 0x0000B07A
		internal XGameInviteRegistrationToken(XGameInviteEventCallback callback, IntPtr context)
		{
			this.interop = new XGameInviteRegistrationToken(callback, context);
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0000CE8F File Offset: 0x0000B08F
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x0000CE9C File Offset: 0x0000B09C
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

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0000CEAA File Offset: 0x0000B0AA
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000CEB7 File Offset: 0x0000B0B7
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}
	}
}
