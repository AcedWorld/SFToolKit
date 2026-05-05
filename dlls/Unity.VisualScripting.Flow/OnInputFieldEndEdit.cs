using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000069 RID: 105
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(InputField))]
	[UnitOrder(3)]
	public sealed class OnInputFieldEndEdit : GameObjectEventUnit<string>
	{
		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000090A8 File Offset: 0x000072A8
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnInputFieldEndEditMessageListener);
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x000090B4 File Offset: 0x000072B4
		protected override string hookName
		{
			get
			{
				return "OnInputFieldEndEdit";
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000090BB File Offset: 0x000072BB
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x000090C3 File Offset: 0x000072C3
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003B3 RID: 947 RVA: 0x000090CC File Offset: 0x000072CC
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<string>("value");
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000090E5 File Offset: 0x000072E5
		protected override void AssignArguments(Flow flow, string value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
