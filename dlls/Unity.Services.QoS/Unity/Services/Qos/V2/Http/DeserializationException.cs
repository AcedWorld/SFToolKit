using System;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	internal class DeserializationException : Exception
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x0000476E File Offset: 0x0000296E
		public DeserializationException()
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004776 File Offset: 0x00002976
		public DeserializationException(string message) : base(message)
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000477F File Offset: 0x0000297F
		private DeserializationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
