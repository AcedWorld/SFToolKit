using System;
using System.Runtime.CompilerServices;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000031 RID: 49
	internal interface IAsyncOperationAwaiter : ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000BE RID: 190
		bool IsCompleted { get; }

		// Token: 0x060000BF RID: 191
		void GetResult();
	}
}
