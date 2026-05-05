using System;
using System.Collections;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000030 RID: 48
	internal interface IAsyncOperation<out T> : IEnumerator
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000B8 RID: 184
		bool IsDone { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000B9 RID: 185
		AsyncOperationStatus Status { get; }

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000BA RID: 186
		// (remove) Token: 0x060000BB RID: 187
		event Action<IAsyncOperation<T>> Completed;

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000BC RID: 188
		Exception Exception { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000BD RID: 189
		T Result { get; }
	}
}
