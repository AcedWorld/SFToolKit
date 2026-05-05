using System;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine.Scripting;

namespace Unity.VisualScripting
{
	// Token: 0x02000012 RID: 18
	public sealed class AotDictionary : OrderedDictionary
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00002BC0 File Offset: 0x00000DC0
		public AotDictionary()
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public AotDictionary(IEqualityComparer comparer) : base(comparer)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002BD1 File Offset: 0x00000DD1
		public AotDictionary(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002BDA File Offset: 0x00000DDA
		public AotDictionary(int capacity, IEqualityComparer comparer) : base(capacity, comparer)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002BE4 File Offset: 0x00000DE4
		[Preserve]
		public static void AotStubs()
		{
			AotDictionary aotDictionary = new AotDictionary();
			aotDictionary.Add(null, null);
			aotDictionary.Remove(null);
			object obj = aotDictionary[null];
			aotDictionary[null] = null;
			aotDictionary.Contains(null);
			aotDictionary.Clear();
			int count = aotDictionary.Count;
		}
	}
}
