using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000006 RID: 6
	public class ToggleActive : MonoBehaviour
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002365 File Offset: 0x00000565
		public void Toggle()
		{
			base.gameObject.SetActive(!base.gameObject.activeSelf);
		}
	}
}
