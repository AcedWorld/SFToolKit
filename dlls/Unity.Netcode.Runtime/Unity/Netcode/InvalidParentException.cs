using System;

namespace Unity.Netcode
{
	// Token: 0x02000041 RID: 65
	public class InvalidParentException : Exception
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public InvalidParentException()
		{
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000519D File Offset: 0x0000339D
		public InvalidParentException(string message) : base(message)
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000AC05 File Offset: 0x00008E05
		public InvalidParentException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
