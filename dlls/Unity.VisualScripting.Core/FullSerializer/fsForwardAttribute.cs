using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200017D RID: 381
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	public sealed class fsForwardAttribute : Attribute
	{
		// Token: 0x06000A29 RID: 2601 RVA: 0x0002A776 File Offset: 0x00028976
		public fsForwardAttribute(string memberName)
		{
			this.MemberName = memberName;
		}

		// Token: 0x0400025E RID: 606
		public string MemberName;
	}
}
