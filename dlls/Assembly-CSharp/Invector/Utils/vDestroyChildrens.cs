using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003B4 RID: 948
	public class vDestroyChildrens : MonoBehaviour
	{
		// Token: 0x060012F0 RID: 4848 RVA: 0x00064416 File Offset: 0x00062616
		public virtual void DestroyChildrens()
		{
			this.DestroyChildrens(base.transform);
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x00064424 File Offset: 0x00062624
		public virtual void DestroyChildrensOfOther(Transform target)
		{
			this.DestroyChildrens(target);
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00064430 File Offset: 0x00062630
		protected virtual void DestroyChildrens(Transform target)
		{
			for (int i = target.childCount - 1; i >= 0; i--)
			{
				Object.Destroy(target.GetChild(i).gameObject);
			}
		}
	}
}
