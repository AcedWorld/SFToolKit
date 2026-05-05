using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003C0 RID: 960
	public class UxmlHash128AttributeDescription : TypedUxmlAttributeDescription<Hash128>
	{
		// Token: 0x06001FC2 RID: 8130 RVA: 0x00078A50 File Offset: 0x00076C50
		public UxmlHash128AttributeDescription()
		{
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = default(Hash128);
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x00078A90 File Offset: 0x00076C90
		public override string defaultValueAsString
		{
			get
			{
				return base.defaultValue.ToString();
			}
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x00078AB8 File Offset: 0x00076CB8
		public override Hash128 GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<Hash128>(bag, cc, (string s, Hash128 i) => Hash128.Parse(s), base.defaultValue);
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x00078AF8 File Offset: 0x00076CF8
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref Hash128 value)
		{
			return base.TryGetValueFromBag<Hash128>(bag, cc, (string s, Hash128 i) => Hash128.Parse(s), base.defaultValue, ref value);
		}
	}
}
