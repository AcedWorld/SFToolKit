using System;
using System.Runtime.CompilerServices;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000029 RID: 41
	internal struct AsyncOperationAwaiter : IAsyncOperationAwaiter, ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00002578 File Offset: 0x00000778
		public AsyncOperationAwaiter(IAsyncOperation asyncOperation)
		{
			this.m_Operation = asyncOperation;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002584 File Offset: 0x00000784
		public void OnCompleted(Action continuation)
		{
			this.m_Operation.Completed += delegate(IAsyncOperation operation)
			{
				continuation();
			};
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000025B8 File Offset: 0x000007B8
		public void UnsafeOnCompleted(Action continuation)
		{
			this.m_Operation.Completed += delegate(IAsyncOperation operation)
			{
				continuation();
			};
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000025E9 File Offset: 0x000007E9
		public bool IsCompleted
		{
			get
			{
				return this.m_Operation.IsDone;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000025F6 File Offset: 0x000007F6
		public void GetResult()
		{
			if (this.m_Operation.Status == AsyncOperationStatus.Failed || this.m_Operation.Status == AsyncOperationStatus.Cancelled)
			{
				throw this.m_Operation.Exception;
			}
		}

		// Token: 0x04000025 RID: 37
		private IAsyncOperation m_Operation;
	}
}
