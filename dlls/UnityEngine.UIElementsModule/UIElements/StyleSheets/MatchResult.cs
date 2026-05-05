using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200049F RID: 1183
	internal struct MatchResult
	{
		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x060024CE RID: 9422 RVA: 0x0009B328 File Offset: 0x00099528
		public bool success
		{
			get
			{
				return this.errorCode == MatchResultErrorCode.None;
			}
		}

		// Token: 0x040011BF RID: 4543
		public MatchResultErrorCode errorCode;

		// Token: 0x040011C0 RID: 4544
		public string errorValue;
	}
}
