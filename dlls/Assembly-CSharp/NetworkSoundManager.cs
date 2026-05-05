using System;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class NetworkSoundManager : NetworkBehaviour
{
	// Token: 0x06000224 RID: 548 RVA: 0x000128EC File Offset: 0x00010AEC
	private void Start()
	{
		if (base.IsOwner)
		{
			this.MuteAllSources();
		}
	}

	// Token: 0x06000225 RID: 549 RVA: 0x000128FC File Offset: 0x00010AFC
	private void Update()
	{
		if (!base.IsOwner)
		{
			return;
		}
		if (this.onFrontCollision != this.scooterController.frontWheelGrounded)
		{
			this.onFrontCollision = this.scooterController.frontWheelGrounded;
			this.CheckAndPlayFrontCollisionSound();
		}
		if (this.onRearCollision != this.scooterController.rearWheelGrounded)
		{
			this.onRearCollision = this.scooterController.rearWheelGrounded;
			this.CheckAndPlayRearCollisionSound();
		}
		if (this.onGroundCollision != this.scooterController.isGrounded)
		{
			this.onGroundCollision = this.scooterController.isGrounded;
			this.CheckAndPlayGroundCollisionSound();
		}
		if (this.onPush != this.pushForce.activeInHierarchy)
		{
			if (this.pushForce.activeInHierarchy)
			{
				this.pushSound01.Play();
			}
			this.onPush = this.pushForce.activeInHierarchy;
		}
		if (this.onGrindCollision != this.lockRotation.isGrinding)
		{
			this.onGrindCollision = this.lockRotation.isGrinding;
			this.CheckAndPlayGrindSound();
		}
		this.UpdateGrindSlideSound();
		this.UpdateRollingSound();
		this.UpdateLandSoundVolume();
		this.UpdateCrashAndSlideSounds();
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00012A10 File Offset: 0x00010C10
	private void MuteAllSources()
	{
		this.A_LandSound02.mute = true;
		this.fenceHit01.mute = true;
		this.fenceHit02.mute = true;
		this.grindHit01.mute = true;
		this.grindHit02.mute = true;
		this.grindHit03.mute = true;
		this.grindHit04.mute = true;
		this.grindSlideSound.mute = true;
		this.rollingSound.mute = true;
		this.crashSlideSound.mute = true;
		this.characterSliding.mute = true;
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00012AA1 File Offset: 0x00010CA1
	private void CheckAndPlayFrontCollisionSound()
	{
		if (this.scooterController.frontWheelGrounded && !this.scooterController.Manual && !this.lockRotation.isGrinding)
		{
			this.frontLandSound = (this.frontLandSound + 1) % 3;
			this.PlayFrontLandSound();
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00012AE0 File Offset: 0x00010CE0
	private void CheckAndPlayRearCollisionSound()
	{
		if (this.scooterController.rearWheelGrounded && !this.scooterController.NoseManual && !this.lockRotation.isGrinding)
		{
			this.rearLandSound = (this.rearLandSound + 1) % 3;
			this.PlayRearLandSound();
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00012B20 File Offset: 0x00010D20
	private void CheckAndPlayGroundCollisionSound()
	{
		if (this.scooterController.isGrounded && this.scooterController.mainRaycast.transform != null && this.scooterController.mainRaycast.distance < 0.5f && this.scooterController.mainRaycast.transform.CompareTag("MeshFence"))
		{
			this.fenceHitCount = !this.fenceHitCount;
			this.PlayFenceHitSound();
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00012B9A File Offset: 0x00010D9A
	private void CheckAndPlayGrindSound()
	{
		if (this.lockRotation.isGrinding)
		{
			this.GrindHitCount = (this.GrindHitCount + 1) % 4;
			this.PlayGrindHitSound();
		}
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00012BC0 File Offset: 0x00010DC0
	private void UpdateGrindSlideSound()
	{
		this.grindSlideSound.pitch = Mathf.Lerp(this.grindSlideSound.pitch, this.grindSlidePitch, this.grindSlidePitchSmooth * Time.deltaTime);
		if (this.lockRotation.isGrinding)
		{
			this.grindSlidePitch = 1.2f;
			this.grindSlideSound.volume = Mathf.Min(this.playerRB.velocity.magnitude / this.grindSlideTweaker, this.maxGrindSlideVolume);
			return;
		}
		this.grindSlideSound.volume = 0f;
		this.grindSlidePitch = 1.1f;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x00012C60 File Offset: 0x00010E60
	private void UpdateRollingSound()
	{
		this.rollingPitch = Mathf.Lerp(this.rollingPitch, this.rollingPitchTarget, this.rollingPitchSmooth * Time.deltaTime);
		this.rollingSound.pitch = this.rollingPitch;
		if (this.pushForce.activeInHierarchy || !this.scooterController.isGrounded || this.pumpMechanic.playerIsPumping)
		{
			this.rollingPitchTarget = 1.2f;
		}
		else
		{
			this.rollingPitchTarget = 1f;
		}
		if (!this.ragdollControl.ragdollActive)
		{
			this.tempRollingVolume = Mathf.Min(this.playerRB.velocity.magnitude / this.rollingTweaker, this.maxRollingVolume);
			if (this.scooterController.isGrounded && !this.lockRotation.isGrinding)
			{
				this.rollingSound.volume = this.tempRollingVolume;
				this.lastRollingVolume = this.tempRollingVolume;
			}
			else
			{
				this.rollingSound.volume = this.lastRollingVolume / this.RollingDivideWhenAir;
			}
		}
		if (this.ragdollControl.ragdollActive || this.characterStates.currentState == CharacterState.Walking)
		{
			this.rollingSound.volume = 0f;
		}
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00012D94 File Offset: 0x00010F94
	private void UpdateLandSoundVolume()
	{
		this.landSoundVolume = Mathf.Clamp(this.playerRB.velocity.magnitude / this.landSoundDivider, 0f, this.maxLandSoundVolume);
		this.A_LandSound02.volume = this.landSoundVolume;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00012DE4 File Offset: 0x00010FE4
	private void UpdateCrashAndSlideSounds()
	{
		this.crashSlideSound.volume = (this.ragdollControl.ragdollActive ? (this.playerRB.velocity.magnitude / this.crashSlideSoundDivider) : 0f);
		if (!this.ragdollControl.ragdollActive || !this.playBodyHitSound.colliding)
		{
			this.characterSliding.volume = 0f;
			return;
		}
		this.characterSliding.volume = this.characterRB.velocity.magnitude / this.characterSlidingDivider;
	}

	// Token: 0x0600022F RID: 559 RVA: 0x00012E7A File Offset: 0x0001107A
	private void PlayFrontLandSound()
	{
		this.A_LandSound02.pitch = Random.Range(0.8f, 1f);
		this.A_LandSound02.volume = 0.5f;
		this.A_LandSound02.Play();
	}

	// Token: 0x06000230 RID: 560 RVA: 0x00012EB1 File Offset: 0x000110B1
	private void PlayRearLandSound()
	{
		this.A_LandSound02.pitch = Random.Range(1f, 1.4f);
		this.A_LandSound02.volume = 0.5f;
		this.A_LandSound02.Play();
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00012EE8 File Offset: 0x000110E8
	private void PlayFenceHitSound()
	{
		if (this.fenceHitCount)
		{
			this.fenceHit01.Play();
			return;
		}
		this.fenceHit02.Play();
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00012F0C File Offset: 0x0001110C
	private void PlayGrindHitSound()
	{
		switch (this.GrindHitCount)
		{
		case 0:
			this.grindHit01.Play();
			return;
		case 1:
			this.grindHit02.Play();
			return;
		case 2:
			this.grindHit03.Play();
			return;
		case 3:
			this.grindHit04.Play();
			return;
		default:
			return;
		}
	}

	// Token: 0x06000233 RID: 563 RVA: 0x00012F68 File Offset: 0x00011168
	public void PlayScooterCrashHitSound()
	{
		if (!this.ragdollControl.ragdollActive)
		{
			return;
		}
		this.scooterCrashHitSoundCount = (this.scooterCrashHitSoundCount + 1) % 6;
		switch (this.scooterCrashHitSoundCount)
		{
		case 0:
			this.scooterHitGround01.Play();
			return;
		case 1:
			this.scooterHitGround02.Play();
			return;
		case 2:
			this.scooterHitGround03.Play();
			return;
		case 3:
			this.scooterHitGround04.Play();
			return;
		case 4:
			this.scooterHitGround05.Play();
			return;
		case 5:
			this.scooterHitGround06.Play();
			return;
		default:
			return;
		}
	}

	// Token: 0x06000234 RID: 564 RVA: 0x00013000 File Offset: 0x00011200
	public void PlayBodyHitSound()
	{
		this.deepBodyHit01.Play();
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00013010 File Offset: 0x00011210
	public void PlayLimbHitSound()
	{
		this.limbHitCount = (this.limbHitCount + 1) % 3;
		switch (this.limbHitCount)
		{
		case 0:
			this.bodyHit01.Play();
			return;
		case 1:
			this.bodyHit02.Play();
			return;
		case 2:
			this.bodyHit03.Play();
			return;
		default:
			return;
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0001306A File Offset: 0x0001126A
	public void PlayHelmetHit()
	{
		this.helmetHit01.Play();
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0001308C File Offset: 0x0001128C
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0000209E File Offset: 0x0000029E
	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	// Token: 0x0600023A RID: 570 RVA: 0x000130A2 File Offset: 0x000112A2
	protected internal override string __getTypeName()
	{
		return "NetworkSoundManager";
	}

	// Token: 0x040002A7 RID: 679
	public ScooterController scooterController;

	// Token: 0x040002A8 RID: 680
	public LockRotation lockRotation;

	// Token: 0x040002A9 RID: 681
	public RagdollControl ragdollControl;

	// Token: 0x040002AA RID: 682
	public Rigidbody playerRB;

	// Token: 0x040002AB RID: 683
	public PumpMechanic pumpMechanic;

	// Token: 0x040002AC RID: 684
	public CharacterStates characterStates;

	// Token: 0x040002AD RID: 685
	public GameObject pushForce;

	// Token: 0x040002AE RID: 686
	private bool onPush;

	// Token: 0x040002AF RID: 687
	public AudioSource pushSound01;

	// Token: 0x040002B0 RID: 688
	public AudioSource A_LandSound02;

	// Token: 0x040002B1 RID: 689
	private float landSoundVolume;

	// Token: 0x040002B2 RID: 690
	public float landSoundDivider;

	// Token: 0x040002B3 RID: 691
	private float maxLandSoundVolume = 0.3f;

	// Token: 0x040002B4 RID: 692
	public AudioSource fenceHit01;

	// Token: 0x040002B5 RID: 693
	public AudioSource fenceHit02;

	// Token: 0x040002B6 RID: 694
	private bool fenceHitCount;

	// Token: 0x040002B7 RID: 695
	public bool onFrontCollision;

	// Token: 0x040002B8 RID: 696
	public bool onRearCollision;

	// Token: 0x040002B9 RID: 697
	public bool onGroundCollision;

	// Token: 0x040002BA RID: 698
	private int frontLandSound;

	// Token: 0x040002BB RID: 699
	private int rearLandSound;

	// Token: 0x040002BC RID: 700
	public bool onGrindCollision;

	// Token: 0x040002BD RID: 701
	public int GrindHitCount;

	// Token: 0x040002BE RID: 702
	public AudioSource grindHit01;

	// Token: 0x040002BF RID: 703
	public AudioSource grindHit02;

	// Token: 0x040002C0 RID: 704
	public AudioSource grindHit03;

	// Token: 0x040002C1 RID: 705
	public AudioSource grindHit04;

	// Token: 0x040002C2 RID: 706
	public AudioSource grindSlideSound;

	// Token: 0x040002C3 RID: 707
	public float maxGrindSlideVolume;

	// Token: 0x040002C4 RID: 708
	public float grindSlideTweaker;

	// Token: 0x040002C5 RID: 709
	private float grindSlidePitch;

	// Token: 0x040002C6 RID: 710
	public float grindSlidePitchSmooth;

	// Token: 0x040002C7 RID: 711
	public AudioSource rollingSound;

	// Token: 0x040002C8 RID: 712
	public float rollingTweaker;

	// Token: 0x040002C9 RID: 713
	private float lastRollingVolume;

	// Token: 0x040002CA RID: 714
	private float rollingPitch;

	// Token: 0x040002CB RID: 715
	private float tempRollingVolume;

	// Token: 0x040002CC RID: 716
	private float rollingPitchTarget;

	// Token: 0x040002CD RID: 717
	public float maxRollingVolume;

	// Token: 0x040002CE RID: 718
	public float rollingPitchSmooth;

	// Token: 0x040002CF RID: 719
	public float RollingDivideWhenAir;

	// Token: 0x040002D0 RID: 720
	public AudioSource crashSlideSound;

	// Token: 0x040002D1 RID: 721
	public float crashSlideSoundDivider;

	// Token: 0x040002D2 RID: 722
	public AudioSource characterSliding;

	// Token: 0x040002D3 RID: 723
	public float characterSlidingDivider;

	// Token: 0x040002D4 RID: 724
	public Rigidbody characterRB;

	// Token: 0x040002D5 RID: 725
	public PlayBodyHitSound playBodyHitSound;

	// Token: 0x040002D6 RID: 726
	public AudioSource scooterHitGround01;

	// Token: 0x040002D7 RID: 727
	public AudioSource scooterHitGround02;

	// Token: 0x040002D8 RID: 728
	public AudioSource scooterHitGround03;

	// Token: 0x040002D9 RID: 729
	public AudioSource scooterHitGround04;

	// Token: 0x040002DA RID: 730
	public AudioSource scooterHitGround05;

	// Token: 0x040002DB RID: 731
	public AudioSource scooterHitGround06;

	// Token: 0x040002DC RID: 732
	private int scooterCrashHitSoundCount;

	// Token: 0x040002DD RID: 733
	public AudioSource bodyHit01;

	// Token: 0x040002DE RID: 734
	public AudioSource bodyHit02;

	// Token: 0x040002DF RID: 735
	public AudioSource bodyHit03;

	// Token: 0x040002E0 RID: 736
	public AudioSource deepBodyHit01;

	// Token: 0x040002E1 RID: 737
	public AudioSource helmetHit01;

	// Token: 0x040002E2 RID: 738
	private int limbHitCount;
}
