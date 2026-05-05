using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000068 RID: 104
	[Preserve]
	internal class JsonObjectCollectionConverter : JsonConverter
	{
		// Token: 0x060001DD RID: 477 RVA: 0x00007568 File Offset: 0x00005768
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

		// Token: 0x060001DE RID: 478 RVA: 0x000075E8 File Offset: 0x000057E8
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

		// Token: 0x060001DF RID: 479 RVA: 0x00007658 File Offset: 0x00005858
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
