using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003D RID: 61
	[Preserve]
	internal class JsonObjectConverter : JsonConverter
	{
		// Token: 0x060000FB RID: 251 RVA: 0x00004558 File Offset: 0x00002758
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JsonObject jsonObject = (JsonObject)value;
			if (jsonObject.obj == null)
			{
				writer.WriteNull();
				return;
			}
			JToken.FromObject(jsonObject.obj).WriteTo(writer, Array.Empty<JsonConverter>());
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004594 File Offset: 0x00002794
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

		// Token: 0x060000FD RID: 253 RVA: 0x000045F8 File Offset: 0x000027F8
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
