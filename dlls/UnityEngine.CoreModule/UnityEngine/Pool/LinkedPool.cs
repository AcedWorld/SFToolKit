using System;

namespace UnityEngine.Pool
{
	// Token: 0x020003C4 RID: 964
	public class LinkedPool<T> : IDisposable, IObjectPool<T> where T : class
	{
		// Token: 0x060020F3 RID: 8435 RVA: 0x00036910 File Offset: 0x00034B10
		public LinkedPool(Func<T> createFunc, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, bool collectionCheck = true, int maxSize = 10000)
		{
			bool flag = createFunc == null;
			if (flag)
			{
				throw new ArgumentNullException("createFunc");
			}
			bool flag2 = maxSize <= 0;
			if (flag2)
			{
				throw new ArgumentException("maxSize", "Max size must be greater than 0");
			}
			this.m_CreateFunc = createFunc;
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
			this.m_ActionOnDestroy = actionOnDestroy;
			this.m_Limit = maxSize;
			this.m_CollectionCheck = collectionCheck;
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060020F4 RID: 8436 RVA: 0x00036981 File Offset: 0x00034B81
		// (set) Token: 0x060020F5 RID: 8437 RVA: 0x00036989 File Offset: 0x00034B89
		public int CountInactive { get; private set; }

		// Token: 0x060020F6 RID: 8438 RVA: 0x00036994 File Offset: 0x00034B94
		public T Get()
		{
			T t = default(T);
			bool flag = this.m_PoolFirst == null;
			if (flag)
			{
				t = this.m_CreateFunc();
			}
			else
			{
				LinkedPool<T>.LinkedPoolItem poolFirst = this.m_PoolFirst;
				t = poolFirst.value;
				this.m_PoolFirst = poolFirst.poolNext;
				poolFirst.poolNext = this.m_NextAvailableListItem;
				this.m_NextAvailableListItem = poolFirst;
				this.m_NextAvailableListItem.value = default(T);
				int countInactive = this.CountInactive - 1;
				this.CountInactive = countInactive;
			}
			Action<T> actionOnGet = this.m_ActionOnGet;
			if (actionOnGet != null)
			{
				actionOnGet(t);
			}
			return t;
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x00036A34 File Offset: 0x00034C34
		public PooledObject<T> Get(out T v)
		{
			return new PooledObject<T>(v = this.Get(), this);
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x00036A58 File Offset: 0x00034C58
		public void Release(T item)
		{
			Action<T> actionOnRelease = this.m_ActionOnRelease;
			if (actionOnRelease != null)
			{
				actionOnRelease(item);
			}
			bool flag = this.CountInactive < this.m_Limit;
			if (flag)
			{
				LinkedPool<T>.LinkedPoolItem linkedPoolItem = this.m_NextAvailableListItem;
				bool flag2 = linkedPoolItem == null;
				if (flag2)
				{
					linkedPoolItem = new LinkedPool<T>.LinkedPoolItem();
				}
				else
				{
					this.m_NextAvailableListItem = linkedPoolItem.poolNext;
				}
				linkedPoolItem.value = item;
				linkedPoolItem.poolNext = this.m_PoolFirst;
				this.m_PoolFirst = linkedPoolItem;
				int countInactive = this.CountInactive + 1;
				this.CountInactive = countInactive;
			}
			else
			{
				Action<T> actionOnDestroy = this.m_ActionOnDestroy;
				if (actionOnDestroy != null)
				{
					actionOnDestroy(item);
				}
			}
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x00036AF8 File Offset: 0x00034CF8
		public void Clear()
		{
			bool flag = this.m_ActionOnDestroy != null;
			if (flag)
			{
				for (LinkedPool<T>.LinkedPoolItem linkedPoolItem = this.m_PoolFirst; linkedPoolItem != null; linkedPoolItem = linkedPoolItem.poolNext)
				{
					this.m_ActionOnDestroy(linkedPoolItem.value);
				}
			}
			this.m_PoolFirst = null;
			this.m_NextAvailableListItem = null;
			this.CountInactive = 0;
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x00036B57 File Offset: 0x00034D57
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x04000AD8 RID: 2776
		private readonly Func<T> m_CreateFunc;

		// Token: 0x04000AD9 RID: 2777
		private readonly Action<T> m_ActionOnGet;

		// Token: 0x04000ADA RID: 2778
		private readonly Action<T> m_ActionOnRelease;

		// Token: 0x04000ADB RID: 2779
		private readonly Action<T> m_ActionOnDestroy;

		// Token: 0x04000ADC RID: 2780
		private readonly int m_Limit;

		// Token: 0x04000ADD RID: 2781
		internal LinkedPool<T>.LinkedPoolItem m_PoolFirst;

		// Token: 0x04000ADE RID: 2782
		internal LinkedPool<T>.LinkedPoolItem m_NextAvailableListItem;

		// Token: 0x04000ADF RID: 2783
		private bool m_CollectionCheck;

		// Token: 0x020003C5 RID: 965
		internal class LinkedPoolItem
		{
			// Token: 0x04000AE1 RID: 2785
			internal LinkedPool<T>.LinkedPoolItem poolNext;

			// Token: 0x04000AE2 RID: 2786
			internal T value;
		}
	}
}
