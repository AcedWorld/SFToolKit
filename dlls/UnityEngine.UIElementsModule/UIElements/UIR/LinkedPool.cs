using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200044B RID: 1099
	internal class LinkedPool<T> where T : LinkedPoolItem<T>
	{
		// Token: 0x06002276 RID: 8822 RVA: 0x000849EB File Offset: 0x00082BEB
		public LinkedPool(Func<T> createFunc, Action<T> resetAction, int limit = 10000)
		{
			Debug.Assert(createFunc != null);
			this.m_CreateFunc = createFunc;
			Debug.Assert(resetAction != null);
			this.m_ResetAction = resetAction;
			Debug.Assert(limit > 0);
			this.m_Limit = limit;
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06002277 RID: 8823 RVA: 0x00084A28 File Offset: 0x00082C28
		// (set) Token: 0x06002278 RID: 8824 RVA: 0x00084A30 File Offset: 0x00082C30
		public int Count { get; private set; }

		// Token: 0x06002279 RID: 8825 RVA: 0x00084A39 File Offset: 0x00082C39
		public void Clear()
		{
			this.m_PoolFirst = default(T);
			this.Count = 0;
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x00084A50 File Offset: 0x00082C50
		public T Get()
		{
			T t = this.m_PoolFirst;
			bool flag = this.m_PoolFirst != null;
			if (flag)
			{
				int count = this.Count - 1;
				this.Count = count;
				this.m_PoolFirst = t.poolNext;
				this.m_ResetAction(t);
			}
			else
			{
				t = this.m_CreateFunc();
			}
			return t;
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x00084ABC File Offset: 0x00082CBC
		public void Return(T item)
		{
			bool flag = this.Count < this.m_Limit;
			if (flag)
			{
				item.poolNext = this.m_PoolFirst;
				this.m_PoolFirst = item;
				int count = this.Count + 1;
				this.Count = count;
			}
		}

		// Token: 0x04000F61 RID: 3937
		private readonly Func<T> m_CreateFunc;

		// Token: 0x04000F62 RID: 3938
		private readonly Action<T> m_ResetAction;

		// Token: 0x04000F63 RID: 3939
		private readonly int m_Limit;

		// Token: 0x04000F64 RID: 3940
		private T m_PoolFirst;
	}
}
