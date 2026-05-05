using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200003F RID: 63
	[UnitCategory("Control")]
	[UnitTitle("Select On Flow")]
	[UnitShortTitle("Select")]
	[UnitSubtitle("On Flow")]
	[UnitOrder(8)]
	[TypeIcon(typeof(ISelectUnit))]
	public sealed class SelectOnFlow : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000723E File Offset: 0x0000543E
		// (set) Token: 0x0600026B RID: 619 RVA: 0x00007246 File Offset: 0x00005446
		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable("Branches")]
		public int branchCount
		{
			get
			{
				return this._branchCount;
			}
			set
			{
				this._branchCount = Mathf.Clamp(value, 2, 10);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00007257 File Offset: 0x00005457
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000725F File Offset: 0x0000545F
		[DoNotSerialize]
		public Dictionary<ControlInput, ValueInput> branches { get; private set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00007268 File Offset: 0x00005468
		// (set) Token: 0x0600026F RID: 623 RVA: 0x00007270 File Offset: 0x00005470
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00007279 File Offset: 0x00005479
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00007281 File Offset: 0x00005481
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput selection { get; private set; }

		// Token: 0x06000272 RID: 626 RVA: 0x0000728C File Offset: 0x0000548C
		protected override void Definition()
		{
			this.branches = new Dictionary<ControlInput, ValueInput>();
			this.selection = base.ValueOutput<object>("selection");
			this.exit = base.ControlOutput("exit");
			for (int i = 0; i < this.branchCount; i++)
			{
				ValueInput branchValue = base.ValueInput<object>("value_" + i.ToString());
				ControlInput controlInput = base.ControlInput("enter_" + i.ToString(), (Flow flow) => this.Select(flow, branchValue));
				base.Requirement(branchValue, controlInput);
				base.Assignment(controlInput, this.selection);
				base.Succession(controlInput, this.exit);
				this.branches.Add(controlInput, branchValue);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00007364 File Offset: 0x00005564
		public ControlOutput Select(Flow flow, ValueInput branchValue)
		{
			flow.SetValue(this.selection, flow.GetValue(branchValue));
			return this.exit;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000738E File Offset: 0x0000558E
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}

		// Token: 0x040000B7 RID: 183
		[SerializeAs("branchCount")]
		private int _branchCount = 2;
	}
}
