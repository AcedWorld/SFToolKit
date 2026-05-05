using System;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001AF RID: 431
	public static class fsOption
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x00030CE6 File Offset: 0x0002EEE6
		public static fsOption<T> Just<T>(T value)
		{
			return new fsOption<T>(value);
		}
	}
}
