using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils.Libraries.TinyJson
{
	// Token: 0x020004BC RID: 1212
	public static class JsonWriter
	{
		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x060030EF RID: 12527 RVA: 0x00025651 File Offset: 0x00023851
		private static Action<StringBuilder, object> vZEJUCenvFXIBRJuPpqLYCgkJvlg
		{
			get
			{
				Action<StringBuilder, object> result;
				if ((result = JsonWriter.aRQgbSGZVCVJaFBKLgMaTGNnEJmcb) == null)
				{
					result = (JsonWriter.aRQgbSGZVCVJaFBKLgMaTGNnEJmcb = new Action<StringBuilder, object>(JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv));
				}
				return result;
			}
		}

		// Token: 0x060030F0 RID: 12528 RVA: 0x0002566E File Offset: 0x0002386E
		public static string ToJson(object item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(stringBuilder, item);
			return stringBuilder.ToString();
		}

		// Token: 0x060030F1 RID: 12529 RVA: 0x000AB06C File Offset: 0x000A926C
		private static void BCTpyDrDioFUNSbnbrUYblBMmuCv(StringBuilder A_0, object A_1)
		{
			if (A_1 == null)
			{
				A_0.Append("null");
				return;
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
			Type type = A_1.GetType();
			if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToJson)))
			{
				((IExportToJson)A_1).WriteJson(A_0, JsonWriter.vZEJUCenvFXIBRJuPpqLYCgkJvlg);
				return;
			}
			if (type == typeof(string))
			{
				A_0.Append('"');
				JsonWriter.RwEPofcTiedOuDZSRZQutHIZhIHJ(A_0, (string)A_1);
				A_0.Append('"');
				return;
			}
			if (type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong) || type == typeof(short) || type == typeof(ushort) || type == typeof(byte) || type == typeof(sbyte))
			{
				A_0.Append(A_1.ToString());
				return;
			}
			if (type == typeof(float))
			{
				A_0.Append(((float)A_1).ToString(CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(double))
			{
				A_0.Append(((double)A_1).ToString(CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(decimal))
			{
				A_0.Append(((decimal)A_1).ToString(CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(bool))
			{
				A_0.Append(((bool)A_1) ? "true" : "false");
				return;
			}
			if (type == typeof(Guid))
			{
				JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, A_1.ToString());
				return;
			}
			if (ReflectionTools.IsEnum(type))
			{
				Type underlyingType = Enum.GetUnderlyingType(type);
				JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, Convert.ChangeType(A_1, underlyingType));
				return;
			}
			if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
			{
				A_0.Append('[');
				bool flag = true;
				IList list = A_1 as IList;
				for (int i = 0; i < list.Count; i++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						A_0.Append(',');
					}
					JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, list[i]);
				}
				A_0.Append(']');
				return;
			}
			if (ReflectionTools.IsGenericType(type) && ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
			{
				Type type2 = ReflectionTools.GetGenericArguments(type)[0];
				bool flag2 = false;
				Type conversionType = null;
				if (ReflectionTools.IsEnum(type2))
				{
					flag2 = true;
					conversionType = ReflectionTools.GetUnderlyingEnumType(type2);
				}
				A_0.Append('{');
				IDictionary dictionary = A_1 as IDictionary;
				bool flag3 = true;
				foreach (object obj in dictionary.Keys)
				{
					if (flag3)
					{
						flag3 = false;
					}
					else
					{
						A_0.Append(',');
					}
					A_0.Append('"');
					A_0.Append(flag2 ? Convert.ChangeType(obj, conversionType).ToString() : obj.ToString());
					A_0.Append("\":");
					JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, dictionary[obj]);
				}
				A_0.Append('}');
				return;
			}
			A_0.Append('{');
			bool flag4 = true;
			foreach (FieldInfo fieldInfo in ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic))
			{
				if (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), true) && !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), true) && (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), true) || fieldInfo.IsDefined(typeof(SerializeField), true)))
				{
					object value = fieldInfo.GetValue(A_1);
					if (value != null)
					{
						if (flag4)
						{
							flag4 = false;
						}
						else
						{
							A_0.Append(',');
						}
						A_0.Append('"');
						string name;
						if (!fieldInfo.IsDefined(typeof(SerializeAttribute), true) || string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
						{
							name = fieldInfo.Name;
						}
						A_0.Append(name);
						A_0.Append("\":");
						JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, value);
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
						if (flag4)
						{
							flag4 = false;
						}
						else
						{
							A_0.Append(',');
						}
						A_0.Append('"');
						string name2;
						if (!propertyInfo.IsDefined(typeof(SerializeAttribute), true) || string.IsNullOrEmpty(name2 = (CollectionTools.GetValue<object>(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
						{
							name2 = propertyInfo.Name;
						}
						A_0.Append(name2);
						A_0.Append("\":");
						JsonWriter.BCTpyDrDioFUNSbnbrUYblBMmuCv(A_0, value2);
					}
				}
			}
			A_0.Append('}');
		}

		// Token: 0x060030F2 RID: 12530 RVA: 0x000AB660 File Offset: 0x000A9860
		private static void RwEPofcTiedOuDZSRZQutHIZhIHJ(StringBuilder A_0, string A_1)
		{
			if (string.IsNullOrEmpty(A_1))
			{
				return;
			}
			int length = A_1.Length;
			for (int i = 0; i < length; i++)
			{
				if (A_1[i] == '"' && (i == 0 || A_1[i - 1] != '\\'))
				{
					A_0.Append('\\');
				}
				A_0.Append(A_1[i]);
			}
		}

		// Token: 0x04001AD0 RID: 6864
		private static Action<StringBuilder, object> aRQgbSGZVCVJaFBKLgMaTGNnEJmcb;
	}
}
