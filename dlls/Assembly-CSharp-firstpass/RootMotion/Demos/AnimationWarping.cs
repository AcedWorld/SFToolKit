using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000153 RID: 339
	public class AnimationWarping : OffsetModifier
	{
		// Token: 0x06000A57 RID: 2647 RVA: 0x00041A71 File Offset: 0x0003FC71
		protected override void Start()
		{
			base.Start();
			this.lastMode = this.effectorMode;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00041A88 File Offset: 0x0003FC88
		public float GetWarpWeight(int warpIndex)
		{
			if (warpIndex < 0)
			{
				Debug.LogError("Warp index out of range.");
				return 0f;
			}
			if (warpIndex >= this.warps.Length)
			{
				Debug.LogError("Warp index out of range.");
				return 0f;
			}
			if (this.animator == null)
			{
				Debug.LogError("Animator unassigned in AnimationWarping");
				return 0f;
			}
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(this.warps[warpIndex].animationLayer);
			if (!currentAnimatorStateInfo.IsName(this.warps[warpIndex].animationState))
			{
				return 0f;
			}
			return this.warps[warpIndex].weightCurve.Evaluate(currentAnimatorStateInfo.normalizedTime - (float)((int)currentAnimatorStateInfo.normalizedTime));
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00041B48 File Offset: 0x0003FD48
		protected override void OnModifyOffset()
		{
			for (int i = 0; i < this.warps.Length; i++)
			{
				float warpWeight = this.GetWarpWeight(i);
				Vector3 vector = this.warps[i].warpTo.position - this.warps[i].warpFrom.position;
				AnimationWarping.EffectorMode effectorMode = this.effectorMode;
				if (effectorMode != AnimationWarping.EffectorMode.PositionOffset)
				{
					if (effectorMode == AnimationWarping.EffectorMode.Position)
					{
						this.ik.solver.GetEffector(this.warps[i].effector).position = this.ik.solver.GetEffector(this.warps[i].effector).bone.position + vector;
						this.ik.solver.GetEffector(this.warps[i].effector).positionWeight = this.weight * warpWeight;
					}
				}
				else
				{
					this.ik.solver.GetEffector(this.warps[i].effector).positionOffset += vector * warpWeight * this.weight;
				}
			}
			if (this.lastMode == AnimationWarping.EffectorMode.Position && this.effectorMode == AnimationWarping.EffectorMode.PositionOffset)
			{
				foreach (AnimationWarping.Warp warp in this.warps)
				{
					this.ik.solver.GetEffector(warp.effector).positionWeight = 0f;
				}
			}
			this.lastMode = this.effectorMode;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00041CEC File Offset: 0x0003FEEC
		private void OnDisable()
		{
			if (this.effectorMode != AnimationWarping.EffectorMode.Position)
			{
				return;
			}
			foreach (AnimationWarping.Warp warp in this.warps)
			{
				this.ik.solver.GetEffector(warp.effector).positionWeight = 0f;
			}
		}

		// Token: 0x040009E4 RID: 2532
		[Tooltip("Reference to the Animator component to use")]
		public Animator animator;

		// Token: 0x040009E5 RID: 2533
		[Tooltip("Using effector.positionOffset or effector.position with effector.positionWeight? The former will enable you to use effector.position for other things, the latter will weigh in the effectors, hence using Reach and Pull in the process.")]
		public AnimationWarping.EffectorMode effectorMode;

		// Token: 0x040009E6 RID: 2534
		[Space(10f)]
		[Tooltip("The array of warps, can have multiple simultaneous warps.")]
		public AnimationWarping.Warp[] warps;

		// Token: 0x040009E7 RID: 2535
		private AnimationWarping.EffectorMode lastMode;

		// Token: 0x02000154 RID: 340
		[Serializable]
		public struct Warp
		{
			// Token: 0x040009E8 RID: 2536
			[Tooltip("Layer of the 'Animation State' in the Animator.")]
			public int animationLayer;

			// Token: 0x040009E9 RID: 2537
			[Tooltip("Name of the state in the Animator to warp.")]
			public string animationState;

			// Token: 0x040009EA RID: 2538
			[Tooltip("Warping weight by normalized time of the animation state.")]
			public AnimationCurve weightCurve;

			// Token: 0x040009EB RID: 2539
			[Tooltip("Animated point to warp from. This should be in character space so keep this Transform parented to the root of the character.")]
			public Transform warpFrom;

			// Token: 0x040009EC RID: 2540
			[Tooltip("World space point to warp to.")]
			public Transform warpTo;

			// Token: 0x040009ED RID: 2541
			[Tooltip("Which FBBIK effector to use?")]
			public FullBodyBipedEffector effector;
		}

		// Token: 0x02000155 RID: 341
		[Serializable]
		public enum EffectorMode
		{
			// Token: 0x040009EF RID: 2543
			PositionOffset,
			// Token: 0x040009F0 RID: 2544
			Position
		}
	}
}
