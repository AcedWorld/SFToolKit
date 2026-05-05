using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200012D RID: 301
	public class Inertia : OffsetModifier
	{
		// Token: 0x060009B4 RID: 2484 RVA: 0x0003CC94 File Offset: 0x0003AE94
		public void ResetBodies()
		{
			this.lastTime = Time.time;
			Inertia.Body[] array = this.bodies;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0003CCCC File Offset: 0x0003AECC
		protected override void OnModifyOffset()
		{
			Inertia.Body[] array = this.bodies;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this.ik.solver, this.weight, base.deltaTime);
			}
			base.ApplyLimits(this.limits);
		}

		// Token: 0x040008E2 RID: 2274
		[Tooltip("The array of Bodies")]
		public Inertia.Body[] bodies;

		// Token: 0x040008E3 RID: 2275
		[Tooltip("The array of OffsetLimits")]
		public OffsetModifier.OffsetLimits[] limits;

		// Token: 0x0200012E RID: 302
		[Serializable]
		public class Body
		{
			// Token: 0x060009B7 RID: 2487 RVA: 0x0003CD19 File Offset: 0x0003AF19
			public void Reset()
			{
				if (this.transform == null)
				{
					return;
				}
				this.lazyPoint = this.transform.position;
				this.lastPosition = this.transform.position;
				this.direction = Vector3.zero;
			}

			// Token: 0x060009B8 RID: 2488 RVA: 0x0003CD58 File Offset: 0x0003AF58
			public void Update(IKSolverFullBodyBiped solver, float weight, float deltaTime)
			{
				if (this.transform == null)
				{
					return;
				}
				if (this.firstUpdate)
				{
					this.Reset();
					this.firstUpdate = false;
				}
				this.direction = Vector3.Lerp(this.direction, (this.transform.position - this.lazyPoint) / deltaTime * 0.01f, deltaTime * this.acceleration);
				this.lazyPoint += this.direction * deltaTime * this.speed;
				this.delta = this.transform.position - this.lastPosition;
				this.lazyPoint += this.delta * this.matchVelocity;
				this.lazyPoint.y = this.lazyPoint.y + this.gravity * deltaTime;
				foreach (Inertia.Body.EffectorLink effectorLink in this.effectorLinks)
				{
					solver.GetEffector(effectorLink.effector).positionOffset += (this.lazyPoint - this.transform.position) * effectorLink.weight * weight;
				}
				this.lastPosition = this.transform.position;
			}

			// Token: 0x040008E4 RID: 2276
			[Tooltip("The Transform to follow, can be any bone of the character")]
			public Transform transform;

			// Token: 0x040008E5 RID: 2277
			[Tooltip("Linking the body to effectors. One Body can be used to offset more than one effector")]
			public Inertia.Body.EffectorLink[] effectorLinks;

			// Token: 0x040008E6 RID: 2278
			[Tooltip("The speed to follow the Transform")]
			public float speed = 10f;

			// Token: 0x040008E7 RID: 2279
			[Tooltip("The acceleration, smaller values means lazyer following")]
			public float acceleration = 3f;

			// Token: 0x040008E8 RID: 2280
			[Tooltip("Matching target velocity")]
			[Range(0f, 1f)]
			public float matchVelocity;

			// Token: 0x040008E9 RID: 2281
			[Tooltip("gravity applied to the Body")]
			public float gravity;

			// Token: 0x040008EA RID: 2282
			private Vector3 delta;

			// Token: 0x040008EB RID: 2283
			private Vector3 lazyPoint;

			// Token: 0x040008EC RID: 2284
			private Vector3 direction;

			// Token: 0x040008ED RID: 2285
			private Vector3 lastPosition;

			// Token: 0x040008EE RID: 2286
			private bool firstUpdate = true;

			// Token: 0x0200012F RID: 303
			[Serializable]
			public class EffectorLink
			{
				// Token: 0x040008EF RID: 2287
				[Tooltip("Type of the FBBIK effector to use")]
				public FullBodyBipedEffector effector;

				// Token: 0x040008F0 RID: 2288
				[Tooltip("Weight of using this effector")]
				public float weight;
			}
		}
	}
}
