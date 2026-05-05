using System;
using RootMotion.Dynamics;
using UnityEngine;

// Token: 0x020001A6 RID: 422
public class RagdollControl : MonoBehaviour
{
	// Token: 0x06000697 RID: 1687 RVA: 0x00031E66 File Offset: 0x00030066
	private void Start()
	{
		this.DeactivateRagoll();
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00031E6E File Offset: 0x0003006E
	private void FixedUpdate()
	{
		this.CheckVelocityPrevious();
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00031E78 File Offset: 0x00030078
	private void Update()
	{
		if (this.referencedItems.characterStates.currentState == CharacterState.Ragdolling)
		{
			if (this.puppetMasterSetupSequence.SequencePuppetSetup)
			{
				this.puppetMasterSetupSequence.SequenceTimer += Time.deltaTime;
				if (this.puppetMasterSetupSequence.SequenceTimer >= 0.15f)
				{
					this.referencedItems.characterAnimator.Play("Falling");
					this.referencedItems.puppetMaster.state = PuppetMaster.State.Alive;
				}
				if (this.puppetMasterSetupSequence.SequenceTimer >= 0.2f)
				{
					this.referencedItems.puppetMaster.state = PuppetMaster.State.Dead;
					this.puppetMasterSetupSequence.SequenceTimer = 0f;
					this.puppetMasterSetupSequence.SequencePuppetSetup = false;
				}
			}
			if (this.puppetMasterSetupSequence.rotationStarted)
			{
				this.puppetMasterSetupSequence.rotationTimer += Time.deltaTime;
				this.referencedItems.ragdollHipsRigidbody.AddRelativeTorque(Vector3.right * -this.puppetVelocitySettings.localXAngularVelocity * 50000f * this.ragdollSettings.ragdollMultiply);
				this.referencedItems.ragdollSpineRigidbody.AddRelativeTorque(Vector3.right * -this.puppetVelocitySettings.localXAngularVelocity * 50000f * this.ragdollSettings.ragdollMultiply);
				if (this.puppetMasterSetupSequence.rotationTimer >= 0.2f)
				{
					this.puppetMasterSetupSequence.rotationStarted = false;
					this.puppetMasterSetupSequence.rotationTimer = 0f;
				}
			}
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00032010 File Offset: 0x00030210
	public void ActivateRagdoll()
	{
		if (!this.ragdollActive)
		{
			if (this.referencedItems.characterStates.currentState == CharacterState.Idle)
			{
				this.referencedItems.vibration.Vibrate(0.5f, 1f);
				this.CharacterCollidesWithScooter(false);
				this.referencedItems.scooterRagdoll.AddRagdollComponents();
				this.RagdollCollidersSetup(true);
				this.DisablePlayerFunctions();
				this.PuppetMasterInitate();
				this.ragdollActive = true;
			}
			if (this.referencedItems.characterStates.currentState == CharacterState.GettingOffScooter)
			{
				this.CharacterCollidesWithScooter(false);
				this.referencedItems.scooterRagdoll.AddRagdollComponents();
				this.RagdollCollidersSetup(true);
				this.ragdollActive = true;
			}
		}
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x000320BD File Offset: 0x000302BD
	public void DeactivateRagoll()
	{
		this.RagdollCollidersSetup(false);
		this.referencedItems.playerAnimator.Rebind();
		this.CharacterCollidesWithScooter(false);
		this.referencedItems.scooterRagdoll.RemoveRagdollComponents();
		this.ragdollActive = false;
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000320F4 File Offset: 0x000302F4
	public void CharacterCollidesWithScooter(bool enable)
	{
		Physics.IgnoreLayerCollision(8, 23, !enable);
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x00032102 File Offset: 0x00030302
	public void RagdollCollidersSetup(bool enable)
	{
		this.referencedItems.deckCollider.enabled = enable;
		this.referencedItems.neckCollider.enabled = enable;
		this.referencedItems.mainPlayerCollider.enabled = !enable;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x0003213C File Offset: 0x0003033C
	public void DisablePlayerFunctions()
	{
		this.referencedItems.bipedIK.enabled = false;
		this.referencedItems.playerAnimator.enabled = false;
		this.referencedItems.playerHop.enabled = false;
		this.referencedItems.landCorrection.enabled = false;
		this.referencedItems.lockRotation.enabled = false;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x000321A0 File Offset: 0x000303A0
	public void PuppetMasterInitate()
	{
		this.referencedItems.characterStates.UnparentCharacter();
		this.referencedItems.characterStates.currentState = CharacterState.Ragdolling;
		this.referencedItems.puppetMaster.state = PuppetMaster.State.Dead;
		this.referencedItems.PupperMasterController.SetActive(true);
		this.referencedItems.ragdollHipsRigidbody.velocity = this.puppetVelocitySettings.PreviousVelocity * this.ragdollSettings.ragdollMultiply;
		this.referencedItems.ragdollSpineRigidbody.velocity = this.puppetVelocitySettings.PreviousVelocity * this.ragdollSettings.ragdollMultiply;
		this.referencedItems.behaviourFall.enabled = true;
		this.puppetMasterSetupSequence.SequencePuppetSetup = true;
		Vector3 angularVelocity = this.referencedItems.playerRigidbody.angularVelocity;
		Vector3 vector = this.referencedItems.playerRigidbody.transform.InverseTransformDirection(angularVelocity);
		this.puppetVelocitySettings.localXAngularVelocity = vector.x;
		this.puppetVelocitySettings.CachedAngularVelocity = vector;
		this.puppetMasterSetupSequence.rotationStarted = true;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x000322B4 File Offset: 0x000304B4
	public void CheckVelocityPrevious()
	{
		this.puppetVelocitySettings.VelocityTime += Time.deltaTime;
		if (this.puppetVelocitySettings.VelocityTime >= this.puppetVelocitySettings.VelocityDelay)
		{
			this.puppetVelocitySettings.PreviousVelocity = this.referencedItems.playerRigidbody.velocity;
			this.puppetVelocitySettings.PreviousAngularVelocity = this.referencedItems.playerRigidbody.angularVelocity;
			this.puppetVelocitySettings.VelocityTime = 0f;
		}
	}

	// Token: 0x04000B96 RID: 2966
	public bool ragdollActive;

	// Token: 0x04000B97 RID: 2967
	public RagdollReferencedItems referencedItems;

	// Token: 0x04000B98 RID: 2968
	public RagdollSettings ragdollSettings;

	// Token: 0x04000B99 RID: 2969
	public PuppetMasterSetupSequence puppetMasterSetupSequence;

	// Token: 0x04000B9A RID: 2970
	public PuppetVelocitySettings puppetVelocitySettings;
}
