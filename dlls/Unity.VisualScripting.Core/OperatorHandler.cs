using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000F0 RID: 240
	public abstract class OperatorHandler
	{
		// Token: 0x06000647 RID: 1607 RVA: 0x0001C314 File Offset: 0x0001A514
		protected OperatorHandler(string name, string verb, string symbol, string customMethodName)
		{
			Ensure.That("name").IsNotNull(name);
			Ensure.That("verb").IsNotNull(verb);
			Ensure.That("symbol").IsNotNull(symbol);
			this.name = name;
			this.verb = verb;
			this.symbol = symbol;
			this.customMethodName = customMethodName;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0001C374 File Offset: 0x0001A574
		public string name { get; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x0001C37C File Offset: 0x0001A57C
		public string verb { get; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0001C384 File Offset: 0x0001A584
		public string symbol { get; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x0001C38C File Offset: 0x0001A58C
		public string customMethodName { get; }
	}
}
