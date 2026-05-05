using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000107 RID: 263
	public class UniversalPoser : Poser
	{
		// Token: 0x060008D9 RID: 2265 RVA: 0x0000223E File Offset: 0x0000043E
		public override void AutoMapping()
		{
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00038FC8 File Offset: 0x000371C8
		public override void AutoMapping(Transform[] bones)
		{
			if (bones.Length != this.bones.Length)
			{
				Debug.LogError("Trying to use UniversalPoser with an InteractionTarget that has a different number of bones. Bones must match with UniversalPoser bones in both array size and hierarchy", base.transform);
				return;
			}
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].target = bones[i];
			}
			this.StoreDefaultState();
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0003901C File Offset: 0x0003721C
		protected override void InitiatePoser()
		{
			this.StoreDefaultState();
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00039024 File Offset: 0x00037224
		protected override void UpdatePoser()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.localPositionWeight <= 0f && this.localRotationWeight <= 0f)
			{
				return;
			}
			if (this.poseRoot == null)
			{
				return;
			}
			float localRotationWeight = this.localRotationWeight * this.weight;
			float localPositionWeight = this.localPositionWeight * this.weight;
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].Update(localRotationWeight, localPositionWeight, this.targetAxis1, this.targetAxis2, this.axis1, this.axis2);
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x000390C0 File Offset: 0x000372C0
		protected override void FixPoserTransforms()
		{
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].FixTransform();
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000390F0 File Offset: 0x000372F0
		private void StoreDefaultState()
		{
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].StoreDefaultState();
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00039120 File Offset: 0x00037320
		private Transform GetTargetNamed(string tName, Transform[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].name == tName)
				{
					return array[i];
				}
			}
			return null;
		}

		// Token: 0x0400081E RID: 2078
		[Tooltip("Choose 2 axes of a finger bone. For example 1 pointing towards the next finger and 2 pointing up. Select a finger bone in the InteractionTarget hierarchy and see which local axis points towards the next bone and which local axis points up and set targetAxis1 and targetAxis2 accordingly. Then select a finger in this poser's hierarchy and do the same for axis1 and axis2.")]
		public Vector3 targetAxis1;

		// Token: 0x0400081F RID: 2079
		[Tooltip("Choose 2 axes of a finger bone. For example 1 pointing towards the next finger and 2 pointing up. Select a finger bone in the InteractionTarget hierarchy and see which local axis points towards the next bone and which local axis points up and set targetAxis1 and targetAxis2 accordingly. Then select a finger in this poser's hierarchy and do the same for axis1 and axis2.")]
		public Vector3 targetAxis2;

		// Token: 0x04000820 RID: 2080
		[Tooltip("Choose 2 axes of a finger bone. For example 1 pointing towards the next finger and 2 pointing up. Select a finger bone in the InteractionTarget hierarchy and see which local axis points towards the next bone and which local axis points up and set targetAxis1 and targetAxis2 accordingly. Then select a finger in this poser's hierarchy and do the same for axis1 and axis2.")]
		public Vector3 axis1;

		// Token: 0x04000821 RID: 2081
		[Tooltip("Choose 2 axes of a finger bone. For example 1 pointing towards the next finger and 2 pointing up. Select a finger bone in the InteractionTarget hierarchy and see which local axis points towards the next bone and which local axis points up and set targetAxis1 and targetAxis2 accordingly. Then select a finger in this poser's hierarchy and do the same for axis1 and axis2.")]
		public Vector3 axis2;

		// Token: 0x04000822 RID: 2082
		[Tooltip("List of bones must match InteractionTarget's list of bones in both array size and hierarchy.")]
		public UniversalPoser.Map[] bones;

		// Token: 0x02000108 RID: 264
		[Serializable]
		public class Map
		{
			// Token: 0x060008E1 RID: 2273 RVA: 0x00039150 File Offset: 0x00037350
			public Map(Transform bone, Transform target)
			{
				this.bone = bone;
				this.target = target;
				this.StoreDefaultState();
			}

			// Token: 0x060008E2 RID: 2274 RVA: 0x0003916C File Offset: 0x0003736C
			public void StoreDefaultState()
			{
				this.defaultLocalPosition = this.bone.localPosition;
				this.defaultLocalRotation = this.bone.localRotation;
			}

			// Token: 0x060008E3 RID: 2275 RVA: 0x00039190 File Offset: 0x00037390
			public void FixTransform()
			{
				this.bone.localPosition = this.defaultLocalPosition;
				this.bone.localRotation = this.defaultLocalRotation;
			}

			// Token: 0x060008E4 RID: 2276 RVA: 0x000391B4 File Offset: 0x000373B4
			public void Update(float localRotationWeight, float localPositionWeight, Vector3 targetAxis1, Vector3 targetAxis2, Vector3 axis1, Vector3 axis2)
			{
				if (targetAxis1 == axis1 && targetAxis2 == axis2)
				{
					this.bone.localRotation = Quaternion.Lerp(this.bone.localRotation, this.target.localRotation, localRotationWeight);
					return;
				}
				Quaternion rhs = Quaternion.Lerp(this.bone.localRotation, QuaTools.MatchRotation(this.target.localRotation, targetAxis1, targetAxis2, axis1, axis2), localRotationWeight);
				Quaternion lhs = QuaTools.MatchRotation(Quaternion.identity, targetAxis1, targetAxis2, axis1, axis2);
				this.bone.localRotation = lhs * rhs;
			}

			// Token: 0x04000823 RID: 2083
			public Transform bone;

			// Token: 0x04000824 RID: 2084
			[HideInInspector]
			public Transform target;

			// Token: 0x04000825 RID: 2085
			private Vector3 defaultLocalPosition;

			// Token: 0x04000826 RID: 2086
			private Quaternion defaultLocalRotation;
		}
	}
}
