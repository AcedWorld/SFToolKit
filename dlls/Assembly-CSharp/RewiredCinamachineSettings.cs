using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001AC RID: 428
public class RewiredCinamachineSettings : MonoBehaviour
{
	// Token: 0x060006B1 RID: 1713 RVA: 0x000324C2 File Offset: 0x000306C2
	private void Start()
	{
		this.updateCameraInput();
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x000324CC File Offset: 0x000306CC
	private void Update()
	{
		if (this.Trigger != this.characterStates.currentState > CharacterState.Idle && !this.isSpawning)
		{
			if (this.spawnedSetting != null)
			{
				Object.Destroy(this.spawnedSetting);
			}
			base.StartCoroutine(this.DelaySpawn());
			this.Trigger = (this.characterStates.currentState > CharacterState.Idle);
		}
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x00032531 File Offset: 0x00030731
	private IEnumerator DelaySpawn()
	{
		this.isSpawning = true;
		yield return new WaitForSecondsRealtime(0.2f);
		this.updateCameraInput();
		this.isSpawning = false;
		yield break;
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x00032540 File Offset: 0x00030740
	public void updateCameraInput()
	{
		if (this.characterStates.currentState != CharacterState.Idle)
		{
			this.CreateOnFootBridge();
			return;
		}
		this.CreateOnScooterBridge();
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0003255C File Offset: 0x0003075C
	private void CreateOnScooterBridge()
	{
		this.spawnedSetting = Object.Instantiate<GameObject>(this.OnScooterSettings, this.cameraBrain.position, this.cameraBrain.rotation, this.cameraBrain);
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0003258B File Offset: 0x0003078B
	private void CreateOnFootBridge()
	{
		this.spawnedSetting = Object.Instantiate<GameObject>(this.OnFootSettings, this.cameraBrain.position, this.cameraBrain.rotation, this.cameraBrain);
	}

	// Token: 0x04000BA1 RID: 2977
	public Transform cameraBrain;

	// Token: 0x04000BA2 RID: 2978
	public GameObject OnScooterSettings;

	// Token: 0x04000BA3 RID: 2979
	public GameObject OnFootSettings;

	// Token: 0x04000BA4 RID: 2980
	public CharacterStates characterStates;

	// Token: 0x04000BA5 RID: 2981
	private bool Trigger;

	// Token: 0x04000BA6 RID: 2982
	public GameObject spawnedSetting;

	// Token: 0x04000BA7 RID: 2983
	private bool isSpawning;
}
