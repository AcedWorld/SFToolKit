using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200044D RID: 1101
	internal class BasicNodePool<T> : LinkedPool<BasicNode<T>>
	{
		// Token: 0x0600227E RID: 8830 RVA: 0x00084B43 File Offset: 0x00082D43
		private static void Reset(BasicNode<T> node)
		{
			node.next = null;
			node.data = default(T);
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x00084B5C File Offset: 0x00082D5C
		private static BasicNode<T> Create()
		{
			return new BasicNode<T>();
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x00084B73 File Offset: 0x00082D73
		public BasicNodePool() : base(new Func<BasicNode<T>>(BasicNodePool<T>.Create), new Action<BasicNode<T>>(BasicNodePool<T>.Reset), 10000)
		{
		}
	}
}
