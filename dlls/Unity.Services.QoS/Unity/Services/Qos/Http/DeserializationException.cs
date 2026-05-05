using System;

namespace Unity.Services.Qos.Http
{
	// Token: 0x0200005C RID: 92
	[Serializable]
	internal class DeserializationException : Exception
	{
		// Token: 0x060001AB RID: 427 RVA: 0x00006C06 File Offset: 0x00004E06
		public DeserializationException()
		{
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00006C0E File Offset: 0x00004E0E
		public DeserializationException(string message) : base(message)
		{
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00006C17 File Offset: 0x00004E17
		private DeserializationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
