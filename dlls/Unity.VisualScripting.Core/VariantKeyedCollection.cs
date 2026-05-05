using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000026 RID: 38
	public class VariantKeyedCollection<TBase, TImplementation, TKey> : VariantCollection<TBase, TImplementation>, IKeyedCollection<TKey, TBase>, ICollection<TBase>, IEnumerable<!0>, IEnumerable where TImplementation : TBase
	{
		// Token: 0x06000157 RID: 343 RVA: 0x00004275 File Offset: 0x00002475
		public VariantKeyedCollection(IKeyedCollection<TKey, TImplementation> implementation) : base(implementation)
		{
			this.implementation = implementation;
		}

		// Token: 0x17000041 RID: 65
		public TBase this[TKey key]
		{
			get
			{
				return (TBase)((object)this.implementation[key]);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000159 RID: 345 RVA: 0x0000429D File Offset: 0x0000249D
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000042A5 File Offset: 0x000024A5
		public new IKeyedCollection<TKey, TImplementation> implementation { get; private set; }

		// Token: 0x0600015B RID: 347 RVA: 0x000042B0 File Offset: 0x000024B0
		public bool TryGetValue(TKey key, out TBase value)
		{
			TImplementation timplementation;
			bool result = this.implementation.TryGetValue(key, out timplementation);
			value = (TBase)((object)timplementation);
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000042DC File Offset: 0x000024DC
		public bool Contains(TKey key)
		{
			return this.implementation.Contains(key);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000042EA File Offset: 0x000024EA
		public bool Remove(TKey key)
		{
			return this.implementation.Remove(key);
		}

		// Token: 0x17000043 RID: 67
		TBase IKeyedCollection<!2, !0>.this[int index]
		{
			get
			{
				return (TBase)((object)this.implementation[index]);
			}
		}
	}
}
