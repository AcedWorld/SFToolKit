using System;
using UnityEngine;

// Token: 0x02000102 RID: 258
public class SplitPlayer : MonoBehaviour
{
	// Token: 0x0600044F RID: 1103 RVA: 0x0001E0B2 File Offset: 0x0001C2B2
	private void Update()
	{
		if (base.transform.childCount > 0)
		{
			this.RemoveParent();
		}
		if (base.transform.childCount == 0)
		{
			Object.Destroy(base.gameObject, 2f);
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0001E0E8 File Offset: 0x0001C2E8
	public void RemoveParent()
	{
		foreach (object obj in base.transform)
		{
			((Transform)obj).SetParent(null);
		}
	}
}
