using System;
using System.Collections;

namespace Unity.Services.Core.Internal
{
	// Token: 0x0200002F RID: 47
	internal interface IAsyncOperation : IEnumerator
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000B3 RID: 179
		bool IsDone { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000B4 RID: 180
		AsyncOperationStatus Status { get; }

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000B5 RID: 181
		// (remove) Token: 0x060000B6 RID: 182
		event Action<IAsyncOperation> Completed;

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000B7 RID: 183
		Exception Exception { get; }
	}
}
