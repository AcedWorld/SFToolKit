using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200007F RID: 127
	[UnitCategory("Events/Input")]
	public sealed class OnKeyboardInput : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000950E File Offset: 0x0000770E
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00009515 File Offset: 0x00007715
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x0000951D File Offset: 0x0000771D
		[DoNotSerialize]
		public ValueInput key { get; private set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00009526 File Offset: 0x00007726
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x0000952E File Offset: 0x0000772E
		[DoNotSerialize]
		public ValueInput action { get; private set; }

		// Token: 0x06000412 RID: 1042 RVA: 0x00009537 File Offset: 0x00007737
		protected override void Definition()
		{
			base.Definition();
			this.key = base.ValueInput<KeyCode>("key", KeyCode.Space);
			this.action = base.ValueInput<PressState>("action", PressState.Down);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00009564 File Offset: 0x00007764
		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			KeyCode value = flow.GetValue<KeyCode>(this.key);
			PressState value2 = flow.GetValue<PressState>(this.action);
			switch (value2)
			{
			case PressState.Hold:
				return Input.GetKey(value);
			case PressState.Down:
				return Input.GetKeyDown(value);
			case PressState.Up:
				return Input.GetKeyUp(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
