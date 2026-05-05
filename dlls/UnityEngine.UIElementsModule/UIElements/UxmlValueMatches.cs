using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D8 RID: 984
	public class UxmlValueMatches : UxmlTypeRestriction
	{
		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06002035 RID: 8245 RVA: 0x00079A36 File Offset: 0x00077C36
		// (set) Token: 0x06002036 RID: 8246 RVA: 0x00079A3E File Offset: 0x00077C3E
		public string regex { get; set; }

		// Token: 0x06002037 RID: 8247 RVA: 0x00079A48 File Offset: 0x00077C48
		public override bool Equals(UxmlTypeRestriction other)
		{
			UxmlValueMatches uxmlValueMatches = other as UxmlValueMatches;
			bool flag = uxmlValueMatches == null;
			return !flag && this.regex == uxmlValueMatches.regex;
		}
	}
}
