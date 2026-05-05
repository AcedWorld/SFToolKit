using System;
using System.Linq;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001D RID: 29
	internal static class StringUtil
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00002EA4 File Offset: 0x000010A4
		internal static string AddSpacesToCamelCase(string s)
		{
			return string.Concat(s.Select(delegate(char x)
			{
				if (!char.IsUpper(x))
				{
					return x.ToString();
				}
				return " " + x.ToString();
			})).TrimStart(' ');
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002ED7 File Offset: 0x000010D7
		internal static string RemoveSpaces(string s)
		{
			return s.Replace(" ", "");
		}
	}
}
