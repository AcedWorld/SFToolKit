using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003B9 RID: 953
	public class UxmlBoolAttributeDescription : TypedUxmlAttributeDescription<bool>
	{
		// Token: 0x06001F9E RID: 8094 RVA: 0x000783C9 File Offset: 0x000765C9
		public UxmlBoolAttributeDescription()
		{
			base.type = "boolean";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = false;
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x000783F4 File Offset: 0x000765F4
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString().ToLowerInvariant();
			}
		}

		// Token: 0x06001FA0 RID: 8096 RVA: 0x0007841C File Offset: 0x0007661C
		public override bool GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<bool>(bag, cc, (string s, bool b) => UxmlBoolAttributeDescription.ConvertValueToBool(s, b), base.defaultValue);
		}

		// Token: 0x06001FA1 RID: 8097 RVA: 0x0007845C File Offset: 0x0007665C
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref bool value)
		{
			return base.TryGetValueFromBag<bool>(bag, cc, (string s, bool b) => UxmlBoolAttributeDescription.ConvertValueToBool(s, b), base.defaultValue, ref value);
		}

		// Token: 0x06001FA2 RID: 8098 RVA: 0x0007849C File Offset: 0x0007669C
		private static bool ConvertValueToBool(string v, bool defaultValue)
		{
			bool flag2;
			bool flag = v == null || !bool.TryParse(v, out flag2);
			bool result;
			if (flag)
			{
				result = defaultValue;
			}
			else
			{
				result = flag2;
			}
			return result;
		}
	}
}
