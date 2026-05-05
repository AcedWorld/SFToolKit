using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200003E RID: 62
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorLabelAttribute : Attribute
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00004E34 File Offset: 0x00003034
		public InspectorLabelAttribute(string text)
		{
			this.text = text;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00004E43 File Offset: 0x00003043
		public InspectorLabelAttribute(string text, string tooltip)
		{
			this.text = text;
			this.tooltip = tooltip;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00004E59 File Offset: 0x00003059
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00004E61 File Offset: 0x00003061
		public string text { get; private set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00004E6A File Offset: 0x0000306A
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00004E72 File Offset: 0x00003072
		public string tooltip { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00004E7B File Offset: 0x0000307B
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00004E83 File Offset: 0x00003083
		public Texture image { get; set; }
	}
}
