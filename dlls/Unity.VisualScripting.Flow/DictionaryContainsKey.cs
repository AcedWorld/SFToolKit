using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000024 RID: 36
	[UnitCategory("Collections/Dictionaries")]
	[UnitSurtitle("Dictionary")]
	[UnitShortTitle("Contains Key")]
	[TypeIcon(typeof(IDictionary))]
	public sealed class DictionaryContainsKey : Unit
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0000542A File Offset: 0x0000362A
		// (set) Token: 0x0600015D RID: 349 RVA: 0x00005432 File Offset: 0x00003632
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput dictionary { get; private set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000543B File Offset: 0x0000363B
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00005443 File Offset: 0x00003643
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput key { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0000544C File Offset: 0x0000364C
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00005454 File Offset: 0x00003654
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput contains { get; private set; }

		// Token: 0x06000162 RID: 354 RVA: 0x00005460 File Offset: 0x00003660
		protected override void Definition()
		{
			this.dictionary = base.ValueInput<IDictionary>("dictionary");
			this.key = base.ValueInput<object>("key");
			this.contains = base.ValueOutput<bool>("contains", new Func<Flow, bool>(this.Contains));
			base.Requirement(this.dictionary, this.contains);
			base.Requirement(this.key, this.contains);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000054D0 File Offset: 0x000036D0
		private bool Contains(Flow flow)
		{
			IDictionary value = flow.GetValue<IDictionary>(this.dictionary);
			object value2 = flow.GetValue<object>(this.key);
			return value.Contains(value2);
		}
	}
}
