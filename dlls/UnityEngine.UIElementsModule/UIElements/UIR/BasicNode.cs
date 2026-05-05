using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200044C RID: 1100
	internal class BasicNode<T> : LinkedPoolItem<BasicNode<T>>
	{
		// Token: 0x0600227C RID: 8828 RVA: 0x00084B08 File Offset: 0x00082D08
		public void InsertFirst(ref BasicNode<T> first)
		{
			bool flag = first == null;
			if (flag)
			{
				first = this;
			}
			else
			{
				this.next = first.next;
				first.next = this;
			}
		}

		// Token: 0x04000F66 RID: 3942
		public BasicNode<T> next;

		// Token: 0x04000F67 RID: 3943
		public T data;
	}
}
