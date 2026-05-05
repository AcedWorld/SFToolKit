using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000008 RID: 8
	public class HelpBoxAttribute : PropertyAttribute
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002388 File Offset: 0x00000588
		public HelpBoxAttribute(string text, HelpBoxMessageType messageType = HelpBoxMessageType.None)
		{
			this.text = text;
			this.messageType = messageType;
		}

		// Token: 0x0400000F RID: 15
		public string text;

		// Token: 0x04000010 RID: 16
		public HelpBoxMessageType messageType;
	}
}
