using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000066 RID: 102
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(Dropdown))]
	[UnitOrder(4)]
	public sealed class OnDropdownValueChanged : GameObjectEventUnit<int>
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00008FDB File Offset: 0x000071DB
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnDropdownValueChangedMessageListener);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00008FE7 File Offset: 0x000071E7
		protected override string hookName
		{
			get
			{
				return "OnDropdownValueChanged";
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00008FEE File Offset: 0x000071EE
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00008FF6 File Offset: 0x000071F6
		[DoNotSerialize]
		public ValueOutput index { get; private set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00008FFF File Offset: 0x000071FF
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00009007 File Offset: 0x00007207
		[DoNotSerialize]
		public ValueOutput text { get; private set; }

		// Token: 0x060003A7 RID: 935 RVA: 0x00009010 File Offset: 0x00007210
		protected override void Definition()
		{
			base.Definition();
			this.index = base.ValueOutput<int>("index");
			this.text = base.ValueOutput<string>("text");
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000903A File Offset: 0x0000723A
		protected override void AssignArguments(Flow flow, int index)
		{
			flow.SetValue(this.index, index);
			flow.SetValue(this.text, flow.GetValue<Dropdown>(base.target).options[index].text);
		}
	}
}
