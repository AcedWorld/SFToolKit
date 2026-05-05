using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000052 RID: 82
	public sealed class ListChangedEventArgs<T> : EventArgs
	{
		// Token: 0x060002AB RID: 683 RVA: 0x0000C2EE File Offset: 0x0000A4EE
		public ListChangedEventArgs(int index, T item)
		{
			this.index = index;
			this.item = item;
		}

		// Token: 0x0400019E RID: 414
		public readonly int index;

		// Token: 0x0400019F RID: 415
		public readonly T item;
	}
}
