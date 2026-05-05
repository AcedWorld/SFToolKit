using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000D7 RID: 215
	[UnitOrder(502)]
	public abstract class MoveTowards<T> : Unit
	{
		// Token: 0x1700025B RID: 603
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0000CD1D File Offset: 0x0000AF1D
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x0000CD25 File Offset: 0x0000AF25
		[DoNotSerialize]
		public ValueInput current { get; private set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0000CD2E File Offset: 0x0000AF2E
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x0000CD36 File Offset: 0x0000AF36
		[DoNotSerialize]
		public ValueInput target { get; private set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0000CD3F File Offset: 0x0000AF3F
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x0000CD47 File Offset: 0x0000AF47
		[DoNotSerialize]
		public ValueInput maxDelta { get; private set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000CD50 File Offset: 0x0000AF50
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0000CD58 File Offset: 0x0000AF58
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput result { get; private set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x0000CD61 File Offset: 0x0000AF61
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x0000CD69 File Offset: 0x0000AF69
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Per Second")]
		[InspectorToggleLeft]
		public bool perSecond { get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x0000CD74 File Offset: 0x0000AF74
		[DoNotSerialize]
		protected virtual T defaultCurrent
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000CD8C File Offset: 0x0000AF8C
		[DoNotSerialize]
		protected virtual T defaultTarget
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		protected override void Definition()
		{
			this.current = base.ValueInput<T>("current", this.defaultCurrent);
			this.target = base.ValueInput<T>("target", this.defaultTarget);
			this.maxDelta = base.ValueInput<float>("maxDelta", 0f);
			this.result = base.ValueOutput<T>("result", new Func<Flow, T>(this.Operation));
			base.Requirement(this.current, this.result);
			base.Requirement(this.target, this.result);
			base.Requirement(this.maxDelta, this.result);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0000CE48 File Offset: 0x0000B048
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.current), flow.GetValue<T>(this.target), flow.GetValue<float>(this.maxDelta) * (this.perSecond ? Time.deltaTime : 1f));
		}

		// Token: 0x0600067C RID: 1660
		public abstract T Operation(T current, T target, float maxDelta);
	}
}
