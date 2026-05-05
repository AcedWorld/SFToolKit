using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000160 RID: 352
	public class Recursion<T> : IPoolable, IDisposable
	{
		// Token: 0x0600094F RID: 2383 RVA: 0x000283D4 File Offset: 0x000265D4
		protected Recursion()
		{
			this.traversedOrder = new Stack<T>();
			this.traversedCount = new Dictionary<T, int>();
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000283F2 File Offset: 0x000265F2
		public void Enter(T o)
		{
			if (!this.TryEnter(o))
			{
				throw new StackOverflowException(string.Format("Max recursion depth of {0} has been exceeded. Consider increasing '{1}.{2}'.", this.maxDepth, "Recursion", "defaultMaxDepth"));
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00028424 File Offset: 0x00026624
		public bool TryEnter(T o)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(this.ToString());
			}
			int num;
			if (!this.traversedCount.TryGetValue(o, out num))
			{
				this.traversedOrder.Push(o);
				this.traversedCount.Add(o, 1);
				return true;
			}
			if (num < this.maxDepth)
			{
				this.traversedOrder.Push(o);
				Dictionary<T, int> dictionary = this.traversedCount;
				int num2 = dictionary[o];
				dictionary[o] = num2 + 1;
				return true;
			}
			return false;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x000284A4 File Offset: 0x000266A4
		public void Exit(T o)
		{
			if (this.traversedOrder.Count == 0)
			{
				throw new InvalidOperationException("Trying to exit an empty recursion stack.");
			}
			T t = this.traversedOrder.Peek();
			if (!EqualityComparer<T>.Default.Equals(o, t))
			{
				throw new InvalidOperationException(string.Format("Exiting recursion stack in a non-consecutive order:\nProvided: {0} / Expected: {1}", o, t));
			}
			this.traversedOrder.Pop();
			Dictionary<T, int> dictionary = this.traversedCount;
			T key = t;
			int num = dictionary[key];
			dictionary[key] = num - 1;
			if (num == 0)
			{
				this.traversedCount.Remove(t);
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00028534 File Offset: 0x00026734
		public void Dispose()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(this.ToString());
			}
			this.Free();
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00028550 File Offset: 0x00026750
		protected virtual void Free()
		{
			GenericPool<Recursion<T>>.Free(this);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00028558 File Offset: 0x00026758
		void IPoolable.New()
		{
			this.disposed = false;
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00028561 File Offset: 0x00026761
		void IPoolable.Free()
		{
			this.disposed = true;
			this.traversedCount.Clear();
			this.traversedOrder.Clear();
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00028580 File Offset: 0x00026780
		public static Recursion<T> New()
		{
			return Recursion<T>.New(Recursion.defaultMaxDepth);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0002858C File Offset: 0x0002678C
		public static Recursion<T> New(int maxDepth)
		{
			if (!Recursion.safeMode)
			{
				return null;
			}
			if (maxDepth < 1)
			{
				throw new ArgumentException("Max recursion depth must be at least one.", "maxDepth");
			}
			Recursion<T> recursion = GenericPool<Recursion<T>>.New(() => new Recursion<T>());
			recursion.maxDepth = maxDepth;
			return recursion;
		}

		// Token: 0x04000237 RID: 567
		private readonly Stack<T> traversedOrder;

		// Token: 0x04000238 RID: 568
		private readonly Dictionary<T, int> traversedCount;

		// Token: 0x04000239 RID: 569
		private bool disposed;

		// Token: 0x0400023A RID: 570
		protected int maxDepth;
	}
}
