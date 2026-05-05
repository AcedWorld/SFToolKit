using System;

namespace UnityEngine.Windows.Speech
{
	// Token: 0x020002D5 RID: 725
	public enum DictationCompletionCause
	{
		// Token: 0x04000A15 RID: 2581
		Complete,
		// Token: 0x04000A16 RID: 2582
		AudioQualityFailure,
		// Token: 0x04000A17 RID: 2583
		Canceled,
		// Token: 0x04000A18 RID: 2584
		TimeoutExceeded,
		// Token: 0x04000A19 RID: 2585
		PauseLimitExceeded,
		// Token: 0x04000A1A RID: 2586
		NetworkFailure,
		// Token: 0x04000A1B RID: 2587
		MicrophoneUnavailable,
		// Token: 0x04000A1C RID: 2588
		UnknownError
	}
}
