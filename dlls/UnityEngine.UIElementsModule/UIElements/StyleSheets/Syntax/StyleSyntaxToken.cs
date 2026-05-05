using System;

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	// Token: 0x020004B0 RID: 1200
	internal struct StyleSyntaxToken
	{
		// Token: 0x06002538 RID: 9528 RVA: 0x0009D6D9 File Offset: 0x0009B8D9
		public StyleSyntaxToken(StyleSyntaxTokenType t)
		{
			this.type = t;
			this.text = null;
			this.number = 0;
		}

		// Token: 0x06002539 RID: 9529 RVA: 0x0009D6F1 File Offset: 0x0009B8F1
		public StyleSyntaxToken(StyleSyntaxTokenType type, string text)
		{
			this.type = type;
			this.text = text;
			this.number = 0;
		}

		// Token: 0x0600253A RID: 9530 RVA: 0x0009D709 File Offset: 0x0009B909
		public StyleSyntaxToken(StyleSyntaxTokenType type, int number)
		{
			this.type = type;
			this.text = null;
			this.number = number;
		}

		// Token: 0x04001228 RID: 4648
		public StyleSyntaxTokenType type;

		// Token: 0x04001229 RID: 4649
		public string text;

		// Token: 0x0400122A RID: 4650
		public int number;
	}
}
