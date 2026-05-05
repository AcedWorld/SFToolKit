using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003B3 RID: 947
	public class UxmlUnsignedIntAttributeDescription : TypedUxmlAttributeDescription<uint>
	{
		// Token: 0x06001F83 RID: 8067 RVA: 0x00078081 File Offset: 0x00076281
		public UxmlUnsignedIntAttributeDescription()
		{
			base.type = "unsignedInt";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0U;
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001F84 RID: 8068 RVA: 0x000780AC File Offset: 0x000762AC
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F85 RID: 8069 RVA: 0x000780D8 File Offset: 0x000762D8
		public override uint GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<uint>(bag, cc, (string s, uint i) => UxmlUnsignedIntAttributeDescription.ConvertValueToUInt(s, i), base.defaultValue);
		}

		// Token: 0x06001F86 RID: 8070 RVA: 0x00078118 File Offset: 0x00076318
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref uint value)
		{
			return base.TryGetValueFromBag<uint>(bag, cc, (string s, uint i) => UxmlUnsignedIntAttributeDescription.ConvertValueToUInt(s, i), base.defaultValue, ref value);
		}

		// Token: 0x06001F87 RID: 8071 RVA: 0x00078158 File Offset: 0x00076358
		private static uint ConvertValueToUInt(string v, uint defaultValue)
		{
			uint num;
			bool flag = v == null || !uint.TryParse(v, out num);
			uint result;
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
