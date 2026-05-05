using System;
using System.Collections.Generic;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000022 RID: 34
	internal static class UriHelper
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00003854 File Offset: 0x00001A54
		public static Dictionary<string, string> ParseQueryString(string queryString)
		{
			if (queryString == null)
			{
				throw PlayerAccountsExceptionHandler.HandleError("queryString", "Query string cannot be null.", null);
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string[] array = queryString.TrimStart(new char[]
			{
				'?',
				'#'
			}).Split('&', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2)
				{
					dictionary[array2[0]] = Uri.UnescapeDataString(array2[1]);
				}
			}
			return dictionary;
		}
	}
}
