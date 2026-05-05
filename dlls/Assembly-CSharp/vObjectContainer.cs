using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class vObjectContainer : MonoBehaviour
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060000CA RID: 202 RVA: 0x0000846C File Offset: 0x0000666C
	public static Transform root
	{
		get
		{
			if (!vObjectContainer.instance)
			{
				vObjectContainer.instance = new GameObject("Object Container", new Type[]
				{
					typeof(vObjectContainer)
				}).GetComponent<vObjectContainer>();
			}
			return vObjectContainer.instance.transform;
		}
	}

	// Token: 0x04000113 RID: 275
	private static vObjectContainer instance;
}
