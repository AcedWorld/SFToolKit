using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000288 RID: 648
	internal class ObjectPool<T> where T : new()
	{
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00041238 File Offset: 0x0003F438
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x00041250 File Offset: 0x0003F450
		public int maxSize
		{
			get
			{
				return this.m_MaxSize;
			}
			set
			{
				this.m_MaxSize = Math.Max(0, value);
				while (this.Size() > this.m_MaxSize)
				{
					this.Get();
				}
			}
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x00041288 File Offset: 0x0003F488
		public ObjectPool(Func<T> CreateFunc, int maxSize = 100)
		{
			this.maxSize = maxSize;
			bool flag = CreateFunc == null;
			if (flag)
			{
				this.CreateFunc = (() => Activator.CreateInstance<T>());
			}
			else
			{
				this.CreateFunc = CreateFunc;
			}
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x000412EC File Offset: 0x0003F4EC
		public int Size()
		{
			return this.m_Stack.Count;
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x00041309 File Offset: 0x0003F509
		public void Clear()
		{
			this.m_Stack.Clear();
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00041318 File Offset: 0x0003F518
		public T Get()
		{
			return (this.m_Stack.Count == 0) ? this.CreateFunc() : this.m_Stack.Pop();
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x00041354 File Offset: 0x0003F554
		public void Release(T element)
		{
			bool flag = this.m_Stack.Count > 0 && this.m_Stack.Peek() == element;
			if (flag)
			{
				Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
			}
			bool flag2 = this.m_Stack.Count < this.maxSize;
			if (flag2)
			{
				this.m_Stack.Push(element);
			}
		}

		// Token: 0x04000837 RID: 2103
		private readonly Stack<T> m_Stack = new Stack<T>();

		// Token: 0x04000838 RID: 2104
		private int m_MaxSize;

		// Token: 0x04000839 RID: 2105
		internal Func<T> CreateFunc;
	}
}
