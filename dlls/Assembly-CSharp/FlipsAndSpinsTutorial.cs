using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class FlipsAndSpinsTutorial : MonoBehaviour
{
	// Token: 0x060002EB RID: 747 RVA: 0x00016F44 File Offset: 0x00015144
	public void SetTrickState(FlipsAndSpinsTutorial.TrickState newState)
	{
		this.currentState = newState;
		switch (this.currentState)
		{
		default:
			return;
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00016F75 File Offset: 0x00015175
	public void OnStart()
	{
		this.SetTrickState(FlipsAndSpinsTutorial.TrickState.BackFlip);
		this.tutorialManager.UpdateTutorialText("Perform a Backflip");
	}

	// Token: 0x060002ED RID: 749 RVA: 0x00016F8E File Offset: 0x0001518E
	private void Update()
	{
		this.CheckTriggers();
	}

	// Token: 0x060002EE RID: 750 RVA: 0x00016F96 File Offset: 0x00015196
	private void OnEnable()
	{
		this.ResetChallenge();
	}

	// Token: 0x060002EF RID: 751 RVA: 0x00016FA0 File Offset: 0x000151A0
	private void CheckTriggers()
	{
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerA) && !this.hasTouchedA)
		{
			this.hasTouchedA = true;
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.hasTouchedA && !this.scooterController.isGrounded && !this.trickcompleted)
		{
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.BackFlip && this.playerscoring.flipDirection == "Backflip" && this.playerscoring.flipMultiplier == 1)
			{
				Debug.Log("Flip completed");
				this.trickcompleted = true;
				this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.FrontFlip && this.playerscoring.flipDirection == "Frontflip" && this.playerscoring.flipMultiplier == 1)
			{
				Debug.Log("Flip completed");
				this.trickcompleted = true;
				this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.Spin180 && this.playerscoring.spinsCountRounded == 180f)
			{
				Debug.Log("Flip completed");
				this.trickcompleted = true;
				this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.Spin360 && this.playerscoring.spinsCountRounded == 360f)
			{
				Debug.Log("Flip completed");
				this.trickcompleted = true;
				this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
			}
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerB) && this.hasTouchedA && !this.hasTouchedB)
		{
			this.hasTouchedB = true;
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.hasTouchedB)
		{
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.BackFlip && this.trickcompleted)
			{
				this.trickcompleted = false;
				this.SetTrickState(FlipsAndSpinsTutorial.TrickState.FrontFlip);
				Debug.Log("finished");
				this.tutorialManager.UpdateTutorialText("Perform a Frontflip");
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.FrontFlip && this.trickcompleted)
			{
				this.trickcompleted = false;
				this.SetTrickState(FlipsAndSpinsTutorial.TrickState.Spin180);
				Debug.Log("finished");
				this.tutorialManager.UpdateTutorialText("Perform a 180 Spin");
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.Spin180 && this.trickcompleted)
			{
				this.trickcompleted = false;
				this.SetTrickState(FlipsAndSpinsTutorial.TrickState.Spin360);
				Debug.Log("finished");
				this.tutorialManager.UpdateTutorialText("Perform a 360 Spin");
			}
			if (this.currentState == FlipsAndSpinsTutorial.TrickState.Spin360 && this.trickcompleted)
			{
				this.trickcompleted = false;
				this.tutorialManager.PlaySound(this.tutorialManager.correctSound);
				base.gameObject.SetActive(false);
			}
		}
		if (this.IsBoundaryTriggered(this.boundaryTriggers))
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

	// Token: 0x060002F0 RID: 752 RVA: 0x000172D8 File Offset: 0x000154D8
	private bool IsWithinBounds(Transform target, Collider collider)
	{
		return collider.bounds.Contains(target.position);
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x000172FC File Offset: 0x000154FC
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

	// Token: 0x060002F2 RID: 754 RVA: 0x0001732F File Offset: 0x0001552F
	private void ResetTriggers()
	{
		this.hasTouchedA = false;
		this.hasTouchedB = false;
		this.StartMarker.SetActive(true);
		this.FinishMarker.SetActive(true);
		this.trickcompleted = false;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00017360 File Offset: 0x00015560
	private void SetTriggerColor(Collider trigger, Material material)
	{
		Renderer component = trigger.GetComponent<Renderer>();
		if (component != null)
		{
			component.material = material;
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00017384 File Offset: 0x00015584
	private void ResetChallenge()
	{
		this.teleportPlayer.references.spawnpointTransform.position = this.dummySpawnPoint.position;
		this.teleportPlayer.references.spawnpointTransform.rotation = this.dummySpawnPoint.rotation;
		this.teleportPlayer.TeleportToSpawnpoint();
	}

	// Token: 0x040003B8 RID: 952
	public Transform tutorialChecker;

	// Token: 0x040003B9 RID: 953
	public Collider triggerA;

	// Token: 0x040003BA RID: 954
	public Collider triggerB;

	// Token: 0x040003BB RID: 955
	public GameObject StartMarker;

	// Token: 0x040003BC RID: 956
	public GameObject FinishMarker;

	// Token: 0x040003BD RID: 957
	public Collider[] boundaryTriggers;

	// Token: 0x040003BE RID: 958
	public Collider[] resetBoundaryTriggers;

	// Token: 0x040003BF RID: 959
	public Transform dummySpawnPoint;

	// Token: 0x040003C0 RID: 960
	private bool hasTouchedA;

	// Token: 0x040003C1 RID: 961
	private bool hasTouchedB;

	// Token: 0x040003C2 RID: 962
	private int counter;

	// Token: 0x040003C3 RID: 963
	public int passThreshold = 3;

	// Token: 0x040003C4 RID: 964
	public ScooterController scooterController;

	// Token: 0x040003C5 RID: 965
	public TeleportPlayer teleportPlayer;

	// Token: 0x040003C6 RID: 966
	public TutorialManager tutorialManager;

	// Token: 0x040003C7 RID: 967
	public Rigidbody playerRigidbody;

	// Token: 0x040003C8 RID: 968
	public float pointOffset = 0.5f;

	// Token: 0x040003C9 RID: 969
	private Vector3 centerOffset;

	// Token: 0x040003CA RID: 970
	private Vector3 frontPoint;

	// Token: 0x040003CB RID: 971
	private Vector3 backPoint;

	// Token: 0x040003CC RID: 972
	private Vector3 upPoint;

	// Token: 0x040003CD RID: 973
	private Vector3 downPoint;

	// Token: 0x040003CE RID: 974
	private bool trickcompleted;

	// Token: 0x040003CF RID: 975
	public PlayerScoring playerscoring;

	// Token: 0x040003D0 RID: 976
	public FlipsAndSpinsTutorial.TrickState currentState;

	// Token: 0x020000B1 RID: 177
	public enum TrickState
	{
		// Token: 0x040003D2 RID: 978
		BackFlip,
		// Token: 0x040003D3 RID: 979
		FrontFlip,
		// Token: 0x040003D4 RID: 980
		Spin180,
		// Token: 0x040003D5 RID: 981
		Spin360
	}
}
