using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000020 RID: 32
	internal class UnknownCommandReplyException : Exception
	{
		// Token: 0x0600009A RID: 154 RVA: 0x00003A4E File Offset: 0x00001C4E
		public UnknownCommandReplyException(uint id) : base(string.Format("Received a command reply with unknown id: {0}", id))
		{
		}
	}
}
