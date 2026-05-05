using System;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000032 RID: 50
	[Serializable]
	internal class DeserializationException : Exception
	{
		// Token: 0x060000CD RID: 205 RVA: 0x00003CA7 File Offset: 0x00001EA7
		public DeserializationException()
		{
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003CAF File Offset: 0x00001EAF
		public DeserializationException(string message) : base(message)
		{
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003CB8 File Offset: 0x00001EB8
		private DeserializationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
