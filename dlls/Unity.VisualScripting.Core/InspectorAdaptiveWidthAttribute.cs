using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003B RID: 59
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorAdaptiveWidthAttribute : Attribute
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x00004E04 File Offset: 0x00003004
		public InspectorAdaptiveWidthAttribute(float width)
		{
			this.width = width;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00004E13 File Offset: 0x00003013
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00004E1B File Offset: 0x0000301B
		public float width { get; private set; }
	}
}
