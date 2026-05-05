using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200005E RID: 94
	public abstract class GlobalEventUnit<TArgs> : EventUnit<TArgs>
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00008ED9 File Offset: 0x000070D9
		protected override bool register
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00008EDC File Offset: 0x000070DC
		protected virtual string hookName
		{
			get
			{
				throw new InvalidImplementationException();
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00008EE3 File Offset: 0x000070E3
		public override EventHook GetHook(GraphReference reference)
		{
			return this.hookName;
		}
	}
}
