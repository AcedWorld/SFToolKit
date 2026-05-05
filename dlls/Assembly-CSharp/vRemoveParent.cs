using System;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class vRemoveParent : MonoBehaviour
{
	// Token: 0x060000D1 RID: 209 RVA: 0x000087B0 File Offset: 0x000069B0
	private void Start()
	{
		if (this.removeOnStart)
		{
			this.RemoveParent();
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000087C0 File Offset: 0x000069C0
	public void RemoveParentOfOtherTransform(Transform target)
	{
		target.SetParent(null);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x000087C9 File Offset: 0x000069C9
	public void RemoveParent()
	{
		base.transform.SetParent(null);
	}

	// Token: 0x0400011E RID: 286
	public bool removeOnStart = true;
}
