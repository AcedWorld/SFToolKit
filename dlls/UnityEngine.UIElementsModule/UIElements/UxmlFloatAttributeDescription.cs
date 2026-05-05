using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003AD RID: 941
	public class UxmlFloatAttributeDescription : TypedUxmlAttributeDescription<float>
	{
		// Token: 0x06001F68 RID: 8040 RVA: 0x00077D14 File Offset: 0x00075F14
		public UxmlFloatAttributeDescription()
		{
			base.type = "float";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0f;
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06001F69 RID: 8041 RVA: 0x00077D44 File Offset: 0x00075F44
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x00077D70 File Offset: 0x00075F70
		public override float GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<float>(bag, cc, (string s, float f) => UxmlFloatAttributeDescription.ConvertValueToFloat(s, f), base.defaultValue);
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x00077DB0 File Offset: 0x00075FB0
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref float value)
		{
			return base.TryGetValueFromBag<float>(bag, cc, (string s, float f) => UxmlFloatAttributeDescription.ConvertValueToFloat(s, f), base.defaultValue, ref value);
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x00077DF0 File Offset: 0x00075FF0
		private static float ConvertValueToFloat(string v, float defaultValue)
		{
			float num;
			bool flag = v == null || !float.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out num);
			float result;
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
