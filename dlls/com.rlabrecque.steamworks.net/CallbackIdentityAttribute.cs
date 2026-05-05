using System;

namespace Steamworks
{
	// Token: 0x0200017D RID: 381
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	internal class CallbackIdentityAttribute : Attribute
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0000CCE3 File Offset: 0x0000AEE3
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0000CCEB File Offset: 0x0000AEEB
		public int Identity { get; set; }

		// Token: 0x060008B2 RID: 2226 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public CallbackIdentityAttribute(int callbackNum)
		{
			this.Identity = callbackNum;
		}
	}
}
