using System;
using System.Text;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000023 RID: 35
	internal static class StringExtention
	{
		// Token: 0x0600004A RID: 74 RVA: 0x000043DC File Offset: 0x000025DC
		public static string CamelToPascalCaseWithSpace(this string text, bool preserveAcronyms = true)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(char.ToUpper(text[0]));
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]) && ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1]))))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(text[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
