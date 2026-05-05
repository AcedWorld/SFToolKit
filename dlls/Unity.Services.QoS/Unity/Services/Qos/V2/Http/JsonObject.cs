using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000036 RID: 54
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal class JsonObject : IDeserializable
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00004C73 File Offset: 0x00002E73
		[Preserve]
		internal JsonObject(object obj)
		{
			this.obj = obj;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004C84 File Offset: 0x00002E84
		public string GetAsString()
		{
			string result;
			try
			{
				if (this.obj == null)
				{
					result = "";
				}
				else if (this.obj.GetType() == typeof(string))
				{
					result = this.obj.ToString();
				}
				else
				{
					result = IsolatedJsonConvert.SerializeObject(this.obj);
				}
			}
			catch (Exception)
			{
				throw new InvalidOperationException("Failed to convert JsonObject to string.");
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004CF8 File Offset: 0x00002EF8
		public T GetAs<T>(DeserializationSettings deserializationSettings = null)
		{
			deserializationSettings = (deserializationSettings ?? new DeserializationSettings());
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				MissingMemberHandling = ((deserializationSettings.MissingMemberHandling == MissingMemberHandling.Error) ? MissingMemberHandling.Error : MissingMemberHandling.Ignore)
			};
			T result;
			try
			{
				result = IsolatedJsonConvert.DeserializeObject<T>(IsolatedJsonConvert.SerializeObject(this.obj), settings);
			}
			catch (JsonSerializationException ex)
			{
				throw new DeserializationException(ex.Message);
			}
			catch (Exception)
			{
				throw new DeserializationException("Unable to deserialize object.");
			}
			return result;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004D74 File Offset: 0x00002F74
		public T GetAs<T>()
		{
			return this.GetAs<T>(null);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004D7D File Offset: 0x00002F7D
		internal static IDeserializable GetNewJsonObjectResponse(object o)
		{
			return new JsonObject(o);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004D85 File Offset: 0x00002F85
		internal static List<IDeserializable> GetNewJsonObjectResponse(List<object> o)
		{
			if (o == null)
			{
				return null;
			}
			return (from v in o
			select new JsonObject(v)).ToList<IDeserializable>();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004DB6 File Offset: 0x00002FB6
		internal static List<List<IDeserializable>> GetNewJsonObjectResponse(List<List<object>> o)
		{
			if (o == null)
			{
				return null;
			}
			return (from l in o
			select l.Select(delegate(object v)
			{
				if (v != null)
				{
					return new JsonObject(v);
				}
				return null;
			}).ToList<IDeserializable>()).ToList<List<IDeserializable>>();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004DE8 File Offset: 0x00002FE8
		internal static Dictionary<string, IDeserializable> GetNewJsonObjectResponse(Dictionary<string, object> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, object> kv) => kv.Key, (KeyValuePair<string, object> kv) => new JsonObject(kv.Value));
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004E40 File Offset: 0x00003040
		internal static Dictionary<string, List<IDeserializable>> GetNewJsonObjectResponse(Dictionary<string, List<object>> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, List<object>> kv) => kv.Key, (KeyValuePair<string, List<object>> kv) => JsonObject.GetNewJsonObjectResponse(kv.Value));
		}

		// Token: 0x04000092 RID: 146
		[Preserve]
		internal object obj;
	}
}
