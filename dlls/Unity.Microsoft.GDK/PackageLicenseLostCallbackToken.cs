using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000186 RID: 390
	public class PackageLicenseLostCallbackToken
	{
		// Token: 0x170002CD RID: 717
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0000EDFE File Offset: 0x0000CFFE
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x0000EE06 File Offset: 0x0000D006
		internal PackageLicenseLostCallbackToken interop { get; private set; }

		// Token: 0x0600098C RID: 2444 RVA: 0x0000EE0F File Offset: 0x0000D00F
		internal PackageLicenseLostCallbackToken(XStoreLicense licenseHandle, XStorePackageLicenseLostCallback callback, IntPtr context)
		{
			this.interop = new PackageLicenseLostCallbackToken(licenseHandle, callback, context);
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x0000EE25 File Offset: 0x0000D025
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x0000EE32 File Offset: 0x0000D032
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x0000EE3F File Offset: 0x0000D03F
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

		// Token: 0x06000990 RID: 2448 RVA: 0x0000EE4D File Offset: 0x0000D04D
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0000EE5B File Offset: 0x0000D05B
		public void Dispose()
		{
			this.interop.Dispose();
		}
	}
}
