using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001B3 RID: 435
	public class XUserDefaultAudioEndpointUtf16RegistrationToken
	{
		// Token: 0x06000A32 RID: 2610 RVA: 0x0000F5AF File Offset: 0x0000D7AF
		internal XUserDefaultAudioEndpointUtf16RegistrationToken(XUserDefaultAudioEndpointUtf16ChangedCallback callback, IntPtr context)
		{
			this.interop = new XUserDefaultAudioEndpointUtf16RegistrationToken(callback, context);
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x0000F5C4 File Offset: 0x0000D7C4
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0000F5D1 File Offset: 0x0000D7D1
		// (set) Token: 0x06000A35 RID: 2613 RVA: 0x0000F5DE File Offset: 0x0000D7DE
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

		// Token: 0x06000A36 RID: 2614 RVA: 0x0000F5EC File Offset: 0x0000D7EC
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0000F5FA File Offset: 0x0000D7FA
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x040005D2 RID: 1490
		internal XUserDefaultAudioEndpointUtf16RegistrationToken interop;
	}
}
