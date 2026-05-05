using System;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002FD RID: 765
	public class LaunchURL : MonoBehaviour
	{
		// Token: 0x06001018 RID: 4120 RVA: 0x0005575F File Offset: 0x0005395F
		public void urlLinkOrWeb()
		{
			Application.OpenURL(this.URL);
		}

		// Token: 0x04001511 RID: 5393
		public string URL;
	}
}
