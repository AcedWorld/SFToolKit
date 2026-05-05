using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000F0 RID: 240
	[Serializable]
	public class InteractionLookAt
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x00036078 File Offset: 0x00034278
		public void Look(Transform target, float time)
		{
			if (this.ik == null)
			{
				return;
			}
			if (this.ik.solver.IKPositionWeight <= 0f)
			{
				this.ik.solver.IKPosition = this.ik.solver.GetRoot().position + this.ik.solver.GetRoot().forward * 3f;
			}
			this.lookAtTarget = target;
			this.stopLookTime = time;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00036102 File Offset: 0x00034302
		public void OnFixTransforms()
		{
			if (this.ik == null)
			{
				return;
			}
			if (this.ik.fixTransforms)
			{
				this.ik.solver.FixTransforms();
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00036130 File Offset: 0x00034330
		public void Update()
		{
			if (this.ik == null)
			{
				return;
			}
			if (this.ik.enabled)
			{
				this.ik.enabled = false;
			}
			if (this.lookAtTarget == null)
			{
				return;
			}
			if (this.isPaused)
			{
				this.stopLookTime += Time.deltaTime;
			}
			float num = (Time.time < this.stopLookTime) ? this.weightSpeed : (-this.weightSpeed);
			this.weight = Mathf.Clamp(this.weight + num * Time.deltaTime, 0f, 1f);
			this.ik.solver.IKPositionWeight = Interp.Float(this.weight, InterpolationMode.InOutQuintic);
			this.ik.solver.IKPosition = Vector3.Lerp(this.ik.solver.IKPosition, this.lookAtTarget.position, this.lerpSpeed * Time.deltaTime);
			if (this.weight <= 0f)
			{
				this.lookAtTarget = null;
			}
			this.firstFBBIKSolve = true;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00036244 File Offset: 0x00034444
		public void SolveSpine()
		{
			if (this.ik == null)
			{
				return;
			}
			if (!this.firstFBBIKSolve)
			{
				return;
			}
			float headWeight = this.ik.solver.headWeight;
			float eyesWeight = this.ik.solver.eyesWeight;
			this.ik.solver.headWeight = 0f;
			this.ik.solver.eyesWeight = 0f;
			this.ik.solver.Update();
			this.ik.solver.headWeight = headWeight;
			this.ik.solver.eyesWeight = eyesWeight;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000362E8 File Offset: 0x000344E8
		public void SolveHead()
		{
			if (this.ik == null)
			{
				return;
			}
			if (!this.firstFBBIKSolve)
			{
				return;
			}
			float bodyWeight = this.ik.solver.bodyWeight;
			this.ik.solver.bodyWeight = 0f;
			this.ik.solver.Update();
			this.ik.solver.bodyWeight = bodyWeight;
			this.firstFBBIKSolve = false;
		}

		// Token: 0x0400079C RID: 1948
		[Tooltip("(Optional) reference to the LookAtIK component that will be used to make the character look at the objects that it is interacting with.")]
		public LookAtIK ik;

		// Token: 0x0400079D RID: 1949
		[Tooltip("Interpolation speed of the LookAtIK target.")]
		public float lerpSpeed = 5f;

		// Token: 0x0400079E RID: 1950
		[Tooltip("Interpolation speed of the LookAtIK weight.")]
		public float weightSpeed = 1f;

		// Token: 0x0400079F RID: 1951
		[HideInInspector]
		public bool isPaused;

		// Token: 0x040007A0 RID: 1952
		private Transform lookAtTarget;

		// Token: 0x040007A1 RID: 1953
		private float stopLookTime;

		// Token: 0x040007A2 RID: 1954
		private float weight;

		// Token: 0x040007A3 RID: 1955
		private bool firstFBBIKSolve;
	}
}
