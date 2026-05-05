using System;

namespace Unity.Netcode
{
	// Token: 0x02000043 RID: 67
	public class NotListeningException : Exception
	{
		// Token: 0x060001FC RID: 508 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public NotListeningException()
		{
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000519D File Offset: 0x0000339D
		public NotListeningException(string message) : base(message)
		{
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000AC05 File Offset: 0x00008E05
		public NotListeningException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
