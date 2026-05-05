using System;
using UnityEngine;

// Token: 0x020001AE RID: 430
public class UpdateCurrentSetting : MonoBehaviour
{
	// Token: 0x060006BE RID: 1726 RVA: 0x00032634 File Offset: 0x00030834
	private void Start()
	{
		this.RewiredCinamachineSettings = GameObject.Find("RewiredCinamachineSettings").GetComponent<RewiredCinamachineSettings>();
		this.updateCurrentSetting();
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00032651 File Offset: 0x00030851
	public void updateCurrentSetting()
	{
		this.RewiredCinamachineSettings.spawnedSetting = base.gameObject;
	}

	// Token: 0x04000BAB RID: 2987
	public RewiredCinamachineSettings RewiredCinamachineSettings;
}
