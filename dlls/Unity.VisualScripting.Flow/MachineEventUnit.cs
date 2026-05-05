using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008F RID: 143
	public abstract class MachineEventUnit<TArgs> : EventUnit<TArgs>
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000097E0 File Offset: 0x000079E0
		protected sealed override bool register
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000097E3 File Offset: 0x000079E3
		public override EventHook GetHook(GraphReference reference)
		{
			return new EventHook(this.hookName, reference.machine, null);
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x000097F7 File Offset: 0x000079F7
		protected virtual string hookName
		{
			get
			{
				throw new InvalidImplementationException(string.Format("Missing event hook for '{0}'.", this));
			}
		}
	}
}
