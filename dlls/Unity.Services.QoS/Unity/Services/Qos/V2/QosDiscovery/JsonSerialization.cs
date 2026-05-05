using System;
using System.Text;
using Newtonsoft.Json;
using Unity.Services.Qos.V2.Http;

namespace Unity.Services.Qos.V2.QosDiscovery
{
	// Token: 0x02000045 RID: 69
	internal static class JsonSerialization
	{
		// Token: 0x06000145 RID: 325 RVA: 0x00005AD7 File Offset: 0x00003CD7
		public static byte[] Serialize<T>(T obj)
		{
			return Encoding.UTF8.GetBytes(JsonSerialization.SerializeToString<T>(obj));
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005AE9 File Offset: 0x00003CE9
		public static string SerializeToString<T>(T obj)
		{
			return IsolatedJsonConvert.SerializeObject(obj, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});
		}
	}
}
