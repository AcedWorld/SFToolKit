using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000084 RID: 132
	[UnitCategory("Events/Input")]
	public sealed class OnMouseInput : MachineEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000962E File Offset: 0x0000782E
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00009635 File Offset: 0x00007835
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x0000963D File Offset: 0x0000783D
		[DoNotSerialize]
		public ValueInput button { get; private set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00009646 File Offset: 0x00007846
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x0000964E File Offset: 0x0000784E
		[DoNotSerialize]
		public ValueInput action { get; private set; }

		// Token: 0x06000426 RID: 1062 RVA: 0x00009657 File Offset: 0x00007857
		protected override void Definition()
		{
			base.Definition();
			this.button = base.ValueInput<MouseButton>("button", MouseButton.Left);
			this.action = base.ValueInput<PressState>("action", PressState.Down);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00009684 File Offset: 0x00007884
		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			int value = (int)flow.GetValue<MouseButton>(this.button);
			PressState value2 = flow.GetValue<PressState>(this.action);
			switch (value2)
			{
			case PressState.Hold:
				return Input.GetMouseButton(value);
			case PressState.Down:
				return Input.GetMouseButtonDown(value);
			case PressState.Up:
				return Input.GetMouseButtonUp(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
