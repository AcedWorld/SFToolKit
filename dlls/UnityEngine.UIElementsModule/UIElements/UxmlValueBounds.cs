using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D9 RID: 985
	public class UxmlValueBounds : UxmlTypeRestriction
	{
		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06002039 RID: 8249 RVA: 0x00079A88 File Offset: 0x00077C88
		// (set) Token: 0x0600203A RID: 8250 RVA: 0x00079A90 File Offset: 0x00077C90
		public string min { get; set; }

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x0600203B RID: 8251 RVA: 0x00079A99 File Offset: 0x00077C99
		// (set) Token: 0x0600203C RID: 8252 RVA: 0x00079AA1 File Offset: 0x00077CA1
		public string max { get; set; }

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x0600203D RID: 8253 RVA: 0x00079AAA File Offset: 0x00077CAA
		// (set) Token: 0x0600203E RID: 8254 RVA: 0x00079AB2 File Offset: 0x00077CB2
		public bool excludeMin { get; set; }

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x0600203F RID: 8255 RVA: 0x00079ABB File Offset: 0x00077CBB
		// (set) Token: 0x06002040 RID: 8256 RVA: 0x00079AC3 File Offset: 0x00077CC3
		public bool excludeMax { get; set; }

		// Token: 0x06002041 RID: 8257 RVA: 0x00079ACC File Offset: 0x00077CCC
		public override bool Equals(UxmlTypeRestriction other)
		{
			UxmlValueBounds uxmlValueBounds = other as UxmlValueBounds;
			bool flag = uxmlValueBounds == null;
			return !flag && (this.min == uxmlValueBounds.min && this.max == uxmlValueBounds.max && this.excludeMin == uxmlValueBounds.excludeMin) && this.excludeMax == uxmlValueBounds.excludeMax;
		}
	}
}
