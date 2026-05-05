using System;
using JetBrains.Annotations;

namespace Unity.Services.Core.Internal
{
	// Token: 0x0200004E RID: 78
	internal interface IServiceRegistry
	{
		// Token: 0x06000152 RID: 338
		void RegisterService<T>([NotNull] T service);

		// Token: 0x06000153 RID: 339
		T GetService<T>();
	}
}
