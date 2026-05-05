using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000066 RID: 102
	public sealed class GraphPointerException : Exception
	{
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000892D File Offset: 0x00006B2D
		public GraphPointer pointer { get; }

		// Token: 0x0600034D RID: 845 RVA: 0x00008935 File Offset: 0x00006B35
		public GraphPointerException(string message, GraphPointer pointer) : base(message + "\n" + ((pointer != null) ? pointer.ToString() : null))
		{
			this.pointer = pointer;
		}
	}
}
