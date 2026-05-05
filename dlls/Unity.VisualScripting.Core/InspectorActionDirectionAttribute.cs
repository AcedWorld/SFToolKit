using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003A RID: 58
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorActionDirectionAttribute : Attribute
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x00004DE4 File Offset: 0x00002FE4
		public InspectorActionDirectionAttribute(ActionDirection direction)
		{
			this.direction = direction;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00004DF3 File Offset: 0x00002FF3
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00004DFB File Offset: 0x00002FFB
		public ActionDirection direction { get; private set; }
	}
}
