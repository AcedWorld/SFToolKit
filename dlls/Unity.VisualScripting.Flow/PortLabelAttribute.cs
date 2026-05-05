using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000D RID: 13
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class PortLabelAttribute : Attribute
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000027FB File Offset: 0x000009FB
		public PortLabelAttribute(string label)
		{
			this.label = label;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000280A File Offset: 0x00000A0A
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002812 File Offset: 0x00000A12
		public string label { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000052 RID: 82 RVA: 0x0000281B File Offset: 0x00000A1B
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002823 File Offset: 0x00000A23
		public bool hidden { get; set; }
	}
}
