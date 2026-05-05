using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x0200006A RID: 106
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(InputField))]
	[UnitOrder(2)]
	public sealed class OnInputFieldValueChanged : GameObjectEventUnit<string>
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x000090FC File Offset: 0x000072FC
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnInputFieldValueChangedMessageListener);
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00009108 File Offset: 0x00007308
		protected override string hookName
		{
			get
			{
				return "OnInputFieldValueChanged";
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0000910F File Offset: 0x0000730F
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00009117 File Offset: 0x00007317
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003BA RID: 954 RVA: 0x00009120 File Offset: 0x00007320
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<string>("value");
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00009139 File Offset: 0x00007339
		protected override void AssignArguments(Flow flow, string value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
