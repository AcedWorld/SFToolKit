using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000097 RID: 151
	[UnitCategory("Events/Physics")]
	public sealed class OnJointBreak : GameObjectEventUnit<float>
	{
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00009C1E File Offset: 0x00007E1E
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnJointBreakMessageListener);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00009C2A File Offset: 0x00007E2A
		protected override string hookName
		{
			get
			{
				return "OnJointBreak";
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00009C31 File Offset: 0x00007E31
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x00009C39 File Offset: 0x00007E39
		[DoNotSerialize]
		public ValueOutput breakForce { get; private set; }

		// Token: 0x0600047F RID: 1151 RVA: 0x00009C42 File Offset: 0x00007E42
		protected override void Definition()
		{
			base.Definition();
			this.breakForce = base.ValueOutput<float>("breakForce");
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00009C5B File Offset: 0x00007E5B
		protected override void AssignArguments(Flow flow, float breakForce)
		{
			flow.SetValue(this.breakForce, breakForce);
		}
	}
}
