using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class OpenTipLoadScreen : MonoBehaviour
{
	// Token: 0x060003FF RID: 1023 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
	private void Start()
	{
		this.GetImmediateChildObjects(base.transform);
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0001D0F8 File Offset: 0x0001B2F8
	private void GetImmediateChildObjects(Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);
			this.childObjects.Add(child.gameObject);
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0001D130 File Offset: 0x0001B330
	public void OpenLoadScreen()
	{
		if (this.childObjects.Count > 0)
		{
			int index = Random.Range(0, this.childObjects.Count);
			this.childObjects[index].SetActive(true);
		}
		this.loadBar.SetActive(true);
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0001D17C File Offset: 0x0001B37C
	public void CloseAllLoadScreens()
	{
		foreach (GameObject gameObject in this.childObjects)
		{
			gameObject.SetActive(false);
		}
	}

	// Token: 0x040005DD RID: 1501
	private List<GameObject> childObjects = new List<GameObject>();

	// Token: 0x040005DE RID: 1502
	public GameObject loadBar;
}
