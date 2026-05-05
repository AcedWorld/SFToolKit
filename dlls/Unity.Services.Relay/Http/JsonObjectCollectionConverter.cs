using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003E RID: 62
	[Preserve]
	internal class JsonObjectCollectionConverter : JsonConverter
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00004608 File Offset: 0x00002808
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			object obj = value;
			Type type = value.GetType();
			if (type == typeof(Dictionary<string, IDeserializable>))
			{
				obj = (Dictionary<string, IDeserializable>)value;
			}
			else if (type == typeof(List<IDeserializable>))
			{
				obj = (List<IDeserializable>)value;
			}
			else if (type == typeof(List<List<IDeserializable>>))
			{
				obj = (List<List<IDeserializable>>)value;
			}
			if (obj == null)
			{
				writer.WriteNull();
				return;
			}
			JToken.FromObject(obj).WriteTo(writer, Array.Empty<JsonConverter>());
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004688 File Offset: 0x00002888
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Null)
			{
				List<object> list = (List<object>)reader.Value;
				List<JsonObject> list2 = new List<JsonObject>();
				foreach (object obj in list)
				{
					list2.Add(new JsonObject(obj));
				}
				return list2;
			}
			return null;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000046F8 File Offset: 0x000028F8
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
