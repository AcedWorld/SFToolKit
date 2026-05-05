using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000035 RID: 53
public class vEnableDisableEvent : MonoBehaviour
{
	// Token: 0x060000B5 RID: 181 RVA: 0x00008273 File Offset: 0x00006473
	private void OnEnable()
	{
		this.onEnable.Invoke();
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00008280 File Offset: 0x00006480
	private void OnDisable()
	{
		this.onDisable.Invoke();
	}

	// Token: 0x04000106 RID: 262
	public UnityEvent onEnable;

	// Token: 0x04000107 RID: 263
	public UnityEvent onDisable;
}
