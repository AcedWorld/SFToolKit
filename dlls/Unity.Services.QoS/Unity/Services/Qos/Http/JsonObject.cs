using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000066 RID: 102
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal class JsonObject : IDeserializable
	{
		// Token: 0x060001CC RID: 460 RVA: 0x0000700F File Offset: 0x0000520F
		[Preserve]
		internal JsonObject(object obj)
		{
			this.obj = obj;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00007020 File Offset: 0x00005220
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

		// Token: 0x060001CE RID: 462 RVA: 0x00007094 File Offset: 0x00005294
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

		// Token: 0x060001CF RID: 463 RVA: 0x00007144 File Offset: 0x00005344
		public T GetAs<T>()
		{
			return this.GetAs<T>(null);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000714D File Offset: 0x0000534D
		internal static IDeserializable GetNewJsonObjectResponse(object o)
		{
			return new JsonObject(o);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00007155 File Offset: 0x00005355
		internal static List<IDeserializable> GetNewJsonObjectResponse(List<object> o)
		{
			if (o == null)
			{
				return null;
			}
			return (from v in o
			select new JsonObject(v)).ToList<IDeserializable>();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00007186 File Offset: 0x00005386
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

		// Token: 0x060001D3 RID: 467 RVA: 0x000071B8 File Offset: 0x000053B8
		internal static Dictionary<string, IDeserializable> GetNewJsonObjectResponse(Dictionary<string, object> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, object> kv) => kv.Key, (KeyValuePair<string, object> kv) => new JsonObject(kv.Value));
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007210 File Offset: 0x00005410
		internal static Dictionary<string, List<IDeserializable>> GetNewJsonObjectResponse(Dictionary<string, List<object>> o)
		{
			if (o == null)
			{
				return null;
			}
			return o.ToDictionary((KeyValuePair<string, List<object>> kv) => kv.Key, (KeyValuePair<string, List<object>> kv) => JsonObject.GetNewJsonObjectResponse(kv.Value));
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007268 File Offset: 0x00005468
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

		// Token: 0x060001D6 RID: 470 RVA: 0x00007308 File Offset: 0x00005508
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

		// Token: 0x060001D7 RID: 471 RVA: 0x000073E8 File Offset: 0x000055E8
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

		// Token: 0x060001D8 RID: 472 RVA: 0x00007450 File Offset: 0x00005650
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

		// Token: 0x040000D6 RID: 214
		[Preserve]
		internal object obj;
	}
}
