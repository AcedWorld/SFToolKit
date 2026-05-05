using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000072 RID: 114
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(Scrollbar))]
	[UnitOrder(6)]
	public sealed class OnScrollbarValueChanged : GameObjectEventUnit<float>
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00009246 File Offset: 0x00007446
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnScrollbarValueChangedMessageListener);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00009252 File Offset: 0x00007452
		protected override string hookName
		{
			get
			{
				return "OnScrollbarValueChanged";
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00009259 File Offset: 0x00007459
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00009261 File Offset: 0x00007461
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003DA RID: 986 RVA: 0x0000926A File Offset: 0x0000746A
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<float>("value");
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00009283 File Offset: 0x00007483
		protected override void AssignArguments(Flow flow, float value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
