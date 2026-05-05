using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000063 RID: 99
	internal class ApiUtils
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x000070FC File Offset: 0x000052FC
		public static Multimap<string, string> ParameterToMultiMap(IApiConfiguration configuration, string collectionFormat, string name, object value)
		{
			Multimap<string, string> multimap = new Multimap<string, string>();
			ICollection collection = value as ICollection;
			if (collection != null && collectionFormat == "multi")
			{
				using (IEnumerator enumerator = collection.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						multimap.Add(name, ApiUtils.ParameterToString(configuration, obj));
					}
					return multimap;
				}
			}
			IDictionary dictionary = value as IDictionary;
			if (dictionary != null)
			{
				if (collectionFormat == "deepObject")
				{
					using (IDictionaryEnumerator enumerator2 = dictionary.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							DictionaryEntry dictionaryEntry = (DictionaryEntry)obj2;
							Multimap<string, string> multimap2 = multimap;
							string str = "[";
							object key = dictionaryEntry.Key;
							multimap2.Add(name + str + ((key != null) ? key.ToString() : null) + "]", ApiUtils.ParameterToString(configuration, dictionaryEntry.Value));
						}
						return multimap;
					}
				}
				using (IDictionaryEnumerator enumerator2 = dictionary.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						object obj3 = enumerator2.Current;
						DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj3;
						multimap.Add(dictionaryEntry2.Key.ToString(), ApiUtils.ParameterToString(configuration, dictionaryEntry2.Value));
					}
					return multimap;
				}
			}
			multimap.Add(name, ApiUtils.ParameterToString(configuration, value));
			return multimap;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00007280 File Offset: 0x00005480
		public static string ParameterToString(IApiConfiguration configuration, object obj)
		{
			if (obj is DateTime)
			{
				return ((DateTime)obj).ToString(configuration.DateTimeFormat);
			}
			if (obj is DateTimeOffset)
			{
				return ((DateTimeOffset)obj).ToString(configuration.DateTimeFormat);
			}
			if (obj is bool)
			{
				if (!(bool)obj)
				{
					return "false";
				}
				return "true";
			}
			else
			{
				ICollection collection = obj as ICollection;
				if (collection != null)
				{
					return string.Join<object>(",", collection.Cast<object>());
				}
				if (obj is Enum && ApiUtils.HasEnumMemberAttrValue(obj))
				{
					return ApiUtils.GetEnumMemberAttrValue(obj);
				}
				return Convert.ToString(obj, CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00007322 File Offset: 0x00005522
		public static string Base64Encode(string text)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00007334 File Offset: 0x00005534
		public static string SelectHeaderContentType(string[] contentTypes)
		{
			if (contentTypes.Length == 0)
			{
				return null;
			}
			foreach (string text in contentTypes)
			{
				if (ApiUtils.IsJsonMime(text))
				{
					return text;
				}
			}
			return contentTypes[0];
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00007368 File Offset: 0x00005568
		public static string SelectHeaderAccept(string[] accepts)
		{
			if (accepts.Length == 0)
			{
				return null;
			}
			if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
			{
				return "application/json";
			}
			return string.Join(",", accepts);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00007393 File Offset: 0x00005593
		public static bool IsJsonMime(string mime)
		{
			return !string.IsNullOrWhiteSpace(mime) && (ApiUtils.JsonRegex.IsMatch(mime) || mime.Equals("application/json-patch+json"));
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000073BC File Offset: 0x000055BC
		private static bool HasEnumMemberAttrValue(object enumVal)
		{
			if (enumVal == null)
			{
				throw new ArgumentNullException("enumVal");
			}
			Type type = enumVal.GetType();
			string text = enumVal.ToString();
			if (text == null)
			{
				throw new InvalidOperationException();
			}
			MemberInfo memberInfo = type.GetMember(text).FirstOrDefault<MemberInfo>();
			return ((memberInfo != null) ? memberInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault<EnumMemberAttribute>() : null) != null;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00007414 File Offset: 0x00005614
		private static string GetEnumMemberAttrValue(object enumVal)
		{
			if (enumVal == null)
			{
				throw new ArgumentNullException("enumVal");
			}
			Type type = enumVal.GetType();
			string text = enumVal.ToString();
			if (text == null)
			{
				throw new InvalidOperationException();
			}
			MemberInfo memberInfo = type.GetMember(text).FirstOrDefault<MemberInfo>();
			EnumMemberAttribute enumMemberAttribute = (memberInfo != null) ? memberInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault<EnumMemberAttribute>() : null;
			if (enumMemberAttribute != null)
			{
				return enumMemberAttribute.Value;
			}
			return null;
		}

		// Token: 0x0400014A RID: 330
		public static readonly Regex JsonRegex = new Regex("(?i)^(application/json|[^;/ \t]+/[^;/ \t]+[+]json)[ \t]*(;.*)?$");
	}
}
