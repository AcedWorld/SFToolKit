using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000135 RID: 309
	[UnitCategory("Time")]
	public abstract class WaitUnit : Unit
	{
		// Token: 0x170002DB RID: 731
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0000F645 File Offset: 0x0000D845
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x0000F64D File Offset: 0x0000D84D
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0000F656 File Offset: 0x0000D856
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0000F65E File Offset: 0x0000D85E
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x06000842 RID: 2114 RVA: 0x0000F668 File Offset: 0x0000D868
		protected override void Definition()
		{
			this.enter = base.ControlInputCoroutine("enter", new Func<Flow, IEnumerator>(this.Await));
			this.exit = base.ControlOutput("exit");
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x06000843 RID: 2115
		protected abstract IEnumerator Await(Flow flow);
	}
}
