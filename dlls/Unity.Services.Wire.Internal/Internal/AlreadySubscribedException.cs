using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001E RID: 30
	public class AlreadySubscribedException : RequestFailedException
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00003A19 File Offset: 0x00001C19
		public AlreadySubscribedException(string alias) : base(23008, "Already subscribed to " + alias + ".")
		{
		}
	}
}
