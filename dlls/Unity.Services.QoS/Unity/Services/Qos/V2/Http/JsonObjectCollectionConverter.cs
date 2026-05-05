using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000038 RID: 56
	[Preserve]
	internal class JsonObjectCollectionConverter : JsonConverter
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00004F48 File Offset: 0x00003148
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

		// Token: 0x060000E6 RID: 230 RVA: 0x00004FC8 File Offset: 0x000031C8
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

		// Token: 0x060000E7 RID: 231 RVA: 0x00005038 File Offset: 0x00003238
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
