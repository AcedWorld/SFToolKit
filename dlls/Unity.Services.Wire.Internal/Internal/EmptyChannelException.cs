using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000024 RID: 36
	public class EmptyChannelException : RequestFailedException
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00003AC6 File Offset: 0x00001CC6
		public EmptyChannelException() : base(23005, "The channel provided by the token provider is empty or null.")
		{
		}
	}
}
