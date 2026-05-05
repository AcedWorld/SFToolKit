using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003BF RID: 959
	public class vSetParent : MonoBehaviour
	{
		// Token: 0x06001323 RID: 4899 RVA: 0x0003B4F1 File Offset: 0x000396F1
		public void RemoveParent()
		{
			base.transform.parent = null;
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x00064B10 File Offset: 0x00062D10
		public void RemoveParent(Transform target)
		{
			target.parent = null;
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x00064B19 File Offset: 0x00062D19
		public void SetParent(Transform parent)
		{
			base.transform.parent = parent;
		}
	}
}
