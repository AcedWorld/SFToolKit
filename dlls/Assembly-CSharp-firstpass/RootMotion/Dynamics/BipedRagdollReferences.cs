using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000087 RID: 135
	[Serializable]
	public struct BipedRagdollReferences
	{
		// Token: 0x06000446 RID: 1094 RVA: 0x0001A5A4 File Offset: 0x000187A4
		public bool IsValid(ref string msg)
		{
			if (this.root == null || this.hips == null || this.head == null || this.leftUpperArm == null || this.leftLowerArm == null || this.leftHand == null || this.rightUpperArm == null || this.rightLowerArm == null || this.rightHand == null || this.leftUpperLeg == null || this.leftLowerLeg == null || this.leftFoot == null || this.rightUpperLeg == null || this.rightLowerLeg == null || this.rightFoot == null)
			{
				msg = "Invalid References, one or more Transforms missing.";
				return false;
			}
			Transform[] array = new Transform[]
			{
				this.root,
				this.hips,
				this.head,
				this.leftUpperArm,
				this.leftLowerArm,
				this.leftHand,
				this.rightUpperArm,
				this.rightLowerArm,
				this.rightHand,
				this.leftUpperLeg,
				this.leftLowerLeg,
				this.leftFoot,
				this.rightUpperLeg,
				this.rightLowerLeg,
				this.rightFoot
			};
			for (int i = 1; i < array.Length; i++)
			{
				if (!this.IsChildRecursive(array[i], this.root))
				{
					msg = "Invalid References, " + array[i].name + " is not in the Root's hierarchy.";
					return false;
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				for (int k = 0; k < array.Length; k++)
				{
					if (j != k && array[j] == array[k])
					{
						msg = "Invalid References, " + array[j].name + " is represented more than once.";
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0001A7B3 File Offset: 0x000189B3
		private bool IsChildRecursive(Transform t, Transform parent)
		{
			return t.parent == parent || (t.parent != null && this.IsChildRecursive(t.parent, parent));
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0001A7E4 File Offset: 0x000189E4
		public bool IsEmpty(bool considerRoot)
		{
			return (!considerRoot || !(this.root != null)) && !(this.hips != null) && !(this.head != null) && !(this.spine != null) && !(this.chest != null) && !(this.leftUpperArm != null) && !(this.leftLowerArm != null) && !(this.leftHand != null) && !(this.rightUpperArm != null) && !(this.rightLowerArm != null) && !(this.rightHand != null) && !(this.leftUpperLeg != null) && !(this.leftLowerLeg != null) && !(this.leftFoot != null) && !(this.rightUpperLeg != null) && !(this.rightLowerLeg != null) && !(this.rightFoot != null);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0001A8FC File Offset: 0x00018AFC
		public bool Contains(Transform t, bool ignoreRoot = false)
		{
			return (!ignoreRoot && this.root == t) || this.hips == t || this.spine == t || this.chest == t || this.leftUpperLeg == t || this.leftLowerLeg == t || this.leftFoot == t || this.rightUpperLeg == t || this.rightLowerLeg == t || this.rightFoot == t || this.leftUpperArm == t || this.leftLowerArm == t || this.leftHand == t || this.rightUpperArm == t || this.rightLowerArm == t || this.rightHand == t || this.head == t;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001AA20 File Offset: 0x00018C20
		public Transform[] GetRagdollTransforms()
		{
			return new Transform[]
			{
				this.hips,
				this.spine,
				this.chest,
				this.head,
				this.leftUpperArm,
				this.leftLowerArm,
				this.leftHand,
				this.rightUpperArm,
				this.rightLowerArm,
				this.rightHand,
				this.leftUpperLeg,
				this.leftLowerLeg,
				this.leftFoot,
				this.rightUpperLeg,
				this.rightLowerLeg,
				this.rightFoot
			};
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0001AACC File Offset: 0x00018CCC
		public static BipedRagdollReferences FromAvatar(Animator animator)
		{
			BipedRagdollReferences result = default(BipedRagdollReferences);
			if (!animator.isHuman)
			{
				return result;
			}
			result.root = animator.transform;
			result.hips = animator.GetBoneTransform(HumanBodyBones.Hips);
			result.spine = animator.GetBoneTransform(HumanBodyBones.Spine);
			result.chest = animator.GetBoneTransform(HumanBodyBones.Chest);
			result.head = animator.GetBoneTransform(HumanBodyBones.Head);
			result.leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			result.leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
			result.leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
			result.rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
			result.rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
			result.rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
			result.leftUpperLeg = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
			result.leftLowerLeg = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
			result.leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
			result.rightUpperLeg = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
			result.rightLowerLeg = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
			result.rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
			return result;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001ABE0 File Offset: 0x00018DE0
		public static BipedRagdollReferences FromBipedReferences(BipedReferences biped)
		{
			BipedRagdollReferences result = default(BipedRagdollReferences);
			result.root = biped.root;
			result.hips = biped.pelvis;
			if (biped.spine != null && biped.spine.Length != 0)
			{
				result.spine = biped.spine[0];
				if (biped.spine.Length > 1)
				{
					result.chest = biped.spine[biped.spine.Length - 1];
				}
			}
			result.head = biped.head;
			result.leftUpperArm = biped.leftUpperArm;
			result.leftLowerArm = biped.leftForearm;
			result.leftHand = biped.leftHand;
			result.rightUpperArm = biped.rightUpperArm;
			result.rightLowerArm = biped.rightForearm;
			result.rightHand = biped.rightHand;
			result.leftUpperLeg = biped.leftThigh;
			result.leftLowerLeg = biped.leftCalf;
			result.leftFoot = biped.leftFoot;
			result.rightUpperLeg = biped.rightThigh;
			result.rightLowerLeg = biped.rightCalf;
			result.rightFoot = biped.rightFoot;
			return result;
		}

		// Token: 0x040003CE RID: 974
		public Transform root;

		// Token: 0x040003CF RID: 975
		public Transform hips;

		// Token: 0x040003D0 RID: 976
		public Transform spine;

		// Token: 0x040003D1 RID: 977
		public Transform chest;

		// Token: 0x040003D2 RID: 978
		public Transform head;

		// Token: 0x040003D3 RID: 979
		public Transform leftUpperLeg;

		// Token: 0x040003D4 RID: 980
		public Transform leftLowerLeg;

		// Token: 0x040003D5 RID: 981
		public Transform leftFoot;

		// Token: 0x040003D6 RID: 982
		public Transform rightUpperLeg;

		// Token: 0x040003D7 RID: 983
		public Transform rightLowerLeg;

		// Token: 0x040003D8 RID: 984
		public Transform rightFoot;

		// Token: 0x040003D9 RID: 985
		public Transform leftUpperArm;

		// Token: 0x040003DA RID: 986
		public Transform leftLowerArm;

		// Token: 0x040003DB RID: 987
		public Transform leftHand;

		// Token: 0x040003DC RID: 988
		public Transform rightUpperArm;

		// Token: 0x040003DD RID: 989
		public Transform rightLowerArm;

		// Token: 0x040003DE RID: 990
		public Transform rightHand;
	}
}
