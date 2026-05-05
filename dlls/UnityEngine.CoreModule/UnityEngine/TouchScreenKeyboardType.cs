using System;

namespace UnityEngine
{
	// Token: 0x02000295 RID: 661
	public enum TouchScreenKeyboardType
	{
		// Token: 0x0400095A RID: 2394
		Default,
		// Token: 0x0400095B RID: 2395
		ASCIICapable,
		// Token: 0x0400095C RID: 2396
		NumbersAndPunctuation,
		// Token: 0x0400095D RID: 2397
		URL,
		// Token: 0x0400095E RID: 2398
		NumberPad,
		// Token: 0x0400095F RID: 2399
		PhonePad,
		// Token: 0x04000960 RID: 2400
		NamePhonePad,
		// Token: 0x04000961 RID: 2401
		EmailAddress,
		// Token: 0x04000962 RID: 2402
		[Obsolete("Wii U is no longer supported as of Unity 2018.1.")]
		NintendoNetworkAccount,
		// Token: 0x04000963 RID: 2403
		Social,
		// Token: 0x04000964 RID: 2404
		Search,
		// Token: 0x04000965 RID: 2405
		DecimalPad,
		// Token: 0x04000966 RID: 2406
		OneTimeCode
	}
}
