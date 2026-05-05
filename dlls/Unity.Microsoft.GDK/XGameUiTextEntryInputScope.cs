using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000140 RID: 320
	[MovedFrom("Unity.GameCore")]
	public enum XGameUiTextEntryInputScope : uint
	{
		// Token: 0x040004BD RID: 1213
		Default,
		// Token: 0x040004BE RID: 1214
		Url,
		// Token: 0x040004BF RID: 1215
		EmailSmtpAddress = 5U,
		// Token: 0x040004C0 RID: 1216
		Number = 29U,
		// Token: 0x040004C1 RID: 1217
		Password = 31U,
		// Token: 0x040004C2 RID: 1218
		TelephoneNumber,
		// Token: 0x040004C3 RID: 1219
		Alphanumeric = 40U,
		// Token: 0x040004C4 RID: 1220
		Search = 50U,
		// Token: 0x040004C5 RID: 1221
		ChatWithoutEmoji = 68U
	}
}
