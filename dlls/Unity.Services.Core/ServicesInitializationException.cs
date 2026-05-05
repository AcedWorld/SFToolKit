using System;

namespace Unity.Services.Core
{
	// Token: 0x02000008 RID: 8
	public class ServicesInitializationException : Exception
	{
		// Token: 0x0600001B RID: 27 RVA: 0x0000227D File Offset: 0x0000047D
		public ServicesInitializationException()
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002285 File Offset: 0x00000485
		public ServicesInitializationException(string message) : base(message)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000228E File Offset: 0x0000048E
		public ServicesInitializationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
