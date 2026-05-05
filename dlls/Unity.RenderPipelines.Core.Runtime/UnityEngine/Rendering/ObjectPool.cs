using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.Rendering
{
	// Token: 0x0200004C RID: 76
	public class ObjectPool<T> where T : new()
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000C0C3 File Offset: 0x0000A2C3
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000C0CB File Offset: 0x0000A2CB
		public int countAll { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
		public int countActive
		{
			get
			{
				return this.countAll - this.countInactive;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000C0E3 File Offset: 0x0000A2E3
		public int countInactive
		{
			get
			{
				return this.m_Stack.Count;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000C0F0 File Offset: 0x0000A2F0
		public ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease, bool collectionCheck = true)
		{
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
			this.m_CollectionCheck = collectionCheck;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000C120 File Offset: 0x0000A320
		public T Get()
		{
			T t;
			if (this.m_Stack.Count == 0)
			{
				t = Activator.CreateInstance<T>();
				int countAll = this.countAll;
				this.countAll = countAll + 1;
			}
			else
			{
				t = this.m_Stack.Pop();
			}
			if (this.m_ActionOnGet != null)
			{
				this.m_ActionOnGet(t);
			}
			return t;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000C174 File Offset: 0x0000A374
		public ObjectPool<T>.PooledObject Get(out T v)
		{
			return new ObjectPool<T>.PooledObject(v = this.Get(), this);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000C196 File Offset: 0x0000A396
		public void Release(T element)
		{
			if (this.m_ActionOnRelease != null)
			{
				this.m_ActionOnRelease(element);
			}
			this.m_Stack.Push(element);
		}

		// Token: 0x04000194 RID: 404
		private readonly Stack<T> m_Stack = new Stack<T>();

		// Token: 0x04000195 RID: 405
		private readonly UnityAction<T> m_ActionOnGet;

		// Token: 0x04000196 RID: 406
		private readonly UnityAction<T> m_ActionOnRelease;

		// Token: 0x04000197 RID: 407
		private readonly bool m_CollectionCheck = true;

		// Token: 0x0200015D RID: 349
		public struct PooledObject : IDisposable
		{
			// Token: 0x060009E3 RID: 2531 RVA: 0x0002BFAD File Offset: 0x0002A1AD
			internal PooledObject(T value, ObjectPool<T> pool)
			{
				this.m_ToReturn = value;
				this.m_Pool = pool;
			}

			// Token: 0x060009E4 RID: 2532 RVA: 0x0002BFBD File Offset: 0x0002A1BD
			void IDisposable.Dispose()
			{
				this.m_Pool.Release(this.m_ToReturn);
			}

			// Token: 0x040005EF RID: 1519
			private readonly T m_ToReturn;

			// Token: 0x040005F0 RID: 1520
			private readonly ObjectPool<T> m_Pool;
		}
	}
}
