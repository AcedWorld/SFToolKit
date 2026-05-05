using System;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x0200006B RID: 107
	[UnitCategory("Events/GUI")]
	[UnitOrder(21)]
	public sealed class OnMove : GameObjectEventUnit<AxisEventData>
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00009150 File Offset: 0x00007350
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMoveMessageListener);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0000915C File Offset: 0x0000735C
		protected override string hookName
		{
			get
			{
				return "OnMove";
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00009163 File Offset: 0x00007363
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0000916B File Offset: 0x0000736B
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput data { get; private set; }

		// Token: 0x060003C1 RID: 961 RVA: 0x00009174 File Offset: 0x00007374
		protected override void Definition()
		{
			base.Definition();
			this.data = base.ValueOutput<AxisEventData>("data");
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000918D File Offset: 0x0000738D
		protected override void AssignArguments(Flow flow, AxisEventData data)
		{
			flow.SetValue(this.data, data);
		}
	}
}
