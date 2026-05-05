using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000026 RID: 38
	public class ChannelChangedException : RequestFailedException
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00003AEA File Offset: 0x00001CEA
		public ChannelChangedException(string newAlias, string oldAlias) : base(23005, string.Concat(new string[]
		{
			"The token retriever is not consistent, the alias has changed: ",
			oldAlias,
			"->",
			newAlias,
			"."
		}))
		{
		}
	}
}
