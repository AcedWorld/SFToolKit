using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200012F RID: 303
public class CharacterFollow : MonoBehaviour
{
	// Token: 0x060004E3 RID: 1251 RVA: 0x00021EBF File Offset: 0x000200BF
	private void Update()
	{
		if (this.updateMode == UpdateMode.Update)
		{
			this.MatchTransforms();
		}
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00021ECF File Offset: 0x000200CF
	private void LateUpdate()
	{
		if (this.updateMode == UpdateMode.LateUpdate)
		{
			this.MatchTransforms();
		}
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00021EE0 File Offset: 0x000200E0
	private void FixedUpdate()
	{
		if (this.updateMode == UpdateMode.FixedUpdate)
		{
			this.MatchTransforms();
		}
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00021EF4 File Offset: 0x000200F4
	private void MatchTransforms()
	{
		this.SynchronizeTransform(this.playerComponents.hips, this.targetComponents.hips);
		this.SynchronizeTransform(this.playerComponents.leftUpLeg, this.targetComponents.leftUpLeg);
		this.SynchronizeTransform(this.playerComponents.leftLeg, this.targetComponents.leftLeg);
		this.SynchronizeTransform(this.playerComponents.leftFoot, this.targetComponents.leftFoot);
		this.SynchronizeTransform(this.playerComponents.rightUpLeg, this.targetComponents.rightUpLeg);
		this.SynchronizeTransform(this.playerComponents.rightLeg, this.targetComponents.rightLeg);
		this.SynchronizeTransform(this.playerComponents.rightFoot, this.targetComponents.rightFoot);
		this.SynchronizeTransform(this.playerComponents.spine1, this.targetComponents.spine1);
		this.SynchronizeTransform(this.playerComponents.spine2, this.targetComponents.spine2);
		this.SynchronizeTransform(this.playerComponents.leftShoulder, this.targetComponents.leftShoulder);
		this.SynchronizeTransform(this.playerComponents.leftArm, this.targetComponents.leftArm);
		this.SynchronizeTransform(this.playerComponents.leftForeArm, this.targetComponents.leftForeArm);
		this.SynchronizeTransform(this.playerComponents.leftHand, this.targetComponents.leftHand);
		this.SynchronizeTransform(this.playerComponents.rightShoulder, this.targetComponents.rightShoulder);
		this.SynchronizeTransform(this.playerComponents.rightArm, this.targetComponents.rightArm);
		this.SynchronizeTransform(this.playerComponents.rightForeArm, this.targetComponents.rightForeArm);
		this.SynchronizeTransform(this.playerComponents.rightHand, this.targetComponents.rightHand);
		this.SynchronizeTransform(this.playerComponents.neck, this.targetComponents.neck);
		this.SynchronizeTransform(this.playerComponents.head, this.targetComponents.head);
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00022115 File Offset: 0x00020315
	private void SynchronizeTransform(Transform player, Transform target)
	{
		if (player != null && target != null)
		{
			player.position = target.position;
			player.rotation = target.rotation;
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00022144 File Offset: 0x00020344
	private void SynchronizeFingers(List<Transform> playerFingers, List<Transform> targetFingers)
	{
		if (playerFingers.Count != targetFingers.Count)
		{
			Debug.LogError("Mismatch in number of finger bones.");
			return;
		}
		for (int i = 0; i < playerFingers.Count; i++)
		{
			this.SynchronizeTransform(playerFingers[i], targetFingers[i]);
		}
	}

	// Token: 0x040007B5 RID: 1973
	public Transform playerTransform;

	// Token: 0x040007B6 RID: 1974
	public Transform targetTransform;

	// Token: 0x040007B7 RID: 1975
	public CharacterComponents playerComponents = new CharacterComponents();

	// Token: 0x040007B8 RID: 1976
	public CharacterComponents targetComponents = new CharacterComponents();

	// Token: 0x040007B9 RID: 1977
	public UpdateMode updateMode;
}
