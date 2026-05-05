using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000C RID: 12
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class PortKeyAttribute : Attribute
	{
		// Token: 0x0600004D RID: 77 RVA: 0x000027D4 File Offset: 0x000009D4
		public PortKeyAttribute(string key)
		{
			Ensure.That("key").IsNotNull(key);
			this.key = key;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000027F3 File Offset: 0x000009F3
		public string key { get; }
	}
}
