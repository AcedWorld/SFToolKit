using System;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000064 RID: 100
	internal interface IApiAccessor
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002AD RID: 685
		IApiConfiguration Configuration { get; }

		// Token: 0x060002AE RID: 686
		string GetBasePath();
	}
}
