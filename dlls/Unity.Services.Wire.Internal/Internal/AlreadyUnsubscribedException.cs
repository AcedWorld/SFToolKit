using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001F RID: 31
	public class AlreadyUnsubscribedException : RequestFailedException
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00003A36 File Offset: 0x00001C36
		public AlreadyUnsubscribedException(string alias) : base(23009, "Already unsubscribed from " + alias)
		{
		}
	}
}
