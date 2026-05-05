using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000055 RID: 85
	[Preserve]
	public class JsonObjectConverter : JsonConverter
	{
		// Token: 0x06000241 RID: 577 RVA: 0x00008B3C File Offset: 0x00006D3C
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

		// Token: 0x06000242 RID: 578 RVA: 0x00008B78 File Offset: 0x00006D78
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

		// Token: 0x06000243 RID: 579 RVA: 0x00008BDC File Offset: 0x00006DDC
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
