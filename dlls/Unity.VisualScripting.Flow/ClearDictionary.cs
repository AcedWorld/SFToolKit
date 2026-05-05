using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000022 RID: 34
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Clear")]
	[UnitOrder(4)]
	[TypeIcon(typeof(RemoveDictionaryItem))]
	public sealed class ClearDictionary : Unit
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600014C RID: 332 RVA: 0x000052D7 File Offset: 0x000034D7
		// (set) Token: 0x0600014D RID: 333 RVA: 0x000052DF File Offset: 0x000034DF
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600014E RID: 334 RVA: 0x000052E8 File Offset: 0x000034E8
		// (set) Token: 0x0600014F RID: 335 RVA: 0x000052F0 File Offset: 0x000034F0
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueInput dictionaryInput { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000052F9 File Offset: 0x000034F9
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00005301 File Offset: 0x00003501
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueOutput dictionaryOutput { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000152 RID: 338 RVA: 0x0000530A File Offset: 0x0000350A
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00005312 File Offset: 0x00003512
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x06000154 RID: 340 RVA: 0x0000531C File Offset: 0x0000351C
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Clear));
			this.dictionaryInput = base.ValueInput<IDictionary>("dictionaryInput");
			this.dictionaryOutput = base.ValueOutput<IDictionary>("dictionaryOutput");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.dictionaryInput, this.enter);
			base.Assignment(this.enter, this.dictionaryOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000053B0 File Offset: 0x000035B0
		private ControlOutput Clear(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionaryInput);
			flow.SetValue(this.dictionaryOutput, value);
			value.Clear();
			return this.exit;
		}
	}
}
