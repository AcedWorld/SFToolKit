using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001D6 RID: 470
public class BoneAnimator : MonoBehaviour
{
	// Token: 0x06000755 RID: 1877 RVA: 0x00036B51 File Offset: 0x00034D51
	private void Start()
	{
		this.initialPositions = null;
		this.FindBones();
		this.SampleTargetAnimationChar();
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x00036B66 File Offset: 0x00034D66
	private void Update()
	{
		if (this.scriptReferences.bipedIK.TRANSFORMSFIXED && this.READYFORTRANSFROM && !this.TRANSFROMDONE)
		{
			this.TRANSFROMDONE = true;
			base.StartCoroutine(this.SampleAnimationsIdleDelay());
		}
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00036BA0 File Offset: 0x00034DA0
	private void FixedUpdate()
	{
		if (this.scriptReferences.characterStates.characterRotationCorrector)
		{
			float t = Mathf.Clamp01(this.scriptReferences.characterStates.Timing.blendTimer / this.scriptReferences.characterStates.Timing.blendDuration);
			Vector3 eulerAngles = this.characterRoot.localRotation.eulerAngles;
			Quaternion b = Quaternion.Euler(new Vector3(0f, eulerAngles.y, 0f));
			this.characterRoot.localRotation = Quaternion.Slerp(this.characterRoot.localRotation, b, t);
		}
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00036C3C File Offset: 0x00034E3C
	private void FindBones()
	{
		Transform[] componentsInChildren = this.characterHips.GetComponentsInChildren<Transform>();
		List<Transform> list = new List<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			string name = transform.name;
			if (name == "Hips" || name == "Spine" || name == "Spine1" || name == "Spine2" || name == "Neck" || name == "Head")
			{
				list.Add(transform);
			}
			else if ((name.StartsWith("Right") || name.StartsWith("Left")) && name != "RightToe_End" && name != "LeftToe_End")
			{
				list.Add(transform);
			}
		}
		this.bones = list.ToArray();
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x00036D24 File Offset: 0x00034F24
	public void SetBonesNull()
	{
		this.initialPositions = null;
		this.initialRotations = null;
		this.targetPositions = null;
		this.targetRotations = null;
		this.scriptReferences.characterStates.Timing.blendTimer = 0f;
		this.scriptReferences.characterStates.TriggerScooterReturn = false;
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00036D78 File Offset: 0x00034F78
	public void RecordPositionsAndRotations(Vector3[] positionsArray, Quaternion[] rotationsArray)
	{
		for (int i = 0; i < this.bones.Length; i++)
		{
			positionsArray[i] = this.bones[i].localPosition;
			rotationsArray[i] = this.bones[i].localRotation;
		}
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00036DC0 File Offset: 0x00034FC0
	public void RecordInitialPositionsAndRotations()
	{
		this.initialPositions = new Vector3[this.bones.Length];
		this.initialRotations = new Quaternion[this.bones.Length];
		this.RecordPositionsAndRotations(this.initialPositions, this.initialRotations);
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00036DFA File Offset: 0x00034FFA
	public void RecordTargetPositionsAndRotations()
	{
		this.targetPositions = new Vector3[this.bones.Length];
		this.targetRotations = new Quaternion[this.bones.Length];
		this.RecordPositionsAndRotations(this.targetPositions, this.targetRotations);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00036E34 File Offset: 0x00035034
	public void RecordTargetPositionsAndRotationsChar()
	{
		this.targetPositionsChar = new Vector3[this.bones.Length];
		this.targetRotationsChar = new Quaternion[this.bones.Length];
		this.RecordPositionsAndRotations(this.targetPositionsChar, this.targetRotationsChar);
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00036E6E File Offset: 0x0003506E
	public void RecordTargetPositionsAndRotationsFall()
	{
		this.targetPositionsFall = new Vector3[this.bones.Length];
		this.targetRotationsFall = new Quaternion[this.bones.Length];
		this.RecordPositionsAndRotations(this.targetPositionsFall, this.targetRotationsFall);
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00036EA8 File Offset: 0x000350A8
	public void RecordTargetPositionsAndRotationsIdle()
	{
		this.reverseInitialPositions = new Vector3[this.bones.Length];
		this.reverseInitialRotations = new Quaternion[this.bones.Length];
		this.RecordPositionsAndRotations(this.reverseInitialPositions, this.reverseInitialRotations);
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x00036EE4 File Offset: 0x000350E4
	public void SampleTargetAnimationChar()
	{
		this.characterAnimator.enabled = true;
		if (this.scriptReferences.characterStates.PlayGetOffAnimation)
		{
			this.characterAnimator.Play("PushOffScooter");
		}
		this.characterAnimator.Update(0f);
		this.RecordTargetPositionsAndRotationsChar();
		this.characterAnimator.enabled = false;
		this.SampleTargetAnimationFall();
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00036F48 File Offset: 0x00035148
	public void SampleTargetAnimationFall()
	{
		this.characterAnimator.enabled = true;
		this.characterAnimator.SetBool("IsGrounded", false);
		this.characterAnimator.Play("Falling2");
		this.characterAnimator.Update(0f);
		this.RecordTargetPositionsAndRotationsFall();
		this.characterAnimator.enabled = false;
		this.characterAnimator.Rebind();
		this.READYFORTRANSFROM = true;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00036FB6 File Offset: 0x000351B6
	public void SampleTargetAnimationIdle()
	{
		this.RecordTargetPositionsAndRotationsIdle();
		this.scriptReferences.characterStates.HardResetToScooter();
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x00036FD0 File Offset: 0x000351D0
	public void AnimateBones(Vector3[] startPositions, Quaternion[] startRotations, Vector3[] endPositions, Quaternion[] endRotations, float blendProgress)
	{
		for (int i = 0; i < this.bones.Length; i++)
		{
			this.bones[i].localPosition = Vector3.Lerp(startPositions[i], endPositions[i], blendProgress);
			this.bones[i].localRotation = Quaternion.Slerp(startRotations[i], endRotations[i], blendProgress);
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x00037038 File Offset: 0x00035238
	public void ResetBonesPositions()
	{
		for (int i = 0; i < this.bones.Length; i++)
		{
			this.bones[i].localPosition = this.reverseInitialPositions[i];
			this.bones[i].localRotation = this.reverseInitialRotations[i];
		}
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x0003708A File Offset: 0x0003528A
	private IEnumerator SampleAnimationsIdleDelay()
	{
		yield return new WaitForSeconds(0.05f);
		this.SampleTargetAnimationIdle();
		yield break;
	}

	// Token: 0x04000CE6 RID: 3302
	public bool READYFORTRANSFROM;

	// Token: 0x04000CE7 RID: 3303
	public bool TRANSFROMDONE;

	// Token: 0x04000CE8 RID: 3304
	public Vector3[] initialPositions;

	// Token: 0x04000CE9 RID: 3305
	public Quaternion[] initialRotations;

	// Token: 0x04000CEA RID: 3306
	public Vector3[] targetPositions;

	// Token: 0x04000CEB RID: 3307
	public Quaternion[] targetRotations;

	// Token: 0x04000CEC RID: 3308
	public Vector3[] targetPositionsChar;

	// Token: 0x04000CED RID: 3309
	public Quaternion[] targetRotationsChar;

	// Token: 0x04000CEE RID: 3310
	public Vector3[] targetPositionsFall;

	// Token: 0x04000CEF RID: 3311
	public Quaternion[] targetRotationsFall;

	// Token: 0x04000CF0 RID: 3312
	public Vector3[] targetPositionsIdle;

	// Token: 0x04000CF1 RID: 3313
	public Quaternion[] targetRotationsIdle;

	// Token: 0x04000CF2 RID: 3314
	public Vector3[] reverseInitialPositions;

	// Token: 0x04000CF3 RID: 3315
	public Quaternion[] reverseInitialRotations;

	// Token: 0x04000CF4 RID: 3316
	[Header("Transforms")]
	public Transform characterHips;

	// Token: 0x04000CF5 RID: 3317
	public Transform characterRoot;

	// Token: 0x04000CF6 RID: 3318
	public Transform[] bones;

	// Token: 0x04000CF7 RID: 3319
	[Header("Animators")]
	public Animator characterAnimator;

	// Token: 0x04000CF8 RID: 3320
	public Animator playerAnimator;

	// Token: 0x04000CF9 RID: 3321
	[Header("Script References")]
	public ScriptReferences scriptReferences;

	// Token: 0x020001D7 RID: 471
	[Serializable]
	public class BoneData
	{
		// Token: 0x04000CFA RID: 3322
		public Vector3[] positions;

		// Token: 0x04000CFB RID: 3323
		public Quaternion[] rotations;
	}
}
