using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003BD RID: 957
	public class UxmlTypeAttributeDescription<TBase> : TypedUxmlAttributeDescription<Type>
	{
		// Token: 0x06001FB0 RID: 8112 RVA: 0x00078619 File Offset: 0x00076819
		public UxmlTypeAttributeDescription()
		{
			base.type = "string";
			base.typeNamespace = "http://www.w3.org/2001/XMLSchema";
			base.defaultValue = null;
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06001FB1 RID: 8113 RVA: 0x00078644 File Offset: 0x00076844
		public override string defaultValueAsString
		{
			get
			{
				return (base.defaultValue == null) ? "null" : base.defaultValue.FullName;
			}
		}

		// Token: 0x06001FB2 RID: 8114 RVA: 0x00078678 File Offset: 0x00076878
		public override Type GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			return base.GetValueFromBag<Type>(bag, cc, (string s, Type type1) => this.ConvertValueToType(s, type1), base.defaultValue);
		}

		// Token: 0x06001FB3 RID: 8115 RVA: 0x000786A4 File Offset: 0x000768A4
		public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref Type value)
		{
			return base.TryGetValueFromBag<Type>(bag, cc, (string s, Type type1) => this.ConvertValueToType(s, type1), base.defaultValue, ref value);
		}

		// Token: 0x06001FB4 RID: 8116 RVA: 0x000786D4 File Offset: 0x000768D4
		private Type ConvertValueToType(string v, Type defaultValue)
		{
			bool flag = string.IsNullOrEmpty(v);
			Type result;
			if (flag)
			{
				result = defaultValue;
			}
			else
			{
				try
				{
					Type type = Type.GetType(v, true);
					bool flag2 = !typeof(TBase).IsAssignableFrom(type);
					if (!flag2)
					{
						return type;
					}
					Debug.LogError(string.Concat(new string[]
					{
						"Type: Invalid type \"",
						v,
						"\". Type must derive from ",
						typeof(TBase).FullName,
						"."
					}));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				result = defaultValue;
			}
			return result;
		}
	}
}
