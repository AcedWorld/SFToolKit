using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000077 RID: 119
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(Toggle))]
	[UnitOrder(5)]
	public sealed class OnToggleValueChanged : GameObjectEventUnit<bool>
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00009387 File Offset: 0x00007587
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnToggleValueChangedMessageListener);
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00009393 File Offset: 0x00007593
		protected override string hookName
		{
			get
			{
				return "OnToggleValueChanged";
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000939A File Offset: 0x0000759A
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000093A2 File Offset: 0x000075A2
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003F5 RID: 1013 RVA: 0x000093AB File Offset: 0x000075AB
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<bool>("value");
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000093C4 File Offset: 0x000075C4
		protected override void AssignArguments(Flow flow, bool value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
