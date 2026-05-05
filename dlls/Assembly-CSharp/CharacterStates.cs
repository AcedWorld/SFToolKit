using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

// Token: 0x020001E0 RID: 480
public class CharacterStates : MonoBehaviour
{
	// Token: 0x06000774 RID: 1908 RVA: 0x00037120 File Offset: 0x00035320
	private void Start()
	{
		this.ResetPuppetMaster();
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00037128 File Offset: 0x00035328
	private void OnEnable()
	{
		this.CharacterScripts.bipedIK.enabled = true;
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x0003713B File Offset: 0x0003533B
	private void Update()
	{
		if (this.CharacterScripts.boneAnimator.initialPositions != null && !this.TriggerScooterReturn)
		{
			this.AnimateToCharacter();
		}
		if (this.TriggerScooterReturn)
		{
			this.AnimateToScooter();
		}
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x0003716C File Offset: 0x0003536C
	private void FixedUpdate()
	{
		if (this.currentState == CharacterState.Ragdolling && this.UseGetUpPrompt)
		{
			if (!this.playerScripts.ragdollControl.puppetMasterSetupSequence.SequencePuppetSetup && this.Rigidbodies.puppetHips.velocity.magnitude < 0.4f && !this.XboxGetUpPrompt.activeSelf && !this.PlaystationGetUpPrompt.activeSelf)
			{
				if (this.playerScripts.controllerTypeInGame.controllerType == 0)
				{
					this.PlaystationGetUpPrompt.SetActive(true);
				}
				if (this.playerScripts.controllerTypeInGame.controllerType == 1)
				{
					this.XboxGetUpPrompt.SetActive(true);
					return;
				}
			}
		}
		else if (this.XboxGetUpPrompt.activeSelf || this.PlaystationGetUpPrompt.activeSelf)
		{
			this.XboxGetUpPrompt.SetActive(false);
			this.PlaystationGetUpPrompt.SetActive(false);
		}
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x00037258 File Offset: 0x00035458
	public void ChangeCharacterState()
	{
		if (this.currentState == CharacterState.Walking)
		{
			this.GetOnScooter();
		}
		if (this.currentState == CharacterState.Idle)
		{
			if (Vector3.Angle(this.ReferencedTransforms.Player.up, Vector3.up) <= 25f && this.Rigidbodies.player.velocity.magnitude <= 15f)
			{
				this.GetOffScooter();
			}
			else
			{
				this.playerScripts.ragdollControl.ActivateRagdoll();
			}
		}
		if (this.currentState == CharacterState.Ragdolling && !this.playerScripts.ragdollControl.puppetMasterSetupSequence.SequencePuppetSetup && this.Rigidbodies.puppetHips.velocity.magnitude < 0.4f)
		{
			this.GetUpFromRagdoll();
		}
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x0003731C File Offset: 0x0003551C
	public void GetOnScooter()
	{
		this.currentState = CharacterState.GettingOnScooter;
		this.TogglePlayerScripts(true);
		this.playerScripts.ragdollControl.DeactivateRagoll();
		this.StoreCharacterVelocity();
		this.initialRotationCharacter = this.ReferencedTransforms.character.transform.rotation;
		this.ResetPuppetMaster();
		this.ApplyCharacterVelocityToPlayer();
		this.CharacterScripts.boneAnimator.RecordTargetPositionsAndRotations();
		this.Timing.blendTimer = 0f;
		this.TriggerScooterReturn = true;
		this.ToggleCharacterComponents(false, true);
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x000373A4 File Offset: 0x000355A4
	public void GetOffScooter()
	{
		this.currentState = CharacterState.GettingOffScooter;
		this.ReferencedTransforms.character.SetParent(this.ReferencedTransforms.HolderParent);
		this.playerScripts.ragdollControl.ActivateRagdoll();
		this.TogglePlayerScripts(false);
		this.CharacterScripts.boneAnimator.RecordInitialPositionsAndRotations();
		this.CharacterScripts.bipedIK.enabled = false;
		this.playerScripts.grindSystem.StopGrinding(true, true);
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x0003741D File Offset: 0x0003561D
	public void GetUpFromRagdoll()
	{
		this.currentState = CharacterState.GettingUp;
		this.CharacterScripts.puppetMaster.Resurrect();
		this.TogglePlayerScripts(false);
		base.StartCoroutine(this.DelayToWalkState());
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x0003744A File Offset: 0x0003564A
	private IEnumerator DelayToWalkState()
	{
		yield return new WaitForSeconds(this.Timing.timeToStandUp / 2f);
		this.playerScripts.CinemachineCameraCopy.TransitionBackToOriginal();
		yield return new WaitForSeconds(this.Timing.timeToStandUp / 2f);
		this.PlayerHasStoodUp();
		this.playerScripts.CinemachineCameraCopy.cameraSwitched = false;
		yield break;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x00037459 File Offset: 0x00035659
	public void PlayerHasStoodUp()
	{
		if (this.currentState == CharacterState.GettingUp)
		{
			this.PupperMasterController.SetActive(false);
			this.ToggleCharacterComponents(true, true);
			this.currentState = CharacterState.Walking;
			this.playerScripts.ragdollControl.CharacterCollidesWithScooter(true);
		}
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x00037490 File Offset: 0x00035690
	private void AnimateToCharacter()
	{
		if (this.currentState != CharacterState.GettingOffScooter)
		{
			return;
		}
		if (!this.playerScripts.scooterController.isGrounded)
		{
			this.ToggleCharacterComponents(true, false);
		}
		if (this.Timing.blendTimer >= this.Timing.blendDuration)
		{
			this.characterRotationCorrector = false;
			this.ToggleCharacterComponents(true, true);
			this.playerScripts.ragdollControl.CharacterCollidesWithScooter(true);
			this.currentState = CharacterState.Walking;
			return;
		}
		this.characterRotationCorrector = true;
		this.Timing.blendTimer += Time.deltaTime;
		float blendProgress = Mathf.Clamp01(this.Timing.blendTimer / this.Timing.blendDuration);
		if (this.playerScripts.scooterController.isGrounded)
		{
			if (this.PlayGetOffAnimation)
			{
				this.ReferencedAnimators.character.Play("PushOffScooter");
			}
			this.CharacterScripts.boneAnimator.AnimateBones(this.CharacterScripts.boneAnimator.initialPositions, this.CharacterScripts.boneAnimator.initialRotations, this.CharacterScripts.boneAnimator.targetPositionsChar, this.CharacterScripts.boneAnimator.targetRotationsChar, blendProgress);
			return;
		}
		this.ReferencedAnimators.character.SetBool("IsGrounded", false);
		this.ReferencedAnimators.character.Play("Falling2");
		this.CharacterScripts.boneAnimator.AnimateBones(this.CharacterScripts.boneAnimator.initialPositions, this.CharacterScripts.boneAnimator.initialRotations, this.CharacterScripts.boneAnimator.targetPositionsFall, this.CharacterScripts.boneAnimator.targetRotationsFall, blendProgress);
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x00037640 File Offset: 0x00035840
	private void AnimateToScooter()
	{
		this.ReferencedAnimators.player.Play("ScooterIdle");
		this.ReferencedAnimators.character.Rebind();
		this.ReferencedTransforms.character.transform.position = this.ReferencedTransforms.Player.position;
		Quaternion quaternion = this.ReferencedTransforms.Player.rotation * Quaternion.Euler(0f, 180f, 0f);
		if (this.Timing.blendTimer < this.Timing.blendDuration)
		{
			this.Timing.blendTimer += Time.deltaTime;
			float num = Mathf.Clamp01(this.Timing.blendTimer / this.Timing.blendDuration);
			this.CharacterScripts.boneAnimator.AnimateBones(this.CharacterScripts.boneAnimator.targetPositions, this.CharacterScripts.boneAnimator.targetRotations, this.CharacterScripts.boneAnimator.reverseInitialPositions, this.CharacterScripts.boneAnimator.reverseInitialRotations, num);
			this.ReferencedTransforms.character.transform.rotation = Quaternion.Slerp(this.initialRotationCharacter, quaternion, num);
			return;
		}
		this.CharacterScripts.bipedIK.enabled = true;
		this.CharacterScripts.boneAnimator.ResetBonesPositions();
		this.ReferencedTransforms.character.transform.rotation = quaternion;
		this.TriggerScooterReturn = false;
		this.ResetPuppetMaster();
		this.CharacterScripts.boneAnimator.SetBonesNull();
		this.currentState = CharacterState.Idle;
		this.ReferencedTransforms.character.SetParent(this.ReferencedTransforms.Player);
		this.Rigidbodies.character.interpolation = RigidbodyInterpolation.None;
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x0003780B File Offset: 0x00035A0B
	private void StoreCharacterVelocity()
	{
		this.humanVelocity = this.Rigidbodies.character.velocity;
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x00037824 File Offset: 0x00035A24
	private void ApplyCharacterVelocityToPlayer()
	{
		float y = this.ReferencedTransforms.character.rotation.eulerAngles.y;
		int mask = LayerMask.GetMask(new string[]
		{
			"Default"
		});
		RaycastHit raycastHit;
		if (Physics.Raycast(this.ReferencedTransforms.character.position, Vector3.down, out raycastHit, 1f, mask))
		{
			Vector3 normal = raycastHit.normal;
			Quaternion lhs = Quaternion.LookRotation(Vector3.ProjectOnPlane(this.ReferencedTransforms.character.forward, normal), normal);
			this.ReferencedTransforms.Player.rotation = lhs * Quaternion.Euler(0f, 180f, 0f);
		}
		else
		{
			this.ReferencedTransforms.Player.rotation = Quaternion.Euler(0f, y + 180f, 0f);
		}
		this.ReferencedTransforms.Player.position = new Vector3(this.ReferencedTransforms.character.position.x, this.ReferencedTransforms.character.position.y + 0.008f, this.ReferencedTransforms.character.position.z);
		Physics.SyncTransforms();
		Vector3 a = Vector3.Project(this.humanVelocity, this.ReferencedTransforms.character.forward);
		Vector3 b = Vector3.Project(this.humanVelocity, this.ReferencedTransforms.character.up);
		Vector3 a2 = a + b;
		float d = 1f;
		Vector3 b2 = this.ReferencedTransforms.character.forward * d;
		this.Rigidbodies.player.velocity = a2 + b2;
		this.Rigidbodies.player.angularVelocity = Vector3.zero;
		this.playerScripts.landCorrection.UpdateLandRotation();
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x00037A01 File Offset: 0x00035C01
	public void UnparentCharacter()
	{
		if (this.currentState == CharacterState.Idle)
		{
			this.ReferencedTransforms.character.SetParent(this.ReferencedTransforms.HolderParent);
		}
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x00037A28 File Offset: 0x00035C28
	public void HardResetToScooter()
	{
		this.TogglePlayerScripts(false);
		this.ResetPuppetMaster();
		this.ToggleCharacterComponents(false, true);
		this.CharacterScripts.boneAnimator.ResetBonesPositions();
		this.TogglePlayerScripts(true);
		this.CharacterScripts.boneAnimator.SetBonesNull();
		this.playerScripts.ragdollControl.DeactivateRagoll();
		this.currentState = CharacterState.Idle;
		this.ReferencedTransforms.character.SetParent(this.ReferencedTransforms.Player);
		this.ReferencedAnimators.character.Rebind();
		this.CharacterScripts.bipedIK.enabled = true;
		this.Rigidbodies.character.interpolation = RigidbodyInterpolation.None;
		this.playerScripts.CinemachineCameraCopy.TransitionBackToOriginal();
		this.playerScripts.CinemachineCameraCopy.cameraSwitched = false;
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x00037AF8 File Offset: 0x00035CF8
	public void CameraHolderReset()
	{
		this.ReferencedTransforms.CameraHolder.localPosition = Vector3.zero;
		this.ReferencedTransforms.CameraHolder.localRotation = Quaternion.identity;
		this.ReferencedTransforms.CameraHolder.localScale = Vector3.one;
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x00037B44 File Offset: 0x00035D44
	public void ResetPuppetMaster()
	{
		this.PupperMasterController.SetActive(false);
		this.CharacterScripts.puppetMaster.thumpRebuild();
		this.CharacterScripts.puppetMaster.state = PuppetMaster.State.Dead;
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x00037B74 File Offset: 0x00035D74
	private void TogglePlayerScripts(bool OnOrOff)
	{
		if (!OnOrOff)
		{
			this.playerScripts.scooterController.ResetScooterController();
		}
		this.playerScripts.scooterController.enabled = OnOrOff;
		this.playerScripts.playerHop.enabled = OnOrOff;
		this.playerScripts.landCorrection.enabled = OnOrOff;
		this.playerScripts.upright.enabled = OnOrOff;
		this.playerScripts.pumpMechanic.enabled = OnOrOff;
		this.playerScripts.rampDirection.enabled = OnOrOff;
		this.playerScripts.lockRotation.enabled = OnOrOff;
		this.ReferencedAnimators.player.enabled = OnOrOff;
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x00037C1C File Offset: 0x00035E1C
	public void ToggleCharacterComponents(bool OnOrOff, bool toggleAnimator = true)
	{
		if (toggleAnimator)
		{
			this.ReferencedAnimators.character.enabled = OnOrOff;
		}
		this.CharacterCollider.enabled = OnOrOff;
		this.CharacterLeftFootCollider.enabled = OnOrOff;
		this.CharacterRightFootCollider.enabled = OnOrOff;
		this.CharacterScripts.VThirdPersonController.enabled = OnOrOff;
		this.CharacterScripts.VThirdPersonInput.enabled = OnOrOff;
		this.CharacterScripts.VFootStep.enabled = OnOrOff;
		this.Rigidbodies.character.isKinematic = !OnOrOff;
	}

	// Token: 0x04000D26 RID: 3366
	public bool debug;

	// Token: 0x04000D27 RID: 3367
	public bool PlayGetOffAnimation;

	// Token: 0x04000D28 RID: 3368
	[Header("State Management")]
	public CharacterState currentState;

	// Token: 0x04000D29 RID: 3369
	[Header("Bools")]
	public bool TriggerScooterReturn;

	// Token: 0x04000D2A RID: 3370
	[Header("Colliders")]
	public CapsuleCollider CharacterCollider;

	// Token: 0x04000D2B RID: 3371
	public SphereCollider CharacterLeftFootCollider;

	// Token: 0x04000D2C RID: 3372
	public SphereCollider CharacterRightFootCollider;

	// Token: 0x04000D2D RID: 3373
	[Header("GameObjects")]
	public GameObject PupperMasterController;

	// Token: 0x04000D2E RID: 3374
	public GameObject PlaystationGetUpPrompt;

	// Token: 0x04000D2F RID: 3375
	public GameObject XboxGetUpPrompt;

	// Token: 0x04000D30 RID: 3376
	public bool UseGetUpPrompt;

	// Token: 0x04000D31 RID: 3377
	[Header("Rigidbodies")]
	public Rigidbodies Rigidbodies;

	// Token: 0x04000D32 RID: 3378
	[Header("Referenced Animators")]
	public ReferencedAnimators ReferencedAnimators;

	// Token: 0x04000D33 RID: 3379
	[Header("Timing")]
	public Timing Timing;

	// Token: 0x04000D34 RID: 3380
	[Header("Character Scripts")]
	public CharacterScripts CharacterScripts;

	// Token: 0x04000D35 RID: 3381
	[Header("Player Scripts")]
	public playerScripts playerScripts;

	// Token: 0x04000D36 RID: 3382
	[Header("ReferencedTransforms")]
	public ReferencedTransforms ReferencedTransforms;

	// Token: 0x04000D37 RID: 3383
	private Vector3 humanVelocity;

	// Token: 0x04000D38 RID: 3384
	public bool characterRotationCorrector;

	// Token: 0x04000D39 RID: 3385
	private Quaternion initialRotationCharacter;
}
