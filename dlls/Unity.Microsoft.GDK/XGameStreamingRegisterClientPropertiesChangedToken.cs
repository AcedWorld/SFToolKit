using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200013B RID: 315
	public class XGameStreamingRegisterClientPropertiesChangedToken
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0000D518 File Offset: 0x0000B718
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x0000D520 File Offset: 0x0000B720
		internal XGameStreamingRegisterClientPropertiesChangedToken interop { get; private set; }

		// Token: 0x060007D5 RID: 2005 RVA: 0x0000D529 File Offset: 0x0000B729
		internal XGameStreamingRegisterClientPropertiesChangedToken(XGameStreamingClientId clientId, XGameStreamingClientPropertiesChangedCallback callback, IntPtr context)
		{
			this.interop = new XGameStreamingRegisterClientPropertiesChangedToken(clientId.data, callback, context);
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x0000D544 File Offset: 0x0000B744
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x0000D551 File Offset: 0x0000B751
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x0000D55E File Offset: 0x0000B75E
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

		// Token: 0x060007D9 RID: 2009 RVA: 0x0000D56C File Offset: 0x0000B76C
		public bool Unregister(XGameStreamingClientId clientId, bool wait)
		{
			return this.interop.Unregister(clientId.data, wait);
		}
	}
}
