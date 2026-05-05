using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000028 RID: 40
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Set Item")]
	[UnitOrder(1)]
	[TypeIcon(typeof(IDictionary))]
	public sealed class SetDictionaryItem : Unit
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000180 RID: 384 RVA: 0x0000582D File Offset: 0x00003A2D
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00005835 File Offset: 0x00003A35
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000583E File Offset: 0x00003A3E
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00005846 File Offset: 0x00003A46
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput dictionary { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000584F File Offset: 0x00003A4F
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00005857 File Offset: 0x00003A57
		[DoNotSerialize]
		public ValueInput key { get; private set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00005860 File Offset: 0x00003A60
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00005868 File Offset: 0x00003A68
		[DoNotSerialize]
		public ValueInput value { get; private set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00005871 File Offset: 0x00003A71
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00005879 File Offset: 0x00003A79
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x0600018A RID: 394 RVA: 0x00005884 File Offset: 0x00003A84
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Set));
			this.dictionary = base.ValueInput<IDictionary>("dictionary");
			this.key = base.ValueInput<object>("key");
			this.value = base.ValueInput<object>("value");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.dictionary, this.enter);
			base.Requirement(this.key, this.enter);
			base.Requirement(this.value, this.enter);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000593C File Offset: 0x00003B3C
		public ControlOutput Set(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionary);
			object value2 = flow.GetValue<object>(this.key);
			object value3 = flow.GetValue<object>(this.value);
			value[value2] = value3;
			return this.exit;
		}
	}
}
