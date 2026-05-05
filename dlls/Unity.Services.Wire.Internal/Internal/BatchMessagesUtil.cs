using System;
using System.Collections.Generic;
using System.Text;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000014 RID: 20
	internal static class BatchMessagesUtil
	{
		// Token: 0x0600002E RID: 46 RVA: 0x000023D4 File Offset: 0x000005D4
		private static IEnumerable<string> SplitMessages(string message)
		{
			string[] array = message.Split(new string[]
			{
				"}\n{"
			}, StringSplitOptions.None);
			if (array.Length > 1)
			{
				BatchMessagesUtil.FixJsonSplit(ref array);
			}
			return array;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002405 File Offset: 0x00000605
		public static IEnumerable<string> SplitMessages(byte[] byteMessage)
		{
			return BatchMessagesUtil.SplitMessages(Encoding.UTF8.GetString(byteMessage));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002418 File Offset: 0x00000618
		private static void FixJsonSplit(ref string[] pubs)
		{
			for (int i = 0; i < pubs.Length; i++)
			{
				if (i > 0)
				{
					pubs[i] = "{" + pubs[i];
				}
				if (i < pubs.Length - 1)
				{
					string[] array = pubs;
					int num = i;
					array[num] += "}";
				}
			}
		}
	}
}
