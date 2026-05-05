using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public class PerfectTransferTutorial : MonoBehaviour
{
	// Token: 0x0600030A RID: 778 RVA: 0x00017BFF File Offset: 0x00015DFF
	private void Update()
	{
		this.CheckTriggers();
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00017C07 File Offset: 0x00015E07
	private void OnEnable()
	{
		this.ResetChallenge();
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00017C10 File Offset: 0x00015E10
	private void CheckTriggers()
	{
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerA) && !this.hasTouchedA && this.rampDirection.transferHasPumped)
		{
			this.hasTouchedA = true;
			this.SetTriggerColor(this.triggerA, this.greenMaterial);
			this.tutorialManager.Down.SetActive(true);
			this.tutorialManager.Up.SetActive(true);
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			Time.timeScale = 0.5f;
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerB) && this.hasTouchedA && !this.hasTouchedB && this.rampDirection.adjustingMidAir && !this.scooterController.isGrounded)
		{
			this.FinishMarker.SetActive(true);
			Time.timeScale = 1f;
			this.hasTouchedB = true;
			this.SetTriggerColor(this.triggerB, this.greenMaterial);
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerC) && this.hasTouchedA && this.hasTouchedB && !this.hasTouchedC && GameObject.FindGameObjectsWithTag("markers").Length == 0)
		{
			this.hasTouchedC = true;
			this.tutorialManager.DisableAllButtons();
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			this.counter++;
			this.tutorialManager.UpdateTutorialText("Complete 3 total Transfers, Current Counter: " + this.counter.ToString());
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			this.ResetTriggers();
		}
		if ((this.IsBoundaryTriggered(this.boundaryTriggers) || (this.IsWithinBounds(this.tutorialChecker, this.triggerA) && this.hasTouchedA && this.hasTouchedB)) && this.scooterController.isGrounded)
		{
			this.ResetTriggers();
		}
		if (this.IsBoundaryTriggered(this.resetBoundaryTriggers))
		{
			Debug.Log("Reset Boundary Triggered! Resetting Challenge...");
			this.ResetChallenge();
		}
		if (this.counter >= this.passThreshold && this.scooterController.isGrounded)
		{
			this.tutorialManager.PlaySound(this.tutorialManager.correctSound);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600030D RID: 781 RVA: 0x00017E7C File Offset: 0x0001607C
	private bool IsWithinBounds(Transform target, Collider collider)
	{
		return collider.bounds.Contains(target.position);
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00017EA0 File Offset: 0x000160A0
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

	// Token: 0x0600030F RID: 783 RVA: 0x00017ED4 File Offset: 0x000160D4
	private void ResetTriggers()
	{
		Time.timeScale = 1f;
		this.hasTouchedA = false;
		this.hasTouchedB = false;
		this.hasTouchedC = false;
		this.FinishMarker.SetActive(false);
		this.tutorialManager.GOLup.SetActive(true);
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

	// Token: 0x06000310 RID: 784 RVA: 0x00017F98 File Offset: 0x00016198
	private void SetTriggerColor(Collider trigger, Material material)
	{
		Renderer component = trigger.GetComponent<Renderer>();
		if (component != null)
		{
			component.material = material;
		}
	}

	// Token: 0x06000311 RID: 785 RVA: 0x00017FBC File Offset: 0x000161BC
	private void ResetChallenge()
	{
		this.teleportPlayer.references.spawnpointTransform.position = this.dummySpawnPoint.position;
		this.teleportPlayer.references.spawnpointTransform.rotation = this.dummySpawnPoint.rotation;
		this.teleportPlayer.TeleportToSpawnpoint();
	}

	// Token: 0x0400040A RID: 1034
	public Transform tutorialChecker;

	// Token: 0x0400040B RID: 1035
	public Collider triggerA;

	// Token: 0x0400040C RID: 1036
	public Collider triggerB;

	// Token: 0x0400040D RID: 1037
	public Collider triggerC;

	// Token: 0x0400040E RID: 1038
	public GameObject FinishMarker;

	// Token: 0x0400040F RID: 1039
	public GameObject WheelMarkerA;

	// Token: 0x04000410 RID: 1040
	public GameObject WheelMarkerB;

	// Token: 0x04000411 RID: 1041
	public Collider[] boundaryTriggers;

	// Token: 0x04000412 RID: 1042
	public Collider[] resetBoundaryTriggers;

	// Token: 0x04000413 RID: 1043
	public Material defaultMaterial;

	// Token: 0x04000414 RID: 1044
	public Material defaultMaterialRed;

	// Token: 0x04000415 RID: 1045
	public Material greenMaterial;

	// Token: 0x04000416 RID: 1046
	public Transform dummySpawnPoint;

	// Token: 0x04000417 RID: 1047
	private bool hasTouchedA;

	// Token: 0x04000418 RID: 1048
	private bool hasTouchedB;

	// Token: 0x04000419 RID: 1049
	private bool hasTouchedC;

	// Token: 0x0400041A RID: 1050
	private int counter;

	// Token: 0x0400041B RID: 1051
	public int passThreshold = 3;

	// Token: 0x0400041C RID: 1052
	public RampDirection rampDirection;

	// Token: 0x0400041D RID: 1053
	public ScooterController scooterController;

	// Token: 0x0400041E RID: 1054
	public TeleportPlayer teleportPlayer;

	// Token: 0x0400041F RID: 1055
	public TutorialManager tutorialManager;
}
