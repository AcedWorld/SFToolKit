using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x02000054 RID: 84
	internal static class IsolatedJsonConvert
	{
		// Token: 0x0600022A RID: 554 RVA: 0x0000667D File Offset: 0x0000487D
		[DebuggerStepThrough]
		public static string SerializeObject(object value)
		{
			return IsolatedJsonConvert.SerializeObject(value, null, null);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00006687 File Offset: 0x00004887
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Formatting formatting)
		{
			return IsolatedJsonConvert.SerializeObject(value, formatting, null);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00006694 File Offset: 0x00004894
		[DebuggerStepThrough]
		public static string SerializeObject(object value, params JsonConverter[] converters)
		{
			JsonSerializerSettings jsonSerializerSettings;
			if (converters == null || converters.Length == 0)
			{
				jsonSerializerSettings = null;
			}
			else
			{
				jsonSerializerSettings = new JsonSerializerSettings
				{
					Converters = converters
				};
			}
			JsonSerializerSettings settings = jsonSerializerSettings;
			return IsolatedJsonConvert.SerializeObject(value, null, settings);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000066C4 File Offset: 0x000048C4
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Formatting formatting, params JsonConverter[] converters)
		{
			JsonSerializerSettings jsonSerializerSettings;
			if (converters == null || converters.Length == 0)
			{
				jsonSerializerSettings = null;
			}
			else
			{
				jsonSerializerSettings = new JsonSerializerSettings
				{
					Converters = converters
				};
			}
			JsonSerializerSettings settings = jsonSerializerSettings;
			return IsolatedJsonConvert.SerializeObject(value, null, formatting, settings);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000066F4 File Offset: 0x000048F4
		[DebuggerStepThrough]
		public static string SerializeObject(object value, JsonSerializerSettings settings)
		{
			return IsolatedJsonConvert.SerializeObject(value, null, settings);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00006700 File Offset: 0x00004900
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Type type, JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = JsonSerializer.Create(settings);
			return IsolatedJsonConvert.SerializeObjectInternal(value, type, jsonSerializer);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000671C File Offset: 0x0000491C
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Formatting formatting, JsonSerializerSettings settings)
		{
			return IsolatedJsonConvert.SerializeObject(value, null, formatting, settings);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00006728 File Offset: 0x00004928
		[DebuggerStepThrough]
		public static string SerializeObject(object value, Type type, Formatting formatting, JsonSerializerSettings settings)
		{
			JsonSerializer jsonSerializer = JsonSerializer.Create(settings);
			jsonSerializer.Formatting = formatting;
			return IsolatedJsonConvert.SerializeObjectInternal(value, type, jsonSerializer);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000674C File Offset: 0x0000494C
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

		// Token: 0x06000233 RID: 563 RVA: 0x000067AC File Offset: 0x000049AC
		[DebuggerStepThrough]
		public static object DeserializeObject(string value)
		{
			return IsolatedJsonConvert.DeserializeObject(value, null, null);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000067B6 File Offset: 0x000049B6
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, JsonSerializerSettings settings)
		{
			return IsolatedJsonConvert.DeserializeObject(value, null, settings);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000067C0 File Offset: 0x000049C0
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type)
		{
			return IsolatedJsonConvert.DeserializeObject(value, type, null);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000067CA File Offset: 0x000049CA
		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value)
		{
			return IsolatedJsonConvert.DeserializeObject<T>(value, null);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000067D3 File Offset: 0x000049D3
		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject)
		{
			return IsolatedJsonConvert.DeserializeObject<T>(value);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000067DB File Offset: 0x000049DB
		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject, JsonSerializerSettings settings)
		{
			return IsolatedJsonConvert.DeserializeObject<T>(value, settings);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000067E4 File Offset: 0x000049E4
		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value, params JsonConverter[] converters)
		{
			return (T)((object)IsolatedJsonConvert.DeserializeObject(value, typeof(T), converters));
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000067FC File Offset: 0x000049FC
		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value, JsonSerializerSettings settings)
		{
			return (T)((object)IsolatedJsonConvert.DeserializeObject(value, typeof(T), settings));
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006814 File Offset: 0x00004A14
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type, params JsonConverter[] converters)
		{
			JsonSerializerSettings jsonSerializerSettings;
			if (converters == null || converters.Length == 0)
			{
				jsonSerializerSettings = null;
			}
			else
			{
				jsonSerializerSettings = new JsonSerializerSettings
				{
					Converters = converters
				};
			}
			JsonSerializerSettings settings = jsonSerializerSettings;
			return IsolatedJsonConvert.DeserializeObject(value, type, settings);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00006844 File Offset: 0x00004A44
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

		// Token: 0x0600023D RID: 573 RVA: 0x0000688C File Offset: 0x00004A8C
		[DebuggerStepThrough]
		public static void PopulateObject(string value, object target)
		{
			IsolatedJsonConvert.PopulateObject(value, target, null);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00006898 File Offset: 0x00004A98
		public static void PopulateObject(string value, object target, JsonSerializerSettings settings)
		{
			using (JsonReader jsonReader = new JsonTextReader(new StringReader(value)))
			{
				JsonSerializer.Create(settings).Populate(jsonReader, target);
				if (settings != null && settings.CheckAdditionalContent)
				{
					while (jsonReader.Read())
					{
						if (jsonReader.TokenType != JsonToken.Comment)
						{
							throw new JsonSerializationException("Additional text found in JSON string after finishing deserializing object.");
						}
					}
				}
			}
		}
	}
}
