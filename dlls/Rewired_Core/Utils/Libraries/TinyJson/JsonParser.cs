using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils.Libraries.TinyJson
{
	// Token: 0x020004BA RID: 1210
	public static class JsonParser
	{
		// Token: 0x060030DD RID: 12509 RVA: 0x000255CB File Offset: 0x000237CB
		public static bool TryFromJson<T>(string json, out T value)
		{
			return JsonParser.TryFromJson<T>(json, out value, null);
		}

		// Token: 0x060030DE RID: 12510 RVA: 0x000AA1C0 File Offset: 0x000A83C0
		[CustomObfuscation(rename = false)]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			bool result;
			try
			{
				if (string.IsNullOrEmpty(json))
				{
					value = default(T);
					result = false;
				}
				else
				{
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length = 0;
					for (int i = 0; i < json.Length; i++)
					{
						char c = json[i];
						if (c == '"')
						{
							i = JsonParser.MvvBakytZDFZJbxAIjFJweNjhSMpA(true, i, json);
						}
						else if (!char.IsWhiteSpace(c))
						{
							JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(c);
						}
					}
					bool flag;
					value = (T)((object)JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(typeof(T), JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.ToString(), preferredAnonymousObjectType, out flag));
					result = true;
				}
			}
			catch
			{
				value = default(T);
				result = false;
			}
			return result;
		}

		// Token: 0x060030DF RID: 12511 RVA: 0x000255D5 File Offset: 0x000237D5
		public static T FromJson<T>(string json)
		{
			return JsonParser.FromJson<T>(json, null);
		}

		// Token: 0x060030E0 RID: 12512 RVA: 0x000AA270 File Offset: 0x000A8470
		[CustomObfuscation(rename = false)]
		internal static T FromJson<T>(string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return default(T);
			}
			JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length = 0;
			for (int i = 0; i < json.Length; i++)
			{
				char c = json[i];
				if (c == '"')
				{
					i = JsonParser.MvvBakytZDFZJbxAIjFJweNjhSMpA(true, i, json);
				}
				else if (!char.IsWhiteSpace(c))
				{
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(c);
				}
			}
			bool flag;
			return (T)((object)JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(typeof(T), JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.ToString(), preferredAnonymousObjectType, out flag));
		}

		// Token: 0x060030E1 RID: 12513 RVA: 0x000255DE File Offset: 0x000237DE
		public static object FromJson(Type type, string json)
		{
			return JsonParser.FromJson(type, json, null);
		}

		// Token: 0x060030E2 RID: 12514 RVA: 0x000AA2F8 File Offset: 0x000A84F8
		[CustomObfuscation(rename = false)]
		internal static object FromJson(Type type, string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return null;
			}
			JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length = 0;
			for (int i = 0; i < json.Length; i++)
			{
				char c = json[i];
				if (c == '"')
				{
					i = JsonParser.MvvBakytZDFZJbxAIjFJweNjhSMpA(true, i, json);
				}
				else if (!char.IsWhiteSpace(c))
				{
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(c);
				}
			}
			bool flag;
			return JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(type, JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.ToString(), preferredAnonymousObjectType, out flag);
		}

		// Token: 0x060030E3 RID: 12515 RVA: 0x000AA36C File Offset: 0x000A856C
		private static object iGIsjWelCFXBnLZIPeTjOxtQPLPw(Type A_0, string A_1, Type A_2, out bool A_3)
		{
			if (string.IsNullOrEmpty(A_1))
			{
				A_3 = false;
				return null;
			}
			if (A_0 == typeof(string))
			{
				if (A_1.Length <= 2)
				{
					A_3 = false;
					return string.Empty;
				}
				string text = A_1.Substring(1, A_1.Length - 2);
				A_3 = true;
				return text.Replace("\\", string.Empty);
			}
			else
			{
				if (A_0 == typeof(int))
				{
					int num;
					A_3 = int.TryParse(A_1, out num);
					return num;
				}
				if (A_0 == typeof(float))
				{
					float num2;
					A_3 = float.TryParse(A_1, NumberStyles.Any, CultureInfo.InvariantCulture, out num2);
					return num2;
				}
				if (A_0 == typeof(double))
				{
					double num3;
					A_3 = double.TryParse(A_1, NumberStyles.Any, CultureInfo.InvariantCulture, out num3);
					return num3;
				}
				if (A_0 != typeof(bool))
				{
					if (A_0 == typeof(Guid))
					{
						try
						{
							bool flag;
							string g = (string)JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(typeof(string), A_1, A_2, out flag);
							if (!flag)
							{
								A_3 = false;
								return Guid.Empty;
							}
							A_3 = true;
							return new Guid(g);
						}
						catch
						{
							A_3 = false;
							return Guid.Empty;
						}
					}
					if (ReflectionTools.IsEnum(A_0))
					{
						bool flag2;
						object obj = JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(ReflectionTools.GetUnderlyingEnumType(A_0), A_1, A_2, out flag2);
						if (flag2 && obj != null && ReflectionTools.IsValueType(obj.GetType()))
						{
							A_3 = true;
							return Enum.ToObject(A_0, obj);
						}
						try
						{
							obj = JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(typeof(string), A_1, A_2, out flag2);
							if (flag2 && !string.IsNullOrEmpty((string)obj))
							{
								obj = Enum.Parse(A_0, (string)obj, true);
								if (obj != null)
								{
									A_3 = true;
									return obj;
								}
							}
						}
						catch
						{
						}
					}
					if (A_1 == "null")
					{
						A_3 = true;
						return null;
					}
					if (A_2 != null && ReflectionTools.DoesTypeImplement(A_2, A_0))
					{
						return JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(A_1, A_2, out A_3);
					}
					if (ReflectionTools.IsArray(A_0))
					{
						Type elementType = A_0.GetElementType();
						if (A_1[0] != '[' || A_1[A_1.Length - 1] != ']')
						{
							A_3 = false;
							return null;
						}
						List<string> list = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_1);
						Array array = Array.CreateInstance(elementType, list.Count);
						for (int i = 0; i < list.Count; i++)
						{
							bool flag3;
							array.SetValue(JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(elementType, list[i], A_2, out flag3), i);
						}
						JsonParser.splitArrayPool.Push(list);
						A_3 = true;
						return array;
					}
					else
					{
						bool flag4 = ReflectionTools.IsGenericType(A_0);
						if (flag4 && A_0.GetGenericTypeDefinition() == typeof(List<>))
						{
							Type type = ReflectionTools.GetGenericArguments(A_0)[0];
							if (A_1[0] != '[' || A_1[A_1.Length - 1] != ']')
							{
								A_3 = false;
								return null;
							}
							IList list2 = (IList)Factory.CreateInstance(typeof(List<>).MakeGenericType(new Type[]
							{
								type
							}), null);
							List<string> list3 = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_1);
							for (int j = 0; j < list3.Count; j++)
							{
								bool flag5;
								list2.Add(JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(type, list3[j], A_2, out flag5));
							}
							JsonParser.splitArrayPool.Push(list3);
							A_3 = true;
							return list2;
						}
						else
						{
							if (flag4 && A_0.GetGenericTypeDefinition() == typeof(Dictionary<, >))
							{
								Type[] genericArguments = ReflectionTools.GetGenericArguments(A_0);
								Type type2 = genericArguments[0];
								Type type3 = genericArguments[1];
								if (type2 != typeof(string))
								{
									A_3 = false;
									return null;
								}
								if (A_1[0] != '{' || A_1[A_1.Length - 1] != '}')
								{
									A_3 = false;
									return null;
								}
								List<string> list4 = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_1);
								try
								{
									if (list4.Count % 2 != 0)
									{
										A_3 = false;
										return null;
									}
									IDictionary dictionary = (IDictionary)Factory.CreateInstance(typeof(Dictionary<, >).MakeGenericType(new Type[]
									{
										type2,
										type3
									}), null);
									for (int k = 0; k < list4.Count; k += 2)
									{
										if (list4[k].Length > 2)
										{
											string key = list4[k].Substring(1, list4[k].Length - 2);
											bool flag6;
											object value = JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(type3, list4[k + 1], A_2, out flag6);
											dictionary.Add(key, value);
										}
									}
									A_3 = true;
									return dictionary;
								}
								finally
								{
									if (list4 != null)
									{
										JsonParser.splitArrayPool.Push(list4);
									}
								}
							}
							if (A_0 == typeof(object))
							{
								return JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(A_1, A_2, out A_3);
							}
							if (A_1[0] == '{' && A_1[A_1.Length - 1] == '}')
							{
								A_3 = true;
								return JsonParser.GDLrKSfSpCklJTEiUhMuvAkwCJcq(A_0, A_1, A_2);
							}
							A_3 = false;
							return null;
						}
					}
					object result;
					return result;
				}
				if (string.Equals(A_1, "true", StringComparison.OrdinalIgnoreCase))
				{
					A_3 = true;
					return true;
				}
				if (string.Equals(A_1, "false", StringComparison.OrdinalIgnoreCase))
				{
					A_3 = true;
					return false;
				}
				A_3 = false;
				return false;
			}
		}

		// Token: 0x060030E4 RID: 12516 RVA: 0x000AA89C File Offset: 0x000A8A9C
		private static object bPPjKYjnMoNBYHABRCblIIIUTLlVA(string A_0, Type A_1, out bool A_2)
		{
			if (A_0.Length == 0)
			{
				A_2 = false;
				return null;
			}
			if (A_0[0] == '{' && A_0[A_0.Length - 1] == '}')
			{
				List<string> list = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_0);
				try
				{
					if (list.Count % 2 != 0)
					{
						A_2 = false;
						return null;
					}
					if (A_1 != null && ReflectionTools.DoesTypeImplement(A_1, typeof(IAddKeyValue<string, object>)))
					{
						IAddKeyValue<string, object> addKeyValue = (IAddKeyValue<string, object>)Factory.CreateInstance(A_1, new object[]
						{
							list.Count / 2
						});
						for (int i = 0; i < list.Count; i += 2)
						{
							bool flag;
							addKeyValue.Add(list[i].Substring(1, list[i].Length - 2), JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(list[i + 1], A_1, out flag));
						}
						A_2 = true;
						return addKeyValue;
					}
					Dictionary<string, object> dictionary = new Dictionary<string, object>(list.Count / 2);
					for (int j = 0; j < list.Count; j += 2)
					{
						bool flag2;
						dictionary.Add(list[j].Substring(1, list[j].Length - 2), JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(list[j + 1], A_1, out flag2));
					}
					A_2 = true;
					return dictionary;
				}
				finally
				{
					if (list != null)
					{
						JsonParser.splitArrayPool.Push(list);
					}
				}
			}
			if (A_0[0] == '[' && A_0[A_0.Length - 1] == ']')
			{
				List<string> list2 = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_0);
				try
				{
					if (A_1 != null && ReflectionTools.DoesTypeImplement(A_1, typeof(IAddValue<object>)))
					{
						IAddValue<object> addValue = (IAddValue<object>)Factory.CreateInstance(A_1, new object[]
						{
							list2.Count
						});
						for (int k = 0; k < list2.Count; k++)
						{
							bool flag3;
							addValue.Add(JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(list2[k], A_1, out flag3));
						}
						A_2 = true;
						return addValue;
					}
					List<object> list3 = new List<object>(list2.Count);
					for (int l = 0; l < list2.Count; l++)
					{
						bool flag4;
						list3.Add(JsonParser.bPPjKYjnMoNBYHABRCblIIIUTLlVA(list2[l], A_1, out flag4));
					}
					A_2 = true;
					return list3;
				}
				finally
				{
					if (list2 != null)
					{
						JsonParser.splitArrayPool.Push(list2);
					}
				}
			}
			if (A_0[0] == '"' && A_0[A_0.Length - 1] == '"')
			{
				string text = A_0.Substring(1, A_0.Length - 2);
				A_2 = true;
				return text.Replace("\\", string.Empty);
			}
			if (char.IsDigit(A_0[0]) || A_0[0] == '-')
			{
				if (A_0.Contains("."))
				{
					double num;
					A_2 = double.TryParse(A_0, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
					return num;
				}
				int num2;
				A_2 = int.TryParse(A_0, out num2);
				return num2;
			}
			else
			{
				if (A_0 == "true")
				{
					A_2 = true;
					return true;
				}
				if (A_0 == "false")
				{
					A_2 = true;
					return false;
				}
				A_2 = true;
				return null;
			}
			object result;
			return result;
		}

		// Token: 0x060030E5 RID: 12517 RVA: 0x000AABEC File Offset: 0x000A8DEC
		private static object GDLrKSfSpCklJTEiUhMuvAkwCJcq(Type A_0, string A_1, Type A_2)
		{
			object obj = Factory.CreateInstance(A_0, null);
			List<string> list = JsonParser.nHGqkUhQGCSgTRHjNxpAqZrekqaq(A_1);
			object result;
			try
			{
				if (list.Count % 2 != 0)
				{
					result = obj;
				}
				else
				{
					Dictionary<string, FieldInfo> dictionary;
					if (!JsonParser.AtHlyTImOnQJQXjfwcVSaZujgPaPA.TryGetValue(A_0, out dictionary))
					{
						dictionary = ReflectionTools.GetFields(A_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(new Func<FieldInfo, bool>(JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF.<>9.HafbZLeSUJREgxzgLZYQNnZOZsTM)).ToDictionary(new Func<FieldInfo, string>(JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF.<>9.dLxmqlUkmmyYYtXcmgyaIKICakTX));
						JsonParser.AtHlyTImOnQJQXjfwcVSaZujgPaPA.Add(A_0, dictionary);
					}
					Dictionary<string, PropertyInfo> dictionary2;
					if (!JsonParser.zaJIxcbiogTSTqWAUIxbsrvyRQRFA.TryGetValue(A_0, out dictionary2))
					{
						dictionary2 = ReflectionTools.GetProperties(A_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(new Func<PropertyInfo, bool>(JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF.<>9.YvFsvXPQakuxhivYVrIbARQVDLObA)).ToDictionary(new Func<PropertyInfo, string>(JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF.<>9.TcofjQsiSgNCupFArtxNzlnfRfjD));
						JsonParser.zaJIxcbiogTSTqWAUIxbsrvyRQRFA.Add(A_0, dictionary2);
					}
					for (int i = 0; i < list.Count; i += 2)
					{
						if (list[i].Length > 2)
						{
							string key = list[i].Substring(1, list[i].Length - 2);
							string text = list[i + 1];
							FieldInfo fieldInfo;
							PropertyInfo propertyInfo;
							if (dictionary.TryGetValue(key, out fieldInfo))
							{
								bool flag;
								fieldInfo.SetValue(obj, JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(fieldInfo.FieldType, text, A_2, out flag));
							}
							else if (dictionary2.TryGetValue(key, out propertyInfo) && propertyInfo.CanWrite)
							{
								bool flag2;
								propertyInfo.SetValue(obj, JsonParser.iGIsjWelCFXBnLZIPeTjOxtQPLPw(propertyInfo.PropertyType, text, A_2, out flag2), null);
							}
						}
					}
					ISerializationCallbackReceiver serializationCallbackReceiver = obj as ISerializationCallbackReceiver;
					if (serializationCallbackReceiver != null)
					{
						try
						{
							serializationCallbackReceiver.OnAfterDeserialize();
						}
						catch (Exception ex)
						{
							Logger.LogError(ex.ToString(), true);
						}
					}
					result = obj;
				}
			}
			finally
			{
				if (list != null)
				{
					JsonParser.splitArrayPool.Push(list);
				}
			}
			return result;
		}

		// Token: 0x060030E6 RID: 12518 RVA: 0x000AAE10 File Offset: 0x000A9010
		private static int MvvBakytZDFZJbxAIjFJweNjhSMpA(bool A_0, int A_1, string A_2)
		{
			JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_2[A_1]);
			for (int i = A_1 + 1; i < A_2.Length; i++)
			{
				if (A_2[i] == '\\')
				{
					if (A_0)
					{
						JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_2[i]);
					}
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_2[i + 1]);
					i++;
				}
				else
				{
					if (A_2[i] == '"')
					{
						JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_2[i]);
						return i;
					}
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_2[i]);
				}
			}
			return A_2.Length - 1;
		}

		// Token: 0x060030E7 RID: 12519 RVA: 0x000AAEB8 File Offset: 0x000A90B8
		private static List<string> nHGqkUhQGCSgTRHjNxpAqZrekqaq(string A_0)
		{
			List<string> list = (JsonParser.splitArrayPool.Count > 0) ? JsonParser.splitArrayPool.Pop() : new List<string>();
			list.Clear();
			int num = 0;
			JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length = 0;
			int i = 1;
			while (i < A_0.Length - 1)
			{
				char c = A_0[i];
				if (c > ':')
				{
					if (c <= ']')
					{
						if (c != '[')
						{
							if (c != ']')
							{
								goto IL_AB;
							}
							goto IL_7A;
						}
					}
					else if (c != '{')
					{
						if (c != '}')
						{
							goto IL_AB;
						}
						goto IL_7A;
					}
					num++;
					goto IL_AB;
					IL_7A:
					num--;
					goto IL_AB;
				}
				if (c != '"')
				{
					if (c != ',' && c != ':')
					{
						goto IL_AB;
					}
					if (num != 0)
					{
						goto IL_AB;
					}
					list.Add(JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.ToString());
					JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length = 0;
				}
				else
				{
					i = JsonParser.MvvBakytZDFZJbxAIjFJweNjhSMpA(true, i, A_0);
				}
				IL_BD:
				i++;
				continue;
				IL_AB:
				JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Append(A_0[i]);
				goto IL_BD;
			}
			if (JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.Length == 0)
			{
				return list;
			}
			list.Add(JsonParser.RWfEXPTMCrhLvRCFWKizDpbufqCs.ToString());
			return list;
		}

		// Token: 0x04001AC7 RID: 6855
		[CustomObfuscation(rename = false)]
		internal static Stack<List<string>> splitArrayPool = new Stack<List<string>>();

		// Token: 0x04001AC8 RID: 6856
		private static StringBuilder RWfEXPTMCrhLvRCFWKizDpbufqCs = new StringBuilder();

		// Token: 0x04001AC9 RID: 6857
		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> AtHlyTImOnQJQXjfwcVSaZujgPaPA = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		// Token: 0x04001ACA RID: 6858
		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> zaJIxcbiogTSTqWAUIxbsrvyRQRFA = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		// Token: 0x020004BB RID: 1211
		[CompilerGenerated]
		[Serializable]
		private sealed class mdGbGyiwthZECGlUYMSknXTbdiSF
		{
			// Token: 0x060030EB RID: 12523 RVA: 0x000AAFB4 File Offset: 0x000A91B4
			internal bool HafbZLeSUJREgxzgLZYQNnZOZsTM(FieldInfo A_1)
			{
				return (A_1.IsPublic || A_1.IsDefined(typeof(SerializeAttribute), true) || A_1.IsDefined(typeof(SerializeField), true)) && !A_1.IsDefined(typeof(NonSerializedAttribute), true) && !A_1.IsDefined(typeof(DoNotSerializeAttribute), true);
			}

			// Token: 0x060030EC RID: 12524 RVA: 0x000AB018 File Offset: 0x000A9218
			internal string dLxmqlUkmmyYYtXcmgyaIKICakTX(FieldInfo A_1)
			{
				string name;
				if (A_1.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(A_1.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return A_1.Name;
			}

			// Token: 0x060030ED RID: 12525 RVA: 0x0002561E File Offset: 0x0002381E
			internal bool YvFsvXPQakuxhivYVrIbARQVDLObA(PropertyInfo A_1)
			{
				return A_1.CanWrite && A_1.IsDefined(typeof(SerializeAttribute), true) && !A_1.IsDefined(typeof(DoNotSerializeAttribute), true);
			}

			// Token: 0x060030EE RID: 12526 RVA: 0x000AB018 File Offset: 0x000A9218
			internal string TcofjQsiSgNCupFArtxNzlnfRfjD(PropertyInfo A_1)
			{
				string name;
				if (A_1.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(A_1.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return A_1.Name;
			}

			// Token: 0x04001ACB RID: 6859
			public static readonly JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF <>9 = new JsonParser.mdGbGyiwthZECGlUYMSknXTbdiSF();

			// Token: 0x04001ACC RID: 6860
			public static Func<FieldInfo, bool> <>9__12_0;

			// Token: 0x04001ACD RID: 6861
			public static Func<FieldInfo, string> <>9__12_1;

			// Token: 0x04001ACE RID: 6862
			public static Func<PropertyInfo, bool> <>9__12_2;

			// Token: 0x04001ACF RID: 6863
			public static Func<PropertyInfo, string> <>9__12_3;
		}
	}
}
