using System;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000065 RID: 101
	internal static class JsonSerialization
	{
		// Token: 0x060002AA RID: 682 RVA: 0x000097DF File Offset: 0x000079DF
		public static byte[] Serialize<T>(T obj)
		{
			return Encoding.UTF8.GetBytes(JsonSerialization.SerializeToString<T>(obj));
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000097F1 File Offset: 0x000079F1
		public static string SerializeToString<T>(T obj)
		{
			return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});
		}
	}
}
