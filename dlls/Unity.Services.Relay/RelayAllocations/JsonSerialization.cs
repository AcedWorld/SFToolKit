using System;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x0200004B RID: 75
	internal static class JsonSerialization
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00005143 File Offset: 0x00003343
		public static byte[] Serialize<T>(T obj)
		{
			return Encoding.UTF8.GetBytes(JsonSerialization.SerializeToString<T>(obj));
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005155 File Offset: 0x00003355
		public static string SerializeToString<T>(T obj)
		{
			return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});
		}
	}
}
