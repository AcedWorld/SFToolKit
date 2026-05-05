using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Internal;

namespace UnityEngine
{
	// Token: 0x02000225 RID: 549
	[ExcludeFromDocs]
	public class AsyncInstantiateOperation<T> : CustomYieldInstruction where T : Object
	{
		// Token: 0x0600181D RID: 6173 RVA: 0x00027FF8 File Offset: 0x000261F8
		internal AsyncInstantiateOperation(AsyncInstantiateOperation op)
		{
			this.m_op = op;
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x0600181E RID: 6174 RVA: 0x00028009 File Offset: 0x00026209
		public override bool keepWaiting
		{
			get
			{
				return !this.m_op.isDone;
			}
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x00028019 File Offset: 0x00026219
		public AsyncInstantiateOperation GetOperation()
		{
			return this.m_op;
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x00028019 File Offset: 0x00026219
		public static implicit operator AsyncInstantiateOperation(AsyncInstantiateOperation<T> generic)
		{
			return generic.m_op;
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x00028021 File Offset: 0x00026221
		public bool IsWaitingForSceneActivation()
		{
			return this.m_op.IsWaitingForSceneActivation();
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06001822 RID: 6178 RVA: 0x0002802E File Offset: 0x0002622E
		// (remove) Token: 0x06001823 RID: 6179 RVA: 0x0002803D File Offset: 0x0002623D
		public event Action<AsyncOperation> completed
		{
			add
			{
				this.m_op.completed += value;
			}
			remove
			{
				this.m_op.completed -= value;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001824 RID: 6180 RVA: 0x0002804C File Offset: 0x0002624C
		public bool isDone
		{
			get
			{
				return this.m_op.isDone;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001825 RID: 6181 RVA: 0x00028059 File Offset: 0x00026259
		public float progress
		{
			get
			{
				return this.m_op.progress;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06001826 RID: 6182 RVA: 0x00028066 File Offset: 0x00026266
		// (set) Token: 0x06001827 RID: 6183 RVA: 0x00028073 File Offset: 0x00026273
		public bool allowSceneActivation
		{
			get
			{
				return this.m_op.allowSceneActivation;
			}
			set
			{
				this.m_op.allowSceneActivation = value;
			}
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x00028082 File Offset: 0x00026282
		public void WaitForCompletion()
		{
			this.m_op.WaitForCompletion();
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x00028090 File Offset: 0x00026290
		public void Cancel()
		{
			this.m_op.Cancel();
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x0600182A RID: 6186 RVA: 0x000280A0 File Offset: 0x000262A0
		public unsafe T[] Result
		{
			get
			{
				Object[] result = this.m_op.Result;
				return *UnsafeUtility.As<Object[], T[]>(ref result);
			}
		}

		// Token: 0x04000888 RID: 2184
		internal AsyncInstantiateOperation m_op;
	}
}
