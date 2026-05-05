using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
public class DontDestroy : MonoBehaviour
{
	// Token: 0x0600054D RID: 1357 RVA: 0x000243F2 File Offset: 0x000225F2
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}
}
