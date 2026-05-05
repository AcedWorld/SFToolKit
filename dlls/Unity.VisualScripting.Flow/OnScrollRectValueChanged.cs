using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000073 RID: 115
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(ScrollRect))]
	[UnitOrder(7)]
	public sealed class OnScrollRectValueChanged : GameObjectEventUnit<Vector2>
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0000929F File Offset: 0x0000749F
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnScrollRectValueChangedMessageListener);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060003DE RID: 990 RVA: 0x000092AB File Offset: 0x000074AB
		protected override string hookName
		{
			get
			{
				return "OnScrollRectValueChanged";
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060003DF RID: 991 RVA: 0x000092B2 File Offset: 0x000074B2
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x000092BA File Offset: 0x000074BA
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060003E1 RID: 993 RVA: 0x000092C3 File Offset: 0x000074C3
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<Vector2>("value");
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000092DC File Offset: 0x000074DC
		protected override void AssignArguments(Flow flow, Vector2 value)
		{
			flow.SetValue(this.value, value);
		}
	}
}
