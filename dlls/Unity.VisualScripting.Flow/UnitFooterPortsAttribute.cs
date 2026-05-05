using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000010 RID: 16
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitFooterPortsAttribute : Attribute
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000283C File Offset: 0x00000A3C
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002844 File Offset: 0x00000A44
		public bool ControlInputs { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000284D File Offset: 0x00000A4D
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002855 File Offset: 0x00000A55
		public bool ControlOutputs { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000285E File Offset: 0x00000A5E
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002866 File Offset: 0x00000A66
		public bool ValueInputs { get; set; } = true;

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000286F File Offset: 0x00000A6F
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002877 File Offset: 0x00000A77
		public bool ValueOutputs { get; set; } = true;
	}
}
