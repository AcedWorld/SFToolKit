using System;
using UnityEngine;

namespace Invector.IK
{
	// Token: 0x020003AB RID: 939
	[Serializable]
	public class vIKSolver
	{
		// Token: 0x060012CC RID: 4812 RVA: 0x0006385E File Offset: 0x00061A5E
		public vIKSolver(Transform rootTransform, Transform rootBone, Transform middleBone, Transform endBone)
		{
			this.rootTransform = rootTransform;
			this.rootBone = rootBone;
			this.middleBone = middleBone;
			this.endBone = endBone;
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x00063884 File Offset: 0x00061A84
		public vIKSolver(Animator animator, AvatarIKGoal ikGoal)
		{
			if (animator == null)
			{
				return;
			}
			this.rootTransform = animator.transform;
			if (animator.isHuman)
			{
				switch (ikGoal)
				{
				case AvatarIKGoal.LeftFoot:
					this.rootBone = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
					this.middleBone = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
					this.endBone = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
					this.endTag = "LeftFoot";
					this.middleTag = "LeftHint";
					break;
				case AvatarIKGoal.RightFoot:
					this.rootBone = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
					this.middleBone = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
					this.endBone = animator.GetBoneTransform(HumanBodyBones.RightFoot);
					this.endTag = "RightFoot";
					this.middleTag = "RightHint";
					break;
				case AvatarIKGoal.LeftHand:
					this.rootBone = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
					this.middleBone = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
					this.endBone = animator.GetBoneTransform(HumanBodyBones.LeftHand);
					this.endTag = "LeftHand";
					this.middleTag = "LeftHint";
					break;
				case AvatarIKGoal.RightHand:
					this.rootBone = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
					this.middleBone = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
					this.endBone = animator.GetBoneTransform(HumanBodyBones.RightHand);
					this.endTag = "RightHand";
					this.middleTag = "RightHint";
					break;
				}
			}
			this.CreateBones();
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060012CE RID: 4814 RVA: 0x000639DC File Offset: 0x00061BDC
		public bool isValidBones
		{
			get
			{
				return this.rootBone && this.middleBone && this.endBone && this.endBoneRef && this.middleBoneRef && this.endBoneOffset && this.middleBoneOffset;
			}
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x00063A44 File Offset: 0x00061C44
		private void CreateBones()
		{
			if (this.rootTransform && this.rootBone && this.middleBone && this.endBone)
			{
				if (!this.endBoneRef)
				{
					this.endBoneRef = new GameObject(this.endTag + "Ref").transform;
					this.endBoneRef.hideFlags = HideFlags.HideInHierarchy;
					this.endBoneRef.SetParent(this.rootTransform);
				}
				if (!this.middleBoneRef)
				{
					this.middleBoneRef = new GameObject(this.middleTag + "Ref").transform;
					this.middleBoneRef.hideFlags = HideFlags.HideInHierarchy;
					this.middleBoneRef.SetParent(this.rootTransform);
				}
				if (!this.endBoneOffset)
				{
					this.endBoneOffset = new GameObject(this.endTag + "Offset").transform;
					this.endBoneOffset.SetParent(this.endBoneRef);
					this.endBoneOffset.localPosition = Vector3.zero;
					this.endBoneOffset.localEulerAngles = Vector3.zero;
				}
				if (!this.middleBoneOffset)
				{
					this.middleBoneOffset = new GameObject(this.middleTag + "Offset").transform;
					this.middleBoneOffset.SetParent(this.middleBoneRef);
					this.middleBoneOffset.localPosition = Vector3.zero;
					this.middleBoneOffset.localEulerAngles = Vector3.zero;
				}
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x060012D0 RID: 4816 RVA: 0x00063BE1 File Offset: 0x00061DE1
		public virtual float ikWeight
		{
			get
			{
				return this._weight;
			}
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x00063BE9 File Offset: 0x00061DE9
		public virtual void SetIKWeight(float weight)
		{
			this._weight = weight;
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x00063BF4 File Offset: 0x00061DF4
		public void UpdateIK()
		{
			if (this.endBoneRef)
			{
				this.endBoneRef.position = this.endBone.position;
				this.endBoneRef.rotation = this.endBone.rotation;
			}
			if (this.middleBoneRef)
			{
				this.middleBoneRef.position = this.middleBone.position;
				this.middleBoneRef.rotation = this.middleBone.rotation;
			}
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x00063C74 File Offset: 0x00061E74
		public virtual void AnimationToIK()
		{
			if (!this.isValidBones)
			{
				this.CreateBones();
				return;
			}
			this.UpdateIK();
			this.SetIKHintPosition(this.middleBoneOffset.position);
			this.SetIKPosition(this.endBoneOffset.position);
			this.SetIKRotation(this.endBoneOffset.rotation);
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x00063CCC File Offset: 0x00061ECC
		public virtual void SetIKPosition(Vector3 ikPosition)
		{
			if (this.ikWeight <= 0f)
			{
				return;
			}
			Vector3 middleBoneDirection = Vector3.zero;
			if (this.hintPosition != null)
			{
				middleBoneDirection = this.hintPosition.Value - this.rootBone.position;
			}
			else
			{
				middleBoneDirection = Vector3.Cross(this.endBone.position - this.rootBone.position, Vector3.Cross(this.endBone.position - this.rootBone.position, this.endBone.position - this.middleBone.position));
			}
			float magnitude = (this.middleBone.position - this.rootBone.position).magnitude;
			float magnitude2 = (this.endBone.position - this.middleBone.position).magnitude;
			Vector3 vector = this.GetHintPosition(this.rootBone.position, ikPosition, magnitude, magnitude2, middleBoneDirection);
			Quaternion quaternion = Quaternion.FromToRotation(this.middleBone.position - this.rootBone.position, vector - this.rootBone.position) * this.rootBone.rotation;
			if (!float.IsNaN(quaternion.x) && !float.IsNaN(quaternion.y) && !float.IsNaN(quaternion.z))
			{
				this.rootBone.rotation = Quaternion.Slerp(this.rootBone.rotation, quaternion, this.ikWeight);
				Quaternion b = Quaternion.FromToRotation(this.endBone.position - this.middleBone.position, ikPosition - vector) * this.middleBone.rotation;
				this.middleBone.rotation = Quaternion.Slerp(this.middleBone.rotation, b, this.ikWeight);
			}
			this.hintPosition = null;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00063ED4 File Offset: 0x000620D4
		public virtual void SetIKRotation(Quaternion rotation)
		{
			if (!this.rootBone || !this.middleBone || !this.endBone || this.ikWeight <= 0f)
			{
				return;
			}
			this.endBone.rotation = Quaternion.Slerp(this.endBone.rotation, rotation, this.ikWeight);
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x00063F3A File Offset: 0x0006213A
		public virtual void SetIKHintPosition(Vector3 hintPosition)
		{
			this.hintPosition = new Vector3?(hintPosition);
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x00063F48 File Offset: 0x00062148
		protected virtual Vector3 GetHintPosition(Vector3 rootPos, Vector3 endPos, float rootBoneLength, float middleBoneLength, Vector3 middleBoneDirection)
		{
			Vector3 vector = endPos - rootPos;
			float num = vector.magnitude;
			float num2 = (rootBoneLength + middleBoneLength) * 0.999f;
			if (num > num2)
			{
				endPos = rootPos + vector.normalized * num2;
				vector = endPos - rootPos;
				num = num2;
			}
			float num3 = Mathf.Abs(rootBoneLength - middleBoneLength) * 1.001f;
			if (num < num3)
			{
				endPos = rootPos + vector.normalized * num3;
				vector = endPos - rootPos;
				num = num3;
			}
			float num4 = (num * num + rootBoneLength * rootBoneLength - middleBoneLength * middleBoneLength) * 0.5f / num;
			float d = Mathf.Sqrt(rootBoneLength * rootBoneLength - num4 * num4);
			Vector3 vector2 = Vector3.Cross(vector, Vector3.Cross(middleBoneDirection, vector));
			return rootPos + num4 * vector.normalized + d * vector2.normalized;
		}

		// Token: 0x040018A5 RID: 6309
		public Transform rootTransform;

		// Token: 0x040018A6 RID: 6310
		public Transform rootBone;

		// Token: 0x040018A7 RID: 6311
		public Transform middleBone;

		// Token: 0x040018A8 RID: 6312
		public Transform endBone;

		// Token: 0x040018A9 RID: 6313
		[Header("Optional")]
		public Transform endBoneRef;

		// Token: 0x040018AA RID: 6314
		public Transform middleBoneRef;

		// Token: 0x040018AB RID: 6315
		public Transform endBoneOffset;

		// Token: 0x040018AC RID: 6316
		public Transform middleBoneOffset;

		// Token: 0x040018AD RID: 6317
		private string middleTag;

		// Token: 0x040018AE RID: 6318
		private string endTag;

		// Token: 0x040018AF RID: 6319
		private float _weight;

		// Token: 0x040018B0 RID: 6320
		private Vector3? hintPosition;
	}
}
