using System;

namespace UnityEngine
{
	// Token: 0x0200020E RID: 526
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public class TooltipAttribute : PropertyAttribute
	{
		// Token: 0x060017A0 RID: 6048 RVA: 0x000274CF File Offset: 0x000256CF
		public TooltipAttribute(string tooltip)
		{
			this.tooltip = tooltip;
		}

		// Token: 0x0400086B RID: 2155
		public readonly string tooltip;
	}
}
