using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000022 RID: 34
	internal class CommandNotFoundException : Exception
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003A96 File Offset: 0x00001C96
		public CommandNotFoundException(uint id) : base(string.Format("Command not found (id: {0})", id))
		{
		}
	}
}
