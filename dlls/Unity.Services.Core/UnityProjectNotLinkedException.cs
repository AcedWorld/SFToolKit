using System;

namespace Unity.Services.Core
{
	// Token: 0x0200000A RID: 10
	internal class UnityProjectNotLinkedException : ServicesInitializationException
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00002298 File Offset: 0x00000498
		public UnityProjectNotLinkedException()
		{
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022A0 File Offset: 0x000004A0
		public UnityProjectNotLinkedException(string message) : base(message)
		{
		}
	}
}
