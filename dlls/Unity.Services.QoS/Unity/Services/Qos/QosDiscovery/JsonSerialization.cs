using System;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Qos.QosDiscovery
{
	// Token: 0x02000075 RID: 117
	internal static class JsonSerialization
	{
		// Token: 0x0600023D RID: 573 RVA: 0x000080A3 File Offset: 0x000062A3
		public static byte[] Serialize<T>(T obj)
		{
			return Encoding.UTF8.GetBytes(JsonSerialization.SerializeToString<T>(obj));
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000080B5 File Offset: 0x000062B5
		public static string SerializeToString<T>(T obj)
		{
			return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});
		}
	}
}
