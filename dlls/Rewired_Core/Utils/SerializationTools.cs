using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x02000499 RID: 1177
	public static class SerializationTools
	{
		// Token: 0x06002F50 RID: 12112 RVA: 0x000A4A98 File Offset: 0x000A2C98
		public static string SerializeObjectToXmlString<T>(T obj)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			string result = string.Empty;
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, obj);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x06002F51 RID: 12113 RVA: 0x000A4AF8 File Offset: 0x000A2CF8
		public static void WriteXmlElement(XmlWriter writer, string name, object value)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			bool flag = false;
			if (value is IExportToXml && (value as IExportToXml).writesOwnElementTag)
			{
				flag = true;
			}
			if (flag)
			{
				SerializationTools.wAildCErUBBFQYifBsZFZKZiAJwD(writer, value);
				return;
			}
			writer.WriteStartElement(name);
			SerializationTools.wAildCErUBBFQYifBsZFZKZiAJwD(writer, value);
			writer.WriteEndElement();
		}

		// Token: 0x06002F52 RID: 12114 RVA: 0x000242A0 File Offset: 0x000224A0
		public static void WriteXmlElement<T>(XmlWriter writer, string name, T value)
		{
			SerializationTools.WriteXmlElement(writer, name, value);
		}

		// Token: 0x06002F53 RID: 12115 RVA: 0x000A4B60 File Offset: 0x000A2D60
		private static void wAildCErUBBFQYifBsZFZKZiAJwD(XmlWriter A_0, object A_1)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (A_1 == null)
			{
				return;
			}
			Type type = A_1.GetType();
			if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToXml)))
			{
				((IExportToXml)A_1).WriteXml(A_0);
				return;
			}
			if (type == typeof(string))
			{
				A_0.WriteValue(SerializationTools.CleanInvalidXmlChars((string)A_1));
				return;
			}
			if (type == typeof(char))
			{
				A_0.WriteValue(SerializationTools.CleanInvalidXmlChars(A_1.ToString()));
				return;
			}
			if (type == typeof(byte))
			{
				A_0.WriteValue((int)A_1);
				return;
			}
			if (type == typeof(sbyte))
			{
				A_0.WriteValue((int)A_1);
				return;
			}
			if (type == typeof(short))
			{
				A_0.WriteValue((int)((short)A_1));
				return;
			}
			if (type == typeof(ushort))
			{
				A_0.WriteValue((int)((ushort)A_1));
				return;
			}
			if (type == typeof(int))
			{
				A_0.WriteValue((int)A_1);
				return;
			}
			if (type == typeof(uint))
			{
				A_0.WriteValue((long)((ulong)((uint)A_1)));
				return;
			}
			if (type == typeof(long))
			{
				A_0.WriteValue((long)A_1);
				return;
			}
			if (type == typeof(ulong))
			{
				A_0.WriteValue(((ulong)A_1).ToString());
				return;
			}
			if (type == typeof(float))
			{
				A_0.WriteValue((float)A_1);
				return;
			}
			if (type == typeof(double))
			{
				A_0.WriteValue((double)A_1);
				return;
			}
			if (type == typeof(decimal))
			{
				A_0.WriteValue((decimal)A_1);
				return;
			}
			if (type == typeof(bool))
			{
				A_0.WriteValue((bool)A_1);
				return;
			}
			if (type == typeof(DateTime))
			{
				A_0.WriteValue((DateTime)A_1);
				return;
			}
			if (type == typeof(Guid))
			{
				A_0.WriteValue(((Guid)A_1).ToString());
				return;
			}
			if (ReflectionTools.DoesTypeImplement(type, typeof(Enum)))
			{
				Type underlyingType = Enum.GetUnderlyingType(type);
				A_0.WriteValue(Convert.ChangeType(A_1, underlyingType));
				return;
			}
			if (!ReflectionTools.IsDefined(type, typeof(SerializationTypeAttribute), true) || ReflectionTools.GetAttribute<SerializationTypeAttribute>(type, true).serializationType != SerializationTypeAttribute.SerializationType.Object)
			{
				if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
				{
					IList list = A_1 as IList;
					for (int i = 0; i < list.Count; i++)
					{
						SerializationTools.WriteXmlElement(A_0, (list[i] != null) ? list[i].GetType().Name : "value", list[i]);
					}
					return;
				}
				if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
				{
					IDictionary dictionary = A_1 as IDictionary;
					foreach (object obj in dictionary.Keys)
					{
						SerializationTools.WriteXmlElement(A_0, obj.ToString(), dictionary[obj]);
					}
					return;
				}
				if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
				{
					foreach (object obj2 in (A_1 as IEnumerable))
					{
						SerializationTools.WriteXmlElement(A_0, (obj2 != null) ? obj2.GetType().Name : "value", obj2);
					}
					return;
				}
			}
			ISerializationCallbackReceiver serializationCallbackReceiver = A_1 as ISerializationCallbackReceiver;
			if (serializationCallbackReceiver != null)
			{
				try
				{
					serializationCallbackReceiver.OnBeforeSerialize();
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString(), true);
				}
			}
			foreach (FieldInfo fieldInfo in ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic))
			{
				if (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), true) && !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), true) && (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), true) || fieldInfo.IsDefined(typeof(SerializeField), true)))
				{
					object value = fieldInfo.GetValue(A_1);
					if (value != null)
					{
						string name;
						if (!fieldInfo.IsDefined(typeof(SerializeAttribute), true) || string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
						{
							name = fieldInfo.Name;
						}
						SerializationTools.WriteXmlElement(A_0, name, value);
					}
				}
			}
			foreach (PropertyInfo propertyInfo in ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic))
			{
				if (propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), true) && propertyInfo.CanRead)
				{
					object value2 = propertyInfo.GetValue(A_1, null);
					if (value2 != null)
					{
						string name2;
						if (!propertyInfo.IsDefined(typeof(SerializeAttribute), true) || string.IsNullOrEmpty(name2 = (CollectionTools.GetValue<object>(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
						{
							name2 = propertyInfo.Name;
						}
						SerializationTools.WriteXmlElement(A_0, name2, value2);
					}
				}
			}
		}

		// Token: 0x06002F54 RID: 12116 RVA: 0x000A5120 File Offset: 0x000A3320
		public static string ReadXmlElement(XmlReader reader, string name)
		{
			string result = string.Empty;
			bool isEmptyElement = reader.IsEmptyElement;
			reader.ReadStartElement(name);
			if (!isEmptyElement)
			{
				result = reader.ReadContentAsString();
				reader.ReadEndElement();
			}
			return result;
		}

		// Token: 0x06002F55 RID: 12117 RVA: 0x000A5150 File Offset: 0x000A3350
		public static T ReadXmlElement<T>(XmlReader reader, string name)
		{
			string text = SerializationTools.ReadXmlElement(reader, name);
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int))
			{
				int num;
				if (int.TryParse(text, out num))
				{
					return (T)((object)num);
				}
			}
			else if (typeFromHandle == typeof(float))
			{
				float num2;
				if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num2))
				{
					return (T)((object)num2);
				}
			}
			else if (typeFromHandle == typeof(bool))
			{
				bool flag;
				if (bool.TryParse(text, out flag))
				{
					return (T)((object)flag);
				}
			}
			else
			{
				if (typeFromHandle == typeof(string))
				{
					return (T)((object)text);
				}
				if (typeFromHandle == typeof(short))
				{
					short num3;
					if (short.TryParse(text, out num3))
					{
						return (T)((object)num3);
					}
				}
				else if (typeFromHandle == typeof(byte))
				{
					byte b;
					if (byte.TryParse(text, out b))
					{
						return (T)((object)b);
					}
				}
				else if (typeFromHandle == typeof(ushort))
				{
					ushort num4;
					if (ushort.TryParse(text, out num4))
					{
						return (T)((object)num4);
					}
				}
				else if (typeFromHandle == typeof(uint))
				{
					uint num5;
					if (uint.TryParse(text, out num5))
					{
						return (T)((object)num5);
					}
				}
				else if (typeFromHandle == typeof(long))
				{
					long num6;
					if (long.TryParse(text, out num6))
					{
						return (T)((object)num6);
					}
				}
				else if (typeFromHandle == typeof(ulong))
				{
					ulong num7;
					if (ulong.TryParse(text, out num7))
					{
						return (T)((object)num7);
					}
				}
				else if (typeFromHandle == typeof(double))
				{
					double num8;
					if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num8))
					{
						return (T)((object)num8);
					}
				}
				else
				{
					if (typeFromHandle != typeof(decimal))
					{
						throw new NotImplementedException();
					}
					decimal num9;
					if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num9))
					{
						return (T)((object)num9);
					}
				}
			}
			return default(T);
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x000A5354 File Offset: 0x000A3554
		public static bool TryReadXmlElement(XmlReader reader, string name, out string outValue)
		{
			outValue = string.Empty;
			bool isEmptyElement = reader.IsEmptyElement;
			try
			{
				reader.ReadStartElement(name);
			}
			catch
			{
				return false;
			}
			if (!isEmptyElement)
			{
				outValue = reader.ReadContentAsString();
				reader.ReadEndElement();
			}
			return true;
		}

		// Token: 0x06002F57 RID: 12119 RVA: 0x000A53A4 File Offset: 0x000A35A4
		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue)
		{
			outValue = default(T);
			Type typeFromHandle = typeof(T);
			string text;
			if (!SerializationTools.TryReadXmlElement(reader, name, out text))
			{
				return false;
			}
			if (typeFromHandle == typeof(string))
			{
				outValue = (T)((object)text);
				return true;
			}
			if (typeFromHandle == typeof(byte))
			{
				byte b;
				if (byte.TryParse(text, out b))
				{
					outValue = (T)((object)b);
					return true;
				}
			}
			else if (typeFromHandle == typeof(sbyte))
			{
				sbyte b2;
				if (sbyte.TryParse(text, out b2))
				{
					outValue = (T)((object)b2);
					return true;
				}
			}
			else if (typeFromHandle == typeof(short))
			{
				short num;
				if (short.TryParse(text, out num))
				{
					outValue = (T)((object)num);
					return true;
				}
			}
			else if (typeFromHandle == typeof(ushort))
			{
				ushort num2;
				if (ushort.TryParse(text, out num2))
				{
					outValue = (T)((object)num2);
					return true;
				}
			}
			else if (typeFromHandle == typeof(int))
			{
				int num3;
				if (int.TryParse(text, out num3))
				{
					outValue = (T)((object)num3);
					return true;
				}
			}
			else if (typeFromHandle == typeof(uint))
			{
				uint num4;
				if (uint.TryParse(text, out num4))
				{
					outValue = (T)((object)num4);
					return true;
				}
			}
			else if (typeFromHandle == typeof(float))
			{
				float num5;
				if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num5))
				{
					outValue = (T)((object)num5);
					return true;
				}
			}
			else if (typeFromHandle == typeof(double))
			{
				double num6;
				if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num6))
				{
					outValue = (T)((object)num6);
					return true;
				}
			}
			else if (typeFromHandle == typeof(decimal))
			{
				decimal num7;
				if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num7))
				{
					outValue = (T)((object)num7);
					return true;
				}
			}
			else if (typeFromHandle == typeof(bool))
			{
				bool flag;
				if (bool.TryParse(text, out flag))
				{
					outValue = (T)((object)flag);
					return true;
				}
			}
			else
			{
				if (!ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Enum)))
				{
					throw new NotImplementedException();
				}
				if (Enum.GetUnderlyingType(typeFromHandle) != typeof(int))
				{
					throw new NotImplementedException("Only INT enums are currently supported!");
				}
				int num8;
				if (int.TryParse(text, out num8))
				{
					outValue = (T)((object)num8);
					return true;
				}
			}
			return true;
		}

		// Token: 0x06002F58 RID: 12120 RVA: 0x000242AF File Offset: 0x000224AF
		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue, T defaultValue)
		{
			if (!SerializationTools.TryReadXmlElement<T>(reader, name, out outValue))
			{
				outValue = defaultValue;
				return false;
			}
			return true;
		}

		// Token: 0x06002F59 RID: 12121 RVA: 0x000A5624 File Offset: 0x000A3824
		public static bool TryReadXmlStartElement(XmlReader reader, string name, out bool isEmpty)
		{
			isEmpty = reader.IsEmptyElement;
			try
			{
				reader.ReadStartElement(name);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F5A RID: 12122 RVA: 0x000A565C File Offset: 0x000A385C
		public static bool TryReadXmlEndElement(XmlReader reader)
		{
			bool result;
			try
			{
				reader.ReadEndElement();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002F5B RID: 12123 RVA: 0x000A568C File Offset: 0x000A388C
		public static string CleanInvalidXmlChars(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			string result;
			try
			{
				string pattern = "[^\\x09\\x0A\\x0D\\x20-\\xD7FF\\xE000-\\xFFFD\\x10000-x10FFFF]";
				result = Regex.Replace(text, pattern, "");
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
