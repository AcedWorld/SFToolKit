using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000059 RID: 89
	public struct CustomEventArgs
	{
		// Token: 0x0600035F RID: 863 RVA: 0x00008A77 File Offset: 0x00006C77
		public CustomEventArgs(string name, params object[] arguments)
		{
			this.name = name;
			this.arguments = arguments;
		}

		// Token: 0x040000FE RID: 254
		public readonly string name;

		// Token: 0x040000FF RID: 255
		public readonly object[] arguments;
	}
}
