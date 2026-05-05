using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class TeleportPlayer : MonoBehaviour
{
	// Token: 0x0600056B RID: 1387 RVA: 0x000255E8 File Offset: 0x000237E8
	private void Start()
	{
		if (this.teleportOnStart)
		{
			this.CreateLoadScreen();
			this.references.cameraBrain.ResetCameras();
		}
		this.originalCharacterLocalPosition = this.characterParent.localPosition;
		this.originalCharacterLocalRotation = this.characterParent.localRotation;
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x00025635 File Offset: 0x00023835
	public void TeleportToSpawnpoint()
	{
		this.TeleportFunction();
		this.references.simpleReplay.ResetBuffer();
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x0002564D File Offset: 0x0002384D
	public void TeleportToSpawnpointWithoutBufferReset()
	{
		this.TeleportFunction();
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x00025658 File Offset: 0x00023858
	public void SetMarker()
	{
		if (this.allowTeleport && !this.IsTutorial)
		{
			this.references.spawnpointTransform.position = this.references.scooterController.mainRaycast.point;
			Quaternion rhs = new Quaternion(0f, base.transform.rotation.y, 0f, base.transform.rotation.w);
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, this.references.scooterController.mainRaycast.normal) * rhs;
			this.references.spawnpointTransform.rotation = rotation;
			this.OnSetMarker();
		}
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x00025710 File Offset: 0x00023910
	private void TeleportFunction()
	{
		if (this.allowTeleport)
		{
			this.references.timespeed.NormalTime();
			this.CreateLoadScreen();
			this.references.soundManager.resetRollingSoundVolume();
			base.transform.position = this.references.spawnpointTransform.position;
			base.transform.rotation = this.references.spawnpointTransform.rotation;
			Physics.SyncTransforms();
			this.references.scooterController.ResetScooterController();
			this.references.scooterflowInputSystem.TeleportResetManuals();
			this.references.playerRigidbody.velocity = Vector3.zero;
			this.references.ragdollControl.DeactivateRagoll();
			this.OnTeleport();
		}
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x000257D4 File Offset: 0x000239D4
	public void CreateLoadScreen()
	{
		Object.Instantiate<GameObject>(this.references.loadscreenPrefab, this.references.loadscreenParent);
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x000257F4 File Offset: 0x000239F4
	private void OnTeleport()
	{
		this.references.characterStates.HardResetToScooter();
		this.references.grindSystem.StopGrinding(false, false);
		this.references.rampDirection.switchoff();
		this.Events.onTeleport.Invoke();
		this.characterParent.localPosition = this.originalCharacterLocalPosition;
		this.characterParent.localRotation = this.originalCharacterLocalRotation;
		base.StartCoroutine(this.cameraCoroutine());
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x00025872 File Offset: 0x00023A72
	private IEnumerator cameraCoroutine()
	{
		yield return new WaitForSeconds(0.2f);
		this.references.cameraBrain.ResetCameras();
		yield break;
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x00025881 File Offset: 0x00023A81
	private void OnSetMarker()
	{
		this.Events.onSetMarker.Invoke();
	}

	// Token: 0x040008AE RID: 2222
	public TeleportPlayerReferences references;

	// Token: 0x040008AF RID: 2223
	public bool teleportOnStart;

	// Token: 0x040008B0 RID: 2224
	public bool allowTeleport;

	// Token: 0x040008B1 RID: 2225
	public TeleportEvents Events;

	// Token: 0x040008B2 RID: 2226
	private Vector3 originalCharacterLocalPosition;

	// Token: 0x040008B3 RID: 2227
	private Quaternion originalCharacterLocalRotation;

	// Token: 0x040008B4 RID: 2228
	public Transform characterParent;

	// Token: 0x040008B5 RID: 2229
	public bool IsTutorial;
}
