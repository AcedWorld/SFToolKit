using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200007E RID: 126
	[UnitCategory("Events/Input")]
	public sealed class OnButtonInput : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00009457 File Offset: 0x00007657
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000945E File Offset: 0x0000765E
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00009466 File Offset: 0x00007666
		[DoNotSerialize]
		[PortLabel("Name")]
		public ValueInput buttonName { get; private set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000946F File Offset: 0x0000766F
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00009477 File Offset: 0x00007677
		[DoNotSerialize]
		public ValueInput action { get; private set; }

		// Token: 0x0600040A RID: 1034 RVA: 0x00009480 File Offset: 0x00007680
		protected override void Definition()
		{
			base.Definition();
			this.buttonName = base.ValueInput<string>("buttonName", string.Empty);
			this.action = base.ValueInput<PressState>("action", PressState.Down);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000094B0 File Offset: 0x000076B0
		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			string value = flow.GetValue<string>(this.buttonName);
			PressState value2 = flow.GetValue<PressState>(this.action);
			switch (value2)
			{
			case PressState.Hold:
				return Input.GetButton(value);
			case PressState.Down:
				return Input.GetButtonDown(value);
			case PressState.Up:
				return Input.GetButtonUp(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
