using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003C RID: 60
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal class JsonObject : IDeserializable
	{
		// Token: 0x060000EE RID: 238 RVA: 0x000040AF File Offset: 0x000022AF
		[Preserve]
		internal JsonObject(object obj)
		{
			this.obj = obj;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000040C0 File Offset: 0x000022C0
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
					result = JsonConvert.SerializeObject(this.obj);
				}
			}
			catch (Exception)
			{
				throw new InvalidOperationException("Failed to convert JsonObject to string.");
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004134 File Offset: 0x00002334
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
				T t = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(this.obj), settings);
				List<string> list = this.ValidateObject<T>(t, null);
				if (list.Count > 0)
				{
					throw new DeserializationException(string.Join("\n", list));
				}
				result = t;
			}
			catch (DeserializationException)
			{
				throw;
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

		// Token: 0x060000F1 RID: 241 RVA: 0x000041E4 File Offset: 0x000023E4
		public T GetAs<T>()
		{
			return this.GetAs<T>(null);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000041ED File Offset: 0x000023ED
		public static IDeserializable GetNewJsonObjectResponse(object o)
		{
			return new JsonObject(o);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000041F5 File Offset: 0x000023F5
		public static List<IDeserializable> GetNewJsonObjectResponse(List<object> o)
		{
			if (o == null)
			{
				return null;
			}
			return (from v in o
			select new JsonObject(v)).ToList<IDeserializable>();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004226 File Offset: 0x00002426
		public static List<List<IDeserializable>> GetNewJsonObjectResponse(List<List<object>> o)
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

		// Token: 0x060000F5 RID: 245 RVA: 0x00004258 File Offset: 0x00002458
		public static Dictionary<string, IDeserializable> GetNewJsonObjectResponse(Dictionary<string, object> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, object> kv) => kv.Key, (KeyValuePair<string, object> kv) => new JsonObject(kv.Value));
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000042B0 File Offset: 0x000024B0
		public static Dictionary<string, List<IDeserializable>> GetNewJsonObjectResponse(Dictionary<string, List<object>> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, List<object>> kv) => kv.Key, (KeyValuePair<string, List<object>> kv) => JsonObject.GetNewJsonObjectResponse(kv.Value));
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004308 File Offset: 0x00002508
		private List<string> ValidateObject<T>(T objectToCheck, List<string> errors = null)
		{
			if (errors == null)
			{
				errors = new List<string>();
			}
			if (objectToCheck != null)
			{
				if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
				{
					using (IEnumerator enumerator = ((IEnumerable)((object)objectToCheck)).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object objectToCheck2 = enumerator.Current;
							this.ValidateFieldInfos<object>(objectToCheck2, errors);
							this.ValidatePropertyInfos<object>(objectToCheck2, errors);
						}
						return errors;
					}
				}
				this.ValidateFieldInfos<T>(objectToCheck, errors);
				this.ValidatePropertyInfos<T>(objectToCheck, errors);
			}
			return errors;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000043A8 File Offset: 0x000025A8
		private void ValidatePropertyInfos<T>(T objectToCheck, List<string> errors)
		{
			foreach (PropertyInfo propertyInfo in objectToCheck.GetType().GetProperties())
			{
				if (propertyInfo.GetIndexParameters().Length != 0)
				{
					for (int j = 0; j < propertyInfo.GetIndexParameters().Length; j++)
					{
						object value = propertyInfo.GetValue(objectToCheck, new object[]
						{
							j
						});
						string name = propertyInfo.Name;
						string name2 = objectToCheck.GetType().Name;
						this.ValidateValue(value, name2, "Property", name, errors);
					}
				}
				else
				{
					object value2 = propertyInfo.GetValue(objectToCheck);
					string name3 = propertyInfo.Name;
					string name4 = objectToCheck.GetType().Name;
					this.ValidateValue(value2, name4, "Property", name3, errors);
				}
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004488 File Offset: 0x00002688
		private void ValidateFieldInfos<T>(T objectToCheck, List<string> errors)
		{
			foreach (FieldInfo fieldInfo in objectToCheck.GetType().GetFields())
			{
				object value = fieldInfo.GetValue(objectToCheck);
				string name = fieldInfo.Name;
				string name2 = objectToCheck.GetType().Name;
				this.ValidateValue(value, name2, "Field", name, errors);
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000044F0 File Offset: 0x000026F0
		private void ValidateValue(object value, string objectName, string memberType, string memberName, List<string> errors)
		{
			if (!(value is ValueType) && !(value is string))
			{
				if (value is JObject)
				{
					errors.Add(string.Concat(new string[]
					{
						memberType,
						": \"",
						memberName,
						"\" on Type: \"",
						objectName,
						"\" must not be of type `object` or `dynamic`"
					}));
					return;
				}
				this.ValidateObject<object>(value, errors);
			}
		}

		// Token: 0x04000096 RID: 150
		[Preserve]
		internal object obj;
	}
}
