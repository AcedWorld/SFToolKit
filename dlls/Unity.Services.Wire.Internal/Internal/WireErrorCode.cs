using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200003A RID: 58
	public enum WireErrorCode
	{
		// Token: 0x040000B2 RID: 178
		Unknown = 23000,
		// Token: 0x040000B3 RID: 179
		CommandFailed = 23002,
		// Token: 0x040000B4 RID: 180
		ConnectionFailed,
		// Token: 0x040000B5 RID: 181
		InvalidToken,
		// Token: 0x040000B6 RID: 182
		InvalidChannelName,
		// Token: 0x040000B7 RID: 183
		TokenRetrieverFailed,
		// Token: 0x040000B8 RID: 184
		Unauthorized,
		// Token: 0x040000B9 RID: 185
		AlreadySubscribed,
		// Token: 0x040000BA RID: 186
		AlreadyUnsubscribed
	}
}
