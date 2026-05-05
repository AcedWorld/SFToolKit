using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000023 RID: 35
	[UnitCategory("Collections/Dictionaries")]
	[UnitOrder(-1)]
	[TypeIcon(typeof(IDictionary))]
	[RenamedFrom("Bolt.CreateDitionary")]
	public sealed class CreateDictionary : Unit
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000053EB File Offset: 0x000035EB
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000053F3 File Offset: 0x000035F3
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput dictionary { get; private set; }

		// Token: 0x06000159 RID: 345 RVA: 0x000053FC File Offset: 0x000035FC
		protected override void Definition()
		{
			this.dictionary = base.ValueOutput<IDictionary>("dictionary", new Func<Flow, IDictionary>(this.Create));
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000541B File Offset: 0x0000361B
		public IDictionary Create(Flow flow)
		{
			return new AotDictionary();
		}
	}
}
