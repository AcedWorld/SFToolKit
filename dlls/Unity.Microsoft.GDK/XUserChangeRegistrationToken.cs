using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001B2 RID: 434
	public class XUserChangeRegistrationToken
	{
		// Token: 0x06000A2C RID: 2604 RVA: 0x0000F557 File Offset: 0x0000D757
		internal XUserChangeRegistrationToken(XUserChangeEventCallback callback, IntPtr context)
		{
			this.interop = new XUserChangeRegistrationToken(callback, context);
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x0000F56C File Offset: 0x0000D76C
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0000F579 File Offset: 0x0000D779
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0000F586 File Offset: 0x0000D786
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

		// Token: 0x06000A30 RID: 2608 RVA: 0x0000F594 File Offset: 0x0000D794
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0000F5A2 File Offset: 0x0000D7A2
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x040005D1 RID: 1489
		internal XUserChangeRegistrationToken interop;
	}
}
