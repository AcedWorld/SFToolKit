using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000071 RID: 113
	[CreateAssetMenu(fileName = "PuppetMaster Humanoid Config", menuName = "PuppetMaster/Humanoid Config", order = 1)]
	public class PuppetMasterHumanoidConfig : ScriptableObject
	{
		// Token: 0x060003A6 RID: 934 RVA: 0x00016360 File Offset: 0x00014560
		public void ApplyTo(PuppetMaster p)
		{
			if (p.targetRoot == null)
			{
				Debug.LogWarning("Please assign 'Target Root' for PuppetMaster using a Humanoid Config.", p.transform);
				return;
			}
			if (p.targetAnimator == null)
			{
				Debug.LogError("PuppetMaster 'Target Root' does not have an Animator component. Can not use Humanoid Config.", p.transform);
				return;
			}
			if (!p.targetAnimator.isHuman)
			{
				Debug.LogError("PuppetMaster target is not a Humanoid. Can not use Humanoid Config.", p.transform);
				return;
			}
			p.state = this.state;
			p.stateSettings = this.stateSettings;
			p.mode = this.mode;
			p.blendTime = this.blendTime;
			p.fixTargetTransforms = this.fixTargetTransforms;
			p.solverIterationCount = this.solverIterationCount;
			p.visualizeTargetPose = this.visualizeTargetPose;
			p.mappingWeight = this.mappingWeight;
			p.pinWeight = this.pinWeight;
			p.muscleWeight = this.muscleWeight;
			p.muscleSpring = this.muscleSpring;
			p.muscleDamper = this.muscleDamper;
			p.pinPow = this.pinPow;
			p.pinDistanceFalloff = this.pinDistanceFalloff;
			p.angularPinning = this.angularPinning;
			p.updateJointAnchors = this.updateJointAnchors;
			p.supportTranslationAnimation = this.supportTranslationAnimation;
			p.angularLimits = this.angularLimits;
			p.internalCollisions = this.internalCollisions;
			for (int i = 0; i < this.muscles.Length; i++)
			{
				Muscle muscle = this.GetMuscle(this.muscles[i].bone, p.targetAnimator, p);
				if (muscle == null && i < p.muscles.Length)
				{
					muscle = p.muscles[i];
				}
				if (muscle != null)
				{
					PuppetMasterHumanoidConfig.HumanoidMuscle humanoidMuscle = this.muscles[i];
					muscle.props.group = humanoidMuscle.props.group;
					muscle.props.mappingWeight = humanoidMuscle.props.mappingWeight;
					muscle.props.muscleDamper = humanoidMuscle.props.muscleDamper;
					muscle.props.muscleWeight = humanoidMuscle.props.muscleWeight;
					muscle.props.pinWeight = humanoidMuscle.props.pinWeight;
				}
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00016574 File Offset: 0x00014774
		private Muscle GetMuscle(HumanBodyBones boneId, Animator animator, PuppetMaster puppetMaster)
		{
			if (boneId == HumanBodyBones.LastBone)
			{
				return null;
			}
			Transform boneTransform = animator.GetBoneTransform(boneId);
			if (boneTransform == null)
			{
				return null;
			}
			foreach (Muscle muscle in puppetMaster.muscles)
			{
				if (muscle.target == boneTransform)
				{
					return muscle;
				}
			}
			return null;
		}

		// Token: 0x04000323 RID: 803
		[LargeHeader("Simulation")]
		public PuppetMaster.State state;

		// Token: 0x04000324 RID: 804
		public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;

		// Token: 0x04000325 RID: 805
		public PuppetMaster.Mode mode;

		// Token: 0x04000326 RID: 806
		public float blendTime = 0.1f;

		// Token: 0x04000327 RID: 807
		public bool fixTargetTransforms = true;

		// Token: 0x04000328 RID: 808
		public int solverIterationCount = 6;

		// Token: 0x04000329 RID: 809
		public bool visualizeTargetPose = true;

		// Token: 0x0400032A RID: 810
		[LargeHeader("Master Weights")]
		[Range(0f, 1f)]
		public float mappingWeight = 1f;

		// Token: 0x0400032B RID: 811
		[Range(0f, 1f)]
		public float pinWeight = 1f;

		// Token: 0x0400032C RID: 812
		[Range(0f, 1f)]
		public float muscleWeight = 1f;

		// Token: 0x0400032D RID: 813
		[LargeHeader("Joint and Muscle Settings")]
		public float muscleSpring = 100f;

		// Token: 0x0400032E RID: 814
		public float muscleDamper;

		// Token: 0x0400032F RID: 815
		[Range(1f, 8f)]
		public float pinPow = 4f;

		// Token: 0x04000330 RID: 816
		[Range(0f, 100f)]
		public float pinDistanceFalloff = 5f;

		// Token: 0x04000331 RID: 817
		public bool angularPinning;

		// Token: 0x04000332 RID: 818
		public bool updateJointAnchors = true;

		// Token: 0x04000333 RID: 819
		public bool supportTranslationAnimation;

		// Token: 0x04000334 RID: 820
		public bool angularLimits;

		// Token: 0x04000335 RID: 821
		public bool internalCollisions;

		// Token: 0x04000336 RID: 822
		[LargeHeader("Individual Muscle Settings")]
		public PuppetMasterHumanoidConfig.HumanoidMuscle[] muscles = new PuppetMasterHumanoidConfig.HumanoidMuscle[0];

		// Token: 0x02000072 RID: 114
		[Serializable]
		public class HumanoidMuscle
		{
			// Token: 0x04000337 RID: 823
			[HideInInspector]
			public string name;

			// Token: 0x04000338 RID: 824
			public HumanBodyBones bone;

			// Token: 0x04000339 RID: 825
			public Muscle.Props props;
		}
	}
}
