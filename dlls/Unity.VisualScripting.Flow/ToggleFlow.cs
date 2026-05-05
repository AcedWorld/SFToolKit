using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004A RID: 74
	[UnitCategory("Control")]
	[UnitOrder(18)]
	[UnitFooterPorts(ControlInputs = true, ControlOutputs = true)]
	public sealed class ToggleFlow : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00007DA8 File Offset: 0x00005FA8
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00007DB0 File Offset: 0x00005FB0
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Start On")]
		[InspectorToggleLeft]
		public bool startOn { get; set; } = true;

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00007DB9 File Offset: 0x00005FB9
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00007DC1 File Offset: 0x00005FC1
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00007DCA File Offset: 0x00005FCA
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00007DD2 File Offset: 0x00005FD2
		[DoNotSerialize]
		[PortLabel("On")]
		public ControlInput turnOn { get; private set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00007DDB File Offset: 0x00005FDB
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00007DE3 File Offset: 0x00005FE3
		[DoNotSerialize]
		[PortLabel("Off")]
		public ControlInput turnOff { get; private set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00007DEC File Offset: 0x00005FEC
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00007DF4 File Offset: 0x00005FF4
		[DoNotSerialize]
		public ControlInput toggle { get; private set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00007DFD File Offset: 0x00005FFD
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00007E05 File Offset: 0x00006005
		[DoNotSerialize]
		[PortLabel("On")]
		public ControlOutput exitOn { get; private set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00007E0E File Offset: 0x0000600E
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00007E16 File Offset: 0x00006016
		[DoNotSerialize]
		[PortLabel("Off")]
		public ControlOutput exitOff { get; private set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00007E1F File Offset: 0x0000601F
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00007E27 File Offset: 0x00006027
		[DoNotSerialize]
		public ControlOutput turnedOn { get; private set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00007E30 File Offset: 0x00006030
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00007E38 File Offset: 0x00006038
		[DoNotSerialize]
		public ControlOutput turnedOff { get; private set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00007E41 File Offset: 0x00006041
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00007E49 File Offset: 0x00006049
		[DoNotSerialize]
		public ValueOutput isOn { get; private set; }

		// Token: 0x060002E4 RID: 740 RVA: 0x00007E54 File Offset: 0x00006054
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.turnOn = base.ControlInput("turnOn", new Func<Flow, ControlOutput>(this.TurnOn));
			this.turnOff = base.ControlInput("turnOff", new Func<Flow, ControlOutput>(this.TurnOff));
			this.toggle = base.ControlInput("toggle", new Func<Flow, ControlOutput>(this.Toggle));
			this.exitOn = base.ControlOutput("exitOn");
			this.exitOff = base.ControlOutput("exitOff");
			this.turnedOn = base.ControlOutput("turnedOn");
			this.turnedOff = base.ControlOutput("turnedOff");
			this.isOn = base.ValueOutput<bool>("isOn", new Func<Flow, bool>(this.IsOn));
			base.Succession(this.enter, this.exitOn);
			base.Succession(this.enter, this.exitOff);
			base.Succession(this.turnOn, this.turnedOn);
			base.Succession(this.turnOff, this.turnedOff);
			base.Succession(this.toggle, this.turnedOn);
			base.Succession(this.toggle, this.turnedOff);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00007FA2 File Offset: 0x000061A2
		public IGraphElementData CreateData()
		{
			return new ToggleFlow.Data
			{
				isOn = this.startOn
			};
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00007FB5 File Offset: 0x000061B5
		private bool IsOn(Flow flow)
		{
			return flow.stack.GetElementData<ToggleFlow.Data>(this).isOn;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00007FC8 File Offset: 0x000061C8
		private ControlOutput Enter(Flow flow)
		{
			if (!this.IsOn(flow))
			{
				return this.exitOff;
			}
			return this.exitOn;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00007FE0 File Offset: 0x000061E0
		private ControlOutput TurnOn(Flow flow)
		{
			ToggleFlow.Data elementData = flow.stack.GetElementData<ToggleFlow.Data>(this);
			if (elementData.isOn)
			{
				return null;
			}
			elementData.isOn = true;
			return this.turnedOn;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00008014 File Offset: 0x00006214
		private ControlOutput TurnOff(Flow flow)
		{
			ToggleFlow.Data elementData = flow.stack.GetElementData<ToggleFlow.Data>(this);
			if (!elementData.isOn)
			{
				return null;
			}
			elementData.isOn = false;
			return this.turnedOff;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00008045 File Offset: 0x00006245
		private ControlOutput Toggle(Flow flow)
		{
			ToggleFlow.Data elementData = flow.stack.GetElementData<ToggleFlow.Data>(this);
			elementData.isOn = !elementData.isOn;
			if (!elementData.isOn)
			{
				return this.turnedOff;
			}
			return this.turnedOn;
		}

		// Token: 0x020001AD RID: 429
		public class Data : IGraphElementData
		{
			// Token: 0x04000394 RID: 916
			public bool isOn;
		}
	}
}
