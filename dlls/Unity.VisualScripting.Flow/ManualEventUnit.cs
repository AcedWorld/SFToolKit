using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000090 RID: 144
	public abstract class ManualEventUnit<TArgs> : EventUnit<TArgs>
	{
		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x00009811 File Offset: 0x00007A11
		protected sealed override bool register
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000447 RID: 1095
		protected abstract string hookName { get; }

		// Token: 0x06000448 RID: 1096 RVA: 0x00009814 File Offset: 0x00007A14
		public sealed override EventHook GetHook(GraphReference reference)
		{
			return this.hookName;
		}
	}
}
