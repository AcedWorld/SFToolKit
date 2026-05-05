using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000007 RID: 7
	public sealed class DictionaryCloner : Cloner<IDictionary>
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002221 File Offset: 0x00000421
		public override bool Handles(Type type)
		{
			return typeof(IDictionary).IsAssignableFrom(type);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002234 File Offset: 0x00000434
		public override void FillClone(Type type, ref IDictionary clone, IDictionary original, CloningContext context)
		{
			IDictionaryEnumerator enumerator = original.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object key = enumerator.Key;
				object value = enumerator.Value;
				object key2 = Cloning.Clone(context, key);
				object value2 = Cloning.Clone(context, value);
				clone.Add(key2, value2);
			}
		}
	}
}
