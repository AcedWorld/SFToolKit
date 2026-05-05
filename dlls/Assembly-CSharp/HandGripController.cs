using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014E RID: 334
public class HandGripController : MonoBehaviour
{
	// Token: 0x06000553 RID: 1363 RVA: 0x0002493C File Offset: 0x00022B3C
	private void Start()
	{
		this.FindFingers(this.leftHand, this.leftFingers, this.leftThumbs);
		this.FindFingers(this.rightHand, this.rightFingers, this.rightThumbs);
		foreach (Transform transform in this.leftFingers)
		{
			this.defaultRotations[transform] = transform.localRotation;
		}
		foreach (Transform transform2 in this.rightFingers)
		{
			this.defaultRotations[transform2] = transform2.localRotation;
		}
		foreach (Transform transform3 in this.leftThumbs)
		{
			this.defaultRotations[transform3] = transform3.localRotation;
		}
		foreach (Transform transform4 in this.rightThumbs)
		{
			this.defaultRotations[transform4] = transform4.localRotation;
		}
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x00024AB4 File Offset: 0x00022CB4
	private void Update()
	{
		float gripStrength = this.GetGripStrength(this.leftTarget);
		float gripStrength2 = this.GetGripStrength(this.rightTarget);
		this.ApplyGrip(this.leftFingers, this.leftThumbs, gripStrength, true);
		this.ApplyGrip(this.rightFingers, this.rightThumbs, gripStrength2, false);
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x00024B03 File Offset: 0x00022D03
	private float GetGripStrength(Transform target)
	{
		if (target == null)
		{
			return 0f;
		}
		return Mathf.Clamp01(Mathf.InverseLerp(this.minGripPos, this.maxGripPos, target.localPosition.y));
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00024B38 File Offset: 0x00022D38
	private void FindFingers(Transform hand, List<Transform> fingerList, List<Transform> thumbList)
	{
		if (hand == null)
		{
			return;
		}
		foreach (object obj in hand)
		{
			Transform transform = (Transform)obj;
			if (transform.name.Contains("Thumb"))
			{
				this.CollectFingerJoints(transform, thumbList);
			}
			else if (transform.name.Contains("Index") || transform.name.Contains("Middle") || transform.name.Contains("Ring") || transform.name.Contains("Pinky"))
			{
				this.CollectFingerJoints(transform, fingerList);
			}
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x00024BFC File Offset: 0x00022DFC
	private void CollectFingerJoints(Transform finger, List<Transform> list)
	{
		list.Add(finger);
		foreach (object obj in finger)
		{
			Transform transform = (Transform)obj;
			list.Add(transform);
			if (transform.childCount > 0)
			{
				this.CollectFingerJoints(transform, list);
			}
		}
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00024C68 File Offset: 0x00022E68
	private void ApplyGrip(List<Transform> fingers, List<Transform> thumbs, float gripStrength, bool invertThumb)
	{
		foreach (Transform transform in fingers)
		{
			Quaternion a;
			if (this.defaultRotations.TryGetValue(transform, out a))
			{
				Quaternion b = Quaternion.Euler(a.eulerAngles.x - 60f, a.eulerAngles.y, a.eulerAngles.z);
				transform.localRotation = Quaternion.Lerp(a, b, gripStrength);
			}
		}
		foreach (Transform transform2 in thumbs)
		{
			Quaternion a2;
			if (this.defaultRotations.TryGetValue(transform2, out a2))
			{
				Quaternion b2 = Quaternion.Euler(a2.eulerAngles.x, a2.eulerAngles.y, a2.eulerAngles.z + (invertThumb ? -15f : 15f));
				transform2.localRotation = Quaternion.Lerp(a2, b2, gripStrength);
			}
		}
	}

	// Token: 0x04000868 RID: 2152
	public Transform leftHand;

	// Token: 0x04000869 RID: 2153
	public Transform rightHand;

	// Token: 0x0400086A RID: 2154
	public Transform leftTarget;

	// Token: 0x0400086B RID: 2155
	public Transform rightTarget;

	// Token: 0x0400086C RID: 2156
	public float minGripPos = -0.1f;

	// Token: 0x0400086D RID: 2157
	public float maxGripPos = 0.1f;

	// Token: 0x0400086E RID: 2158
	private List<Transform> leftFingers = new List<Transform>();

	// Token: 0x0400086F RID: 2159
	private List<Transform> rightFingers = new List<Transform>();

	// Token: 0x04000870 RID: 2160
	private List<Transform> leftThumbs = new List<Transform>();

	// Token: 0x04000871 RID: 2161
	private List<Transform> rightThumbs = new List<Transform>();

	// Token: 0x04000872 RID: 2162
	private Dictionary<Transform, Quaternion> defaultRotations = new Dictionary<Transform, Quaternion>();
}
