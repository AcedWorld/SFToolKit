using System;
using System.Collections.Generic;

namespace UnityEngine.Pool
{
	// Token: 0x020003C6 RID: 966
	public class ObjectPool<T> : IDisposable, IObjectPool<T> where T : class
	{
		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060020FC RID: 8444 RVA: 0x00036B61 File Offset: 0x00034D61
		// (set) Token: 0x060020FD RID: 8445 RVA: 0x00036B69 File Offset: 0x00034D69
		public int CountAll { get; private set; }

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x060020FE RID: 8446 RVA: 0x00036B74 File Offset: 0x00034D74
		public int CountActive
		{
			get
			{
				return this.CountAll - this.CountInactive;
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x060020FF RID: 8447 RVA: 0x00036B94 File Offset: 0x00034D94
		public int CountInactive
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x06002100 RID: 8448 RVA: 0x00036BB4 File Offset: 0x00034DB4
		public ObjectPool(Func<T> createFunc, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 10000)
		{
			bool flag = createFunc == null;
			if (flag)
			{
				throw new ArgumentNullException("createFunc");
			}
			bool flag2 = maxSize <= 0;
			if (flag2)
			{
				throw new ArgumentException("Max Size must be greater than 0", "maxSize");
			}
			this.m_List = new List<T>(defaultCapacity);
			this.m_CreateFunc = createFunc;
			this.m_MaxSize = maxSize;
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
			this.m_ActionOnDestroy = actionOnDestroy;
			this.m_CollectionCheck = collectionCheck;
		}

		// Token: 0x06002101 RID: 8449 RVA: 0x00036C34 File Offset: 0x00034E34
		public T Get()
		{
			bool flag = this.m_List.Count == 0;
			T t;
			if (flag)
			{
				t = this.m_CreateFunc();
				int countAll = this.CountAll;
				this.CountAll = countAll + 1;
			}
			else
			{
				int index = this.m_List.Count - 1;
				t = this.m_List[index];
				this.m_List.RemoveAt(index);
			}
			Action<T> actionOnGet = this.m_ActionOnGet;
			if (actionOnGet != null)
			{
				actionOnGet(t);
			}
			return t;
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x00036CBC File Offset: 0x00034EBC
		public PooledObject<T> Get(out T v)
		{
			return new PooledObject<T>(v = this.Get(), this);
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x00036CE0 File Offset: 0x00034EE0
		public void Release(T element)
		{
			Action<T> actionOnRelease = this.m_ActionOnRelease;
			if (actionOnRelease != null)
			{
				actionOnRelease(element);
			}
			bool flag = this.CountInactive < this.m_MaxSize;
			if (flag)
			{
				this.m_List.Add(element);
			}
			else
			{
				int countAll = this.CountAll;
				this.CountAll = countAll - 1;
				Action<T> actionOnDestroy = this.m_ActionOnDestroy;
				if (actionOnDestroy != null)
				{
					actionOnDestroy(element);
				}
			}
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x00036D4C File Offset: 0x00034F4C
		public void Clear()
		{
			bool flag = this.m_ActionOnDestroy != null;
			if (flag)
			{
				foreach (T obj in this.m_List)
				{
					this.m_ActionOnDestroy(obj);
				}
			}
			this.m_List.Clear();
			this.CountAll = 0;
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x00036DD0 File Offset: 0x00034FD0
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x04000AE3 RID: 2787
		internal readonly List<T> m_List;

		// Token: 0x04000AE4 RID: 2788
		private readonly Func<T> m_CreateFunc;

		// Token: 0x04000AE5 RID: 2789
		private readonly Action<T> m_ActionOnGet;

		// Token: 0x04000AE6 RID: 2790
		private readonly Action<T> m_ActionOnRelease;

		// Token: 0x04000AE7 RID: 2791
		private readonly Action<T> m_ActionOnDestroy;

		// Token: 0x04000AE8 RID: 2792
		private readonly int m_MaxSize;

		// Token: 0x04000AE9 RID: 2793
		internal bool m_CollectionCheck;
	}
}
