using System;

namespace Rewired.Utils.Libraries.TinyJson
{
	// Token: 0x020004B9 RID: 1209
	public static class JsonTools
	{
		// Token: 0x060030DC RID: 12508 RVA: 0x000AA190 File Offset: 0x000A8390
		public static T Clone<T>(T obj) where T : class
		{
			if (obj == null)
			{
				return default(T);
			}
			return JsonParser.FromJson<T>(JsonWriter.ToJson(obj));
		}
	}
}
