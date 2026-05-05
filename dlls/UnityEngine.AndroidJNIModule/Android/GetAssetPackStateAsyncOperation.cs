using System;

namespace UnityEngine.Android
{
	// Token: 0x02000018 RID: 24
	public class GetAssetPackStateAsyncOperation : CustomYieldInstruction
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00009A34 File Offset: 0x00007C34
		public override bool keepWaiting
		{
			get
			{
				object operationLock = this.m_OperationLock;
				bool result;
				lock (operationLock)
				{
					result = (this.m_States == null);
				}
				return result;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00009674 File Offset: 0x00007874
		public bool isDone
		{
			get
			{
				return !this.keepWaiting;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00009A80 File Offset: 0x00007C80
		public ulong size
		{
			get
			{
				object operationLock = this.m_OperationLock;
				ulong size;
				lock (operationLock)
				{
					size = this.m_Size;
				}
				return size;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00009AC8 File Offset: 0x00007CC8
		public AndroidAssetPackState[] states
		{
			get
			{
				object operationLock = this.m_OperationLock;
				AndroidAssetPackState[] states;
				lock (operationLock)
				{
					states = this.m_States;
				}
				return states;
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00009B10 File Offset: 0x00007D10
		internal GetAssetPackStateAsyncOperation()
		{
			this.m_OperationLock = new object();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00009B28 File Offset: 0x00007D28
		internal void OnResult(ulong size, AndroidAssetPackState[] states)
		{
			object operationLock = this.m_OperationLock;
			lock (operationLock)
			{
				this.m_Size = size;
				this.m_States = states;
			}
		}

		// Token: 0x0400004A RID: 74
		private ulong m_Size;

		// Token: 0x0400004B RID: 75
		private AndroidAssetPackState[] m_States;

		// Token: 0x0400004C RID: 76
		private readonly object m_OperationLock;
	}
}
