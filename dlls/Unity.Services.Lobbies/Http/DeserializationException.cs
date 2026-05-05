using System;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class DeserializationException : Exception
	{
		// Token: 0x0600020E RID: 526 RVA: 0x0000828B File Offset: 0x0000648B
		public DeserializationException()
		{
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00008293 File Offset: 0x00006493
		public DeserializationException(string message) : base(message)
		{
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000829C File Offset: 0x0000649C
		private DeserializationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
