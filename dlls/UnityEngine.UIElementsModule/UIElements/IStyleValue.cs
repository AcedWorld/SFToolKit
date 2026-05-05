using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200030D RID: 781
	internal interface IStyleValue<T>
	{
		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06001B05 RID: 6917
		// (set) Token: 0x06001B06 RID: 6918
		T value { get; set; }

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06001B07 RID: 6919
		// (set) Token: 0x06001B08 RID: 6920
		StyleKeyword keyword { get; set; }
	}
}
