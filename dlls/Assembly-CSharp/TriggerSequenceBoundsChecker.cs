using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class TriggerSequenceBoundsChecker : MonoBehaviour
{
	// Token: 0x06000301 RID: 769 RVA: 0x000177DE File Offset: 0x000159DE
	private void Update()
	{
		this.CheckTriggers();
	}

	// Token: 0x06000302 RID: 770 RVA: 0x000177E6 File Offset: 0x000159E6
	private void OnEnable()
	{
		this.ResetChallenge();
	}

	// Token: 0x06000303 RID: 771 RVA: 0x000177F0 File Offset: 0x000159F0
	private void CheckTriggers()
	{
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerA) && !this.hasTouchedA && this.rampDirection.airHasPumped)
		{
			this.hasTouchedA = true;
			this.SetTriggerColor(this.triggerA, this.greenMaterial);
			this.tutorialManager.UpdateTutorialText("Airing Triggered");
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			Time.timeScale = 0.5f;
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerB) && this.hasTouchedA && !this.hasTouchedB && this.rampDirection.LookForCoping && !this.scooterController.isGrounded)
		{
			this.FinishMarker.SetActive(true);
			this.DymanicResetter.SetActive(true);
			Time.timeScale = 1f;
			this.hasTouchedB = true;
			this.SetTriggerColor(this.triggerB, this.greenMaterial);
			this.tutorialManager.UpdateTutorialText("Airing Jump Triggered!");
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerC) && this.hasTouchedA && this.hasTouchedB && !this.hasTouchedC && this.scooterController.isGrounded && GameObject.FindGameObjectsWithTag("markers").Length == 0)
		{
			this.hasTouchedC = true;
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			this.FinishMarker.SetActive(false);
			this.counter++;
			this.tutorialManager.UpdateTutorialText("Complete 3 to finish, Current Counter: " + this.counter.ToString());
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.IsBoundaryTriggered(this.boundaryTriggers) && this.scooterController.isGrounded)
		{
			this.ResetTriggers();
		}
		if (this.IsBoundaryTriggered(this.resetBoundaryTriggers) || this.IsWithinBounds(this.tutorialChecker, this.DymanicResetterCol))
		{
			this.ResetChallenge();
		}
		if (this.counter >= this.passThreshold && this.scooterController.isGrounded)
		{
			this.tutorialManager.PlaySound(this.tutorialManager.correctSound);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00017A5C File Offset: 0x00015C5C
	private bool IsWithinBounds(Transform target, Collider collider)
	{
		return collider.bounds.Contains(target.position);
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00017A80 File Offset: 0x00015C80
	private bool IsBoundaryTriggered(Collider[] boundaries)
	{
		foreach (Collider collider in boundaries)
		{
			if (this.IsWithinBounds(this.tutorialChecker, collider))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00017AB4 File Offset: 0x00015CB4
	private void ResetTriggers()
	{
		Time.timeScale = 1f;
		this.hasTouchedA = false;
		this.hasTouchedB = false;
		this.hasTouchedC = false;
		this.FinishMarker.SetActive(false);
		this.DymanicResetter.SetActive(false);
		this.SetTriggerColor(this.triggerA, this.defaultMaterial);
		this.SetTriggerColor(this.triggerB, this.defaultMaterialRed);
		if (this.counter == 0)
		{
			this.WheelMarkerA.SetActive(false);
			this.WheelMarkerB.SetActive(false);
		}
		if (this.counter == 1)
		{
			this.WheelMarkerA.SetActive(true);
		}
		if (this.counter == 2)
		{
			this.WheelMarkerA.SetActive(true);
			this.WheelMarkerB.SetActive(true);
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x00017B74 File Offset: 0x00015D74
	private void SetTriggerColor(Collider trigger, Material material)
	{
		Renderer component = trigger.GetComponent<Renderer>();
		if (component != null)
		{
			component.material = material;
		}
	}

	// Token: 0x06000308 RID: 776 RVA: 0x00017B98 File Offset: 0x00015D98
	private void ResetChallenge()
	{
		this.teleportPlayer.references.spawnpointTransform.position = this.dummySpawnPoint.position;
		this.teleportPlayer.references.spawnpointTransform.rotation = this.dummySpawnPoint.rotation;
		this.teleportPlayer.TeleportToSpawnpoint();
	}

	// Token: 0x040003F2 RID: 1010
	public Transform tutorialChecker;

	// Token: 0x040003F3 RID: 1011
	public Collider triggerA;

	// Token: 0x040003F4 RID: 1012
	public Collider triggerB;

	// Token: 0x040003F5 RID: 1013
	public Collider triggerC;

	// Token: 0x040003F6 RID: 1014
	public Collider DymanicResetterCol;

	// Token: 0x040003F7 RID: 1015
	public GameObject FinishMarker;

	// Token: 0x040003F8 RID: 1016
	public GameObject DymanicResetter;

	// Token: 0x040003F9 RID: 1017
	public GameObject WheelMarkerA;

	// Token: 0x040003FA RID: 1018
	public GameObject WheelMarkerB;

	// Token: 0x040003FB RID: 1019
	public Collider[] boundaryTriggers;

	// Token: 0x040003FC RID: 1020
	public Collider[] resetBoundaryTriggers;

	// Token: 0x040003FD RID: 1021
	public Material defaultMaterial;

	// Token: 0x040003FE RID: 1022
	public Material defaultMaterialRed;

	// Token: 0x040003FF RID: 1023
	public Material greenMaterial;

	// Token: 0x04000400 RID: 1024
	public Transform dummySpawnPoint;

	// Token: 0x04000401 RID: 1025
	private bool hasTouchedA;

	// Token: 0x04000402 RID: 1026
	private bool hasTouchedB;

	// Token: 0x04000403 RID: 1027
	private bool hasTouchedC;

	// Token: 0x04000404 RID: 1028
	private int counter;

	// Token: 0x04000405 RID: 1029
	public int passThreshold = 3;

	// Token: 0x04000406 RID: 1030
	public RampDirection rampDirection;

	// Token: 0x04000407 RID: 1031
	public ScooterController scooterController;

	// Token: 0x04000408 RID: 1032
	public TeleportPlayer teleportPlayer;

	// Token: 0x04000409 RID: 1033
	public TutorialManager tutorialManager;
}
