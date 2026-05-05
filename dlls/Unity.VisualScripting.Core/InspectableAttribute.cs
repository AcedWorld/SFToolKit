using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000038 RID: 56
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class InspectableAttribute : Attribute, IInspectableAttribute
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00004DAB File Offset: 0x00002FAB
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00004DB3 File Offset: 0x00002FB3
		public int order { get; set; }
	}
}
