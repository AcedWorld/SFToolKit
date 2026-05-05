using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003C2 RID: 962
	internal class UxmlObjectAttributeDescription<T> where T : new()
	{
		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06001FCA RID: 8138 RVA: 0x00078B4F File Offset: 0x00076D4F
		// (set) Token: 0x06001FCB RID: 8139 RVA: 0x00078B57 File Offset: 0x00076D57
		public T defaultValue { get; set; }

		// Token: 0x06001FCC RID: 8140 RVA: 0x00078B60 File Offset: 0x00076D60
		public virtual T GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
		{
			VisualTreeAsset visualTreeAsset = cc.visualTreeAsset;
			List<T> list = (visualTreeAsset != null) ? visualTreeAsset.GetUxmlObjects<T>(bag, cc) : null;
			bool flag = list != null;
			if (flag)
			{
				using (List<T>.Enumerator enumerator = list.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						return enumerator.Current;
					}
				}
			}
			return this.defaultValue;
		}
	}
}
