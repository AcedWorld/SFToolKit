using System;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000050 RID: 80
	internal static class XString
	{
		// Token: 0x0600025D RID: 605 RVA: 0x00005FFF File Offset: 0x000041FF
		internal static string Inject(this string format, params object[] formattingArgs)
		{
			return string.Format(format, formattingArgs);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00006008 File Offset: 0x00004208
		internal static string Inject(this string format, params string[] formattingArgs)
		{
			return string.Format(format, (from a in formattingArgs
			select a).ToArray<object>());
		}
	}
}
