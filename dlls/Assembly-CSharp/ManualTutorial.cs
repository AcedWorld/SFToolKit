using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class ManualTutorial : MonoBehaviour
{
	// Token: 0x060002F6 RID: 758 RVA: 0x000173F8 File Offset: 0x000155F8
	public void SetTrickState(ManualTutorial.TrickState newState)
	{
		this.currentState = newState;
		ManualTutorial.TrickState trickState = this.currentState;
		if (trickState != ManualTutorial.TrickState.Manual)
		{
		}
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0001741A File Offset: 0x0001561A
	public void OnStart()
	{
		this.SetTrickState(ManualTutorial.TrickState.Manual);
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x00017423 File Offset: 0x00015623
	private void Update()
	{
		this.CheckTriggers();
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0001742B File Offset: 0x0001562B
	private void OnEnable()
	{
		this.ResetChallenge();
	}

	// Token: 0x060002FA RID: 762 RVA: 0x00017434 File Offset: 0x00015634
	private void CheckTriggers()
	{
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerA))
		{
			this.hasTouchedA = true;
		}
		else
		{
			this.hasTouchedA = false;
		}
		if (this.hasTouchedA)
		{
			if (this.currentState == ManualTutorial.TrickState.Manual)
			{
				if (this.scooterController.Manual && !this.trickcompleted && !this.trickcompleted)
				{
					this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
					this.trickcompleted = true;
				}
				if (this.scooterController.frontWheelGrounded)
				{
					this.groundedtimer += Time.deltaTime;
					if ((double)this.groundedtimer > 0.2)
					{
						this.trickcompleted = false;
						this.tutorialManager.PlaySound(this.tutorialManager.incorrectSound);
						this.ResetChallenge();
					}
				}
			}
			if (this.currentState == ManualTutorial.TrickState.NoseManual && !this.trickcompleted)
			{
				if (this.scooterController.NoseManual && !this.trickcompleted)
				{
					this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
					this.trickcompleted = true;
				}
				if (this.scooterController.rearWheelGrounded)
				{
					this.groundedtimer += Time.deltaTime;
					if ((double)this.groundedtimer > 0.2)
					{
						this.trickcompleted = false;
						this.tutorialManager.PlaySound(this.tutorialManager.incorrectSound);
						this.ResetChallenge();
					}
				}
			}
		}
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerB) && !this.hasTouchedB)
		{
			this.hasTouchedB = true;
			this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		}
		if (this.hasTouchedB)
		{
			if (this.currentState == ManualTutorial.TrickState.Manual && this.trickcompleted)
			{
				this.trickcompleted = false;
				this.SetTrickState(ManualTutorial.TrickState.NoseManual);
				this.FinishMarker.SetActive(false);
				this.tutorialManager.UpdateTutorialText("Hop onto the pad and NOSEMANUAL the whole length, Don't let the back wheel touch the pad");
			}
			if (this.currentState == ManualTutorial.TrickState.NoseManual && this.trickcompleted)
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
			this.ResetChallenge();
		}
		if (this.counter >= this.passThreshold && this.scooterController.isGrounded)
		{
			this.tutorialManager.PlaySound(this.tutorialManager.correctSound);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x060002FB RID: 763 RVA: 0x000176C0 File Offset: 0x000158C0
	private bool IsWithinBounds(Transform target, Collider collider)
	{
		return collider.bounds.Contains(target.position);
	}

	// Token: 0x060002FC RID: 764 RVA: 0x000176E4 File Offset: 0x000158E4
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

	// Token: 0x060002FD RID: 765 RVA: 0x00017717 File Offset: 0x00015917
	private void ResetTriggers()
	{
		this.hasTouchedA = false;
		this.hasTouchedB = false;
		this.FinishMarker.SetActive(true);
		this.trickcompleted = false;
		this.groundedtimer = 0f;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x00017748 File Offset: 0x00015948
	private void SetTriggerColor(Collider trigger, Material material)
	{
		Renderer component = trigger.GetComponent<Renderer>();
		if (component != null)
		{
			component.material = material;
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0001776C File Offset: 0x0001596C
	private void ResetChallenge()
	{
		this.teleportPlayer.references.spawnpointTransform.position = this.dummySpawnPoint.position;
		this.teleportPlayer.references.spawnpointTransform.rotation = this.dummySpawnPoint.rotation;
		this.teleportPlayer.TeleportToSpawnpoint();
	}

	// Token: 0x040003D6 RID: 982
	public Transform tutorialChecker;

	// Token: 0x040003D7 RID: 983
	public Collider triggerA;

	// Token: 0x040003D8 RID: 984
	public Collider triggerB;

	// Token: 0x040003D9 RID: 985
	public GameObject FinishMarker;

	// Token: 0x040003DA RID: 986
	public Collider[] boundaryTriggers;

	// Token: 0x040003DB RID: 987
	public Collider[] resetBoundaryTriggers;

	// Token: 0x040003DC RID: 988
	public Transform dummySpawnPoint;

	// Token: 0x040003DD RID: 989
	private bool hasTouchedA;

	// Token: 0x040003DE RID: 990
	private bool hasTouchedB;

	// Token: 0x040003DF RID: 991
	private int counter;

	// Token: 0x040003E0 RID: 992
	public int passThreshold = 3;

	// Token: 0x040003E1 RID: 993
	public ScooterController scooterController;

	// Token: 0x040003E2 RID: 994
	public TeleportPlayer teleportPlayer;

	// Token: 0x040003E3 RID: 995
	public TutorialManager tutorialManager;

	// Token: 0x040003E4 RID: 996
	public Rigidbody playerRigidbody;

	// Token: 0x040003E5 RID: 997
	public float pointOffset = 0.5f;

	// Token: 0x040003E6 RID: 998
	private Vector3 centerOffset;

	// Token: 0x040003E7 RID: 999
	private Vector3 frontPoint;

	// Token: 0x040003E8 RID: 1000
	private Vector3 backPoint;

	// Token: 0x040003E9 RID: 1001
	private Vector3 upPoint;

	// Token: 0x040003EA RID: 1002
	private Vector3 downPoint;

	// Token: 0x040003EB RID: 1003
	private bool trickcompleted;

	// Token: 0x040003EC RID: 1004
	public PlayerScoring playerscoring;

	// Token: 0x040003ED RID: 1005
	public ManualTutorial.TrickState currentState;

	// Token: 0x040003EE RID: 1006
	private float groundedtimer;

	// Token: 0x020000B3 RID: 179
	public enum TrickState
	{
		// Token: 0x040003F0 RID: 1008
		Manual,
		// Token: 0x040003F1 RID: 1009
		NoseManual
	}
}
