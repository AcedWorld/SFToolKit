using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003D RID: 61
	[UnitCategory("Control")]
	[UnitOrder(14)]
	public sealed class Once : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00006F76 File Offset: 0x00005176
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00006F7E File Offset: 0x0000517E
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00006F87 File Offset: 0x00005187
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00006F8F File Offset: 0x0000518F
		[DoNotSerialize]
		public ControlInput reset { get; private set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00006F98 File Offset: 0x00005198
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00006FA0 File Offset: 0x000051A0
		[DoNotSerialize]
		public ControlOutput once { get; private set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00006FA9 File Offset: 0x000051A9
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00006FB1 File Offset: 0x000051B1
		[DoNotSerialize]
		public ControlOutput after { get; private set; }

		// Token: 0x06000258 RID: 600 RVA: 0x00006FBC File Offset: 0x000051BC
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.reset = base.ControlInput("reset", new Func<Flow, ControlOutput>(this.Reset));
			this.once = base.ControlOutput("once");
			this.after = base.ControlOutput("after");
			base.Succession(this.enter, this.once);
			base.Succession(this.enter, this.after);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00007049 File Offset: 0x00005249
		public IGraphElementData CreateData()
		{
			return new Once.Data();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00007050 File Offset: 0x00005250
		public ControlOutput Enter(Flow flow)
		{
			Once.Data elementData = flow.stack.GetElementData<Once.Data>(this);
			if (!elementData.executed)
			{
				elementData.executed = true;
				return this.once;
			}
			return this.after;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00007086 File Offset: 0x00005286
		public ControlOutput Reset(Flow flow)
		{
			flow.stack.GetElementData<Once.Data>(this).executed = false;
			return null;
		}

		// Token: 0x020001AA RID: 426
		public sealed class Data : IGraphElementData
		{
			// Token: 0x0400038B RID: 907
			public bool executed;
		}
	}
}
