using System;

namespace UnityEngine.Android
{
	// Token: 0x02000019 RID: 25
	public class RequestToUseMobileDataAsyncOperation : CustomYieldInstruction
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00009B78 File Offset: 0x00007D78
		public override bool keepWaiting
		{
			get
			{
				object operationLock = this.m_OperationLock;
				bool result;
				lock (operationLock)
				{
					result = (this.m_RequestResult == null);
				}
				return result;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00009674 File Offset: 0x00007874
		public bool isDone
		{
			get
			{
				return !this.keepWaiting;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00009BC4 File Offset: 0x00007DC4
		public AndroidAssetPackUseMobileDataRequestResult result
		{
			get
			{
				object operationLock = this.m_OperationLock;
				AndroidAssetPackUseMobileDataRequestResult requestResult;
				lock (operationLock)
				{
					requestResult = this.m_RequestResult;
				}
				return requestResult;
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00009C0C File Offset: 0x00007E0C
		internal RequestToUseMobileDataAsyncOperation()
		{
			this.m_OperationLock = new object();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00009C24 File Offset: 0x00007E24
		internal void OnResult(AndroidAssetPackUseMobileDataRequestResult result)
		{
			object operationLock = this.m_OperationLock;
			lock (operationLock)
			{
				this.m_RequestResult = result;
			}
		}

		// Token: 0x0400004D RID: 77
		private AndroidAssetPackUseMobileDataRequestResult m_RequestResult;

		// Token: 0x0400004E RID: 78
		private readonly object m_OperationLock;
	}
}
