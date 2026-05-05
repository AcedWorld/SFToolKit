using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200016A RID: 362
	public class MotionAbsorb : OffsetModifier
	{
		// Token: 0x06000AAA RID: 2730 RVA: 0x0004430B File Offset: 0x0004250B
		protected override void Start()
		{
			base.Start();
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterIK));
			this.initialMode = this.mode;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0004434C File Offset: 0x0004254C
		private void OnCollisionEnter(Collision c)
		{
			if (this.timer > 0f)
			{
				return;
			}
			this.timer = 1f;
			for (int i = 0; i < this.absorbers.Length; i++)
			{
				this.absorbers[i].SetToBone(this.ik.solver, this.mode);
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x000443A4 File Offset: 0x000425A4
		protected override void OnModifyOffset()
		{
			if (this.timer <= 0f)
			{
				return;
			}
			this.mode = this.initialMode;
			this.timer -= Time.deltaTime * this.falloffSpeed;
			this.w = this.falloff.Evaluate(this.timer);
			if (this.mode == MotionAbsorb.Mode.Position)
			{
				for (int i = 0; i < this.absorbers.Length; i++)
				{
					this.absorbers[i].UpdateEffectorWeights(this.w * this.weight);
				}
				return;
			}
			for (int j = 0; j < this.absorbers.Length; j++)
			{
				this.absorbers[j].SetPosition(this.w * this.weight);
			}
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00044460 File Offset: 0x00042660
		private void AfterIK()
		{
			if (this.timer <= 0f)
			{
				return;
			}
			if (this.mode == MotionAbsorb.Mode.Position)
			{
				return;
			}
			for (int i = 0; i < this.absorbers.Length; i++)
			{
				this.absorbers[i].SetRotation(this.w * this.weight);
			}
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x000444B4 File Offset: 0x000426B4
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterIK));
			}
		}

		// Token: 0x04000A74 RID: 2676
		[Tooltip("Use either effector position, position weight, rotation, rotationWeight or positionOffset and rotating the bone directly.")]
		public MotionAbsorb.Mode mode;

		// Token: 0x04000A75 RID: 2677
		[Tooltip("Array containing the absorbers")]
		public MotionAbsorb.Absorber[] absorbers;

		// Token: 0x04000A76 RID: 2678
		[Tooltip("Weight falloff curve (how fast will the effect reduce after impact)")]
		public AnimationCurve falloff;

		// Token: 0x04000A77 RID: 2679
		[Tooltip("How fast will the impact fade away. (if 1, effect lasts for 1 second)")]
		public float falloffSpeed = 1f;

		// Token: 0x04000A78 RID: 2680
		private float timer;

		// Token: 0x04000A79 RID: 2681
		private float w;

		// Token: 0x04000A7A RID: 2682
		private MotionAbsorb.Mode initialMode;

		// Token: 0x0200016B RID: 363
		[Serializable]
		public enum Mode
		{
			// Token: 0x04000A7C RID: 2684
			Position,
			// Token: 0x04000A7D RID: 2685
			PositionOffset
		}

		// Token: 0x0200016C RID: 364
		[Serializable]
		public class Absorber
		{
			// Token: 0x06000AB0 RID: 2736 RVA: 0x00044514 File Offset: 0x00042714
			public void SetToBone(IKSolverFullBodyBiped solver, MotionAbsorb.Mode mode)
			{
				this.e = solver.GetEffector(this.effector);
				if (mode == MotionAbsorb.Mode.Position)
				{
					this.e.position = this.e.bone.position;
					this.e.rotation = this.e.bone.rotation;
					return;
				}
				if (mode != MotionAbsorb.Mode.PositionOffset)
				{
					return;
				}
				this.position = this.e.bone.position;
				this.rotation = this.e.bone.rotation;
			}

			// Token: 0x06000AB1 RID: 2737 RVA: 0x0004459E File Offset: 0x0004279E
			public void UpdateEffectorWeights(float w)
			{
				this.e.positionWeight = w * this.weight;
				this.e.rotationWeight = w * this.weight;
			}

			// Token: 0x06000AB2 RID: 2738 RVA: 0x000445C8 File Offset: 0x000427C8
			public void SetPosition(float w)
			{
				this.e.positionOffset += (this.position - this.e.bone.position) * w * this.weight;
			}

			// Token: 0x06000AB3 RID: 2739 RVA: 0x00044617 File Offset: 0x00042817
			public void SetRotation(float w)
			{
				this.e.bone.rotation = Quaternion.Slerp(this.e.bone.rotation, this.rotation, w * this.weight);
			}

			// Token: 0x04000A7E RID: 2686
			[Tooltip("The type of effector (hand, foot, shoulder...) - this is just an enum")]
			public FullBodyBipedEffector effector;

			// Token: 0x04000A7F RID: 2687
			[Tooltip("How much should motion be absorbed on this effector")]
			public float weight = 1f;

			// Token: 0x04000A80 RID: 2688
			private Vector3 position;

			// Token: 0x04000A81 RID: 2689
			private Quaternion rotation = Quaternion.identity;

			// Token: 0x04000A82 RID: 2690
			private IKEffector e;
		}
	}
}
