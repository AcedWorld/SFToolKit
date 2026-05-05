using System;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

// Token: 0x020001A5 RID: 421
[Serializable]
public class RagdollReferencedItems
{
	// Token: 0x04000B84 RID: 2948
	[Header("Colliders")]
	public BoxCollider deckCollider;

	// Token: 0x04000B85 RID: 2949
	public CapsuleCollider neckCollider;

	// Token: 0x04000B86 RID: 2950
	public CapsuleCollider mainPlayerCollider;

	// Token: 0x04000B87 RID: 2951
	[Header("Scripts")]
	public BipedIK bipedIK;

	// Token: 0x04000B88 RID: 2952
	public Vibration vibration;

	// Token: 0x04000B89 RID: 2953
	public Hop playerHop;

	// Token: 0x04000B8A RID: 2954
	public LandCorrection landCorrection;

	// Token: 0x04000B8B RID: 2955
	public LockRotation lockRotation;

	// Token: 0x04000B8C RID: 2956
	public ScooterRagdoll scooterRagdoll;

	// Token: 0x04000B8D RID: 2957
	public CharacterStates characterStates;

	// Token: 0x04000B8E RID: 2958
	public BehaviourFall behaviourFall;

	// Token: 0x04000B8F RID: 2959
	[Header("Rigidbodies")]
	public Rigidbody playerRigidbody;

	// Token: 0x04000B90 RID: 2960
	public Rigidbody ragdollHipsRigidbody;

	// Token: 0x04000B91 RID: 2961
	public Rigidbody ragdollSpineRigidbody;

	// Token: 0x04000B92 RID: 2962
	[Header("Other")]
	public Animator playerAnimator;

	// Token: 0x04000B93 RID: 2963
	public Animator characterAnimator;

	// Token: 0x04000B94 RID: 2964
	public PuppetMaster puppetMaster;

	// Token: 0x04000B95 RID: 2965
	public GameObject PupperMasterController;
}
