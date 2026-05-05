using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003AF RID: 943
	public class UxmlDoubleAttributeDescription : TypedUxmlAttributeDescription<double>
	{
		// Token: 0x06001F71 RID: 8049 RVA: 0x00077E3B File Offset: 0x0007603B
		public UxmlDoubleAttributeDescription()
		{
			base.type = "double";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0.0;
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06001F72 RID: 8050 RVA: 0x00077E70 File Offset: 0x00076070
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x00077E9C File Offset: 0x0007609C
		public override double GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<double>(bag, cc, (string s, double d) => UxmlDoubleAttributeDescription.ConvertValueToDouble(s, d), base.defaultValue);
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x00077EDC File Offset: 0x000760DC
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref double value)
		{
			return base.TryGetValueFromBag<double>(bag, cc, (string s, double d) => UxmlDoubleAttributeDescription.ConvertValueToDouble(s, d), base.defaultValue, ref value);
		}

		// Token: 0x06001F75 RID: 8053 RVA: 0x00077F1C File Offset: 0x0007611C
		private static double ConvertValueToDouble(string v, double defaultValue)
		{
			double num;
			bool flag = v == null || !double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out num);
			double result;
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
