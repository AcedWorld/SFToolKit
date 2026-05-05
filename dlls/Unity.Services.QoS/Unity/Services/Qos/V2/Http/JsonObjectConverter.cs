using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000037 RID: 55
	[Preserve]
	internal class JsonObjectConverter : JsonConverter
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00004E98 File Offset: 0x00003098
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JsonObject jsonObject = (JsonObject)value;
			if (jsonObject.obj == null)
			{
				writer.WriteNull();
				return;
			}
			JToken.FromObject(jsonObject.obj, serializer).WriteTo(writer, Array.Empty<JsonConverter>());
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004ED4 File Offset: 0x000030D4
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Null)
			{
				if (reader.Value != null)
				{
					return new JsonObject(reader.Value);
				}
				try
				{
					return new JsonObject(JObject.Load(reader));
				}
				catch (JsonReaderException)
				{
					return new JsonObject(JArray.Load(reader));
				}
			}
			return new JsonObject(null);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004F38 File Offset: 0x00003138
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
