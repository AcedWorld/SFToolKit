using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000011 RID: 17
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class UnitHeaderInspectableAttribute : Attribute
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00002896 File Offset: 0x00000A96
		public UnitHeaderInspectableAttribute()
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000289E File Offset: 0x00000A9E
		public UnitHeaderInspectableAttribute(string label)
		{
			this.label = label;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000028AD File Offset: 0x00000AAD
		public string label { get; }
	}
}
