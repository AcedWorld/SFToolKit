using System;

namespace UnityEngine.Windows.Speech
{
	// Token: 0x020002D3 RID: 723
	public enum SpeechError
	{
		// Token: 0x04000A06 RID: 2566
		NoError,
		// Token: 0x04000A07 RID: 2567
		TopicLanguageNotSupported,
		// Token: 0x04000A08 RID: 2568
		GrammarLanguageMismatch,
		// Token: 0x04000A09 RID: 2569
		GrammarCompilationFailure,
		// Token: 0x04000A0A RID: 2570
		AudioQualityFailure,
		// Token: 0x04000A0B RID: 2571
		PauseLimitExceeded,
		// Token: 0x04000A0C RID: 2572
		TimeoutExceeded,
		// Token: 0x04000A0D RID: 2573
		NetworkFailure,
		// Token: 0x04000A0E RID: 2574
		MicrophoneUnavailable,
		// Token: 0x04000A0F RID: 2575
		UnknownError
	}
}
