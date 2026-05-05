using System;

namespace UnityEngine.Internal
{
	// Token: 0x020003DC RID: 988
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.GenericParameter)]
	[Serializable]
	public class DefaultValueAttribute : Attribute
	{
		// Token: 0x06002148 RID: 8520 RVA: 0x000375A8 File Offset: 0x000357A8
		public DefaultValueAttribute(string value)
		{
			this.DefaultValue = value;
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06002149 RID: 8521 RVA: 0x000375BC File Offset: 0x000357BC
		public object Value
		{
			get
			{
				return this.DefaultValue;
			}
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x000375D4 File Offset: 0x000357D4
		public override bool Equals(object obj)
		{
			DefaultValueAttribute defaultValueAttribute = obj as DefaultValueAttribute;
			bool flag = defaultValueAttribute == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.DefaultValue == null;
				if (flag2)
				{
					result = (defaultValueAttribute.Value == null);
				}
				else
				{
					result = this.DefaultValue.Equals(defaultValueAttribute.Value);
				}
			}
			return result;
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x00037624 File Offset: 0x00035824
		public override int GetHashCode()
		{
			bool flag = this.DefaultValue == null;
			int hashCode;
			if (flag)
			{
				hashCode = base.GetHashCode();
			}
			else
			{
				hashCode = this.DefaultValue.GetHashCode();
			}
			return hashCode;
		}

		// Token: 0x04000B08 RID: 2824
		private object DefaultValue;
	}
}
