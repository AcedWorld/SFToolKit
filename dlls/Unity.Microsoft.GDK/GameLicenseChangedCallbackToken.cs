using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000185 RID: 389
	public class GameLicenseChangedCallbackToken
	{
		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0000ED94 File Offset: 0x0000CF94
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x0000ED9C File Offset: 0x0000CF9C
		internal GameLicenseChangedCallbackToken interop { get; private set; }

		// Token: 0x06000984 RID: 2436 RVA: 0x0000EDA5 File Offset: 0x0000CFA5
		internal GameLicenseChangedCallbackToken(XStoreContext storeContext, XStoreGameLicenseChangedCallback callback, IntPtr context)
		{
			this.interop = new GameLicenseChangedCallbackToken(storeContext, callback, context);
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0000EDBB File Offset: 0x0000CFBB
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x0000EDD5 File Offset: 0x0000CFD5
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

		// Token: 0x06000988 RID: 2440 RVA: 0x0000EDE3 File Offset: 0x0000CFE3
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0000EDF1 File Offset: 0x0000CFF1
		public void Dispose()
		{
			this.interop.Dispose();
		}
	}
}
