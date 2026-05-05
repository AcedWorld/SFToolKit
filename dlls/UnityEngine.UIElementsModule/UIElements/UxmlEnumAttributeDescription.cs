using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003BE RID: 958
	public class UxmlEnumAttributeDescription<T> : TypedUxmlAttributeDescription<T> where T : struct, IConvertible
	{
		// Token: 0x06001FB7 RID: 8119 RVA: 0x00078788 File Offset: 0x00076988
		public UxmlEnumAttributeDescription()
		{
			bool flag = !typeof(T).IsEnum;
			if (flag)
			{
				throw new ArgumentException("T must be an enumerated type");
			}
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = Activator.CreateInstance<T>();
			UxmlEnumeration uxmlEnumeration = new UxmlEnumeration();
			List<string> list = new List<string>();
			foreach (object obj in Enum.GetValues(typeof(T)))
			{
				T t = (T)((object)obj);
				list.Add(t.ToString(CultureInfo.InvariantCulture));
			}
			uxmlEnumeration.values = list;
			base.restriction = uxmlEnumeration;
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06001FB8 RID: 8120 RVA: 0x00078870 File Offset: 0x00076A70
		public override string defaultValueAsString
		{
			get
			{
				T defaultValue = base.defaultValue;
				return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x000788A0 File Offset: 0x00076AA0
		public override T GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<T>(bag, cc, (string s, T convertible) => UxmlEnumAttributeDescription<T>.ConvertValueToEnum<T>(s, convertible), base.defaultValue);
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x000788E0 File Offset: 0x00076AE0
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref T value)
		{
			return base.TryGetValueFromBag<T>(bag, cc, (string s, T convertible) => UxmlEnumAttributeDescription<T>.ConvertValueToEnum<T>(s, convertible), base.defaultValue, ref value);
		}

		// Token: 0x06001FBB RID: 8123 RVA: 0x00078920 File Offset: 0x00076B20
		private static U ConvertValueToEnum<U>(string v, U defaultValue) where U : struct
		{
			try
			{
				bool flag = string.IsNullOrEmpty(v);
				if (flag)
				{
					return defaultValue;
				}
				return (U)((object)Enum.Parse(typeof(U), v, true));
			}
			catch (ArgumentException)
			{
				Debug.LogError(UxmlEnumAttributeDescription<T>.GetEnumNameErrorMessage(v, typeof(U)));
			}
			catch (OverflowException)
			{
				Debug.LogError(UxmlEnumAttributeDescription<T>.GetEnumRangeErrorMessage(v, typeof(U)));
			}
			return defaultValue;
		}

		// Token: 0x06001FBC RID: 8124 RVA: 0x000789B0 File Offset: 0x00076BB0
		private static string GetEnumNameErrorMessage(string v, Type enumType)
		{
			return string.Concat(new string[]
			{
				"The ",
				enumType.Name,
				" enum does not contain the value `",
				v,
				"`. Value must be in range [",
				string.Join(" | ", Enum.GetNames(enumType)),
				"]."
			});
		}

		// Token: 0x06001FBD RID: 8125 RVA: 0x00078A10 File Offset: 0x00076C10
		private static string GetEnumRangeErrorMessage(string v, Type enumType)
		{
			return v + " is outside of the range of possible values for the " + enumType.Name + " enum.";
		}
	}
}
