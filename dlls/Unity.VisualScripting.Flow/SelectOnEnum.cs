using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200003E RID: 62
	[UnitCategory("Control")]
	[UnitTitle("Select On Enum")]
	[UnitShortTitle("Select")]
	[UnitSubtitle("On Enum")]
	[UnitOrder(7)]
	[TypeIcon(typeof(ISelectUnit))]
	public sealed class SelectOnEnum : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600025D RID: 605 RVA: 0x000070A3 File Offset: 0x000052A3
		// (set) Token: 0x0600025E RID: 606 RVA: 0x000070AB File Offset: 0x000052AB
		[DoNotSerialize]
		public Dictionary<object, ValueInput> branches { get; private set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600025F RID: 607 RVA: 0x000070B4 File Offset: 0x000052B4
		// (set) Token: 0x06000260 RID: 608 RVA: 0x000070BC File Offset: 0x000052BC
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput selector { get; private set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000261 RID: 609 RVA: 0x000070C5 File Offset: 0x000052C5
		// (set) Token: 0x06000262 RID: 610 RVA: 0x000070CD File Offset: 0x000052CD
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput selection { get; private set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000263 RID: 611 RVA: 0x000070D6 File Offset: 0x000052D6
		// (set) Token: 0x06000264 RID: 612 RVA: 0x000070DE File Offset: 0x000052DE
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[TypeFilter(new Type[]
		{

		}, Enums = true, Classes = false, Interfaces = false, Structs = false, Primitives = false)]
		public Type enumType { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000265 RID: 613 RVA: 0x000070E7 File Offset: 0x000052E7
		public override bool canDefine
		{
			get
			{
				return this.enumType != null && this.enumType.IsEnum;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00007104 File Offset: 0x00005304
		protected override void Definition()
		{
			this.branches = new Dictionary<object, ValueInput>();
			this.selection = base.ValueOutput<object>("selection", new Func<Flow, object>(this.Branch)).Predictable();
			this.selector = base.ValueInput(this.enumType, "selector");
			base.Requirement(this.selector, this.selection);
			foreach (KeyValuePair<string, Enum> keyValuePair in EnumUtility.ValuesByNames(this.enumType, false))
			{
				Enum value = keyValuePair.Value;
				if (!this.branches.ContainsKey(value))
				{
					ValueInput valueInput = base.ValueInput<object>("%" + keyValuePair.Key).AllowsNull();
					this.branches.Add(value, valueInput);
					base.Requirement(valueInput, this.selection);
				}
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000071FC File Offset: 0x000053FC
		public object Branch(Flow flow)
		{
			object value = flow.GetValue(this.selector, this.enumType);
			return flow.GetValue(this.branches[value]);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00007236 File Offset: 0x00005436
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
