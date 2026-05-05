using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003B1 RID: 945
	public class UxmlIntAttributeDescription : TypedUxmlAttributeDescription<int>
	{
		// Token: 0x06001F7A RID: 8058 RVA: 0x00077F67 File Offset: 0x00076167
		public UxmlIntAttributeDescription()
		{
			base.type = "int";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0;
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001F7B RID: 8059 RVA: 0x00077F94 File Offset: 0x00076194
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x00077FC0 File Offset: 0x000761C0
		public override int GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<int>(bag, cc, (string s, int i) => UxmlIntAttributeDescription.ConvertValueToInt(s, i), base.defaultValue);
		}

		// Token: 0x06001F7D RID: 8061 RVA: 0x00078000 File Offset: 0x00076200
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref int value)
		{
			return base.TryGetValueFromBag<int>(bag, cc, (string s, int i) => UxmlIntAttributeDescription.ConvertValueToInt(s, i), base.defaultValue, ref value);
		}

		// Token: 0x06001F7E RID: 8062 RVA: 0x00078040 File Offset: 0x00076240
		private static int ConvertValueToInt(string v, int defaultValue)
		{
			int num;
			bool flag = v == null || !int.TryParse(v, out num);
			int result;
			if (flag)
			{
				result = defaultValue;
			}
			else
			{
				result = num;
			}
			return result;
		}
	}
}
