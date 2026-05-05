using System;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000307 RID: 775
	public class UIElementInFront : MonoBehaviour
	{
		// Token: 0x06001039 RID: 4153 RVA: 0x00056970 File Offset: 0x00054B70
		private void Start()
		{
			base.transform.SetAsLastSibling();
		}
	}
}
