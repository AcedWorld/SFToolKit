using System;

namespace Unity.Netcode
{
	// Token: 0x02000079 RID: 121
	internal class InvalidMessageStructureException : SystemException
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0000E6F9 File Offset: 0x0000C8F9
		public InvalidMessageStructureException()
		{
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000E701 File Offset: 0x0000C901
		public InvalidMessageStructureException(string issue) : base(issue)
		{
		}
	}
}
