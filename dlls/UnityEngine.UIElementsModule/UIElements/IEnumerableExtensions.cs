using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200025F RID: 607
	internal static class IEnumerableExtensions
	{
		// Token: 0x06001157 RID: 4439 RVA: 0x0003ED54 File Offset: 0x0003CF54
		internal static bool HasValues(this IEnumerable<string> collection)
		{
			bool flag = collection == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				using (IEnumerator<string> enumerator = collection.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						string text = enumerator.Current;
						return true;
					}
				}
				result = false;
			}
			return result;
		}
	}
}
