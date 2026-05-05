using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000025 RID: 37
	public class EmptyTokenException : RequestFailedException
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x00003AD8 File Offset: 0x00001CD8
		public EmptyTokenException() : base(23004, "The token provided by the token provider is empty or null.")
		{
		}
	}
}
