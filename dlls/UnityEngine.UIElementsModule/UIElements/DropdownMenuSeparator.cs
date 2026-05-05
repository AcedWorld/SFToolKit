using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200017B RID: 379
	public class DropdownMenuSeparator : DropdownMenuItem
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00030B53 File Offset: 0x0002ED53
		public string subMenuPath { get; }

		// Token: 0x06000C22 RID: 3106 RVA: 0x00030B5B File Offset: 0x0002ED5B
		public DropdownMenuSeparator(string subMenuPath)
		{
			this.subMenuPath = subMenuPath;
		}
	}
}
