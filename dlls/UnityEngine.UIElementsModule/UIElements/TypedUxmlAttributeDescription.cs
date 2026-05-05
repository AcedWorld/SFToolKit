using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003AA RID: 938
	public abstract class TypedUxmlAttributeDescription<T> : UxmlAttributeDescription
	{
		// Token: 0x06001F5B RID: 8027
		public abstract T GetValueFromBag(IUxmlAttributes bag, CreationContext cc);

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001F5C RID: 8028 RVA: 0x00077BFF File Offset: 0x00075DFF
		// (set) Token: 0x06001F5D RID: 8029 RVA: 0x00077C07 File Offset: 0x00075E07
		public T defaultValue { get; set; }

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001F5E RID: 8030 RVA: 0x00077C10 File Offset: 0x00075E10
		public override string defaultValueAsString
		{
			get
			{
				T defaultValue = this.defaultValue;
				return defaultValue.ToString();
			}
		}
	}
}
