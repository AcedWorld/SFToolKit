using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000015 RID: 21
	public class FlexibleDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		// Token: 0x1700001D RID: 29
		public new TValue this[TKey key]
		{
			get
			{
				return base[key];
			}
			set
			{
				if (base.ContainsKey(key))
				{
					base[key] = value;
					return;
				}
				base.Add(key, value);
			}
		}
	}
}
