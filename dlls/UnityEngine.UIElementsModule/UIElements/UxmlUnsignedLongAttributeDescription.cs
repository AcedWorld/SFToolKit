using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003B5 RID: 949
	public class UxmlUnsignedLongAttributeDescription : TypedUxmlAttributeDescription<ulong>
	{
		// Token: 0x06001F8C RID: 8076 RVA: 0x00078199 File Offset: 0x00076399
		public UxmlUnsignedLongAttributeDescription()
		{
			base.type = "unsignedLong";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0UL;
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001F8D RID: 8077 RVA: 0x000781C4 File Offset: 0x000763C4
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F8E RID: 8078 RVA: 0x000781F0 File Offset: 0x000763F0
		public override ulong GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<ulong>(bag, cc, (string s, ulong l) => UxmlUnsignedLongAttributeDescription.ConvertValueToUlong(s, l), base.defaultValue);
		}

		// Token: 0x06001F8F RID: 8079 RVA: 0x00078230 File Offset: 0x00076430
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref ulong value)
		{
			return base.TryGetValueFromBag<ulong>(bag, cc, (string s, ulong l) => UxmlUnsignedLongAttributeDescription.ConvertValueToUlong(s, l), base.defaultValue, ref value);
		}

		// Token: 0x06001F90 RID: 8080 RVA: 0x00078270 File Offset: 0x00076470
		private static ulong ConvertValueToUlong(string v, ulong defaultValue)
		{
			ulong num;
			bool flag = v == null || !ulong.TryParse(v, out num);
			ulong result;
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
