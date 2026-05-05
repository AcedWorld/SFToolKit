using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003AB RID: 939
	public class UxmlStringAttributeDescription : TypedUxmlAttributeDescription<string>
	{
		// Token: 0x06001F60 RID: 8032 RVA: 0x00077C3F File Offset: 0x00075E3F
		public UxmlStringAttributeDescription()
		{
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = "";
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001F61 RID: 8033 RVA: 0x00077C70 File Offset: 0x00075E70
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue;
			}
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x00077C88 File Offset: 0x00075E88
		public override string GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<string>(bag, cc, (string s, string t) => s, base.defaultValue);
		}

		// Token: 0x06001F63 RID: 8035 RVA: 0x00077CC8 File Offset: 0x00075EC8
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref string value)
		{
			return base.TryGetValueFromBag<string>(bag, cc, (string s, string t) => s, base.defaultValue, ref value);
		}
	}
}
