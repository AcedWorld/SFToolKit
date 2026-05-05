using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000048 RID: 72
	[TypeIcon(typeof(IBranchUnit))]
	public abstract class SwitchUnit<T> : Unit, IBranchUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00007A79 File Offset: 0x00005C79
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00007A81 File Offset: 0x00005C81
		[DoNotSerialize]
		public List<KeyValuePair<T, ControlOutput>> branches { get; private set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00007A8A File Offset: 0x00005C8A
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00007A92 File Offset: 0x00005C92
		[Inspectable]
		[Serialize]
		public List<T> options { get; set; } = new List<T>();

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00007A9B File Offset: 0x00005C9B
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00007AA3 File Offset: 0x00005CA3
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00007AAC File Offset: 0x00005CAC
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00007AB4 File Offset: 0x00005CB4
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput selector { get; private set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00007ABD File Offset: 0x00005CBD
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00007AC5 File Offset: 0x00005CC5
		[DoNotSerialize]
		public ControlOutput @default { get; private set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00007ACE File Offset: 0x00005CCE
		public override bool canDefine
		{
			get
			{
				return this.options != null;
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00007ADC File Offset: 0x00005CDC
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.selector = base.ValueInput<T>("selector");
			base.Requirement(this.selector, this.enter);
			this.branches = new List<KeyValuePair<T, ControlOutput>>();
			foreach (T t in this.options)
			{
				string str = "%";
				T t2 = t;
				string key = str + ((t2 != null) ? t2.ToString() : null);
				if (!base.controlOutputs.Contains(key))
				{
					ControlOutput controlOutput = base.ControlOutput(key);
					this.branches.Add(new KeyValuePair<T, ControlOutput>(t, controlOutput));
					base.Succession(this.enter, controlOutput);
				}
			}
			this.@default = base.ControlOutput("default");
			base.Succession(this.enter, this.@default);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00007BF4 File Offset: 0x00005DF4
		protected virtual bool Matches(T a, T b)
		{
			return object.Equals(a, b);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00007C08 File Offset: 0x00005E08
		public ControlOutput Enter(Flow flow)
		{
			T value = flow.GetValue<T>(this.selector);
			foreach (KeyValuePair<T, ControlOutput> keyValuePair in this.branches)
			{
				if (this.Matches(keyValuePair.Key, value))
				{
					return keyValuePair.Value;
				}
			}
			return this.@default;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00007C97 File Offset: 0x00005E97
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
