using System;
using System.Collections.Generic;
using System.Threading;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D7 RID: 1239
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadSafeObjectPool<T> : IObjectPool, IObjectPool<!0> where T : class
	{
		// Token: 0x17000B3E RID: 2878
		// (get) Token: 0x060031B4 RID: 12724 RVA: 0x00026115 File Offset: 0x00024315
		protected ulong InstanceCount
		{
			get
			{
				return this.rSnbDRmVctjBhXMQlFzhvKGEBrBAA;
			}
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x0002611D File Offset: 0x0002431D
		public ThreadSafeObjectPool(int A_1, Func<T> A_2, Action<T> A_3 = null)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("instancerDelegate");
			}
			this._processOnReturnDelegate = A_3;
			this._pool = ((A_1 > 0) ? new AList<T>(A_1) : new AList<T>());
			this._createInstanceDelegate = A_2;
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x00026158 File Offset: 0x00024358
		public ThreadSafeObjectPool(Func<T> A_1) : this(0, A_1, null)
		{
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x00026163 File Offset: 0x00024363
		public void Clear(bool reduceSize = false)
		{
			while (Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			this._pool.Clear();
			if (reduceSize)
			{
				this._pool.TrimExcess();
			}
			Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 0);
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x000ACDB0 File Offset: 0x000AAFB0
		public T Get()
		{
			while (Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			if (this._pool._count == 0)
			{
				T result = this.CreateInstance();
				Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 0);
				return result;
			}
			this._pool._count--;
			T t = this._pool._items[this._pool._count];
			this._pool._items[this._pool._count] = default(T);
			if (t is IPoolableObject_Internal)
			{
				(t as IPoolableObject_Internal).pool = this;
			}
			Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 0);
			return t;
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x000ACE7C File Offset: 0x000AB07C
		public bool Return(T item)
		{
			if (item == null)
			{
				return false;
			}
			if (this._processOnReturnDelegate != null)
			{
				this._processOnReturnDelegate(item);
			}
			if (item is IPoolableObject_Internal)
			{
				(item as IPoolableObject_Internal).Clear();
			}
			while (Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			if (this._pool._count < this._pool._items.Length)
			{
				this._pool._items[this._pool._count] = item;
				this._pool._count++;
			}
			else
			{
				this._pool.Add(item);
			}
			Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 0);
			return true;
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x000ACF44 File Offset: 0x000AB144
		public bool Return(IList<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			int count = items.Count;
			bool result = false;
			Action<T> processOnReturnDelegate = this._processOnReturnDelegate;
			while (Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			for (int i = 0; i < count; i++)
			{
				T t = items[i];
				if (t != null)
				{
					if (processOnReturnDelegate != null)
					{
						processOnReturnDelegate(t);
					}
					if (t is IPoolableObject_Internal)
					{
						(t as IPoolableObject_Internal).Clear();
					}
					if (this._pool._count < this._pool._items.Length)
					{
						this._pool._items[this._pool._count] = t;
						this._pool._count++;
					}
					else
					{
						this._pool.Add(t);
					}
				}
			}
			Interlocked.Exchange(ref this.LZhMsJzBfXguNtGdsgwzLseVhwAgA, 0);
			items.Clear();
			return result;
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x000261A1 File Offset: 0x000243A1
		object IObjectPool.oTclJTtbOZFgHpzLzqsqIJlGIzyP()
		{
			return this.Get();
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x000261AE File Offset: 0x000243AE
		bool IObjectPool.TaIZdMJilqkdTpKbNYUMWGXxABwkA(object A_1)
		{
			return this.Return(A_1 as T);
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x000AD04C File Offset: 0x000AB24C
		protected T CreateInstance()
		{
			T t = this._createInstanceDelegate();
			if (t is IPoolableObject_Internal)
			{
				(t as IPoolableObject_Internal).pool = this;
			}
			this.IncrementInstanceCount();
			return t;
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x000261C1 File Offset: 0x000243C1
		protected ulong IncrementInstanceCount()
		{
			this.rSnbDRmVctjBhXMQlFzhvKGEBrBAA = ((this.rSnbDRmVctjBhXMQlFzhvKGEBrBAA < ulong.MaxValue) ? (this.rSnbDRmVctjBhXMQlFzhvKGEBrBAA + 1UL) : 0UL);
			return this.rSnbDRmVctjBhXMQlFzhvKGEBrBAA;
		}

		// Token: 0x04001B43 RID: 6979
		private const int jTrtJyqIrYuvqCqLQuUTZinFHHYR = 1;

		// Token: 0x04001B44 RID: 6980
		private const int eyQAIUzDCXmdeiBNiuTaQUrLbPWI = 0;

		// Token: 0x04001B45 RID: 6981
		protected readonly AList<T> _pool;

		// Token: 0x04001B46 RID: 6982
		protected readonly Func<T> _createInstanceDelegate;

		// Token: 0x04001B47 RID: 6983
		protected readonly Action<T> _processOnReturnDelegate;

		// Token: 0x04001B48 RID: 6984
		private ulong rSnbDRmVctjBhXMQlFzhvKGEBrBAA;

		// Token: 0x04001B49 RID: 6985
		private int LZhMsJzBfXguNtGdsgwzLseVhwAgA;
	}
}
