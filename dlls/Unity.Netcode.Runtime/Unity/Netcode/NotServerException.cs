using System;

namespace Unity.Netcode
{
	// Token: 0x02000044 RID: 68
	public class NotServerException : Exception
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public NotServerException()
		{
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000519D File Offset: 0x0000339D
		public NotServerException(string message) : base(message)
		{
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000AC05 File Offset: 0x00008E05
		public NotServerException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
