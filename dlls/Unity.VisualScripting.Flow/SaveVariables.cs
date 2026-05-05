using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000154 RID: 340
	[UnitCategory("Variables")]
	public sealed class SaveVariables : Unit
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x000101DB File Offset: 0x0000E3DB
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x000101E3 File Offset: 0x0000E3E3
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x000101EC File Offset: 0x0000E3EC
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x000101F4 File Offset: 0x0000E3F4
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060008CB RID: 2251 RVA: 0x00010200 File Offset: 0x0000E400
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.exit = base.ControlOutput("exit");
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0001024D File Offset: 0x0000E44D
		private ControlOutput Enter(Flow arg)
		{
			SavedVariables.SaveDeclarations(SavedVariables.merged);
			return this.exit;
		}
	}
}
