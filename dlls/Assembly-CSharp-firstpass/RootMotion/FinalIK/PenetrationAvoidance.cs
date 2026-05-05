using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000138 RID: 312
	public class PenetrationAvoidance : OffsetModifier
	{
		// Token: 0x060009E5 RID: 2533 RVA: 0x0003DAA4 File Offset: 0x0003BCA4
		protected override void OnModifyOffset()
		{
			PenetrationAvoidance.Avoider[] array = this.avoiders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Solve(this.ik.solver, this.weight);
			}
		}

		// Token: 0x04000921 RID: 2337
		[Tooltip("Definitions of penetration avoidances.")]
		public PenetrationAvoidance.Avoider[] avoiders;

		// Token: 0x02000139 RID: 313
		[Serializable]
		public class Avoider
		{
			// Token: 0x060009E7 RID: 2535 RVA: 0x0003DAE0 File Offset: 0x0003BCE0
			public void Solve(IKSolverFullBodyBiped solver, float weight)
			{
				this.offsetTarget = this.GetOffsetTarget(solver);
				float smoothTime = (this.offsetTarget.sqrMagnitude > this.offset.sqrMagnitude) ? this.smoothTimeIn : this.smoothTimeOut;
				this.offset = Vector3.SmoothDamp(this.offset, this.offsetTarget, ref this.offsetV, smoothTime);
				foreach (PenetrationAvoidance.Avoider.EffectorLink effectorLink in this.effectors)
				{
					solver.GetEffector(effectorLink.effector).positionOffset += this.offset * weight * effectorLink.weight;
				}
			}

			// Token: 0x060009E8 RID: 2536 RVA: 0x0003DB8C File Offset: 0x0003BD8C
			private Vector3 GetOffsetTarget(IKSolverFullBodyBiped solver)
			{
				Vector3 vector = Vector3.zero;
				foreach (Transform transform in this.raycastFrom)
				{
					vector += this.Raycast(transform.position, this.raycastTo.position + vector);
				}
				return vector;
			}

			// Token: 0x060009E9 RID: 2537 RVA: 0x0003DBE0 File Offset: 0x0003BDE0
			private Vector3 Raycast(Vector3 from, Vector3 to)
			{
				Vector3 direction = to - from;
				float magnitude = direction.magnitude;
				RaycastHit raycastHit;
				if (this.raycastRadius <= 0f)
				{
					Physics.Raycast(from, direction, out raycastHit, magnitude, this.layers);
				}
				else
				{
					Physics.SphereCast(from, this.raycastRadius, direction, out raycastHit, magnitude, this.layers);
				}
				if (raycastHit.collider == null)
				{
					return Vector3.zero;
				}
				return Vector3.Project(-direction.normalized * (magnitude - raycastHit.distance), raycastHit.normal);
			}

			// Token: 0x04000922 RID: 2338
			[Tooltip("Bones to start the raycast from. Multiple raycasts can be used by assigning more than 1 bone.")]
			public Transform[] raycastFrom;

			// Token: 0x04000923 RID: 2339
			[Tooltip("The Transform to raycast towards. Usually the body part that you want to keep from penetrating.")]
			public Transform raycastTo;

			// Token: 0x04000924 RID: 2340
			[Tooltip("If 0, will use simple raycasting, if > 0, will use sphere casting (better, but slower).")]
			[Range(0f, 1f)]
			public float raycastRadius;

			// Token: 0x04000925 RID: 2341
			[Tooltip("Linking this to FBBIK effectors.")]
			public PenetrationAvoidance.Avoider.EffectorLink[] effectors;

			// Token: 0x04000926 RID: 2342
			[Tooltip("The time of smooth interpolation of the offset value to avoid penetration.")]
			public float smoothTimeIn = 0.1f;

			// Token: 0x04000927 RID: 2343
			[Tooltip("The time of smooth interpolation of the offset value blending out of penetration avoidance.")]
			public float smoothTimeOut = 0.3f;

			// Token: 0x04000928 RID: 2344
			[Tooltip("Layers to keep penetrating from.")]
			public LayerMask layers;

			// Token: 0x04000929 RID: 2345
			private Vector3 offset;

			// Token: 0x0400092A RID: 2346
			private Vector3 offsetTarget;

			// Token: 0x0400092B RID: 2347
			private Vector3 offsetV;

			// Token: 0x0200013A RID: 314
			[Serializable]
			public class EffectorLink
			{
				// Token: 0x0400092C RID: 2348
				[Tooltip("Effector to apply the offset to.")]
				public FullBodyBipedEffector effector;

				// Token: 0x0400092D RID: 2349
				[Tooltip("Multiplier of the offset value, can be negative.")]
				public float weight;
			}
		}
	}
}
