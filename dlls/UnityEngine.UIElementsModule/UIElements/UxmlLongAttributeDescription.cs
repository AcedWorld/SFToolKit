using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020003B7 RID: 951
	public class UxmlLongAttributeDescription : TypedUxmlAttributeDescription<long>
	{
		// Token: 0x06001F95 RID: 8085 RVA: 0x000782B1 File Offset: 0x000764B1
		public UxmlLongAttributeDescription()
		{
			base.type = "long";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = 0L;
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001F96 RID: 8086 RVA: 0x000782DC File Offset: 0x000764DC
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		// Token: 0x06001F97 RID: 8087 RVA: 0x00078308 File Offset: 0x00076508
		public override long GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<long>(bag, cc, (string s, long l) => UxmlLongAttributeDescription.ConvertValueToLong(s, l), base.defaultValue);
		}

		// Token: 0x06001F98 RID: 8088 RVA: 0x00078348 File Offset: 0x00076548
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref long value)
		{
			return base.TryGetValueFromBag<long>(bag, cc, (string s, long l) => UxmlLongAttributeDescription.ConvertValueToLong(s, l), base.defaultValue, ref value);
		}

		// Token: 0x06001F99 RID: 8089 RVA: 0x00078388 File Offset: 0x00076588
		private static long ConvertValueToLong(string v, long defaultValue)
		{
			long num;
			bool flag = v == null || !long.TryParse(v, out num);
			long result;
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
