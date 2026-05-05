using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000023 RID: 35
	internal class CommandAlreadyExists : Exception
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00003AAE File Offset: 0x00001CAE
		public CommandAlreadyExists(uint id) : base(string.Format("Command already exists (id: {0})", id))
		{
		}
	}
}
