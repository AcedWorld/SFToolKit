using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003BB RID: 955
	public class UxmlColorAttributeDescription : TypedUxmlAttributeDescription<Color>
	{
		// Token: 0x06001FA7 RID: 8103 RVA: 0x000784E0 File Offset: 0x000766E0
		public UxmlColorAttributeDescription()
		{
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = new Color(0f, 0f, 0f, 1f);
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06001FA8 RID: 8104 RVA: 0x00078530 File Offset: 0x00076730
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString();
			}
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x00078558 File Offset: 0x00076758
		public override Color GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<Color>(bag, cc, (string s, Color color) => UxmlColorAttributeDescription.ConvertValueToColor(s, color), base.defaultValue);
		}

		// Token: 0x06001FAA RID: 8106 RVA: 0x00078598 File Offset: 0x00076798
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref Color value)
		{
			return base.TryGetValueFromBag<Color>(bag, cc, (string s, Color color) => UxmlColorAttributeDescription.ConvertValueToColor(s, color), base.defaultValue, ref value);
		}

		// Token: 0x06001FAB RID: 8107 RVA: 0x000785D8 File Offset: 0x000767D8
		private static Color ConvertValueToColor(string v, Color defaultValue)
		{
			Color color;
			bool flag = v == null || !ColorUtility.TryParseHtmlString(v, out color);
			Color result;
			if (flag)
			{
				result = defaultValue;
			}
			else
			{
				result = color;
			}
			return result;
		}
	}
}
