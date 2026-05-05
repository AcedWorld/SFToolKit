using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000027 RID: 39
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Remove Item")]
	[UnitOrder(3)]
	public sealed class RemoveDictionaryItem : Unit
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000173 RID: 371 RVA: 0x000056D7 File Offset: 0x000038D7
		// (set) Token: 0x06000174 RID: 372 RVA: 0x000056DF File Offset: 0x000038DF
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000175 RID: 373 RVA: 0x000056E8 File Offset: 0x000038E8
		// (set) Token: 0x06000176 RID: 374 RVA: 0x000056F0 File Offset: 0x000038F0
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueInput dictionaryInput { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000177 RID: 375 RVA: 0x000056F9 File Offset: 0x000038F9
		// (set) Token: 0x06000178 RID: 376 RVA: 0x00005701 File Offset: 0x00003901
		[DoNotSerialize]
		[PortLabel("Dictionary")]
		[PortLabelHidden]
		public ValueOutput dictionaryOutput { get; private set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000179 RID: 377 RVA: 0x0000570A File Offset: 0x0000390A
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00005712 File Offset: 0x00003912
		[DoNotSerialize]
		public ValueInput key { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600017B RID: 379 RVA: 0x0000571B File Offset: 0x0000391B
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00005723 File Offset: 0x00003923
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x0600017D RID: 381 RVA: 0x0000572C File Offset: 0x0000392C
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Remove));
			this.dictionaryInput = base.ValueInput<IDictionary>("dictionaryInput");
			this.dictionaryOutput = base.ValueOutput<IDictionary>("dictionaryOutput");
			this.key = base.ValueInput<object>("key");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.dictionaryInput, this.enter);
			base.Requirement(this.key, this.enter);
			base.Assignment(this.enter, this.dictionaryOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000057E4 File Offset: 0x000039E4
		public ControlOutput Remove(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionaryInput);
			object value2 = flow.GetValue<object>(this.key);
			flow.SetValue(this.dictionaryOutput, value);
			value.Remove(value2);
			return this.exit;
		}
	}
}
