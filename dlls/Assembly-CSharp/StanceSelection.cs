using System;
using UnityEngine;

// Token: 0x020001CB RID: 459
public class StanceSelection : MonoBehaviour
{
	// Token: 0x06000729 RID: 1833 RVA: 0x0003629A File Offset: 0x0003449A
	private void Start()
	{
		if (this.isRegular)
		{
			this.FlipBones();
		}
		else
		{
			this.characterStates.enabled = true;
		}
		this.animatorToSwitch.runtimeAnimatorController = (this.isRegular ? this.regularController : this.goofyController);
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x000362DC File Offset: 0x000344DC
	public void FlipBones()
	{
		if (this.hips == null)
		{
			Debug.LogError("Hips transform is not assigned!");
			return;
		}
		if (this.leftBones.Length != this.rightBones.Length)
		{
			Debug.LogError("Left and Right bone arrays must have the same length!");
			return;
		}
		for (int i = 0; i < this.leftBones.Length; i++)
		{
			Transform transform = this.leftBones[i];
			Transform transform2 = this.rightBones[i];
			if (!(transform == null) && !(transform2 == null))
			{
				Vector3 localPosition = transform.localPosition;
				transform.localPosition = new Vector3(-transform2.localPosition.x, transform2.localPosition.y, transform2.localPosition.z);
				transform2.localPosition = new Vector3(-localPosition.x, localPosition.y, localPosition.z);
				Quaternion localRotation = transform.localRotation;
				transform.localRotation = new Quaternion(transform2.localRotation.x, -transform2.localRotation.y, -transform2.localRotation.z, transform2.localRotation.w);
				transform2.localRotation = new Quaternion(localRotation.x, -localRotation.y, -localRotation.z, localRotation.w);
			}
		}
		foreach (Transform transform3 in this.centralBones)
		{
			if (!(transform3 == null))
			{
				transform3.localPosition = new Vector3(-transform3.localPosition.x, transform3.localPosition.y, transform3.localPosition.z);
				transform3.localRotation = new Quaternion(transform3.localRotation.x, -transform3.localRotation.y, -transform3.localRotation.z, transform3.localRotation.w);
			}
		}
		this.isFlipped = !this.isFlipped;
		Debug.Log("Bone mirroring and flipping applied correctly in Editor.");
		if (this.isFlipped)
		{
			this.characterStates.enabled = true;
		}
	}

	// Token: 0x04000CBE RID: 3262
	[SerializeField]
	private Animator animatorToSwitch;

	// Token: 0x04000CBF RID: 3263
	[SerializeField]
	private RuntimeAnimatorController goofyController;

	// Token: 0x04000CC0 RID: 3264
	[SerializeField]
	private RuntimeAnimatorController regularController;

	// Token: 0x04000CC1 RID: 3265
	public Transform hips;

	// Token: 0x04000CC2 RID: 3266
	public bool isFlipped;

	// Token: 0x04000CC3 RID: 3267
	public Transform[] leftBones;

	// Token: 0x04000CC4 RID: 3268
	public Transform[] rightBones;

	// Token: 0x04000CC5 RID: 3269
	public Transform[] centralBones;

	// Token: 0x04000CC6 RID: 3270
	public bool isRegular;

	// Token: 0x04000CC7 RID: 3271
	public CharacterStates characterStates;
}
