using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000020 RID: 32
	public struct NoAllocEnumerator<T> : IEnumerator<!0>, IEnumerator, IDisposable
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x000039B6 File Offset: 0x00001BB6
		public NoAllocEnumerator(IList<T> list)
		{
			this = default(NoAllocEnumerator<T>);
			this.list = list;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000039C6 File Offset: 0x00001BC6
		public void Dispose()
		{
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000039C8 File Offset: 0x00001BC8
		public bool MoveNext()
		{
			if (this.index < this.list.Count)
			{
				this.current = this.list[this.index];
				this.index++;
				return true;
			}
			this.index = this.list.Count + 1;
			this.current = default(T);
			this.exceeded = true;
			return false;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00003A36 File Offset: 0x00001C36
		public T Current
		{
			get
			{
				return this.current;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00003A3E File Offset: 0x00001C3E
		object IEnumerator.Current
		{
			get
			{
				if (this.exceeded)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003A59 File Offset: 0x00001C59
		void IEnumerator.Reset()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x0400001A RID: 26
		private readonly IList<T> list;

		// Token: 0x0400001B RID: 27
		private int index;

		// Token: 0x0400001C RID: 28
		private T current;

		// Token: 0x0400001D RID: 29
		private bool exceeded;
	}
}
