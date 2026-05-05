using System;

namespace Unity.Netcode
{
	// Token: 0x02000047 RID: 71
	public class VisibilityChangeException : Exception
	{
		// Token: 0x06000206 RID: 518 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public VisibilityChangeException()
		{
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000519D File Offset: 0x0000339D
		public VisibilityChangeException(string message) : base(message)
		{
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000AC05 File Offset: 0x00008E05
		public VisibilityChangeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
