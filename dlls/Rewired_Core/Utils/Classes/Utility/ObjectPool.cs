using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D6 RID: 1238
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectPool<T> : IObjectPool, IObjectPool<T> where T : class
	{
		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x060031AA RID: 12714 RVA: 0x00026082 File Offset: 0x00024282
		protected ulong InstanceCount
		{
			get
			{
				return this.XWmwpNRiYgWRqIAmUNfArkjYOsDw;
			}
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x0002608A File Offset: 0x0002428A
		public ObjectPool(int A_1, Func<T> A_2, Action<T> A_3 = null)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("instancerDelegate");
			}
			this._processOnReturnDelegate = A_3;
			this._pool = ((A_1 > 0) ? new Queue<T>(A_1) : new Queue<T>());
			this._createInstanceDelegate = A_2;
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x000260C5 File Offset: 0x000242C5
		public ObjectPool(Func<T> A_1) : this(0, A_1, null)
		{
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x000ACC18 File Offset: 0x000AAE18
		public void Clear(bool reduceSize = false)
		{
			Queue<T> pool = this._pool;
			lock (pool)
			{
				this._pool.Clear();
				if (reduceSize)
				{
					this._pool.TrimExcess();
				}
			}
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x000ACC6C File Offset: 0x000AAE6C
		public T Get()
		{
			Queue<T> pool = this._pool;
			T result;
			lock (pool)
			{
				if (this._pool.Count == 0)
				{
					result = this.CreateInstance();
				}
				else
				{
					T t = this._pool.Dequeue();
					if (t is IPoolableObject_Internal)
					{
						(t as IPoolableObject_Internal).pool = this;
					}
					result = t;
				}
			}
			return result;
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x000ACCEC File Offset: 0x000AAEEC
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
			Queue<T> pool = this._pool;
			lock (pool)
			{
				this._pool.Enqueue(item);
			}
			return true;
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x000260D0 File Offset: 0x000242D0
		object IObjectPool.hRblHkVadMsCIygkmlrxraQheORJ()
		{
			return this.Get();
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x000260DD File Offset: 0x000242DD
		bool IObjectPool.OqppMVRXprgrVMHlLOHIfPxMuRcB(object A_1)
		{
			return this.Return(A_1 as T);
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x000ACD70 File Offset: 0x000AAF70
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

		// Token: 0x060031B3 RID: 12723 RVA: 0x000260F0 File Offset: 0x000242F0
		protected ulong IncrementInstanceCount()
		{
			this.XWmwpNRiYgWRqIAmUNfArkjYOsDw = ((this.XWmwpNRiYgWRqIAmUNfArkjYOsDw < ulong.MaxValue) ? (this.XWmwpNRiYgWRqIAmUNfArkjYOsDw + 1UL) : 0UL);
			return this.XWmwpNRiYgWRqIAmUNfArkjYOsDw;
		}

		// Token: 0x04001B3F RID: 6975
		protected readonly Queue<T> _pool;

		// Token: 0x04001B40 RID: 6976
		protected readonly Func<T> _createInstanceDelegate;

		// Token: 0x04001B41 RID: 6977
		protected readonly Action<T> _processOnReturnDelegate;

		// Token: 0x04001B42 RID: 6978
		private ulong XWmwpNRiYgWRqIAmUNfArkjYOsDw;
	}
}
