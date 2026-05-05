using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000054 RID: 84
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	public class JsonObject : IDeserializable
	{
		// Token: 0x06000234 RID: 564 RVA: 0x00008693 File Offset: 0x00006893
		[Preserve]
		internal JsonObject(object obj)
		{
			this.obj = obj;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000086A4 File Offset: 0x000068A4
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

		// Token: 0x06000236 RID: 566 RVA: 0x00008718 File Offset: 0x00006918
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

		// Token: 0x06000237 RID: 567 RVA: 0x000087C8 File Offset: 0x000069C8
		public T GetAs<T>()
		{
			return this.GetAs<T>(null);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000087D1 File Offset: 0x000069D1
		public static IDeserializable GetNewJsonObjectResponse(object o)
		{
			return new JsonObject(o);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000087D9 File Offset: 0x000069D9
		public static List<IDeserializable> GetNewJsonObjectResponse(List<object> o)
		{
			if (o == null)
			{
				return null;
			}
			return (from v in o
			select new JsonObject(v)).ToList<IDeserializable>();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000880A File Offset: 0x00006A0A
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

		// Token: 0x0600023B RID: 571 RVA: 0x0000883C File Offset: 0x00006A3C
		public static Dictionary<string, IDeserializable> GetNewJsonObjectResponse(Dictionary<string, object> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, object> kv) => kv.Key, (KeyValuePair<string, object> kv) => new JsonObject(kv.Value));
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00008894 File Offset: 0x00006A94
		public static Dictionary<string, List<IDeserializable>> GetNewJsonObjectResponse(Dictionary<string, List<object>> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, List<object>> kv) => kv.Key, (KeyValuePair<string, List<object>> kv) => JsonObject.GetNewJsonObjectResponse(kv.Value));
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000088EC File Offset: 0x00006AEC
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

		// Token: 0x0600023E RID: 574 RVA: 0x0000898C File Offset: 0x00006B8C
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

		// Token: 0x0600023F RID: 575 RVA: 0x00008A6C File Offset: 0x00006C6C
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

		// Token: 0x06000240 RID: 576 RVA: 0x00008AD4 File Offset: 0x00006CD4
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

		// Token: 0x0400011A RID: 282
		[Preserve]
		internal object obj;
	}
}
