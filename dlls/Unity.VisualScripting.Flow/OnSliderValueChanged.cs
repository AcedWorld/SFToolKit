using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000075 RID: 117
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(Slider))]
	[UnitOrder(8)]
	public sealed class OnSliderValueChanged : GameObjectEventUnit<float>
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00009313 File Offset: 0x00007513
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnSliderValueChangedMessageListener);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000931F File Offset: 0x0000751F
		protected override string hookName
		{
			get
			{
				return "OnSliderValueChanged";
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00009326 File Offset: 0x00007526
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000932E File Offset: 0x0000752E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003EB RID: 1003 RVA: 0x00009337 File Offset: 0x00007537
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<float>("value");
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00009350 File Offset: 0x00007550
		protected override void AssignArguments(Flow flow, float value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
