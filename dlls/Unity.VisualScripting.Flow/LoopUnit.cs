using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200003C RID: 60
	public abstract class LoopUnit : Unit
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00006EBC File Offset: 0x000050BC
		// (set) Token: 0x06000247 RID: 583 RVA: 0x00006EC4 File Offset: 0x000050C4
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00006ECD File Offset: 0x000050CD
		// (set) Token: 0x06000249 RID: 585 RVA: 0x00006ED5 File Offset: 0x000050D5
		[DoNotSerialize]
		public ControlOutput exit { get; private set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00006EDE File Offset: 0x000050DE
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00006EE6 File Offset: 0x000050E6
		[DoNotSerialize]
		public ControlOutput body { get; private set; }

		// Token: 0x0600024C RID: 588 RVA: 0x00006EF0 File Offset: 0x000050F0
		protected override void Definition()
		{
			this.enter = base.ControlInputCoroutine("enter", new Func<Flow, ControlOutput>(this.Loop), new Func<Flow, IEnumerator>(this.LoopCoroutine));
			this.exit = base.ControlOutput("exit");
			this.body = base.ControlOutput("body");
			base.Succession(this.enter, this.body);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600024D RID: 589
		protected abstract ControlOutput Loop(Flow flow);

		// Token: 0x0600024E RID: 590
		protected abstract IEnumerator LoopCoroutine(Flow flow);
	}
}
