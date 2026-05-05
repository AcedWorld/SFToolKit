using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000EE RID: 238
	[Serializable]
	public class TwistSolver
	{
		// Token: 0x0600080F RID: 2063 RVA: 0x00034BD0 File Offset: 0x00032DD0
		public TwistSolver()
		{
			this.weight = 1f;
			this.parentChildCrossfade = 0.5f;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00034C3C File Offset: 0x00032E3C
		public TwistSolver(Transform t)
		{
			this.transform = t;
			this.weight = 1f;
			this.parentChildCrossfade = 0.5f;
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00034CB0 File Offset: 0x00032EB0
		public void Initiate()
		{
			if (this.inititated)
			{
				return;
			}
			if (this.transform == null)
			{
				Debug.LogError("TwistRelaxer solver has unassigned Transform. TwistRelaxer.cs was restructured for FIK v2.0 to support multiple relaxers on the same body part and TwistRelaxer components need to be set up again, sorry for the inconvenience!", this.transform);
				return;
			}
			if (this.parent == null)
			{
				this.parent = this.transform.parent;
			}
			if (this.children.Length == 0)
			{
				if (this.transform.childCount == 0)
				{
					Transform[] componentsInChildren = this.parent.GetComponentsInChildren<Transform>();
					for (int i = 1; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i] != this.transform)
						{
							Transform[] array = new Transform[]
							{
								componentsInChildren[i]
							};
							break;
						}
					}
				}
				else
				{
					this.children = new Transform[]
					{
						this.transform.GetChild(0)
					};
				}
			}
			if (this.children.Length == 0 || this.children[0] == null)
			{
				Debug.LogError("TwistRelaxer has no children assigned.", this.transform);
				return;
			}
			this.twistAxis = this.transform.InverseTransformDirection(this.children[0].position - this.transform.position);
			this.axis = new Vector3(this.twistAxis.y, this.twistAxis.z, this.twistAxis.x);
			Vector3 point = this.transform.rotation * this.axis;
			this.axisRelativeToParentDefault = Quaternion.Inverse(this.parent.rotation) * point;
			this.axisRelativeToChildDefault = Quaternion.Inverse(this.children[0].rotation) * point;
			this.childRotations = new Quaternion[this.children.Length];
			this.defaultLocalRotation = this.transform.localRotation;
			this.defaultChildLocalRotations = new Quaternion[this.children.Length];
			for (int j = 0; j < this.children.Length; j++)
			{
				this.defaultChildLocalRotations[j] = this.children[j].localRotation;
			}
			this.inititated = true;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00034EB0 File Offset: 0x000330B0
		public void FixTransforms()
		{
			this.transform.localRotation = this.defaultLocalRotation;
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].localRotation = this.defaultChildLocalRotations[i];
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00034EFC File Offset: 0x000330FC
		public void Relax()
		{
			if (!this.inititated)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			Quaternion quaternion = this.transform.rotation;
			Quaternion lhs = Quaternion.AngleAxis(this.twistAngleOffset, quaternion * this.twistAxis);
			quaternion = lhs * quaternion;
			Vector3 vector = lhs * this.parent.rotation * this.axisRelativeToParentDefault;
			vector = Quaternion.FromToRotation(this.transform.position - this.parent.position, this.children[0].position - this.transform.position) * vector;
			Vector3 b = lhs * this.children[0].rotation * this.axisRelativeToChildDefault;
			Vector3 vector2 = Vector3.Slerp(vector, b, this.parentChildCrossfade);
			vector2 = Quaternion.Inverse(Quaternion.LookRotation(quaternion * this.axis, quaternion * this.twistAxis)) * vector2;
			float num = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
			for (int i = 0; i < this.children.Length; i++)
			{
				this.childRotations[i] = this.children[i].rotation;
			}
			this.transform.rotation = Quaternion.AngleAxis(num * this.weight, quaternion * this.twistAxis) * quaternion;
			for (int j = 0; j < this.children.Length; j++)
			{
				this.children[j].rotation = this.childRotations[j];
			}
		}

		// Token: 0x04000768 RID: 1896
		[Tooltip("The transform that this solver operates on.")]
		public Transform transform;

		// Token: 0x04000769 RID: 1897
		[Tooltip("If this is the forearm roll bone, the parent should be the forearm bone. If null, will be found automatically.")]
		public Transform parent;

		// Token: 0x0400076A RID: 1898
		[Tooltip("If this is the forearm roll bone, the child should be the hand bone. If null, will attempt to find automatically. Assign the hand manually if the hand bone is not a child of the roll bone.")]
		public Transform[] children = new Transform[0];

		// Token: 0x0400076B RID: 1899
		[Tooltip("The weight of relaxing the twist of this Transform")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400076C RID: 1900
		[Tooltip("If 0.5, this Transform will be twisted half way from parent to child. If 1, the twist angle will be locked to the child and will rotate with along with it.")]
		[Range(0f, 1f)]
		public float parentChildCrossfade = 0.5f;

		// Token: 0x0400076D RID: 1901
		[Tooltip("Rotation offset around the twist axis.")]
		[Range(-180f, 180f)]
		public float twistAngleOffset;

		// Token: 0x0400076E RID: 1902
		private Vector3 twistAxis = Vector3.right;

		// Token: 0x0400076F RID: 1903
		private Vector3 axis = Vector3.forward;

		// Token: 0x04000770 RID: 1904
		private Vector3 axisRelativeToParentDefault;

		// Token: 0x04000771 RID: 1905
		private Vector3 axisRelativeToChildDefault;

		// Token: 0x04000772 RID: 1906
		private Quaternion[] childRotations;

		// Token: 0x04000773 RID: 1907
		private bool inititated;

		// Token: 0x04000774 RID: 1908
		private Quaternion defaultLocalRotation = Quaternion.identity;

		// Token: 0x04000775 RID: 1909
		private Quaternion[] defaultChildLocalRotations;
	}
}
