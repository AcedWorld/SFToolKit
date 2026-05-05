using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000043 RID: 67
	[TypeIcon(typeof(ISelectUnit))]
	public abstract class SelectUnit<T> : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000287 RID: 647 RVA: 0x000074FA File Offset: 0x000056FA
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00007502 File Offset: 0x00005702
		[DoNotSerialize]
		public List<KeyValuePair<T, ValueInput>> branches { get; private set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000289 RID: 649 RVA: 0x0000750B File Offset: 0x0000570B
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00007513 File Offset: 0x00005713
		[Inspectable]
		[Serialize]
		public List<T> options { get; set; } = new List<T>();

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000751C File Offset: 0x0000571C
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00007524 File Offset: 0x00005724
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput selector { get; private set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000752D File Offset: 0x0000572D
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00007535 File Offset: 0x00005735
		[DoNotSerialize]
		public ValueInput @default { get; private set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000753E File Offset: 0x0000573E
		// (set) Token: 0x06000290 RID: 656 RVA: 0x00007546 File Offset: 0x00005746
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput selection { get; private set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000754F File Offset: 0x0000574F
		public override bool canDefine
		{
			get
			{
				return this.options != null;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000755C File Offset: 0x0000575C
		protected override void Definition()
		{
			this.selection = base.ValueOutput<object>("selection", new Func<Flow, object>(this.Result)).Predictable();
			this.selector = base.ValueInput<T>("selector");
			base.Requirement(this.selector, this.selection);
			this.branches = new List<KeyValuePair<T, ValueInput>>();
			foreach (T t in this.options)
			{
				string str = "%";
				T t2 = t;
				string key = str + ((t2 != null) ? t2.ToString() : null);
				if (!base.valueInputs.Contains(key))
				{
					ValueInput valueInput = base.ValueInput<object>(key).AllowsNull();
					this.branches.Add(new KeyValuePair<T, ValueInput>(t, valueInput));
					base.Requirement(valueInput, this.selection);
				}
			}
			this.@default = base.ValueInput<object>("default");
			base.Requirement(this.@default, this.selection);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00007680 File Offset: 0x00005880
		protected virtual bool Matches(T a, T b)
		{
			return object.Equals(a, b);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00007694 File Offset: 0x00005894
		public object Result(Flow flow)
		{
			T value = flow.GetValue<T>(this.selector);
			foreach (KeyValuePair<T, ValueInput> keyValuePair in this.branches)
			{
				if (this.Matches(keyValuePair.Key, value))
				{
					return flow.GetValue(keyValuePair.Value);
				}
			}
			return flow.GetValue(this.@default);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000772F File Offset: 0x0000592F
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
