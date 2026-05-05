using System;

namespace Unity.Netcode
{
	// Token: 0x02000078 RID: 120
	internal class HandlerNotRegisteredException : SystemException
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x0000E6F9 File Offset: 0x0000C8F9
		public HandlerNotRegisteredException()
		{
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000E701 File Offset: 0x0000C901
		public HandlerNotRegisteredException(string issue) : base(issue)
		{
		}
	}
}
