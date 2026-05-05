using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000025 RID: 37
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Get Item")]
	[UnitOrder(0)]
	[TypeIcon(typeof(IDictionary))]
	public sealed class GetDictionaryItem : Unit
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00005504 File Offset: 0x00003704
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000550C File Offset: 0x0000370C
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput dictionary { get; private set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00005515 File Offset: 0x00003715
		// (set) Token: 0x06000168 RID: 360 RVA: 0x0000551D File Offset: 0x0000371D
		[DoNotSerialize]
		public ValueInput key { get; private set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00005526 File Offset: 0x00003726
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000552E File Offset: 0x0000372E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x0600016B RID: 363 RVA: 0x00005538 File Offset: 0x00003738
		protected override void Definition()
		{
			this.dictionary = base.ValueInput<IDictionary>("dictionary");
			this.key = base.ValueInput<object>("key");
			this.value = base.ValueOutput<object>("value", new Func<Flow, object>(this.Get));
			base.Requirement(this.dictionary, this.value);
			base.Requirement(this.key, this.value);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000055A8 File Offset: 0x000037A8
		private object Get(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionary);
			object value2 = flow.GetValue<object>(this.key);
			return value[value2];
		}
	}
}
