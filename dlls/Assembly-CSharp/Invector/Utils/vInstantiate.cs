using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003BC RID: 956
	[vClassHeader("v Instantiate", true, "icon_v2", false, "", openClose = false)]
	public class vInstantiate : vMonoBehaviour
	{
		// Token: 0x06001316 RID: 4886 RVA: 0x0006495B File Offset: 0x00062B5B
		protected virtual void Start()
		{
			if (this.instantiateOnStart)
			{
				this.InstantiateObject();
			}
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0006496C File Offset: 0x00062B6C
		public virtual void InstantiateObject()
		{
			if (this.prefab)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.prefab, base.transform.position, base.transform.rotation);
				gameObject.SetActive(true);
				if (this.setThisAsParent)
				{
					gameObject.transform.parent = base.transform;
				}
			}
		}

		// Token: 0x040018E0 RID: 6368
		public GameObject prefab;

		// Token: 0x040018E1 RID: 6369
		public bool instantiateOnStart;

		// Token: 0x040018E2 RID: 6370
		public bool setThisAsParent;
	}
}
