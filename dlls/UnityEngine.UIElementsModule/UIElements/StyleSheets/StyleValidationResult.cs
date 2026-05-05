using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x020004A6 RID: 1190
	internal struct StyleValidationResult
	{
		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x0600251E RID: 9502 RVA: 0x0009C7FC File Offset: 0x0009A9FC
		public bool success
		{
			get
			{
				return this.status == StyleValidationStatus.Ok;
			}
		}

		// Token: 0x040011DE RID: 4574
		public StyleValidationStatus status;

		// Token: 0x040011DF RID: 4575
		public string message;

		// Token: 0x040011E0 RID: 4576
		public string errorValue;

		// Token: 0x040011E1 RID: 4577
		public string hint;
	}
}
