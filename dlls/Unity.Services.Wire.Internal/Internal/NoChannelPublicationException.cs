using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001D RID: 29
	internal class NoChannelPublicationException : Exception
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00003A06 File Offset: 0x00001C06
		public NoChannelPublicationException(string originalData) : base("can't parse publication's channel: " + originalData)
		{
		}
	}
}
