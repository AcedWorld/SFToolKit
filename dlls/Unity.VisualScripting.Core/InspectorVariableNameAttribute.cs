using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200016C RID: 364
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorVariableNameAttribute : Attribute
	{
		// Token: 0x060009AF RID: 2479 RVA: 0x00029210 File Offset: 0x00027410
		public InspectorVariableNameAttribute(ActionDirection direction)
		{
			this.direction = direction;
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0002921F File Offset: 0x0002741F
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x00029227 File Offset: 0x00027427
		public ActionDirection direction { get; private set; }
	}
}
