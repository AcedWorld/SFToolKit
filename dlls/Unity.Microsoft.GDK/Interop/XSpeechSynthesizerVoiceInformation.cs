using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200026D RID: 621
	internal struct XSpeechSynthesizerVoiceInformation
	{
		// Token: 0x04000856 RID: 2134
		[MarshalAs(UnmanagedType.LPStr)]
		internal string Description;

		// Token: 0x04000857 RID: 2135
		[MarshalAs(UnmanagedType.LPStr)]
		internal string DisplayName;

		// Token: 0x04000858 RID: 2136
		internal XSpeechSynthesizerVoiceGender Gender;

		// Token: 0x04000859 RID: 2137
		[MarshalAs(UnmanagedType.LPStr)]
		internal string VoiceId;

		// Token: 0x0400085A RID: 2138
		[MarshalAs(UnmanagedType.LPStr)]
		internal string Language;
	}
}
