using System;

namespace Rewired.Utils.Attributes
{
	// Token: 0x0200053A RID: 1338
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal class MonoPInvokeCallbackAttribute : Attribute
	{
		// Token: 0x0600366D RID: 13933 RVA: 0x0002A79C File Offset: 0x0002899C
		public MonoPInvokeCallbackAttribute(Type A_1)
		{
			this.type = A_1;
		}

		// Token: 0x04001C94 RID: 7316
		private Type type;
	}
}
