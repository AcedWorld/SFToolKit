using System;

namespace TMPro
{
	// Token: 0x0200021E RID: 542
	[Serializable]
	public class TMP_DigitValidator : TMP_InputValidator
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x0003BB12 File Offset: 0x00039D12
		public override char Validate(ref string text, ref int pos, char ch)
		{
			if (ch >= '0' && ch <= '9')
			{
				text += ch.ToString();
				pos++;
				return ch;
			}
			return '\0';
		}
	}
}
