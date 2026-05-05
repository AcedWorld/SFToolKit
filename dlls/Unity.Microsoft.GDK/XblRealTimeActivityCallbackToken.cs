using System;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000E5 RID: 229
	public struct XblRealTimeActivityCallbackToken
	{
		// Token: 0x06000644 RID: 1604 RVA: 0x0000BD72 File Offset: 0x00009F72
		public void Reset()
		{
			this.InteropHandlerId = 0;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0000BD7B File Offset: 0x00009F7B
		public bool IsValid()
		{
			return XblRealTimeActivityCallbackToken.IsValid(this.InteropHandlerId);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0000BD88 File Offset: 0x00009F88
		public static bool IsValid(int interopHandlerId)
		{
			return interopHandlerId > 0;
		}

		// Token: 0x04000392 RID: 914
		public const int InvalidHandlerId = 0;

		// Token: 0x04000393 RID: 915
		public int InteropHandlerId;
	}
}
