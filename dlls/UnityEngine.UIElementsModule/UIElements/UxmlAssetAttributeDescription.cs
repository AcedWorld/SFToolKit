using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003A6 RID: 934
	internal class UxmlAssetAttributeDescription<T> : TypedUxmlAttributeDescription<T> where T : Object
	{
		// Token: 0x06001F44 RID: 8004 RVA: 0x00077798 File Offset: 0x00075998
		public UxmlAssetAttributeDescription()
		{
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = default(T);
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001F45 RID: 8005 RVA: 0x000777D5 File Offset: 0x000759D5
		public override string defaultValueAsString
		{
			get
			{
				T t = base.defaultValue;
				return ((t != null) ? t.ToString() : null) ?? "null";
			}
		}

		// Token: 0x06001F46 RID: 8006 RVA: 0x000777F8 File Offset: 0x000759F8
		public override T GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			string path = null;
			bool flag = base.TryGetValueFromBag<string>(bag, cc, (string s, string t) => s, null, ref path);
			T result;
			if (flag)
			{
				VisualTreeAsset visualTreeAsset = cc.visualTreeAsset;
				result = ((visualTreeAsset != null) ? visualTreeAsset.GetAsset<T>(path) : default(T));
			}
			else
			{
				result = default(T);
			}
			return result;
		}
	}
}
