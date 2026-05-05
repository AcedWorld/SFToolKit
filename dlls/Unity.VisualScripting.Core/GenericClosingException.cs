using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D0 RID: 208
	public sealed class GenericClosingException : Exception
	{
		// Token: 0x0600052B RID: 1323 RVA: 0x0000C69B File Offset: 0x0000A89B
		public GenericClosingException(string message) : base(message)
		{
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
		public GenericClosingException(Type open, Type closed) : base(string.Format("Open-constructed type '{0}' is not assignable from closed-constructed type '{1}'.", open, closed))
		{
		}
	}
}
