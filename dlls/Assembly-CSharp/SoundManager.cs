using System;
using UnityEngine;

// Token: 0x020001FD RID: 509
public class SoundManager : MonoBehaviour
{
	// Token: 0x060007F9 RID: 2041 RVA: 0x00038F67 File Offset: 0x00037167
	private void Start()
	{
		this.A_LandSound01 = this.landSound01.GetComponent<AudioSource>();
		this.A_LandSound02 = this.landSound02.GetComponent<AudioSource>();
		this.grindSlidePitch = 1f;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00038F98 File Offset: 0x00037198
	private void Update()
	{
		if (this.onFrontCollision != this.scooterController.frontWheelGrounded)
		{
			this.playFrontLandSound01();
			this.onFrontCollision = this.scooterController.frontWheelGrounded;
		}
		if (this.onRearCollision != this.scooterController.rearWheelGrounded)
		{
			this.playRearLandSound01();
			this.onRearCollision = this.scooterController.rearWheelGrounded;
		}
		if (this.onGroundCollision != this.scooterController.isGrounded)
		{
			this.playFenceHit();
			this.onGroundCollision = this.scooterController.isGrounded;
		}
		this.grindSlideSound.pitch = Mathf.Lerp(this.grindSlideSound.pitch, this.grindSlidePitch, this.grindSlidePitchSmooth * Time.deltaTime);
		if (this.onGrindCollision != this.lockRotation.isGrinding)
		{
			this.PlayGrindHitSound();
			this.onGrindCollision = this.lockRotation.isGrinding;
		}
		if (this.lockRotation.isGrinding)
		{
			this.grindSlidePitch = 1.2f;
			if (this.grindSlideSound.volume < this.maxGrindSlideVolume)
			{
				this.grindSlideSound.volume = this.playerRB.velocity.magnitude / this.grindSlideTweaker;
			}
			if (this.grindSlideSound.volume > this.maxGrindSlideVolume)
			{
				this.grindSlideSound.volume = this.maxGrindSlideVolume;
			}
		}
		else
		{
			this.grindSlideSound.volume = 0f;
			this.grindSlidePitch = 1.1f;
		}
		if (this.onDeckCollision != this.deckCollision.deckCollision && !this.lockRotation.isGrinding)
		{
			this.PlayDeckHitSound();
			this.onDeckCollision = this.deckCollision.deckCollision;
		}
		this.rollingPitch = Mathf.Lerp(this.rollingPitch, this.rollingPitchTarget, this.rollingPitchSmooth * Time.deltaTime);
		this.rollingSound.pitch = this.rollingPitch;
		if (this.pumpMechanic.pumpTimer > 0.4f)
		{
			this.rollingPitchTarget = 1.3f;
		}
		else if (this.pushForce.activeInHierarchy)
		{
			this.rollingPitchTarget = 1.2f;
		}
		else if (!this.scooterController.isGrounded)
		{
			this.rollingPitchTarget = 1.4f;
		}
		if (!this.pushForce.activeInHierarchy && this.scooterController.isGrounded && this.pumpMechanic.pumpTimer < 0.4f)
		{
			this.rollingPitchTarget = 1f;
		}
		if (!this.ragdollControl.ragdollActive)
		{
			this.tempRollingVolume = this.playerRB.velocity.magnitude / this.rollingTweaker;
			if (this.rollingSound.volume > this.maxRollingVolume)
			{
				this.tempRollingVolume = this.maxRollingVolume;
			}
			if (this.scooterController.isGrounded && !this.ragdollControl.ragdollActive && !this.lockRotation.isGrinding)
			{
				this.rollingSound.volume = this.tempRollingVolume;
				this.lastRollingVolume = this.tempRollingVolume;
			}
			else if ((!this.scooterController.isGrounded && !this.ragdollControl.ragdollActive) || (this.lockRotation.isGrinding && !this.ragdollControl.ragdollActive))
			{
				this.rollingSound.volume = this.lastRollingVolume / this.RollingDivideWhenAir;
			}
		}
		if (this.ragdollControl.ragdollActive || this.characterStates.currentState == CharacterState.Walking)
		{
			this.rollingSound.volume = 0f;
		}
		if (this.onPush != this.pushForce.activeInHierarchy)
		{
			if (this.pushForce.activeInHierarchy)
			{
				this.PlayPushSound();
			}
			this.onPush = this.pushForce.activeInHierarchy;
		}
		if (this.landSoundVolume < this.maxLandSoundVolume)
		{
			this.landSoundVolume = this.playerRB.velocity.magnitude / this.landSoundDivider;
		}
		else
		{
			this.landSoundVolume = this.maxLandSoundVolume;
		}
		this.A_LandSound01.volume = this.landSoundVolume;
		this.A_LandSound02.volume = this.landSoundVolume;
		if (this.ragdollControl.ragdollActive && this.scooterController)
		{
			this.crashSlideSound.volume = this.playerRB.velocity.magnitude / this.crashSlideSoundDivider;
		}
		if (!this.ragdollControl.ragdollActive)
		{
			this.crashSlideSound.volume = 0f;
		}
		if (!this.ragdollControl.ragdollActive || !this.playBodyHitSound.colliding)
		{
			this.characterSliding.volume = 0f;
		}
		if (this.ragdollControl.ragdollActive && this.playBodyHitSound.colliding)
		{
			this.characterSliding.volume = this.characterRB.velocity.magnitude / this.characterSlidingDivider;
		}
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x00039464 File Offset: 0x00037664
	public void resetRollingSoundVolume()
	{
		this.tempRollingVolume = 0f;
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x00039474 File Offset: 0x00037674
	public void playFrontLandSound01()
	{
		this.A_LandSound01.pitch = Random.Range(0.8f, 1f);
		if (this.scooterController.frontWheelGrounded && !this.scooterController.Manual && !this.lockRotation.isGrinding)
		{
			this.frontLandSound++;
			if (this.frontLandSound == 3)
			{
				this.frontLandSound = 0;
			}
			if (this.frontLandSound == 0)
			{
				this.SpawnAndRecordSound(this.landSound01, this.playersTransform.position, this.landHitSoundParent);
			}
			if (this.frontLandSound == 1)
			{
				this.SpawnAndRecordSound(this.landSound01, this.playersTransform.position, this.landHitSoundParent);
			}
			if (this.frontLandSound == 2)
			{
				this.SpawnAndRecordSound(this.landSound01, this.playersTransform.position, this.landHitSoundParent);
			}
		}
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x0003955C File Offset: 0x0003775C
	public void playRearLandSound01()
	{
		this.A_LandSound02.pitch = Random.Range(1f, 1.4f);
		if (this.scooterController.rearWheelGrounded && !this.scooterController.NoseManual && !this.lockRotation.isGrinding)
		{
			this.rearLandSound++;
			if (this.rearLandSound == 3)
			{
				this.rearLandSound = 0;
			}
			if (this.rearLandSound == 0)
			{
				this.SpawnAndRecordSound(this.landSound02, this.playersTransform.position, this.landHitSoundParent);
			}
			if (this.rearLandSound == 1)
			{
				this.SpawnAndRecordSound(this.landSound02, this.playersTransform.position, this.landHitSoundParent);
			}
			if (this.rearLandSound == 2)
			{
				this.SpawnAndRecordSound(this.landSound02, this.playersTransform.position, this.landHitSoundParent);
			}
		}
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x00039644 File Offset: 0x00037844
	public void PlayGrindHitSound()
	{
		if (this.lockRotation.isGrinding)
		{
			this.GrindHitCount++;
			if (this.GrindHitCount == 4)
			{
				this.GrindHitCount = 0;
			}
			if (this.GrindHitCount == 0)
			{
				this.SpawnAndRecordSound(this.grindHit01, this.playersTransform.position, this.GrindSoundParent);
			}
			if (this.GrindHitCount == 1)
			{
				this.SpawnAndRecordSound(this.grindHit02, this.playersTransform.position, this.GrindSoundParent);
			}
			if (this.GrindHitCount == 2)
			{
				this.SpawnAndRecordSound(this.grindHit03, this.playersTransform.position, this.GrindSoundParent);
			}
			if (this.GrindHitCount == 3)
			{
				this.SpawnAndRecordSound(this.grindHit04, this.playersTransform.position, this.GrindSoundParent);
			}
		}
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00039718 File Offset: 0x00037918
	public void PlayDeckHitSound()
	{
		if (!this.lockRotation.isGrinding && this.deckCollision.deckCollision && !this.ragdollControl.ragdollActive)
		{
			this.GrindHitCount++;
			if (this.GrindHitCount == 4)
			{
				this.GrindHitCount = 0;
			}
			if (this.GrindHitCount == 0)
			{
				this.SpawnAndRecordSound(this.deckHit01, this.playersTransform.position, this.deckHitParent);
			}
			if (this.GrindHitCount == 1)
			{
				this.SpawnAndRecordSound(this.deckHit02, this.playersTransform.position, this.deckHitParent);
			}
			if (this.GrindHitCount == 2)
			{
				this.SpawnAndRecordSound(this.deckHit03, this.playersTransform.position, this.deckHitParent);
			}
			if (this.GrindHitCount == 3)
			{
				this.SpawnAndRecordSound(this.deckHit04, this.playersTransform.position, this.deckHitParent);
			}
		}
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x0003980C File Offset: 0x00037A0C
	public void playFenceHit()
	{
		if (this.scooterController.isGrounded && !this.ragdollControl.ragdollActive && this.scooterController.mainRaycast.transform != null && this.scooterController.mainRaycast.distance < 0.5f && this.scooterController.mainRaycast.transform.tag == "MeshFence")
		{
			this.fenceHitCount = !this.fenceHitCount;
			if (this.fenceHitCount)
			{
				this.SpawnAndRecordSound(this.fenceHit01, this.playersTransform.position, null);
			}
			if (!this.fenceHitCount)
			{
				this.SpawnAndRecordSound(this.fenceHit02, this.playersTransform.position, null);
			}
		}
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000398DC File Offset: 0x00037ADC
	public void PlayScooterCrashHitSound()
	{
		if (this.ragdollControl.ragdollActive)
		{
			this.scooterCrashHitSoundCount++;
			if (this.scooterCrashHitSoundCount == 6)
			{
				this.scooterCrashHitSoundCount = 0;
			}
			if (this.scooterCrashHitSoundCount == 0)
			{
				this.SpawnAndRecordSound(this.scooterHitGround01, this.playersTransform.position, null);
			}
			if (this.scooterCrashHitSoundCount == 1)
			{
				this.SpawnAndRecordSound(this.scooterHitGround02, this.playersTransform.position, null);
			}
			if (this.scooterCrashHitSoundCount == 2)
			{
				this.SpawnAndRecordSound(this.scooterHitGround03, this.playersTransform.position, null);
			}
			if (this.scooterCrashHitSoundCount == 3)
			{
				this.SpawnAndRecordSound(this.scooterHitGround04, this.playersTransform.position, null);
			}
			if (this.scooterCrashHitSoundCount == 4)
			{
				this.SpawnAndRecordSound(this.scooterHitGround05, this.playersTransform.position, null);
			}
			if (this.scooterCrashHitSoundCount == 5)
			{
				this.SpawnAndRecordSound(this.scooterHitGround06, this.playersTransform.position, null);
			}
		}
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x000399DC File Offset: 0x00037BDC
	public void PlayPushSound()
	{
		this.SpawnAndRecordSound(this.pushSound01, this.characterPushingFoot.position, this.characterPushingFoot);
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x000399FB File Offset: 0x00037BFB
	public void PlayBodyHitSound()
	{
		this.SpawnAndRecordSound(this.deepBodyHit01, this.charactersTransform.position, null);
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x00039A18 File Offset: 0x00037C18
	public void PlayLimbHitSound()
	{
		this.limbHitCount++;
		if (this.limbHitCount == 3)
		{
			this.limbHitCount = 0;
		}
		if (this.limbHitCount == 0)
		{
			this.SpawnAndRecordSound(this.bodyHit01, this.charactersTransform.position, null);
		}
		if (this.limbHitCount == 1)
		{
			this.SpawnAndRecordSound(this.bodyHit02, this.charactersTransform.position, null);
		}
		if (this.limbHitCount == 2)
		{
			this.SpawnAndRecordSound(this.bodyHit03, this.charactersTransform.position, null);
		}
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x00039AA5 File Offset: 0x00037CA5
	public void PlayHelmetHit()
	{
		this.SpawnAndRecordSound(this.helmetHit01, this.charactersTransform.position, null);
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x00039AC0 File Offset: 0x00037CC0
	private void SpawnAndRecordSound(GameObject prefab, Vector3 position, Transform parent = null)
	{
		GameObject gameObject;
		if (parent != null)
		{
			gameObject = Object.Instantiate<GameObject>(prefab, position, Quaternion.identity, parent);
		}
		else
		{
			gameObject = Object.Instantiate<GameObject>(prefab, position, Quaternion.identity);
		}
		AudioSource component = gameObject.GetComponent<AudioSource>();
		float pitch = component ? component.pitch : 1f;
		float volume = component ? component.volume : 1f;
		this.replayRecorder.RecordSoundSpawn(prefab, position, pitch, volume);
	}

	// Token: 0x04000DB5 RID: 3509
	public CharacterStates characterStates;

	// Token: 0x04000DB6 RID: 3510
	public Transform playersTransform;

	// Token: 0x04000DB7 RID: 3511
	public Transform charactersTransform;

	// Token: 0x04000DB8 RID: 3512
	public Rigidbody playerRB;

	// Token: 0x04000DB9 RID: 3513
	public LockRotation lockRotation;

	// Token: 0x04000DBA RID: 3514
	public RagdollControl ragdollControl;

	// Token: 0x04000DBB RID: 3515
	public PumpMechanic pumpMechanic;

	// Token: 0x04000DBC RID: 3516
	public Rigidbody characterRB;

	// Token: 0x04000DBD RID: 3517
	public PlayBodyHitSound playBodyHitSound;

	// Token: 0x04000DBE RID: 3518
	public SimpleReplay replayRecorder;

	// Token: 0x04000DBF RID: 3519
	public GameObject landSound01;

	// Token: 0x04000DC0 RID: 3520
	private AudioSource A_LandSound01;

	// Token: 0x04000DC1 RID: 3521
	public GameObject landSound02;

	// Token: 0x04000DC2 RID: 3522
	private AudioSource A_LandSound02;

	// Token: 0x04000DC3 RID: 3523
	private float landSoundVolume;

	// Token: 0x04000DC4 RID: 3524
	public float landSoundDivider;

	// Token: 0x04000DC5 RID: 3525
	public float maxLandSoundVolume;

	// Token: 0x04000DC6 RID: 3526
	public Transform landHitSoundParent;

	// Token: 0x04000DC7 RID: 3527
	private int frontLandSound;

	// Token: 0x04000DC8 RID: 3528
	private int rearLandSound;

	// Token: 0x04000DC9 RID: 3529
	public AudioSource rollingSound;

	// Token: 0x04000DCA RID: 3530
	public GameObject pushForce;

	// Token: 0x04000DCB RID: 3531
	private bool onPush;

	// Token: 0x04000DCC RID: 3532
	public Transform characterPushingFoot;

	// Token: 0x04000DCD RID: 3533
	public GameObject pushSound01;

	// Token: 0x04000DCE RID: 3534
	public bool onFrontCollision;

	// Token: 0x04000DCF RID: 3535
	public bool onRearCollision;

	// Token: 0x04000DD0 RID: 3536
	public bool onGroundCollision;

	// Token: 0x04000DD1 RID: 3537
	public bool onGrindCollision;

	// Token: 0x04000DD2 RID: 3538
	public int GrindHitCount;

	// Token: 0x04000DD3 RID: 3539
	public GameObject grindHit01;

	// Token: 0x04000DD4 RID: 3540
	public GameObject grindHit02;

	// Token: 0x04000DD5 RID: 3541
	public GameObject grindHit03;

	// Token: 0x04000DD6 RID: 3542
	public GameObject grindHit04;

	// Token: 0x04000DD7 RID: 3543
	public Transform GrindSoundParent;

	// Token: 0x04000DD8 RID: 3544
	public AudioSource grindSlideSound;

	// Token: 0x04000DD9 RID: 3545
	public float maxGrindSlideVolume;

	// Token: 0x04000DDA RID: 3546
	public float grindSlideTweaker;

	// Token: 0x04000DDB RID: 3547
	private float grindSlidePitch;

	// Token: 0x04000DDC RID: 3548
	public float grindSlidePitchSmooth;

	// Token: 0x04000DDD RID: 3549
	public DeckCollision deckCollision;

	// Token: 0x04000DDE RID: 3550
	public bool onDeckCollision;

	// Token: 0x04000DDF RID: 3551
	public GameObject deckHit01;

	// Token: 0x04000DE0 RID: 3552
	public GameObject deckHit02;

	// Token: 0x04000DE1 RID: 3553
	public GameObject deckHit03;

	// Token: 0x04000DE2 RID: 3554
	public GameObject deckHit04;

	// Token: 0x04000DE3 RID: 3555
	public Transform deckHitParent;

	// Token: 0x04000DE4 RID: 3556
	public GameObject fenceHit01;

	// Token: 0x04000DE5 RID: 3557
	public GameObject fenceHit02;

	// Token: 0x04000DE6 RID: 3558
	private bool fenceHitCount;

	// Token: 0x04000DE7 RID: 3559
	public float rollingTweaker;

	// Token: 0x04000DE8 RID: 3560
	private float lastRollingVolume;

	// Token: 0x04000DE9 RID: 3561
	private float rollingPitch;

	// Token: 0x04000DEA RID: 3562
	private float tempRollingVolume;

	// Token: 0x04000DEB RID: 3563
	private float rollingPitchTarget;

	// Token: 0x04000DEC RID: 3564
	public float maxRollingVolume;

	// Token: 0x04000DED RID: 3565
	public float rollingPitchSmooth;

	// Token: 0x04000DEE RID: 3566
	public float RollingDivideWhenAir;

	// Token: 0x04000DEF RID: 3567
	public AudioSource crashSlideSound;

	// Token: 0x04000DF0 RID: 3568
	public float crashSlideSoundDivider;

	// Token: 0x04000DF1 RID: 3569
	public ScooterController scooterController;

	// Token: 0x04000DF2 RID: 3570
	public int scooterCrashHitSoundCount;

	// Token: 0x04000DF3 RID: 3571
	public GameObject scooterHitGround01;

	// Token: 0x04000DF4 RID: 3572
	public GameObject scooterHitGround02;

	// Token: 0x04000DF5 RID: 3573
	public GameObject scooterHitGround03;

	// Token: 0x04000DF6 RID: 3574
	public GameObject scooterHitGround04;

	// Token: 0x04000DF7 RID: 3575
	public GameObject scooterHitGround05;

	// Token: 0x04000DF8 RID: 3576
	public GameObject scooterHitGround06;

	// Token: 0x04000DF9 RID: 3577
	public GameObject bodyHit01;

	// Token: 0x04000DFA RID: 3578
	public GameObject bodyHit02;

	// Token: 0x04000DFB RID: 3579
	public GameObject bodyHit03;

	// Token: 0x04000DFC RID: 3580
	public GameObject deepBodyHit01;

	// Token: 0x04000DFD RID: 3581
	public GameObject helmetHit01;

	// Token: 0x04000DFE RID: 3582
	public int limbHitCount;

	// Token: 0x04000DFF RID: 3583
	public AudioSource characterSliding;

	// Token: 0x04000E00 RID: 3584
	public float characterSlidingDivider;
}
