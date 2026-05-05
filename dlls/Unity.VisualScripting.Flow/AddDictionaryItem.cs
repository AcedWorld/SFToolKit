using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000021 RID: 33
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Add Item")]
	[UnitOrder(2)]
	public sealed class AddDictionaryItem : Unit
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000513D File Offset: 0x0000333D
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00005145 File Offset: 0x00003345
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000514E File Offset: 0x0000334E
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00005156 File Offset: 0x00003356
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueInput dictionaryInput { get; private set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000515F File Offset: 0x0000335F
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00005167 File Offset: 0x00003367
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueOutput dictionaryOutput { get; private set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00005170 File Offset: 0x00003370
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00005178 File Offset: 0x00003378
		[DoNotSerialize]
		public ValueInput key { get; private set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005181 File Offset: 0x00003381
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00005189 File Offset: 0x00003389
		[DoNotSerialize]
		public ValueInput value { get; private set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00005192 File Offset: 0x00003392
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000519A File Offset: 0x0000339A
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x06000149 RID: 329 RVA: 0x000051A4 File Offset: 0x000033A4
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Add));
			this.dictionaryInput = base.ValueInput<IDictionary>("dictionaryInput");
			this.key = base.ValueInput<object>("key");
			this.value = base.ValueInput<object>("value");
			this.dictionaryOutput = base.ValueOutput<IDictionary>("dictionaryOutput");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.dictionaryInput, this.enter);
			base.Requirement(this.key, this.enter);
			base.Requirement(this.value, this.enter);
			base.Assignment(this.enter, this.dictionaryOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005280 File Offset: 0x00003480
		private ControlOutput Add(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionaryInput);
			object value2 = flow.GetValue<object>(this.key);
			object value3 = flow.GetValue<object>(this.value);
			flow.SetValue(this.dictionaryOutput, value);
			value.Add(value2, value3);
			return this.exit;
		}
	}
}
