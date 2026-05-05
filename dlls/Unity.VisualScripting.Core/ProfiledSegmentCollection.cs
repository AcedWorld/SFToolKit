using System;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x020000CA RID: 202
	public class ProfiledSegmentCollection : KeyedCollection<string, ProfiledSegment>
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x0000AE69 File Offset: 0x00009069
		protected override string GetKeyForItem(ProfiledSegment item)
		{
			return item.name;
		}
	}
}
