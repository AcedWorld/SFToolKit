using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000034 RID: 52
	internal static class IsolatedJsonConvert
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00004B15 File Offset: 0x00002D15
		[DebuggerStepThrough]
		public static string SerializeObject(object value)
		{
			return IsolatedJsonConvert.SerializeObject(value, null, null);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004B1F File Offset: 0x00002D1F
		[DebuggerStepThrough]
		public static string SerializeObject(object value, JsonSerializerSettings settings)
		{
			return IsolatedJsonConvert.SerializeObject(value, null, settings);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004B2C File Offset: 0x00002D2C
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Type type, JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = JsonSerializer.Create(settings);
			return IsolatedJsonConvert.SerializeObjectInternal(value, type, jsonSerializer);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004B48 File Offset: 0x00002D48
		private static string SerializeObjectInternal(object value, Type type, JsonSerializer jsonSerializer)
		{
			StringWriter stringWriter = new StringWriter(new StringBuilder(256), CultureInfo.InvariantCulture);
			using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
			{
				jsonTextWriter.Formatting = jsonSerializer.Formatting;
				jsonSerializer.Serialize(jsonTextWriter, value, type);
			}
			return stringWriter.ToString();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004BA8 File Offset: 0x00002DA8
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type)
		{
			return IsolatedJsonConvert.DeserializeObject(value, type, null);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004BB2 File Offset: 0x00002DB2
		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value, JsonSerializerSettings settings)
		{
			return (T)((object)IsolatedJsonConvert.DeserializeObject(value, typeof(T), settings));
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004BCC File Offset: 0x00002DCC
		public static object DeserializeObject(string value, Type type, JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = JsonSerializer.Create(settings);
			object result;
			using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(value)))
			{
				result = jsonSerializer.Deserialize(jsonTextReader, type);
			}
			return result;
		}
	}
}
