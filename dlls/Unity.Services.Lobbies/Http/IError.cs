using System;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000051 RID: 81
	internal interface IError
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600022B RID: 555
		string Type { get; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600022C RID: 556
		string Title { get; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600022D RID: 557
		int? Status { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600022E RID: 558
		int Code { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600022F RID: 559
		string Detail { get; }
	}
}
