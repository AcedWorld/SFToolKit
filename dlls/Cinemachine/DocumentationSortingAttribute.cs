using System;

namespace Cinemachine
{
	// Token: 0x02000044 RID: 68
	[DocumentationSorting(DocumentationSortingAttribute.Level.Undoc)]
	public sealed class DocumentationSortingAttribute : Attribute
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00012E01 File Offset: 0x00011001
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00012E09 File Offset: 0x00011009
		public DocumentationSortingAttribute.Level Category { get; private set; }

		// Token: 0x060002CE RID: 718 RVA: 0x00012E12 File Offset: 0x00011012
		public DocumentationSortingAttribute(DocumentationSortingAttribute.Level category)
		{
			this.Category = category;
		}

		// Token: 0x020000AF RID: 175
		public enum Level
		{
			// Token: 0x0400038B RID: 907
			Undoc,
			// Token: 0x0400038C RID: 908
			API,
			// Token: 0x0400038D RID: 909
			UserRef
		}
	}
}
