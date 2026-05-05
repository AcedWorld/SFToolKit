using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000350 RID: 848
	public class vEditorToolbarAttribute : PropertyAttribute
	{
		// Token: 0x06001155 RID: 4437 RVA: 0x0005DC7B File Offset: 0x0005BE7B
		public vEditorToolbarAttribute(string title, bool useIcon = false, string iconName = "", bool overrideIcon = false, bool overrideChildOrder = false)
		{
			this.title = title;
			this.icon = iconName;
			this.useIcon = useIcon;
			this.overrideChildOrder = overrideChildOrder;
			this.overrideIcon = overrideIcon;
		}

		// Token: 0x0400174C RID: 5964
		public readonly string title;

		// Token: 0x0400174D RID: 5965
		public readonly string icon;

		// Token: 0x0400174E RID: 5966
		public readonly bool useIcon;

		// Token: 0x0400174F RID: 5967
		public readonly bool overrideChildOrder;

		// Token: 0x04001750 RID: 5968
		public readonly bool overrideIcon;
	}
}
