using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200013A RID: 314
	public class XGameStreamingConnectionStateChangedToken
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0000D4BC File Offset: 0x0000B6BC
		// (set) Token: 0x060007CD RID: 1997 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
		internal XGameStreamingConnectionStateChangedToken interop { get; private set; }

		// Token: 0x060007CE RID: 1998 RVA: 0x0000D4CD File Offset: 0x0000B6CD
		internal XGameStreamingConnectionStateChangedToken(XGameStreamingConnectionStateChangedCallback callback, IntPtr context)
		{
			this.interop = new XGameStreamingConnectionStateChangedToken(callback, context);
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0000D4E2 File Offset: 0x0000B6E2
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0000D4EF File Offset: 0x0000B6EF
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x0000D4FC File Offset: 0x0000B6FC
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

		// Token: 0x060007D2 RID: 2002 RVA: 0x0000D50A File Offset: 0x0000B70A
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}
	}
}
