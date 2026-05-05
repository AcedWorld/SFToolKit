using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000026 RID: 38
	[UnitCategory("Collections/Dictionaries")]
	[UnitOrder(5)]
	public sealed class MergeDictionaries : MultiInputUnit<IDictionary>
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600016E RID: 366 RVA: 0x000055DC File Offset: 0x000037DC
		// (set) Token: 0x0600016F RID: 367 RVA: 0x000055E4 File Offset: 0x000037E4
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput dictionary { get; private set; }

		// Token: 0x06000170 RID: 368 RVA: 0x000055F0 File Offset: 0x000037F0
		protected override void Definition()
		{
			this.dictionary = base.ValueOutput<IDictionary>("dictionary", new Func<Flow, IDictionary>(this.Merge));
			base.Definition();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.dictionary);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005668 File Offset: 0x00003868
		public IDictionary Merge(Flow flow)
		{
			AotDictionary aotDictionary = new AotDictionary();
			for (int i = 0; i < this.inputCount; i++)
			{
				IDictionaryEnumerator enumerator = flow.GetValue<IDictionary>(base.multiInputs[i]).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!aotDictionary.Contains(enumerator.Key))
					{
						aotDictionary.Add(enumerator.Key, enumerator.Value);
					}
				}
			}
			return aotDictionary;
		}
	}
}
