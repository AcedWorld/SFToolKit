using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000067 RID: 103
	[Preserve]
	internal class JsonObjectConverter : JsonConverter
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x000074B8 File Offset: 0x000056B8
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

		// Token: 0x060001DA RID: 474 RVA: 0x000074F4 File Offset: 0x000056F4
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

		// Token: 0x060001DB RID: 475 RVA: 0x00007558 File Offset: 0x00005758
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
