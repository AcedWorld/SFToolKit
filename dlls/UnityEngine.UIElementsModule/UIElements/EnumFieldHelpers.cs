using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000A8 RID: 168
	internal static class EnumFieldHelpers
	{
		// Token: 0x06000600 RID: 1536 RVA: 0x000169EC File Offset: 0x00014BEC
		internal static bool ExtractValue(IUxmlAttributes bag, CreationContext cc, out Type resEnumType, out Enum resEnumValue, out bool resIncludeObsoleteValues)
		{
			resIncludeObsoleteValues = false;
			resEnumValue = null;
			resEnumType = EnumFieldHelpers.type.GetValueFromBag(bag, cc);
			bool flag = resEnumType == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string text = null;
				object obj = null;
				bool flag2 = EnumFieldHelpers.value.TryGetValueFromBag(bag, cc, ref text) && !Enum.TryParse(resEnumType, text, false, out obj);
				if (flag2)
				{
					Debug.LogErrorFormat("EnumField: Could not parse value of '{0}', because it isn't defined in the {1} enum.", new object[]
					{
						text,
						resEnumType.FullName
					});
					result = false;
				}
				else
				{
					resEnumValue = ((text != null && obj != null) ? ((Enum)obj) : ((Enum)Enum.ToObject(resEnumType, 0)));
					resIncludeObsoleteValues = EnumFieldHelpers.includeObsoleteValues.GetValueFromBag(bag, cc);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0400028C RID: 652
		internal static readonly UxmlTypeAttributeDescription<Enum> type = new UxmlTypeAttributeDescription<Enum>
		{
			name = "type"
		};

		// Token: 0x0400028D RID: 653
		internal static readonly UxmlStringAttributeDescription value = new UxmlStringAttributeDescription
		{
			name = "value"
		};

		// Token: 0x0400028E RID: 654
		internal static readonly UxmlBoolAttributeDescription includeObsoleteValues = new UxmlBoolAttributeDescription
		{
			name = "include-obsolete-values",
			defaultValue = false
		};
	}
}
