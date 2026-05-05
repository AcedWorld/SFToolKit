using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000056 RID: 86
	[Preserve]
	internal class JsonObjectCollectionConverter : JsonConverter
	{
		// Token: 0x06000245 RID: 581 RVA: 0x00008BEC File Offset: 0x00006DEC
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

		// Token: 0x06000246 RID: 582 RVA: 0x00008C6C File Offset: 0x00006E6C
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

		// Token: 0x06000247 RID: 583 RVA: 0x00008CDC File Offset: 0x00006EDC
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
